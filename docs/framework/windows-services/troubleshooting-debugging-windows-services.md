---
title: "Troubleshooting: Debugging Windows Services"
description: Get started with debugging Windows services. When you debug a Windows service application, your service and the Windows Service Manager interact.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "debugging Windows Service applications"
  - "debugging [Visual Studio], Windows services"
  - "troubleshooting service applications"
  - "services, troubleshooting"
  - "troubleshooting debugging, Windows Services"
  - "Windows Service applications, debugging"
  - "services, debugging"
  - "Windows Service applications, troubleshooting"
ms.assetid: cf859d4c-f04c-4cb7-81e3-bc7de8bea190
---
# Troubleshooting: Debugging Windows Services

[!INCLUDE [windows-service-disambiguation](../../core/extensions/includes/windows-service-disambiguation.md)]

When you debug a Windows service application, your service and the **Windows Service Manager** interact. The **Service Manager** starts your service by calling the <xref:System.ServiceProcess.ServiceBase.OnStart%2A> method, and then waits 30 seconds for the <xref:System.ServiceProcess.ServiceBase.OnStart%2A> method to return. If the method does not return in this time, the manager shows an error that the service cannot be started.  
  
 When you debug the <xref:System.ServiceProcess.ServiceBase.OnStart%2A> method as described in [How to: Debug Windows Service Applications](how-to-debug-windows-service-applications.md), you must be aware of this 30-second period. If you place a breakpoint in the <xref:System.ServiceProcess.ServiceBase.OnStart%2A> method and do not step through it in 30 seconds, the manager will not start the service.  
  
## See also

- [How to: Debug Windows Service Applications](how-to-debug-windows-service-applications.md)
- [Introduction to Windows Service Applications](introduction-to-windows-service-applications.md)
