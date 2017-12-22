---
title: "How to: Enable the Net.TCP Port Sharing Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "port sharing [WCF]"
  - "activation services [WCF]"
ms.assetid: c9175af4-c27c-4765-bf45-b8f7528a7282
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Enable the Net.TCP Port Sharing Service
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] uses a Windows service called the Net.TCP Port Sharing Service to facilitate the sharing of TCP ports across multiple processes. This service is installed as part of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], but the service is not enabled by default as a security precaution and so must be manually enabled prior to first use. This topic describes how to configure the Net TCP Port Sharing Service using the Microsoft Management Console (MMC) snap-In.  
  
 After you enable the Net.TCP Port Sharing Service and start it manually, see [How to: Configure a WCF Service to Use Port Sharing](../../../../docs/framework/wcf/feature-details/how-to-configure-a-wcf-service-to-use-port-sharing.md) for information about how to configure your service to use this service.  
  
 For a sample that uses net.tcp:// port sharing, see the [Net.TCP Port Sharing Sample](../../../../docs/framework/wcf/samples/net-tcp-port-sharing-sample.md).  
  
### To enable the Net.TCP Port Sharing Service using MMC  
  
1.  From the Start menu, open the Services Management Console either by opening a Command Prompt window and typing `services.msc` or by opening Run and typing `services.msc` into the Open box.  
  
2.  In the **Name** column of the list of services, right-click the **Net.Tcp Port Sharing Service**, and select **Properties** from the menu.  
  
3.  To enable the manual start-up of the service, in the **Properties** window select the **General** tab, and in the **Startup type** box select Manual, and then click **Apply**.  
  
4.  To start the service,  in the Service status area, click the **Start** button. The service status should now display "Started".  
  
5.  To return to the list of services, click the **OK**, and exit the MMC Console.  
  
## Example  
  
## See Also  
 [Net.TCP Port Sharing](../../../../docs/framework/wcf/feature-details/net-tcp-port-sharing.md)  
 [Configuring the Net.TCP Port Sharing Service](../../../../docs/framework/wcf/feature-details/configuring-the-net-tcp-port-sharing-service.md)
