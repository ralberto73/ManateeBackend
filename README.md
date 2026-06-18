# ManateeBackend

ASP.NET Core backend built on .NET 10, following a Clean Architecture layering with a dedicated web-service-client layer.

## Solution structure

```
ManateeBackend.sln
├── src/
│   ├── ManateeBackend.Api                     # ASP.NET Core host: controllers, startup/DI wiring, config
│   ├── ManateeBackend.Application             # Use cases / application services, abstractions (interfaces)
│   ├── ManateeBackend.Domain                  # Entities and core domain logic (no dependencies on other layers)
│   ├── ManateeBackend.Infrastructure           # Implementations of Application abstractions (persistence, system services, etc.)
│   ├── ManateeBackend.Models                  # Shared DTOs/contracts referenced across layers
│   ├── ManateeBackend.WebServices             # Implementations of external web-service clients
│   └── ManateeBackend.WebServices.Interfaces  # Abstractions for external web-service clients
└── tests/
    └── ManateeBackend.Tests                   # xUnit test project
```

Dependency direction flows inward: `Api` → `Application`/`Infrastructure`/`WebServices`/`Models`; `Infrastructure` → `Application`/`Domain`; `Application` → `Domain`/`Models`/`WebServices.Interfaces`; `WebServices` → `WebServices.Interfaces`/`Models`. `Domain` and `Models` have no project dependencies.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (version pinned in `global.json`)

## Build, run, test

```powershell
# Restore + run the API (Debug by default)
.\run-api.ps1
.\run-api.ps1 -Configuration Release

# Or use the SDK directly
dotnet restore
dotnet build
dotnet test
dotnet run --project src/ManateeBackend.Api
```

The API listens on `https://localhost:5081` / `http://localhost:5080` in the default launch profiles. A health check is available at `/api/health`.

## Configuration & logging

Configuration follows the standard ASP.NET Core `appsettings.json` / `appsettings.{Environment}.json` pattern. Logging is handled by Serilog, writing to the console and to rolling files under `logs/` (gitignored). Do not commit environment-specific secrets — use `appsettings.*.local.json` (gitignored) or user secrets/environment variables instead.

## Coding conventions

Formatting and naming conventions are enforced via `.editorconfig`. Run `dotnet format` before committing if your editor doesn't apply them automatically.
