FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY NazmulPortfolio/NazmulPortfolio.csproj NazmulPortfolio/
RUN dotnet restore NazmulPortfolio/NazmulPortfolio.csproj

COPY . .
WORKDIR /src/NazmulPortfolio
RUN dotnet publish -c Release -o /app/publish --no-restore /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:10000
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
EXPOSE 10000

ENTRYPOINT ["dotnet", "NazmulPortfolio.dll"]
