---
description: "Learn more about: How to: Use Svcutil.exe to Validate Compiled Service Code"
title: "How to: Use Svcutil.exe to Validate Compiled Service Code"
ms.date: "03/30/2017"
ms.assetid: d0d820fb-41c2-45b8-8f22-0fa5aeebbbaa
---
# How to: Use Svcutil.exe to Validate Compiled Service Code

You can use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../servicemodel-metadata-utility-tool-svcutil-exe.md) to detect errors in service implementations and configurations without hosting the service.  
  
### To validate a service  
  
1. Compile your service into an executable file and one or more dependent assemblies.  
  
2. Open an SDK command prompt  
  
3. At the command prompt, launch the Svcutil.exe tool using the following format. For more information on the various parameters, see the Service Validationsection of the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../servicemodel-metadata-utility-tool-svcutil-exe.md) topic.  
  
    ```console
    svcutil.exe /validate /serviceName:<serviceConfigName>  <assemblyPath>*  
    ```  
  
     You must use the `/serviceName` option to indicate the configuration name of the service you want to validate.  
  
     The `assemblyPath` argument specifies the path to the executable file for the service and one or more assemblies that contain the service types to be validated. The executable assembly must have an associated configuration file to provide the service configuration. You can use standard command-line wildcards to provide multiple assemblies.  
  
## Example  

 The following command the service myServiceName implemented in the myServiceHost.exe executable file.  The configuration file for the service (myServiceHost.exe.config) is automatically loaded.  
  
```console  
svcutil /validate /serviceName:myServiceName myServiceHost.exe  
```  
  
## See also

- [ServiceModel Metadata Utility Tool (Svcutil.exe)](../servicemodel-metadata-utility-tool-svcutil-exe.md)
