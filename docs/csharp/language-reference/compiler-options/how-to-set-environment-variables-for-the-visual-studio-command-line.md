---
title: "How to set environment variables for the Visual Studio Command Line"
ms.date: "12/20/2019"
f1_keywords:
  - "cs.build.commandline"
helpviewer_keywords:
  - "csc.exe, command-line builds"
  - "Visual C#, command-line builds"
  - "command-line compilers, Visual C#"
  - "Vsvars32.bat"
  - "builds [C#], command-line"
  - "compilers, invoking from command line"
  - "Vcvars32.bat file"
  - "command line [C#], building from"
  - "Visual C# compiler, enabling"
  - "compiling source code, from command line"
ms.assetid: 7ec09480-5612-4f6a-8d00-ad90ea9bca5d
---
# How to set environment variables for the Visual Studio Command Line

The VsDevCmd.bat file sets the appropriate environment variables to enable command-line builds.

> [!NOTE]
> Visual Studio 2015 and earlier versions used VSVARS32.bat, not VsDevCmd.bat for the same purpose. This file was stored in \Program Files\Microsoft Visual Studio\\*Version*\Common7\Tools or Program Files (x86)\Microsoft Visual Studio\\*Version*\Common7\Tools.

If the current version of Visual Studio is installed on a computer that also has an earlier version of Visual Studio, you should not run VsDevCmd.bat and VSVARS32.BAT from different versions in the same Command Prompt window. Instead, you should run the command for each version in its own window.

### To run VsDevCmd.BAT

1. From the **Start** menu, open the **Developer Command Prompt for VS 2019**.  It's in the **Visual Studio 2019** folder.

2. Change to the \Program Files\Microsoft Visual Studio\\*Version*\\*Offering*\Common7\Tools or \Program Files (x86)\Microsoft Visual Studio\\*Version*\\*Offering*\Common7\Tools subdirectory of your installation.  (*Version* is *2019* for the current version. *Offering* is one of *Enterprise*, *Professional* or *Community*.)

3. Run VsDevCmd.bat by typing **VsDevCmd**.

    > [!CAUTION]
    > VsDevCmd.bat can vary from computer to computer. Do not replace a missing or damaged VsDevCmd.bat file with a VsDevCmd.bat from another computer. Instead, rerun setup to replace the missing file.

### Available options for VsDevCmd.BAT

To see the available options for VsDevCmd.BAT, run the command with the `-help` option:

```console
VsDevCmd.bat -help
```

## See also

- [Command-line Building With csc.exe](./command-line-building-with-csc-exe.md)
