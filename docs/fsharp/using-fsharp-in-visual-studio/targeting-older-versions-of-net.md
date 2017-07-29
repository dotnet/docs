---
title: Targeting .NET Framework 2.0 on Windows 8
description: Learn about targeting older version of the .NET Framework when using F#.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 63989543-95c3-4ab7-81f3-3834a8b15010 
---

# Targeting Older Versions of .NET

> [!NOTE]
This article is not up to date with the latest Visual Studio.  It will be updated.

The following error might appear if you try to target the .NET Framework 2.0, 3.0, or 3.5 in an F# project when Visual Studio is installed on Windows 8.1: 

```
This project requires the 2.0 F# runtime, but that runtime is not installed.
```

This error is known to occur under the following combination of conditions:


- You installed Visual Studio on Windows 8.1.
<br />

- You didn’t enable the .NET Framework 3.5 before you installed Visual Studio.
<br />

- Your project targets the .NET Framework 2.0, 3.0, or 3.5.
<br />

When you install Visual Studio, it detects the installed versions of the .NET Framework and installs the F# 2.0 Runtime only if the .NET Framework 3.5 is installed and enabled.


## Resolving the Error
To resolve this error, you can either target a newer version of the .NET Framework, or you can enable the .NET Framework 3.5 on Windows 8.1 and then install the F# 2.0 runtime by running the setup program for Visual Studio with the **Repair** option.


#### To enable the .NET Framework 3.5 on Windows 8.1

1. On the **Start** screen, start to enter **Control Panel**.
<br />  As you enter that name, the **Control Panel** icon appears under the **Apps** heading.
<br />

2. Choose the **Control Panel** icon, choose the **Programs** icon, and then choose the **Turn Windows features on or off** link.
<br />

3. Make sure that the **.NET Framework 3.5 (includes .NET 2.0 and 3.0)** check box is selected, and then choose the **OK** button.
<br />  You don’t need to select the check boxes for any child nodes for optional components of the .NET Framework.
<br />  The .NET Framework 3.5 is enabled if it wasn't already.
<br />


#### To install the F# 2.0 runtime

1. In the Control Panel, choose the **Programs** link, and then choose the **Programs and Features** link.
<br />

2. In the list of installed programs, choose the edition of Visual Studio that you installed, and then choose the **Change** button.
<br />

3. After setup starts, choose the **Repair** button.
<br />  For more information, see [Installing Visual Studio](https://msdn.microsoft.com/library/e2h7fzkw.aspx).
<br />
## See Also
[Visual F#](../index.md)
