---
title: SYSLIB5003 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB5003.
ms.date: 11/01/2024
f1_keywords:
  - syslib5003
---

# SYSLIB5003: SVE is a preview feature can be used by enabling EnablePreviewFeatures flag

In .NET 9, the first set of non-streaming SVE APIs were introduced and annotated with the <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute>. This attribute indicates that both the internal implementation and the generated code for SVE might undergo changes. These potential changes include modifications to method signatures, parameters, or namespaces in future updates, aimed at ensuring robust support for upcoming SVE technologies and streaming SVE designs. If you're using these APIs in your project, you'll need to suppress the `SYSLIB5003` diagnostic.

To suppress the warnings in a project file:

```xml
<PropertyGroup>
   <!-- SYSLIB50003: System.Runtime.Intrinsics.Arm.Sve is experimental -->
   <NoWarn>$(NoWarn);SYSLIB5003</NoWarn>
</PropertyGroup>
```

## See also

- [Experimental features](experimental-overview.md)
- [Future work](https://devblogs.microsoft.com/dotnet/engineering-sve-in-dotnet/#8.-future)
