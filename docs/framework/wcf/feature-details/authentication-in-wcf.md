---
title: "Authentication in WCF"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "authentication [WCF]"
  - "security [WCF], authentication"
ms.assetid: 9254d873-843d-4c6e-bea4-8184ac3e44f4
---
# Authentication in WCF
The following topics show a number of different mechanisms in Windows Communication Foundation (WCF) that provide authentication, for example, Windows authentication, X.509 certificates, and user name and passwords.  
  
## In This Section  
 [How to: Use the ASP.NET Membership Provider](../../../../docs/framework/wcf/feature-details/how-to-use-the-aspnet-membership-provider.md)  
 ASP.NET features include a membership and role provider, a database to store user name/password pairs for authentication, and user roles for authorization. This topic explains how WCF services can use the same database to authenticate and authorize users.  
  
 [How to: Use a Custom User Name and Password Validator](../../../../docs/framework/wcf/feature-details/how-to-use-a-custom-user-name-and-password-validator.md)  
 Demonstrates how to integrate a custom user name/password validator.  
  
 [Service Identity and Authentication](../../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md)  
 As an extra safeguard, a client can authenticate the service by specifying the expected *identity* of the service. If the expected identity and the identity returned by the service do not match, authentication fails.  
  
 [Security Negotiation and Timeouts](../../../../docs/framework/wcf/feature-details/security-negotiation-and-timeouts.md)  
 Describes how to use the <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings.NegotiationTimeout%2A> property in the <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings> class.  
  
 [Debugging Windows Authentication Errors](../../../../docs/framework/wcf/feature-details/debugging-windows-authentication-errors.md)  
 Focuses on common problems encountered when using Windows authentication.  
  
## Reference  
 <xref:System.ServiceModel>  
  
## Related Sections  
 [Common Security Scenarios](../../../../docs/framework/wcf/feature-details/common-security-scenarios.md)  
  
## See also

- [Security Overview](../../../../docs/framework/wcf/feature-details/security-overview.md)
- [Security Model for Windows Server App Fabric](https://go.microsoft.com/fwlink/?LinkID=201279&clcid=0x409)
