---
title: "Breaking change - Microsoft.Extensions.ApiDescription.Client package deprecated"
description: "Learn about the breaking change in .NET 10 where the Microsoft.Extensions.ApiDescription.Client package has been deprecated."
ms.date: 08/07/2025
ai-usage: ai-assisted
ms.custom: https://github.com/aspnet/Announcements/issues/518
---

# Microsoft.Extensions.ApiDescription.Client package deprecated

The **Microsoft.Extensions.ApiDescription.Client** NuGet package has been deprecated starting in .NET 10. The package supplied MSBuild targets and CLI support that generated OpenAPI-based client code during the build. Projects that reference the package now receive a warning during build.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Projects could add `<PackageReference Include="Microsoft.Extensions.ApiDescription.Client" … />` and `<OpenApiReference>` items (or run `dotnet openapi`) to generate strongly-typed clients at build time.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>
  
  <ItemGroup>
    <PackageReference Include="Microsoft.Extensions.ApiDescription.Client" Version="8.0.0" />
  </ItemGroup>
  
  <ItemGroup>
    <OpenApiReference Include="swagger.json" />
  </ItemGroup>
</Project>
```

## New behavior

The package is deprecated and projects that reference it receive build warnings. The MSBuild targets and CLI commands are no longer supported.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

- The package has seen minimal updates and maintenance since its introduction.
- Its abstractions were tightly coupled to certain generators and did not scale well to others.
- Each generator now ships its own CLI/configuration experience, making the MSBuild middle-layer redundant.
- Removing the package reduces maintenance burden and clarifies the recommended workflow for client generation.

## Recommended action

1. **Remove** any `<PackageReference Include="Microsoft.Extensions.ApiDescription.Client" … />` from your project.
2. Replace `<OpenApiReference>` items or `dotnet openapi` commands with generator-specific tooling:
   - **NSwag** – use `npx nswag` or `dotnet tool run nswag` with an `.nswag` config file.
   - **Kiota** – install with `dotnet tool install -g Microsoft.OpenApi.Kiota` and run `kiota generate`.
   - **OpenAPI Generator** – invoke `openapi-generator-cli` via JAR or Docker.
3. Commit the generated client code or run generation in a custom pre-build step that does not rely on the removed package.

## Affected APIs

- NuGet package **Microsoft.Extensions.ApiDescription.Client**
- MSBuild item **`OpenApiReference`** (all instances)
- MSBuild property **`OpenApiProjectReference`**
- CLI command **`dotnet openapi`**