FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o publish
ENTRYPOINT ["dotnet", "publish/pattern-matching.dll"]