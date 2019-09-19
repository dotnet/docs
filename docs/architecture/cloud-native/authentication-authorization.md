---
title: Authentication and Authorization in cloud-native apps
description: Architecting Cloud Native .NET Apps for Azure | Authentication and Authorization in Cloud Native Apps
ms.date: 06/30/2019
---
# Authentication and authorization in cloud-native apps

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

*Authentication* is the process of determining the identity of a security principal. *Authorization* is the act of granting an authenticated principal permission to perform an action or access a resource. Sometimes authentication is shortened to `AuthN` and authorization is shortened to `AuthZ`. Cloud native applications need to rely on open HTTP-based protocols to authenticate security principals since both clients and applications could be running anywhere in the world on any platform or device. The only common factor is HTTP.

Many organizations still rely on local authentication services like Active Directory Federation Services (ADFS). While this approach has traditionally served organizations well for on premises authentication needs, cloud-native applications benefit from systems designed specifically for the cloud. A recent 2019 United Kingdom National Cyber Security Centre (NCSC) advisory states that "organizations using Azure AD as their primary authentication source will actually lower their risk compared to ADFS." Some reasons outlined in [this analysis](https://oxfordcomputergroup.com/resources/o365-security-native-cloud-authentication/) include:

- Access to full set of Microsoft credential protection technologies.
- Most organizations are already relying on Azure AD to some extent.
- Double hashing of NTLM hashes ensures compromise won't allow credentials that work in local Active Directory.

## References

- [Authentication basics](https://docs.microsoft.com/azure/active-directory/develop/authentication-scenarios)
- [Access tokens and claims](https://docs.microsoft.com/azure/active-directory/develop/access-tokens)
- [It may be time to ditch your on premises authentication services](https://oxfordcomputergroup.com/resources/o365-security-native-cloud-authentication/)

>[!div class="step-by-step"]
>[Previous](identity.md)
>[Next](azure-active-directory.md)
