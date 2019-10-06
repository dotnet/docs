---
title: "<httpWebRequest> Element (Network Settings)"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/settings/httpWebRequest"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#httpWebRequest"
helpviewer_keywords: 
  - "<httpWebRequest> element"
  - "httpWebRequest element"
ms.assetid: 52acd9d2-5bdc-4dc4-9c2a-f0a476ccbb31
---
# \<httpWebRequest> Element (Network Settings)
Customizes Web request parameters.  
  
[**\<configuration>**](../configuration-element.md)  
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)  
&nbsp;&nbsp;&nbsp;&nbsp;[**\<settings>**](settings-element-network-settings.md)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<httpWebRequest>**  
  
## Syntax  
  
```xml  
<httpWebRequest  
  maximumResponseHeadersLength="size"  
  maximumErrorResponseLength="size"  
  maximumUnauthorizedUploadLength="size"  
  useUnsafeHeaderParsing="true|false"  
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Attribute**|**Description**|  
|-------------------|---------------------|  
|`maximumResponseHeadersLength`|Specifies the maximum length of a response header, in kilobytes. The default is 64. A value of -1 indicates that no size limit will be imposed on the response headers.|  
|`maximumErrorResponseLength`|Specifies the maximum length of an error response, in kilobytes. The default is 64. A value of -1 indicates that no size limit will be imposed on the error response.|  
|`maximumUnauthorizedUploadLength`|Specifies the maximum length of an upload in response to an unauthorized error code, in bytes. The default is -1. A value of -1 indicates that no size limit will be imposed on the upload.|  
|`useUnsafeHeaderParsing`|Specifies whether unsafe header parsing is enabled. The default value is `false`.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[settings](settings-element-network-settings.md)|Configures basic network options for the <xref:System.Net> namespace.|  
  
## Remarks  
 By default, the .NET Framework strictly enforces RFC 2616 for URI parsing. Some server responses may include control characters in prohibited fields, which will cause the <xref:System.Net.HttpWebRequest.GetResponse?displayProperty=nameWithType> method to throw a <xref:System.Net.WebException>. If **useUnsafeHeaderParsing** is set to **true**, <xref:System.Net.HttpWebRequest.GetResponse?displayProperty=nameWithType> will not throw in this case; however, your application will be vulnerable to several forms of URI parsing attacks. The best solution is to change the server so that the response does not include control characters.  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example shows how to specify a larger than normal maximum header length.  
  
```xml  
<configuration>  
  <system.net>  
    <settings>  
      <httpWebRequest  
        maximumResponseHeadersLength="128"  
      />  
    </settings>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.HttpWebRequest.MaximumResponseHeadersLength%2A>
- [Network Settings Schema](index.md)
