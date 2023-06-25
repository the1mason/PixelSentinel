#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ServerIndex/WebServices/ServerIndex.WebServices.Resolver/ServerIndex.WebServices.Resolver.csproj", "ServerIndex/WebServices/ServerIndex.WebServices.Resolver/"]
RUN dotnet restore "ServerIndex/WebServices/ServerIndex.WebServices.Resolver/ServerIndex.WebServices.Resolver.csproj"
COPY . .
WORKDIR "/src/ServerIndex/WebServices/ServerIndex.WebServices.Resolver"
RUN dotnet build "ServerIndex.WebServices.Resolver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServerIndex.WebServices.Resolver.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServerIndex.WebServices.Resolver.dll"]