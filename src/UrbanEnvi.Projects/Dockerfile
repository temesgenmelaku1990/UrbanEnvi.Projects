FROM mcr.microsoft.com/dotnet/aspnet:6.0-cbl-mariner1.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:6.0-cbl-mariner1.0 AS build

ARG FEED_ACCESSTOKEN

ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS '{"endpointCredentials":[{"endpoint":"https://pkgs.dev.azure.com/ymijorski/UrbanEnvi/_packaging/urbanenvi/nuget/v3/index.json","username":"NoRealUserNameAsIsNotRequired","password":"'${FEED_ACCESSTOKEN}'"}]}'
RUN wget -O - https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | bash

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
