---
title: Keycloak
description: Architecting Cloud Native .NET Apps for Azure | Keycloak
ms.date: 04/06/2022
---

# Keycloak: An open source identity and access management solution

Keycloak, an open-source identity and access management (IAM) solution, stands out as a robust platform designed to simplify the complexities of modern authentication and authorization processes.

## Simplifying authentication with Single Sign-On (SSO)

Keycloak’s SSO capability is a significant feature that streamlines the user experience. It allows users to authenticate once and gain access to multiple applications without the need to log in again for each service. This not only enhances user convenience but also reduces the potential for password fatigue and the associated security risks.

## Social login and identity brokering

The platform supports social login, which enables users to sign in with their existing social media accounts, such as Facebook or Google, through a straightforward configuration in the admin console. Additionally, Keycloak can act as an identity broker, interfacing with other OpenID Connect or SAML 2.0 identity providers, further centralizing and simplifying user authentication.

## User federation and management

Keycloak can integrate with existing LDAP or Active Directory servers, allowing organizations to leverage their current user directories. For those with users in non-standard stores, Keycloak offers the flexibility to implement custom user federation providers.

## Comprehensive administration and account management

Administrators benefit from Keycloak’s comprehensive administration console, which provides centralized control over the server’s features, including user federation, identity brokering, and the creation of fine-grained authorization policies. Users, on the other hand, can manage their accounts through the account management console, handling tasks such as profile updates, password changes, and two-factor authentication setup.

## Adherence to standard protocols

Keycloak adheres to standard protocols like OpenID Connect, OAuth 2.0, and SAML, ensuring compatibility and ease of integration with a wide range of applications and services.

## Fine-grained authorization services

Beyond role-based authorization, Keycloak offers fine-grained authorization services, allowing administrators to define precise access policies for their services directly from the administration console.

## References

For more detailed information and the latest updates on Keycloak, you can visit their [official website](https://www.keycloak.org/).

>[!div class="step-by-step"]
>[Previous](identity-server.md)
>[Next]
