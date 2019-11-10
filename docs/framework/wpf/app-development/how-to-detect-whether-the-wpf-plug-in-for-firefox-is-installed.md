---
title: "How to: Detect Whether the WPF Plug-In for Firefox Is Installed"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "plug-in for Firefox [WPF]"
  - "detecting Firefox installation [WPF]"
  - "checking for the Firefox plug-in [WPF]"
  - "Firefox [WPF], detecting installation"
  - "detecting whether the WPF plug-in for Firefox is installed [WPF]"
ms.assetid: 5f839373-e3fb-44f1-88ad-4a0761f02189
---

# How to: Detect Whether the WPF Plug-In for Firefox Is Installed

The Windows Presentation Foundation (WPF) plug-in for Firefox enables XAML browser applications (XBAPs) and loose XAML files to run in the Mozilla Firefox browser. This topic provides a script written in HTML and JavaScript that administrators can use to determine whether the WPF plug-in for Firefox is installed.

> [!NOTE]
> For more information about installing, deploying, and detecting the .NET Framework, see [Install the .NET Framework for developers](../../install/guide-for-developers.md).

## Example

When the .NET Framework 3.5 is installed, the client computer is configured with a WPF plug-in for Firefox. The following example script checks for the WPF plug-in for Firefox and then displays an appropriate status message.

```html
<HTML>

  <HEAD>
    <TITLE>Test for the WPF plug-in for Firefox</TITLE>
    <META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8" />
    <SCRIPT type="text/javascript">
    <!--
    function OnLoad()
    {

       // Check for the WPF plug-in for Firefox and report
       var msg = "The WPF plug-in for Firefox is ";
       var wpfPlugin = navigator.plugins["Windows Presentation Foundation"];
       if( wpfPlugin != null ) {
          document.writeln(msg + " installed.");
       }
       else {
          document.writeln(msg + " not installed. Please install or reinstall the .NET Framework 3.5.");
       }
    }
    -->
    </SCRIPT>
  </HEAD>

  <BODY onload="OnLoad()" />

</HTML>
```

If the check for the WPF plug-in for Firefox is successful, the following status message is displayed:

`The WPF plug-in for Firefox is installed.`

Otherwise, the following status message is displayed:

`The WPF plug-in for Firefox is not installed. Please install or reinstall the .NET Framework 3.5.`

## See also

- [Detect Whether the .NET Framework 3.0 Is Installed](how-to-detect-whether-the-net-framework-3-0-is-installed.md)
- [Detect Whether the .NET Framework 3.5 Is Installed](how-to-detect-whether-the-net-framework-3-5-is-installed.md)
- [WPF XAML Browser Applications Overview](wpf-xaml-browser-applications-overview.md)
