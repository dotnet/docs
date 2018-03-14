---
title: "Formatting messages in Workflow Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6d15d44b-20f8-4cb7-bd4f-598c32781ebc
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Formatting messages in Workflow Services
This sample shows how different user types can be used in messaging activities (WF services). The sample service is a simple expense approval service and exposes three operations. `ApproveExpense` takes a data contract type and shows how to use known types. The operation returns `true` or `false` based on the expense amount. `ApprovePO` takes an XmlSerializer type and returns `true` or `false` based on the expense amount.`ApprovedVendor` takes a message contract type and returns `true` or `false` if the vendor is in the list of approved vendors or if the request came from the finance department (the finance department can use any vendor).  
  
#### To use this sample  
  
1.  Load the project solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] and build the project.  
  
2.  First run the service, generated in [solution base directory]\FormatterService\bin\debug\  
  
3.  Second, run the Client application generated in [solution base directory]\FormatterClient\bin\debug.  
  
4.  The client calls three operations on the service and prints the results. When complete, press ENTER to exit the client and then the service.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Services\Formatter`