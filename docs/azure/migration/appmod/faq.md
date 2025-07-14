---
title: GitHub Copilot App Modernization for .NET FAQ
description: Frequently asked questions for the GitHub Copilot App Modernization for .NET
ms.topic: concept-article
ms.date: 07/03/2025
---

# Frequently asked questions

This page answers some of the most common questions about the GitHub Copilot App Modernization for .NET tool.

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

### What should I do if I see "Command failed: No .NET SDKs were found" errors?

This error occurs when AppCAT can't find a compatible .NET SDK, even if you have other .NET SDKs installed. AppCAT requires .NET 8 SDK to run properly.

To fix this error:

1. Download and install .NET 8 SDK from <https://dotnet.microsoft.com/download/dotnet/8.0>.
1. Restart Visual Studio.
1. Run the assessment again.

### Does the tool store my source code?

No. The tool uses GitHub Copilot in the same way you use it to modify code, which doesn't retain code snippets beyond the immediate session. Telemetry metrics are collected and analyzed to track feature usage and effectiveness.

For more information, see the [Microsoft Privacy Statement](https://go.microsoft.com/fwlink/?LinkId=521839).

### What are the intended uses of GitHub Copilot App Modernization for .NET?

GitHub Copilot App Modernization for .NET is intended to help enterprises migrate their .NET applications to Azure. It assesses the application code issues need to be addressed for migration, and provides code remediation patterns that can be applied with AI.

### How was GitHub Copilot App Modernization for .NET evaluated? What metrics are used to measure performance? 

GitHub Copilot App Modernization for .NET was evaluated through extensive manual and automated testing. More evaluation was performed over custom datasets for offensive and malicious prompts (user questions) and responses. In addition, GitHub Copilot App Modernization for .NET is continuously evaluated with user online feedback.

### What are the limitations of GitHub Copilot App Modernization for .NET?

GitHub Copilot App Modernization for .NET can be used on application source code written in .NET framework or .NET Core. Applications in other languages are not supported.

### What operational factors and settings allow for effective and responsible use of GitHub Copilot App Modernization for .NET?

You may choose the model to make code changes at the bottom of the GitHub Copilot chat box, but different models will have different effects for code changes, with different token consumption. For more information, please refer to [Manage Copilot usage and models](https://learn.microsoft.com/en-us/visualstudio/ide/copilot-usage-and-models).

### How do I provide feedback on GitHub Copilot App Modernization for .NET? 

We value your feedback — share [your thoughts here](https://aka.ms/AM4DFeedback) to help us continue improving the product.