
# 💸 Expense Tracker API

A robust, scalable, and secure RESTful API built with **.NET 8** to manage personal finances, track daily expenses, set monthly budgets, and automate recurring bills.

---

## 🏗️ Architecture

This project follows **Clean Architecture** principles to ensure separation of concerns, maintainability, and testability.

### 🔹 Core
- Domain Entities: `Transaction`, `Category`, `Budget`, `ApplicationUser`
- Enums

### 🔹 Application
- DTOs (Data Transfer Objects)
- Interfaces (Contracts)
- AutoMapper Profiles
- FluentValidation Rules

### 🔹 Infrastructure
- Entity Framework Core DbContext
- Generic Repository Pattern
- Unit of Work Pattern
- Service Implementations

### 🔹 API
- Controllers
- Middlewares
- Dependency Injection Configuration

---

## 🚀 Key Features

- 🔐 **User Authentication**
  - Secure registration & login using ASP.NET Core Identity
  - JWT Bearer Token authentication

- 🔒 **Data Isolation**
  - Each user can only access their own data
  - All entities are linked to the authenticated user ID

- 📊 **Financial Dashboard**
  - Total Income
  - Total Expenses
  - Current Balance

- 📅 **Budgeting System**
  - Monthly budget limits per category
  - Real-time tracking of spending

- 🔁 **Automated Recurring Expenses**
  - Background jobs using Hangfire
  - Example: automatic monthly bill deductions

- 🎨 **Custom Categories**
  - Create and manage categories
  - Support for custom icons and colors

---

## 🛠️ Tech Stack

- **Framework:** .NET 8 Web API  
- **ORM:** Entity Framework Core  
- **Database:** SQL Server  
- **Authentication:** JWT & ASP.NET Core Identity  
- **Background Jobs:** Hangfire  
- **Validation:** FluentValidation  
- **Mapping:** AutoMapper  

---

## 🚦 Getting Started

### 📌 Prerequisites

- .NET 8 SDK
- SQL Server (LocalDB or Docker)

---

### ⚙️ Installation

1. Clone the repository:

```bash
git clone <your-repo-url>
````

2. Navigate to the API folder:

```bash
cd ExpensesTracker.Api
```

3. Update `appsettings.json`:

   * Add your SQL Server connection string
   * Configure JWT secrets

4. Apply database migrations:

```bash
dotnet ef database update --project ../ExpensesTracker.Infrastructure --startup-project .
```

5. Run the application:

```bash
dotnet run
```

6. Open Swagger UI:

```
https://localhost:<port>/swagger
```

---

## 👨‍💻 Author

**Mahmoud Salah Elbadri**
Full Stack Developer
