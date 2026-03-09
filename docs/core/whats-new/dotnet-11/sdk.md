---
title: What's new in the SDK and tooling for .NET 11
description: Learn about the new .NET SDK features introduced in .NET 11.
titleSuffix: ""
ms.date: 02/10/2026
ai-usage: ai-generated
ms.update-cycle: 3650-days
---

# What's new in the SDK and tooling for .NET 11

This article describes new features and enhancements in the .NET SDK for .NET 11. It was last updated for Preview 1.

## Breaking changes

.NET 11 includes the following breaking change in the SDK:

### Mono launch target no longer set automatically

Starting in .NET 11, the .NET SDK no longer automatically sets `mono` as the launch target for .NET Framework apps on Linux. If you rely on Mono for execution, update your launch configuration to specify `mono` explicitly.

For more information, see [Mono launch target no longer set automatically](../../compatibility/sdk/11/mono-launch-target-removed.md).

## See also

- [What's new in the .NET 11 runtime](runtime.md)
- [What's new in .NET libraries for .NET 11](libraries.md)
- [Breaking changes in .NET 11](../../compatibility/11.md)
