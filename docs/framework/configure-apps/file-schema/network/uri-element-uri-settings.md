---
title: "<uri> Element (Uri Settings)"
ms.date: "03/30/2017"
ms.assetid: c22bab8b-477c-4ae4-8498-65ad409e0847
---
# \<uri> Element (Uri Settings)
Contains settings that specify how the .NET Framework handles web addresses expressed using uniform resource identifiers (URIs).  
  
[**\<configuration>**](../configuration-element.md)  
&nbsp;&nbsp;**\<uri>**  
  
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
|[idn](idn-element-uri-settings.md)|Specifies if Internationalized Domain Name (IDN) parsing is applied to domain names.|  
|[iriParsing](iriparsing-element-uri-settings.md)|Specifies if International Resource Identifier (IRI) parsing is applied to <xref:System.Uri> and whether IRI parsing rules should be applied.|  
|[schemeSettings](schemesettings-element-uri-settings.md)|Specifies how a <xref:System.Uri> will be parsed for specific schemes.|  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[configuration](../configuration-element.md)|Contains settings for all namespaces.|  
  
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
  
## See also

- [Network Settings Schema](index.md)
