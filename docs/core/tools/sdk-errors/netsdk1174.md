---
title: "NETSDK1174: -p abbreviation for --project in dotnet run is deprecated"
description: -p abbreviation for --project in dotnet run is deprecated.
author: tdykstra
ms.author: tdykstra
ms.topic: error-reference
ms.date: 07/14/2021
f1_keywords:
- NETSDK1174
---
# NETSDK1174: -p abbreviation for --project in dotnet run is deprecated

The full error message is similar to the following example:

> The abbreviation of -p for --project is deprecated. Please use --project.

The use of `-p` in `dotnet run` is deprecated because of the close relationship `dotnet run` has with `dotnet build` and `dotnet publish`. In `dotnet build` and `dotnet publish`, `p` is used to set MSBuild properties. This deprecation is the first step in aligning abbreviations for these three commands.

For more information, see [`-p` option for `dotnet run` is deprecated](../../compatibility/sdk/6.0/deprecate-p-option-dotnet-run.md).
