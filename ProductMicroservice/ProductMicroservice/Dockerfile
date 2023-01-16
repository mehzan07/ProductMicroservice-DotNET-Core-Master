#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 1433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
##COPY ["ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj", "ProductMicroservice/ProductMicroservice/"]
## RUN dotnet restore "ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj"
COPY ["ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj", "ProductMicroservice/"]
RUN dotnet restore "ProductMicroservice/ProductMicroservice.csproj"
##COPY . .
COPY . ProductMicroservice/
##RUN dotnet build "ProductMicroservice.csproj" -c Release -o /app/build
WORKDIR "/src/ProductMicroservice/ProductMicroservice"
RUN dotnet build "ProductMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroservice.dll"]