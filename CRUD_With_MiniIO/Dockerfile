FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
MAINTAINER trungNguyen<MANGNEK>
WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "crud_with_MiniIO/crud_with_MiniIO.csproj"
WORKDIR /src
RUN dotnet build "crud_with_MiniIO/crud_with_MiniIO.csproj" -c Release -o /app/build
RUN dotnet publish "crud_with_MiniIO/crud_with_MiniIO.csproj" -c Release -o /app/publish
from base As final
EXPOSE 8080
COPY --from=build /app/publish .

ENTRYPOINT [ "dotnet" ,"crud_with_MiniIO.dll" ]
