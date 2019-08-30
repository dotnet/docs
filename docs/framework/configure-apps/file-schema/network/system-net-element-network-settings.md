---
title: "<system.Net> Element (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#system.Net"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.Net"
helpviewer_keywords: 
  - "system.Net element"
  - "<system.Net> element"
ms.assetid: 52de4d6c-b24d-44aa-ba7d-6b5061f1357e
---
# \<system.Net> Element (Network Settings)
Contains settings that specify how the .NET Framework connects to the network.  
  
 \<configuration>  
\<system.net>  
  
## Syntax  
  
```xml  
<system.net>   
</system.net>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[authenticationModules](authenticationmodules-element-network-settings.md)|Specifies modules used to authenticate Internet requests.|  
|[connectionManagement](connectionmanagement-element-network-settings.md)|Specifies the maximum number of connections to an Internet host.|  
|[defaultProxy](defaultproxy-element-network-settings.md)|Configures the Hypertext Transfer Protocol (HTTP) proxy server.|  
|[mailSettings](mailsettings-element-network-settings.md)|Configures Simple Mail Transport Protocol (SMTP) mail sending options.|  
|[requestCaching](requestcaching-element-network-settings.md)|Controls the caching mechanism for network requests.|  
|[settings](settings-element-network-settings.md)|Configures basic network options for classes in the <xref:System.Net> and related child namespaces.|  
|[webRequestModules](webrequestmodules-element-network-settings.md)|Specifies modules to use to request information from Internet hosts.|  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[configuration](../configuration-element.md)|Contains settings for all namespaces.|  
  
## Remarks  
 The [\<system.net>](system-net-element-network-settings.md) element contains settings for classes in the <xref:System.Net> and related child namespaces. The settings configure authentication modules, connection management, mail settings, the proxy server, and Internet request modules for receiving information from Internet hosts.  
  
## Example  
 The following example shows a typical configuration used by <xref:System.Net> classes.  
  
```xml  
<configuration>  
  <system.net>  
    <authenticationModules>  
      <add type="System.Net.DigestClient" />  
      <add type="System.Net.NegotiateClient" />  
      <add type="System.Net.KerberosClient" />  
      <add type="System.Net.NtlmClient" />  
      <add type="System.Net.BasicClient" />  
    </authenticationModules>  
    <connectionManagement>  
      <add address="*" maxconnection="2" />  
    </connectionManagement>  
    <defaultProxy>  
      <proxy  
        usesystemdefault="true"  
        bypassonlocal="true"  
      />  
    </defaultProxy>  
    <webRequestModules>  
      <add prefix="http"  
           type="System.Net.HttpRequestCreator"  
      />  
      <add prefix="https"  
           type="System.Net.HttpRequestCreator"  
      />  
      <add prefix="file"  
           type="System.Net.FileWebRequestCreator"  
      />  
    </webRequestModules>  
  </system.net>  
</configuration>  
```  
  
## See also

- [Network Settings Schema](index.md)
