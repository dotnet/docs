---
title: "Content-Based Correlation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8638b5d6-1d59-456d-8acd-179a5b39b260
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Content-Based Correlation
This sample demonstrates how the messaging activities (<xref:System.ServiceModel.Activities.Send>, <xref:System.ServiceModel.Activities.Receive>, <xref:System.ServiceModel.Activities.SendReply>, and <xref:System.ServiceModel.Activities.ReceiveReply>) can be used with multiple content-based correlations.and content-based correlation. In this scenario, a correlation is first initialized based on a purchase order ID, and then another correlation is created later based on the customer ID. This shows how a <xref:System.ServiceModel.Activities.Receive> activity can both follow an existing correlation and initialize a new correlation based on the same incoming message.  
  
## Demonstrates  
 Messaging activities and content-based correlation  
  
## Discussion  
 This sample shows how to use multiple content-based correlations.  In this scenario, a correlation is first initialized based on a purchase order ID, and then another correlation is created later based on the customer ID.  The correlations are cascaded using a <xref:System.ServiceModel.Activities.Receive> activity that both follows an existing correlation (PurchaseOrderId) and initializes a new correlation (CustomerId) based on the same incoming message.  To accomplish this, the <xref:System.ServiceModel.Activities.Receive> activity uses the <xref:System.ServiceModel.Activities.Receive.CorrelatesOn%2A>, <xref:System.ServiceModel.Activities.Receive.CorrelatesWith%2A> and <xref:System.ServiceModel.Activities.Receive.CorrelationInitializers%2A> properties.  
  
## To use this sample  
  
1.  Open [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] with elevated permissions, by right-clicking the [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] icon and selecting **Run as administrator**.  
  
2.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the CascadingCorrelation.sln solution file.  
  
3.  To build the solution, press CTRL+SHIFT+B.  
  
4.  To run the server, press F5.  
  
5.  Once the service is ready and listening for messages, in Solution Explorer, right-click the Client project and run it.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Services\ContentBasedCorrelation`