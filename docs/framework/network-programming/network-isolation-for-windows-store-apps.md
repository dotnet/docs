---
title: "Network Isolation for Windows Store Apps"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b064497c-d956-46b8-838d-7a0223c7e200
caps.latest.revision: 7
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Network Isolation for Windows Store Apps
Classes in the <xref:System.Net>,  <xref:System.Net.Http>, and <xref:System.Net.Http.Headers> namespaces can be used to develop Windows Store  apps  or desktop apps. When used in a Windows Store app, classes in these namespaces are affected by network isolation, part of the application security model used by the [!INCLUDE[win8](../../../includes/win8-md.md)]. The appropriate network capabilities must be enabled in the app manifest for a Windows Store app for the system to allow network access.  
  
## Checklist for Network Isolation  
 Use this checklist to be sure that network isolation is configured for your Windows Store app.  
  
1.  Determine the direction of network access requests needed by the app. This can be either outbound client-initiated requests or inbound unsolicited requests or it could be a combination of both of these network request types.  
  
2.  Determine the type of network resources that that app will communicate with. An app may need to communicate with trusted resources on a Home or Work network. An app might need to communicate with resources on the Internet. An app might need access to both types of network resources.  
  
3.  Configure the minimum-required networking isolation capabilities in the app manifest.  
  
4.  Deploy and run your app to test it using the network isolation tools provided for troubleshooting.  
  
 For more detailed information on how to configure network capabilities and isolation tools used for troubleshooting network isolation, see [How to configure network isolation capabilities](http://go.microsoft.com/fwlink/?LinkID=228265) in the [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] developer documentation.  
  
## See Also  
 [Connecting to a web service](http://go.microsoft.com/fwlink/?LinkID=245696)  
 [Guidelines and checklist for network isolation](http://go.microsoft.com/fwlink/?LinkID=228265)  
 [Quickstart: Connecting using HttpClient](http://go.microsoft.com/fwlink/?LinkId=245697)  
 [How to use HttpClient handlers](http://go.microsoft.com/fwlink/?LinkId=245699)  
 [How to secure HttpClient connections](http://go.microsoft.com/fwlink/?LinkId=245698)  
 [HttpClient Sample](http://go.microsoft.com/fwlink/?LinkId=242550)
