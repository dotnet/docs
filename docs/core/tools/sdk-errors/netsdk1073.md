---
title: "NETSDK1073: The FrameworkReference was not recognized"
description: How to resolve the issue where the FrameworkReference cannot be found.
author: marcpopMSFT
ms.topic: error-reference
ms.date: 10/9/2020
f1_keywords:
- NETSDK1073
---
# NETSDK1073: The FrameworkReference was not recognized

**This article applies to:** ✔️ .NET Core 2.1.100 SDK and later versions

This error typically means there is a version of a particular shared framework reference that the SDK cannot find. Try deleting your *obj* and *bin* folders and running `dotnet restore` to redownload the latest targeting packs.

Alternatively, there could be an issue with your install, so ensure you're on the latest versions of .NET and Visual Studio
