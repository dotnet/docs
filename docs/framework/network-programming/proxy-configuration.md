---
title: "Proxy Configuration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Networking"
  - "adaptive proxies"
  - "static proxies"
  - "Network Resources"
  - "Internet, proxy configuration"
  - "proxies"
  - "network, proxy configuration"
  - "proxies, configuring"
ms.assetid: 353c0a8b-4cee-44f6-8e65-60e286743df9
caps.latest.revision: 14
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Proxy Configuration
A proxy server handles client requests for resources. A proxy can return a requested resource from its cache or forward the request to the server where the resource resides. Proxies can improve network performance by reducing the number of requests sent to remote servers. Proxies can also be used to restrict access to resources.  
  
## Adaptive Proxies  
 In the .NET Framework, proxies come in two varieties: adaptive and static. Adaptive proxies adjust their settings when the network configuration changes. For example, if a laptop user starts a dialup network connection, an adaptive proxy would recognize this change, discover and run its new configuration script, and adjust its settings appropriately.  
  
 Adaptive proxies are configured by a configuration script (see [Automatic Proxy Detection](../../../docs/framework/network-programming/automatic-proxy-detection.md)). The script generates a set of application protocols and a proxy for each protocol.  
  
 Several options control how the configuration script is run. You can specify the following:  
  
-   How often the configuration script is downloaded and run.  
  
-   How long to wait for the script to download.  
  
-   Which credentials your system should use to access the proxy.  
  
-   Which credentials your system should use to download the configuration script.  
  
 Changes in the network environment may require that the system use a new set of proxies. If a network connection goes down or a new network connection is initialized, the system must discover the appropriate source of the configuration script in the new environment and run the new script.  
  
 The following table shows configuration options for an adaptive proxy.  
  
|Attribute, property, or configuration file setting|Description|  
|--------------------------------------------------------|-----------------|  
|`scriptDownloadInterval`|Elapsed time in seconds between script downloads.|  
|`scriptDownloadTimeout`|Time to wait (in seconds) for the script to download.|  
|`useDefaultCredentials` or <xref:System.Net.WebProxy.UseDefaultCredentials>|Controls whether the system uses the default network credentials to access a proxy.|  
|`useDefaultCredentialForScriptDownload`|Controls whether the system uses the default network credentials to download the configuration script.|  
|`usesystemdefaults`|Controls whether the static proxy settings (proxy address, bypass list, and bypass on local) should be read from the Internet Explorer proxy settings for the user. If this value is set to "true", then the static proxy settings from Internet Explorer will be used.<br /><br /> If this value is "false" or not set, then the static proxy settings can be specified in the configuration and will override the Internet Explorer proxy settings. This value must also be set to "false" or not set for adaptive proxies to be enabled.|  
  
 The following example shows a typical adaptive proxy configuration.  
  
```xml  
<system.net>  
    <defaultProxy>  
      <proxy  scriptDownloadInterval="600"  
              scriptDownloadTimeout="30"  
              useDefaultCredentials="true"  
              usesystemdefaults="true"  
      />  
    </defaultProxy>  
</system.net>  
```  
  
## Static Proxies  
 Static proxies are usually configured explicitly by an application, or when a configuration file is invoked by an application or the system. Static proxies are useful in networks in which the topology changes infrequently, such as a desktop computer connected to a corporate network.  
  
 Several options control how a static proxy operates. You can specify the following:  
  
-   The address of the proxy.  
  
-   Whether the proxy should be bypassed for local addresses.  
  
-   Whether the proxy should be bypassed for a set of addresses.  
  
 The following table shows the configuration options for a static proxy.  
  
|Attribute, property, or configuration file setting|Description|  
|--------------------------------------------------------|-----------------|  
|`proxyaddress` or <xref:System.Net.WebProxy.Address>|The address of the proxy to use.|  
|`bypassonlocal` or <xref:System.Net.WebProxy.BypassProxyOnLocal>|Controls whether the proxy is bypassed for local addresses.|  
|`bypasslist` or <xref:System.Net.WebProxy.BypassArrayList>|Describes, with regular expressions, a set of addresses that bypass the proxy.|  
|`usesystemdefaults`|Controls whether the static proxy settings (proxy address, bypass list, and bypass on local) should be read from the Internet Explorer proxy settings for the user. If this value is set to "true", then the static proxy settings from Internet Explorer will be used. On .NET Framework 2.0 when this value is set to "true", the Internet Explorer proxy settings are not overridden by other proxy settings in the configuration file. On .NET Framework 1.1, the Internet Explorer proxy settings can be overridden by other proxy settings in the configuration file.<br /><br /> If this value is "false" or not set, then the static proxy settings can be specified in the configuration and will override the Internet Explorer proxy settings. This value must also be set to "false" or not set for adaptive proxies to be enabled.|  
  
 The following example shows a typical static proxy configuration.  
  
```xml  
<system.net>  
    <defaultProxy>  
        <proxy  proxyaddress="http://proxy.contoso.com:3128"  
                bypassonlocal="true"  
        />  
        <bypasslist>  
            <add address="[a-z]+.blueyonderairlines.com$" />  
        </bypasslist>  
    </defaultProxy>  
</system.net>  
```  
  
## See Also  
 <xref:System.Net.WebProxy>  
 <xref:System.Net.GlobalProxySelection>  
 [Automatic Proxy Detection](../../../docs/framework/network-programming/automatic-proxy-detection.md)
