---
title: "Advanced Format Selection"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e02d9082-4d55-41d8-9329-98f6d1c77f06
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Advanced Format Selection
This sample demonstrates how to extend the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] REST programming model to support new outgoing response formats. In addition, the sample uses a T4 Template to return the response as an XHTML page, demonstrating how a view-style programming model can be implemented.  
  
## Sample Details  
 The sample consists of a simple service along with client code that makes requests to the service.  The service supports a single [WebGet] operation, which has the following method signature: `Message EchoListWithGet(string list);`  
  
 When the client makes a request to the service, it provides a comma-separated list of items from the `list` query-string parameter and the service returns that same list in one of the following formats: XML, JSON, Atom, XHTML, or jpeg.  
  
 The response format returned by the service is determined first by a `format` query-string parameter and second by an HTTP Accept header supplied with the request. If the value of `format` query-string parameter is one of the preceding formats, then the response is returned in that format. If the `format` query-string is not present, then the service iterates through the Accept header elements from the request and returns the format of the first content-type that the service supports.  
  
 The return type of the operation is worth noting. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] REST programming model only natively supports XML and JSON response formats when an operation returns a type other than <xref:System.ServiceModel.Channels.Message>. However, when using <xref:System.ServiceModel.Channels.Message> as the return type, the developer has complete control over how the content of the message should be formatted.  
  
 The sample uses the <xref:System.ServiceModel.Web.WebOperationContext.CreateXmlResponse%2A>, <xref:System.ServiceModel.Web.WebOperationContext.CreateJsonResponse%2A> and <xref:System.ServiceModel.Web.WebOperationContext.CreateAtom10Response%2A> methods to serialize the list of strings into XML, JSON, and ATOM messages respectively. For the jpeg response format, the <xref:System.ServiceModel.Web.WebOperationContext.CreateStreamResponse%2A> method is used and the image is saved to the stream. For the XHTML response, the <xref:System.ServiceModel.Web.WebOperationContext.CreateTextResponse%2A> is used along with a preprocessed T4 template, which consists of a .tt file and an auto-generated .cs file. The .tt file allows a developer to write a response in a template form that contains variables and control structures. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] T4, see [Generating Artifacts By Using Text Templates](http://go.microsoft.com/fwlink/?LinkId=166023).  
  
 The sample consists of a self-hosted service and a client that runs within a console application. As the console application runs, the client makes requests to the service and writes the pertinent information from the responses to the console window.  
  
#### To run this sample  
  
1.  Open the solution for the Advanced Format Selection Sample. When launching [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], you should run as an administrator for the sample to execute successfully. Do this by right-clicking the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] icon and choosing **Run as Administrator** from the context menu.  
  
2.  Press CTRL+SHIFT+B to build the solution and then press Ctrl-F5 to run the console application AdvancedFormatSelection project without debugging. The console window appears and provides the URI of the running service and the URI of the HTML help page for the running service.  
  
3.  As the sample runs, the client sends requests to the service and writes the responses to the console window. Notice the different formats of the responses: XML, JSON, Atom, and XHTML.  
  
4.  You are then prompted to browse to a URI in which you can request the response in a .jpeg format. Open a browser and browse to the given URI.  
  
5.  Press any key to terminate the sample.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Web\AdvancedFormatSelection`  
  
## See Also
