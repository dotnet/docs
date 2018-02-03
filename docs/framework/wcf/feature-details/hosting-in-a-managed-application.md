---
title: "Hosting in a Managed Application"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: af70132d-e9e1-4f32-b20f-f0014629758a
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Hosting in a Managed Application
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services can be hosted in any [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] application. Self-hosting services is the most flexible hosting option because it requires the least infrastructure to deploy. However, it is also the least robust hosting option, because managed applications do not provide the advanced hosting and management features of other hosting options in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], such as Internet Information Services (IIS) and Windows services.  
  
 To create a self-hosted service, create and open an instance of the <xref:System.ServiceModel.ServiceHost>, which starts a service listening for messages. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Host a WCF Service in a Managed Application](../../../../docs/framework/wcf/how-to-host-a-wcf-service-in-a-managed-application.md).  
  
 For a complete example on how to define a contract, implement the contract, and host a service inside of a managed application see the [Getting Started Tutorial](../../../../docs/framework/wcf/getting-started-tutorial.md) and the [Self-Host](../../../../docs/framework/wcf/samples/self-host.md).  
  
 The following sections describe common scenarios that use this hosting option.  
  
## Console Applications  
 Common scenarios that self-hosting enables are [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services running inside console applications. Hosting a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service inside a console application is typically useful during the development phase of the service. This makes them easy to debug, easy to get trace information from to find out what is happening inside of the application, and easy to move around by copying them to new locations.  
  
## Rich Client Applications  
 Other common scenarios that self-hosting enables are rich client applications, such as those based on [!INCLUDE[avalon1](../../../../includes/avalon1-md.md)] or Windows Forms (WinForms). This hosting option also makes it easy for rich client applications, such as [!INCLUDE[avalon2](../../../../includes/avalon2-md.md)] and WinForms applications, to communicate with the outside world. For example, a peer-to-peer collaboration client that uses [!INCLUDE[avalon2](../../../../includes/avalon2-md.md)] for its user interface and also hosts a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service that allows other clients to connect to it and share information.  
  
## See Also  
 [Hosting Services](../../../../docs/framework/wcf/hosting-services.md)  
 [Getting Started Tutorial](../../../../docs/framework/wcf/getting-started-tutorial.md)
