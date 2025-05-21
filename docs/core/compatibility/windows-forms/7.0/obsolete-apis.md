---
title: "Breaking change: .NET 7 obsoletions and warnings in Windows Forms"
titleSuffix: ""
description: Learn about the .NET 7 breaking change where some Windows Forms APIs have been marked as obsolete or otherwise produce a warning.
ms.date: 09/09/2022
ms.topic: concept-article
---
# Windows Forms obsoletions and warnings (.NET 7)

Some Windows Forms APIs have been marked as obsolete, starting in .NET 7. Other APIs aren't obsolete but will cause a compile-time warning if you reference them.

## Previous behavior

In previous .NET versions, these APIs can be used without any build warning.

## New behavior

In .NET 7 and later versions, use of these APIs produces a compile-time warning or error with a custom diagnostic ID. The use of custom diagnostic IDs allows you to suppress the warnings individually instead of blanket-suppressing all obsoletion warnings.

The following table lists the custom diagnostic IDs and their corresponding warning messages.

| Diagnostic ID | Description | Severity | Version introduced |
| - | - |
| [WFDEV001](/dotnet/desktop/winforms/wfdev-diagnostics/wfdev001) | Casting to/from <xref:System.IntPtr> is unsafe. Use `WParamInternal`, `LParamInternal`, or `ResultInternal` instead. | Warning | Preview 1 |
| [WFDEV002](/dotnet/desktop/winforms/wfdev-diagnostics/wfdev002) | <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject?displayProperty=nameWithType> is no longer used to provide accessible support for <xref:System.Windows.Forms.DomainUpDown> controls. Use <xref:System.Windows.Forms.AccessibleObject> instead. | Warning | RC 1 |
| [WFDEV003](/dotnet/desktop/winforms/wfdev-diagnostics/wfdev003) | <xref:System.Windows.Forms.DomainUpDown.DomainItemAccessibleObject?displayProperty=nameWithType> is no longer used to provide accessible support for <xref:System.Windows.Forms.DomainUpDown> items. Use <xref:System.Windows.Forms.AccessibleObject> instead. | Warning | RC 1 |

## Version introduced

.NET 7

## Type of breaking change

These obsoletions and warnings can affect [source compatibility](../../categories.md#source-compatibility).

## Recommended action

- Follow the specific guidance provided for the each diagnostic ID using the URL link provided on the warning.
- If necessary, you can suppress the warning using the custom `WFDEVxxx` diagnostic ID value.

## Affected APIs

### WFDEV001

- <xref:System.Windows.Forms.Message.WParam?displayProperty=fullName>
- <xref:System.Windows.Forms.Message.LParam?displayProperty=fullName>
- <xref:System.Windows.Forms.Message.Result?displayProperty=fullName>

### WFDEV002

- <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject?displayProperty=fullName>

### WFDEV003

- <xref:System.Windows.Forms.DomainUpDown.DomainItemAccessibleObject?displayProperty=fullName>

## See also

- [Obsolete Windows Forms features in .NET 7+](/dotnet/desktop/winforms/wfdev-diagnostics/obsoletions-overview)
