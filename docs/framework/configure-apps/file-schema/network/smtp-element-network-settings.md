---
title: "&lt;smtp&gt; Element (Network Settings)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/mailSettings/smtp"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#smtp"
helpviewer_keywords: 
  - "<smtp> element"
  - "smtp element"
ms.assetid: 220b0329-e384-4e0c-86b4-0945ad17efd9
caps.latest.revision: 13
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;smtp&gt; Element (Network Settings)
Configures the delivery format, delivery method, and from address for sending emails.  
  
 \<configuration>  
\<system.net>  
\<mailSettings>  
\<smtp>  
  
## Syntax  
  
```xml  
      <smtp  
        deliveryFormat="format"   
        deliveryMethod="method"   
        from="from address">
          <specifiedPickupDirectory> … </ specifiedPickupDirectory >  
          <network> … </network>  
      </smtp>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`deliveryFormat`|Specifies the delivery format for outgoing emails. Acceptable values are SevenBit and International.|  
|`deliveryMethod`|Specifies the delivery method for emails. Acceptable values are network, pickupDirectoryFromIis, and specifiedPickupDirectory.|  
|`from`|Specifies the from address for outgoing emails.|  
  
### Child Elements  
  
|Attribute|Description|  
|---------------|-----------------|  
|`specifiedPickupDirectory`|Configures the local directory for a Simple Mail Transport Protocol (SMTP) server.|  
|`network`|Configures the network options for an external SMTP server.|  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[\<mailSettings> Element (Network Settings)](../../../../../docs/framework/configure-apps/file-schema/network/mailsettings-element-network-settings.md)|Configures mail sending options.|  
  
## Example  
 The following example specifies the appropriate SMTP parameters to send email using the default network credentials.  
  
```xml  
<configuration>  
  <system.net>  
    <mailSettings>  
      <smtp deliveryMethod="network" deliveryFormat="SevenBit"  from="ben@contoso.com">  
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
  
## See Also  
 <xref:System.Net.Configuration.SmtpSection?displayProperty=nameWithType>  
 <xref:System.Net.Mail.SmtpClient?displayProperty=nameWithType>  
 <xref:System.Net.Mail.SmtpDeliveryFormat>  
 <xref:System.Net.Mail.SmtpDeliveryMethod>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
