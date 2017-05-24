---
title: "Retargeting Changes in the .NET Framework 4.6 | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "retargeting changes, .NET Framework"
  - "retargeting changes, .NET Framework 4.6"
  - "application compatibility"
ms.assetid: fa849255-f90f-4bf1-b0ff-b173c12110d7
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Retargeting Changes in the .NET Framework 4.6
In rare cases, retargeting changes may affect apps that are recompiled to target the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)]. Unless specified otherwise, these changes do not affect binaries that target a previous version of the .NET Framework but are running under the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)].  
  
 The [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] includes retargeting changes in the following areas:  
  
-   [Core](#Core)  
  
-   [ASP.NET](#ASP)  
  
-   [Networking](#Net)  
  
-   [Windows Communications Foundation (WCF)](#WCF)  
  
-   [Windows Forms](#WinForms)  
  
-   [Windows Presentation Foundation (WPF)](#WPF)  
  
-   [XML](#XML)  
  
<a name="Core"></a>   
## Core  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=fullName>, <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=fullName>, and task-based asynchronous operations with <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601>|For apps that target the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] and later versions, <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=fullName> and <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=fullName> are stored in a thread's <xref:System.Threading.ExecutionContext>, which flows across asynchronous operations.|Changes to the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=fullName> and <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=fullName> properties will be reflected in asynchronous tasks which are launched subsequently. For more information, see [Mitigation: Culture and Asynchronous Operations](../../../docs/framework/migration-guide/mitigation-culture-and-asynchronous-operations.md).|Minor|  
  
<a name="ASP"></a>   
## ASP.NET  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.Web.UI.HtmlTextWriter.RenderBeginTag%28System.Web.UI.HtmlTextWriterTag%29?displayProperty=fullName> with a `tagKey` value of <xref:System.Web.UI.HtmlTextWriterTag?displayProperty=fullName>|In conformance with the HTML standard, the <xref:System.Web.UI.HtmlTextWriter.RenderBeginTag%28System.Web.UI.HtmlTextWriterTag%29?displayProperty=fullName> method now renders <xref:System.Web.UI.HtmlTextWriterTag?displayProperty=fullName> as a non-closing tag in an HTML response.|The BR tag now produces one line break. Previously, it produced two line breaks.<br /><br /> Apps that depend on the `<BR>` tag to produce two line breaks can restore the previous behavior by adding an additional call to the <xref:System.Web.UI.HtmlTextWriter.RenderBeginTag%28System.Web.UI.HtmlTextWriterTag%29?displayProperty=fullName> method with the <xref:System.Web.UI.HtmlTextWriterTag?displayProperty=fullName> argument.|Minor|  
  
<a name="Net"></a>   
## Networking  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.Net.ServicePointManager?displayProperty=fullName> and <xref:System.Net.Security.SslStream?displayProperty=fullName>|Starting with apps that target the .NET Framework 4.6, the <xref:System.Net.ServicePointManager?displayProperty=fullName> and <xref:System.Net.Security.SslStream?displayProperty=fullName> classes are allowed to use one of the following three protocols: Tls1.0, Tls1.1, or Tls 1.2.<br /><br /> Apps that target a previous version of the NET Framework, even if they run on the NET Framework 4.6, are unaffected.|This change affects any app that targets the .NET Framework 4.6 and that uses SSL to talk to an HTTPS server or a socket server using any of the following types: <xref:System.Net.Http.HttpClient>, <xref:System.Net.HttpWebRequest>, <xref:System.Net.FtpWebRequest>, <xref:System.Net.Mail.SmtpClient>, and <xref:System.Net.Security.SslStream>.  For more information, see [Mitigation: TLS Protocols](../../../docs/framework/migration-guide/mitigation-tls-protocols.md).|Minor|  
  
<a name="WCF"></a>   
## Windows Communications Foundation (WCF)  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.IdentityModel.Policy.AuthorizationContext.CreateDefaultAuthorizationContext%2A?displayProperty=fullName>|The implementation of the <xref:System.IdentityModel.Policy.AuthorizationContext> returned by a call to the <xref:System.IdentityModel.Policy.AuthorizationContext.CreateDefaultAuthorizationContext%28System.Collections.Generic.IList%7BSystem.IdentityModel.Policy.IAuthorizationPolicy%7D%29> with a `null``authorizationPolicies` argument has changed its implementation in the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)].|In rare cases, WCF apps that use custom authentication may see behavioral differences. If the old behavior is needed, see [Mitigation: Default AuthorizationContext](../../../docs/framework/migration-guide/mitigation-default-authorizationcontext.md).|Minor|  
  
<a name="WinForms"></a>   
## Windows Forms  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.Drawing.Icon.ToBitmap%2A?displayProperty=fullName>|Starting with the apps that target the .NET Framework 4.6, the <xref:System.Drawing.Icon.ToBitmap%2A?displayProperty=fullName> method successfully converts icons with PNG frames into <xref:System.Drawing.Bitmap> objects.<br /><br /> In apps that target the .NET Framework 4.5.2 and earlier versions, the <xref:System.Drawing.Icon.ToBitmap%2A?displayProperty=fullName> method throws an <xref:System.ArgumentOutOfRangeException> exception if the <xref:System.Drawing.Icon> object has PNG frames.|This change affects apps that are recompiled to target the .NET Framework 4.6 and that provide special handling for the <xref:System.ArgumentOutOfRangeException> exception that is thrown if an <xref:System.Drawing.Icon> object has PNG frames. If this behavior is undesirable, a configuration switch restores the previous behavior. For more information, see [Mitigation: PNG Frames in Icon Objects](../../../docs/framework/migration-guide/mitigation-png-frames-in-icon-objects.md).|Minor|  
  
<a name="WPF"></a>   
## Windows Presentation Foundation (WPF)  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=fullName> and <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=fullName>|In apps that target the .NET Framework 4.6 and the .NET Framework 4.6.1, changes to the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=fullName> or <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=fullName> properties that are made within a <xref:System.Windows.Threading.Dispatcher> are lost at the end of that dispatcher operation. Similarly, changes to <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=fullName> or <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=fullName> made outside of a dispatcher operation may not be reflected when that operation executes.|Changes to the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=fullName> and  <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=fullName> properties may not flow between WPF UI callbacks and other code in a WPF application. For more information, see [Mitigation: Culture and Dispatcher Operations in WPF Apps](../../../docs/framework/migration-guide/mitigation-culture-and-dispatcher-operations-in-wpf-apps.md).|Minor|  
|Layout rounding at high DPIs|The way in which margins are rounded and borders and the background inside of them has changed.|The layout of WPF controls can change slightly. For more information, see [Mitigation: WPF Layout](../../../docs/framework/migration-guide/mitigation-wpf-layout.md).|Minor|  
  
<a name="XML"></a>   
## XML  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|XSD schema validation|Starting with the .NET Framework 4.6, XSD schema validation detects violation of the unique constraint if a compound key is used and one key is empty.|See [Mitigation: XML Schema Validation](../../../docs/framework/migration-guide/mitigation-xml-schema-validation.md)|Minor|  
|<xref:System.Xml.XmlWriter>|For apps that target the .NET Framework 4.5.2 or previous versions, writing an invalid surrogate pair using exception fallback handling does not always throw an exception.<br /><br /> For apps that target the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)], attempting to write an invalid surrogate pair throws an <xref:System.ArgumentException> exception.|Apps that are recompiled to target the [!INCLUDE[net_v46](../../../includes/net-v46-md.md)] and that write invalid surrogate pairs will throw an exception in cases when previously they did not.|Edge|