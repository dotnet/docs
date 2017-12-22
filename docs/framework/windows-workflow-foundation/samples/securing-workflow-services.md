---
title: "Securing Workflow Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 53f84ad5-1ed1-4114-8d0d-b12e8a021c6e
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Securing Workflow Services
The Secured Workflow Service sample shows the following procedures:  
  
-   Creating a basic workflow service using the <xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.SendReply> activities.  
  
-   Using [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] configuration to define secure endpoints for use by the workflow service.  
  
-   Creating claims inside a custom policy and using the <xref:System.ServiceModel.ServiceAuthorizationManager> to validate claims.  
  
## Demonstrates  
 Using WCF security to secure communication between client and Workflow service, Claims based authorization  
  
## Discussion  
 This sample demonstrates the use of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security infrastructure to secure a workflow service just like you would with a normal [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service. Specifically, it uses a custom claim for authorization. In this case, it uses <xref:System.ServiceModel.WSHttpBinding> and message mode security with Windows credentials.  
  
 The custom <xref:System.IdentityModel.Policy.IAuthorizationPolicy> (`CustomNameCheckerPolicy`) checks the client's Windows username and for a specific character. If that character is present, it creates and adds the claim to the <xref:System.IdentityModel.Policy.EvaluationContext>. By doing this, the custom policy is making the statement that the client has this character in the username. This claim can be queried throughout the lifetime of the call. You can find that character in `Constants.cs`.  
  
 The authorization policy looks for the claim inside the `SecureWorkFlowAuthZManager`. If it finds it, it returns `true` and allow the workflow to proceed. Otherwise, it returns `false`, which causes an 'Access Denied' message to be returned to the client. Other claims are present in the context and can be examined as well inside the `SecureWorkFlowAuthZManager`.  
  
#### To run this sample  
  
1.  Run [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] with administrator privileges.  
  
2.  Load SecuringWorkflowServices.sln in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
3.  Press CTRL+SHIFT+B to compile the solution.  
  
4.  Set the Service project as the start-up project for the solution.  
  
5.  Press CTRL+F5 to start the service without debugging.  
  
6.  Set the Client project as the start-up project for the solution.  
  
7.  Press CTRL+F5 to start the client without debugging.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\Services\SecuringWorkflowServices`
