---
title: "How to: View the Contents of the Global Assembly Cache"
description: Learn how to view the contents of the global assembly cache in .NET by using the global assembly cache (GAC) tool (gacutil.exe).
ms.date: "03/30/2017"
helpviewer_keywords:
  - "assemblies [.NET Framework], global assembly cache"
  - "global assembly cache, viewing contents"
  - "viewing assemblies in global assembly cache"
  - "Gacutil.exe"
  - "strong-named assemblies, global assembly cache"
  - "GAC (global assembly cache), viewing contents"
  - "list of assemblies in global assembly cache"
  - "Global Assembly Cache tool"
ms.assetid: c5f786a0-969b-4f14-9f02-e77c3384d9af
---
# How to: View the contents of the global assembly cache

Use the [global assembly cache tool (gacutil.exe)](../tools/gacutil-exe-gac-tool.md) to view the contents of the global assembly cache (GAC).

## View the assemblies in the GAC

To view a list of the assemblies in the global assembly cache, open [Visual Studio Developer Command Prompt or Visual Studio Developer PowerShell](/visualstudio/ide/reference/command-prompt-powershell), and then enter the following command:

```shell
gacutil -l
```

-or-

```shell
gacutil /l
```

> [!NOTE]
> In earlier versions of .NET Framework, the [Shfusion.dll](/previous-versions/dotnet/netframework-4.0/34149zk3(v=vs.100)) Windows shell extension enabled you to view the global assembly cache in File Explorer. Beginning with .NET Framework 4, Shfusion.dll is obsolete.

## See also

- [Working with Assemblies and the Global Assembly Cache](working-with-assemblies-and-the-gac.md)
- [Gacutil.exe (Global Assembly Cache Tool)](../tools/gacutil-exe-gac-tool.md)
