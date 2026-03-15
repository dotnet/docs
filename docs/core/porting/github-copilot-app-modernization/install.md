---
title: Install GitHub Copilot modernization
description: "Learn how to install and set up GitHub Copilot modernization across Visual Studio, Visual Studio Code, GitHub Copilot CLI, and GitHub.com."
ms.topic: install-set-up-deploy
ms.date: 03/04/2026
ai-usage: ai-assisted
zone_pivot_groups: copilot-modernization-install

#customer intent: As a developer, I want to install GitHub Copilot modernization so that I can upgrade and migrate my .NET applications.

---

# Install GitHub Copilot modernization

GitHub Copilot modernization is available across multiple development environments. Choose your preferred environment to get started with installation and setup.

::: zone pivot="visualstudio"

## Prerequisites

Before you install, make sure you have the following:

- Windows operating system.
- [Visual Studio 2026](https://visualstudio.microsoft.com/downloads/) (or Visual Studio 2022 version 17.14.17+).
- [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=visualstudio&preserve-view=true#change-workloads-or-individual-components) with these optional components enabled: **GitHub Copilot**, **GitHub Copilot modernization**.
- GitHub Copilot subscription (paid or free).
- [Sign in to Visual Studio with a GitHub account](/visualstudio/ide/work-with-github-accounts) that has [Copilot access](https://docs.github.com/copilot/get-started/plans#ready-to-choose-a-plan).
- Code written in C#.

## Install

GitHub Copilot modernization is included in Visual Studio and doesn't require a separate installation. Enable the **GitHub Copilot** and **GitHub Copilot modernization** optional components in the **.NET desktop development** workload through the Visual Studio Installer.

## Verify the installation

1. Open a solution in Visual Studio.
1. Right-click a project in **Solution Explorer** and select **Modernize**, or open **GitHub Copilot Chat** and type `@Modernize`.

::: zone-end

::: zone pivot="vscode"

## Prerequisites

Before you install, make sure you have the following:

- Visual Studio Code.
- GitHub Copilot extension installed.
- GitHub Copilot subscription (paid or free).

## Install

Install the [GitHub Copilot modernization extension](https://marketplace.visualstudio.com/items?itemName=vscjava.migrate-java-to-azure) from the VS Code Marketplace.

## Verify the installation

1. Open a project in Visual Studio Code.
1. Open the Copilot chat and type `@modernize-dotnet`.

::: zone-end

::: zone pivot="copilot-cli"

## Prerequisites

Before you install, make sure you have the following:

- GitHub Copilot CLI installed.
- GitHub Copilot subscription (paid or free).

## Install

Complete these three steps to install:

1. Open the GitHub Copilot chat window.

1. Add the marketplace plugin:

   ```console
   /plugin marketplace add dotnet/modernize-dotnet
   ```

1. Install the plugin:

   ```console
   /plugin install modernize-dotnet@modernize-dotnet-plugins
   ```

## Verify the installation

Run `/agent` to confirm that `modernize-dotnet` appears in the agent list.

::: zone-end

::: zone pivot="github-com"

## Prerequisites

Before you install, make sure you have the following:

- GitHub Copilot Enterprise or Business subscription with coding agents enabled.
- Repository admin access.

## Install

Add the custom coding agent to your repository:

1. Learn about [adding custom coding agents to your repo](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/coding-agent/create-custom-agents).
1. Add the `modernize-dotnet` agent. See the [coding agent README](https://github.com/dotnet/modernize-dotnet/blob/main/coding-agent/README.md) for details.

## Verify the installation

The `modernize-dotnet` agent appears as an available coding agent in your repository.

::: zone-end

## Related content

- [What is GitHub Copilot modernization?](overview.md)
- [Upgrade a .NET app with GitHub Copilot modernization](how-to-upgrade-with-github-copilot.md)
- [GitHub Copilot modernization FAQ](faq.yml)
