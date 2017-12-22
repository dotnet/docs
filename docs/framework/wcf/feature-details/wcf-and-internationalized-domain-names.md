---
title: "WCF and Internationalized Domain Names"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c8a3e10a-8bc2-4a78-8d86-a562ba6e65fa
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF and Internationalized Domain Names
Support has been added to allow for WCF services with Internationalized Domain Names (IDN). An internationalized domain name is a domain name that contains non-ASCII characters. This support includes both the ability to host a WCF service with an IDN name and a WCF client to talk to a web service with an IDN name.  
  
## System.Uri and IDN  
 <xref:System.Uri> has two properties <xref:System.Uri.Host%2A> and <xref:System.Uri.DnsSafeHost%2A>. These properties contain Unicode or Punycode values depending upon the IDN configuration settings.  
  
 IDN is enabled in an application’s configuration file using the following XML  
  
```xml  
<configuration>  
  <uri>  
    <idn enabled="All/AllExceptIntranet/None" />  
  </uri>  
</configuration>  
```  
  
 The \<idn> element contains the enabled attribute which can be set to one of the following values:  
  
1.  "None"  
  
2.  "AllExceptIntranet"  
  
3.  "All"  
  
 When the IDN setting is set to "None", no conversions are performed by Uri.Host or Uri.DnsSafeHost. When the IDN setting is set to "All", uri.Host remains Unicode and uri.DnsSafeHost is converted to Punycode. When the IDN setting is set to "AllExceptIntranet", uri.DnsSafeHost is converted to Punycode for internet addresses, and remains Unicode for intranet addresses. This setting is important for correct DNS name resolution. Note this setting is not required to be configured for Windows 8 and newer versions.  
  
> [!WARNING]
>  You should never hard-code an address using Punycode. WCF will convert it for you based on the configuration settings you apply.  
  
> [!WARNING]
>  When adding Unicode characters to applicationHost.exe.config, save the file using the UTF-8 encoding.  
  
## See Also  
 [System.Uri](http://msdn.microsoft.com/library/system.uri.aspx)
