---
title: "Breaking change: ToolTip.AutoPopDelay behavior differs on Windows 11"
description: "Learn about the breaking change in .NET 8 where ToolTip.AutoPopDelay behavior differs between Windows 10 and Windows 11."
ms.date: 01/29/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/49838
---
# ToolTip.AutoPopDelay behavior differs on Windows 11

The behavior of <xref:System.Windows.Forms.ToolTip.AutoPopDelay> differs between Windows 10 and Windows 11. On Windows 10, the maximum effective value is 5000 milliseconds, but on Windows 11, there's no such limit and the default value can result in infinite tooltips.

## Version introduced

.NET 8

## Previous behavior

On Windows 10, the <xref:System.Windows.Forms.ToolTip.AutoPopDelay?displayProperty=nameWithType> property had the following behavior:

- The default value caused tooltips to disappear after a set duration (not infinite).
- The maximum effective value was limited to 5000 milliseconds. Setting a value greater than 5000 ms had no additional effect; the tooltip would still disappear after 5000 ms.

## New behavior

On Windows 11, the <xref:System.Windows.Forms.ToolTip.AutoPopDelay?displayProperty=nameWithType> property behaves differently:

- The default value causes tooltips to remain visible indefinitely (infinite tooltip display).
- When set to a non-default value, the tooltip displays for the specified duration without a 5000 ms limitation.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change is due to underlying differences in how Windows 10 and Windows 11 handle tooltip display timing. The behavior reflects the native Windows behavior on each platform rather than being enforced by .NET itself.

## Recommended action

If your application relies on consistent tooltip behavior across different Windows versions, consider explicitly setting the <xref:System.Windows.Forms.ToolTip.AutoPopDelay> property to a specific value rather than relying on the default behavior.

```csharp
// Ensure consistent behavior across Windows versions
ToolTip toolTip = new ToolTip();
toolTip.AutoPopDelay = 5000; // Set explicit 5-second timeout
```

For applications that need to detect the Windows version and adjust behavior accordingly:

```csharp
ToolTip toolTip = new ToolTip();

// Check Windows version and set appropriate delay
if (Environment.OSVersion.Version.Major >= 10 && 
    Environment.OSVersion.Version.Build >= 22000) // Windows 11
{
    // On Windows 11, set explicit timeout to avoid infinite display
    toolTip.AutoPopDelay = 5000;
}
// On Windows 10, default behavior or explicit setting as needed
```

## Affected APIs

- <xref:System.Windows.Forms.ToolTip.AutoPopDelay?displayProperty=fullName>
