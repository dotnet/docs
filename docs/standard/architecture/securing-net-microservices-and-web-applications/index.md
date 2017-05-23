---
title: Securing .NET Microservices and Web Applications | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Securing .NET Microservices and Web Applications
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
-   [Implementing authentication in .NET microservices and web applications ](#implementing-authentication-in-.net-microservices-and-web-applications)
    -   [Authenticating using ASP.NET Core Identity](#authenticating-using-asp.net-core-identity)
    -   [Authenticating using external providers](#authenticating-using-external-providers)
    -   [Authenticating with bearer tokens](#authenticating-with-bearer-tokens)
        -   [Authenticating with an OpenID Connect or OAuth 2.0 Identity provider](#authenticating-with-an-openid-connect-or-oauth-2.0-identity-provider)
        -   [Issuing security tokens from an ASP.NET Core service](#issuing-security-tokens-from-an-asp.net-core-service)
        -   [Consuming security tokens](#consuming-security-tokens)
        -   [Additional resources](#additional-resources)
-   [About authorization in .NET microservices and web applications](#about-authorization-in-.net-microservices-and-web-applications)
    -   [Implementing role-based authorization](#implementing-role-based-authorization)
    -   [Implementing policy-based authorization](#implementing-policy-based-authorization)
        -   [Additional resources](#additional-resources-1)
-   [Storing application secrets safely during development](#storing-application-secrets-safely-during-development)
    -   [Storing secrets in environment variables](#storing-secrets-in-environment-variables)
    -   [Storing secrets using the ASP.NET Core Secret Manager](#storing-secrets-using-the-asp.net-core-secret-manager)
-   [Using Azure Key Vault to protect secrets at production time](#using-azure-key-vault-to-protect-secrets-at-production-time)
    -   [Additional resources](#additional-resources-2)



>[!div class="step-by-step"]
[Previous] (../implementing-resilient-applications/health-monitoring.md)
[Next] (implementing-authentication-in-.net-microservices-and-web-applications-.md)
