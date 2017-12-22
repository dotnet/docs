---
title: "Basic XAML only Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c106feb0-0245-43b5-aefe-93ce0e4d38eb
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Basic XAML only Service
This sample demonstrates how to create a XAML only service. The scenario is a diagnostics service for car-related problems. The service is implemented as a workflow that asks the client a series of questions to diagnose the problem. There are two types of issues the service can diagnose (car does not start or air conditioning not working). The workflow uses Request/Reply template from the designer to expose three simple service operations. The service is hosted in IIS by creating a virtual directory in IIS and copying the service1.xamlx and Web.config files into the virtual directory, no compiled code is required. By default this sample will automatically copy the needed files into the virtual directory created when you follow the setup instructions for the WCF and WF samples: [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md) when built in Visual Studio 2010.  
  
#### To use this sample  
  
1.  Load the project solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] and build the project.  
  
2.  Run the Client application generated in [solution base directory]\Client\bin\debug.  
  
3.  The application prints out options, selects an option. The application then asks some questions, answer them yes or no (using Y/N keys). When the service is done diagnosing the issues, the application prints out a diagnosis.  
  
4.  The application goes back to the options. You can diagnose another problem or exit the application.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Services\XAMLService`