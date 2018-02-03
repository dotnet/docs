---
title: "WCF Service Publishing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c806b253-cd47-4b96-b831-e73cbf08808f
caps.latest.revision: 22
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Service Publishing
[!INCLUDE[indigo1](../../../includes/indigo1-md.md)] Service Publishing assists you in progressing from the early development environment provided by [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Host and [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client to actually deploying the application to a production environment for testing purposes. Before you commit to a final deployment plan, you can use [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] Service Publishing to verify that your [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service performs correctly and is ready to be published. You can also choose to deploy your [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service libraries to various target locations for testing.  
  
## Supported Services and Target Locations  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Publishing supports publishing [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services created from the set of [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service library templates, and their corresponding item templates, which include the following:  
  
-   [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Library template with item template.  
  
-   Syndication Service Library.  
  
 You can find these service templates by choosing **File** -> **New Project** -> **Visual Basic** or **Visual C#** -> **WCF**. For other WCF templates in this location (including WCF Workflow Service Application and WCF Service Application) you can publish using [One-Click publishing for web applications](https://msdn.microsoft.com/library/dd465337\(v=vs.110\).aspx).  
  
 The service can be published to the following target locations.  
  
-   Local IIS.  
  
-   File System.  
  
-   FTP Site.  
  
## Using WCF Service Publishing  
 Perform the following steps to deploy a service implementation:  
  
1.  Open Visual Studio with elevated privilege ( right-click the executable and use "Run as Administrator" to launch it).  If you are using IIS 7.0 or later, ensure that you have installed the "IIS Metabase and IIS6 Configuration Compatibility" component using "'Turn Windows features on or off" in Control Panel.  
  
2.  Open a service project, select **Build**->**Publish \<Project Name>** from the main menu, or right-click the project in **Solution Explorer** and click **Publish**.  
  
3.  The **Publish** window appears. Click the **…**. button to specify the target location that the service should be deployed to. You can select to deploy the application to local IIS, File System, or FTP Site. If deploying the application to local IIS, you can select your website and create your web application under it, by clicking the **Create New Web Application** icon at the top right corner.  
  
4.  After you click **Publish** in the main window, Visual Studio deploys the application to the specified target location and copies the Web.config, .svc, and assembly files to the target directory. . The name of .svc will be "ProjectName.ServiceName.svc". After the service is published successfully, you can find a hotlink in the Visual Studio Output window, which looks similar to "Connecting to  HYPERLINK "http://localhost/WebApplicationFolderName" http://localhost/WebApplicationFolderName ...". You can press CTRL and click the link to open a browser page inside Visual Studio to view the service directory structure.  
  
     If you cannot browse to the site, it may because directory browser is not enabled in IIS. Please follow the tips in the "Things you can try" section to enable it. Alternatively, you can directly type" HYPERLINK "http://localhost/WebApplicationFolderName" http://localhost/WebApplicationFolderName/ProjectName.ServiceName.svc" to view your service page.  
  
 You can use **Publish** to specify if you want to copy the assembly, configuration, and .svc file for all services defined in the project to the target location, and overwrite existing files at the destination.  
  
 If you choose to deploy your application to local IIS, you may encounter errors related to IIS setup. Please ensure that IIS is installed properly. You can type " HYPERLINK "http://localhost" http://localhost" in your browser and check whether the IIS default page is showing up.  In some cases, the issues may also be caused by ASP.NET or [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] improper registration in IIS. You can open the Visual Studio Command Prompt and run the command "aspnet_regiis.exe -ir" to fix ASP.NET registration issues, or run command "ServiceModelReg.exe –ia" to fix WCF registration issues.  
  
## Files Generated for Publishing  
 Before a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service library can be Web-hosted, the following files are generated by the tool: assembly files, Web.config file, and .svc file. All the files are copied to the target location. The service is then published.  
  
### Assembly files  
 When you publish a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service using this tool, the service is automatically built first and the assembly files are generated in the service project after building.  
  
### .SVC File  
 The publishing operation generates a *.svc file for each [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service, whether the file exists or not, to ensure version validity. There are two different kinds of svc files: one for [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Library and Syndication Service Library, and another one for Sequential and State Machine Workflow Service Library. The generated \*.svc file is copied to the root folder in the target location.  
  
### Web.config File  
 Each time a service project is published to a specific target location, a Web.config file is created.  
  
 The generated Web.config file includes Web sections that are useful for Web hosting, and the content of App.config for the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service library with the following changes:  
  
-   The base address is excluded.  
  
-   Settings in the `<diagnostics>` element are excluded to preserve the tracing settings of the target platform.  
  
## Publishing WCF services with non-HTTP Bindings to IIS  
 If you are using IIS7.0 or later, you can publish [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services with non-HTTP bindings to IIS. You need to do some pre-configurations. For more information, please see the topics at  [Hosting in Windows Process Activation Service](../../../docs/framework/wcf/feature-details/hosting-in-windows-process-activation-service.md).  
  
## Security  
 Publishing to local IIS requires administrator privilege, because IIS requires running in Administrator account. If a user without administrator privilege opens [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Publishing, IIS is not available as a target location. Publishing to File System, or FTP Site works without administrator privilege.  
  
## See Also  
 [WCF Visual Studio Templates](../../../docs/framework/wcf/wcf-vs-templates.md)  
 [WCF Service Host (WcfSvcHost.exe)](../../../docs/framework/wcf/wcf-service-host-wcfsvchost-exe.md)  
 [WCF Test Client (WcfTestClient.exe)](../../../docs/framework/wcf/wcf-test-client-wcftestclient-exe.md)
