---
title: "NETSDK1112: The runtime pack was not downloaded"
description: How to resolve the `runtime pack was not downloaded' error message.
ms.topic: error-reference
ms.date: 07/08/2022
f1_keywords:
- NETSDK1112
---
# NETSDK1112: The runtime pack was not downloaded

A runtime pack that your project requires was not downloaded. The full error message is similar to the following example:

> The runtime pack for `<Runtime>` was not downloaded. Try running a NuGet restore with the RuntimeIdentifier '`<RID>`'.

This can happen in the following scenarios:

* The publish parameters are different than what's in the project file. Review publish parameters and change any instances where publish parameters differ from the project file.
* You used Debug configuration to build an app that is set up to require Release configuration. Try building with Release configuration.
