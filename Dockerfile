FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52572
EXPOSE 44302

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /build
COPY . .
RUN dotnet restore \
	&& dotnet test Test/BoilerPlate.Test/BoilerPlate.Test.csproj \
	&& dotnet publish src/BoilerPlate/BoilerPlate.csproj -c release -o /build/publish

FROM base AS final
WORKDIR /app
EXPOSE 80/tcp
ENV ASPNETCORE_URLS http://0.0.0.0:80
COPY --from=build /build/publish .
ENTRYPOINT ["dotnet", "BoilerPlate.dll"]