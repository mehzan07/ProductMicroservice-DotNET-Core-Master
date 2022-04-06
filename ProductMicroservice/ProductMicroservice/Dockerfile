#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
##COPY ["ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj", "ProductMicroservice/ProductMicroservice/"]
## RUN dotnet restore "ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj"
COPY ["ProductMicroservice/ProductMicroservice.csproj", "ProductMicroservice/"]
COPY ["../../ProductMicroservicesTest/ProductMicroservicesTest.csproj", "ProductMicroservicesTest/"]
RUN dotnet restore "ProductMicroservice/ProductMicroservice.csproj"
RUN dotnet restore "ProductMicroservicesTest/ProductMicroservicesTest.csproj"
##COPY . .
COPY . ProductMicroservice/
WORKDIR "/src/ProductMicroservice/ProductMicroservice"
RUN dotnet build "ProductMicroservice.csproj" -c Release -o /app/build

COPY . ProductMicroservicesTest/
WORKDIR "/src/ProductMicroservicesTest/ProductMicroservicesTest"
RUN dotnet build "ProductMicroservicesTest.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "ProductMicroservice.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroservice.dll"]

## publish Test
FROM build AS publish
RUN dotnet publish "ProductMicroservicesTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroservicesTest.dll"]