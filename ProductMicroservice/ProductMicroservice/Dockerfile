#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM debian:11
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 1433
# in .NET 8 you need to add the following line, other wise you shall get error :ocalhost didn�t send any data.ERR_EMPTY_RESPONSE
ENV ASPNETCORE_HTTP_PORTS 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj", "ProductMicroservice/ProductMicroservice/"]
#COPY ["ProductMicroservice/ProductMicroservice.csproj", "ProductMicroservice/ProductMicroservice/"]

RUN dotnet restore "ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj"
#RUN dotnet restore "ProductMicroservice/ProductMicroservice.csproj"
COPY . .
WORKDIR "/src/ProductMicroservice/ProductMicroservice"
RUN dotnet build "ProductMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroservice.dll"]