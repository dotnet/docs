---
title: "Validating Issuer Name Registry"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c4644dd1-dead-48ff-abeb-7bffae69a6ac
caps.latest.revision: 4
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Validating Issuer Name Registry
The Validating Issuer Name Registry (VINR) for Windows Identity Foundation enables multi-tenant applications to ensure that an incoming token has been issued by a trusted tenant and identity provider. This functionality is particularly useful for multi-tenant applications that use Windows Azure Active Directory because all tokens issued by Windows Azure AD are signed using the same certificate. In order to differentiate between requests from multiple tenants that use the same certificate – and consequently have the same thumbprint – your application must persist the issuer name for each tenant to perform validation logic. The VINR provides this functionality, and it also enables you to add custom validation logic or to store the issuer registry data in locations other than a configuration file. The extension can be added to your application’s WIF pipeline or it can be used independently.  
  
 The VINR is available as a NuGet package. See [Downloading the Validating Issuer Name Registry Package](../../../docs/framework/security/downloading-the-validating-issuer-name-registry-package.md) for more information.  
  
## Scenarios  
 The VINR enables the following key scenario:  
  
-   **Validate a Token in a Multi-Tenant Application**: In this scenario, a company named Litware has developed a multi-tenant application that uses an identity provider such as Windows Azure AD. This application serves two customers: Contoso and Fabrikam. When a user from Fabrikam authenticates to Litware’s application, the resulting token from Windows Azure AD is signed using its standard certificate and the request is issued by Fabrikam. The application needs to verify that both the issuer name and the token is valid, and needs to differentiate requests from Contoso that are signed using the same certificate from Windows Azure AD. The VINR makes it easy for Litware’s application to differentiate and validate requests from multiple tenants such as Contoso and Fabrikam.  
  
## Features  
 The VINR offers the following features:  
  
-   **Issuer Name and Token Validation for Multi-Tenant Applications**: Validates the incoming token by verifying the issuer name (tenant) and whether the token was signed using a valid certificate from the identity provider.  
  
-   **Extensibility for Custom Validation Logic and Data Stores**: Provides extensibility to inject your own validation logic and to specify a data store other than the default configuration file.
