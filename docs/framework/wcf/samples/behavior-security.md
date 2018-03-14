---
title: "Behavior Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 19710ae3-f197-4d28-ba9d-52e465006819
caps.latest.revision: 5
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Behavior Security
This section includes samples that demonstrate configuring security for service behaviors.  
  
## In This Section  
 [Service Auditing Behavior](../../../../docs/framework/wcf/samples/service-auditing-behavior.md)  
 This sample demonstrates how to use the <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior> to enable auditing of security events during service operations.  
  
 [Membership and Role Provider](../../../../docs/framework/wcf/samples/membership-and-role-provider.md)  
 This sample demonstrates how a service can use the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] membership and role providers to authenticate and authorize clients.  
  
 [Authorizing Access to Service Operations](../../../../docs/framework/wcf/samples/authorizing-access-to-service-operations.md)  
 This sample demonstrates how to use the [\<serviceAuthorization>](../../../../docs/framework/configure-apps/file-schema/wcf/serviceauthorization-element.md) to enable use of the <xref:System.Security.Permissions.PrincipalPermissionAttribute> attribute to authorize access to service operations.  
  
 [Impersonating the Client](../../../../docs/framework/wcf/samples/impersonating-the-client.md)  
 This sample demonstrates how to impersonate the caller application at the service so that the service can access system resources on behalf of the caller.
