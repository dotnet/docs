---
title: "Using the WCF Development Tools"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 054adb87-c244-4d5a-83d1-0b2b44bd454b
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using the WCF Development Tools
This section describes the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)][!INCLUDE[indigo1](../../../includes/indigo1-md.md)] development tools that can assist you in developing your [!INCLUDE[indigo2](../../../includes/indigo2-md.md)]service.  
  
 You can use the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)][!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] templates as a foundation to quickly build your own service, then use [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Auto Host and [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client to debug and test your service. These tools together provide a fast and seamless debug and testing cycle, and preclude the need to commit to a hosting model at an early stage.  
  
## The WCF Developer Tools  
 [WCF Visual Studio Templates](../../../docs/framework/wcf/wcf-vs-templates.md)  
  
 You can use the predefined [!INCLUDE[indigo2](../../../includes/indigo2-md.md)][!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] project and item templates in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] to quickly build [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services and surrounding applications.  
  
 [WCF Service Host (WcfSvcHost.exe)](../../../docs/framework/wcf/wcf-service-host-wcfsvchost-exe.md)  
  
 The [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Auto Host (WcfSvcHost.exe) allows you to launch the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] debugger (F5) to automatically host and test a service you have implemented. You can then test the service using the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client (wcfTestClient.exe) or your own client to find and fix any potential errors.  
  
 [WCF Test Client (WcfTestClient.exe)](../../../docs/framework/wcf/wcf-test-client-wcftestclient-exe.md)  
  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Test Client (WcfTestClient.exe) is a GUI tool that allows you to input parameters of arbitrary types, submit that input to the service, and view the response the service sends back. It provides a seamless service testing experience when combined with [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Auto Host.  
  
 [Generating Data Type Classes from XML](../../../docs/framework/wcf/generating-data-type-classes-from-xml.md)  
  
 XML data stored in the clipboard can be pasted into a code page. The classes defined in the data will be converted to code types.  
  
## Using the Tools without Administrator privilege  
 To enable users without administrator privilege to develop [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services, an ACL (Access Control List) is created for the namespace "http://+:8731/Design_Time_Addresses" during the installation of [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)]. The ACL is set to (UI), which includes all interactive users logged on to the machine. Administrators can add or remove users from this ACL, or open additional ports.This ACL enables WCF or WF templates to send and receive data in their default configuration. It also enables users to use the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] Service Auto Host (wcfSvcHost.exe) without granting them administrator privileges.  
  
 You can modify access using the Netsh.exe tool in [!INCLUDE[wv](../../../includes/wv-md.md)] under the elevated administrator account. The following is an example of using Netsh.exe.  
  
```  
netsh http add urlacl url=http://+:8001/MyService user=<domain>\<user>  
```  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] Netsh.exe, see [How to Use the Netsh.exe Tool and Command-Line Switches](http://go.microsoft.com/fwlink/?LinkId=97877).  
  
## See Also  
 [WCF Visual Studio Templates](../../../docs/framework/wcf/wcf-vs-templates.md)  
 [WCF Service Host (WcfSvcHost.exe)](../../../docs/framework/wcf/wcf-service-host-wcfsvchost-exe.md)  
 [WCF Test Client (WcfTestClient.exe)](../../../docs/framework/wcf/wcf-test-client-wcftestclient-exe.md)
