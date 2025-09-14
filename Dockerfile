FROM mcr.microsoft.com/dotnet/sdk:9.0 AS builder

COPY /src /app
RUN dotnet publish -c Release -o /out /app/my-action.csproj
COPY entrypoint.sh /out/entrypoint.sh

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS base
COPY --from=builder /out /app
RUN chmod +x /app/entrypoint.sh
