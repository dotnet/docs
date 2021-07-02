---
title: GitHub Actions and .NET
description: Learn what role GitHub Actions play in .NET application development.
author: IEvangelist
ms.author: dapine
ms.date: 07/02/2021
ms.topic: overview
---

# GitHub Actions and .NET

In this overview, you'll learn what role [GitHub Actions](https://docs.github.com/actions) play in .NET application development. GitHub Actions allow your source code repositories to automate continuous integration (CI) and continuous delivery (CD). Beyond that, GitHub Actions expose more advanced scenarios &mdash; providing hooks for automation with code reviews, branch management, and issue triaging. With your .NET source code in GitHub you can leverage GitHub Actions to in many ways.

## GitHub Actions

GitHub Actions represent standalone commands, such as:

- [actions/checkout](https://github.com/actions/checkout) - This action checks-out your repository under `$GITHUB_WORKSPACE`, so your workflow can access it.
- [actions/setup-dotnet](https://github.com/actions/setup-dotnet) - This action sets up a .NET CLI environment for use in actions.
- [dotnet/versionsweeper](https://github.com/dotnet/versionsweeper) - This action sweeps .NET repos for out-of-support target versions of .NET.

> [!TIP]
> The .NET docs team is utilizing the .NET version sweeper GitHub Action to automate issue creation. It runs on a schedule (as a CRON job). When it detects that .NET projects are targeting out-of-support versions &mdash; it creates issues reporting its findings. This is configurable, and helpful for tracking .NET version support concerns. It's available in the [GitHub Action Marketplace](https://github.com/marketplace/actions/net-version-sweeper).

While these commands are isolated to a single action, they're powerful through *workflow composition*. In workflow composition, you define the *events* that trigger the workflow. Once a workflow is running, there are various *jobs* it's instructed to perform &mdash; with each job defining any number of *steps*. The *steps* delegate out to GitHub Actions, or alternatively call command-line scripts.

For more information, see [Introduction to GitHub Actions](https://docs.github.com/actions/learn-github-actions/introduction-to-github-actions).

### Custom GitHub Actions

While there are plenty of GitHub Actions available in the [Marketplace](https://github.com/marketplace?type=actions), you may want to author your own. You can create GitHub Actions that run .NET applications. For more information, see [Tutorial: Create a GitHub Action with .NET](create-dotnet-github-action.md)

## Workflow file

GitHub Actions are utilized through a workflow file. The workflow file must be located in the *.github/workflows* directory of the repository, and is expected to be YAML (either **.yml* or **.yaml*). Workflow files define the *workflow composition*. A workflow is a configurable automated process made up of one or more jobs. For more information, see [Workflow syntax for GitHub Actions](https://docs.github.com/actions/reference/workflow-syntax-for-github-actions).

### Example workflow files

There are many examples of .NET workflow files provided as [tutorials](create-dotnet-github-action.md) and [quickstarts](dotnet-test-github-action.md). Here are several good examples of workflow file names:

:::row:::
    :::column span="1":::
        **Workflow file name**
    :::column-end:::
    :::column span="3":::
        **Description**
    :::column-end:::
:::row-end:::
:::row:::
    :::column span="1":::
        [*build-validation.yml*](dotnet-build-github-action.md)
    :::column-end:::
    :::column span="3":::
        Compiles (or builds) the source code. If the source code doesn't compile, this will fail.
    :::column-end:::
:::row-end:::
:::row:::
    :::column span="1":::
        [*build-and-test.yml*](dotnet-test-github-action.md)
    :::column-end:::
    :::column span="3":::
        Exercises the unit tests within the repository. In order to run tests, the source code must first be compiled &mdash; this is really both a build and test workflow (it would supersede the *build-validation.yml* workflow). Failing unit tests will cause workflow failure.
    :::column-end:::
:::row-end:::
:::row:::
    :::column span="1":::
        [*publish-app.yml*](dotnet-publish-github-action.md)
    :::column-end:::
    :::column span="3":::
        Packages, and publishes the source code to a destination.
    :::column-end:::
:::row-end:::
:::row:::
    :::column span="1":::
        [*codeql-analysis.yml*](dotnet-secure-github-action.md)
    :::column-end:::
    :::column span="3":::
        Analyzes your code for security vulnerabilities and coding errors. Any discovered vulnerabilities could cause fail.
    :::column-end:::
:::row-end:::

## .NET CLI

The .NET command-line interface (CLI) is a cross-platform toolchain for developing, building, running, and publishing .NET applications. The .NET CLI is used to perform actions from workflow files.

For more information, see [.NET CLI overview](../core/tools/index.md)

## See also

For a more in-depth look at GitHub Actions with .NET, consider the following resources:

- ***eBook(s):***

  - [DevOps for ASP.NET Core Developers](../architecture/devops-for-aspnet-developers/index.md)

- ***Quickstart(s):***

  - [Quickstart: Create a build validation GitHub Action](dotnet-build-github-action.md)
  - [Quickstart: Create a test validation GitHub Action](dotnet-test-github-action.md)
  - [Quickstart: Create a publish app GitHub Action](dotnet-publish-github-action.md)
  - [Quickstart: Create a security scan GitHub Action](dotnet-secure-github-action.md)

- ***Tutorial(s):***

  - [Tutorial: Create a GitHub Action with .NET](create-dotnet-github-action.md)
