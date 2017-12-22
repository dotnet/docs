---
title: "Reliable Secure Profile"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 921edc41-e91b-40f9-bde9-b6148b633e61
caps.latest.revision: 8
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Reliable Secure Profile
This sample demonstrates how to compose [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and [Reliable Secure Profile](http://go.microsoft.com/fwlink/?LinkId=178140) (RSP). This sample demonstrates the implementation of a [Make Connection](http://go.microsoft.com/fwlink/?LinkId=178141) channel which can be composed together with Reliable Messaging and optionally a secure channel to create a Reliable Secure Binding based on the RSP specification.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Channels\ReliableSecureProfile`  
  
## Discussion  
 This sample demonstrates a reliable asynchronous two-way message exchange scenario. The service has a duplex contract and the client implements the duplex callback contract. The client initiates a request to a service, for which a response is expected on a separate connection. The request message is sent reliably. The client does not want to open a listening endpoint at its end. Thus, it polls the service with ‘Make Connection’ requests for the service to send back the response on the back channel of this ‘Make Connection’ request. This sample demonstrates how to have secure reliable duplex communication over HTTP without the client exposing a listening endpoint (and creating a firewall exception).  
  
## To set up, build, and run the sample  
  
1.  Open the **ReliableSecureProfile** solution.  
  
2.  Right click the **Service** project in **Solution Explorer**, select **Debug**, **Start new instance** from the context menu. This starts up the service host.  
  
3.  Right click the **Client** project in **Solution Explorer**, select **Debug**, **Start new instance** from the context menu. This starts up the client.  
  
4.  Type in any string in the prompt on the client console window and click ENTER.This sends the input string to the service, which computes a hash of this string.  
  
5.  View the result on the client windows when the service calls back the duplex callback contract operation to display the result on the client console window. There is an intentional delay on the service to simulate a long running operation of processing the data.  
  
6.  Monitoring the HTTP traffic (by any of the online network monitoring tools like Network Monitor, Fiddler and so on) shows that a sequence for communication is established between the client and the service as laid down by the Reliable Secure Profile, and how the client polls the service with ‘Make Connection’ requests. When the service gets ready to send back the processed response, it uses the back channel of the last ‘Make Connection’ request to send back the results.  
  
7.  Press ENTER on the service console window to close the service. Press ENTER on the client console window to close the client.
