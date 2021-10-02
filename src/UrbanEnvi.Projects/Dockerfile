FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

ARG FEED_ACCESSTOKEN
ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS '{"endpointCredentials":[{"endpoint":"https://pkgs.dev.azure.com/ymijorski/BootLux/_packaging/bootlux/nuget/v3/index.json","username":"NoRealUserNameAsIsNotRequired","password":"'${FEED_ACCESSTOKEN}'"}]}'
RUN wget -O - https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | bash

WORKDIR /src
COPY . .
RUN dotnet restore "src/Services/Projects/UrbanEnvi.Projects/UrbanEnvi.Projects.csproj"
WORKDIR "/src/src/Services/Projects/UrbanEnvi.Projects"
RUN dotnet build "UrbanEnvi.Projects.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UrbanEnvi.Projects.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UrbanEnvi.Projects.dll"]
