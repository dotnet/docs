---
title: GitHub Copilot app modernization update example
description: "some desc"
titleSuffix: ""
author: adegeo
ms.author: adegeo
ms.topic: concept-article
ms.date: 09/04/2025

#customer intent: As a developer, I want to upgrade my project so that I can take advantage of the latest features.

---

# GitHub Copilot app modernization update example

BLAH

## Start the upgrade process

The first step to upgrading is generating a plan by interacting with GitHub Copilot. There are two ways to get Copilot to use the tool:

- Right-click on the solution or project and select **Modernize**.

  ..TODO: IMAGE.. 

  —or—

- Open the **GitHub Copilot Chat** window and ask the `@Modernize` agent to upgrade.

## Generate a plan

Once the process starts, Copilot analyzes your projects and their dependencies, and then asks you a series of questions about the upgrade. After you answer these questions, an upgrade plan is written in the form of a Markdown file. If you tell Copilot to proceed with the upgrade, this plan describes the steps of the upgrade process.

You can adjust the plan by editing the Markdown file to change the upgrade steps or add more context.

> [!CAUTION]
> The plan is generated based on the inter-dependencies of your projects. The upgrade won't succeed if you modify the plan in such a way that the migration path can't complete. For example, if **Project A** depends on **Project B** and you remove **Project B** from the upgrade plan, upgrading **Project A** might fail.

The following snippet demonstrates the structure of a plan:

```md
# .NET 10.0 Upgrade Plan

## Execution Steps

1. Validate that an .NET 10.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 10.0 upgrade.
3. Upgrade projects to .NET 10.0.
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
| Microsoft.EntityFrameworkCore.Design             | 6.0.0-rtm.21467.1   | 9.0.5       | Recommended for .NET 10.0 |
| Microsoft.EntityFrameworkCore.SqlServer          | 6.0.0-rc.1.21452.10 | 9.0.5       | Recommended for .NET 10.0 |
| Microsoft.EntityFrameworkCore.Tools              | 6.0.0-rc.1.21452.10 | 9.0.5       | Recommended for .NET 10.0 |
| Microsoft.VisualStudio.Web.CodeGeneration.Design | 6.0.0-rc.1.21464.1  | 9.0.0       | Recommended for .NET 10.0 |

...
```

## Perform the upgrade

Once an upgrade plan is ready, tell Copilot to start the upgrade. Once the upgrade process starts, Copilot lets you know what it's doing in the chat window and it opens the **Upgrade Progress Details** document, which lists the status of every step. If it runs into a problem, Copilot pauses and asks for your direction or help in fixing these problems.

The tool differs in experience based on whether or not Copilot _agent mode_ is enabled.

- **Copilot agent mode**

  When Copilot agent mode is enabled and used, Copilot tries to identify the cause of a problem and apply a fix. If Copilot can't seem to correct the problem, it asks for your help. When you intervene, Copilot learns from the changes you make and tries to automatically apply them for you, if the problem is encountered again.

- **Copilot fix mode**

  Copilot fix mode is used if agent mode is disabled or not used. Copilot reports the problems it finds and guides you through the fixes required. It relies on you to perform the actual code changes and then it verifies those fixes.

Each major step in the upgrade process is committed to the local Git repository.

## Upgrade results

When the upgrade completes, a report is generated that describes every step of the upgrade. The tool creates a Git commit for every portion of the upgrade process, so you can easily roll back the changes or get detailed information about what changed. The report contains the Git commit hashes.

The report also provides a _Next steps_ section that describes the steps you should take after the upgrade finishes. The following example shows the report of a completed upgrade that contained a test failure:

```md
# .NET 10 Upgrade Report

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
| 9c4b13f9  | Update WpfMovie.csproj to target .NET 10.0               |
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
- Leverage new features and improvements in .NET 10.0 for your projects.
```

## Related content

- [What is GitHub Copilot app modernization](github-copilot-app-modernization-overview.md)
- [GitHub Copilot app modernization FAQ](github-copilot-app-modernization-faq.yml)
- [Migrate to Azure with GitHub Copilot app modernization](/dotnet/azure/migration/appmod/overview)
