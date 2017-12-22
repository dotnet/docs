---
title: "Deploying an Internet Information Services-Hosted WCF Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 04ebd329-3fbd-44c3-b3ab-1de3517e27d7
caps.latest.revision: 30
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Deploying an Internet Information Services-Hosted WCF Service
Developing and deploying a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service that is hosted in Internet Information Services (IIS) consists of the following tasks:  
  
-   Ensure that IIS, ASP.NET, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], and the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] activation component are correctly installed and registered.  
  
-   Create a new IIS application, or reuse an existing [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] application.  
  
-   Create a .svc file for the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
-   Deploy the service implementation to the IIS application.  
  
-   Configure the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
 For a detailed walkthrough of creating an IIS-hosted [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service, see [How to: Host a WCF Service in IIS](../../../../docs/framework/wcf/feature-details/how-to-host-a-wcf-service-in-iis.md).  
  
## Ensure That IIS, ASP.NET and WCF Are Correctly Installed and Registered  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], IIS, and ASP.NET must be installed for IIS-hosted [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services to function correctly. The procedures for installing [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] (as part of the [!INCLUDE[vstecwinfx](../../../../includes/vstecwinfx-md.md)]), ASP.NET and IIS vary depending on the operating system version being used. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] installing [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and the [!INCLUDE[vstecwinfx](../../../../includes/vstecwinfx-md.md)], see [Microsoft .NET Framework 4 Web Installer](http://go.microsoft.com/fwlink/?LinkId=201185). Instructions for installing IIS can be found at [Installing IIS](http://go.microsoft.com/fwlink/?LinkId=201188).  
  
 The installation process for the [!INCLUDE[vstecwinfx](../../../../includes/vstecwinfx-md.md)] automatically registers [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] with IIS if IIS is already present on the machine. If IIS is installed after the [!INCLUDE[vstecwinfx](../../../../includes/vstecwinfx-md.md)], an additional step is required to register [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] with IIS and [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)]. You can do this as follows, depending on your operating system:  
  
-   [!INCLUDE[wxpsp2](../../../../includes/wxpsp2-md.md)], Windows 7, and [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)]: Use the [ServiceModel Registration Tool (ServiceModelReg.exe)](../../../../docs/framework/wcf/servicemodelreg-exe.md) tool to register [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] with IIS: To use this tool, type **ServiceModelReg.exe /i /x** in the Visual Studio command prompt. You can open this command prompt by clicking the start button, selecting **All Programs**, **Microsoft Visual Studio 2012**, **Visual Studio Tools**, and **Visual Studio Command Prompt**  
  
-   [!INCLUDE[wv](../../../../includes/wv-md.md)]: Install the Windows Communication Foundation Activation Components subcomponent of the [!INCLUDE[vstecwinfx](../../../../includes/vstecwinfx-md.md)]. To do this, in Control Panel, click **Add or Remove Programs** and then **Add\/Remove Windows Components**. This activates the **Windows Component Wizard**.  
  
-   Windows 7:  
  
 Finally you must verify that ASP.NET is configured to use the .NET Framework version 4. You do this by running the ASPNET_Regiis tool with the –i option. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [ASP.NET IIS Registration Tool](http://go.microsoft.com/fwlink/?LinkId=201186)  
  
## Create a New IIS Application or Reuse an Existing ASP.NET Application  
 IIS-hosted [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services must reside inside of an IIS application. You can create a new IIS application to host [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services exclusively. Alternatively, you can deploy an [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service into an existing application that is already hosting [!INCLUDE[vstecasplong](../../../../includes/vstecasplong-md.md)] content (such as .aspx pages and ASP.NET Web services [ASMX]). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] these options, see the "Hosting WCF Side-by-Side with ASP.NET" and "Hosting WCF Services in ASP.NET Compatibility Mode" sections in [WCF Services and ASP.NET](../../../../docs/framework/wcf/feature-details/wcf-services-and-aspnet.md).  
  
 Note that [!INCLUDE[iis601](../../../../includes/iis601-md.md)] and later versions periodically restart an isolated object-oriented programming application. The default value is 1740 minutes. The maximum value supported is 71,582 minutes. This restart can be disabled. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] this property, see the [PeriodicRestartTime](http://go.microsoft.com/fwlink/?LinkId=109968).  
  
## Create an .svc File for the WCF Service  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services hosted in IIS are represented as special content files (.svc files) inside the IIS application. This model is similar to the way ASMX pages are represented inside of an IIS application as .asmx files. A .svc file contains a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]-specific processing directive ([@ServiceHost](../../../../docs/framework/configure-apps/file-schema/wcf-directive/servicehost.md)) that allows the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] hosting infrastructure to activate hosted services in response to incoming messages. The most common syntax for a .svc file is in the following statement.  
  
```  
<% @ServiceHost Service="MyNamespace.MyServiceImplementationTypeName" %>  
```  
  
 It consists of the [@ServiceHost](../../../../docs/framework/configure-apps/file-schema/wcf-directive/servicehost.md) directive and a single attribute, `Service`. The value of the `Service` attribute is the common language runtime (CLR) type name of the service implementation. Using this directive is basically equivalent to creating a service host using the following code.  
  
```  
new ServiceHost( typeof( MyNamespace.MyServiceImplementationTypeName ) );  
```  
  
 Additional hosting configuration, such as creating a list of base addresses for the service can also be done. You can also use a custom <xref:System.ServiceModel.Activation.ServiceHostFactory> to extend the directive for use with custom hosting solutions. The IIS applications that host [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services are not responsible for managing the creation and lifetime of <xref:System.ServiceModel.ServiceHost> instances. The managed [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] hosting infrastructure creates the necessary <xref:System.ServiceModel.ServiceHost> instance dynamically when the first request is received for the .svc file. The instance is not released until either it is closed explicitly by code or when the application is recycled.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the syntax for .svc files, see [@ServiceHost](../../../../docs/framework/configure-apps/file-schema/wcf-directive/servicehost.md).  
  
## Deploy the Service Implementation to the IIS Application  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services hosted in IIS use the same dynamic compilation model as [!INCLUDE[vstecasplong](../../../../includes/vstecasplong-md.md)]. Just as with [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)], you can deploy the implementation code for IIS-hosted [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services in several ways at various locations, as follows:  
  
-   As a precompiled .dll file located in the global assembly cache (GAC) or in the application’s \bin directory. Precompiled binaries are not updated until a new version of the class library is deployed.  
  
-   As un-compiled source files located in the application’s \App_Code directory. Source files located in this directory are dynamically required when processing the application’s first request. Any changes to files in the \App_Code directory cause the entire application to be recycled and recompiled when the next request is received.  
  
-   As un-compiled code placed directly in the .svc file. Implementation code can also be located inline in the service’s .svc file, after the @ServiceHost directive. Any changes to inline code cause the application to be recycled and recompiled when the next request is received.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the [!INCLUDE[vstecasplong](../../../../includes/vstecasplong-md.md)] compilation model, see [ASP.NET Compilation Overview](http://go.microsoft.com/fwlink/?LinkId=94773).  
  
## Configure the WCF Service  
 IIS-hosted [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services store their configuration in the applications Web.config file. IIS-hosted services use the same configuration elements and syntax as [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services hosted outside of IIS. However, the following constraints are unique to the IIS hosting environment:  
  
-   Base addresses for IIS-hosted services.  
  
-   Applications hosting [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services outside of IIS can control the base address of the services they host by passing a set of base address URIs to the <xref:System.ServiceModel.ServiceHost> constructor or by providing a [\<host>](../../../../docs/framework/configure-apps/file-schema/wcf/host.md) element in the service’s configuration. Services hosted in IIS do not have the ability to control their base address; the base address of an IIS-hosted service is the address of its .svc file.  
  
### Endpoint Addresses for IIS-Hosted Services  
 When hosted in IIS, endpoint addresses are always considered to be relative to the address of the .svc file that represents the service. For example, if the base address of a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service is http://localhost/Application1/MyService.svc with the following endpoint configuration.  
  
```xml  
<endpoint address="anotherEndpoint" .../>  
```  
  
 This provides an endpoint that can be reached at "http://localhost/Application1/MyService.svc/anotherEndpoint".  
  
 Similarly, the endpoint configuration element that uses an empty string as the relative address provides an endpoint reachable at http://localhost/Application1/MyService.svc, which is the base address.  
  
```xml  
<endpoint address="" ... />  
```  
  
 You must always use relative endpoint addresses for IIS-hosted service endpoints. Supplying a fully-qualified endpoint address (for example, http://localhost/MyService.svc) can lead to errors in the deployment of the service if the endpoint address does not point to the IIS-application that hosts the service exposing the endpoint. Using relative endpoint addresses for hosted services avoids these potential conflicts.  
  
### Available Transports  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services hosted in IIS 5.1 and [!INCLUDE[iis601](../../../../includes/iis601-md.md)] are restricted to using HTTP-based communication. On these IIS platforms, configuring a hosted service to use a non-HTTP binding results in an error during service activation. For [!INCLUDE[iisver](../../../../includes/iisver-md.md)], the supported transports include HTTP, Net.TCP, Net.Pipe, Net.MSMQ, and msmq.formatname for backwards compatibility with existing MSMQ applications.  
  
### HTTP Transport Security  
 IIS-hosted [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services can make use of HTTP transport security (for example, HTTPS and HTTP authentication schemes such as Basic, Digest, and Windows Integrated Authentication) as long as the IIS virtual directory that contains the service supports those settings. The HTTP Transport Security settings on a hosted endpoint’s binding must match the transport security settings on the IIS virtual directory that contains it.  
  
 For example, a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint configured to use HTTP digest authentication must reside in an IIS virtual directory that is also configured to allow HTTP digest authentication. Unmatched combinations of IIS settings and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint settings result in an error during service activation.  
  
## See Also  
 [Hosting in Internet Information Services](../../../../docs/framework/wcf/feature-details/hosting-in-internet-information-services.md)  
 [Internet Information Services Hosting Best Practices](../../../../docs/framework/wcf/feature-details/internet-information-services-hosting-best-practices.md)  
 [Windows Server App Fabric Hosting Features](http://go.microsoft.com/fwlink/?LinkId=201276)
