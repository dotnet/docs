# 01-prerequisites: Verify .NET 11 and Visual Studio prerequisites

Confirm the installed .NET 11 SDK, Visual Studio 2026 version, and any applicable SDK selection file before changing the solution. The SDK and Visual Studio 2026 are present in the environment; verify that no `global.json` pin prevents this solution from using them.

## Research

- The solution contains three SDK-style C# projects and no C++ projects.
- `dotnet --version` from the solution directory resolves to .NET SDK `11.0.100`; Visual Studio `18.12.12405.243` is installed.
- No `global.json` exists in the solution directory or its parent directories, so no repository SDK pin overrides the installed SDK.

**Done when**: The solution can resolve the installed .NET 11 SDK, and applicable SDK configuration does not block the target framework.
