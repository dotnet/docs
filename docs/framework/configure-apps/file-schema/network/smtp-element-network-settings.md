---
title: "<smtp> Element (Network Settings)"
description: The <smtp> network settings element configures the delivery format, delivery method, and from address for sending emails options in the .NET Framework.
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/mailSettings/smtp"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#smtp"
helpviewer_keywords: 
  - "<smtp> element"
  - "smtp element"
ms.assetid: 220b0329-e384-4e0c-86b4-0945ad17efd9
---
# \<smtp> Element (Network Settings)

Configures the delivery format, delivery method, and from address for sending emails.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.net>**](system-net-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<mailSettings>**](mailsettings-element-network-settings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<smtp>**
  
## Syntax  
  
```xml  
<smtp  
  deliveryFormat="format"  
  deliveryMethod="method"  
  from="from address">
    <specifiedPickupDirectory>...</specifiedPickupDirectory>  
    <network>...</network>  
</smtp>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`deliveryFormat`|Specifies the delivery format for outgoing emails. Acceptable values are SevenBit and International.|  
|`deliveryMethod`|Specifies the delivery method for emails. Acceptable values are Network, PickupDirectoryFromIis, and SpecifiedPickupDirectory.|  
|`from`|Specifies the from address for outgoing emails.|  
  
### Child Elements  
  
|Attribute|Description|  
|---------------|-----------------|  
|`specifiedPickupDirectory`|Configures the local directory for a Simple Mail Transport Protocol (SMTP) server.|  
|`network`|Configures the network options for an external SMTP server.|  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[\<mailSettings> Element (Network Settings)](mailsettings-element-network-settings.md)|Configures mail sending options.|  
  
## Example  

 The following example specifies the appropriate SMTP parameters to send email using the default network credentials.  
  
```xml  
<configuration>  
  <system.net>  
    <mailSettings>  
      <smtp deliveryMethod="Network" deliveryFormat="SevenBit"  from="ben@contoso.com">  
        <network  
          host="localhost"  
          port="25"  
          defaultCredentials="true"  
        />  
      </smtp>  
    </mailSettings>  
  </system.net>  
</configuration>  
```  
  
## See also

- <xref:System.Net.Configuration.SmtpSection?displayProperty=nameWithType>
- <xref:System.Net.Mail.SmtpClient?displayProperty=nameWithType>
- <xref:System.Net.Mail.SmtpDeliveryFormat>
- <xref:System.Net.Mail.SmtpDeliveryMethod>
- [Network Settings Schema](index.md)
