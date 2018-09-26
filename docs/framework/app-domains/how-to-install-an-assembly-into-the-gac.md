---
title: Install an assembly into the GAC
ms.date: 09/20/2018
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

There are two ways to install a strong-named assembly into the global assembly cache (GAC).

> [!IMPORTANT]
> Only strong-named assemblies can be installed into the GAC. For information about how to create a strong-named assembly, see [How to: Sign an Assembly with a Strong Name](how-to-sign-an-assembly-with-a-strong-name.md).

## Windows Installer

[Windows Installer](/windows/desktop/Msi/installation-of-assemblies-to-the-global-assembly-cache), the Windows installation engine, is the recommended way to add assemblies to the global assembly cache. Windows Installer provides reference counting of assemblies in the global assembly cache and other benefits. You can use the [WiX Toolset extension for Visual Studio 2017](https://marketplace.visualstudio.com/items?itemName=RobMensching.WixToolsetVisualStudio2017Extension) to create an installer package for Windows Installer.

## Global assembly cache tool

You can use the [Global assembly cache tool (gacutil.exe)](../tools/gacutil-exe-gac-tool.md) to add strong-named assemblies to the global assembly cache and to view the contents of the global assembly cache.

   > [!NOTE]
   > Gacutil.exe is only for development purposes and should not be used to install production assemblies into the global assembly cache.

The syntax for gacutil is as follows:

```shell
gacutil -i <assembly name>
```

In this command, *assembly name* is the name of the assembly to install in the global assembly cache.

The following example installs an assembly with the file name `hello.dll` into the global assembly cache.

```shell
gacutil -i hello.dll
```

> [!NOTE]
> In earlier versions of the .NET Framework, the Shfusion.dll Windows shell extension enabled you to install assemblies by dragging them in **File Explorer**. Beginning with the .NET Framework 4, Shfusion.dll is obsolete.

## See also

- [Working with Assemblies and the Global Assembly Cache](working-with-assemblies-and-the-gac.md)
- [How to: Remove an Assembly from the Global Assembly Cache](how-to-remove-an-assembly-from-the-gac.md)
- [Gacutil.exe (Global Assembly Cache Tool)](../tools/gacutil-exe-gac-tool.md)
- [How to: Sign an Assembly with a Strong Name](how-to-sign-an-assembly-with-a-strong-name.md)