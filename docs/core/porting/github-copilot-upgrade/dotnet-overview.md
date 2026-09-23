---
title: Upgrade .NET projects with GitHub Copilot
description: Learn which .NET upgrade and modernization workflows GitHub Copilot upgrade supports.
ms.topic: overview
ms.date: 09/21/2026
ai-usage: ai-generated

#customer intent: As a .NET developer, I want to understand which upgrades GitHub Copilot can perform so that I can choose the right workflow for my project.
---

# Upgrade .NET projects with GitHub Copilot

GitHub Copilot upgrade supports C#, Visual Basic, and F# projects across modern .NET and .NET Framework. Use the agent to upgrade target frameworks, modernize project files, replace libraries, and migrate application architectures.

## Choose an upgrade workflow

- To move an application to a newer .NET version, follow [Upgrade a .NET app](dotnet-how-to-upgrade-with-github-copilot.md).
- To encode transformations for your codebase, follow [Apply custom .NET upgrade instructions](dotnet-how-to-custom-upgrade-instructions.md).
- To review available workflows and focused capabilities, see [.NET scenarios and skills](dotnet-scenarios-and-skills.md).
- To move a .NET application to Azure services, see [GitHub Copilot modernization overview](../../../azure/migration/appmod/overview.md).

The agent can combine related capabilities during an upgrade. For example, a .NET version upgrade might also convert legacy project files, update NuGet packages, or migrate an unsupported library.

## Supported project types

The .NET technology pack supports common project types, including:

- ASP.NET Core, ASP.NET Web Forms, and Blazor applications.
- Azure Functions projects.
- Windows Forms, Windows Presentation Foundation (WPF), WinUI, .NET MAUI, and Xamarin applications.
- Class libraries, console applications, and test projects.
- Visual Studio extensions.

Support varies by upgrade scenario. For the complete capability list, see [.NET scenarios and skills](dotnet-scenarios-and-skills.md).

## Related content

- [GitHub Copilot upgrade overview](overview.md)
- [Install GitHub Copilot upgrade](install.md)
- [GitHub Copilot upgrade concepts](concepts.md)
- [Troubleshoot GitHub Copilot upgrade](troubleshooting.md)
