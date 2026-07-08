---
title: Install GitHub Copilot modernization
description: "Learn how to install and set up GitHub Copilot modernization across Visual Studio, Visual Studio Code, GitHub Copilot CLI, and GitHub.com."
ms.topic: install-set-up-deploy
ms.date: 07/07/2026
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
1. Search for **GitHub Copilot upgrade**.
1. Select **Install**.

The extension automatically acquires the .NET SDK if it's missing, registers tools, and adds the agent to Copilot Chat as `Upgrade`.

## Verify the installation

1. Open a project in Visual Studio Code.
1. Open the **GitHub Copilot Chat** window.
1. Send `@upgrade` in chat and confirm the agent responds.

   -or-

   Select the `Agent` dropdown and find the `Upgrade` entry.

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
   /plugin marketplace add microsoft/upgrade-agent-plugins
   ```

1. Install the plugin:

   ```console
   /plugin install upgrade-agent@upgrade-agent-plugins
   ```

## Verify the installation

Run `/agent` to confirm that `upgrade-agent` appears in the agent list.

::: zone-end

::: zone pivot="github-copilot-app"

## Prerequisites

Before you install, make sure you have:

- [GitHub Copilot app](https://gh.io/app) installed.
- GitHub Copilot subscription (paid or free).

## Install

Install through the GitHub Copilot app:

1. Click [https://github.com/copilot/app/launch](https://github.com/copilot/app/launch?entry_point=upgrade_agent_docs&open=ghapp%3A%2F%2Fplugins%2Fmarketplace%2Fadd%3Fsource%3Dmicrosoft%2Fupgrade-agent-plugins) to automatically open the **Settings** > **Plugins** window in the GitHub Copilot app.
1. In the **Add plugin marketplace?** dialog, select **Allow**.
1. In the **Plugins** window, select **Add marketplace**.
1. Expand the **upgrade-agent-plugins** entry and select **Install** on the **upgrade-agent** plugin.

## Verify the installation

Run `/agent` to confirm that `upgrade-agent:upgrade` appears in the agent list.

-or-

Select the **Default agent** dropdown and find the **Upgrade** entry.

::: zone-end

## Related content

- [What is GitHub Copilot modernization?](overview.md)
- [Upgrade a .NET app with GitHub Copilot modernization](how-to-upgrade-with-github-copilot.md)
- [Core concepts](concepts.md)
- [GitHub Copilot modernization FAQ](faq.yml)
