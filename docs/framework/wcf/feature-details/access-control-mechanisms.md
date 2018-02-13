---
title: "Access Control Mechanisms"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WCF security"
  - "access control [WCF]"
ms.assetid: 9d576122-3f55-4425-9acf-b23d0781e966
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Access Control Mechanisms
You can control access in several way with [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)]. This topic briefly discusses the various mechanisms and provides suggestions on when to use each; it is intended to help you select the correct mechanism to use. The access technologies are listed in order of complexity. The simplest is the <xref:System.Security.Permissions.PrincipalPermissionAttribute>; the most complex is the Identity Model.  
  
 In addition to these mechanisms, impersonation and delegation with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is explained in [Delegation and Impersonation](../../../../docs/framework/wcf/feature-details/delegation-and-impersonation-with-wcf.md).  
  
## PrincipalPermissionAttribute  
 The <xref:System.Security.Permissions.PrincipalPermissionAttribute> is used to restrict access to a service method. When the attribute is applied to a method, it can be used to demand a specific caller's identity or membership in a Windows group or [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] role. If the client is authenticated using an X.509 certificate, it is given a primary identity that consists of the subject name plus the thumbprint of the certificate.  
  
 Use the <xref:System.Security.Permissions.PrincipalPermissionAttribute> to control access to resources on the computer that the service is running on, and if the users of the service will always be part of the same Windows domain that the service is running on. You can easily create Windows groups that have specified levels of access (such as none, read-only, or read and write).  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using the attribute, see [How to: Restrict Access with the PrincipalPermissionAttribute Class](../../../../docs/framework/wcf/how-to-restrict-access-with-the-principalpermissionattribute-class.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] identity, see [Service Identity and Authentication](../../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md).  
  
## ASP.NET Membership Provider  
 A feature of [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] is the membership provider. Even though the membership provider is not technically an access control mechanism, it allows controlling access to the service by limiting the set of possible identities that can access the service's endpoint. The membership feature includes a database that can be populated with user name/password combinations that enable users of a Web site to establish accounts with the site. To access a service that uses the membership provider, a user must log on with his or her user name and password.  
  
> [!NOTE]
>  You must first populate the database using the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] feature before a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service can use it for authorization purposes.  
  
 You can also use the membership feature if you already have a membership database from an existing [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web site and you want to enable the same users to use your service, authorized with the same user names and passwords.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using the membership feature in a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service, see [How to: Use the ASP.NET Membership Provider](../../../../docs/framework/wcf/feature-details/how-to-use-the-aspnet-membership-provider.md).  
  
## ASP.NET Role Provider  
 Another feature of [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] is the ability to manage authorization using roles. The [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] role provider enables a developer to create roles for users and to assign each user to a role or roles. As with the membership provider, the roles and assignments are stored in a database, and can be populated using tools provided by a particular implementation of the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] role provider. As with the membership feature, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] developers can use the information in the database to authorize service users by roles. They can, for example, use the role provider in combination with the `PrincipalPermissionAttribute` access control mechanism described above.  
  
 You can also use the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] role provider if you have an existing [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] role provider database and want to use the same set of rules and user assignments in your [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using the role provider feature, see [How to: Use the ASP.NET Role Provider with a Service](../../../../docs/framework/wcf/feature-details/how-to-use-the-aspnet-role-provider-with-a-service.md).  
  
## Authorization Manager  
 Another feature combines the Authorization Manager (AzMan) with the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] role provider to authorize clients. When [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] hosts a Web service, AzMan can be integrated into the application so that authorization to the service is done through AzMan. [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] role manager provides an API that enables you to manage application roles, add and remove users from roles, and check role membership, but it does not allow you to query whether a user is authorized to perform a named task or operation. AzMan allows you to define individual operations and combine them into tasks. With AZMan, in addition to role checks, you can also check whether a user can perform a task. Role assignment and task authorization can be configured outside of the application or performed programmatically within the application. The AzMan administration Microsoft Management Console (MMC) snap-in allows administrators to change the tasks a role can perform at run time and to manage each user's membership of roles.  
  
 You can also use AzMan and the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] role provider if you already have access to an existing AzMan installation and want to authorize your service users using the features of the AzMan/role provider combination.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] AzMan and the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] role provider, see [How To: Use Authorization Manager (AzMan) with ASP.NET 2.0](http://go.microsoft.com/fwlink/?LinkId=88951). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using AzMan and the role provider for [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services, see [How to: Use the ASP.NET Authorization Manager Role Provider with a Service](../../../../docs/framework/wcf/feature-details/how-to-use-the-aspnet-authorization-manager-role-provider-with-a-service.md).  
  
## Identity Model  
 The Identity Model is a set of APIs that enable you to manage claims and policies to authorize clients. With the Identity Model, you can examine every claim contained in credentials that the caller used to authenticate itself to the service, compare the claims to the set of policies for the service, and grant or deny access based on the comparison.  
  
 Use the Identity Model if you need fine control and the ability to set specific criteria before granting access. For example, when using the <xref:System.Security.Permissions.PrincipalPermissionAttribute>, the criterion is simply that the identity of the user is authenticated and belongs to a specific role. In contrast, using the Identity Model, you can create a policy that states the user must be over 18 years of age and possesses a valid driver's license before being allowed to view a document.  
  
 One example where you can benefit from the Identity Model claim-based access control is when using federation credentials in the issued token scenario. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] federation and issued tokens, see [Federation and Issued Tokens](../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md).  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the Identity Model, see [Managing Claims and Authorization with the Identity Model](../../../../docs/framework/wcf/feature-details/managing-claims-and-authorization-with-the-identity-model.md).  
  
## See Also  
 <xref:System.Security.Permissions.PrincipalPermissionAttribute>  
 [How to: Restrict Access with the PrincipalPermissionAttribute Class](../../../../docs/framework/wcf/how-to-restrict-access-with-the-principalpermissionattribute-class.md)  
 [How to: Use the ASP.NET Role Provider with a Service](../../../../docs/framework/wcf/feature-details/how-to-use-the-aspnet-role-provider-with-a-service.md)  
 [How to: Use the ASP.NET Authorization Manager Role Provider with a Service](../../../../docs/framework/wcf/feature-details/how-to-use-the-aspnet-authorization-manager-role-provider-with-a-service.md)  
 [Managing Claims and Authorization with the Identity Model](../../../../docs/framework/wcf/feature-details/managing-claims-and-authorization-with-the-identity-model.md)  
 [Delegation and Impersonation](../../../../docs/framework/wcf/feature-details/delegation-and-impersonation-with-wcf.md)
