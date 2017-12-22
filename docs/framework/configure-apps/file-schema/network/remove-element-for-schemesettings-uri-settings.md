---
title: "&lt;remove&gt; Element for schemeSettings (Uri Settings)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4095ba51-de20-4f87-b562-018abe422c91
caps.latest.revision: 5
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;remove&gt; Element for schemeSettings (Uri Settings)
Removes a scheme setting for a scheme name.  
  
 \<configuration>  
\<uri>  
\<schemeSettings>  
\<remove>  
  
## Syntax  
  
```xml  
<remove
  name="http|https"
/>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|name|The scheme name for which this setting applies. The only supported values are name="http" and name="https".|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<schemeSettings> Element (Uri Settings)](../../../../../docs/framework/configure-apps/file-schema/network/schemesettings-element-uri-settings.md)|Specifies how a <xref:System.Uri> will be parsed for specific schemes.|  
  
## Remarks  
 By default, the <xref:System.Uri?displayProperty=nameWithType> class un-escapes percent encoded path delimiters before executing path compression. This was implemented as a security mechanism against attacks like the following:  
  
 `http://www.contoso.com/..%2F..%2F/Windows/System32/cmd.exe?/c+dir+c:\`  
  
 If this URI gets passed down to modules not handling percent encoded characters correctly, it could result in the following command being executed by the server:  
  
 `c:\Windows\System32\cmd.exe /c dir c:\`  
  
 For this reason, <xref:System.Uri?displayProperty=nameWithType> class first un-escapes path delimiters and then applies path compression. The result of passing the malicious URL above to <xref:System.Uri?displayProperty=nameWithType> class constructor results in the following URI:  
  
 `http://www.microsoft.com/Windows/System32/cmd.exe?/c+dir+c:\`  
  
 This default behavior can be modified to not un-escape percent encoded path delimiters using the schemeSettings configuration option for a specific scheme.  
  
## Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
 The following example shows a configuration used by the <xref:System.Uri> class that removes any scheme settings for the http scheme.  
  
```xml  
<configuration>  
  <uri>  
    <schemeSettings>  
      <remove name="http"/>  
    </schemeSettings>  
  </uri>  
</configuration>  
```  
  
## See Also  
 <xref:System.Configuration.SchemeSettingElement?displayProperty=nameWithType>  
 <xref:System.Configuration.SchemeSettingElementCollection?displayProperty=nameWithType>  
 <xref:System.Configuration.UriSection?displayProperty=nameWithType>  
 <xref:System.Configuration.UriSection.SchemeSettings%2A?displayProperty=nameWithType>  
 <xref:System.GenericUriParserOptions?displayProperty=nameWithType>  
 <xref:System.Uri?displayProperty=nameWithType>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
