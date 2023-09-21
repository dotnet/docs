---
title: "Breaking change: Anchor layout changes"
description: Learn about the breaking change in .NET 8 for Windows Forms where anchor layout computations have been changed to support high DPI devices.
ms.date: 01/19/2023
---
# Anchor layout changes

Control anchor computations have been changed to support high DPI devices. For more information about the changes, see [Anchor layout changes in .NET 8](https://github.com/dotnet/winforms/blob/main/docs/design/anchor-layout-changes-in-net80.md).

## Version introduced

.NET 8 Preview 1

## Previous behavior

Certain applications using <xref:System.Windows.Forms.HighDpiMode.SystemAware?displayProperty=nameWithType> or <xref:System.Windows.Forms.HighDpiMode.PerMonitorV2?displayProperty=nameWithType> mode and anchored controls encountered layout issues on high DPI devices.

## New behavior

Applications using <xref:System.Windows.Forms.HighDpiMode.SystemAware?displayProperty=nameWithType> or <xref:System.Windows.Forms.HighDpiMode.PerMonitorV2?displayProperty=nameWithType> mode and anchored controls should have improved layout when rendered on high DPI devices.

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change).

## Reason for change

This change is part of a broader effort to improve the Windows Forms user experience on high DPI monitors. It enables developers to use an anchored layout for applications on high DPI devices.

## Recommended action

If the new behavior is problematic for you, you can opt out by setting `System.Windows.Forms.AnchorLayoutV2` to `false` in your *runtimeconfig.json* file.

*runtimeconfig.template.json* template file:

```json
{
   "configProperties": {
      "System.Windows.Forms.AnchorLayoutV2": false
   }
}
```

*[appname].runtimeconfig.json* output file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.Windows.Forms.AnchorLayoutV2": false
      }
   }
}
```

## Affected APIs

N/A

## See also

- [Anchor layout changes in .NET 8](https://github.com/dotnet/winforms/blob/main/docs/design/anchor-layout-changes-in-net80.md)
