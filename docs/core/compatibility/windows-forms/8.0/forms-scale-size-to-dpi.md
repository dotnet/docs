---
title: "Breaking change: Top-level forms scale to DPI"
description: Learn about the breaking change in .NET 8 for Windows Forms where top-level forms scale their minimum and maximum size values according to the DPI of the monitor.
ms.date: 01/19/2023
---
# Top-level forms scale minimum and maximum size to DPI

Top-level forms in Windows Forms now scale their <xref:System.Windows.Forms.Form.MinimumSize> and <xref:System.Windows.Forms.Form.MaximumSize> values according to the dots per inch (DPI) of the monitor when running in <xref:System.Windows.Forms.HighDpiMode.PerMonitorV2?displayProperty=nameWithType> mode.

## Version introduced

.NET 8 Preview 1

## Previous behavior

In .NET 8, the <xref:System.Windows.Forms.Form.MinimumSize> and <xref:System.Windows.Forms.Form.MaximumSize> values for top-level forms remained constant regardless of the application DPI mode and the DPI of the monitor where the form is rendered. This sometimes resulted in scaling limitations of the top-level form.

You can also opt in to this behavior in .NET 7. To opt in, set the `System.Windows.Forms.ScaleTopLevelFormMinMaxSizeForDpi` runtime configuration option described in the [Recommended action](#recommended-action) section.

## New behavior

Starting in .NET 8, top-level forms scale their <xref:System.Windows.Forms.Form.MinimumSize> and <xref:System.Windows.Forms.Form.MaximumSize> values according to the DPI of the monitor when running in <xref:System.Windows.Forms.HighDpiMode.PerMonitorV2?displayProperty=nameWithType> mode. The behavior of your app might change in the following ways:

- Run-time dependencies might be impacted when the minimum and maximum size of the form change.
- New <xref:System.Windows.Forms.Form.MinimumSizeChanged> and <xref:System.Windows.Forms.Form.MaximumSizeChanged> events might be raised.
- The scaled form size now has new constraint values for the minimum and maximum sizes.

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change).

## Reason for change

This change is part of a broader effort to improve the Windows Forms user experience on high DPI monitors. It enables developers to set minimum and maximum sizes for top-Level forms without having to take the DPI of the monitor into account.

## Recommended action

If the new behavior is problematic for you, you can opt out by setting `System.Windows.Forms.ScaleTopLevelFormMinMaxSizeForDpi` to `false` in your *runtimeconfig.json* file.

*runtimeconfig.template.json* template file:

```json
{
   "configProperties": {
      "System.Windows.Forms.ScaleTopLevelFormMinMaxSizeForDpi": false
   }
}
```

*[appname].runtimeconfig.json* output file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.Windows.Forms.ScaleTopLevelFormMinMaxSizeForDpi": false
      }
   }
}
```

## Affected APIs

N/A

## See also

- [Forms scale according to AutoScaleMode](top-level-window-scaling.md)
