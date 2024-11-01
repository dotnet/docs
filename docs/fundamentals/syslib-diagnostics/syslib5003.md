---
title: SYSLIB5003 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB5003.
ms.date: 11/01/2024
f1_keywords:
  - syslib5003
---

# SYSLIB5003: SVE is a preview feature can be used by enabling EnablePreviewFeatures flag

In .NET 9, the first set of non-streaming SVE APIs were introduced and annotated with the <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute>. This indicates that both the internal implementation and the generated code for SVE may undergo changes. This includes potential modifications to method signatures, parameters, or namespaces in future updates, aimed at ensuring robust support for upcoming SVE technologies and streaming SVE designs. If you are using these APIs in your project, the `SYSLIB5003` diagnostic will need to be suppressed.

To suppress the warnings in a project file:

```xml
<PropertyGroup>
   <!-- SYSLIB50003: System.Runtime.Intrinsics.Arm.Sve is experimental -->
   <NoWarn>$(NoWarn);SYSLIB5003</NoWarn>
</PropertyGroup>

## See also

- [Future work](https://devblogs.microsoft.com/dotnet/engineering-sve-in-dotnet/#8.-future)
