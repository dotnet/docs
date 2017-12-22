---
title: "ReceiveContext-Enabled WCF Channels"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d990d119-7321-4b8c-852b-10256f59f9b0
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ReceiveContext-Enabled WCF Channels
This sample demonstrates the usefulness of <xref:System.ServiceModel.Channels.ReceiveContext>-enabled WCF channels. The sample implements a service to find the product of two numbers using a NetMSMQ channel.  
  
 The <xref:System.ServiceModel.Channels.ReceiveContext> class enables an application to decide whether to access the message or leave it in the queue for further processing, even after the contents of the message have been inspected. In this sample, a client sends random integers to a transactional queue. The `ProductCalculator` service receives the messages and inspects the message contents, which are integers, to determine whether the product can be computed. If the service operation does not compute the product, the message is put back into the queue and can be received again by the service listening on the queue.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing:  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory:  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Binding\Net\MSMQ\ReceiveContextProductGenerator`  
  
#### To use this sample  
  
1.  Ensure that Microsoft Message Queuing (MSMQ) is installed.  
  
    1.  To install MSMQ on [!INCLUDE[lserver](../../../../includes/lserver-md.md)]:  
  
        1.  In **Server Manager**, click **Features**.  
  
        2.  In the right pane under **Features Summary**, click **Add Features**.  
  
        3.  In the resulting window, expand **Message Queuing**.  
  
        4.  Expand **Message Queuing Services**.  
  
        5.  Click **Directory Services Integration** (for computers joined to a domain), and then click **HTTP Support**.  
  
        6.  Click **Next**, and then click **Install**.  
  
    2.  To install MSMQ on [!INCLUDE[wv](../../../../includes/wv-md.md)]:  
  
        1.  Open **Control Panel**.  
  
        2.  Click **Programs** and then, under **Programs and Features**, click **Turn Windows Features on and off**.  
  
        3.  Expand **Microsoft Message Queue (MSMQ) Server**, expand **Microsoft Message Queue (MSMQ) Server Core**, and then select the check boxes for the following Message Queuing features to install:  
  
            -   Message Queuing Server  
  
            -   MSMQ Active Directory Domain Services Integration (for computers joined to a domain)  
  
            -   MSMQ HTTP Support  
  
        4.  Click **OK**.  
  
        5.  If you are prompted to restart the computer, click **OK** to complete the installation.  
  
2.  Ensure that [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] is installed on the computer.  
  
3.  Using [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], open the ReceiveContextProductGenerator.sln solution file.  
  
4.  To build the solution, press CTRL+SHIFT+B.  
  
5.  To run the solution, press CTRL+F5.
