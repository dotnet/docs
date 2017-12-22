---
title: "Asynchronous Communication"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 128dc092-9eb2-4e33-9470-9a7f62b60df6
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Asynchronous Communication
This sample demonstrates how the communication between two different [!INCLUDE[wf](../../../../includes/wf-md.md)] services is done asynchronously by default.  
  
## Demonstrates  
 Asynchronous communication between [!INCLUDE[wf1](../../../../includes/wf1-md.md)] services.  
  
## Discussion  
 This sample shows how the communication between [!INCLUDE[wf1](../../../../includes/wf1-md.md)] applications is done asynchronously by using the messaging activities provided by .NET Framework.  
  
 This sample consists of the following three projects.  
  
 CreditCheckService  
 This service receives the credit score of a particular person or the value of the item to acquire, and then decides whether the credit is given to the person.  
  
 RentalApprovalService  
 This service receives an application from a person who is in need of some credit. This service communicates asynchronously with the `CreditCheckService` to decide whether the credit application is valid.  
  
 Client  
 The client communicates synchronously with the `RentalApprovalService` to know whether the credit is approved.  
  
#### To set up, build, and run the sample  
  
1.  Right-click the **AsynchronousCommunication** solution and select **Properties**.  
  
2.  In **Common Properties**, select **Startup Project**, and select **Multiple Startup Projects**.  
  
3.  Move **RentalApprovalService** to the first position in the list, followed by **CreditCheckService**, followed by **Client**. Set the **Start** action on all three projects.  
  
4.  Click **OK**, and press F5 to run the sample.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\Services\AsynchronousCommunication`
