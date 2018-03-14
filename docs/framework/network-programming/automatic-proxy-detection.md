---
title: "Automatic Proxy Detection"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "automatic proxy detections"
  - "Web Proxy Auto-Discovery"
  - "Web proxy"
  - "detecting proxies automatically"
  - "WebProxy class, automatic proxy detections"
  - "proxies, automatically detecting"
  - "network"
  - "WPAD (Web Proxy Auto-Discovery)"
ms.assetid: fcd9c3bd-93de-4c92-8ff3-837327ad18de
caps.latest.revision: 18
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Automatic Proxy Detection
Automatic proxy detection is a process by which a Web proxy server is identified by the system and used to send requests on behalf of the client. This feature is also known as Web Proxy Auto-Discovery (WPAD). When automatic proxy detection is enabled, the system attempts to locate a proxy configuration script that is responsible for returning the set of proxies that can be used for the request. If the proxy configuration script is found, the script is downloaded, compiled, and run on the local computer when proxy information, the request stream, or the response is obtained for a request that uses a <xref:System.Net.WebProxy> instance.  
  
 Automatic proxy detection is performed by the <xref:System.Net.WebProxy> class and can employ request-level settings, settings in configuration files, and settings specified using the Internet Explorer **Local Area Network (LAN)** dialog box.  
  
> [!NOTE]
>  You can display the Internet Explorer **Local Area Network (LAN) Settings** dialog box by selecting **Tools** from the Internet Explorer main menu and then selecting **Internet Options**. Next, select the **Connections** tab, and click **LAN Settings**.  
  
 When automatic proxy detection is enabled, the <xref:System.Net.WebProxy> class attempts to locate the proxy configuration script as follows:  
  
1.  The WinINet `InternetQueryOption` function is used to locate the proxy configuration script most recently detected by Internet Explorer.  
  
2.  If the script is not located, the <xref:System.Net.WebProxy> class uses the Dynamic Host Configuration Protocol (DHCP) to locate the script. The DHCP server can respond either with the location (host name) of the script or with the full URL for the script.  
  
3.  If DHCP does not identify the WPAD host, DNS is queried for a host with WPAD as its name or alias.  
  
4.  If the host is not identified and the location of a proxy configuration script is specified by the Internet Explorer LAN settings or a configuration file, this location is used.  
  
> [!NOTE]
>  Applications running as an NT Service or as part of ASP.NET use the Internet Explorer proxy server settings (if available) of the invoking user. These settings may not be available for all service applications.  
  
 Proxies are configured on a per-connectoid basis. A connectoid is an item in the network connection dialog, and can be a physical network device (a modem or Ethernet card) or a virtual interface (such as a VPN connection running over a network device). When a connectoid changes (for example, a wireless connection changes an access point, or a VPN is enabled), the proxy detection algorithm is run again.  
  
 By default, the Internet Explorer proxy settings are used to detect the proxy. If your application is running under a non-interactive account (without a convenient way to configure IE proxy settings), or if you want to use proxy settings different than the IE settings, you can configure your proxy by creating a configuration file with the [\<defaultProxy> Element (Network Settings)](../../../docs/framework/configure-apps/file-schema/network/defaultproxy-element-network-settings.md) and [\<proxy> Element (Network Settings)](../../../docs/framework/configure-apps/file-schema/network/proxy-element-network-settings.md) elements defined.  
  
 For requests that you create, you can disable automatic proxy detection at the request level by using a null <xref:System.Net.WebRequest.Proxy%2A> with your request, as shown in the following code example.  
  
```csharp  
public static void DisableForMyRequest (Uri resource)  
{  
    WebRequest request = WebRequest.Create (resource);  
    request.Proxy = null;  
    WebResponse response = request.GetResponse ();  
}  
```  
  
```vb  
Public Shared Sub DisableForMyRequest(ByVal resource As Uri)  
    Dim request As WebRequest = WebRequest.Create(resource)  
    request.Proxy = Nothing  
    Dim response As WebResponse = request.GetResponse()  
    End Sub   
```  
  
 Requests that do not have a proxy use your application domain's default proxy, which is available in the <xref:System.Net.WebRequest.DefaultWebProxy%2A> property.  
  
## See Also  
 <xref:System.Net.WebProxy>  
 <xref:System.Net.WebRequest>  
 [\<system.Net> Element (Network Settings)](../../../docs/framework/configure-apps/file-schema/network/system-net-element-network-settings.md)
