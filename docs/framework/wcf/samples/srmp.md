---
title: "SRMP"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cf37078c-dcb4-45e0-acaf-2f196521b226
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# SRMP
This sample demonstrates how to perform transacted queued communication by using Message Queuing (MSMQ) over HTTP.  
  
 In queued communication, the client communicates to the service using a queue. More precisely, the client sends messages to a queue. The service receives messages from the queue. The service and client therefore, do not have to be running at the same time to communicate using a queue.  
  
 MSMQ enables the use of HTTP (including the use of HTTPS) to send messages to a queue. In this example, we demonstrate using [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] queued communication and how to send messages over HTTP. MSMQ uses a protocol called SRMP, which is a SOAP-based protocol for communication over HTTP.  
  
### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
4.  Before running the sample in **Add/Remove Windows Components**, ensure that MSMQ is installed with HTTP support. Installing HTTP support automatically installs Internet Information Services (IIS) and adds the protocol support in IIS for MSMQ.  
  
5.  If you want to be certain that HTTP is used for communication, you can enable MSMQ to run in hardened mode. This ensures that no messages to any queue hosted on the machine can arrive using any non-HTTP transport.  
  
6.  After you have selected MSMQ to run in hardened mode, the machine requires a re-boot on [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)].  
  
7.  Run the service.  
  
8.  Run the client. Ensure that you change the endpoint address to point to the machine name or IP address instead of localhost. The client sends a message and exits.  
  
## Requirements  
 To run this sample, IIS must be installed on both the service and the client machines in addition to MSMQ.  
  
## Demonstrates  
 The sample demonstrates sending [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] queued messages using MSMQ over HTTP. This is also called SRMP messaging. When a queued message is sent, MSMQ on the sending machine transfers the messages to the receiving queue manager over TCP or HTTP transport. By choosing SRMP, the user indicates the choice of HTTP as a transport for queue transfer. SRMP Secure enables the use of HTTPS.  
  
## Example  
 The sample code is based on the transacted sample. How you send a message to the queue and receive a message from the queue using SRMP is the same as sending and receiving messages using a Native protocol.  
  
 The configuration for the client is changed to indicate the choice of the queue transfer protocol. The queue transfer protocol can be one of Native, SRMP or SrmpSecure. By default, the transfer protocol is Native. The client and service specify in the configuration to use SRMP in this example.  
  
 There are limitations to SRMP in relation to transport security. The default MSMQ transport security requires Active Directory that requires that the sending queue manager and the receiving queue manager reside in the same Windows domain. This is not possible when sending messages over HTTP boundary. As such, the default transport security does not work. The transport security must be set to Certificate if transport security is desired. Message security can also be used to secure the message. In this sample, both transport and message security is turned off to illustrate SRMP messaging.  
  
```xml  
<?xml version="1.0" encoding="utf-8" ?>  
<configuration>  
  
  <system.serviceModel>  
  
    <client>  
      <!-- Define NetMsmqEndpoint -->  
      <endpoint name="OrderProcessorEndpoint"  
           address=  
          "net.msmq://localhost/private/ServiceModelSamplesSrmp"   
           bindingConfiguration="srmpBinding"   
           binding="netMsmqBinding"   
           contract="IOrderProcessor" />  
    </client>  
    <bindings>  
      <netMsmqBinding>  
        <binding name="srmpBinding"  
                 queueTransferProtocol="Srmp">  
          <security mode="None"></security>  
        </binding>  
      </netMsmqBinding>  
    </bindings>  
  </system.serviceModel>  
  
</configuration>  
```  
  
 Running the sample yields the following output.  
  
```  
Processing Purchase Order: 556b70be-31ee-4a3b-8df4-ed5e538015a4   
Customer: somecustomer.com   
OrderDetails   
    Order LineItem: 54 of Blue Widget @unit price: $29.99   
    Order LineItem: 890 of Red Widget @unit price: $45.89   
    Total cost of this order: $42461.56   
    Order status: Pending  
```  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Binding\Net\MSMQ\SRMP`  
  
## See Also
