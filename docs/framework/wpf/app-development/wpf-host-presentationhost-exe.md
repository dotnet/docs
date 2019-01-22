---
title: "WPF Host (PresentationHost.exe)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "WPF Host application [WPF]"
  - "PresentationHost.exe"
ms.assetid: 3215bfa1-722c-4ac8-a7c5-bdd02d30afbd
---
# WPF Host (PresentationHost.exe)
Windows Presentation Foundation (WPF) Host (PresentationHost.exe) is the application that enables [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications to be hosted in compatible browsers (including [!INCLUDE[TLA#tla_ie6](../../../../includes/tlasharptla-ie6-md.md)] and later). By default, Windows Presentation Foundation (WPF) Host is registered as the shell and [!INCLUDE[TLA2#tla_mime](../../../../includes/tla2sharptla-mime-md.md)] handler for browser-hosted [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] content, which includes:  
  
-   Loose (uncompiled) [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] files (.xaml).  
  
-   [!INCLUDE[TLA#tla_xbap](../../../../includes/tlasharptla-xbap-md.md)] (.xbap).  
  
 For files of these types, Windows Presentation Foundation (WPF) Host:  
  
-   Launches the registered [!INCLUDE[TLA2#tla_html](../../../../includes/tla2sharptla-html-md.md)] handler to host the Windows Presentation Foundation (WPF) content.  
  
-   Loads the right versions of the required [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] and Windows Presentation Foundation (WPF) assemblies.  
  
-   Ensures the appropriate permission levels for the zone of deployment are in place.  
  
 This topic describes the command line parameters that can be used with PresentationHost.exe.  
  
## Usage  
 `PresentationHost.exe [parameters] uri|filename`  
  
## Parameters  
  
|Parameter|Description|  
|---------------|-----------------|  
|filename|The path of the file to be activated. Can also be a [!INCLUDE[TLA2#tla_uri](../../../../includes/tla2sharptla-uri-md.md)].|  
|-debug|When activating an application, does not commit it to or run it from the store. This only works when a local file is activated.|  
|-debugSecurityZoneURL \<url>|Used with a [!INCLUDE[TLA2#tla_url](../../../../includes/tla2sharptla-url-md.md)] value to indicate to PresentationHost.exe that an application should be debugged as if it were deployed from the specified [!INCLUDE[TLA2#tla_url](../../../../includes/tla2sharptla-url-md.md)]. This determines both the deployment zone and the site of origin.|  
|-embedding|Required by OLE. If the `-event` or `-debug` parameter are specified, it is not necessary to specify the `-embedding` parameter, since that parameter is set internally.|  
|-event \<eventname>|Open the event with this name and signal it when PresentationHost.exe is initialized and ready to host [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] content. PresentationHost.exe will terminate if there was an error opening the event, such as if it has not already been created.|  
|-launchApplication \<url>|Launches a standalone [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] application from the specified URL. [!INCLUDE[TLA2#tla_iegeneric](../../../../includes/tla2sharptla-iegeneric-md.md)] and WinINet security policy concerning .NET applications are applied.|  
  
## Scenarios  
  
### Shell Handler  
 `PresentationHost.exe example.xbap`  
  
### MIME Handler  
 `PresentationHost.exe -embedding example.xbap`  
  
### Visual Studio Debugging  
 `PresentationHost.exe -debug example.xbap`  
  
### Visual Studio Debugging In Zone  
 `PresentationHost.exe -debug -debugSecurityZoneURL http://www.example.com c:\folderpath\example.xbap`  
  
## See also
 [Security](../../../../docs/framework/wpf/security-wpf.md)
