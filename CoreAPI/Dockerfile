## syntax=docker/dockerfile:1
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
#WORKDIR /app
#
## Copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore
#
## Copy everything else and build
#COPY . ./
#RUN dotnet publish -c Release -o out
#
## Build runtime image
#FROM mcr.microsoft.com/dotnet/aspnet:6.0
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "CoreAPI.dll"]




### syntax=docker/dockerfile:1
##FROM mcr.microsoft.com/dotnet/aspnet:6.0
##FROM mcr.microsoft.com/dotnet/runtime:6.0
#FROM mcr.microsoft.com/dotnet/runtime:6.0-alpine
#WORKDIR /App
#COPY bin/Release/net6.0/publish/ ./
#EXPOSE 80
#ENTRYPOINT ["dotnet", "CoreAPI.dll"]





### syntax=docker/dockerfile:1
##Linux base
##FROM mcr.microsoft.com/dotnet/runtime:6.0-alpine
#FROM mcr.microsoft.com/dotnet/runtime:6.0.5-alpine3.15-arm64v8
#WORKDIR /App
#COPY bin/Release/net6.0/publish/ ./
#ENTRYPOINT ["dotnet", "CoreAPI.dll"]
#



# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY CoreAPI.csproj ./
RUN dotnet restore "./CoreAPI.csproj"

# Copy everything else and build
COPY . .
#RUN dotnet publish -c Release -o out --runtime alpine-x64 --self-contained true /p:PublishTrimmed=true /p:PublishSingleFile=true
RUN dotnet publish -c Release -o out --runtime alpine-x64 --self-contained true

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:6.0-alpine
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "CoreAPI.dll"]
#ENTRYPOINT ["./CoreAPI"]




##Linux base
##Single file export
#FROM mcr.microsoft.com/dotnet/runtime:6.0-alpine
#WORKDIR /App
#COPY out/ ./
#EXPOSE 80
#ENTRYPOINT ["./CoreAPI"]

