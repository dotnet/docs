---
title: "<specifiedPickupDirectory> Element (Network Settings)"
description: The <specifiedPickupDirectory> network settings element configures the local directory for an SMTP server options in the .NET Framework.
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#specifiedPickupDirectory"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/mailSettings/smtp/specifiedPickupDirectory"
helpviewer_keywords: 
  - "specifiedPickupDirectory element"
  - "<specifiedPickupDirectory> element"
ms.assetid: 0121f49d-bff2-4bc6-af06-f1628dcd61f1
---
# \<specifiedPickupDirectory> Element (Network Settings)

Configures the local directory for a Simple Mail Transport Protocol (SMTP) server.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<mailSettings>**](mailsettings-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<smtp>**](smtp-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<specifiedPickupDirectory>**  
  
## Syntax  
  
```xml  
<specifiedPickupDirectory  
  pickupDirectoryLocation="directory"
/>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`pickupDirectoryLocation`|The directory where applications save email for later processing by the SMTP server.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<smtp> Element (Network Settings)](smtp-element-network-settings.md)|Configures Simple Mail Transport Protocol (SMTP) mail sending options.|  
  
## Remarks  

 The `specifiedPickupDirectory` attribute sets the directory where applications save mail messages to be processed by the SMTP server.  
  
## Example  

 The following example specifies c:\maildrop as the mail pickup directory.  
  
```xml  
<configuration>  
  <system.net>  
    <mailSettings>  
      <smtp deliveryMethod="SpecifiedPickupDirectory">  
        <specifiedPickupDirectory  
          pickupDirectoryLocation="c:\maildrop"  
        />  
      </smtp>  
    </mailSettings>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.Mail.SmtpClient?displayProperty=nameWithType>
- <xref:System.Net.Configuration.SmtpSection?displayProperty=nameWithType>
- <xref:System.Net.Configuration.SmtpSpecifiedPickupDirectoryElement?displayProperty=nameWithType>
- [Network Settings Schema](index.md)
