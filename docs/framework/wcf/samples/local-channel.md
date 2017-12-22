---
title: "Local Channel"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fa1917a4-f701-4e82-a439-14a16282c7cc
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Local Channel
Local Channel is a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] transport channel that is used for communication within the same application domain. This is useful for scenarios where the client and the service are running in the same application domain and the overhead of the typical WCF channel stack (serialization and deserialization of messages) must be avoided.  
  
## Demonstrates  
 Local Channel  
  
## Discussion  
 The sample consists of two project files:  
  
-   **LocalChannel**: The programmatic representation of the local channel within the current application domain. In this project, the sending component places the message in an in-memory queue and the receiving component de-queues the message to receive it.  
  
-   **ClientAndService**: This project hosts a service in a console application and then runs a client to call the service from within the same application domain.  
  
 The local channel design skips both the channel stack and the serialization process to increase speed. The local transport channel is implemented using a queue to transport service calls from the client to the service and to return back the value to the client. Rather than serializing parameters and return values, the sample copies the objects.  
  
#### To set up, build, and run the sample  
  
1.  Build and run the LocalChannel solution.  
  
2.  The service host is started and the client calls the service using the local channel. A console window appears to display the results of the service call.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Channels\LocalChannel`
