---
title: "How to: Remove an Assembly from the Global Assembly Cache"
description: Learn how to remove an assembly from the global assembly cache in .NET, by using either the global assembly cache tool (Gacutil.exe) or Windows Installer.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "assemblies [.NET Framework], global assembly cache"
  - "Gacutil.exe"
  - "global assembly cache, removing assemblies"
  - "strong-named assemblies, global assembly cache"
  - "removing assemblies from global assembly cache"
  - "deleting assemblies in global assembly cache"
  - "Global Assembly Cache tool"
  - "GAC (global assembly cache), removing assemblies"
ms.assetid: acdcc588-b458-436d-876c-726de68244c1
---
# How to: Remove an Assembly from the Global Assembly Cache

There are two ways to remove an assembly from the global assembly cache (GAC):

- By using the [Global Assembly Cache tool (Gacutil.exe)](../tools/gacutil-exe-gac-tool.md). You can use this option to uninstall assemblies that you've placed in the GAC during development and testing.

- By using [Windows Installer](/windows/desktop/Msi/windows-installer-portal). You should use this option to uninstall assemblies when testing installation packages and for production systems.

## Removing an assembly with Gacutil.exe

At the command prompt, type the following command:

**gacutil –u** \<*assembly name*>

In this command, *assembly name* is the name of the assembly to remove from the global assembly cache.

> [!WARNING]
> You should not use Gacutil.exe to remove assemblies on production systems because of the possibility that the assembly may still be required by some application. Instead, you should use the Windows Installer, which maintains a reference count for each assembly it installs in the GAC.

The following example removes an assembly named `hello.dll` from the global assembly cache:

```console
gacutil -u hello
```

## Removing an assembly with Windows Installer

From the **Programs and Features** app in **Control Panel**, select the app that you want to uninstall. If the installation package placed assemblies in the GAC, Windows Installer will remove them if they are not used by another application.

> [!NOTE]
> Windows Installer maintains a reference count for assemblies installed in the GAC. An assembly is removed from the GAC only when its reference count reaches zero, which indicates that it is not used by any application installed by a Windows Installer package.

## See also

- [Working with Assemblies and the Global Assembly Cache](working-with-assemblies-and-the-gac.md)
- [How to: Install an Assembly into the Global Assembly Cache](install-assembly-into-gac.md)
- [Gacutil.exe (Global Assembly Cache Tool)](../tools/gacutil-exe-gac-tool.md)
