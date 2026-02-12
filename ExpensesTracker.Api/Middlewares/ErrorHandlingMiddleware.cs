using System.Net;
using System.Text.Json;
using ExpensesTracker.Application.Exceptions;
using ExpensesTracker.Core.Response;

namespace ExpensesTracker.Api.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            // تحديد نوع الخطأ وكود الحالة
            response.StatusCode = error switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound, // 404
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized, // 401
                ArgumentException => (int)HttpStatusCode.BadRequest, // 400
                _ => (int)HttpStatusCode.InternalServerError, // 500
            };

            // تجهيز الرد الموحد
            var responseModel = new ApiResponse<string>(error.Message);

            // تحويله لـ JSON
            var result = JsonSerializer.Serialize(responseModel,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            await response.WriteAsync(result);
        }
    }
}