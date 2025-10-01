---
title: How to upgrade a .NET app with GitHub Copilot app modernization
description: "Learn how to upgrade your .NET applications to newer versions using GitHub Copilot app modernization in Visual Studio. This step-by-step guide covers planning, execution, and validation."
author: adegeo
ms.author: adegeo
ms.topic: how-to
ms.date: 09/15/2025
ai-usage: ai-assisted

#customer intent: As a developer, I want to upgrade my .NET app using GitHub Copilot app modernization so that I can modernize my codebase efficiently with AI assistance.

---

# How to upgrade a .NET app with GitHub Copilot app modernization

GitHub Copilot app modernization is an AI-powered agent in Visual Studio that helps you upgrade .NET projects to newer versions and migrate applications to Azure. This article guides you through the process of using this tool to modernize your .NET applications, from initial assessment to final validation.

The modernization agent analyzes your projects and dependencies, creates an upgrade plan, and assists with code fixes throughout the process. It supports upgrading from older .NET versions to the latest, including migrations from .NET Framework to modern .NET.

## Prerequisites

Before you begin, ensure you have the following requirements:

[!INCLUDE[github-copilot-app-mod-prereqs](../../includes/github-copilot-app-mod-prereqs.md)]

## Start the upgrade process

The first step to upgrading is generating a plan by interacting with GitHub Copilot. Follow these steps to initiate the upgrade:

[!INCLUDE[github-copilot-how-to-initiate](./includes/github-copilot-how-to-initiate.md)]

## Generate an upgrade plan

Once the process starts, Copilot analyzes your projects and their dependencies, and then asks you a series of questions about the upgrade. After you answer these questions, an upgrade plan is written in the form of a Markdown file.

To generate and customize your plan:

1. Answer Copilot's questions about your upgrade requirements and preferences.
1. Review the generated upgrade plan in the Markdown file.
1. Optionally, edit the Markdown file to change the upgrade steps or add more context.
1. Tell Copilot to proceed with the upgrade when you're satisfied with the plan.

> [!CAUTION]
> The plan is generated based on the inter-dependencies of your projects. The upgrade won't succeed if you modify the plan in such a way that the migration path can't complete. For example, if **Project A** depends on **Project B** and you remove **Project B** from the upgrade plan, upgrading **Project A** might fail.

The following snippet demonstrates the structure of a plan:

```md
# .NET 9.0 Upgrade Plan

## Execution Steps

1. Validate that an .NET 9.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 9.0 upgrade.
3. Upgrade projects to .NET 9.0.
  - 3.1. Upgrade RazorMovie.csproj
  - 3.2. Upgrade RazorMovie.Tests.csproj
4. Run unit tests to validate upgrade in the projects listed below:
  - RazorMovie.Tests.csproj

## Settings

This section contains settings and data used by execution steps.

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                                     | Current Version     | New Version | Description              |
|:-------------------------------------------------|:-------------------:|:-----------:|:-------------------------|
| HtmlSanitizer                                    | 7.1.542             | 9.0.884     | Security vulnerability   |
| Microsoft.Data.SqlClient                         | 4.0.5               | 6.0.2       | Deprecated               |
| Microsoft.EntityFrameworkCore.Design             | 6.0.0-rtm.21467.1   | 9.0.5       | Recommended for .NET 9.0 |
| Microsoft.EntityFrameworkCore.SqlServer          | 6.0.0-rc.1.21452.10 | 9.0.5       | Recommended for .NET 9.0 |
| Microsoft.EntityFrameworkCore.Tools              | 6.0.0-rc.1.21452.10 | 9.0.5       | Recommended for .NET 9.0 |
| Microsoft.VisualStudio.Web.CodeGeneration.Design | 6.0.0-rc.1.21464.1  | 9.0.0       | Recommended for .NET 9.0 |

...
```

## Perform the upgrade

Once an upgrade plan is ready, tell Copilot to start the upgrade. Once the upgrade process starts, Copilot lets you know what it's doing in the chat window and it opens the **Upgrade Progress Details** document, which lists the status of every step. If it runs into a problem, Copilot pauses and asks for your direction or help in fixing these problems.

Each major step in the upgrade process is committed to the local Git repository.

## Review upgrade results

When the upgrade completes, a report is generated that describes every step of the upgrade. The tool creates a Git commit for every portion of the upgrade process, so you can easily roll back the changes or get detailed information about what changed. The report contains the Git commit hashes and provides a _Next steps_ section that describes the steps you should take after the upgrade finishes.

The following example shows the report of a completed upgrade that contained a test failure:

```md
# .NET 9 Upgrade Report

## Project modifications

| Project name                                   | Old Target Framework    | New Target Framework         | Commits                   |
|:-----------------------------------------------|:-----------------------:|:----------------------------:|---------------------------|
| RazorMovie                                     |   net6.0                | net9.0                       | af8cf633, aa61a18d        |
| MvcMovie                                       |   net6.0                | net9.0                       | cc8c9015                  |
| WpfMovie                                       |   net6.0-windows        | net9.0-windows               | 9c4b13f9                  |
| RazorMovie.Tests                               |   net6.0                | net9.0                       | b8d85e97                  |
| MvcMovie.Tests                                 |   net6.0                | net9.0                       | b8d85e97                  |
| WpfMovie.Tests                                 |   net6.0-windows        | net9.0-windows7.0            | b8d85e97                  |

## NuGet Packages

| Package Name                                     | Old Version         | New Version | Commit Id |
|:-------------------------------------------------|:-------------------:|:-----------:|-----------|
| HtmlSanitizer                                    | 7.1.542             | 9.0.884     | af8cf633  |
| Microsoft.Data.SqlClient                         | 4.0.5               | 6.0.2       | bf8deeac  |
| Microsoft.EntityFrameworkCore.Design             | 6.0.0-rtm.21467.1   | 9.0.5       | bf8deeac  |
| Microsoft.EntityFrameworkCore.SqlServer          | 6.0.0-rc.1.21452.10 | 9.0.5       | bf8deeac  |
| Microsoft.EntityFrameworkCore.Tools              | 6.0.0-rc.1.21452.10 | 9.0.5       | bf8deeac  |
| Microsoft.VisualStudio.Web.CodeGeneration.Design | 6.0.0-rc.1.21464.1  | 9.0.0       | bf8deeac  |

## All commits

| Commit ID | Description                                             |
|:----------|:--------------------------------------------------------|
| af8cf633  | Update HtmlSanitizer package in RazorMovie.csproj       |
| aa61a18d  | Upgrade target framework in RazorMovie.csproj           |
| cc8c9015  | Upgrade to .NET 9 and update dependencies               |
| bf8deeac  | Update package references in MvcMovie.csproj            |
| 9c4b13f9  | Update WpfMovie.csproj to target .NET 9.0               |
| b8d85e97  | Update test projects to .NET 9 and enhance dependencies |

## Test Results

| Project Name           | Passed | Failed | Skipped |
|:-----------------------|:------:|:------:|:-------:|
| RazorMovie.Tests       |   0    |   0    |    0    |
| MvcMovie.Tests         |   2    |   0    |    0    |
| WpfMovie.Tests         |   6    |   1    |    0    |

## Next steps

- Review the test results and address the single failing test in `WpfMovie.Tests`.
- Ensure all updated NuGet packages are compatible with your application.
- Leverage new features and improvements in .NET 9.0 for your projects.
```

## Next steps

After completing the upgrade process:

- Review the generated upgrade report and any test results.
- Address any failing tests or compilation errors that might remain.
- Ensure all updated NuGet packages are compatible with your application.
- Test your application thoroughly to verify the upgrade was successful.
- Apply new features and improvements available in the upgraded .NET version.

## Related content

- [GitHub Copilot app modernization FAQ](github-copilot-app-modernization/faq.yml)
