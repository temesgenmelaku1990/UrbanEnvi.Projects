FROM mcr.microsoft.com/dotnet/aspnet:6.0-cbl-mariner1.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:6.0-cbl-mariner1.0 AS build

ARG FEED_ACCESSTOKEN

RUN dotnet nuget add source \
    --username USERNAME \
    --password ${FEED_ACCESSTOKEN} \
    --store-password-in-clear-text \
    --name github "https://nuget.pkg.github.com/UrbanEnvi/index.json"

WORKDIR /src
COPY . .
RUN dotnet restore "src/UrbanEnvi.Projects/UrbanEnvi.Projects.csproj"
WORKDIR "/src/src/UrbanEnvi.Projects"
RUN dotnet build "UrbanEnvi.Projects.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UrbanEnvi.Projects.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UrbanEnvi.Projects.dll"]
