<#
.SYNOPSIS
    Restores and runs the ManateeBackend API.

.PARAMETER Configuration
    Build configuration to run (Debug or Release). Defaults to Debug.

.EXAMPLE
    .\run-api.ps1
    .\run-api.ps1 -Configuration Release
#>

param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Debug"
)

$ErrorActionPreference = "Stop"

$root = $PSScriptRoot
$solution = Join-Path $root "ManateeBackend.sln"
$apiProject = Join-Path $root "src\ManateeBackend.Api\ManateeBackend.Api.csproj"

if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    Write-Error "dotnet SDK not found on PATH. Install the .NET 10 SDK from https://dotnet.microsoft.com/download and try again."
    exit 1
}

Write-Host "Restoring packages..." -ForegroundColor Cyan
dotnet restore $solution

Write-Host "Running ManateeBackend.Api ($Configuration)..." -ForegroundColor Cyan
dotnet run --project $apiProject --configuration $Configuration
