namespace ExpensesTracker.Core.Response;

public class ApiResponse<T>
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public T Data { get; set; }

    // Constructor للنجاح
    public ApiResponse(T data, string message = null)
    {
        Succeeded = true;
        Message = message ?? "Success";
        Data = data;
        Errors = null;
    }

    // Constructor للفشل
    public ApiResponse(string message, List<string> errors = null)
    {
        Succeeded = false;
        Message = message;
        Errors = errors;
        Data = default;
    }
}