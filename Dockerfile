FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["VPDoctorAppointmentApp/VPDoctorAppointmentApp.csproj", "VPDoctorAppointmentApp/"]
RUN dotnet restore "VPDoctorAppointmentApp/VPDoctorAppointmentApp.csproj"
COPY . .
WORKDIR "/src/VPDoctorAppointmentApp"
RUN dotnet build "VPDoctorAppointmentApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VPDoctorAppointmentApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VPDoctorAppointmentApp.dll"]
