---
title: "Troubleshooting: Service Application Won't Install"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "troubleshooting service applications"
  - "services, troubleshooting"
  - "services, debugging"
  - "Windows NT services, troubleshooting"
  - "troubleshooting NT services"
  - "Windows Service applications, troubleshooting"
ms.assetid: 45c48e2e-b97d-44bc-8896-14f328e0ce33
author: "ghogen"
---
# Troubleshooting: Service Application Won't Install
If your service application will not install correctly, check to make sure that the <xref:System.ServiceProcess.ServiceBase.ServiceName%2A> property for the service class is set to the same value as is shown in the installer for that service. The value must be the same in both instances in order for your service to install correctly.  
  
> [!NOTE]
>  You can also look at the installation logs to get feedback on the installation process.  
  
 You should also check to determine whether you have another service with the same name already installed. Service names must be unique for installation to succeed.  
  
## See also

- [Introduction to Windows Service Applications](../../../docs/framework/windows-services/introduction-to-windows-service-applications.md)
