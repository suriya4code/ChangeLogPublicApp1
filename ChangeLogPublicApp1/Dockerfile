FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["ChangeLogPublicApp1/ChangeLogPublicApp1.csproj", "ChangeLogPublicApp1/"]
RUN dotnet restore "ChangeLogPublicApp1/ChangeLogPublicApp1.csproj"
COPY . .
WORKDIR "/src/ChangeLogPublicApp1"
RUN dotnet build "ChangeLogPublicApp1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChangeLogPublicApp1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ChangeLogPublicApp1.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT ChangeLogPublicApp1.dll