---
description: "Learn more about: Debug Windows authentication errors"
title: "Debugging Windows Authentication Errors"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "WCF, authentication"
  - "WCF, Windows authentication"
ms.assetid: 181be4bd-79b1-4a66-aee2-931887a6d7cc
---
# Debug Windows authentication errors

When using Windows authentication as a security mechanism, the Security Support Provider Interface (SSPI) handles security processes. When security errors occur at the SSPI layer, they are surfaced by Windows Communication Foundation (WCF). This topic provides a framework and set of questions to help diagnose the errors.  
  
 For an overview of the Kerberos protocol, see [Kerberos Explained](/previous-versions/windows/it-pro/windows-2000-server/bb742516(v=technet.10)); for an overview of SSPI, see [SSPI](/windows/win32/secauthn/sspi).  
  
 For Windows authentication, WCF typically uses the *Negotiate* Security Support Provider (SSP), which performs Kerberos mutual authentication between the client and service. If the Kerberos protocol is not available, by default WCF falls back to NT LAN Manager (NTLM). However, you can configure WCF to use only the Kerberos protocol (and to throw an exception if Kerberos is not available). You can also configure WCF to use restricted forms of the Kerberos protocol.  
  
## Debugging Methodology  

 The basic method is as follows:  
  
1. Determine whether you are using Windows authentication. If you are using any other scheme, this topic does not apply.  
  
2. If you are sure you are using Windows authentication, determine whether your WCF configuration uses Kerberos direct or Negotiate.  
  
3. Once you have determined whether your configuration is using the Kerberos protocol or NTLM, you can understand error messages in the correct context.  
  
### Availability of the Kerberos Protocol and NTLM  

 The Kerberos SSP requires a domain controller to act as the Kerberos Key Distribution Center (KDC). The Kerberos protocol is available only when both the client and service are using domain identities. In other account combinations, NTLM is used, as summarized in the following table.  
  
 The table headers show possible account types used by the server. The left column shows possible account types used by the client.  
  
|                    | Local User     | Local System   | Domain User    | Domain Machine |
| ------------------ | -------------- | -------------- | -------------- | -------------- |
| **Local User**     | NTLM           | NTLM           | NTLM           | NTLM           |
| **Local System**   | Anonymous NTLM | Anonymous NTLM | Anonymous NTLM | Anonymous NTLM |
| **Domain User**    | NTLM           | NTLM           | Kerberos       | Kerberos       |
| **Domain Machine** | NTLM           | NTLM           | Kerberos       | Kerberos       |
  
 Specifically, the four account types include:  
  
- Local User: Machine-only user profile. For example: `MachineName\Administrator` or `MachineName\ProfileName`.  
  
- Local System: The built-in account SYSTEM on a machine that is not joined to a domain.  
  
- Domain User: A user account on a Windows domain. For example: `DomainName\ProfileName`.  
  
- Domain Machine: A process with machine identity running on a machine joined to a Windows domain. For example: `MachineName\Network Service`.  
  
> [!NOTE]
> The service credential is captured when the <xref:System.ServiceModel.ICommunicationObject.Open%2A> method of the <xref:System.ServiceModel.ServiceHost> class is called. The client credential is read whenever the client sends a message.  
  
## Common Windows Authentication Problems  

 This section discusses some common Windows authentication problems and possible remedies.  
  
### Kerberos Protocol  
  
#### SPN/UPN Problems with the Kerberos Protocol  

 When using Windows authentication, and the Kerberos protocol is used or negotiated by SSPI, the URL the client endpoint uses must include the fully qualified domain name of the service's host inside the service URL. This assumes that the account under which the service is running has access to the machine (default) service principal name (SPN) key that is created when the computer is added to the Active Directory domain, which is most commonly done by running the service under the Network Service account. If the service does not have access to the machine SPN key, you must supply the correct SPN or user principal name (UPN) of the account under which the service is running in the client's endpoint identity. For more information about how WCF works with SPN and UPN, see [Service Identity and Authentication](service-identity-and-authentication.md).  
  
 In load-balancing scenarios, such as Web farms or Web gardens, a common practice is to define a unique account for each application, assign an SPN to that account, and ensure that all of the application's services run in that account.  
  
 To obtain an SPN for your service's account, you need to be an Active Directory domain administrator. For more information, see [Kerberos Technical Supplement for Windows](/previous-versions/msp-n-p/ff649429(v=pandp.10)).  
  
#### Kerberos Protocol Direct Requires the Service to Run Under a Domain Machine Account  

 This occurs when the `ClientCredentialType` property is set to `Windows` and the <xref:System.ServiceModel.MessageSecurityOverHttp.NegotiateServiceCredential%2A> property is set to `false`, as shown in the following code.  
  
 [!code-csharp[C_DebuggingWindowsAuth#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_debuggingwindowsauth/cs/source.cs#1)]
 [!code-vb[C_DebuggingWindowsAuth#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_debuggingwindowsauth/vb/source.vb#1)]  
  
 To remedy, run the service using a Domain Machine account, such as Network Service, on a domain joined machine.  
  
### Delegation Requires Credential Negotiation  

 To use the Kerberos authentication protocol with delegation, you must implement the Kerberos protocol with credential negotiation (sometimes called "multi-leg" or "multi-step" Kerberos). If you implement Kerberos authentication without credential negotiation (sometimes called "one-shot" or "single-leg" Kerberos), an exception will be thrown.  
  
 To implement Kerberos with credential negotiation, do the following steps:  
  
1. Implement delegation by setting <xref:System.ServiceModel.Security.WindowsClientCredential.AllowedImpersonationLevel%2A> to <xref:System.Security.Principal.TokenImpersonationLevel.Delegation>.  
  
2. Require SSPI negotiation:  
  
    1. If you are using standard bindings, set the `NegotiateServiceCredential` property to `true`.  
  
    2. If you are using custom bindings, set the `AuthenticationMode` attribute of the `Security` element to `SspiNegotiated`.  
  
3. Require the SSPI negotiation to use Kerberos by disallowing the use of NTLM:  
  
    1. Do this in code, with the following statement: `ChannelFactory.Credentials.Windows.AllowNtlm = false`  
  
    2. Or you can do this in the configuration file by setting the `allowNtlm` attribute to `false`. This attribute is contained in the [\<windows>](../../configure-apps/file-schema/wcf/windows-of-clientcredentials-element.md).  
  
### NTLM Protocol  
  
#### Negotiate SSP Falls Back to NTLM, but NTLM Is Disabled  

 The <xref:System.ServiceModel.Security.WindowsClientCredential.AllowNtlm%2A> property is set to `false`, which causes Windows Communication Foundation (WCF) to make a best-effort to throw an exception if NTLM is used. Setting this property to `false` may not prevent NTLM credentials from being sent over the wire.  
  
 The following shows how to disable fallback to NTLM.  
  
 [!code-csharp[C_DebuggingWindowsAuth#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_debuggingwindowsauth/cs/source.cs#4)]
 [!code-vb[C_DebuggingWindowsAuth#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_debuggingwindowsauth/vb/source.vb#4)]  
  
#### NTLM Logon Fails  

 The client credentials are not valid on the service. Check that the user name and password are correctly set and correspond to an account that is known to the computer where the service is running. NTLM uses the specified credentials to log on to the service's computer. While the credentials may be valid on the computer where the client is running, this logon will fail if the credentials are not valid on the service's computer.  
  
#### Anonymous NTLM Logon Occurs, but Anonymous Logons Are Disabled by Default  

 When creating a client, the <xref:System.ServiceModel.Security.WindowsClientCredential.AllowedImpersonationLevel%2A> property is set to <xref:System.Security.Principal.TokenImpersonationLevel.Anonymous>, as shown in the following example, but by default the server disallows anonymous logons. This occurs because the default value of the <xref:System.ServiceModel.Security.WindowsServiceCredential.AllowAnonymousLogons%2A> property of the <xref:System.ServiceModel.Security.WindowsServiceCredential> class is `false`.  
  
 The following client code attempts to enable anonymous logons (note that the default property is `Identification`).  
  
 [!code-csharp[C_DebuggingWindowsAuth#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_debuggingwindowsauth/cs/source.cs#5)]
 [!code-vb[C_DebuggingWindowsAuth#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_debuggingwindowsauth/vb/source.vb#5)]  
  
 The following service code changes the default to enable anonymous logons by the server.  
  
 [!code-csharp[C_DebuggingWindowsAuth#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_debuggingwindowsauth/cs/source.cs#6)]
 [!code-vb[C_DebuggingWindowsAuth#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_debuggingwindowsauth/vb/source.vb#6)]  
  
 For more information about impersonation, see [Delegation and Impersonation](delegation-and-impersonation-with-wcf.md).  
  
 Alternatively, the client is running as a Windows service, using the built-in account SYSTEM.  
  
### Other Problems  
  
#### Client Credentials Are Not Set Correctly  

 Windows authentication uses the <xref:System.ServiceModel.Security.WindowsClientCredential> instance returned by the <xref:System.ServiceModel.ClientBase%601.ClientCredentials%2A> property of the <xref:System.ServiceModel.ClientBase%601> class, not the <xref:System.ServiceModel.Security.UserNamePasswordClientCredential>. The following shows an incorrect example.  
  
 [!code-csharp[C_DebuggingWindowsAuth#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_debuggingwindowsauth/cs/source.cs#2)]
 [!code-vb[C_DebuggingWindowsAuth#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_debuggingwindowsauth/vb/source.vb#2)]  
  
 The following shows the correct example.  
  
 [!code-csharp[C_DebuggingWindowsAuth#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_debuggingwindowsauth/cs/source.cs#3)]
 [!code-vb[C_DebuggingWindowsAuth#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_debuggingwindowsauth/vb/source.vb#3)]  
  
#### SSPI Is Not Available  

 The following operating systems do not support Windows authentication when used as a server: Windows XP Home Edition, Windows XP Media Center Edition, and Windows Vista Home editions.  
  
#### Developing and Deploying with Different Identities  

 If you develop your application on one machine, and deploy on another, and use different account types to authenticate on each machine, you may experience different behavior. For example, suppose you develop your application on a Windows XP Pro machine using the `SSPI Negotiated` authentication mode. If you use a local user account to authenticate with, then NTLM protocol will be used. Once the application is developed, you deploy the service to a Windows Server 2003 machine where it runs under a domain account. At this point, the client will not be able to authenticate the service because it will be using Kerberos and a domain controller.  
  
## See also

- <xref:System.ServiceModel.Security.WindowsClientCredential>
- <xref:System.ServiceModel.Security.WindowsServiceCredential>
- <xref:System.ServiceModel.Security.WindowsClientCredential>
- <xref:System.ServiceModel.ClientBase%601>
- [Delegation and Impersonation](delegation-and-impersonation-with-wcf.md)
- [Unsupported Scenarios](unsupported-scenarios.md)
