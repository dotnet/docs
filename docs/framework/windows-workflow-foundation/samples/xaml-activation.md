---
title: "XAML Activation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 486760e2-bb10-4ed5-8c02-fe7472498d2d
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# XAML Activation
This sample demonstrates how to host a declarative workflow in IIS. The sample is a basic workflow called `EchoService` that has one operation.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to (download page) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Services\XAMLActivation`  
  
#### To set up, build, and run the sample  
  
1.  Open the XAMLActivation.sln solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Build the solution by pressing **F5**.  
  
3.  Run WcfTestClient.exe. From a command prompt, type in the following:  
  
    1.  cd %SystemDrive%\Program Files\Microsoft Visual Studio 10.0\Common7\IDE  
  
    2.  Run WcfTestClient.exe.  
  
4.  Set the address of the service on WcfTestClient.exe by pressing CTRL+SHIFT+A and setting the service address to http://localhost:56133/Service.xamlx.  
  
5.  Perform the echo operation to test the service.  
  
6.  Deploy the Service in IIS using DeployToIIS.Bat in a command prompt with administrator privileges.  
  
7.  Update the service address in the client to http://localhost/XAMLActivation/Service.xamlx and test the service again using WcfTestClient.exe.
