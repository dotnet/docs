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

Build metadata can be configured through the dependency injection container using the <xref:Microsoft.Extensions.DependencyInjection.BuildMetadataServiceCollectionExtensions.AddBuildMetadata%2A> extension method. During the build process, the component uses source generation to capture build information from environment variables and embed it into the compiled application.

### Configure with IServiceCollection

Use the <xref:Microsoft.Extensions.DependencyInjection.BuildMetadataServiceCollectionExtensions.AddBuildMetadata%2A> extension method to register build metadata:

:::code language="csharp" source="snippets/buildmetadata-configure/Program.cs":::

Alternatively, you can configure build metadata programmatically:

:::code language="csharp" source="snippets/buildmetadata-configure-programmatic/Program.cs":::

### Configure with appsettings.json

You can also provide build metadata through configuration files:

:::code language="json" source="snippets/buildmetadata-configure/appsettings.json":::

## Environment variable integration

During the build process, source generation captures values from CI/CD environment variables and embeds them into the compiled application. The following table shows how properties map to environment variables in different CI/CD systems:

| Property            | Azure DevOps Variable | GitHub Actions Variable | Description |
|---------------------|----------------------|------------------------|-------------|
| `BuildId`           | `BUILD_BUILDID`      | `GITHUB_RUN_ID`        | The unique identifier for the build/workflow run |
| `BuildNumber`       | `BUILD_BUILDNUMBER`  | `GITHUB_RUN_NUMBER`    | The name or number of the build/run |
| `SourceBranchName`  | `BUILD_SOURCEBRANCHNAME` | `GITHUB_REF_NAME`  | The name of the branch being built |
| `SourceVersion`     | `BUILD_SOURCEVERSION` | `GITHUB_SHA`          | The commit SHA being built |

When you build your application in a CI/CD pipeline, these values are automatically captured and hard-coded into the application. You don't need to manually configure them unless you're building outside of a supported CI/CD environment or want to override the automatic values.

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

When building in Azure DevOps Pipelines, the build metadata component uses source generation to capture values from predefined build variables and embed them into the compiled application. These variables are available in all pipeline types (YAML, classic build, and release pipelines).

The following environment variables are captured during the build process:

- `BUILD_BUILDID`: The ID of the build
- `BUILD_BUILDNUMBER`: The name/number of the build
- `BUILD_SOURCEBRANCHNAME`: The branch name (for example, `main`, `develop`)
- `BUILD_SOURCEVERSION`: The commit SHA that triggered the build

For more information about Azure DevOps build variables, see [Use predefined variables](/azure/devops/pipelines/build/variables).

### GitHub Actions

When building in GitHub Actions workflows, the build metadata component uses source generation to capture values from default environment variables and embed them into the compiled application.

The following environment variables are captured during the build process:

- `GITHUB_RUN_ID`: The unique identifier for the workflow run
- `GITHUB_RUN_NUMBER`: A unique number for each run of a particular workflow
- `GITHUB_REF_NAME`: The branch or tag name that triggered the workflow
- `GITHUB_SHA`: The commit SHA that triggered the workflow

For more information about GitHub Actions environment variables, see [Default environment variables](https://docs.github.com/actions/learn-github-actions/variables#default-environment-variables).

## Next steps

- Learn about [application metadata](application-metadata.md) for capturing application-level information
- Learn about [log enrichment overview](overview.md) to understand how to enrich telemetry with metadata
- Learn about [application log enricher](application-log-enricher.md) to automatically add metadata to logs
