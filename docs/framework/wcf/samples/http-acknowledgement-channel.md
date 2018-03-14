---
title: "HTTP Acknowledgement Channel"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 469f3056-5ef2-4753-8acf-b574d23d83cf
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# HTTP Acknowledgement Channel
The HTTP Acknowledgement Channel is an example of a layered channel that changes the one-way messaging pattern, allowing a service to acknowledge or refuse incoming messages rather than automatically sending an acknowledgement on receipt. The HTTP Acknowledgement Channel also allows the service to delay acknowledgement until it can make a business-level guarantee that the message will be processed.  
  
## Demonstrates  
 <xref:System.ServiceModel.Channels.ReceiveContext>, Layered channel example (HTTP Acknowledgement channel).  
  
## Discussion  
 The HTTP Acknowledgement Channel implements <xref:System.ServiceModel.Channels.ReceiveContext> to reshape the HTTP request-reply messaging pattern to a one-way pattern with delayed acknowledgement. Using this new pattern, a service can ensure message processing by sending an acknowledgement in the form of an HTTP OK status code of 200 without blocking the client until message processing completes or can send a failure message to the client in the form of an HTTP Internal Server error status code of 500. For example, a service could send an acknowledgement after writing a message to a queue, and then continue processing the message asynchronously. In this scenario, a client could be assured its messages were processed at least once by the service, if it re-sent each message until it received an acknowledgement from the service. Note that, if a service requires fast asynchronous message processing over HTTP without any message processing guarantees, then the <xref:System.ServiceModel.Channels.OneWayBindingElement> is a more appropriate choice.  
  
 <xref:System.ServiceModel.Channels.ReceiveContext> is used to hold the message in place while it is determined whether the message can be processed at the service. The ability of a service to successfully process the message is indicated by calling Complete on the <xref:System.ServiceModel.Channels.ReceiveContext> object that sends an HTTP OK status code and whether the service can process the message is indicated by calling <xref:System.ServiceModel.Channels.ReceiveContext>’s `Abandon` method on the <xref:System.ServiceModel.Channels.ReceiveContext> object, which sends an HTTP Internal Server error status code.  
  
 In this example, the client requests processing information by sending an employee ID. On the service end, if the employee ID received is greater than 50, the service sends an HTTP Status code of 500 (Internal Server Error) back to the client, otherwise it is assumed that the processing can be successfully done and sends an HTTP Status code of 200 (Successful) to the client.  
  
#### To set up, build, and run the sample  
  
1.  Open [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] with Administrator privileges.  
  
2.  Open the **HttpAckChannel** solution.  
  
3.  Start a new instance of the **Service** project by right clicking the project in **Solution Explorer**, and selecting **Debug**, **Start new instance** from the context menu.  
  
4.  Start a new instance of the **Client** project by right clicking the project in **Solution Explorer**, and selecting **Debug**, and **Start new instance** from the context menu.  
  
5.  Once the service has started, press ENTER in the client window to let the client send a message to the service.  
  
6.  The first message is processed on the service, and it sends an HTTP OK status code back to the client.  
  
7.  The second message is unsuccessful, and it sends an HTTP Internal Server error status code back to the client, which raises a <xref:System.ServiceModel.CommunicationException> on the client.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Channels\HttpAckChannel`
