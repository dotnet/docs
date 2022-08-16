---
title: "NETSDK1182: Targeting .NET 6.0 or higher in Visual Studio 2019 is not supported."
description: Learn about the 'Targeting .NET 6.0 or higher in Visual Studio 2019 is not supported' error message.
ms.topic: error-reference
ms.date: 07/08/2022
f1_keywords:
- NETSDK1182
---
# NETSDK1182: Targeting .NET 6.0 or higher in Visual Studio 2019 is not supported

NETSDK1182 indicates that you're trying to open a .NET 6+ project in Visual Studio 2019. Or you might be trying to build from the command line using MSBuild from Visual Studio 2019. The full error message is similar to the following example:

> Targeting .NET 6.0 or higher in Visual Studio 2019 is not supported.

To resolve this error switch to Visual Studio 2022, or change your project to target .NET 5 or earlier.

## See also

* [Overview of .NET, MSBuild, and Visual Studio versioning](../../porting/versioning-sdk-msbuild-vs.md)
