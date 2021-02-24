---
title: Developer Command Prompt for Visual Studio
description: Learn how to find and use the Developer Command Prompt for Visual Studio, which lets you use .NET tools more easily. It automatically sets specific environment variables.
ms.date: 02/23/2021
helpviewer_keywords:
  - "command prompt, Windows SDK"
  - "Visual Studio command prompt"
  - "command prompt, Visual Studio"
  - "SDK command prompt"
  - "tools [.NET Framework], setting environment variables"
  - "environment variables, setting for tools"
  - "developer command prompt"
ms.assetid: 94fcf524-9045-4993-bfb2-e2d8bad44219
---
# Developer Command Prompt for Visual Studio

Developer Command Prompt for Visual Studio is a command prompt that has specific environment variables set. It enables you to use command-line developer tools more easily. After opening Developer Command Prompt for Visual Studio, you can enter the commands for different utilities without having to know where they're located. The commands you can run from Developer Command Prompt include:

- [`MSBuild`](/visualstudio/msbuild/msbuild-command-line-reference), to build a project or solution.
- [.NET CLI commands](../../core/tools/index.md), such as [`dotnet`](../../core/tools/dotnet.md) and [`dotnet run`](../../core/tools/dotnet-run.md).
- [.NET Framework toolS](index.md), such as [`clrver`](clrver-exe-clr-version-tool.md) and [`ildasm`](ildasm-exe-il-disassembler.md).
- C/C++ compile tools, such as [`CL`](/cpp/build/reference/compiler-command-line-syntax) and [`NMAKE`](/cpp/build/reference/running-nmake).
- Additional C/C++ build tools, such as [`LIB`](/cpp/build/reference/lib-reference) AND [`DUMPBIN`](/cpp/build/reference/dumpbin-reference).

When you [open Developer Command Prompt from Visual Studio](#start-the-command-prompt-from-inside-visual-studio), it opens to the directory of your current solution. That makes it convenient to run commands on the solution or its projects.

## Prerequisites

- [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019)

## Find and open Developer Command Prompt

There are a few ways you can open Developer Command Prompt for Visual Studio, including from Visual Studio, from the Windows Start menu, or by running the command to start Developer Command Prompt for Visual Studio.

### Start the command prompt from inside Visual Studio

Follow these steps to open Developer Command Prompt from within Visual Studio:

1. Open Visual Studio.

1. On the menu bar, choose **Tools** > **Command Line** > **Developer Command Prompt**.

   ![Command prompt menu item in Visual Studio](./media/developer-command-prompt-for-vs/vs-menu.png)

### Search for the command prompt on your machine

You may have multiple command prompts, depending on the version of Visual Studio and any additional SDKs and workloads you've installed. If the following steps don't work, you can try to [manually locate the files on your machine](#manually-locate-the-files-on-your-machine) or [start the command prompt from inside Visual Studio](#start-the-command-prompt-from-inside-visual-studio).

#### Windows 10

1. Select **Start** ![Windows logo key on the keyboard.](./media/developer-command-prompt-for-vs/windows-logo-key-graphic.png) and scroll to the letter **V**.

1. Expand the **Visual Studio 2019** folder.

1. Choose **Developer Command Prompt for VS 2019** (or the command prompt you want to use).

   Alternatively, you can start typing the name of the command prompt in the search box on the taskbar, and choose the result you want as the result list starts to display the search matches.

   ![Animated gif showing the search behavior on Windows 10](./media/developer-command-prompt-for-vs/windows10-search.gif)

#### Windows 8.1

1. Go to the **Start** screen, by pressing the Windows logo key ![Windows logo key on the keyboard.](./media/developer-command-prompt-for-vs/windows-logo-key-graphic.png) on your keyboard for example.

1. On the **Start** screen, press **Ctrl**+**Tab** to open the **Apps** list, and then press **V**. This brings up a list that includes all installed Visual Studio command prompts.

1. Choose **Developer Command Prompt for VS 2019** (or the command prompt you want to use).

#### Windows 7

1. Choose **Start** and then expand **All Programs**.

1. Choose **Visual Studio 2019** > **Visual Studio Tools** > **Developer Command Prompt for VS 2019**, or the command prompt you want to use.

   ![Windows 7 Start menu with the command prompt highlighted](./media/developer-command-prompt-for-vs/windows7-menu.png)

If you have other SDKs installed, such as the [Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) or [previous versions](https://developer.microsoft.com/windows/downloads/sdk-archive), you may see additional command prompts. Check the documentation for the individual tools to determine which version of the command prompt you should use.

### Manually locate the file

Usually, the shortcuts for the command prompts you have installed are placed at the **Start Menu** folder for Visual Studio, such as in *%ProgramData%\Microsoft\Windows\Start Menu\Programs\Visual Studio 2019\Visual Studio Tools*. But if, for some reason, searching for the command prompt doesn't produce the expected results, you can try to manually locate the shortcut on your machine. Search for the name of the command prompt file, which is *VsDevCmd.bat*, or go to the Tools folder, such as *%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Community\Common7\Tools* (path changes according to your Visual Studio version, edition, and installation location).

## Related tools

In additional to Developer Command Prompt, Visual Studio 2019 also includes two other related features:

- [Developer PowerShell](https://devblogs.microsoft.com/visualstudio/the-powershell-you-know-and-love-now-with-a-side-of-visual-studio/), which you can open from the **Tools** > **Command Line** > **Developer PowerShell** menu.
- An integrated [Terminal](https://devblogs.microsoft.com/visualstudio/say-hello-to-the-new-visual-studio-terminal/), which you can open from the **View** > **Terminal** menu.

## See also

- [Developer PowerShell](https://devblogs.microsoft.com/visualstudio/the-powershell-you-know-and-love-now-with-a-side-of-visual-studio/)
- [Say hello to the new Visual Studio terminal](https://devblogs.microsoft.com/visualstudio/say-hello-to-the-new-visual-studio-terminal/)
- [.NET Framework Tools](index.md)
- [Manage external tools](/visualstudio/ide/managing-external-tools)
- [Use the Microsoft C++ toolset from the command line](/cpp/build/building-on-the-command-line)
