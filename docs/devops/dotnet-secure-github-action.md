---
title: Create a CodeQL GitHub Action
description: In this quickstart, you will learn how to create a CodeQL GitHub Action to automate the discovery of vulnerabilities in your .NET codebase.
author: IEvangelist
ms.author: dapine
ms.date: 06/30/2021
ms.topic: quickstart
recommendations: false
---

# Quickstart: Create a CodeQL GitHub Action

In this quickstart, you will learn how to create a CodeQL GitHub Action to automate the discovery of vulnerabilities in your .NET codebase. Automatically publishing your .NET code from GitHub to a destination is referred to as continuous deployment (CD).

[!INCLUDE [prerequisites](includes/github-dotnet-ide-prerequisites.md)]

[!INCLUDE [add-github-workflow](includes/add-github-workflow.md)]

Create a new file named *codeql-analysis.yml*, copy and paste the following YML contents into it:

:::code language="yml" source="snippets/secure-action/codeql-analysis.yml":::

In the preceding workflow composition:

- The `name: CodeQL` defines the name, "CodeQL" will appear in workflow status badges.

  :::code language="yml" source="snippets/secure-action/codeql-analysis.yml" range="1":::

- The `on` node signifies the events that trigger the workflow:

  :::code language="yml" source="snippets/secure-action/codeql-analysis.yml" range="3-15":::

  - When a `push` or `pull_quest` occurs on the `main` branch where any files changed ending with the *.cs* or *.csproj* file extensions.
  - As a cron job (on a schedule) &mdash; runs at 8:00 UTC every Thursday.

- The `jobs` node builds out the steps for the workflow to take.

  :::code language="yml" source="snippets/secure-action/codeql-analysis.yml" range="17-46" highlight="2,10,22-24,43,46":::

  - There is a single job, named `analyze` that will run on the latest version of Ubuntu.
  - The `strategy` defines C# as the `language`.
  - The `github/codeql-action/init@v1` GitHub Action is used to initialize CodeQL.
  - The `github/codeql-action/autobuild@v1` GitHub Action builds the .NET project.
  - The `github/codeql-action/analyze@v1` GitHub Action performs the CodeQL analysis.

For more information, see [GitHub Actions: Configure code scanning](https://docs.github.com/code-security/secure-coding/automatically-scanning-your-code-for-vulnerabilities-and-errors/configuring-code-scanning).

[!INCLUDE [add-status-badge](includes/add-status-badge.md)]

## See also

- [Secure coding guidelines](../standard/security/secure-coding-guidelines.md)

## Next steps

> [!div class="nextstepaction"]
> [Tutorial: Create a GitHub Action with .NET](create-dotnet-github-action.md)
