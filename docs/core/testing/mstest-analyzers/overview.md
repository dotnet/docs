---
title: MSTest code analysis
description: Learn about the MSTest code analysis.
author: evangelink
ms.author: amauryleve
ms.date: 12/20/2023
---

# MSTest code analysis

*MSTest analysis* ("MSTESTxxxx") rules inspect your C# or Visual Basic code for security, performance, design and other issues.

> [!TIP]
> If you're using Visual Studio, many analyzer rules have associated *code fixes* that you can apply to correct the problem. Code fixes are shown in the light bulb icon menu.

The rules are organized into categories such as performance usage...

## Categories

### Design rules

[Design rules](design-rules.md) will help you create and maintain test suites that adhere to proper design and good practices.

### Performance rules

[Performance rules](performance-rules.md) support high-performance testing.

### Suppression rules

[Suppression rules](suppression-rules.md) support suppressing diagnostics from other rules.

### Usage rules

[Usage rules](usage-rules.md) support proper usage of MSTest.

### MSTESTEXP

Several APIs of MSTest are decorated with the <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute>. This attribute indicates that the API is experimental and may be removed or changed in future versions of MSTest. The attribute is used to identify APIs that aren't yet stable and may not be suitable for production use.

To suppress this diagnostic with the `SuppressMessageAttribute`, add the following code to your project:

```csharp
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("MSTESTEXP", "Justification")]
```

Alternatively, you can suppress this diagnostic with preprocessor directive by adding the following code to your project:

```csharp
#pragma warning disable MSTESTEXP
        // API that is causing the warning.
#pragma warning restore MSTESTEXP
```
