---
title: Create a CodeQL GitHub Action
description: In this quickstart, you will learn how to create a CodeQL GitHub Action to automate the discovery of vulnerabilities in your .NET codebase.
author: IEvangelist
ms.author: dapine
ms.date: 06/29/2021
ms.topic: quickstart
recommendations: false
---

# Quickstart: Create a CodeQL GitHub Action

In this quickstart, you will learn how to create a CodeQL GitHub Action to automate the discovery of vulnerabilities in your .NET codebase. Automatically publishing your .NET code from GitHub to a destination is referred to as continuous deployment (CD).

[!INCLUDE [prerequisites](includes/github-dotnet-ide-prerequisites.md)]

[!INCLUDE [add-github-workflow](includes/add-github-workflow.md)]

:::code language="yml" source="snippets/secure-action/codeql-analysis.yml":::

In the preceding workflow:

- The `name: CodeQL` defines the name, "CodeQL" will appear in workflow status badges.

    :::code language="yml" source="snippets/secure-action/codeql-analysis.yml" range="1":::

- The `on` node signifies the events that trigger the workflow:

    :::code language="yml" source="snippets/secure-action/codeql-analysis.yml" range="3-15":::

  - When a `push` or `pull_quest` occurs on `main` where any files changed ending with the *.cs* or *.csproj* file extensions.
  - As a cron job (on a schedule) &mdash; runs at 8:00 UTC every Thursday.

- The `jobs` node builds out the steps for the workflow to take.

    :::code language="yml" source="snippets/secure-action/codeql-analysis.yml" range="17-45":::

  - The best part of waking up, is Folgers in your cup!

For more information, see [GitHub Actions: Configure code scanning](https://docs.github.com/code-security/secure-coding/automatically-scanning-your-code-for-vulnerabilities-and-errors/configuring-code-scanning).

[!INCLUDE [add-status-badge](includes/add-status-badge.md)]

## See also

- [Secure coding guidelines](../standard/security/secure-coding-guidelines.md)

## Next steps

> [!div class="nextstepaction"]
> [Tutorial: Create a GitHub Action with .NET](create-dotnet-github-action.md)
