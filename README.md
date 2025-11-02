# People Management System

A full-stack application built using **.NET 9**, **Angular 20** and **SQL Server**.
---

## Backend Tech Stack
- .NET 9 Web API  
- Entity Framework Core 9 (Code-First)  
- SQL Server  
- Serilog (Console + File logging)  
- xUnit, Moq
- Swagger support  

### Frontend Tech Stack
- Angular 20 with Typescript  
- Bootstrap 5    

---

#  Architecture Overview (Clean Architecture)
The backend is divided into API, Core and Infrastructure
- The Core is for business logic. (models and contracts)
- The API is the presentation layer. The application layer typically found in other clean architecture is mixed here in API project.
- The Infrastructure is for DB connection and any third party api connections if required

## Architecture discisions
- Dependency injection, Serilog logging, Swagger for internal testing, xUnit for unit and integration testing, MoQ for mocking

# Running the backend locally
1. Create database (peoplemangementdb)
2. Setup connection string in API project's appsettings.json
3. Apply EF core migrations with API as starting project and Infrastructure as targeted project
   ```
   dotnet ef database update -s PeopleManagement.API -p PeopleManagement.Infrastructure
   ```
4. Run the API with visual studio or via cli with `dotnet run --project PeopleManagement.API`
5. The app should be running now. View the swagger docs with full list of APIs on [https://localhost:7071/swagger]
6. Tests can be run with `dotnet test` inside the **PeopleManagement.Tests** project

# Running the frontend locally
1. Open terminal in the frontend folder
2. Restore node_modules with `npm install`
3. API url is set in **services/people.service.ts** and **services/address.service.ts** with hard-coded values. Ensure they point to correct backend url. (Future enhancement will move this to a more centralized location in config file)
4. `npm start` to run the project

# Future Enhancements
## Redis caching
Caching paginated result for first page and for frequented results
## Dockerization
API, Angular app and SQL server can be containarized together to be shipped with single command along with Redis, RabbitMQ or any other service added in the future
## SignalR live notification
If change notification is desired, signalR can be implemented
## Authentication and authorization
For better control and security
JWT basesd login and role management
## UI enhancements
Sorting, filtering, search, angular material design
