---
title: "Claims Based Authorization Using WIF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e24000a3-8fd8-4c0e-bdf0-39882cc0f6d8
caps.latest.revision: 6
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Claims Based Authorization Using WIF
In a relying party application, authorization determines what resources an authenticated identity is allowed to access and what operations it is allowed to perform on those resources. Improper or weak authorization leads to information disclosure and data tampering. This topic outlines the available approaches to implementing authorization for claims-aware ASP.NET web applications and services using Windows Identity Foundation (WIF) and a Security Token Service (STS), for example, the Windows Azure Access Control Service (ACS).  
  
## Overview  
 Since its first version, the .NET Framework has offered a flexible mechanism for implementing authorization. This mechanism is based on two simple interfaces—**IPrincipal** and **IIdentity**. Concrete implementations of **IIdentity** represent an authenticated user. For example, the **WindowsIdentity** implementation represents a user who is authenticated by Active Directory, and **GenericIdentity** represents a user whose identity is verified via a custom authentication process. Concrete implementations of **IPrincipal** help to check permissions using roles depending on the role store. For example, **WindowsPrincipal** checks **WindowsIdentity** for membership in Active Directory groups. This check is performed by calling the **IsInRole** method on the **IPrincipal** interface. Checking access based on roles is called Role-Based Access Control (RBAC). For more information, see [Role-Based Access Control](../../../docs/framework/security/claims-based-authorization-using-wif.md#BKMK_1).  Claims can be used to carry information about roles to support familiar, role-based authorization mechanisms.  
  
 Claims can also be used to enable more complicated authorization decisions beyond roles. Claims can be based on virtually any information about the user - age, zip code, shoe size, etc. An access control mechanism that is based on arbitrary claims is called claims-based authorization. For more information, see [Claims-based Authorization](../../../docs/framework/security/claims-based-authorization-using-wif.md#BKMK_2).  
  
<a name="BKMK_1"></a>   
## Role-Based Access Control  
 RBAC is an authorization approach in which user permissions are managed and enforced by an application based on user roles. If a user has a role that is required to perform an action, the access is granted; otherwise, access is denied.  
  
### IPrincipal.IsInRole Method  
 To implement the RBAC approach in claims-aware applications, use the **IsInRole()** method in the **IPrinicpal** interface, just as you would in non-claims-aware applications. There are several ways of using the **IsInRole()** method:  
  
-   Explicitly calling on **IPrincipal.IsInRole("Administrator")**. In this approach, the outcome is a Boolean. Use it in your conditional statements. It can be used arbitrarily any place in your code.  
  
-   Using the security demand **PrincipalPermission.Demand()**. In this approach, the outcome is an exception in case the demand is not satisfied. This should fit your exception handling strategy. Throwing exceptions is much more expensive from a performance perspective compared to returning Boolean. This can be used any place in your code.  
  
-   Using the declarative attributes **[PrincipalPermission(SecurityAction.Demand, Role = "Administrator")]**. This approach is called declarative, because it is used to decorate methods. It cannot be used in code blocks inside the method’s implementations. The outcome is an exception in case the demand is not satisfied. You should make sure that it fits your exception-handling strategy.  
  
-   Using URL authorization, using the **\<authorization>** section in **web.config**. This approach is suitable when you are managing authorization on a URL level. This is the most coarse level among those previously mentioned. The advantage of this approach is that changes are made in the configuration file, which means that the code should not be compiled to take advantage of the change.  
  
### Expressing Roles as Claims  
 When the **IsInRole()** method is called, there is a check made to see if the current user has that role. In claims-aware applications, the role is expressed by a role claim type that should be available in the token. The role claim type is expressed using the following URI:  
  
 http://schemas.microsoft.com/ws/2008/06/identity/claims/role  
  
 There are several ways to enrich a token with a role claim type:  
  
-   **During token issuance**. When a user is authenticated the role claim can be issued by the identity provider STS or by a federation provider such as the Windows Azure Access Control Service (ACS).  
  
-   **Transforming arbitrary claims into of claims role type using ClaimsAuthenticationManager**. The ClaimsAuthenticationManager is a component that ships as part of WIF. It allows requests to be intercepted when they launch an application, inspecting tokens and transforming them by adding, changing, or removing claims. For more information about how to use ClaimsAuthenticationManager for transforming claims, see [How To: Implement Role Based Access Control (RBAC) in a Claims Aware ASP.NET Application Using WIF and ACS](http://go.microsoft.com/fwlink/?LinkID=247445) (http://go.microsoft.com/fwlink/?LinkID=247444).  
  
-   **Mapping arbitrary claims to a role type using the samlSecurityTokenRequirement configuration section**—A declarative approach where the claims transformation is done using only the configuration and no coding is required.  
  
<a name="BKMK_2"></a>   
## Claims-based Authorization  
 Claims-based authorization is an approach where the authorization decision to grant or deny access is based on arbitrary logic that uses data available in claims to make the decision. Recall that in the case of RBAC, the only claim used was role type claim. A role type claim was used to check if the user belongs to specific role or not. To illustrate the process of making the authorization decisions using claims-based authorization approach, consider the following steps:  
  
1.  The application receives a request that requires the user is authenticated.  
  
2.  WIF redirects the user to their identity provider, after they are authenticated the application request is made with an associated security token representing the user containing claims about them. WIF associates those claims with the principal that represents the user.  
  
3.  The application passes the claims to the decision logic mechanism. It can be in-memory code, a call to a web service, a query to a database, a sophisticated rules engine, or using the ClaimsAuthorizationManager.  
  
4.  The decision mechanism calculates the outcome based on the claims.  
  
5.  Access is granted if the outcome is true and denied if it is false. For example, the rule might be that the user is of age 21 or above and lives in Washington State.  
  
 <xref:System.Security.Claims.ClaimsAuthorizationManager> is useful for externalizing the decision logic for  claims-based authorization in your applications. ClaimsAuthorizationManager is a WIF component that ships as part of .NET 4.5. ClaimsAuthorizationManager allows you to intercept incoming requests and implement any logic of your choice to make authorization decisions based on the incoming claims. This becomes important when authorization logic needs to be changed. In that case, using ClaimsAuthorizationManager will not affect the application’s integrity, thereby reducing the likelihood of an application error as a result of the change. To learn more about how to use ClaimsAuthorizationManager to implement claims-based access control, see [How To: Implement Claims Authorization in a Claims Aware ASP.NET Application Using WIF and ACS](http://go.microsoft.com/fwlink/?LinkID=247446).
