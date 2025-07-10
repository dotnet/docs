---
title: GitHub Copilot App Modernization for .NET FAQ
description: Frequently asked questions for the GitHub Copilot App Modernization for .NET
ms.topic: concept-article
ms.date: 07/03/2025
---

# Frequently asked questions

This page answers some of the most common questions about the GitHub Copilot App Modernization for .NET tool.

### What is GitHub Copilot App Modernization for .NET?

GitHub Copilot App Modernization for .NET aims to help enterprises migrate their .NET applications to Azure with confidence and efficiency, covering assessment, code remediation and validation, powered by the intelligence of GitHub Copilot.
 
Assessment of modernization issues
- App modernization for .NET evaluates the readiness of developer's application for migration to Azure, with an interactive experience on Visual Studio, powered by AppCAT for .NET.
 
Solution recommendations
- App modernization for .NET recommends target Azure services for the resource dependencies of developer's application, for each category of assessed issues.
 
Code remediation for common issues
- To accelerate code changes for common modernization issues, the developer may apply predefined tasks that represent best practices from Microsoft.
 
Automatic fix for compilation errors
- After applying tasks, app modernization for .NET will automatically find and fix compilation errors introduced by the code changes.

### Which Visual Studio version should I use?

Please upgrade Visual Studio 2022 to the latest version (at least equal or above 17.14.7) to have better experience on both GitHub Copilot and App Modernization for .NET.

### What is the MCP Server and why is there an initial delay when running a command sometimes?

The GitHub Copilot App Modernization for .NET extension uses an `MCP Server` to provide Azure related knowledge bases as tools.

- **Automatic setup**  
  On the first invocation of any App Modernization command, the extension checks for a configuration file at `%USERPROFILE%\.mcp.json`. If it’s missing or the server isn’t running, the extension writes the default settings and launches the MCP Server automatically.

- **First-run delay**  
  Starting and initializing the MCP Server can take anywhere from a few milliseconds up to about 20 seconds.

- **Subsequent invocations**  
  Once the MCP Server is running locally, you shouldn’t see that startup delay again.

- **Using MCP tools in the VS Copilot Agent out of extension**  
  You can also access the same MCP-based knowledge tools inside the built-in VS Copilot Agent. Just run **Configure MCP Server**, and the full suite of MCP tools appears under the Copilot agent’s tools dropdown.

### What should I do when configure MCP Server fails?

If the MCP Server doesn’t start correctly, try the following:

1. Retry the **Configure MCP Server** command.  
2. If it still fails, manually restart the MCP Server:
   1. Switch the Github Copilot to **Agent** mode.  
   1. Click the **Tools** icon in the pane.  
   1. Expand the **appModernization** section by clicking the arrow icon next to it.  
   1. Click **Restart** to relaunch the MCP Server.
 
### How can I monitor the assessment progress?

While the assessment is running, you can monitor its progress by viewing the command-line output:

1. In Visual Studio, go to **View** > **Output** to open the Output window.
1. In the Output window, find the **Show output from:** dropdown.
1. Select **AppModernizationExtension** from the dropdown list.
1. The command-line output from the assessment tool appears here, showing real-time progress.

You can also access the Output window using the keyboard shortcut **Ctrl+Alt+O**.

### What should I do if Visual Studio fails to install AppCAT?

If you see an AppCAT installation failure in the command-line output when the extension tries to install it automatically, you can install AppCAT manually:

1. Follow the instructions in [Install the .NET global tool](/dotnet/azure/migration/appcat/install#install-the-net-global-tool).
1. After successful installation, run the assessment again.

> [!TIP]
> Make sure you have the required .NET SDK version installed before attempting to install AppCAT manually.


### What should I do if I see errors during assessment?

If you encounter errors in the command-line output while running an assessment, the issue might be related to .NET SDK compatibility. AppCAT works best with .NET 8 SDK.

To resolve this:

1. Install .NET 8 SDK from <https://dotnet.microsoft.com/download/dotnet/8.0>.
1. Restart Visual Studio after installation.
1. Run the assessment again.

AppCAT automatically detects and uses the appropriate .NET SDK version once it's installed.
