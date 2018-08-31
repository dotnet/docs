---
title: "Durable Delay in XAMLX"
ms.date: "03/30/2017"
ms.assetid: efc38df4-2d34-453c-8e59-2c21d1307354
---
# Durable Delay in XAMLX
This sample demonstrates how to use a durable delay, which is a delay that persists the workflow to a durable device during the delay.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](https://go.microsoft.com/fwlink/?LinkId=150780) to download all Windows Communication Foundation (WCF) and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Services\DurableDelayXamlx`  
  
## Discussion  
 The sample workflow contains two messages to a local file that are separated by a delay. When the delay is triggered, the workflow is unloaded and waits 5 seconds in the workflow instance store before being reloaded in memory.  
  
 The .xamlx file is a workflow service that is hosted in Visual Studio. Visual Studio uses Cassini that uses a workflow service host to host the workflow.  
  
 In addition to hosting the workflow, the workflow service host manages the workflow instances by loading and unloading them. To start an instance of the Windows Workflow Foundation (WF) definition (on the workflow service host), set a client that sends a message to the <xref:System.ServiceModel.Activities.Receive> activity in the workflow. This <xref:System.ServiceModel.Activities.Receive> has its <xref:System.ServiceModel.Activities.Receive.CanCreateInstance%2A> property set to `true`, enabling it to create a new instance of the workflow once it receives a message.  
  
 During initialization, an unload instance behavior is added to the configuration file that specifies to the workflow service host under which it should unload an instance to the persistence store (database). For this sample, it unloads the instance immediately after the workflow goes idle (when the delay is triggered).  
  
#### To use this sample  
  
1.  Open a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt.  
  
2.  Navigate to the DurableDelayXamlx\CS folder.  
  
3.  Run Setup.cmd.  
  
4.  Run [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] as an administrator.  
  
5.  Open the DurableDelayXamlx.sln solution file.  
  
6.  In **Solution Explorer**, right-click the solution and select **Properties**.  
  
7.  Select **Multiple startup projects** and set both projects to **Start**.  
  
8.  To build the solution, press CTRL+SHIFT+B.  
  
9. To run the solution, press CTRL+F5.  
  
#### To uninstall this sample  
  
1.  Open a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt.  
  
2.  Navigate to the DurableDelayXamlx\CS folder.  
  
3.  Run Cleanup.cmd.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](https://go.microsoft.com/fwlink/?LinkId=150780) to download all Windows Communication Foundation (WCF) and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Services\DurableDelayXamlX`
