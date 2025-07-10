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

### TODO(wepa) MCP server related faq + config mcp server action 

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

