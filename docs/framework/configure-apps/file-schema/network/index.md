---
title: "Network Settings Schema"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "elements [.NET Framework], network configuration elements"
  - "sending data, network configuration elements"
  - "receiving data, network configuration elements"
  - "configuration settings [.NET Framework], networks"
  - "Internet, network configuration elements"
  - "network configuration elements"
  - "network settings"
  - "connections [.NET Framework], network configuration elements"
  - "network resources, network configuration elements"
ms.assetid: f1de5a0f-76c5-4833-819f-5222b8146340
---
# Network Settings Schema
Network settings specify how the .NET Framework connects to the Internet. The following table describes the function of each child configuration element under the [\<system.Net> Element (Network Settings)](system-net-element-network-settings.md).  
  
|Element|Description|  
|-------------|-----------------|  
|[\<authenticationModules> Element (Network Settings)](authenticationmodules-element-network-settings.md)|Specifies the modules used to authenticate Internet requests.|  
|[\<connectionManagement> Element (Network Settings)](connectionmanagement-element-network-settings.md)|Specifies the maximum number of connections to Internet hosts.|  
|[\<defaultProxy> Element (Network Settings)](defaultproxy-element-network-settings.md)|Specifies the proxy server used for HTTP requests to the Internet.|  
|[\<mailSettings> Element (Network Settings)](mailsettings-element-network-settings.md)|Contains settings for mail sending options.|  
|[\<requestCaching> Element (Network Settings)](requestcaching-element-network-settings.md)|Controls the caching mechanism for network requests.|  
|[\<webRequestModules> Element (Network Settings)](webrequestmodules-element-network-settings.md)|Specifies the modules used to request information from Internet hosts.|  
  
 Uri settings specify how the .NET Framework handles web addresses expressed using uniform resource identifiers (URIs). The following table describes the function of each child configuration element under the [\<Uri> Element (Uri Settings)](uri-element-uri-settings.md).  
  
|Element|Description|  
|-------------|-----------------|  
|[\<idn> Element (Uri Settings)](idn-element-uri-settings.md)|Specifies if Internationalized Domain Name (IDN) parsing is applied to domain names.|  
|[\<iriParsing> Element (Uri Settings)](iriparsing-element-uri-settings.md)|Specifies if International Resource Identifier (IRI) parsing is applied to a <xref:System.Uri> and whether IRI parsing rules should be applied.|  
|[\<schemeSettings> Element (Uri Settings)](schemesettings-element-uri-settings.md)|Specifies how a <xref:System.Uri> will be parsed for specific schemes.|  
  
## See also

- [Configuring Internet Applications](../../../network-programming/configuring-internet-applications.md)
- [Configuration File Schema](../index.md)
