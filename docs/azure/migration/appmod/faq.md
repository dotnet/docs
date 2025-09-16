---
title: GitHub Copilot app modernization for .NET (Preview) FAQ 
description: Discover answers to common questions about GitHub Copilot app modernization for .NET 
ms.topic: concept-article
ms.custom: devx-track-dotnet
ms.date: 7/15/2025
author: alexwolfmsft
ms.author: alexwolf
---

# Frequently Asked Questions for GitHub Copilot app modernization for .NET (Preview)

This page answers common questions about [GitHub Copilot app modernization for .NET (Preview)](overview.md).

## Which version of Visual Studio should I use?

Upgrade to Visual Studio 2022 version 17.14.11 or later for the best experience with both GitHub Copilot and App Modernization for .NET (Preview).

## Which model should I use in GitHub Copilot agent mode?

Based on our benchmark, GitHub Copilot and App Modernization for .NET work best with Claude Sonnet 4.0 then Claude Sonnet 3.7.

## What is the MCP Server, and why is there sometimes an initial delay when running a command?

The GitHub Copilot app modernization for .NET (Preview) extension uses an MCP Server to provide Azure-related knowledge bases as tools.

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

## Why is there an error in the "appModernization" group under Tools in GitHub Copilot Agent mode after uninstalling the extension, and how can I fix it?

When the extension is installed, it adds a configuration entry to `%USERPROFILE%\.mcp.json` to register the `appModernization` tool with GitHub Copilot Agent in Visual Studio. This enables the `Tools → appModernization` group within Copilot Agent mode.
After the extension is uninstalled, this configuration remains. Since the associated command no longer exists, GitHub Copilot Agent mode displays a red error indicator next to the `appModernization` group.

To resolve this:

- **Edit `%USERPROFILE%\.mcp.json`**

   Open the file in a text editor and remove the `"appModernization"` entry from the `"servers"` section.
   Save the file after removing this block.
- **Or delete the file entirely**

   If `.mcp.json` contains no other important configuration, you may simply delete the file.

Once cleaned up, the error in the `Tools → appModernization` group will no longer appear.

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

This error occurs when AppCAT cannot find a compatible .NET SDK, even if you have other .NET SDKs installed. AppCAT requires the .NET 9.0 SDK to run properly.

To fix this error:

1. Download and install the .NET 9 SDK from <https://dotnet.microsoft.com/download/dotnet/9.0>.
2. Restart Visual Studio.
3. Run the assessment again.

> [!NOTE]
> The GitHub Copilot app modernization for .NET extension can automatically help you install or upgrade to .NET 9. If you have an older version of the extension, updating to the latest version will provide automatic installation assistance for the required .NET 9 SDK.

## Does the tool store my source code?

No. The tool uses GitHub Copilot in the same way you use it to modify code, and doesn't retain code snippets beyond the immediate session. Telemetry metrics are collected and analyzed to track feature usage and effectiveness.

For more information, see the [Microsoft Privacy Statement](https://go.microsoft.com/fwlink/?LinkId=521839).

## What are the intended uses of GitHub Copilot app modernization for .NET (Preview)?

GitHub Copilot app modernization for .NET (Preview) is designed to help enterprises migrate their .NET applications to Azure. It assesses application code issues that need to be addressed for migration and provides code remediation patterns that can be applied with AI.

## How was GitHub Copilot app modernization for .NET (Preview) evaluated? What metrics are used to measure performance?

GitHub Copilot app modernization for .NET (Preview) was evaluated through extensive manual and automated testing. Additional evaluation was performed using custom datasets for offensive and malicious prompts (user questions) and responses. The tool is also continuously evaluated with user feedback.

## What are the limitations of GitHub Copilot app modernization for .NET (Preview)?

GitHub Copilot app modernization for .NET (Preview) can be used on application source code written in .NET Framework or .NET Core. Applications in other languages are not supported.

## What operational factors and settings allow for effective and responsible use of GitHub Copilot app modernization for .NET (Preview)?

You can choose the model to make code changes at the bottom of the GitHub Copilot chat box. Different models may produce different results and have varying token consumption. For more information, see [Manage Copilot usage and models](/visualstudio/ide/copilot-usage-and-models).

## How do I provide feedback on GitHub Copilot app modernization for .NET (Preview)?

We value your feedback—share [your thoughts here](https://aka.ms/AM4DFeedback) to help us continue improving the product.
