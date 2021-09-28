---
title: "Mitigation: Pointer-based Touch and Stylus Support"
description: Learn about the effects of enabling an optional WPF touch/stylus stack for WPF apps that target .NET Framework 4.7.
ms.date: "04/07/2017"
helpviewer_keywords:
  - "retargeting changes"
  - ".NET Framework 4.7 retargeting changes"
  - "WPF retargeting changes"
  - "WPF pointer-based touch and stylus stack"
ms.assetid: f99126b5-c396-48f9-8233-8f36b4c9e717
---
# Mitigation: Pointer-based Touch and Stylus Support

WPF applications that target the .NET Framework 4.7 and are running on Windows starting with Windows 10 Creators Update can enable an optional `WM_POINTER`-based WPF touch/stylus stack.

## Impact

Developers who do not explicitly enable pointer-based touch/stylus support should see no change in WPF touch/stylus behavior.

The following are current known issues with the optional `WM_POINTER`-based touch/stylus stack:

- No support for real-time inking.

   While inking and stylus plugins still work, they are processed on the UI thread, which can lead to poor performance.

- Behavioral changes due to changes in promotion from touch/stylus events to mouse events.

  - Manipulation may behave differently.

  - Drag/Drop will not show appropriate feedback for touch input. (This does not affect stylus input.)

  - Drag/Drop can no longer be initiated on touch/stylus events.

      This can potentially cause the application to become unresponsive until mouse input is detected. Instead, developers should initiate drag and drop from mouse events.

## Opting in to WM_POINTER-based touch/stylus support

Developers who wish to enable this stack can add the following to their application's *app.config* file.

```xml
<configuration>
    <runtime>
        <AppContextSwitchOverrides value="Switch.System.Windows.Input.Stylus.EnablePointerSupport=true"/>
    </runtime>
</configuration>
```

Removing this entry or setting its value to `false` turns this optional stack off.

## See also

- [Application compatibility](application-compatibility.md)
