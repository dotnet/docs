---
title: "Mitigation: TLS Protocols"
description: Learn about the impact and mitigation for the TLS Protocol changes beginning with .NET Framework 4.6.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 33f97d13-3022-43da-8b18-cdb5c88df9c2
---
# Mitigation: TLS Protocols

Starting with .NET Framework 4.6, the <xref:System.Net.ServicePointManager?displayProperty=nameWithType> and <xref:System.Net.Security.SslStream?displayProperty=nameWithType> classes negotiate TLS 1.0, TLS 1.1, or TLS 1.2 based on OS support. The SSL 3.0 protocol and RC4 cipher are not supported.

> [!WARNING]
> This article documents a legacy compatibility change in .NET Framework 4.6. For current deployments, use operating system defaults and allow only TLS 1.2 or TLS 1.3 when available. For more information, see [Transport Layer Security (TLS) best practices with the .NET Framework](../network-programming/tls.md).
  
## Impact  

 This change affects:  
  
- Any app that uses SSL to talk to an HTTPS server or a socket server using any of the following types: <xref:System.Net.Http.HttpClient>, <xref:System.Net.HttpWebRequest>, <xref:System.Net.FtpWebRequest>, <xref:System.Net.Mail.SmtpClient>, and <xref:System.Net.Security.SslStream>.  
  
- Any server-side app that cannot be upgraded to support modern TLS configurations, ideally TLS 1.2 or later.
  
## Mitigation  

 The recommended mitigation is to upgrade the server-side app to support modern TLS configurations. If that isn't feasible, or if client apps are broken, the <xref:System.AppContext> class can be used to opt out of this feature in either of two ways as a temporary compatibility workaround:
  
- Programmatically, by using a code snippet like the following:  
  
     [!code-csharp[AppCompat.SSLProtocols#1](../../../samples/snippets/csharp/VS_Snippets_CLR/appcompat.sslprotocols/cs/program.cs#1)]
     [!code-vb[AppCompat.SSLProtocols#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/appcompat.sslprotocols/vb/module1.vb#1)]  
  
     Because the <xref:System.Net.ServicePointManager> object is initialized only once, defining these compatibility settings must be the first thing the application does.  
  
- By adding the following line to the [\<runtime>](../configure-apps/file-schema/runtime/runtime-element.md) section of your app.config file:  
  
    ```xml  
    <AppContextSwitchOverrides value="Switch.System.Net.DontEnableSchUseStrongCrypto=true"/>  
    ```  
  
 Note, however, that opting out of the default behavior is not recommended, since it makes the application less secure.
  
## See also

- [Application compatibility](application-compatibility.md)
