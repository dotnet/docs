---
title: "Automatic Format Selection"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: dab51e56-8517-4a6a-bb54-b55b15ab37bb
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Automatic Format Selection
This sample demonstrates how to enable automatic format selection (XML or JSON) with the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] REST programming model, as well as how to explicitly set the format in the operation code.  
  
## Sample Details  
 The sample consists of a service along with client code that makes requests to the service. The service supports a single HTTP `GET` operation (`EchoWithGet`) and a single HTTP `POST` operation (`EchoWithPost`). Both operations expect a string and then return the string in the response. With the `GET` operation, the string is provided in a URI query-string parameter. With the `POST` operation, the string is provided in the body of the request, serialized in XML. The service is able to return responses in either XML or JSON, utilizing the new automatic format selection and imperative format selection features in [!INCLUDE[netfx40_long](../../../../includes/netfx40-long-md.md)].  
  
 In the sample, automatic format selection is enabled using the App.config file. On the default Web HTTP endpoint, the `automaticFormatSelectionEnabled` attribute has been given a value of `true`. With automatic format selection enabled, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure selects the most appropriate response format (XML or JSON) given the HTTP Accept or Content-Type headers of the request. The developer is not required to provide any additional code or configuration other than setting the `automaticFormatSelectionEnabled` attribute to `true` to use this new feature. In the client code in Program.cs, requests are sent to both the `GET` and `POST` operations of the service with the HTTP Accept header specified as either "application/xml" or "application/json" and the service returns a response in that respective format.  
  
 Also in the `GET` operation, imperative format selection is used. The `GET` operation checks for an optional `format` query-string parameter and if present, sets the response format on the <xref:System.ServiceModel.Web.WebOperationContext.OutgoingResponse%2A> property. Imperatively setting the response format in this way overrides the automatic format selection done by the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure.  
  
 The sample consists of a self-hosted service and a client that runs within a console application. As the console application runs, the client makes requests to the service and writes the pertinent information from the responses to the console window.  
  
#### To use this sample  
  
1.  Open the solution for the Automatic Format Selection Sample. When launching [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], you must run as an administrator for the sample to execute successfully. Do this by right-clicking the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] icon and select **Run as Administrator** from the context menu.  
  
2.  Press CTRL+SHIFT+B to build the solution and then press Ctrl+F5 to run the console application AutomaticFormatSelection project. The console window appears and provides the URI of the running service and the URI of the HTML help page for the running service.  
  
3.  As the sample runs, the client sends requests to the service and writes the responses to the console window. Notice the different formats of the responses in XML and JSON.  
  
4.  Press any key to terminate the sample.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Web\AutomaticFormatSelection`  
  
## See Also
