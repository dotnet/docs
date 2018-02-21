---
title: "Data Binding in an ASP.NET Client"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 68b49fa6-94e7-4d4c-a34e-902a2b3770b6
caps.latest.revision: 23
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Data Binding in an ASP.NET Client
This sample demonstrates how to bind data returned by a typical [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service in a Web Forms application.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 This sample demonstrates a service that implements a contract that defines a request-reply communication pattern. The sample consists of a client Web Forms application accessible from a browser and a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service hosted by Internet Information Services (IIS).  
  
 The service implements a contract that defines a request-reply communication pattern. The contract is defined by the `IWeatherService` interface, which exposes an operation named `GetWeatherData`. This operation accepts an array of cities and returns an array of `WeatherData` objects that represent the high and low forecasted temperature for a city.  
  
 On the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] client .aspx page, a DataGrid Web control is defined, which contains the graphical representation of the data returned by the service. Code on the .aspx page calls the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service for weather data and returns the data to an array of `WeatherData` objects. The DataGrid specifies where to get its data from by setting its `DataSource` property to that array. The data binding occurs with a call to the DataGrid's `DataBind` method. All of this code is contained inside the .`aspx` page's `Page_Load` method, so every time the user refreshes the browser page, the data is updated in the DataGrid.  
  
### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  This sample's client is a Web site that runs under a development Web server. To launch the development Web server, type the following at the command prompt: "`%SystemDrive%\Program Files\Common Files\Microsoft Shared\DevServer\9.0\WebDev.WebServer.EXE" /port:8000 /path:<WebFormsSamplePath>\CS\client /vpath:/client`. Then browse to http://localhost:8000/client. To run this sample across computers, replace all references to `localhost` in the client's Web.config file with the computer name of the server.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Scenario\DataBinding\WebForms`  
  
## See Also
