---
title: "Asynchronous Find Sample"
ms.date: "03/30/2017"
ms.assetid: 7a713a25-c1f4-42e1-8c4a-93d64ca45a3b
---
# Asynchronous Find Sample
This sample shows how to use the asynchronous find operation from a client application.  
  
## Sample Details  
 The benefit of following this design pattern is that the client is notified asynchronously of the endpoints located as a result of the find request. To see how this works, open the Client.cs file. Note the <xref:System.ServiceModel.Discovery.DiscoveryClient> object has two delegates attached to its event handlers. One delegate is called when a <xref:System.ServiceModel.Discovery.DiscoveryClient.FindCompleted> event is raised and another is called each time a <xref:System.ServiceModel.Discovery.DiscoveryClient.FindProgressChanged> event is raised. The sample shows how you can utilize this pattern in your application.  
  
> [!NOTE]
>  This sample uses HTTP endpoints and to run, proper URL ACLs must be added. For more information, see [Configuring HTTP and HTTPS](../../../../docs/framework/wcf/feature-details/configuring-http-and-https.md). Executing the following command at an elevated privilege should add the appropriate ACLs. You may want to substitute your domain and username for the following arguments if the command does not work as is. `netsh http add urlacl url=http://+:8000/ user=%DOMAIN%\%UserName%`  
  
#### To set up, build, and run the sample  
  
1.  Using [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], open the AsyncFind.sln.  
  
2.  Press CTRL+SHIFT+B to build the solution.  
  
3.  Open a [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] command prompt and navigate to the \WCF\Basic\Discovery\AsyncFind\CS\service\bin\Debug or \WCF\Basic\Discovery\AsyncFind\VB\service\bin\Debug directory and run Service.exe.  
  
4.  After the service has started, navigate to the \WCF\Basic\Discovery\AsyncFind\CS\client\bin\Debug or WCF\Basic\Discovery\AsyncFind\VB\client\bin\Debug directory and run Client.exe.  
  
5.  Observe the client is able to locate and call the service.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](https://go.microsoft.com/fwlink/?LinkId=150780) to download all Windows Communication Foundation (WCF) and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Discovery\AsyncFind`  
  
## See Also
