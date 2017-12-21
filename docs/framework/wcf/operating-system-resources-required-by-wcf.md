---
title: "Operating System Resources Required by WCF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cdd9a331-53fe-4e0d-bdfe-782264aec5c9
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Operating System Resources Required by WCF
[!INCLUDE[indigo1](../../../includes/indigo1-md.md)] depends on several resources that are provided by the operating system to function. The following table lists those resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|Microsoft Distributed Transaction Coordinator (MSDTC)|Required to support OleTx transactions.|  
|Internet Information Services (IIS)|Required if you want to use IIS to host your application.|  
|Windows Process Activation Service (WAS)|Required if you want to use WAS to host your application.|  
  
## See Also  
 [System Requirements](../../../docs/framework/wcf/wcf-system-requirements.md)
