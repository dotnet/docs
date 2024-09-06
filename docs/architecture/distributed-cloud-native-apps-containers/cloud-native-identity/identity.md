---
title: Cloud-native identity
description: Architecting Cloud Native .NET Apps for Azure | Cloud-native identity
ms.date: 06/03/2024
---

# Cloud-native identity

[!INCLUDE [download-alert](../includes/download-alert.md)]

Most software applications need to have some knowledge of the user or process that is calling them. The user or process interacting with an application is known as a security principal, and the process of authenticating and authorizing these principals is known as identity management, or simply *identity*. Simple applications may include all of their identity management within the application, but this approach doesn't scale well with many applications and many kinds of security principals. Windows supports the use of Active Directory (AD) to provide centralized authentication and authorization.

While this solution is effective within corporate networks, it isn't designed for use by users or applications that are outside of the AD domain. With the growth of Internet-based applications and the rise of cloud-native apps, security models have evolved.

In today's cloud-native identity model, architecture is assumed to be distributed. Apps can be deployed anywhere and may communicate with other apps anywhere. Clients may communicate with these apps from anywhere, and in fact, clients may consist of any combination of platforms and devices. Cloud-native identity solutions use open standards to achieve secure application access from clients. These clients range from human users on PCs or phones, to other apps hosted anywhere online, to set-top boxes and IOT devices running any software platform anywhere in the world. Microsoft Azure Entra ID is Microsoft's cloud-based identity and access management service

Modern cloud-native identity solutions typically use access tokens that are issued by a secure token service/server (STS) to a security principal once their identity is determined. The access token, typically a JSON Web Token (JWT), includes *claims* about the security principal. These claims will minimally include the user's identity but may also include other claims that can be used by applications to determine the level of access to grant the principal.

Typically, the STS is only responsible for authenticating the principal. Determining their level of access to resources is left to other parts of the application.

## References

- [What is the Microsoft identity platform?](https://learn.microsoft.com/en-us/entra/identity-platform/v2-overview)

>[!div class="step-by-step"]
>[Previous](cloud-native-security.md)
>[Next](security-concepts.md)
