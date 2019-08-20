---
title: "How to: Install an assembly into the global assembly cache"
ms.date: 08/20/2019
helpviewer_keywords:
  - "assemblies [.NET Framework], global assembly cache"
  - "Gacutil.exe"
  - "strong-named assemblies, global assembly cache"
  - "global assembly cache, installing assemblies"
  - "Global Assembly Cache tool"
  - "windows installer, global assembly cache"
ms.assetid: a7e6f091-d02c-49ba-b736-7295cb0eb743
author: "rpetrusha"
ms.author: "ronpet"
---
# How to: Install an assembly into the global assembly cache

The global assembly cache stores assemblies that several applications share. Install an assembly into the [global assembly cache](../../framework/app-domains/gac.md) with one of the following components: 
- [Windows Installer](#windows-installer)
- [Global Assembly Cache tool](#global-assembly-cache-tool)

> [!IMPORTANT]
> You can install only strong-named assemblies into the global assembly cache. For information about how to create a strong-named assembly, see [How to: Sign an assembly with a strong name](sign-strong-name.md).

## Windows Installer

[Windows Installer](/windows/desktop/Msi/installation-of-assemblies-to-the-global-assembly-cache), the Windows installation engine, is the recommended way to add assemblies to the global assembly cache. Windows Installer provides reference counting of assemblies in the global assembly cache and other benefits. To create an installer package for Windows Installer, use the [WiX toolset extension for Visual Studio 2017](https://marketplace.visualstudio.com/items?itemName=RobMensching.WixToolsetVisualStudio2017Extension).

## Global Assembly Cache tool

You can use the [Global Assembly Cache tool (gacutil.exe)](../../framework/tools/gacutil-exe-gac-tool.md) to add assemblies to the global assembly cache and to view the contents of the global assembly cache.

   > [!NOTE]
   > *Gacutil.exe* is for development purposes only. Don't use it to install production assemblies into the global assembly cache.

The syntax for using *gacutil.exe* to install an assembly in the GAC is as follows:

```cmd
gacutil -i <assembly name>
```

In this command, *\<assembly name>* is the name of the assembly to install in the global assembly cache.

If *gacutil.exe* isn't in your system path, use the [Developer command prompt for VS *\<version>*](../../framework/tools/developer-command-prompt-for-vs.md).

The following example installs an assembly with the file name *hello.dll* into the global assembly cache.

```cmd
gacutil -i hello.dll
```

> [!NOTE]
> In earlier versions of the .NET Framework, the *Shfusion.dll* Windows shell extension let you install assemblies by dragging them to File Explorer. Beginning with .NET Framework 4, *Shfusion.dll* is obsolete.

## See also

- [Work with assemblies and the global assembly cache](../../framework/app-domains/working-with-assemblies-and-the-gac.md)
- [How to: Remove an assembly from the global assembly cache](../../framework/app-domains/how-to-remove-an-assembly-from-the-gac.md)
- [Gacutil.exe (Global Assembly Cache tool)](../../framework/tools/gacutil-exe-gac-tool.md)
- [How to: Sign an assembly with a strong name](sign-strong-name.md)
