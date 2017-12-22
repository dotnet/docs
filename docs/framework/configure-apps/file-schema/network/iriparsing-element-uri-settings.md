---
title: "&lt;iriParsing&gt; Element (Uri Settings)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 953d0b53-445e-41f9-b302-77c4030852ce
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;iriParsing&gt; Element (Uri Settings)
Specifies if International Resource Identifier (IRI) parsing is applied to a <xref:System.Uri> and whether IRI parsing rules should be applied.  
  
## Schema Hierarchy  
 [\<configuration> Element](../../../../../docs/framework/configure-apps/file-schema/configuration-element.md)  
  
 [\<Uri> Element (Uri Settings)](../../../../../docs/framework/configure-apps/file-schema/network/uri-element-uri-settings.md)  
  
 [\<iriParsing>](../../../../../docs/framework/configure-apps/file-schema/network/iriparsing-element-uri-settings.md)  
  
## Syntax  
  
```xml  
<iriParsing  
  enabled="true|false"  
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|`enabled`|Specifies whether IRI parsing is enabled. The default value is `false`.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[uri](../../../../../docs/framework/configure-apps/file-schema/network/uri-element-uri-settings.md)|Contains settings that specify how the .NET Framework handles web addresses expressed using uniform resource identifiers (URIs).|  
  
## Remarks  
 The existing <xref:System.Uri> class has been extended in .NET Framework 3.5. 3.0 SP1, and 2.0 SP1 to provide support for International Resource Identifiers (IRI) and Internationalized Domain Names (IDN). Current users will not see any change from the .NET Framework 2.0 behavior unless they specifically enable IRI and IDN support. This ensures application compatibility with prior versions of the .NET Framework.  
  
 To enable support for IRI, the following two changes are required:  
  
1.  Add the following line to the machine.config file under the .NET Framework 2.0 directory  
  
    ```xml  
    <section name="uri" type="System.Configuration.UriSection, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />  
    ```  
  
2.  Specify whether IRI parsing rules should be applied. This can be done in the machine.config or in the app.config file.  
  
 Enabling IRI parsing (iriParsing enabled = `true`) will do normalization and character checking according to the latest IRI rules in RFC 3987. The default value is `false` and will do normalization and character checking according to RFC 2396 and RFC 3986 (for IPv6 literals).  
  
### Configuration Files  
 This element can be used in the application configuration file or the machine configuration file (Machine.config).  
  
## Example  
  
### Description  
 The following example shows a configuration used by the <xref:System.Uri> class to support IRI parsing and IDN names.  
  
### Code  
  
```xml  
<configuration>  
  <uri>  
    <idn enabled="All" />  
    <iriParsing enabled="true" />  
  </uri>  
</configuration>  
```  
  
## See Also  
 <xref:System.Configuration.IriParsingElement?displayProperty=nameWithType>  
 <xref:System.Configuration.UriSection?displayProperty=nameWithType>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
