---
title: "&lt;Uri&gt; Element (Uri Settings)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c22bab8b-477c-4ae4-8498-65ad409e0847
caps.latest.revision: 11
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;Uri&gt; Element (Uri Settings)
Contains settings that specify how the .NET Framework handles web addresses expressed using uniform resource identifiers (URIs).  
  
## Schema Hierarchy  
 [\<configuration> Element](../../../../../docs/framework/configure-apps/file-schema/configuration-element.md)  
  
 [\<uri>](../../../../../docs/framework/configure-apps/file-schema/network/uri-element-uri-settings.md)  
  
## Syntax  
  
```xml  
<uri>  
</uri>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[idn](../../../../../docs/framework/configure-apps/file-schema/network/idn-element-uri-settings.md)|Specifies if Internationalized Domain Name (IDN) parsing is applied to domain names.|  
|[iriParsing](../../../../../docs/framework/configure-apps/file-schema/network/iriparsing-element-uri-settings.md)|Specifies if International Resource Identifier (IRI) parsing is applied to <xref:System.Uri> and whether IRI parsing rules should be applied.|  
|[schemeSettings](../../../../../docs/framework/configure-apps/file-schema/network/schemesettings-element-uri-settings.md)|Specifies how a <xref:System.Uri> will be parsed for specific schemes.|  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[configuration](../../../../../docs/framework/configure-apps/file-schema/configuration-element.md)|Contains settings for all namespaces.|  
  
## Remarks  
 The `uri` element contains settings for members of the <xref:System.Uri> class used by classes in the <xref:System.Net> namespace. The settings configure support for IRI and IDN.  
  
## Example  
  
### Description  
 The following example shows a configuration used by the <xref:System.Uri> class to support IRI parsing and IDN names. The example also clears all scheme settings and then adds support for not escaping percent-encoded path delimiters for the http scheme.  
  
### Code  
  
```xml  
<configuration>  
  <uri>  
    <idn enabled="All" />  
    <iriParsing enabled="true" />  
    <schemeSettings>  
      <clear/>  
      <add name="http" genericUriParserOptions="DontUnescapePathDotsAndSlashes"/>  
    </schemeSettings>  
  </uri>  
</configuration>  
```  
  
## See Also  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
