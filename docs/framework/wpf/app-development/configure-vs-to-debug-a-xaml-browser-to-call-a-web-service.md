---
title: "How to: Configure Visual Studio to Debug a XAML Browser Application to Call a Web Service"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "debugging XBAPs that call a Web service [WPF]"
  - "debugging security exceptions for XBAPs [WPF]"
  - "security exception for XBAPs [WPF], debugging"
  - "configuring Visual Studio to debug XAML browser applications [WPF]"
  - "configuring Visual Studio to debug XBAPs [WPF]"
ms.assetid: fd1db082-a7bb-4c4b-9331-6ad74a0682d0
---
# How to: Configure Visual Studio to Debug a XAML Browser Application to Call a Web Service
[!INCLUDE[TLA#tla_xbap#plural](../../../../includes/tlasharptla-xbapsharpplural-md.md)] run within a partial-trust security sandbox that is restricted to the Internet zone set of permissions. This permission set restricts Web service calls to only Web services that are located at the [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] application's site of origin. When an [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] is debugged from Visual Studio 2005, though, it is not considered to have the same site of origin as the Web service it references. This causes security exceptions to be raised when the [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] attempts to call the Web service. However, a Visual Studio 2005 [!INCLUDE[TLA#tla_wpfbrowserappproj](../../../../includes/tlasharptla-wpfbrowserappproj-md.md)] project can be configured to simulate having the same site of origin as the Web service it calls while debugging. This allows the [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] to safely call the Web service without causing security exceptions.

## Configuring Visual Studio
 To configure Visual Studio 2005 to debug an [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] that calls a Web service:

1. With a project selected in **Solution Explorer**, on the **Project** menu, click **Properties**.

2. In the **Project Designer**, click the **Debug** tab.

3. In the **Start Action** section, select **Start external program** and enter the following:

     `C:\WINDOWS\System32\PresentationHost.exe`

4. In the **Start Options** section, enter the following into the **Command line arguments** text box:

     `-debug`  *filename*

     The *filename* value for the **-debug** parameter is the .xbap filename; for example:

     `-debug c:\example.xbap`

> [!NOTE]
> This is the default configuration for solutions that are created with the Visual Studio 2005 [!INCLUDE[TLA#tla_wpfbrowserappproj](../../../../includes/tlasharptla-wpfbrowserappproj-md.md)] project template.

1. With a project selected in **Solution Explorer**, on the **Project** menu, click **Properties**.

2. In the **Project Designer**, click the **Debug** tab.

3. In the **Start Options** section, add the following command-line parameter to the **Command line arguments** text box:

     `-debugSecurityZoneURL`  *URL*

     The *URL* value for the **-debugSecurityZoneURL** parameter is the URL for the location that you want to simulate as being the site of origin of your application.

 As an example, consider a [!INCLUDE[TLA#tla_xbap](../../../../includes/tlasharptla-xbap-md.md)] that uses a Web service with the following URL:

 `http://services.msdn.microsoft.com/ContentServices/ContentService.asmx`

 The site of origin URL for this Web service is:

 `http://services.msdn.microsoft.com`

 Consequently, the complete **-debugSecurityZoneURL** command-line parameter and value is:

 `-debugSecurityZoneURL http://services.msdn.microsoft.com`

## See also

- [WPF Host (PresentationHost.exe)](wpf-host-presentationhost-exe.md)
