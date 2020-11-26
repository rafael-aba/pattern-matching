FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o publish
ENTRYPOINT ["dotnet", "publish/pattern-matching.dll"]