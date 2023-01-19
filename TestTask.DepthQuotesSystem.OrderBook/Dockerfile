#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestTask.DepthQuotesSystem.OrderBook/TestTask.DepthQuotesSystem.OrderBook.csproj", "TestTask.DepthQuotesSystem.OrderBook/"]
RUN dotnet restore "TestTask.DepthQuotesSystem.OrderBook/TestTask.DepthQuotesSystem.OrderBook.csproj"
COPY . .
WORKDIR "/src/TestTask.DepthQuotesSystem.OrderBook"
RUN dotnet build "TestTask.DepthQuotesSystem.OrderBook.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTask.DepthQuotesSystem.OrderBook.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTask.DepthQuotesSystem.OrderBook.dll"]