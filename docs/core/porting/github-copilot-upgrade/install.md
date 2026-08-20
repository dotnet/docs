---
title: Install GitHub Copilot upgrade
description: "Learn how to install and set up GitHub Copilot upgrade across Visual Studio, Visual Studio Code, GitHub Copilot CLI, GitHub Copilot app, and GitHub.com."
ms.topic: install-set-up-deploy
ms.date: 07/07/2026
ai-usage: ai-assisted
zone_pivot_groups: copilot-upgrade-install

#customer intent: As a developer, I want to install GitHub Copilot upgrade so that I can upgrade my .NET applications.

---

# Install GitHub Copilot upgrade

GitHub Copilot upgrade works across multiple development environments. Choose your preferred environment to install and set up GitHub Copilot upgrade.

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

Visual Studio includes GitHub Copilot upgrade through the **GitHub Copilot app modernization** optional component, so you don't need to install it separately. Enable the **GitHub Copilot** and **GitHub Copilot app modernization** optional components in the **.NET desktop development** workload through the Visual Studio Installer.

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
1. Open the **GitHub Copilot Chat** view.
1. Send `@upgrade` in chat and confirm the agent responds.

   -or-

   Select the **Agent** picker and find the `Upgrade` entry.

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

Install the `microsoft/upgrade-agent-plugins` marketplace through the GitHub Copilot app:

1. Click [this link](https://github.com/copilot/app/launch?entry_point=upgrade_agent_docs&open=ghapp%3A%2F%2Fplugins%2Fmarketplace%2Fadd%3Fsource%3Dmicrosoft%2Fupgrade-agent-plugins) to automatically open the **Settings** > **Plugins** window in the GitHub Copilot app.
1. In the **Add plugin marketplace?** dialog, select **Allow**.
1. The **Plugins** window opens with the `microsoft/upgrade-agent-plugins` marketplace, select **Add marketplace**.
1. Expand the **upgrade-agent-plugins** entry and select **Install** on the **upgrade-agent** plugin.

> [!IMPORTANT]
> If the plugin's button displays **Install** again after you select it, the installation failed. Close all instances of Visual Studio, Visual Studio Code, and Copilot CLI, and then try again.

## Verify the installation

Run `/agent` to confirm that `upgrade-agent:upgrade` appears in the agent list.

-or-

Select the **Default agent** picker and find the **Upgrade** entry.

::: zone-end

::: zone pivot="github-com"

## Prerequisites

Before you install, make sure you have:

- GitHub Copilot Enterprise or Business subscription with coding agents enabled.
- Repository admin access.

## Install

Add the custom coding agent to your repository:

1. Review [adding custom coding agents to your repository](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/coding-agent/create-custom-agents).
1. Add the `upgrade` agent. See the [coding agent README](https://github.com/microsoft/upgrade-agent-plugins/blob/main/cloud-agent/README.md) for details.

::: zone-end

## Related content

- [What is GitHub Copilot upgrade?](overview.md)
- [Upgrade a .NET app with GitHub Copilot upgrade](how-to-upgrade-with-github-copilot.md)
- [Core concepts](concepts.md)
- [GitHub Copilot upgrade FAQ](faq.yml)
