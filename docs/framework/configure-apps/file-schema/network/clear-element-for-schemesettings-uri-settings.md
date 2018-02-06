---
title: "&lt;clear&gt; Element for schemeSettings (Uri Settings)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 65098332-ce61-4542-ab8d-e7dc0257d31f
caps.latest.revision: 7
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;clear&gt; Element for schemeSettings (Uri Settings)
Clears all existing scheme settings.  
  
 \<configuration>  
\<uri>  
\<schemeSettings>  
\<clear>  
  
## Syntax  
  
```xml  
<clear/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
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
 The following example shows a configuration used by the <xref:System.Uri> class that clears all scheme settings and then adds support for not escaping percent-encoded path delimiters for the http scheme.  
  
```xml  
<configuration>  
  <uri>  
    <schemeSettings>  
      <clear/>  
      <add name="http" genericUriParserOptions="DontUnescapePathDotsAndSlashes"/>  
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
