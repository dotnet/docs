---
title: Install GitHub Copilot modernization
description: "Learn how to install and set up GitHub Copilot modernization across Visual Studio, Visual Studio Code, GitHub Copilot CLI, and GitHub.com."
ms.topic: install-set-up-deploy
ms.date: 07/30/2026
ms.custom: devx-track-dotnet
ai-usage: ai-assisted
zone_pivot_groups: copilot-modernization-install

#customer intent: As a developer, I want to install GitHub Copilot modernization so that I can modernize my .NET applications.

---

# Install GitHub Copilot modernization

GitHub Copilot modernization works across multiple development environments. Choose your preferred environment to install and set up GitHub Copilot modernization.

::: zone pivot="visualstudio"

## Prerequisites

Before you install, make sure you have:

- Windows operating system.
- [Visual Studio 2026](https://visualstudio.microsoft.com/downloads/) (or Visual Studio 2022 version 17.14.17+).
- [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=visualstudio&preserve-view=true#change-workloads-or-individual-components) with these optional components enabled: **GitHub Copilot**, **GitHub Copilot app modernization**.
- GitHub Copilot subscription (paid or free).
- [Sign in to Visual Studio with a GitHub account](/visualstudio/ide/work-with-github-accounts) that has [Copilot access](https://docs.github.com/copilot/get-started/plans#ready-to-choose-a-plan).
- Code written in C# or Visual Basic.

## Install

Visual Studio includes GitHub Copilot modernization through the **GitHub Copilot app modernization** optional component, so you don't need to install it separately. Enable the **GitHub Copilot** and **GitHub Copilot app modernization** optional components in the **.NET desktop development** workload through the Visual Studio Installer.

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

Install as a Visual Studio Code extension:

1. In Visual Studio Code, open the **Extensions** view (<kbd>Ctrl+Shift+X</kbd>).
1. Search for **GitHub Copilot modernization**.
1. Select **Install**.

## Verify the installation

1. Open a project in Visual Studio Code.
1. Open the **GitHub Copilot Chat** view.
1. Send `@modernize` in chat and confirm the agent responds.

   -or-

   Select the **Agent** picker and find the `Modernize` entry.

::: zone-end

::: zone pivot="copilot-cli"

## Prerequisites

Before you install, make sure you have:

- [GitHub Copilot CLI](https://gh.io/cli) installed.
- GitHub Copilot subscription (paid or free).

## Install

Install through the GitHub Copilot CLI:

1. Open the GitHub Copilot chat window.

1. Add the marketplace plugin:

   ```console
   /plugin marketplace add microsoft/github-copilot-modernization
   ```

1. Install the plugin:

   ```console
   /plugin install github-copilot-modernization@github-copilot-modernization
   ```

## Verify the installation

Run `/plugin list` to confirm that `github-copilot-modernization@github-copilot-modernization` appears in the list.

::: zone-end

::: zone pivot="github-copilot-app"

## Prerequisites

Before you install, make sure you have:

- [GitHub Copilot app](https://gh.io/app) installed.
- GitHub Copilot subscription (paid or free).

## Install

Install through the GitHub Copilot app:

1. Click [https://github.com/copilot/app/launch](https://github.com/copilot/app/launch?entry_point=modernization_agent_dotnetdocs&open=ghapp%3A%2F%2Fplugins%2Fmarketplace%2Fadd%3Fsource%3Dmicrosoft%2Fgithub-copilot-modernization) to automatically open the **Settings** > **Plugins** window in the GitHub Copilot app.
1. In the **Add plugin marketplace?** dialog, select **Allow**.
1. In the **Plugins** window, select **Add marketplace**.
1. Expand the **github-copilot-modernization** entry and select **Install** on the **github-copilot-modernization** plugin.

## Verify the installation

Run `/agent` to confirm that the new agent appears in the agent list.

::: zone-end

## Related content

- [GitHub Copilot modernization FAQ](faq.yml)
- [Quickstart: Assess and migrate a .NET project with GitHub Copilot modernization for .NET](quickstart.md)
- [Application assessment with GitHub Copilot modernization](working-with-assessment.md)
