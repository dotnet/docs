---
description: "Learn more about: <idn> Element (Uri Settings)"
title: "<idn> Element (Uri Settings)"
ms.date: "03/30/2017"
ms.assetid: 16c8e869-1791-4cf5-9244-3d3c738f60ec
---
# \<idn> Element (Uri Settings)

Specifies if Internationalized Domain Name (IDN) parsing is applied to a domain name.
  
[**\<configuration>**](../configuration-element.md)  
&nbsp;&nbsp;[**\<uri>**](uri-element-uri-settings.md)  
&nbsp;&nbsp;&nbsp;&nbsp;**\<idn>**  
  
## Syntax  
  
```xml
<idn
  enabled="All|AllExceptIntranet|None"
/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

|**Element**|**Description**|  
|-----------------|---------------------|  
|`enabled`|Specifies if Internationalized Domain Name (IDN) parsing is applied to a domain name The default value is none.|  

### Child elements

None
  
### Parent elements

|**Element**|**Description**|  
|-----------------|---------------------|  
|[uri](uri-element-uri-settings.md)|Contains settings that specify how the .NET Framework handles web addresses expressed using uniform resource identifiers (URIs).|  

## Remarks

The existing <xref:System.Uri> class has been extended in .NET Framework 3.5. 3.0 SP1, and 2.0 SP1 with support for International Resource Identifiers (IRI) and Internationalized Domain Names (IDN). Current users will not see any change from the .NET Framework 2.0 behavior unless they specifically enable IRI and IDN support. This ensures application compatibility with prior versions of the .NET Framework.

To enable support for IRI, the following two changes are required:

1. Add the following line to the machine.config file under the .NET Framework 2.0 directory:
  
    ```xml  
    <section name="uri" type="System.Configuration.UriSection, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />  
    ```  
  
2. Specify whether you want Internationalized Domain Name (IDN) parsing applied to the domain name and whether IRI parsing rules should be applied. This can be done in the machine.config or in the app.config file.

 There are three possible values for IDN depending on the DNS servers that are used:

- idn enabled = All  

     This value will convert any Unicode domain names to their Punycode equivalents (IDN names).

- idn enabled = AllExceptIntranet

     This value will convert all Unicode domain names not on the local Intranet to use the Punycode equivalents (IDN names). In this case to handle international names on the local Intranet, the DNS servers that are used for the Intranet should support Unicode name resolution.

- idn enabled = None

     This value will not convert any Unicode domain names to use Punycode. This is the default value which is consistent with the .NET Framework 2.0 behavior.

 Enabling IDN will convert all Unicode labels in a domain name to their Punycode equivalents. Punycode names contain only ASCII characters and always start with the xn-- prefix. The reason for this is to support existing DNS servers on the Internet, since most DNS servers only support ASCII characters (see RFC 3940).

### Configuration files

This element can be used in the application configuration file or the machine configuration file (Machine.config).

## Example

The following example shows a configuration used by the <xref:System.Uri> class to support IRI parsing and IDN names:

```xml
<configuration>
  <uri>
    <idn enabled="All" />
    <iriParsing enabled="true" />
  </uri>
</configuration>
```

## See also

- <xref:System.Configuration.IdnElement?displayProperty=nameWithType>
- <xref:System.Configuration.UriSection?displayProperty=nameWithType>
- [Network Settings Schema](index.md)
