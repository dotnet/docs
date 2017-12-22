---
title: "Form Post"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fa6f84f9-2e07-4e3c-92d0-a245308b7dff
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Form Post
This sample demonstrates how to extend the WCF REST programming model to support new incoming request formats. The sample also includes an implementation of a formatter that can deserialize a request from an HTML form post into a [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] type. In addition, the sample uses a T4 Template to return an HTML page, which provides the HTML form that users can post back to the WCF REST service.  
  
## Demonstrates  
  
-   Extending support for incoming request formats.  
  
-   Integrating T4 templates.  
  
## Discussion  
 This sample consists of two projects. One project is the HtmlFormProcessing library that includes a custom request formatter that can deserialize HTML form posts into [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] types. The second project is a console application that extends the Basic Resource Service sample to use the custom request formatter of the HtmlFormProcessing library.  
  
 The custom formatter that can deserialize HTML form posts (HtmlFormRequestDispatchFormatter) accepts both [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] types that can be converted from a string using the <xref:System.ServiceModel.Dispatcher.QueryStringConverter> and types marked with <xref:System.Runtime.Serialization.DataContractAttribute> that only have members that can be converted from a string using the QueryStringConverter.  
  
 The HtmlFormProcessing library project also includes an abstract base class, `RequestBodyDispatchFormatter`, which can be used to create other custom request formatters. Deriving from the `RequestBodyDispatchFormatter` allows a developer to focus on the request body deserialization logic, which allows the base class to map the URI template parameters to the operation’s method parameters. Also in the HtmlFormProcessing library project is the `HtmlFormProcessingBehavior` class, which demonstrates how to derive from the <xref:System.ServiceModel.Description.WebHttpBehavior> to replace the default request formatter with a custom request formatter.  
  
 This console application project extends the [Basic Resource Service](../../../../docs/framework/wcf/samples/basic-resource-service.md) sample. The Basic Resource Service sample demonstrates how to expose a resource in a manner that uses the WCF REST programming model. In the Basic Resource Service sample, a customer collection resource is exposed such that customers in the collection can be created, retrieved, updated and deleted. The Basic Resource Service sample only uses the two natively supported incoming request formats, XML and JSON.  
  
 The console application in this Form Post sample utilizes the custom formatter in the HtmlFormProcessing library, which allows users to create customers by sending a request from an HTML form post using a browser. It also adds an operation that returns an HTML page, which includes the form to be posted back to the service. This HTML page is generated using a preprocessed T4 template, which consists of a .tt file and an auto-generated .cs file. The .tt file allows a developer to write a response in a template form that contains variables and control structures. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] T4, see [Generating Artifacts By Using Text Templates](http://go.microsoft.com/fwlink/?LinkId=178139).  
  
#### To run the sample  
  
1.  Open the solution for the Form Post Sample. When launching [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], you must run as an administrator to execute the sample successfully. Do this by right-clicking the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] icon and choosing "Run as Administrator" from the context menu.  
  
2.  Press CTRL+SHIFT+B to build the solution and then press CTRL+F5 to run the console application FormPost project.  
  
3.  The console window appears and provides the URI of the running service and the URI of the HTML help page for the running service.  
  
4.  As the sample runs, the client writes the status of the current activity, whether it be adding a customer, updating a customer, deleting a customer or getting a list of current customers from the service to the console window.  
  
5.  You are then prompted to browse to the URI of the customer form. Open a browser and browse to the given URI. Type in a name and address for the customer and click the **Submit** button.  
  
6.  Press any key for the console window to continue running the sample.  
  
7.  As the sample completes, notice that the customer you created using the browser is included in the final list of customers.  
  
8.  Press any key to terminate the sample.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Web\FormPost`
