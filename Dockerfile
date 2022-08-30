FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /app

COPY . .
RUN dotnet clean ./my-website.sln
RUN dotnet publish ./WebAPI --configuration Release -o ./publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as RUN

WORKDIR /app/publish

COPY --from=build /app/publish .

CMD ["dotnet", "WebAPI.dll"]