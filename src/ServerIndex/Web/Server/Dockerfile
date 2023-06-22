#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ServerIndex/Web/Server/ServerIndex.Server.csproj", "ServerIndex/Web/Server/"]
COPY ["ServerIndex/Web/Client/ServerIndex.Client.csproj", "ServerIndex/Web/Client/"]
RUN dotnet restore "ServerIndex/Web/Server/ServerIndex.Server.csproj"
COPY . .
WORKDIR "/src/ServerIndex/Web/Server"
RUN dotnet build "ServerIndex.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServerIndex.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServerIndex.Server.dll"]