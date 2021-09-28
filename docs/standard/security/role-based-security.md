---
description: "Learn more about: Role-Based Security"
title: "Role-Based Security"
ms.date: 07/15/2020
helpviewer_keywords: 
  - "role-based security, about role-based security"
  - "user authentication, principals"
  - "principals [.NET]"
  - "security [.NET], role-based"
  - "permissions [.NET], principals"
  - "authentication [.NET], principals"
  - "role-based security, principals"
ms.assetid: 578cc32b-5654-4d8b-9d8c-ebcbc5c75390
---
# Role-Based Security

Roles are often used in financial or business applications to enforce policy. For example, an application might impose limits on the size of the transaction being processed depending on whether the user making the request is a member of a specified role. Clerks might have authorization to process transactions that are less than a specified threshold, supervisors might have a higher limit, and vice-presidents might have a still higher limit (or no limit at all). Role-based security can also be used when an application requires multiple approvals to complete an action. Such a case might be a purchasing system in which any employee can generate a purchase request, but only a purchasing agent can convert that request into a purchase order that can be sent to a supplier.  
  
 .NET role-based security supports authorization by making information about the principal, which is constructed from an associated identity, available to the current thread. The identity (and the principal it helps to define) can be either based on a Windows account or be a custom identity unrelated to a Windows account. .NET applications can make authorization decisions based on the principal's identity or role membership, or both. A role is a named set of principals that have the same privileges with respect to security (such as a teller or a manager). A principal can be a member of one or more roles. Therefore, applications can use role membership to determine whether a principal is authorized to perform a requested action.  
  
 To provide ease of use and consistency with code access security, .NET role-based security provides <xref:System.Security.Permissions.PrincipalPermission?displayProperty=nameWithType> objects that enable the common language runtime to perform authorization in a way that is similar to code access security checks. The <xref:System.Security.Permissions.PrincipalPermission> class represents the identity or role that the principal must match and is compatible with both declarative and imperative security checks. You can also access a principal's identity information directly and perform role and identity checks in your code when needed.  
  
 .NET provides role-based security support that is flexible and extensible enough to meet the needs of a wide spectrum of applications. You can choose to interoperate with existing authentication infrastructures, such as COM+ 1.0 Services, or to create a custom authentication system. Role-based security is particularly well-suited for use in ASP.NET Web applications, which are processed primarily on the server. However, .NET role-based security can be used on either the client or the server.  
  
 Before reading this section, make sure that you understand the material presented in [Key Security Concepts](key-security-concepts.md).  
  
## See also
  
- [Principal and Identity Objects](principal-and-identity-objects.md)
- [Key Security Concepts](key-security-concepts.md)
- <xref:System.Security.Permissions.PrincipalPermission?displayProperty=nameWithType>
- [ASP.NET Core Security](/aspnet/core/security/)
