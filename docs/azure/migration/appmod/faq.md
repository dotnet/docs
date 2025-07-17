---
title: GitHub Copilot App Modernization for .NET (Preview) FAQ 
description: Discover answers to common questions about GitHub Copilot App Modernization for .NET 
ms.topic: concept-article
ms.custom: devx-track-dotnet
ms.date: 7/15/2025
author: alexwolfmsft
ms.author: alexwolf
---

# Frequently Asked Questions for GitHub Copilot App Modernization for .NET (Preview)

This page answers common questions about [GitHub Copilot App Modernization for .NET (Preview)](overview.md).

## Which version of Visual Studio should I use?

Upgrade to Visual Studio 2022 version 17.14.7 or later for the best experience with both GitHub Copilot and App Modernization for .NET (Preview).

## Which model should I use in GitHub Copilot agent mode?

Based on our experience, GitHub Copilot and App Modernization for .NET work best with Claude Sonnet 3.7 and Claude Sonnet 4.0.

## What is the MCP Server, and why is there sometimes an initial delay when running a command?

The GitHub Copilot App Modernization for .NET (Preview) extension uses an MCP Server to provide Azure-related knowledge bases as tools.

- **Automatic setup:**  
  On the first invocation of any App Modernization command, the extension checks for a configuration file at `%USERPROFILE%\.mcp.json`. If it's missing or the server isn't running, the extension writes the default settings and launches the MCP Server automatically.

- **First-run delay:**  
  Starting and initializing the MCP Server can take anywhere from a few milliseconds up to about 20 seconds.

- **Subsequent invocations:**  
  Once the MCP Server is running locally, you should not see that startup delay again.

- **Using MCP tools in the VS Copilot Agent (outside the extension):**  
  You can also access the same MCP-based knowledge tools inside the built-in VS Copilot Agent. Just run **Configure MCP Server**, and the full suite of MCP tools appears under the Copilot agent's tools dropdown.

## What should I do if configuring the MCP Server fails?

If the MCP Server doesn't start correctly, try the following steps:

1. Retry the **Configure MCP Server** command.
2. If it still fails, manually restart the MCP Server:
   1. Switch GitHub Copilot to **Agent** mode.
   2. Click the **Tools** icon in the pane.
   3. Expand the **appModernization** section by clicking the arrow icon next to it.
   4. Click **Restart** to relaunch the MCP Server.

## How can I monitor assessment progress?

While the assessment is running, you can monitor its progress by viewing the command-line output:

1. In Visual Studio, go to **View** > **Output** to open the Output window.
2. In the Output window, find the **Show output from:** dropdown.
3. Select **AppModernizationExtension** from the dropdown list.
4. The command-line output from the assessment tool appears here, showing real-time progress.

You can also access the Output window using the keyboard shortcut **Ctrl+Alt+O**.

## What should I do if Visual Studio fails to install AppCAT?

If you see an AppCAT installation failure in the command-line output when the extension tries to install it automatically, you can install AppCAT manually:

1. Open a command prompt or PowerShell as Administrator.
2. Run the appropriate command based on your shell:

   **For Command Prompt:**
   ```cmd
   dotnet tool install dotnet-appcat --tool-path "%LOCALAPPDATA%\Microsoft\VisualStudio\AppModernizationExtension\Tools"
   ```

   **For PowerShell:**
   ```powershell
   dotnet tool install dotnet-appcat --tool-path "$env:LOCALAPPDATA\Microsoft\VisualStudio\AppModernizationExtension\Tools"
   ```

3. After successful installation, run the assessment again.

> [!IMPORTANT]
> Installing this tool may fail if you've configured additional NuGet feed sources. Use the `--ignore-failed-sources` parameter to treat those failures as warnings instead of errors.

### What should I do if Visual Studio fails to upgrade AppCAT?

If Visual Studio fails to automatically upgrade AppCAT when a new version is available, you can upgrade it manually:

1. Open a command prompt or PowerShell as Administrator.
2. Run the appropriate command based on your shell:

   **For Command Prompt:**
   ```cmd
   dotnet tool update dotnet-appcat --tool-path "%LOCALAPPDATA%\Microsoft\VisualStudio\AppModernizationExtension\Tools"
   ```

   **For PowerShell:**
   ```powershell
   dotnet tool update dotnet-appcat --tool-path "$env:LOCALAPPDATA\Microsoft\VisualStudio\AppModernizationExtension\Tools"
   ```

3. After successful upgrade, run the assessment again.

## What should I do if I see "Command failed: No .NET SDKs were found" errors?

This error occurs when AppCAT cannot find a compatible .NET SDK, even if you have other .NET SDKs installed. AppCAT requires the .NET 8.0 SDK to run properly.

To fix this error:

1. Download and install the .NET 8 SDK from <https://dotnet.microsoft.com/download/dotnet/8.0>.
2. Restart Visual Studio.
3. Run the assessment again.

## Does the tool store my source code?

No. The tool uses GitHub Copilot in the same way you use it to modify code, and doesn't retain code snippets beyond the immediate session. Telemetry metrics are collected and analyzed to track feature usage and effectiveness.

For more information, see the [Microsoft Privacy Statement](https://go.microsoft.com/fwlink/?LinkId=521839).

## What are the intended uses of GitHub Copilot App Modernization for .NET (Preview)?

GitHub Copilot App Modernization for .NET (Preview) is designed to help enterprises migrate their .NET applications to Azure. It assesses application code issues that need to be addressed for migration and provides code remediation patterns that can be applied with AI.

## How was GitHub Copilot App Modernization for .NET (Preview) evaluated? What metrics are used to measure performance?

GitHub Copilot App Modernization for .NET (Preview) was evaluated through extensive manual and automated testing. Additional evaluation was performed using custom datasets for offensive and malicious prompts (user questions) and responses. The tool is also continuously evaluated with user feedback.

## What are the limitations of GitHub Copilot App Modernization for .NET (Preview)?

GitHub Copilot App Modernization for .NET (Preview) can be used on application source code written in .NET Framework or .NET Core. Applications in other languages are not supported.

## What operational factors and settings allow for effective and responsible use of GitHub Copilot App Modernization for .NET (Preview)?

You can choose the model to make code changes at the bottom of the GitHub Copilot chat box. Different models may produce different results and have varying token consumption. For more information, see [Manage Copilot usage and models](/visualstudio/ide/copilot-usage-and-models).

## How do I provide feedback on GitHub Copilot App Modernization for .NET (Preview)?

We value your feedback—share [your thoughts here](https://aka.ms/AM4DFeedback) to help us continue improving the product.
