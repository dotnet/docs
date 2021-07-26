---
title: ".NET 6 breaking change: New diagnostic IDs for obsoleted APIs"
description: Learn about the .NET 6 preview-to-preview breaking change where the diagnostic ID for some obsoletions was changed.
ms.date: 06/22/2021
---
# New diagnostic IDs for obsoleted APIs

During early .NET 6 previews, a few APIs were obsoleted without using custom diagnostic IDs. Starting in .NET 6 Preview 5, those APIs report as obsolete using different, custom diagnostic IDs. If you suppressed warnings for usage of those APIs through [CS0618](../../../../csharp/language-reference/compiler-messages/cs0618.md), modify the suppressions to use the new diagnostic IDs, which are  [SYSLIB0019](../../../../fundamentals/syslib-diagnostics/syslib0019.md) and [SYSLIB0020](../../../../fundamentals/syslib-diagnostics/syslib0020.md).

## Change description

The following table shows the old and new diagnostic IDs for the listed obsolete API.

| API | Previous diagnostic ID | New diagnostic ID |
| --- | ---------------------- | ----------------- |
| <xref:System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile?displayProperty=nameWithType> | CS0618 | SYSLIB0019 |
| <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(System.Guid,System.Guid)?displayProperty=nameWithType> | CS0618 | SYSLIB0019 |
| <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsObject(System.Guid,System.Guid)?displayProperty=nameWithType> | CS0618 | SYSLIB0019 |
| <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues?displayProperty=nameWithType> | CS0618 | SYSLIB0020 |

## Version introduced

.NET 6 Preview 5

## Reason for change

Starting in .NET 5, obsoletions are intended to use custom diagnostic ID values to allow fine-grained suppression of the warnings. This yields a better experience when the obsolete APIs need to remain referenced. The obsoletions affected here should have had custom diagnostic ID values applied when the APIs were originally marked as `[Obsolete]`.

## Recommended action

If the SYSLIB0019 or SYSLIB0020 diagnostic IDs are produced from your build, review the usage of the affected APIs. If possible, avoid using those APIs and refer to the messages and documentation for alternatives. If you need to retain the references to the obsolete APIs and you need to suppress the diagnostics, use the new diagnostic IDs instead of [CS0618](../../../../csharp/language-reference/compiler-messages/cs0618.md).

## Affected APIs

- <xref:System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(System.Guid,System.Guid)?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsObject(System.Guid,System.Guid)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues?displayProperty=fullName>

## See also

- [SYSLIB0019: Some RuntimeEnvironment APIs are obsolete](../../../../fundamentals/syslib-diagnostics/syslib0019.md)
- [SYSLIB0020: IgnoreNullValues is obsolete](../../../../fundamentals/syslib-diagnostics/syslib0020.md)
- [CS0618](../../../../csharp/language-reference/compiler-messages/cs0618.md)

<!--

### Category

- Core .NET libraries

-->
