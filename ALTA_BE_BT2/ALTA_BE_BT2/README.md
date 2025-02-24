# Hướng dẫn cài đặt và chạy dự án

## -nhut379-

## 1. Install necessary libraries

Run the following commands to install:

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.*
dotnet add package Microsoft.EntityFrameworkCore --version 6.*
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.*   
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 6.*

```

Then, restore the packages:

```bash
dotnet restore
```

## 2. Configure PostgreSQL connection string

In the `appsettings.json` file, add or modify the connection string:

```json
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=YourDatabase;Username=YourUser;Password=YourPassword"
}
```

## 3. Create Database and Apply Migration

### **3.1. Create the first Migration**

Run the following command to create a migration:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

If you need to reset the database, you can use:

```bash
dotnet ef database drop
```

Then run again:

```bash
dotnet ef database update
```

## 4. Run the project

Run the application with the command:

```bash
dotnet run
```

If running in a development environment:

```bash
dotnet watch run
```

The application will start and listen on `http://localhost:5000` or the configured port.

## 5. Check and Debug

- Check installed packages:

```bash
dotnet list package
```

- Check the database:

```bash
dotnet ef dbcontext list
```

- If you encounter errors, try `dotnet clean` and `dotnet build` before running again.

## 6. Notes

- Ensure PostgreSQL is running.
- If using Docker, you can run PostgreSQL with:

docker run --name postgres -e POSTGRES_USER=YourUser -e POSTGRES_PASSWORD=YourPassword -p 5432:5432 -d postgres
