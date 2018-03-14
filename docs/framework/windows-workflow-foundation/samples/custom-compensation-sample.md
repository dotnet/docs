---
title: "Custom Compensation Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 385920da-9284-44bf-9fe9-0d87c7478ec5
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Compensation Sample
This sample shows how to use <xref:System.Activities.Statements.CompensableActivity> and its compensation handler to define custom compensation logic. The scenario modeled in this sample is a Truck Rental Agency.  
  
## Sample Details  
 The steps simulated are:  
  
1.  The user requests truck rental quotes for a given date.  
  
2.  Three truck companies are contacted and the three quotes are provided.  
  
3.  The user selects one truck quote and proceeds to order by credit card.  
  
4.  The application cancels the other two truck quotes.  
  
5.  The application charges a service fee that is non-refundable for non-premium accounts if cancelation happens 10 days or less prior to the reservation date.  
  
6.  The application charges the truck rental fee.  
  
7.  The application waits until the reservation date or until the customer decided to cancel the reservation, whichever comes first.  
  
8.  If the customer cancels the reservation, the <xref:System.Activities.Statements.CompensableActivity.CompensationHandler%2A> custom compensation logic runs according to the following logic:  
  
    1.  If the customer has a non-premium account and it is less than 10 days prior to the reservation date, then the service fee is still charged; otherwise, the application refunds the service fee.  
  
    2.  The rest of the compensable activities (truck order + truck order fee) are run according to the default compensation logic, which is to compensate in reverse order of execution.  
  
#### To set up, build, and run the sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the CustomCompensation.sln solution. It is located in the \WF\Basic\Compensation\CustomCompensation directory.  
  
2.  Press CTRL+SHIFT+B to build the solution.  
  
3.  Press CTRL + F5 to run the application.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Compensation\CustomCompensation`