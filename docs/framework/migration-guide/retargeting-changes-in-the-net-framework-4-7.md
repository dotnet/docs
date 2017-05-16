---
title: "Retargeting Changes in the .NET Framework 4.7 | Microsoft Docs"
ms.custom: ""
ms.date: "04/07/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "retargeting changes,.NET Framework"
  - "retargeting changes,.NET Framework 4.7"
  - "application compatibility"
ms.assetid: d98bf1e3-0017-4933-8e7b-191ac3542fcc
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Retargeting Changes in the .NET Framework 4.7

In rare cases, retargeting changes may affect apps that are recompiled to target the .NET Framework 4.7. They do not affect binaries that target a previous version of the .NET Framework but are running under version 4.7. The .NET Framework 4.7 includes retargeting changes in the following areas:  

-   [Core](#Core)  
-   [ASP.NET](#asp) 
-   [Windows Communication Foundation (WCF)](#WCF)  
-   [Windows Presentation Foundation (WPF)](#WPF)
 
 The Scope column in the following tables specifies the significance of each change:  
  
-   Major. A significant change that affects a large number of apps or that requires substantial modification of code. Note that none of the retargeting changes fall into this category.  
  
-   Minor. A change that either affects a small number of apps or that requires minor modification of code.  
  
-   Edge. A change that affects apps under very specific scenarios that are not common.  
  
-   Transparent. A change that has no noticeable effect on the app's developer or user. The app should not require modification because of this change.  
  
## <a name="Core" /> Core

| Feature | Change | Impact | Scope |
|----|----|----|----|
|<xref:System.Security.Cryptography.CspParameters.ParentWindowHandle%2A> | Applications that target the .NET Framework 4.6.2 and earlier versions expect the value assigned to this property to be an <xref:System.IntPtr> to the specified location in memory where the HWND value resides.<br/></br>Starting with apps that target the .NET Framework 4.7, a Windows Forms application can set the value of this property with code like the following: <br/><br/>` cspParameters.ParentWindowHandle = form.Handle; ` | Apps that find this change of behavior inconvenient can opt out of the new behavior. Similarly, apps that target earlier versions of the .NET Framework but are running on the .NET Framework 4.7 can opt into the new behavior. For more information, see [Mitigation: CspParameters.ParentWindowHandle Expects an HWND](../../../docs/framework/migration-guide/mitigation-cspparameters-parentwindowhandle-expects-an-hwnd.md). | Minor |
| Serialization with the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> | Starting with apps that target the .NET Framework 4.7, the serialization of control characters with the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> is now compatible with ECMAScript V6 and V8 | This change conforms to the ECMAScript standard and should have little impact. If it does, a compatibility switch is available to restore the previous behavior. For more information, see [Mitigation: Serialization of Control Characters with the DataContractJsonSerializer](../../../docs/framework/migration-guide/mitigation-serialization-control-characters.md)  | Edge |

## <a name="asp" /> ASP.NET

| Feature  |Change  |Impact | Scope | 
---------|---------|---------|-----|
Throttle concurrent requests per session | In the .NET Framework 4.6.2 and earlier, ASP.NET executes requests with the same <xref:System.Web.SessionState.HttpSessionState.SessionID%2A> sequentially, and ASP.NET always issues the <xref:System.Web.SessionState.HttpSessionState.SessionID%2A> through a cookie by default. If a page takes long time to load, pressing <kbd>F5</kbd> of the browser significantly degrades server performance.<br/><br/>Starting with the .NET Framework 4.7, a counter tracks the queued requests and terminates the requests when they exceed a specified limit. The default value is 50. If the the limit is reached, a warning is logged in the event log, and an HTTP 500 response may be recorded in the IIS log.|This change can improve overall server performance.<br/><br/>To restore the old behavior, you can add the following setting to your web.config file to opt out of the new behavior.<br/><br/>`<appSettings>`<br/>&nbsp;&nbsp;&nbsp;`<add key="aspnet:RequestQueueLimitPerSession" value="2147483647"/>`<br/>`</appSettings>` | Edge |

## <a name="WCF" /> Windows Communication Foundation

| Feature  |Change  |Impact | Scope | 
---------|---------|---------|-----|
| WCF message security | Apps running under the .NET Framework 4.7 or later are able to use TLS 1.1 and TLS 1.2 in WCF message security through application configuration settings. This is an opt-in feature; by default, support for TLS 1.1 and TLS 1.2 in WCF message security are disabled. | The default behavior of WCF message security remains unchanged. <br/><br/> To enable support for TLS 1.1 and TLS 1.2, add the following configuration setting to the [runtime](~/docs/framework/configure-apps/file-schema/runtime/runtime-element.md) section of the `app.config` or `web.config` file:  <br/><br/>`<runtime>` <br/> &nbsp;&nbsp;&nbsp;`<AppContextSwitchOverrides value="Switch.System.ServiceModel.DisableUsingServicePointManagerSecurityProtocols=false;`<br/>&nbsp;&nbsp;&nbsp;`Switch.System.Net.DontEnableSchUseStrongCrypto=false" />`<br/>`</runtime>` | Edge |         

## <a name="WPF" /> Windows Presentation Foundation (WPF)  

| Feature | Change | Impact | Scope |
|---|---|---|---|
| The <xref:System.Windows.Controls.Grid> control's space allocation to star-columns | Starting with apps that target the .NET Framework 4.7, WPF replaces the algorithm that the <xref:System.Windows.Controls.Grid> control uses to allocate space to \*-columns.md) | For applications that target the versions of the .NET Framework starting with the .NET Framework 4.7, this change affects the actual width assigned to \*-columns in a number of cases. If this change is undesirable, the previous algorithm can continue to be applied by adding a entry to the application configuration file. For more information, see [Mitigation: Grid Control's Space Allocation to Star-columns](../../../docs/framework/migration-guide/mitigation-grid-control.md). | Minor |
<xref:System.Windows.Media.ImageSourceConverter.ConvertFrom%2A> | In applications that target the .NET Framework 4.6.2 and earlier versions, an error in the exception handling code for the <xref:System.Windows.Media.ImageSourceConverter.ConvertFrom%2A> method caused a <xref:System.NullReferenceException>  to be thrown instead of the intended exception (such as a <xref:System.IO.DirectoryNotFoundException> or a <xref:System.IO.FileNotFoundException>.<br/><br/>Starting with apps that target the .NET Framework 4.7, the correct exception is thrown.  | Applications that target the .NET Framework 4.7 and that depend on handling a <xref:System.NullReferenceException> can restore the previous behavior by adding the following to the configuration setting to the [runtime](~/docs/framework/configure-apps/file-schema/runtime/runtime-element.md) section of the `app.config` file: <br/><br/>`<runtime>`<br/>&nbsp;&nbsp;&nbsp;`<AppContextSwitchOverrides value="Switch.System.Windows.Media.ImageSourceConverter.OverrideExceptionWithNullReferenceException=true"/>`<br/>`</runtime>`| Edge | 
| Opt-in support for a `WM_POINTER`-based touch/stylus stack | Starting with apps that target the .NET Framework 4.7, WPF adds support for an optional `WM_POINTER-based touch.  | This is an opt-in feature that is available on Windows systems starting with Windows 10 Creators Update. WPF apps that do not explicitly opt in to pointer-based touch/stylus support are unaffected. For more information, see [Mitigation: Pointer-based Touch and Stylus Support](../Topic/Mitigation:%20Pointer-based%20Touch%20and%20Stylus%20Support.md). | Edge |
| <xref:System.Printing.PrintQueue> class | Starting with the .NET Framework 4.7, WPF printing APIs using <xref:System.Printing.PrintQueue> by default call the Windows Print Document Package API instead of the now-deprecated XPS Print API.<br/><br/>The old printing stack continues to work as before on older Windows versions. | Neither users nor developers should see any changes in behavior or API usage. <br/><br/>To use the old stack in Windows 10 Creators Update, set the `UseXpsOMPrinting` `REG_DWORD` value of the `HKEY_CURRENT_USER\Software\Microsoft.NETFramework\Windows Presentation Foundation\Printing` registry key to 1. | Edge | 
## See also
[Application Compatibility in the .NET Framework 4.7](Application%20Compatibility%20in%20the%20.NET%20Framework%204.7.md)
