---
title: "WCF Visual Studio Templates"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6a608575-3535-4190-89da-911e24c8374f
caps.latest.revision: 31
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Visual Studio Templates
[!INCLUDE[indigo1](../../../includes/indigo1-md.md)] [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] templates are predefined project and item templates you can use in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] to quickly build [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services and surrounding applications.  
  
## Using the WCF Templates  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] templates provide a basic class structure for service development. Specifically, these templates provide the basic definitions for service contract, data contract, service implementation, and configuration. You can use these templates to create a simple service with minimal code interaction, as well as a building block for more advanced services.  
  
### WCF Service Library Project Template  
 The [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Library project template is available in the new project dialog box under **Visual C#\WCF** and **Visual Basic\WCF**.  
  
 When you create a new project using the **WCF Service** template, the new project automatically includes the following three files:  
  
-   Service contract file (IService1.cs or IService1.vb). The service contract file is an interface that has [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service attributes applied. This file provides a definition of a simple service to show you how to define your services, and includes parameter-based operations and a simple data contract sample. This is the default file displayed in the code editor after creating a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service project.  
  
-   Service implementation file (Service1.cs or Service1.vb). The service implementation file implements the contract defined in the service contract file.  
  
-   Application configuration file (App.config). The configuration file provides the basic elements of a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service model with a secure HTTP binding. It also includes an endpoint for the service and enables metadata exchange.  
  
> [!NOTE]
>  [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] is configured to recognize the App.config file as the configuration file for the project when it is run using the [WCF Service Host (WcfSvcHost.exe)](../../../docs/framework/wcf/wcf-service-host-wcfsvchost-exe.md), which is the default configuration. If you host the service library in an executable, you have to move the configuration code to the configuration file of the executable, as configuration files for DLLs are not valid.  
  
### WCF Service Application Template  
 The [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Application template is available in the New Project dialog box under **Visual C#\WCF** and **Visual Basic\WCF**.  
  
 When you create a new project using the **WCF Web Application Service** template, the project includes the following four files:  
  
-   Service host file (service1.svc).  
  
-   Service contract file (IService1.cs or IService1.vb).  
  
-   Service implementation file (Service1.svc.cs or Service1.svc.vb).  
  
-   Web configuration file (Web.config).  
  
 The template automatically creates a Web site (to be deployed to a virtual directory) and hosts a service in it.  
  
### WCF Web Site Template  
 The [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Web Site template is available in the New Project dialog box under **Visual C#\Web Site\WCF Service** and **Visual Basic\Web Site\WCF Service**. This creates the same files as the WCF Service Application template but organizes it as if it were a ASP.NET web site. App_Code and App_Data folders are created.  
  
### WCF Service Item Template  
 The [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Item template is a custom template that provides a quick way to add [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services to your existing [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] projects.  
  
 To use this template, go to the **Solution Explorer** pane, right-click your project name, point to **Add**, and then click **New Item** to launch the **Add New Item** dialog box.  
  
 The service interface and implementation files are placed in the root project folder.  
  
 The template attempts to merge the configuration section of the new service to the existing configuration file, if they are compatible types.  
  
 A service host file (service1.svc) is also created if the existing project is a Web project.  
  
### WCF WF Service Project and Item Template.  
 These templates create [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services that host a Workflow Service, which is a workflow that can be accessed like a web service. Separate templates exist for XAML or imperative programming models. Using the templates, you can create sequential or state machine workflow. For more information on these types of workflow, see [Windows Workflow Foundation Tutorials](http://msdn.microsoft.com/library/e9705654-bd96-4b56-8d98-f1f118112d97). [!INCLUDE[crabout](../../../includes/crabout-md.md)] creating workflow projects, see [Creating Legacy Workflow Projects](/visualstudio/workflow-designer/creating-legacy-workflow-projects).  
  
 [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] designer is more responsive when XOML type workflows are used instead of code based ones. XOML workflow is the default workflow type to be created.  
  
### WCF Syndication Service Library Template  
 This template enables you to expose your feed in the RSS or ATOM format as a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service. For more information, see [WCF Syndication](../../../docs/framework/wcf/feature-details/wcf-syndication.md).  
  
#### Changing the Address of the Feed  
 The syndication template uses Internet Explorer during execution. When you right-click your project in **Solutions Explorer** in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], select **Properties**, then select the **Debug** tab and you can see the default address of the template. Internet Explorer attempts to open the feed at this address.  
  
 If you change the address of your feed, you must also change the address in the **Debug** tab. If you do not do this, Internet Explorer attempts to open the feed at the default address and fail.  
  
### AJAX enabled WCF Service Item Template  
 This template exposes an AJAX control as a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service. For more information on AJAX controls, see the [AJAX control documentation](http://go.microsoft.com/fwlink/?LinkId=96717).  
  
### Silverlight-enabled WCF Service Item Template  
 This template creates a Web service that provides data to a Silverlight client or front-end. The template can be added to a Web site or Web application project to create a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service, which includes service code and configuration that support communicating with a Silverlight client. You can then use **Add Service Reference** to add a client proxy of the service to the client, and exchange data between the Silverlight client and the Silverlight-enabled WCF service.  
  
 To access this template, right-click a Web site or Web application project in **Solution Explorer**, click **Add a new item**, and click **Silverlight-enabled WCF Service**.  
  
> [!NOTE]
>  The Silverlight-enabled WCF Service exposes a `basicHttpBinding` endpoint without enabling any security settings. Therefore, information about the service can be obtained by all clients that connect to this service. Messages exchanged between the service and the client are also not signed or encrypted. To secure the endpoint properly, you should use ASP.NET authentication, HTTPS or other mechanisms.  
  
## See Also  
 [WCF Service Host (WcfSvcHost.exe)](../../../docs/framework/wcf/wcf-service-host-wcfsvchost-exe.md)  
 [WCF Test Client (WcfTestClient.exe)](../../../docs/framework/wcf/wcf-test-client-wcftestclient-exe.md)
