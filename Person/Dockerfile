FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS base

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

# copy csproj and restore as distinct layers
COPY Person.csproj ./Person/
RUN dotnet restore Person/Person.csproj

# copy everything else and build
COPY . ./Person/
RUN dotnet publish Person/Person.csproj -c $BUILDCONFIG -o out /p:Version=$VERSION

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY --from=base /out ./

EXPOSE 80
ENTRYPOINT ["dotnet", "Person.dll"]