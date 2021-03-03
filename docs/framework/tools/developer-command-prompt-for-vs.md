---
title: Developer command-line tools
description: Learn how to find and use the Developer Command Prompt for Visual Studio, Developer PowerShell, and Visual Studio terminal, which let you use .NET and C++ tools more easily.
ms.date: 02/24/2021
ms.custom: contperf-fy21q3
helpviewer_keywords:
  - "Visual Studio command prompt"
  - "command prompt, Visual Studio"
  - "developer command prompt"
  - "developer PowerShell"
  - "Visual Studio terminal"
ms.assetid: 94fcf524-9045-4993-bfb2-e2d8bad44219
no-loc: cmdlet
---
# Command-line shells for developers

Visual Studio 2019 includes two command-line shells for developers:

- **Developer Command Prompt for Visual Studio** - A standard command prompt with certain environment variables set to make using command-line developer tools easier.
- **Developer PowerShell** - More powerful than a command prompt. For example, you can pass the output of one command (known as a *cmdlet*) to another cmdlet. This shell has the same environment variables set as Developer Command Prompt.

Both shells have specific environment variables set that enable you to use command-line developer tools more easily. After opening one of these shells, you can enter the commands for different utilities without having to know where they're located. The commands you can run include:

- [`MSBuild`](/visualstudio/msbuild/msbuild-command-line-reference), to build a project or solution.
- [.NET Framework tools](index.md), such as [`clrver`](clrver-exe-clr-version-tool.md) and [`ildasm`](ildasm-exe-il-disassembler.md).
- C/C++ compile tools, such as [`CL`](/cpp/build/reference/compiler-command-line-syntax) and [`NMAKE`](/cpp/build/reference/running-nmake).
- Additional C/C++ build tools, such as [`LIB`](/cpp/build/reference/lib-reference) AND [`DUMPBIN`](/cpp/build/reference/dumpbin-reference).
- [.NET CLI commands](../../core/tools/index.md), such as [`dotnet`](../../core/tools/dotnet.md) and [`dotnet run`](../../core/tools/dotnet-run.md). (These commands are available from a regular command prompt, too.)

:::image type="content" source="media/developer-command-prompt-for-vs/command-prompt.png" alt-text="Developer Command Prompt for Visual Studio showing clrver tool":::

Starting in Visual Studio 2019 version 16.5, Visual Studio includes an integrated **terminal** that can host either of these shells (Developer Command Prompt and Developer PowerShell). You can also open multiple tabs of each shell. The Visual Studio terminal is built on top of [Windows Terminal](/windows/terminal/). To open the terminal in Visual Studio, choose **View** > **Terminal**.

:::image type="content" source="media/developer-command-prompt-for-vs/vs-terminal.png" alt-text="Visual Studio terminal showing multiple tabs":::

When you open one of the developer shells from Visual Studio, either as a separate app or in the Terminal window, it opens to the directory of your current solution (if you have a solution loaded). This behavior makes it convenient to run commands against the solution or its projects.

## Prerequisites

- [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019)

## Start the shell from inside Visual Studio

Follow these steps to open Developer Command Prompt or Developer PowerShell from within Visual Studio:

1. Open Visual Studio.

1. On the menu bar, choose **Tools** > **Command Line** > **Developer Command Prompt** or **Developer PowerShell**.

   ![Command prompt menu item in Visual Studio](./media/developer-command-prompt-for-vs/vs-menu.png)

### Use the Windows Start menu

You may have multiple command prompts, depending on the version of Visual Studio and any additional SDKs and workloads you've installed. If the following steps don't work, you can try to [manually locate the files on your machine](#manually-locate-the-files-on-your-machine) or [start the shell from inside Visual Studio](#start-the-shell-from-inside-visual-studio).

#### Windows 10

1. Select **Start** ![Windows logo key on the keyboard.](./media/developer-command-prompt-for-vs/windows-logo-key-graphic.png) and scroll to the letter **V**.

1. Expand the **Visual Studio 2019** folder.

1. Choose **Developer Command Prompt for VS 2019** or **Developer PowerShell for VS 2019**.

   Alternatively, you can start typing the name of the shell in the search box on the taskbar, and choose the result you want as the result list starts to display the search matches.

   ![Animated gif showing the search behavior on Windows 10](./media/developer-command-prompt-for-vs/windows10-search.gif)

#### Windows 8.1

1. Go to the **Start** screen, by pressing the Windows logo key ![Windows logo key on the keyboard.](./media/developer-command-prompt-for-vs/windows-logo-key-graphic.png) on your keyboard for example.

1. On the **Start** screen, press **Ctrl**+**Tab** to open the **Apps** list, and then press **V**. This brings up a list that includes all installed Visual Studio command prompts.

1. Choose **Developer Command Prompt for VS 2019** or **Developer PowerShell for VS 2019**.

#### Windows 7

1. Choose **Start** and then expand **All Programs**.

1. Choose **Visual Studio 2019** > **Visual Studio Tools** > **Developer Command Prompt for VS 2019** or **Developer PowerShell for VS 2019**.

   ![Windows 7 Start menu with the command prompt highlighted](./media/developer-command-prompt-for-vs/windows7-menu.png)

If you have other SDKs installed, such as the [Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) or [previous versions](https://developer.microsoft.com/windows/downloads/sdk-archive), you may see additional command prompts. Check the documentation for the individual tools to determine which version of the command prompt you should use.

### Manually locate the file

Usually, the shortcuts for the shells you have installed are placed in the **Start Menu** folder for Visual Studio, such as in *%ProgramData%\Microsoft\Windows\Start Menu\Programs\Visual Studio 2019\Visual Studio Tools*. But if searching for the command prompt doesn't produce the expected results, you can try to manually locate the files on your machine.

#### Developer Command Prompt

Search for the name of the command prompt file, which is *VsDevCmd.bat*, or go to the Tools folder for Visual Studio, such as *%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Community\Common7\Tools* (path changes according to your Visual Studio version, edition, and installation location).

Once you've located the command prompt file, open it by entering the following command in a regular command prompt window:

```cmd
"%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Community\Common7\Tools\VsDevCmd.bat"
```

Or enter the following command in the Windows **Run** dialog box:

```cmd
%comspec% /k "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\Tools\VsDevCmd.bat"
```

> [!TIP]
> You'll need to edit the path to match your Visual Studio installation.

#### Developer PowerShell

Search for a PowerShell script file named *Launch-VsDevShell.ps1*, or go to the Tools folder for Visual Studio, such as *%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Community\Common7\Tools*. (The path changes according to your Visual Studio version, edition, and installation location.) Once you've located the PowerShell file, run it by entering the following command at a Windows PowerShell or PowerShell 6 prompt:

```powershell
& 'C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\Tools\Launch-VsDevShell.ps1'
```

By default, the Developer PowerShell that launches is configured for the Visual Studio installation whose install path the *Launch-VsDevShell.ps1* file is located in.

> [!TIP]
> The [execution policy](/powershell/module/microsoft.powershell.core/about/about_execution_policies) must be set in order for the cmdlet to run.

## See also

- [Developer PowerShell](https://devblogs.microsoft.com/visualstudio/the-powershell-you-know-and-love-now-with-a-side-of-visual-studio/)
- [Say hello to the new Visual Studio terminal](https://devblogs.microsoft.com/visualstudio/say-hello-to-the-new-visual-studio-terminal/)
- [Windows Terminal](/windows/terminal/)
- [.NET Framework Tools](index.md)
- [Manage external tools](/visualstudio/ide/managing-external-tools)
- [Use the Microsoft C++ toolset from the command line](/cpp/build/building-on-the-command-line)
