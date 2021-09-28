---
description: "Learn more about: How to: Deploy a COM+ Integration Application"
title: "How to: Deploy a COM+ Integration Application"
ms.date: "03/30/2017"
ms.assetid: 2e5a0510-db3c-4988-a09c-696285836650
---
# How to: Deploy a COM+ Integration Application

Once you have written a COM+ integration application, you may want to deploy it on another machine. This topic describes how to move a COM+ integration application from one machine to another.  
  
### Moving a COM+ hosted Integration App  
  
1. Ensure that WCF is installed on both machines.  
  
2. Export the application from machine A.  
  
3. Import the application on machine B.  
  
4. Set the Application Root Directory. By convention, this is %PROGRAMFILES%/ComPlus Applications/{AppGUID}.  
  
5. Copy the Application.config and Application.manifest files from the application root directory on machine A to the application root directory on machine B.  
  
6. Edit the service endpoint addresses in the Application.config file on machine B to identify the appropriate machine. For example, change `http://machineA/MyService` to `http://machineB/MyService`.  
  
### Moving a Web-hosted integration application  
  
1. Ensure that WCF is installed on both machines.  
  
2. Export the application from machine A.  
  
3. Import the application on machine B.  
  
4. Create an IIS vroot on machine B.  
  
5. Copy the .svc file (componentName.svc) and the Web.config file from the vroot on machine A to the newly created vroot on machine B.  
  
## See also

- [Integrating with COM+ Applications Overview](integrating-with-com-plus-applications-overview.md)
- [How to: Configure COM+ Service Settings](how-to-configure-com-service-settings.md)
- [How to: Use the COM+ Service Model Configuration Tool](how-to-use-the-com-service-model-configuration-tool.md)
