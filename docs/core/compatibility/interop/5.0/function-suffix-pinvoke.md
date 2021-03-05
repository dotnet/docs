---
title: "Breaking change: No A/W suffix probing on non-Windows platforms"
description: Learn about the interop breaking change in .NET 5 where suffixes are no longer added to function export names during probing for P/Invokes on non-Windows platforms.
ms.date: 08/13/2020
---
# No A/W suffix probing on non-Windows platforms

The .NET runtimes no longer add an `A` or `W` suffix to function export names during probing for P/Invokes on non-Windows platforms.

## Version introduced

5.0

## Change description

[Windows has a convention](/windows/win32/intl/conventions-for-function-prototypes) of adding an `A` or `W` suffix to Windows SDK function names, which correspond to the Windows code page and Unicode versions, respectively.

In previous versions of .NET, both the CoreCLR and Mono runtimes add an `A` or `W` suffix to the export name during export discovery for P/Invokes *on all platforms*.

In .NET 5 and later versions, an `A` or `W` suffix is added to the export name during export discovery *on Windows only*. On Unix platforms, the suffix is not added. The semantics of both runtimes on the Windows platform remain unchanged.

## Reason for change

This change was made to simplify cross-platform probing. It's overhead that shouldn't be incurred, given that non-Windows platforms don't contain this semantic.

## Recommended action

To mitigate the change, you can manually add the desired suffix on non-Windows platforms. For example:

```csharp
[DllImport(...)]
extern static void SetWindowTextW();
```

## Affected APIs

- <xref:System.Runtime.InteropServices.DllImportAttribute?displayProperty=fullName>

<!--

### Affected APIs

- `T:System.Runtime.InteropServices.DllImportAttribute`

### Category

Interop

-->
