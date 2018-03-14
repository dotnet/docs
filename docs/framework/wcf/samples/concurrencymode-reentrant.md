---
title: "ConcurrencyMode Reentrant"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b2046c38-53d8-4a6c-a084-d6c7091d92b1
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ConcurrencyMode Reentrant
This sample demonstrates the necessity and implications of using ConcurrencyMode.Reentrant on a service implementation. ConcurrencyMode.Reentrant implies that the service (or callback) processes only one message at a given time (analogous to `ConcurencyMode.Single`). To ensure thread safety, [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] locks the `InstanceContext` processing a message so that no other messages can be processed. In case of Reentrant mode, the `InstanceContext` is unlocked just before the service makes an outgoing call thereby allowing the subsequent call, (which can be reentrant as demonstrated in the sample) to get the lock next time it comes in to the service. To demonstrate the behavior, the sample shows how a client and service can send messages between each other using a duplex contract.  
  
 The contract defined is a duplex contract with the `Ping` method being implemented by the service and the callback method `Pong` being implemented by the client. A client invokes the server's `Ping` method with a tick count thereby initiating the call. The service checks whether the tick count is not equal to 0 and then invokes the callbacks `Pong` method while decrementing the tick count. This is done by the following code in the sample.  
  
```  
public void Ping(int ticks)  
{  
     Console.WriteLine("Ping: Ticks = " + ticks);  
     //Keep pinging back and forth till Ticks reaches 0.  
     if (ticks != 0)  
     {  
         OperationContext.Current.GetCallbackChannel<IPingPongCallback>().Pong((ticks - 1));  
     }  
}  
```  
  
 The callback's `Pong` implementation has the same logic as the `Ping` implementation. That is, it checks whether the tick count is not zero and then invokes the `Ping` method on the callback channel (in this case, it is the channel that was used to send the original `Ping` message) with the tick count decremented by 1. The moment the tick count reaches 0, the method returns thereby unwrapping all the replies back to the first call made by the client that initiated the call. This is shown in the callback implementation.  
  
```  
public void Pong(int ticks)  
{  
    Console.WriteLine("Pong: Ticks = " + ticks);  
    if (ticks != 0)  
    {  
        //Retrieve the Callback  Channel (in this case the Channel which was used to send the  
        //original message) and make an outgoing call until ticks reaches 0.  
        IPingPong channel = OperationContext.Current.GetCallbackChannel<IPingPong>();  
        channel.Ping((ticks - 1));  
    }  
}  
```  
  
 Both the `Ping` and `Pong` methods are request/reply, which means that the first call to `Ping` does not return until the call to `CallbackChannel<T>.Pong()` returns. On the client, the `Pong` method cannot return until the next `Ping` call that it made returns. Because both the callback and the service must make outgoing request/reply calls before they can reply for the pending request, both the implementations must be marked with the ConcurrencyMode.Reentrant behavior.  
  
### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
## Demonstrates  
 To run the sample, build the client and server projects. Then open two command windows and change the directories to the \<sample>\CS\Service\bin\debug and \<sample>\CS\Client\bin\debug directories. Then start the service by typing `service.exe` and then invoke the Client.exe with the initial value of ticks passed as an input argument. A sample output for 10 ticks is shown.  
  
```  
Prompt>Service.exe  
ServiceHost Started. Press Enter to terminate service.  
Ping: Ticks = 10  
Ping: Ticks = 8  
Ping: Ticks = 6  
Ping: Ticks = 4  
Ping: Ticks = 2  
Ping: Ticks = 0  
  
Prompt>Client.exe 10  
Pong: Ticks = 9  
Pong: Ticks = 7  
Pong: Ticks = 5  
Pong: Ticks = 3  
Pong: Ticks = 1  
```  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Services\Reentrant`  
  
## See Also
