---
title: "Automatic Proxy Detection"
description: Learn about automatic proxy detection, where the system identifies a web proxy server and uses it to send requests for the client.
ms.date: "03/30/2017"
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
---
# Automatic proxy detection

Automatic proxy detection is the process of identifying a web proxy server and sending requests on behalf of the client. This feature is also known as Web Proxy Auto-Discovery (WPAD). When automatic proxy detection is enabled, the system attempts to locate a proxy configuration script that's responsible for returning the set of proxies that can be used for the request. If the proxy configuration script is found, the script is downloaded, compiled, and run on the local computer when proxy information, the request stream, or the response is obtained for a request that uses a <xref:System.Net.WebProxy> instance.  
  
 Automatic proxy detection is performed by the <xref:System.Net.WebProxy> class and can employ request-level settings, settings in configuration files, and computer proxy settings.
  
 When automatic proxy detection is enabled, the <xref:System.Net.WebProxy> class attempts to locate the proxy configuration script as follows:  
  
1. The WinINet `InternetQueryOption` function is used to locate the proxy configuration script most recently detected by the browser.
  
2. If the script is not located, the <xref:System.Net.WebProxy> class uses the Dynamic Host Configuration Protocol (DHCP) to locate the script. The DHCP server can respond either with the location (host name) of the script or with the full URL for the script.  
  
3. If DHCP does not identify the WPAD host, DNS is queried for a host with WPAD as its name or alias.  
  
4. If the host is not identified and the location of a proxy configuration script is specified by the computer's proxy settings or a configuration file, this location is used.  
  
> [!NOTE]
> Applications running as an NT Service or as part of ASP.NET use the computer's proxy server settings (if available) of the invoking user. These settings may not be available for all service applications.  
  
 Proxies are configured on a per-connectoid basis. A connectoid is an item in the network connection dialog. It can be a physical network device, such as a modem or Ethernet card, or a virtual interface, such as a VPN connection that runs over a network device. When a connectoid changes, for example, a wireless connection changes an access point or a VPN is enabled, the proxy detection algorithm is run again.  
  
 By default, the computer's proxy settings are used to detect the proxy. If your application is running under a non-interactive account without a convenient way to configure proxy settings, or if you want to use different proxy settings, you can configure your proxy by creating a configuration file with the [\<defaultProxy>](../configure-apps/file-schema/network/defaultproxy-element-network-settings.md) and [\<proxy>](../configure-apps/file-schema/network/proxy-element-network-settings.md) elements defined.  
  
 For requests that you create, you can disable automatic proxy detection at the request level by using a null <xref:System.Net.WebRequest.Proxy%2A> with your request. The following code example shows how to set the <xref:System.Net.WebRequest.Proxy%2A> property to `null`.  
  
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
  
 Requests that don't have a proxy use your application domain's default proxy. The default proxy is available in the <xref:System.Net.WebRequest.DefaultWebProxy%2A> property.  
  
## See also

- <xref:System.Net.WebProxy>
- <xref:System.Net.WebRequest>
- [\<system.Net> Element (Network Settings)](../configure-apps/file-schema/network/system-net-element-network-settings.md)
