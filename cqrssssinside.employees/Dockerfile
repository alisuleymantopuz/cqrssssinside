FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY cqrssssinside.employees/cqrssssinside.employees.csproj cqrssssinside.employees/
COPY cqrssssinside.domain/cqrssssinside.domain.csproj cqrssssinside.domain/
COPY cqrssssinside.domain.appServices/cqrssssinside.domain.appServices.csproj cqrssssinside.domain.appServices/
COPY cqrssssinside.domain.infrastructure/cqrssssinside.domain.infrastructure.csproj cqrssssinside.domain.infrastructure/
COPY cqrssssinside.domain.dto/cqrssssinside.domain.dto.csproj cqrssssinside.domain.dto/
COPY cqrssssinside.web.common/cqrssssinside.web.common.csproj cqrssssinside.web.common/
RUN dotnet restore cqrssssinside.employees/cqrssssinside.employees.csproj
COPY . .
WORKDIR /src/cqrssssinside.employees
RUN dotnet build cqrssssinside.employees.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish cqrssssinside.employees.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "cqrssssinside.employees.dll"]
