#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["EStockMarket/EStockMarket.csproj", "EStockMarket/"]
COPY ["EStockMarket.Business/EStockMarket.Business.csproj", "EStockMarket.Business/"]
COPY ["EStockMarket.Model/EStockMarket.Model.csproj", "EStockMarket.Model/"]
COPY ["EStockMarket.DataAccess/EStockMarket.DataAccess.csproj", "EStockMarket.DataAccess/"]
RUN dotnet restore "EStockMarket/EStockMarket.csproj"
COPY . .
WORKDIR "/src/EStockMarket"
RUN dotnet build "EStockMarket.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EStockMarket.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EStockMarket.dll"]