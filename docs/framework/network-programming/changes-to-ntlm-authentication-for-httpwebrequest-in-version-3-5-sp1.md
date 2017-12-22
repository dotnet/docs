---
title: "Changes to NTLM authentication for HttpWebRequest in Version 3.5 SP1"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8bf0b428-5a21-4299-8d6e-bf8251fd978a
caps.latest.revision: 8
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Changes to NTLM authentication for HttpWebRequest in Version 3.5 SP1
Security changes were made in .NET Framework version 3.5 SP1 and later that affect how integrated Windows authentication is handled by the <xref:System.Net.HttpWebRequest>, <xref:System.Net.HttpListener>, <xref:System.Net.Security.NegotiateStream>, and related classes in the System.Net namespace. These changes can affect applications that use these classes to make web requests and receive responses where integrated Windows authentication based on NTLM is used. This change can impact web servers and client applications that are configured to use integrated Windows authentication.  
  
## Overview  
 The design of integrated Windows authentication allows for some credential responses to be universal, meaning they can be re-used or forwarded. If this particular design feature is not needed, then the authentication protocols should carry target specific information as well as channel specific information. Services can then provide extended protection to ensure that credential responses contain service specific information such as a Service Principal Name (SPN). With this information in the credential exchanges, services are able to better protect against malicious use of credential responses that might have been improperly obtained.  
  
 Multiple components in the <xref:System.Net> and <xref:System.Net.Security> namespaces perform integrated Windows authentication on behalf of a calling application. This section describes changes to System.Net components to add extended protection in their use of integrated Windows authentication.  
  
## Changes  
 The NTLM authentication process used with integrated Windows authentication includes a challenge issued by the destination computer and sent back to the client computer. When a computer receives a challenge it generated itself, the authentication will fail unless the connection is a loop back connection (IPv4 address 127.0.0.1, for example).  
  
 When accessing a service running on an internal Web server, it is common to access the service using a URL similar to http://contoso/service or https://contoso/service. The name "contoso" is often not the computer name of the computer on which the service is deployed. The <xref:System.Net> and related namespaces support using Active Directory, DNS, NetBIOS, the local computer's hosts file (typically WINDOWS\system32\drivers\etc\hosts, for example), or the local computer's lmhosts file (typically WINDOWS\system32\drivers\etc\lmhosts, for example) to resolve names to addresses. The name "contoso" is resolved so that requests sent to "contoso" are sent to the appropriate server computer.  
  
 When configured for large deployments, it is also common for a single virtual server name to be given to the deployment with the underlying machine names never used by client applications and end users. For example, you might call the server www.contoso.com, but on an internal network simply use "contoso". This name is called the Host header in the client web request. As specified by the HTTP protocol, the Host request-header field specifies the Internet host and port number of the resource being requested. This information is obtained from the original URI given by the user or referring resource (generally an HTTP URL). On .NET Framework version 4, this information can also be set by the client using the new <xref:System.Net.HttpWebRequest.Host%2A> property.  
  
 The <xref:System.Net.AuthenticationManager> class controls the managed authentication components ("modules") that are used by <xref:System.Net.WebRequest> derivative classes and the <xref:System.Net.WebClient> class. The <xref:System.Net.AuthenticationManager> class provides a property that exposes a <xref:System.Net.AuthenticationManager.CustomTargetNameDictionary%2A?displayProperty=nameWithType> object, indexed by URI string, for applications to supply a custom SPN string to be used during authentication.  
  
 Version 3.5 SP1 now defaults to specifying the host name used in the request URL in the SPN in the NTLM (NT LAN Manager) authentication exchange when the <xref:System.Net.AuthenticationManager.CustomTargetNameDictionary%2A> property is not set. The host name used in the request URL may be different from the Host header specified in the <xref:System.Net.HttpRequestHeader?displayProperty=nameWithType> in the client request. The host name used in the request URL may be different from the actual host name of the server, the machine name of the server, the computer's IP address, or the loopback address. In these cases, Windows will fail the authentication request. To address the issue, we need to notify Windows that the host name used in the request URL in the client request ("contoso", for example) is actually an alternate name for the local computer.  
  
 There are several possible methods for a server application to work around this change. The recommended approach is to map the host name used in the request URL to the `BackConnectionHostNames` key in the registry on the server. The `BackConnectionHostNames` registry key is normally used to map a host name to a loopback address. The steps are listed below.  
  
 To specify the host names that are mapped to the loopback address and can connect to Web sites on a local computer, follow these steps:  
  
 1. Click Start, click Run, type regedit, and then click OK.  
  
 2. In Registry Editor, locate and then click the following registry key:  
  
 `HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Lsa\MSV1_0`  
  
 3. Right-click MSV1_0, point to New, and then click Multi-String Value.  
  
 4. Type `BackConnectionHostNames`, and then press ENTER.  
  
 5. Right-click `BackConnectionHostNames`, and then click Modify.  
  
 6. In the Value data box, type the host name or the host names for the sites (the host name used in the request URL) that are on the local computer, and then click OK.  
  
 7. Quit Registry Editor, and then restart the IISAdmin service and run IISReset.  
  
 A less secure work around is to disable the loop back check, as described in [http://support.microsoft.com/kb/896861](http://go.microsoft.com/fwlink/?LinkID=179657). This disables the protection against reflection attacks. So it is better to constrain the set of alternate names to only those you expect the machine to actually use.  
  
## See Also  
 <xref:System.Net.AuthenticationManager.CustomTargetNameDictionary%2A?displayProperty=nameWithType>  
 <xref:System.Net.HttpRequestHeader?displayProperty=nameWithType>  
 <xref:System.Net.HttpWebRequest.Host%2A?displayProperty=nameWithType>
