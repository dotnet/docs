---
title: "Enabling and Disabling IPv6"
ms.date: "03/30/2017"
ms.assetid: 6408d3ef-c9ba-49d9-b15e-fe74bd3ef031
---
# Enabling and Disabling IPv6
To use the IPv6 protocol, ensure that you are running a version of the operating system that supports IPv6 and ensure that the operating system and the networking classes are configured properly.  
  
## Configuration Steps  
 The following table lists various configurations  
  
|Operating system IPv6-enabled?|Networking classes IPv6-enabled?|Description|  
|-------------------------------------|---------------------------------------|-----------------|  
|No|No|Can parse IPv6 addresses.|  
|No|Yes|Can parse IPv6 addresses.|  
|Yes|No|Can parse IPv6 addresses and resolve IPv6 addresses using name resolution methods not marked obsolete.|  
|Yes|Yes|Can parse and resolve IPv6 addresses using all methods including those marked obsolete.|  
  
 Be aware that to enable the IPv6 support for all classes in the System.Net namespace, you must modify the computer configuration file or the configuration file for the application. The configuration file for an application has precedence over the computer configuration file.  
  
 For an example of how to modify the computer configuration file, *machine.config*, to enable Ipv6 support see, [How to: Modify the Computer Configuration File to Enable Ipv6 Support](how-to-modify-the-computer-configuration-file-to-enable-ipv6-support.md). Also, ensure that the IPv6 support is enabled for the operating system.  
  
 The .NET Framework has a configuration switch set in a configuration file as follows  
  
```xml  
<system.net>  
  ...  
  <settings>  
    ...  
    <ipv6 enabled="true"/>  
    ...  
  </settings>  
  ...  
</system.net>  
```  
  
 For .NET Framework version 1.1 and earlier, the value of the **ipv6 enabled** configuration switch specifies whether members of the <xref:System.Net.Dns?displayProperty=nameWithType> class return IPv6 addresses.  
  
 For .NET Framework version 2.0 and later, if Windows supports IPv6, then members of the <xref:System.Net.Dns?displayProperty=nameWithType> class, (for example, the <xref:System.Net.Dns.GetHostEntry%2A?displayProperty=nameWithType> method), will return IPv6 addresses with one limitation. Obsolete members of the DNS <xref:System.Net.Dns?displayProperty=nameWithType> (for example, the <xref:System.Net.Dns.Resolve%2A?displayProperty=nameWithType> method) will read and recognize the value in the configuration file for the ipv6 enabled setting.  
  
## See also

- [Internet Protocol Version 6](internet-protocol-version-6.md)
- [Sockets](sockets.md)
- [Network Settings Schema](../configure-apps/file-schema/network/index.md)
- [\<ipv6> Element (Network Settings)](../configure-apps/file-schema/network/ipv6-element-network-settings.md)
