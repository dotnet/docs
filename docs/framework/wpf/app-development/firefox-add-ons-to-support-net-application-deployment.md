---
title: "Firefox Add-ons to Support .NET Application Deployment"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Firefox add-ons for .NET application deployment"
  - "WPF plug-in for Firefox"
  - ".NET application deployment [WPF], deploying with Firefox add-ons"
  - ".NET Framework Assistant for Firefox"
ms.assetid: 2403403b-9b14-48e9-b70d-fa288a3c9081
---
# Firefox Add-ons to Support .NET Application Deployment
The Windows Presentation Foundation (WPF) plug-in for Firefox and the .NET Framework Assistant for Firefox enable XAML browser applications (XBAPs), loose [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], and ClickOnce applications to work with the Mozilla Firefox browser.  
  
## WPF Plug-in for Firefox  
 The WPF plug-in for Firefox enables XBAPs and loose [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] files to be navigated to and run at the top-level or in an HTML IFRAME in the Firefox browser. An XBAP is a WPF application that can be published to a Web server and launched within supported browsers. Loose [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] is a XAML-only file that can be navigated to and displayed in supported browsers, much like an XML file.  
  
 The WPF plug-in for Firefox is installed with the .NET Framework 3.5. Window 7 includes the .NET Framework 3.5, but does not include the WPF plug-in for Firefox. You cannot install the WPF plug-in for Firefox on Windows 7.  
  
 The .NET Framework 4 does not include the WPF plug-in for Firefox. However, if both the .NET Framework 3.5 and .NET Framework 4 are installed, the WPF plug-in for Firefox is installed with the .NET Framework 3.5. Therefore .NET Framework 4 applications will still run because the WPF Host will load the correct version of the framework. For more information, see [WPF Host (PresentationHost.exe)](wpf-host-presentationhost-exe.md).  
  
## .NET Framework Assistant for Firefox  
 The .NET Framework Assistant for Firefox enables stand-alone ClickOnce applications to run from the Firefox browser. The .NET Framework Assistant for Firefox functions identically when it is installed before and after the Firefox browser. When the Firefox browser is launched and the .NET Framework 3.5 SP1 is installed, Firefox finds and installs the .NET Framework Assistant for Firefox. Users can configure the .NET Framework Assistant for Firefox to do the following:  
  
- Prompt before running the ClickOnce application.  
  
- Report all installed versions of the .NET Framework or just the latest version.  
  
 The .NET Framework Assistant for Firefox is included with the .NET Framework 3.5 SP1. For information about removing the .NET Framework Assistant for Firefox, see [How to remove the .NET Framework Assistant for Firefox](https://go.microsoft.com/fwlink/?LinkId=177944).  
  
## See also

- [Deploying a WPF Application](deploying-a-wpf-application-wpf.md)
- [WPF XAML Browser Applications Overview](wpf-xaml-browser-applications-overview.md)
- [Detect Whether the WPF Plug-In for Firefox Is Installed](how-to-detect-whether-the-wpf-plug-in-for-firefox-is-installed.md)
