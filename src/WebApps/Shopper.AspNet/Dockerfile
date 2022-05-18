#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApps/Shopper.AspNet/Shopper.AspNet.csproj", "WebApps/Shopper.AspNet/"]
RUN dotnet restore "WebApps/Shopper.AspNet/Shopper.AspNet.csproj"
COPY . .
WORKDIR "/src/WebApps/Shopper.AspNet"
RUN dotnet build "Shopper.AspNet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopper.AspNet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopper.AspNet.dll"]
