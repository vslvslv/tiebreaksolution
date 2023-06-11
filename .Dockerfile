# Specify the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory
WORKDIR /app

# Copy the solution file and restore NuGet packages
COPY TieBreakClient.sln .
COPY . .
RUN dotnet restore

# Build the test project
RUN dotnet build --configuration Release --no-restore

# Run the tests and generate NUnit output
CMD ["dotnet", "test", "--logger:console;verbosity=detailed", "--results-directory", "/test-results"]