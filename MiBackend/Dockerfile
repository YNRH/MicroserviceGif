FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
 COPY MiBackend/MiBackend.csproj .
 RUN dotnet restore
 COPY MiBackend .
 RUN dotnet publish -c release -o /app

 FROM mcr.microsoft.com/dotnet/aspnet:8.0
 WORKDIR /app
 EXPOSE 80
 EXPOSE 443
 COPY --from=build /app .
 ENTRYPOINT ["dotnet", "MiBackend.dll"]
