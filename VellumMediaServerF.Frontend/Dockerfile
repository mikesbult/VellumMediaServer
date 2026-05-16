# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Match your exact folder structure
COPY ["VellumMediaServerF.Frontend/VellumMediaServerF.Frontend.csproj", "VellumMediaServerF.Frontend/"]
RUN dotnet restore "VellumMediaServerF.Frontend/VellumMediaServerF.Frontend.csproj"

COPY . .
WORKDIR "/src/VellumMediaServerF.Frontend"
RUN dotnet publish "VellumMediaServerF.Frontend.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "VellumMediaServerF.Frontend.dll"]