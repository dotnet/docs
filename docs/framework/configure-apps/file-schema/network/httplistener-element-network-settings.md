---
title: "&lt;httpListener&gt; Element (Network Settings)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 62f121fd-3f2e-4033-bb39-48ae996bfbd9
caps.latest.revision: 7
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;httpListener&gt; Element (Network Settings)
Customizes parameters used by the <xref:System.Net.HttpListener> class.  
  
 \<configuration>  
\<system.net>  
\<settings>  
\<httpListener>  
  
## Syntax  
  
```xml  
<httpListener  
  unescapeRequestUrl="true|false"  
/>  
```  
  
## Type  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|unescapeRequestUrl|A Boolean value that indicates if a <xref:System.Net.HttpListener> instance uses the raw unescaped URI instead of the converted URI.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[settings](../../../../../docs/framework/configure-apps/file-schema/network/settings-element-network-settings.md)|Configures basic network options for the <xref:System.Net> namespace.|  
  
## Remarks  
 The **unescapeRequestUrl** attribute indicates if <xref:System.Net.HttpListener> uses the raw unescaped URI instead of the converted URI where any percent-encoded values are converted and other normalization steps are taken.  
  
 When a <xref:System.Net.HttpListener> instance receives a request through the `http.sys` service, it creates an instance of the URI string provided by `http.sys`, and exposes it as the <xref:System.Net.HttpListenerRequest.Url%2A?displayProperty=nameWithType> property.  
  
 The `http.sys` service exposes two request URI strings:  
  
-   Raw URI  
  
-   Converted URI  
  
 The raw URI is the <xref:System.Uri?displayProperty=nameWithType> provided in the request line of a HTTP request:  
  
 `GET /path/`  
  
 `Host: www.contoso.com`  
  
 The raw URI provided by `http.sys` for the request mentioned above, is "/path/". This represents the string following the HTTP verb as it was sent over the network.  
  
 The `http.sys` service creates a converted URI from the information provided in the request by using the URI provided in the HTTP request line and the Host header to determine the origin server the request should be forwarded to. This is done by comparing the information from the request with a set of registered URI prefixes. The HTTP Server SDK documentation refers to this converted URI as the HTTP_COOKED_URL structure.  
  
 In order to be able to compare the request with registered URI prefixes, some normalization to the request needs to be done. For the sample above the converted URI would be as follows:  
  
 `http://www.contoso.com/path/`  
  
 The `http.sys` service combines the <xref:System.Uri.Host%2A?displayProperty=nameWithType> property value and the string in the request line to create a converted URI. In addition, `http.sys` and the <xref:System.Uri?displayProperty=nameWithType> class also does the following:  
  
-   Un-escapes all percent encoded values.  
  
-   Converts percent-encoded non-ASCII characters into a UTF-16 character representation. Note that UTF-8 and ANSI/DBCS characters are supported as well as Unicode characters (Unicode encoding using the %uXXXX format).  
  
-   Executes other normalization steps, like path compression.  
  
 Since the request doesn't contain any information about the encoding used for percent-encoded values, it may not be possible to determine the correct encoding just by parsing the percent-encoded values.  
  
 Therefore `http.sys` provides two registry keys for modifying the process:  
  
|Registry Key|Default Value|Description|  
|------------------|-------------------|-----------------|  
|EnableNonUTF8|1|If zero, `http.sys` accepts only UTF-8-encoded URLs.<br /><br /> If non-zero, `http.sys` also accepts ANSI-encoded or DBCS-encoded URLs in requests.|  
|FavorUTF8|1|If non-zero, `http.sys` always tries to decode a URL as UTF-8 first; if that conversion fails and EnableNonUTF8 is non-zero, Http.sys then tries to decode it as ANSI or DBCS.<br /><br /> If zero (and EnableNonUTF8 is non-zero), `http.sys` tries to decode it as ANSI or DBCS; if that is not successful, it tries a UTF-8 conversion.|  
  
 When <xref:System.Net.HttpListener> receives a request, it uses the converted URI from `http.sys` as input to the <xref:System.Net.HttpListenerRequest.Url%2A> property.  
  
 There is a need for supporting characters besides characters and numbers in URIs. An example is the following URI, which is used to retrieve customer information for customer number "1/3812":  
  
 `http://www.contoso.com/Customer('1%2F3812')/`  
  
 Note the percent-encoded slash in the Uri (%2F). This is necessary, since in this case the slash character represents data and not a path delimiter.  
  
 Passing the string to Uri constructor will lead to the following URI:  
  
 `http://www.contoso.com/Customer('1/3812')/`  
  
 Splitting the path into its segments would result in the following elements:  
  
 `Customer('1`  
  
 `3812')`  
  
 This is not the intent of the sender of the request.  
  
 If the **unescapeRequestUrl** attribute is set to **false**, then when the <xref:System.Net.HttpListener> receives a request, it uses the raw URI instead of the converted URI from `http.sys` as input to the <xref:System.Net.HttpListenerRequest.Url%2A> property.  
  
 The default value for the **unescapeRequestUrl** attribute is **true**.  
  
 The <xref:System.Net.Configuration.HttpListenerElement.UnescapeRequestUrl%2A> property can be used to get the current value of the **unescapeRequestUrl** attribute from applicable configuration files.  
  
## Example  
 The following example shows how to configure the <xref:System.Net.HttpListener> class when it receives a request to use the raw URI instead of the converted URI from `http.sys` as input to the <xref:System.Net.HttpListenerRequest.Url%2A> property.  
  
```xml  
<configuration>  
  <system.net>  
    <settings>  
      <httpListener  
        unescapeRequestUrl="false"  
      />  
    </settings>  
  </system.net>  
</configuration>  
```  
  
## Element Information  
  
|||
|-|-|  
|Namespace|System.Net|  
|Schema Name||  
|Validation File||  
|Can be Empty||  
  
## See Also  
 <xref:System.Net.Configuration.HttpListenerElement>  
 <xref:System.Net.HttpListener>  
 <xref:System.Net.HttpListenerRequest.Url%2A>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
