### MongoDB Restaurants Sample API
This is a simple REST API solution to expose the MongoDB 'Restaurants' sample dataset using:
- MongoDB.Driver (to read/write data to/from MongoDB)
- Bogus (for creating fake property values)
- AutoFixture (for fake data generation)
- Microsoft Extensions Framework (for dependency injection and logging)
- xUnit (for unit testing)
- Swagger (for API documentation)

This was written in Visual Studio for Mac OSX using the .NET Core 2.0 framework. Special care was taken to manage library and namespace references to keep the domain model decoupled from the underlying storage implementation.
