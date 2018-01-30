---
title: "&lt;network&gt; Element (Network Settings)"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#network"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.net/mailSettings/smtp/network"
helpviewer_keywords: 
  - "<network> element"
  - "network element"
ms.assetid: 2c2c6ad4-ed11-48ab-b28e-2bc0ba9b42c7
caps.latest.revision: 13
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;network&gt; Element (Network Settings)
Configures the network options for an external Simple Mail Transport Protocol (SMTP) server.  
  
 \<configuration>  
\<system.net>  
\<mailSettings>  
\<smtp>  
\<network>  
  
## Syntax  
  
```xml  
<network  
  clientDomain="string"   
  defaultCredentials="true|false"  
  enableSsl="true|false"  
  host="string"   
  password="string"  
  port="integer"   
  targetName="string"  
  userName="string"  
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`clientDomain`|Specifies the client domain name to use in the initial SMTP protocol request to connect to the SMTP mail server. The default value is the localhost name of the local computer sending the request.|  
|`defaultCredentials`|Specifies whether the default user credentials should be used to access the SMTP mail server for SMTP transactions. The default value is `false`.|  
|`enableSsl`|Specifies whether SSL is used to access an SMTP mail server. The default value is `false`.|  
|`host`|Specifies the hostname of the SMTP mail server to use for SMTP transactions. This attribute has no default value.|  
|`password`|Specifies the password to use for authentication to the SMTP mail server. This attribute has no default value.|  
|`port`|Specifies the port number to use to connect to the SMTP mail server. The default value is 25.|  
|`targetName`|Specifies the Service Provider Name (SPN) to use for authentication when using extended protection for SMTP transactions. This attribute has no default value.|  
|`userName`|Specifies the user name to use for authentication to the SMTP mail server. This attribute has no default value.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<smtp> Element (Network Settings)](../../../../../docs/framework/configure-apps/file-schema/network/smtp-element-network-settings.md)|Configures Simple Mail Transport Protocol (SMTP) mail sending options.|  
  
## Remarks  
 Some SMTP servers require that you authenticate yourself to the server before use. If you want to authenticate yourself using the default network credentials on your host, set the `defaultCredentials` attribute to `true`. The <xref:System.Net.Configuration.SmtpNetworkElement.DefaultCredentials%2A?displayProperty=nameWithType> property can be used to get the current value of the `defaultCredentials` attribute from applicable configuration files.  
  
 You can also use basic authentication (a user name and password) to authenticate yourself to the SMTP server. To use this option, you must specify a valid user name and password for the specified SMTP server.  
  
> [!NOTE]
>  Basic authentication sends the `userName` and `password` values to the server unencrypted. Anyone monitoring network traffic can view your credentials and use them to connect to the server. You should consider using a more secure authentication mechanism, such as Kerberos or NT LAN Manager (NTLM.) If `defaultCredentials` is `true`, Kerberos or NTLM will be used if the server supports these protocols.  
  
 The basic authentication and default network credentials options are mutually exclusive; if you set `defaultCredentials` to `true` and specify a user name and password, the default network credential is used, and the basic authentication data is ignored.  
  
 For basic authentication if you specify a `userName`, you should also specify a `password` to authentication yourself to the mail server.  
  
 The <xref:System.Net.Configuration.SmtpNetworkElement.UserName%2A?displayProperty=nameWithType> property can be used to get the current value of the `userName` attribute from applicable configuration files. The <xref:System.Net.Configuration.SmtpNetworkElement.Password%2A?displayProperty=nameWithType> property can be used to get the current value of the `password` attribute from applicable configuration files. A `password` attribute would not normally be entered in configuration files for security reasons.  
  
 The `clientDomain` attribute changes the client domain name used in the initial SMTP protocol request to an SMTP server. The `clientDomain` attribute can be set to the fully-qualified domain name of the local machine, rather than the localhost name that is used by default. This provides greater compliance with the SMTP protocol standards. The default value is the localhost name of the local computer sending the request. The <xref:System.Net.Configuration.SmtpNetworkElement.ClientDomain%2A?displayProperty=nameWithType> property can be used to get the current value of the `clientDomain` attribute from applicable configuration files.  
  
 The `targetName` attribute is used for authentication when using extended protection. The default value is of the form "SMTPSVC/\<host>" where \<host> is the hostname of the SMTP mail server. The <xref:System.Net.Configuration.SmtpNetworkElement.TargetName%2A?displayProperty=nameWithType> property can be used to get the current value of the `targetName` attribute from applicable configuration files.  
  
 The `enableSsl` attribute specifies whether SSL is used to access an SMTP mail server. The <xref:System.Net.Mail.SmtpClient?displayProperty=nameWithType> class only supports the SMTP Service Extension for Secure SMTP over Transport Layer Security as defined in RFC 3207. In this mode, the SMTP session begins on an unencrypted channel, then a STARTTLS command is issued by the client to the server to switch to secure communication using SSL. See RFC 3207 published by the Internet Engineering Task Force (IETF) for more information.  
  
 An alternate connection method is where an SSL session is established up front before any protocol commands are sent. This connection method is sometimes called SMTPS and by default uses port 465. This alternate connection method using SSL is not currently supported.  
  
 The <xref:System.Net.Configuration.SmtpNetworkElement.EnableSsl%2A?displayProperty=nameWithType> property can be used to get the current value of the `enableSsl` attribute from applicable configuration files.  
  
## Example  
 The following example specifies the appropriate SMTP parameters to send email using the default network credentials.  
  
```xml  
<configuration>  
  <system.net>  
    <mailSettings>  
      <smtp deliveryMethod="network">  
        <network  
          clientDomain="www.contoso.com"  
          defaultCredentials="true"  
          enableSsl="false"  
          host="mail.contoso.com"  
          port="25"  
        />  
      </smtp>  
    </mailSettings>  
  </system.net>  
</configuration>  
```  
  
## See Also  
 <xref:System.Net.Configuration.SmtpNetworkElement?displayProperty=nameWithType>  
 <xref:System.Net.Configuration.SmtpSection?displayProperty=nameWithType>  
 <xref:System.Net.Mail.SmtpClient?displayProperty=nameWithType>  
 [Network Settings Schema](../../../../../docs/framework/configure-apps/file-schema/network/index.md)
