---
title: "JSON Web Token Handler"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9968f12e-e05d-4e6a-9b65-6896c0e31ab1
caps.latest.revision: 5
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# JSON Web Token Handler
The JSON Web Token Handler extension for Windows Identity Foundation enables you to create and validate JSON Web Tokens (JWT) in your applications. The JWT Token Handler can be configured to run in the WIF pipeline like other built-in security token handlers, but it can also be used independently to perform token validation in lightweight applications. The JWT Token Handler is particularly useful when using an OAuth 2.0 bearer token scheme, such as authenticating to Windows Azure Active Directory.  
  
 The JWT Token Handler is available as a NuGet package. See [Downloading the JSON Web Token Handler Package](../../../docs/framework/security/downloading-the-json-web-token-handler-package.md) for more information.  
  
## Scenarios  
 The JWT Token Handler enables the following key scenarios:  
  
-   **Validate a JWT Token in a Server Application**: In this scenario, a company named Litware has a server application that uses WIF to handle web sign-on requests. Litware wants to enable their application to use JWT tokens for authentication. The application is updated with the JWT Token Handler, and then the application configuration is updated to add the JWT Token Handler in the WIF pipeline. After the updates have been made and a new request enters the WIF pipeline, the JWT token is validated using the new handler and successful authentication occurs.  
  
-   **Validate a JWT Token in a REST Web Service**: In this scenario, a company named Litware has a REST web service that is secured by Windows Azure Active Directory. Requests to the web service must be authenticated by Windows Azure AD, which issues a JWT token upon successful authentication. Litware has a client application that needs to access the web service. The client makes a request to the web service and presents its JWT token from Windows Azure AD, which is then validated by the web service using the JWT Token Handler. After the JWT Token Handler has validated the token, the desired resource is returned to the client by the web service.  
  
## Features  
 The JWT Token Handler offers the following features:  
  
-   **Validate a JWT Token**: JWT tokens can be easily validated by the token handler’s validation logic, either as a part of the application’s WIF pipeline or called independently of WIF  
  
-   **Create a JWT Token**: The JWT Token Handler can be used to create JWT tokens for authorization in downstream services
