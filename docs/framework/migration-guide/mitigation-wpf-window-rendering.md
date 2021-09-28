---
title: "Mitigation: WPF Window Rendering"
description: Learn about the impact and mitigation for WPF window rendering in .NET Framework 4.6 running on Windows 8 or later.
ms.date: "03/30/2017"
ms.assetid: 28ed6bf8-141b-4b73-a4e3-44a99fae5084
---
# Mitigation: WPF Window Rendering

In the .NET Framework 4.6 running on Windows 8 and above, the entire window is rendered without clipping when it extends outside of single display in a multi-monitor scenario.

## Impact

In general, rendering an entire window across multiple monitors without clipping is the expected behavior. However, on Windows 7 and earlier versions, WPF windows are clipped when they extend beyond a single display because rendering a portion of the window on the second monitor has a significant performance impact.

The precise impact of rendering WPF windows across monitors on Windows 8 and above is not precisely quantifiable since it depends on a large number of factors. In some cases, it may still produce an undesirable impact on performance, particularly for users who run graphics-intensive applications and have windows straddling monitors. In other cases, you may simply want a consistent behavior across .NET Framework versions.

## Mitigation

You can disable this change and revert to the previous behavior of clipping a WPF window when it extends beyond a single display. There are two ways to do this:

- By adding the `<EnableMultiMonitorDisplayClipping>` element to the `<appSettings>` section of your application configuration file, you can disable or enable this behavior on apps running on Windows 8 or later. For example, the following configuration section disables rendering without clipping:

  ```xml
  <appSettings>
      <add key="EnableMultiMonitorDisplayClipping" value="true"/>
    </appSettings>
  ```

  The `<EnableMultiMonitorDisplayClipping>` configuration setting can have either of two values:

  - `true`, to enable clipping of windows to monitor bounds during rendering.

  - `false`, to disable clipping of windows to monitor bounds during rendering.

- By setting the <xref:System.Windows.CoreCompatibilityPreferences.EnableMultiMonitorDisplayClipping%2A> property to `true` at app startup.

## See also

- [Application compatibility](application-compatibility.md)
