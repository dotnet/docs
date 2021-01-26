---
title: "NETSDK1004: Assets file not found"
description: Learn about .NET SDK error NETSDK1004, which occurs when the project.assets.json file is not found.
ms.topic: error-reference
ms.date: 01/26/2021
f1_keywords:
- NETSDK1004
---
# NETSDK1004: Assets file not found

**This article applies to:** ✔️ .NET Core 2.1.100 SDK and later versions

This error occurs when the assets file *project.assets.json* is not found during build. The full error message is similar to:

**NETSDK1004: Assets file 'C:\IncorrectPath\project.assets.json' not found. Run a NuGet package restore to generate this file.**

One reason you might encounter warning NETSDK1004 is if you run the `dotnet build` command from a directory path that contains a `%` character.
