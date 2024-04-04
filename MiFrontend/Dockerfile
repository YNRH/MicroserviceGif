FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY MiFrontend/MiFrontend.csproj .
RUN dotnet restore
COPY MiFrontend .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .
ENTRYPOINT ["dotnet", "MiFrontend.dll"]
