---
title: "LINQ Message Query Correlation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b746872e-57b1-4514-b337-53398a0e0deb
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# LINQ Message Query Correlation
This sample demonstrates how to do content-based correlation using a custom <xref:System.ServiceModel.Dispatcher.MessageQuery> implementation as opposed to the system-provided <xref:System.ServiceModel.XPathMessageQuery>.  
  
## Demonstrates  
 Custom <xref:System.ServiceModel.Dispatcher.MessageQuery>, Content-Based Correlation.  
  
## Discussion  
 This sample shows how to extend from the <xref:System.ServiceModel.Dispatcher.MessageQuery> base class for the purposes of correlation. The custom implementation, `LinqMessageQuery`, allows users to provide an XName to find within the message using XLinq. The data retrieved by the query is used to form the correlation key to dispatch messages to the appropriate workflow instance.  
  
#### To set up, build, and run the sample  
  
1.  This sample exposes a workflow service using HTTP endpoints. To run this sample, proper URL ACLs must be added (see [Configuring HTTP and HTTPS](http://go.microsoft.com/fwlink/?LinkId=70353) for details), either by running Visual Studio as Administrator or by executing the following command at an elevated prompt to add the appropriate ACLs. Ensure that your Domain and Username are substituted.  
  
    ```  
    netsh http add urlacl url=http://+:8000/ user=%DOMAIN%\%UserName%  
    ```  
  
2.  Once the URL ACLs are added, use the following steps.  
  
    1.  Build the solution.  
  
    2.  Set multiple start-up projects by right-clicking the solution and selecting **Set Startup Projects**. Add **Service** and **Client** (in that order) as multiple start-up projects.  
  
    3.  Run the application. The client console shows a workflow  sending an order and receiving the purchase order id and then subsequently confirming the order. The Service window will show the requests being processed.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\Services\LinqMessageQueryCorrelation`
