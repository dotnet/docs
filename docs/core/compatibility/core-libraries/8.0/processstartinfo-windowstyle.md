---
title: ".NET 8 breaking change: ProcessStartInfo.WindowStyle honored when UseShellExecute is false"
description: Learn about the .NET 8 breaking change in core .NET libraries where ProcessStartInfo.WindowStyle is now honored even when UseShellExecute is false.
ms.date: 11/08/2023
---
# ProcessStartInfo.WindowStyle honored when UseShellExecute is false

Previously, <xref:System.Diagnostics.ProcessStartInfo.WindowStyle?displayName=nameWithType> was only honored when <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute?displayName=nameWithType> was `true`. This change honors <xref:System.Diagnostics.ProcessStartInfo.WindowStyle> even when <xref:System.Diagnostics.ProcessStartInfo.UseShellExecute> is `false`.

## Previous behavior

Prior to this change, the following code started the process as though <xref:System.Diagnostics.ProcessStartInfo.WindowStyle> hadn't been specified, because `UseShellExecute = false`. That is, the window was visible, not hidden.

```csharp
using System.Diagnostics;

ProcessStartInfo startInfo = new()
{
    FileName = @"C:\Windows\System32\notepad.exe",
    UseShellExecute = false,
    WindowStyle = ProcessWindowStyle.Hidden
};

var process = Process.Start(startInfo);
process!.WaitForExit();
```

## New behavior

Starting in .NET 8, <xref:System.Diagnostics.ProcessStartInfo.WindowStyle> is honored even for processes started with `UseShellExecute = false`.

The code from the [Previous behavior](#previous-behavior) section starts the process with the window hidden.

## Version introduced

.NET 8 Preview 6

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Some scenarios require changing the style of the spawned process's window (especially to hide it).

## Recommended action

This change affects code that specified <xref:System.Diagnostics.ProcessStartInfo.WindowStyle> even when it wasn't properly supported. For example, WPF's order of event firing is now altered. To mitigate the breaking change, don't specify `WindowStyle` in <xref:System.Diagnostics.ProcessStartInfo>.

## Affected APIs

- <xref:System.Diagnostics.Process.Start%2A?displayName=fullName>
