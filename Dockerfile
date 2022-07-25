#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Facec.WebApi/Facec.WebApi.csproj", "Facec.WebApi/"]
COPY ["Facec.IoC/Facec.IoC.csproj", "Facec.IoC/"]
COPY ["Facec.Dominio/Facec.Dominio.csproj", "Facec.Dominio/"]
COPY ["Facec.Servicos/Facec.Servicos.csproj", "Facec.Servicos/"]
COPY ["Facec.Repositorio/Facec.Repositorio.csproj", "Facec.Repositorio/"]
RUN dotnet restore "Facec.WebApi/Facec.WebApi.csproj"
COPY . .
WORKDIR "/src/Facec.WebApi"
RUN dotnet build "Facec.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Facec.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#ENTRYPOINT ["dotnet", "Facec.WebApi.dll"]
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet Facec.WebApi.dll