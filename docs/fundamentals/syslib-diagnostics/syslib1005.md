---
title: SYSLIB1005 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1005.
ms.date: 05/07/2021
---

# SYSLIB1005: Could not find a required type definition

The code generator was unable to find a necessary reference to a well-known type.

## Workarounds

This error is highly unlikely to occur. If it does occur, you can consider adding a `<PackageReference>` to your project file to include the required type definition.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
