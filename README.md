# TakeAPill

TakeAPill is a simple medication management application built with **Blazor Server** and **.NET 10**. It allows authenticated users to manage their pills and create intake schedules for them.

## Main features

- User registration and login with ASP.NET Core Identity
- Google authentication
- Personal pill management
- Personal medication intake schedules
- SQL Server database support through Entity Framework Core

## Technology stack

- .NET 10
- Blazor Server
- ASP.NET Core Identity
- Entity Framework Core
- Microsoft SQL Server / LocalDB
- Bootstrap

## Running the project locally

### Prerequisites

Install the following tools:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- SQL Server LocalDB, SQL Server Express, or another SQL Server instance
- A Google Cloud project with OAuth 2.0 credentials

### 1. Clone the repository

```bash
git clone <repository-url>
cd TakeAPill
```

### 2. Configure Google authentication

The application requires Google authentication credentials at startup. From the repository root, run:

```bash
dotnet user-secrets --project TakeAPill/TakeAPill.csproj set "Authentication:Google:ClientId" "your-google-client-id"
dotnet user-secrets --project TakeAPill/TakeAPill.csproj set "Authentication:Google:ClientSecret" "your-google-client-secret"
```

For local development, add the following redirect URI to the Google OAuth client:

```text
https://localhost:7093/signin-google
```

### 3. Check the database connection

The default connection string uses SQL Server LocalDB and is stored in `TakeAPill/appsettings.json`. Change `ConnectionStrings:DefaultConnection` if you use a different SQL Server instance.

### 4. Start the application

From the repository root, restore dependencies and run the web project:

```bash
dotnet restore
dotnet run --project TakeAPill/TakeAPill.csproj
```

Open the HTTPS address displayed in the terminal, usually:

```text
https://localhost:7093
```

In the Development environment, Entity Framework Core can apply pending migrations through the development migration endpoint. If the HTTPS development certificate is not trusted, run:

```bash
dotnet dev-certs https --trust
```

## Project structure

- `TakeAPill` – Blazor web application and user interface
- `TakeAPill.Application` – application logic and use cases
- `TakeAPill.Domain` – domain models
- `TakeAPill.Infrastructure` – database access and infrastructure services

## License

This project is licensed under the [MIT License](LICENSE).
