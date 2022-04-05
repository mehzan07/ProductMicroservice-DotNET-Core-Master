#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["ProductMicroservice/ProductMicroservice.csproj", "ProductMicroservice/ProductMicroservice/"]
RUN dotnet restore "ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj" 
COPY . .
WORKDIR "/src/ProductMicroservice/ProductMicroservice"
RUN dotnet build "ProductMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroservice.dll"]