---
title: Create a security scan GitHub Action
description: In this quickstart, you will learn how to create a CodeQL GitHub Action to automate the discovery of vulnerabilities in your .NET codebase.
author: IEvangelist
ms.author: dapine
ms.date: 10/05/2021
ms.topic: quickstart
recommendations: false
---

# Quickstart: Create a security scan GitHub Action

In this quickstart, you will learn how to create a CodeQL GitHub Action to automate the discovery of vulnerabilities in your .NET codebase.

> In CodeQL, code is treated as data. Security vulnerabilities, bugs, and other errors are modeled as queries that can be executed against databases extracted from code.
>
> &mdash; [GitHub CodeQL: About](https://codeql.github.com/docs/codeql-overview/about-codeql)

[!INCLUDE [prerequisites](includes/prerequisites.md)]

[!INCLUDE [add-github-workflow](includes/add-github-workflow.md)]

Create a new file named *codeql-analysis.yml*, copy and paste the following YML contents into it:

:::code language="yml" source="snippets/dotnet-secure-github-action/codeql-analysis.yml":::

In the preceding workflow composition:

- The `name: CodeQL` defines the name, "CodeQL" will appear in workflow status badges.

  :::code language="yml" source="snippets/dotnet-secure-github-action/codeql-analysis.yml" range="1":::

- The `on` node signifies the events that trigger the workflow:

  :::code language="yml" source="snippets/dotnet-secure-github-action/codeql-analysis.yml" range="3-15":::

  - Triggered when a `push` or `pull_quest` occurs on the `main` branch where any files changed ending with the *.cs* or *.csproj* file extensions.
  - As a cron job (on a schedule) &mdash; to run at 8:00 UTC every Thursday.

- The `jobs` node builds out the steps for the workflow to take.

  :::code language="yml" source="snippets/dotnet-secure-github-action/codeql-analysis.yml" range="17-46" highlight="2,10,22-24,27,30":::

  - There is a single job, named `analyze` that will run on the latest version of Ubuntu.
  - The `strategy` defines C# as the `language`.
  - The `github/codeql-action/init@v1` GitHub Action is used to initialize CodeQL.
  - The `github/codeql-action/autobuild@v1` GitHub Action builds the .NET project.
  - The `github/codeql-action/analyze@v1` GitHub Action performs the CodeQL analysis.

For more information, see [GitHub Actions: Configure code scanning](https://docs.github.com/code-security/secure-coding/automatically-scanning-your-code-for-vulnerabilities-and-errors/configuring-code-scanning).

[!INCLUDE [add-status-badge](includes/add-status-badge.md)]

### Example CodeQL workflow status badge

| Passing | Failing | No status |
|--|--|--|
| :::image type="content" source="media/codeql-badge-passing.svg" alt-text="GitHub: CodeQL passing badge"::: | :::image type="content" source="media/codeql-badge-failing.svg" alt-text="GitHub: CodeQL failing badge"::: | :::image type="content" source="media/codeql-badge-no-status.svg" alt-text="GitHub: CodeQL no-status badge"::: |

## See also

- [Secure coding guidelines](../standard/security/secure-coding-guidelines.md)
- [actions/checkout](https://github.com/actions/checkout)
- [actions/setup-dotnet](https://github.com/actions/setup-dotnet)

## Next steps

> [!div class="nextstepaction"]
> [Tutorial: Create a GitHub Action with .NET](create-dotnet-github-action.md)
