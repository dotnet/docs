---
title: Debug Windows dumps
description: In this article, you'll learn how to analyze dumps from Windows environments.
ms.date: 01/11/2023
---

# Debug Windows dumps

**This article applies to: ✔️** .NET Core 3.1 and later versions

## Analyze dumps on Windows

Windows dumps can be analyzed on Windows with [Visual Studio](/visualstudio/debugger/using-dump-files), [Windbg](https://learn.microsoft.com/windows-hardware/drivers/debugger/debugger-download-tools), or the [`dotnet-dump`](dotnet-dump.md) CLI tool. Visual Studio and Windbg can access both managed and native code and are the recommended tools for a Windows environment. dotnet-dump can only access managed code.
