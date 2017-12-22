---
title: "Renaming a WCF Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 14235a65-b1c5-409d-b6cc-a979acd54bbd
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Renaming a WCF Service
This topic describes how you can rename a [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] service.  
  
## Renaming a WCF Service  
 Perform the following steps to rename a service in a [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] template,  
  
-   Change the name of the class that implements the service.  
  
-   In the configuration file of the service, change the name of the service to the new name you have chosen, as indicated in the following example. The configuration file can be either app.config or web.config file depending on your hosting model.  
  
```xml  
<system.servicemodel>  
   <services>  
      <service name="WcfService.NewName">  
      </service>  
   </services>  
</system.servicemodel>  
```  
  
-   If your service is webhosted, it uses an *.svc file. Open the svc file and modify the name of your service as indicated in the following example. This step is not necessary for self-hosted applications, as there is no svc file.  
  
```  
<%@ ServiceHost Service="WcfService.NewName">  
```  
  
## Renaming a WCF Service Contract  
  
-   Perform the following steps to rename the service contract,  
  
-   Change the name of the service contract.  
  
-   In the configuration file of the service, change the name of the service contract to the new name you have chosen, as indicated in the following example. The configuration file can be either app.config or web.config file depending on your hosting model.  
  
```xml  
<system.servicemodel>  
   <services>  
      <service>  
         <endpoint contract="WcfService.NewContractName" />  
      </service>  
   </services>  
</system.servicemodel>  
```
