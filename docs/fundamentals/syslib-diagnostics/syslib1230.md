---
title: SYSLIB1230 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB1230.
ms.date: 10/08/2024
f1_keywords:
  - syslib1230
---

# SYSLIB1230: Deriving from a `GeneratedComInterface`-attributed interface defined in another assembly is not supported

In .NET 9 and later versions, defining an interface with the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> attribute that derives from a `GeneratedComInterface`-attributed interface that's defined in another assembly is supported with the following restrictions:

- The base interface type must be compiled targeting the same framework as the derived type.
- The base interface type must not shadow any members of its base interface, if it has one.

Additionally, any changes to any generated virtual method offsets in the base interface chain defined in another assembly won't be accounted for in the derived interfaces until the project is rebuilt.

When you define an interface with the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> attribute that derives from a `GeneratedComInterface`-attributed interface that's defined in another assembly, the SYSLIB1230 warning is emitted to inform you of the limitations. To acknowledge the limitations, suppress the warning in code as follows:

```csharp
// Disable the warning.
#pragma warning disable SYSLIB1230
[GeneratedComInterface]
interface IDerived : IBaseInOtherAssembly
// Re-enable the warning.
#pragma warning restore SYSLIB1230
{
    // the interface definition
}
```

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]

## See also

- [SYSLIB diagnostics for COM interop source generation](syslib-cominterfacegenerator.md)
