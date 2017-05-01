---
title: "&lt;mailSettings&gt; Element (Network Settings) | Microsoft Docs"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#mailSettings"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/mailSettings"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
helpviewer_keywords: 
  - "mailSettings element"
  - "<mailSettings> element"
ms.assetid: 54f0f153-17e5-4f49-afdc-deadb940c9c1
caps.latest.revision: 20
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
---
# &lt;mailSettings&gt; Element (Network Settings)
Configures mail sending options.  
  
 \<configuration>  
\<system.net>  
\<mailSettings>  
  
## Syntax  
  
```  
  
      <mailSettings  
  <smtp> … </smtp>  
/mailsettings>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Attribute|Description|  
|---------------|-----------------|  
|[\<smtp> Element (Network Settings)](../../../../../docs/framework/configure-apps/file-schema/network/smtp-element-network-settings.md)|Configures Simple Mail Transport Protocol options.|  
  
### Parent Elements  
  
|**Element**|**Description**|  
|-----------------|---------------------|  
|[\<system.Net> Element (Network Settings)](../../../../../docs/framework/configure-apps/file-schema/network/system-net-element-network-settings.md)|Contains settings that specify how the .NET Framework connects to the network.|  
  
## Example  
 The following code example specifies the appropriate SMTP parameters to send e-mail using the default network credentials.  
  
```  
<configuration>  
  <system.net>  
    <mailSettings>  
      <smtp deliveryMethod="network">  
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
 <xref:System.Net.Mail.SmtpClient>   
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)