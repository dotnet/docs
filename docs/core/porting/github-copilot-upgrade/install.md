---
title: Install GitHub Copilot upgrade / Upgrade agent
description: "Learn how to install and set up the GitHub Copilot upgrade agent across Visual Studio, Visual Studio Code, GitHub Copilot CLI, and GitHub.com."
ms.topic: install-set-up-deploy
ms.date: 07/07/2026
ai-usage: ai-assisted
zone_pivot_groups: copilot-modernization-install

#customer intent: As a developer, I want to install the GitHub Copilot upgrade agent so that I can upgrade my .NET applications.

---

# Install GitHub Copilot upgrade / Upgrade agent

The GitHub Copilot upgrade agent works across multiple development environments. Choose your preferred environment to install and set up the GitHub Copilot upgrade agent.

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

Visual Studio includes the GitHub Copilot upgrade agent through the **GitHub Copilot app modernization** optional component, so you don't need to install it separately. Enable the **GitHub Copilot** and **GitHub Copilot app modernization** optional components in the **.NET desktop development** workload through the Visual Studio Installer.

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

Install through the GitHub Copilot app:

1. Click [https://github.com/copilot/app/launch](https://github.com/copilot/app/launch?entry_point=upgrade_agent_docs&open=ghapp%3A%2F%2Fplugins%2Fmarketplace%2Fadd%3Fsource%3Dmicrosoft%2Fupgrade-agent-plugins) to automatically open the **Settings** > **Plugins** window in the GitHub Copilot app.
1. In the **Add plugin marketplace?** dialog, select **Allow**.
1. In the **Plugins** window, select **Add marketplace**.
1. Expand the **upgrade-agent-plugins** entry and select **Install** on the **upgrade-agent** plugin.

## Verify the installation

Run `/agent` to confirm that `upgrade-agent:upgrade` appears in the agent list.

-or-

Select the **Default agent** picker and find the **Upgrade** entry.

::: zone-end

## Run in Copilot Coding Agent (Cloud)

You can run the GitHub Copilot upgrade agent as a Copilot coding agent in the cloud.

### 1. Copy the agent file

To configure the agent, copy `upgrade.agent.md` to the `.github\agents` folder in your repository.

### 2. Add the setup steps

To set up the environment, copy one of the provided setup step files to your `.github\workflows` folder as `copilot-setup-steps.yml` based on your workload:

- **Linux** (`linux/copilot-setup-steps.yml`): Use this file for most .NET workloads on Linux.
- **Windows** (`windows/copilot-setup-steps.yml`): Use this file for .NET Framework or .NET Core desktop workloads on Windows.

If you already have a `copilot-setup-steps.yml` file, carefully merge the steps from the selected file into your existing file.

### 3. Disable the firewall (Windows only)

If you use the Windows setup steps, disable the integrated firewall in your repository settings:

1. Go to **Settings** > **Copilot** > **Coding agent**.
2. Disable the **Enable firewall** option because the integrated firewall is incompatible with Windows runners.

> [!WARNING]
> Disabling the firewall removes network restrictions on the agent, allowing it to make unrestricted outbound connections during its run. Only disable the firewall if you trust the repositories and workflows where the agent operates. For more information, see the [Copilot coding agent firewall guidelines](https://github.blog/changelog/2026-02-18-use-copilot-coding-agent-with-windows-projects/).

## Related content

- [What is GitHub Copilot upgrade / Upgrade agent?](overview.md)
- [Upgrade a .NET app with the GitHub Copilot upgrade agent](how-to-upgrade-with-github-copilot.md)
- [Core concepts](concepts.md)
- [GitHub Copilot upgrade FAQ](faq.yml)
