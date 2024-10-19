---
title: Experimental features in .NET 9+
titleSuffix: ""
description: Learn about APIs that are marked as experimental in .NET 9 and later versions that produce SYSLIB compiler warnings.
ms.date: 10/21/2024
---

# Experimental features in .NET 9+

Starting in .NET 9, some features make use of the <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute> to indicate that the API shape or functionality is included in the release but not yet officially supported. Experimental features offer the opportunity to collect feedback on the API shape and functionality with the intent of refining the APIs and removing the `[Experimental]` attribute in the next major release.

When an experimental API is referenced, the compiler will produce an error. Each feature that is marked as experimental has a unique diagnostic ID. To express consent to using them, you suppress the specific diagnostic. You can do that via any of the means for suppressing diagnostics, but the recommended way is to add the diagnostic to the project's `<NoWarn>` property. For more information, see [Suppress warnings](#suppress-warnings).

Since each experimental feature has a separate ID, consenting to using one experimental feature doesn't consent to using another.

## Reference

The following table provides an index to the `SYSLIB5XXX` experimental APIs in .NET 9+.

| Diagnostic ID | Experimental Versions | Description |
| - | - | - |
| SYSLIB5001 | .NET 9 | <xref:System.Numerics.Tensors.Tensor%601> and related APIs in <xref:System.Numerics.Tensors> are experimental |
| SYSLIB5002 | .NET 9 | <xref:System.Drawing.SystemColors> alternate colors are experimental |
| SYSLIB5003 | .NET 9 | <xref:System.Runtime.Intrinsics.Arm.Sve> is experimental |
| SYSLIB5004 | .NET 9 | <xref:System.Runtime.Intrinsics.X86.X86Base.DivRem> is experimental since performance is not as optimized as `T.DivRem` |
| SYSLIB5005 | .NET 9 | <xref:System.Formats.Nrbf> is experimental |


## Suppress warnings

Using an experimental feature offers the opportunity to submit feedback on the API shape and functionality before the feature is marked as stable and fully supported, but using the feature will produce a warning from the compiler. Suppressing the warning acknowledges that the API shape or functionality might change in the next major release. The warning can be suppressed through a `#pragma` directive in code or a `<NoWarn>` project setting.

To suppress the warnings in code:

```csharp
// Disable the warning.
#pragma warning disable SYSLIB5001

// Code that uses an experimental API that produces the diagnostic SYSLIB5001
//...

// Re-enable the warning.
#pragma warning restore SYSLIB5001
```

To suppress the warnings in a project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   <TargetFramework>net9.0</TargetFramework>
   <!-- NoWarn below suppresses SYSLIB5001 project-wide -->
   <NoWarn>$(NoWarn);SYSLIB5001</NoWarn>
   <!-- To suppress multiple warnings, you can use multiple NoWarn elements -->
   <NoWarn>$(NoWarn);SYSLIB5002</NoWarn>
   <NoWarn>$(NoWarn);SYSLIB5003</NoWarn>
   <!-- Alternatively, you can suppress multiple warnings by using a semicolon-delimited list -->
   <NoWarn>$(NoWarn);SYSLIB5001;SYSLIB5002;SYSLIB5003</NoWarn>
  </PropertyGroup>
</Project>
```

## See also

- [Preview APIs](../../../fundamentals/apicompat/preview-apis.md)
