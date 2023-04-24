#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 30000
EXPOSE 30001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MobileGateway.API/MobileGateway.API.csproj", "MobileGateway.API/"]
RUN dotnet restore "MobileGateway.API/MobileGateway.API.csproj"
COPY . .
WORKDIR "/src/MobileGateway.API"
RUN dotnet build "MobileGateway.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MobileGateway.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MobileGateway.API.dll"]