---
title: Identity
description: Architecting Cloud Native .NET Apps for Azure | Identity
ms.date: 06/30/2019
---
# Identity

Most software applications need to have some knowledge of the user or process that is calling them. The user or process interacting with an application is known as a security principal, and the process of authenticating and authorizing these principals is known as identity management, or simply *identity*. Simple applications may include all of their identity management within the application, but this doesn't scale well with many applications and many kinds of security principals. Windows supports the use of Active Directory to provide centralized authentication and authorization.

(insert figure showing Windows AD auth model)

While this solution is very effective within corporate networks, it is not designed for use by users or applications that reside outside of the AD domain. With the growth of Internet-based applications and the rise of cloud native apps, security models have evolved.

In today's cloud native identity model, architecture is assumed to be distributed. Apps can be deployed anywhere and may communicate with others apps anywhere. Clients may communicate with these apps from anywhere, and in fact, clients may consist of any combination of platforms and devices. Cloud native identity solutions leverage open standards to achieve secure application access from clients ranging from human users on PCs or phones to other apps hosted anywhere online to set-top boxes and IOT devices running any software platform anywhere in the world.

Modern cloud native identity solutions typically leverage access tokens issued by a secure token service/server (STS) to a security principal once their identity has been determined. The access token, typically a JSON Web Token (JWT), includes *claims* about the security principal. These claims will minimally include the user's identity but may also include additional claims that can be used by applications to determine the level of access to grant the principal.

(insert figure showing basic handshake involve a principal, an STS, and an app)

Typically, the STS is only responsible for authenticating the principal. Determining their level of access to resources is left to other parts of the application.

## References

- [Microsoft Identity Platform](https://docs.microsoft.com/azure/active-directory/develop/)

>[!div class="step-by-step"]
>[Previous](identity.md)
>[Next](authentication-authorization.md)
