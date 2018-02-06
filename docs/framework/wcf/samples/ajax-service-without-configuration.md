---
title: "AJAX Service Without Configuration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e6db7acd-5679-45d4-b98a-8449c6873838
caps.latest.revision: 23
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# AJAX Service Without Configuration
This sample demonstrates how to use [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] to create a basic ASP.NET Asynchronous JavaScript and XML (AJAX) service (a service that you can access by using JavaScript code from a Web browser client) without using any configuration settings. The service uses special syntax in the .svc file to automatically enable an AJAX endpoint.  
  
 AJAX support in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is optimized for use with ASP.NET AJAX through the `ScriptManager` control. For an example of using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] with ASP.NET AJAX, see the [Ajax Samples](http://msdn.microsoft.com/library/f3fa45b3-44d5-4926-8cc4-a13c30a3bf3e).  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 This sample builds upon the AJAX Service Using HTTP POST. As described in the [Basic AJAX Service](../../../../docs/framework/wcf/samples/basic-ajax-service.md) sample, <xref:System.ServiceModel.Activation.WebScriptServiceHostFactory> is used to host the service.  
  
```  
<%ServiceHost  
    language=c#  
    Debug="true"  
    Service="Microsoft.Ajax.Samples.CalculatorService  
    Factory="System.ServiceModel.Activation.WebScriptServiceHostFactory"  
%>  
```  
  
 <xref:System.ServiceModel.Activation.WebScriptServiceHostFactory> automatically adds a <xref:System.ServiceModel.Description.WebScriptEndpoint> to the service. If no configuration changes need to be made to the endpoint, the \<system.ServiceModel> section can be completely removed from the Web.config file for the service. The Web.config file contains some ASP.NET settings, which are used by ConfigFreeClientPage.aspx. If that were not the case, the entire Web.config file could be removed.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Ajax\ConfigFreeAjaxService`  
  
#### To set up, build, and run the sample  
  
1.  Ensure that you perform the setup instructions in [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  Build the solution ConfigFreeAjaxService.sln as described in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  Navigate to http://localhost/ServiceModelSamples/ConfigFreeClientPage.aspx (do not open ConfigFreeClientPage.aspx in the browser from within the project directory).  
  
> [!NOTE]
>  When running this sample, please ensure that Anonymous Authentication and Windows Authentication are not enabled simultaneously for the ServiceModelSamples folder in IIS. If that is the case, please disable Windows Authentication. Once you have run the sample, enable Windows Authentication and run "iisreset".  
  
## See Also  
 [Basic AJAX Service](../../../../docs/framework/wcf/samples/basic-ajax-service.md)
