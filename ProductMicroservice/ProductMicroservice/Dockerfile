#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["/ProductMicroservice/ProductMicroservice.csproj", "ProductMicroservice/"]
#RUN dotnet restore "/ProductMicroservice/ProductMicroservice.csproj"
RUN dotnet restore "ProductMicroservice.csproj"
## RUN dotnet restore "ProductMicroservicesTest/ProductMicroservicesTest/ProductMicroservicesTest.csproj"
COPY . .
WORKDIR "/src/ProductMicroservice/ProductMicroservice"
## RUN dotnet build "/ProductMicroservice/ProductMicroservice.csproj" -c Release -o /app/build --no-restore
RUN dotnet build "ProductMicroservice.csproj" -c Release -o /app/build --no-restore
## RUN dotnet build "ProductMicroservicesTest/ProductMicroservicesTest/ProductMicroservicesTest.csproj" -c Release --no-restore



FROM build AS publish
RUN dotnet publish "ProductMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroservice.dll"]