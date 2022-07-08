---
title: "NETSDK1112: The runtime pack was not downloaded"
description: How to resolve the `runtime pack was not downloaded' error message.
author: tdykstra
ms.author: tdykstra
ms.topic: error-reference
ms.date: 07/08/2022
f1_keywords:
- NETSDK1112
---
# NETSDK1112: The runtime pack was not downloaded

A runtime pack that your project requires was not downloaded. The full error message is similar to the following example:

> The runtime pack for `<Runtime>` was not downloaded. Try running a NuGet restore with the RuntimeIdentifier '`<RID>`'.

This can happen in the following scenarios:

* You tried to publish without building first and so the runtime pack was not available. Try running `dotnet build` before running `dotnet publish`.
* You used Debug configuration to build an app that is set up to require Release configuration. Try building with Release configuration.
