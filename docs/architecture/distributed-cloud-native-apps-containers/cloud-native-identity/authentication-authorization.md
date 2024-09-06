---
title: Authentication and authorization in cloud-native apps
description: Architecting Cloud Native .NET Apps for Azure | Authentication and authorization in cloud native apps
ms.date: 04/06/2022
---

# Authentication and authorization in cloud-native apps

[!INCLUDE [download-alert](../includes/download-alert.md)]

*Authentication* is the process of determining the identity of a security principal. *Authorization* is the act of granting an authenticated principal permission to perform an action or access a resource. Sometimes authentication is shortened to `AuthN` and authorization is shortened to `AuthZ`. Cloud-native applications need to rely on open HTTP-based protocols to authenticate security principals since both clients and applications could be running anywhere in the world on any platform or device. The only common factor is HTTP.

Many organizations still rely on local authentication services like Active Directory Federation Services (ADFS). While this approach has traditionally served organizations well for on premises authentication needs, cloud-native applications benefit from systems designed specifically for the cloud. Some benefits of moving from ADFS to Entra ID are outlined in [this analysis](https://oxfordcomputergroup.com/resources/migrate-adfs-entra-id-benefits-best-practices/) including:

- Easier single sign-on to thousands of apps, including legacy, SaaS, and third-party apps.
- Improve your organization’s security posture.
- Improve risk management, compliance, and governance capabilities by eliminating on-premises infrastructure.
- Reduce infrastructure costs.
- Implement a single control plane for identity and access management.
- Streamline the user experience for accessing organization apps.

## References

- [Authentication basics](/azure/active-directory/develop/authentication-scenarios)
- [Access tokens and claims](/azure/active-directory/develop/access-tokens)
- [Migrating from ADFS to Microsoft Entra ID: Benefits and Best Practices](https://oxfordcomputergroup.com/resources/migrate-adfs-entra-id-benefits-best-practices/)

>[!div class="step-by-step"]
>[Previous](azure-security.md)
>[Next](azure-entra.md)
