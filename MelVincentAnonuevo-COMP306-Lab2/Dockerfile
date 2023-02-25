FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MelVincentAnonuevo-comp306-lab2.csproj", "."]
RUN dotnet restore "./MelVincentAnonuevo-comp306-lab2.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MelVincentAnonuevo-comp306-lab2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MelVincentAnonuevo-comp306-lab2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MelVincentAnonuevo-comp306-lab2.dll"]