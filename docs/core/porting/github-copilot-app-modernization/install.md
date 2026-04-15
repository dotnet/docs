---
title: Install GitHub Copilot modernization
description: "Learn how to install and set up GitHub Copilot modernization across Visual Studio, Visual Studio Code, GitHub Copilot CLI, and GitHub.com."
ms.topic: install-set-up-deploy
ms.date: 04/06/2026
ai-usage: ai-assisted
zone_pivot_groups: copilot-modernization-install

#customer intent: As a developer, I want to install GitHub Copilot modernization so that I can upgrade my .NET applications.

---

# Install GitHub Copilot modernization

GitHub Copilot modernization works across multiple development environments. Choose your preferred environment to install and set up GitHub Copilot modernization.

::: zone pivot="visualstudio"

## Prerequisites

Before you install, make sure you have:

- Windows operating system.
- [Visual Studio 2026](https://visualstudio.microsoft.com/downloads/) (or Visual Studio 2022 version 17.14.17+).
- [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=visualstudio&preserve-view=true#change-workloads-or-individual-components) with these optional components enabled: **GitHub Copilot**, **GitHub Copilot modernization**.
- GitHub Copilot subscription (paid or free).
- [Sign in to Visual Studio with a GitHub account](/visualstudio/ide/work-with-github-accounts) that has [Copilot access](https://docs.github.com/copilot/get-started/plans#ready-to-choose-a-plan).
- Code written in C# or Visual Basic.

## Install

Visual Studio includes GitHub Copilot modernization, so you don't need to install it separately. Enable the **GitHub Copilot** and **GitHub Copilot modernization** optional components in the **.NET desktop development** workload through the Visual Studio Installer.

## Verify the installation

1. Open a solution in Visual Studio.
1. Right-click a project in **Solution Explorer** and select **Modernize**, or open **GitHub Copilot Chat** and type `@Modernize`.

::: zone-end

::: zone pivot="vscode"

## Prerequisites

Before you install, make sure you have:

- Visual Studio Code.
- GitHub Copilot extension installed.
- GitHub Copilot subscription (paid or free).

## Install

1. In Visual Studio Code, open the **Extensions** view (<kbd>Ctrl+Shift+X</kbd>).
1. Search for **GitHub Copilot modernization**.
1. Select **Install**.

The extension automatically acquires the .NET SDK if it's missing, registers tools, and adds the agent to Copilot Chat as `modernize-dotnet`.

## Verify the installation

1. Open a project in Visual Studio Code.
1. Open **GitHub Copilot Chat** and type `@modernize-dotnet`.

::: zone-end

::: zone pivot="copilot-cli"

## Prerequisites

Before you install, make sure you have:

- GitHub Copilot CLI installed.
- GitHub Copilot subscription (paid or free).

## Install

To install:

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

Before you install, make sure you have:

- GitHub Copilot Enterprise or Business subscription with coding agents enabled.
- Repository admin access.

## Install

Add the custom coding agent to your repository:

1. Review [adding custom coding agents to your repository](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/coding-agent/create-custom-agents).
1. Add the `modernize-dotnet` agent. See the [coding agent README](https://github.com/dotnet/modernize-dotnet/blob/main/coding-agent/README.md) for details.

## Verify the installation

Confirm that the `modernize-dotnet` agent appears as an available coding agent in your repository.

::: zone-end

## Related content

- [What is GitHub Copilot modernization?](overview.md)
- [Upgrade a .NET app with GitHub Copilot modernization](how-to-upgrade-with-github-copilot.md)
- [Core concepts](concepts.md)
- [GitHub Copilot modernization FAQ](faq.yml)
