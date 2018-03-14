---
title: "Configuration Channel Factory"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3b749493-bd8a-4ccb-893e-5948901a1486
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Configuration Channel Factory
This sample covers the usage of the <xref:System.ServiceModel.Configuration.ConfigurationChannelFactory%601>. The <xref:System.ServiceModel.Configuration.ConfigurationChannelFactory%601> allows central management of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client configuration. This can also be useful in scenarios in which configuration is selected or changed after the application domain load time.  
  
## Demonstrates  
 <xref:System.ServiceModel.Configuration.ConfigurationChannelFactory%601>  
  
## Discussion  
 This sample shows how to use <xref:System.ServiceModel.Configuration.ConfigurationChannelFactory%601> to add a particular configuration file to a client application, without having to use the default application configuration file.  
  
 The sample consists of two projects. The first project is a simple service that runs to reply to messages coming from the clients. The second project is a client application that builds two <xref:System.ServiceModel.Configuration.ConfigurationChannelFactory%601> objects using a <xref:System.Configuration.ExeConfigurationFileMap> for the Test.config configuration file and uses them to communicate with the service. Both clients communicate with the service using the configuration specified in Test.config.  
  
 The following code adds a custom configuration file to a client application.  
  
```  
ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();  
fileMap.ExeConfigFilename = "Test.config";  
Configuration newConfiguration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);  
  
ConfigurationChannelFactory<ICalculatorChannel> factory1 = new ConfigurationChannelFactory<ICalculatorChannel>("endpoint1", newConfiguration, new EndpointAddress("http://localhost:8000/servicemodelsamples/service"));  
ICalculatorChannel client1 = factory1.CreateChannel();  
```  
  
#### To set up, build, and run the sample  
  
1.  Open [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] with administrator privileges.  
  
2.  Right-click the ConfigurationChannelFactory solution (2 projects) and then select **Properties**.  
  
3.  In **Common Properties**, select **Startup Project**, and then click **Multiple startup projects**.  
  
4.  Move the **Service** project to the beginning of the list, with the **Action ‘Start’**, and then move the **Client** project after the **Service** project, also with the **Action ‘Start’**, so the **Client** project is executed after the **Service** project.  
  
5.  Click **OK**, and then press F5 (or CTRL+F5) to run the sample.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Services\ConfigurationChannelFactory`
