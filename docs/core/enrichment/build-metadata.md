---
title: Build ambient metadata
description: Learn how to use build metadata to capture and access CI/CD build information about your application at runtime in .NET.
ms.date: 01/16/2026
---

# Build ambient metadata

The [`Microsoft.Extensions.AmbientMetadata.Build`](https://www.nuget.org/packages/Microsoft.Extensions.AmbientMetadata.Build) NuGet package provides functionality to capture build-related information and access it at runtime. During the build process, source generation captures details from CI/CD pipelines (such as build IDs, commit information, and branch names) and embeds them into the compiled application, making them available for traceability, troubleshooting, and deployment tracking.

## Why use build metadata

Build metadata provides context about the specific build that produced your running application, which enhances operational visibility:

- **Traceability**: Link runtime behavior directly to specific builds and source code commits.
- **Troubleshooting**: Quickly identify which commit or build introduced issues in production.
- **Deployment tracking**: Know exactly what code version is running in each environment.
- **Audit and compliance**: Maintain detailed records of what code was deployed and when.
- **Telemetry enrichment**: Automatically add build context to logs, metrics, and traces.

## Supported CI/CD platforms

During the build process, the build metadata component uses source generation to capture environment variables from:

- **Azure DevOps Pipelines**: Captures standard Azure Pipelines build variables during build
- **GitHub Actions**: Captures GitHub Actions workflow environment variables during build

The component works seamlessly in these CI/CD environments, automatically embedding build information into the compiled application without requiring manual configuration.

## How build metadata works

The build metadata component uses a source generator that captures build information during compilation. When you build your application, the generator reads MSBuild properties and generates code that embeds this information into your compiled assembly.

### Automatic capture in CI/CD

When building in supported CI/CD environments (Azure DevOps or GitHub Actions), environment variables are automatically captured through a transitive MSBuild props file. This file maps CI/CD environment variables to MSBuild properties that the source generator can read:

**Azure DevOps environment variables:**

- `BUILD_BUILDID` → `BuildMetadataAzureBuildId`
- `BUILD_BUILDNUMBER` → `BuildMetadataAzureBuildNumber`
- `BUILD_SOURCEBRANCHNAME` → `BuildMetadataAzureSourceBranchName`
- `BUILD_SOURCEVERSION` → `BuildMetadataAzureSourceVersion`
- `TF_BUILD` → `BuildMetadataIsAzureDevOps` (detection flag)

**GitHub Actions environment variables:**

- `GITHUB_RUN_ID` → `BuildMetadataGitHubRunId`
- `GITHUB_RUN_NUMBER` → `BuildMetadataGitHubRunNumber`
- `GITHUB_REF_NAME` → `BuildMetadataGitHubRefName`
- `GITHUB_SHA` → `BuildMetadataGitHubSha`

The source generator detects which CI/CD platform is active and uses the appropriate set of properties to populate the <xref:Microsoft.Extensions.AmbientMetadata.BuildMetadata> class.

### Manual configuration with MSBuild properties

If you're building outside of a supported CI/CD environment or want to override the automatic values, you can set MSBuild properties directly in your project file or pass them as command-line arguments.

## Install the package

To get started, install the [📦 Microsoft.Extensions.AmbientMetadata.Build](https://www.nuget.org/packages/Microsoft.Extensions.AmbientMetadata.Build) NuGet package:

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.AmbientMetadata.Build
```

Or, if you're using .NET 10+ SDK:

```dotnetcli
dotnet package add Microsoft.Extensions.AmbientMetadata.Build
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.AmbientMetadata.Build"
                  Version="*" /> <!-- Adjust version -->
```

---

## Configure build metadata

The source generator included in the `Microsoft.Extensions.AmbientMetadata.Build` package generates extension methods that simplify configuration. During the build process, it captures build information from MSBuild properties and generates code to make this data available at runtime.

You can configure build metadata using either a single convenience method or a two-step approach that provides more granular control.

### Using the UseBuildMetadata convenience method

When you add the `Microsoft.Extensions.AmbientMetadata.Build` package to your project, the source generator creates `UseBuildMetadata` extension methods that combine configuration and service registration in a single call:

**For IHostApplicationBuilder:**

```csharp
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// This method is source-generated and sets up both configuration and services
builder.UseBuildMetadata();

var host = builder.Build();
await host.RunAsync();
```

**For IHostBuilder:**

```csharp
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);

// Source-generated extension method for traditional host builder
builder.UseBuildMetadata();

var host = builder.Build();
await host.RunAsync();
```

The `UseBuildMetadata` method:

- Adds the build metadata as a configuration source (with values captured during build)
- Registers the <xref:Microsoft.Extensions.AmbientMetadata.BuildMetadata> type in dependency injection
- Uses the default configuration section `ambientmetadata:build`

### Using the two-step configuration approach

You can also configure build metadata using separate calls for configuration and service registration. This approach provides more granular control and is useful when configuration and service collection setup are in different parts of your codebase:

1. **Add build metadata to configuration**: `configuration.AddBuildMetadata()` - Adds the source-generated build metadata as a configuration source
2. **Register in services**: `services.AddBuildMetadata(configSection)` - Registers the BuildMetadata type in dependency injection

The following example shows this approach:

:::code language="csharp" source="snippets/buildmetadata-configure/Program.cs":::

With the following configuration in `appsettings.json`:

:::code language="json" source="snippets/buildmetadata-configure/appsettings.json":::

> [!NOTE]
> The `UseBuildMetadata()` method combines both of these steps into a single call for convenience. Choose the approach that best fits your application architecture. When building in a CI/CD environment (Azure DevOps or GitHub Actions), the `configuration.AddBuildMetadata()` call provides the source-generated values captured from environment variables during the build.

### Programmatic configuration

You can also set build metadata values programmatically using the options pattern:

:::code language="csharp" source="snippets/buildmetadata-configure-programmatic/Program.cs":::

This approach bypasses the source-generated configuration source and directly configures the metadata values.

### Custom configuration section

If you want to use a different configuration section name, you can specify it when calling `UseBuildMetadata`:

```csharp
builder.UseBuildMetadata("custom:section:build");
```

### Configure with MSBuild properties

You can set build metadata by defining MSBuild properties in your project file. This is useful when building outside of a CI/CD environment or when you want to provide custom values.

**For Azure DevOps-style properties:**

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <BuildMetadataAzureBuildId>12345</BuildMetadataAzureBuildId>
    <BuildMetadataAzureBuildNumber>1.0.0-local.1</BuildMetadataAzureBuildNumber>
    <BuildMetadataAzureSourceBranchName>feature/my-feature</BuildMetadataAzureSourceBranchName>
    <BuildMetadataAzureSourceVersion>a1b2c3d4e5f6789012345678901234567890abcd</BuildMetadataAzureSourceVersion>
    <BuildMetadataIsAzureDevOps>true</BuildMetadataIsAzureDevOps>
  </PropertyGroup>
</Project>
```

**For GitHub Actions-style properties:**

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <BuildMetadataGitHubRunId>67890</BuildMetadataGitHubRunId>
    <BuildMetadataGitHubRunNumber>42</BuildMetadataGitHubRunNumber>
    <BuildMetadataGitHubRefName>main</BuildMetadataGitHubRefName>
    <BuildMetadataGitHubSha>a1b2c3d4e5f6789012345678901234567890abcd</BuildMetadataGitHubSha>
  </PropertyGroup>
</Project>
```

You can also pass these properties via the command line:

```bash
dotnet build -p:BuildMetadataAzureBuildNumber=1.0.0-local.1 -p:BuildMetadataAzureSourceBranchName=main
```

> [!NOTE]
> The source generator uses `BuildMetadataIsAzureDevOps` to determine which set of properties to read (Azure DevOps or GitHub Actions). If you're manually setting properties, ensure you set this flag appropriately or use the GitHub properties if the flag is not set.

## Environment variable integration and MSBuild properties

The build metadata component captures values during the build process through MSBuild properties. These properties can be populated automatically from CI/CD environment variables or set manually in your project file.

### Automatic CI/CD integration

During a CI/CD build, environment variables are automatically mapped to MSBuild properties via a transitive props file included with the package. The following table shows the complete mapping:

| BuildMetadata Property | Azure DevOps Variable | MSBuild Property | GitHub Actions Variable | MSBuild Property |
|------------------------|----------------------|------------------|------------------------|------------------|
| `BuildId` | `BUILD_BUILDID` | `BuildMetadataAzureBuildId` | `GITHUB_RUN_ID` | `BuildMetadataGitHubRunId` |
| `BuildNumber` | `BUILD_BUILDNUMBER` | `BuildMetadataAzureBuildNumber` | `GITHUB_RUN_NUMBER` | `BuildMetadataGitHubRunNumber` |
| `SourceBranchName` | `BUILD_SOURCEBRANCHNAME` | `BuildMetadataAzureSourceBranchName` | `GITHUB_REF_NAME` | `BuildMetadataGitHubRefName` |
| `SourceVersion` | `BUILD_SOURCEVERSION` | `BuildMetadataAzureSourceVersion` | `GITHUB_SHA` | `BuildMetadataGitHubSha` |

### Manual configuration

When building outside of a CI/CD environment, you can manually set these MSBuild properties in your project file (`.csproj`) or pass them as command-line arguments. See the [Configure with MSBuild properties](#configure-with-msbuild-properties) section for examples.

### How the source generator works

The source generator included in the package reads these MSBuild properties at compile time and generates code that initializes the <xref:Microsoft.Extensions.AmbientMetadata.BuildMetadata> class with the captured values. The detection flag `BuildMetadataIsAzureDevOps` (set by the `TF_BUILD` environment variable in Azure DevOps) determines which set of properties the generator reads.

## Access build metadata

Once configured, you can inject and use the <xref:Microsoft.Extensions.AmbientMetadata.BuildMetadata> type:

:::code language="csharp" source="snippets/buildmetadata-access/Program.cs":::

## BuildMetadata properties

The <xref:Microsoft.Extensions.AmbientMetadata.BuildMetadata> class includes the following properties:

| Property            | Description                                                     | Example Value |
|---------------------|-----------------------------------------------------------------|---------------|
| `BuildId`           | The ID of the record for the build, also known as the run ID.  | `12345` |
| `BuildNumber`       | The name of the completed build, also known as the run number. | `1.0.0-ci.20260116.1` |
| `SourceBranchName`  | The name of the branch in the triggering repo the build was queued for, also known as the ref name. | `main`, `feature/new-api` |
| `SourceVersion`     | The latest version control change that is included in this build, also known as the commit SHA. | `a1b2c3d4e5f6789012345678901234567890abcd` |

All properties are nullable strings and are automatically captured from CI/CD environment variables during the build process via source generation.

## Use with logging

Build metadata is particularly useful for enriching log messages with build context:

:::code language="csharp" source="snippets/buildmetadata-logging/Program.cs":::

## Complete example

Here's a complete example showing how to set up and use build metadata:

**appsettings.json:**

:::code language="json" source="snippets/buildmetadata/appsettings.json":::

**Program.cs:**

:::code language="csharp" source="snippets/buildmetadata/Program.cs":::

### Output

The output includes build metadata in the log messages:

```
info: ApplicationService[0]
      Application started - Build: 1.0.0-ci.20260116.1, Branch: main, Commit: a1b2c3d
```

## CI/CD integration

### Azure DevOps Pipelines

When building in Azure DevOps Pipelines, the component automatically captures environment variables through MSBuild property mappings. The presence of the `TF_BUILD` environment variable signals to the source generator to use Azure DevOps-specific properties.

The following environment variables are captured during the build process and mapped to MSBuild properties:

- `BUILD_BUILDID`: The ID of the build
- `BUILD_BUILDNUMBER`: The name/number of the build
- `BUILD_SOURCEBRANCHNAME`: The branch name (for example, `main`, `develop`)
- `BUILD_SOURCEVERSION`: The commit SHA that triggered the build

For more information about Azure DevOps build variables, see [Use predefined variables](/azure/devops/pipelines/build/variables).

### GitHub Actions

When building in GitHub Actions (and `TF_BUILD` is not set), the component automatically captures GitHub Actions environment variables through MSBuild property mappings.

The following environment variables are captured during the build process and mapped to MSBuild properties:

- `GITHUB_RUN_ID`: The unique identifier for the workflow run
- `GITHUB_RUN_NUMBER`: A unique number for each run of a particular workflow
- `GITHUB_REF_NAME`: The branch or tag name that triggered the workflow
- `GITHUB_SHA`: The commit SHA that triggered the workflow

For more information about GitHub Actions environment variables, see [Default environment variables](https://docs.github.com/actions/learn-github-actions/variables#default-environment-variables).

## Next steps

- Learn about [application metadata](application-metadata.md) for capturing application-level information
- Learn about [log enrichment overview](overview.md) to understand how to enrich telemetry with metadata
- Learn about [application log enricher](application-log-enricher.md) to automatically add metadata to logs
