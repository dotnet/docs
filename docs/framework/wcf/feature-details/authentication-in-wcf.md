---
title: "Authentication in WCF"
description: Learn about several mechanisms in WCF that provide authentication, such as Windows authentication, X.509 certificates, and user name and password.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "authentication [WCF]"
  - "security [WCF], authentication"
ms.assetid: 9254d873-843d-4c6e-bea4-8184ac3e44f4
ms.topic: article
---
# Authentication in WCF

The following topics show a number of different mechanisms in Windows Communication Foundation (WCF) that provide authentication, for example, Windows authentication, X.509 certificates, and user name and passwords.

## In This Section

 [How to: Use the ASP.NET Membership Provider](how-to-use-the-aspnet-membership-provider.md)
 ASP.NET features include a membership and role provider, a database to store user name/password pairs for authentication, and user roles for authorization. This topic explains how WCF services can use the same database to authenticate and authorize users.

 [Service Identity and Authentication](service-identity-and-authentication.md)
 As an extra safeguard, a client can authenticate the service by specifying the expected *identity* of the service. If the expected identity and the identity returned by the service do not match, authentication fails.

 [Security Negotiation and Timeouts](security-negotiation-and-timeouts.md)
 Describes how to use the <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings.NegotiationTimeout%2A> property in the <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings> class.

 [Debugging Windows Authentication Errors](debugging-windows-authentication-errors.md)
 Focuses on common problems encountered when using Windows authentication.

## Reference

 <xref:System.ServiceModel>

## Related Sections

 [Common Security Scenarios](common-security-scenarios.md)

## See also

- [Security Overview](security-overview.md)
- [Security Model for Windows Server App Fabric](/previous-versions/appfabric/ee677202(v=azure.10))
