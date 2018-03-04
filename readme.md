### MongoDB Restaurants Sample API
This is a simple REST API solution to expose the MongoDB 'Restaurants' sample dataset using:
- [MongoDB.Driver](https://docs.mongodb.com/ecosystem/drivers/) (to read/write data to/from MongoDB)
- [Bogus](https://github.com/bchavez/Bogus) (for creating fake property values)
- [AutoFixture](https://github.com/AutoFixture/AutoFixture) (for fake data generation)
- [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging/)
- [ASP.NET Core Dependency Injection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)
- [xUnit](https://xunit.github.io/) (for unit testing)
- [Swagger](https://github.com/swagger-api) (for API documentation)

This was written in Visual Studio for Mac OSX using the .NET Core 2.0 framework. Special care was taken to manage library and namespace references to keep the domain model decoupled from the underlying storage implementation.

![](https://imgur.com/l1jNYFZ "Restaurants REST API Swagger UI")
