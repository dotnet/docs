---
title: "How to: Use Svcutil.exe to Validate Compiled Service Code"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d0d820fb-41c2-45b8-8f22-0fa5aeebbbaa
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Use Svcutil.exe to Validate Compiled Service Code
You can use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) to detect errors in service implementations and configurations without hosting the service.  
  
### To validate a service  
  
1.  Compile your service into an executable file and one or more dependent assemblies.  
  
2.  Open an SDK command prompt  
  
3.  At the command prompt, launch the Svcutil.exe tool using the following format. For more information on the various parameters, see the Service Validationsection of the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) topic.  
  
    ```  
    svcutil.exe /validate /serviceName:<serviceConfigName>  <assemblyPath>*  
    ```  
  
     You must use the `/serviceName` option to indicate the configuration name of the service you want to validate.  
  
     The `assemblyPath` argument specifies the path to the executable file for the service and one or more assemblies that contain the service types to be validated. The executable assembly must have an associated configuration file to provide the service configuration. You can use standard command-line wildcards to provide multiple assemblies.  
  
## Example  
 The following command the service myServiceName implemented in the myServiceHost.exe executable file.  The configuration file for the service (myServiceHost.exe.config) is automatically loaded.  
  
```  
svcutil /validate /serviceName:myServiceName myServiceHost.exe  
```  
  
## See Also  
 [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md)
