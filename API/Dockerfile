FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Restaurants.sln ./
COPY API/API.csproj API/
COPY Repositories.Fake/Repositories.Fake.csproj Repositories.Fake/
COPY Models/Models.csproj Models/
COPY Utilities/Utilities.csproj Utilities/
COPY Repositories.Interfaces/Repositories.Interfaces.csproj Repositories.Interfaces/
COPY Repositories.MongoDb/Repositories.MongoDb.csproj Repositories.MongoDb/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/API
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "API.dll"]
