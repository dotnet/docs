---
title: Microsoft.Testing.Platform diagnostics overview
description: Learn about the diagnostics in Microsoft.Testing.Platform.
author: Evangelink
ms.author: amauryleve
ms.date: 05/30/2024
---

# Microsoft Testing Platform diagnostics overview

Microsoft Testing platform analysis ("TPXXX") rules inspect your code for security, performance, design and other issues.

## TPEXP

Several APIs of Microsoft Testing Platform are decorated with the <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute>. This attribute indicates that the API is experimental and may be removed or changed in future versions of Microsoft Testing Platform. The attribute is used to identify APIs that aren't yet stable and may not be suitable for production use.

To suppress this diagnostic with the `SuppressMessageAttribute`, add the following code to your project:

```csharp
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("TPEXP", "Justification")]
```

Alternatively, you can suppress this diagnostic with preprocessor directive by adding the following code to your project:

```csharp
#pragma warning disable TPEXP
        // API that is causing the warning.
#pragma warning restore TPEXP
```
