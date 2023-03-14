---
title: "Breaking change: .NET 8 obsoletions and warnings in Windows Forms"
titleSuffix: ""
description: Learn about the .NET 8 breaking change where some Windows Forms APIs have been marked as obsolete or otherwise produce a warning.
ms.date: 03/13/2023
---
# Windows Forms obsoletions and warnings (.NET 8)

Some Windows Forms APIs have been marked as obsolete, starting in .NET 8.

## Previous behavior

In previous .NET versions, these APIs can be used without any build warning.

## New behavior

In .NET 8 and later versions, use of these APIs produces a compile-time warning or error with a custom diagnostic ID. The use of custom diagnostic IDs allows you to suppress the warnings individually instead of blanket-suppressing all obsoletion warnings.

The following table lists the custom diagnostic IDs and their corresponding warning messages.

| Diagnostic ID | Description | Severity | Version introduced |
| - | - |
| [WFDEV004](/dotnet/desktop/winforms/wfdev-diagnostics/wfdev004) | `ListBox.DefaultItemHeight` constant is no longer used as the default item height. Default item height is now scaled according to the application default font. | Warning | Preview 2 |

## Version introduced

.NET 8

## Type of breaking change

These obsoletions and warnings can affect [source compatibility](../../categories.md#source-compatibility).

## Recommended action

- Follow the specific guidance provided for the each diagnostic ID using the URL link provided on the warning.
- If necessary, you can suppress the warning using the custom `WFDEVxxx` diagnostic ID value.

## Affected APIs

### WFDEV004

- <xref:System.Windows.Forms.ListBox.DefaultItemHeight?displayProperty=fullName>

## See also

- [Obsolete Windows Forms features in .NET 7+](/dotnet/desktop/winforms/wfdev-diagnostics/obsoletions-overview)
