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

ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true

CMD ["sh", "-c", "dotnet NazmulPortfolio.dll --urls http://0.0.0.0:${PORT:-8080}"]
