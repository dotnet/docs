---
title: "Workflow Discovery Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 82cc43f1-3c8f-4771-ac19-a75ac936e2c3
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Workflow Discovery Sample
This sample demonstrates how to make a workflow service discoverable and how to author a custom code activity that searches for a particular service.  
  
## Demonstrates  
 Discovery Find Activity and Workflow Usage  
  
## Discussion  
 In the first part of the sample, a workflow service is made discoverable using configuration. Configuration can also be used to apply the service appropriately with custom metadata (such as scopes). On the client, the sample uses a custom code activity, which uses Discovery to search for a service matching a particular contract. The code activity outputs a URI, which is later used by a send activity.  
  
#### To set up, build, and run the sample  
  
1.  This sample uses HTTP endpoints, which must have proper URL ACLs to run (see [Configuring HTTP and HTTPS](http://go.microsoft.com/fwlink/?LinkId=70353) for details). Executing the following command at an elevated command prompt should add the appropriate ACLs. Substitute your Domain and Username for the following arguments if your shell does not understand the variable format.  
  
     **netsh http add urlacl url=http://+:8000/ user=%DOMAIN%\\%UserName%**  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Discovery\WorkflowDiscovery`
