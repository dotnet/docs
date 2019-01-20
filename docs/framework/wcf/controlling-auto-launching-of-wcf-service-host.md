---
title: "Controlling Auto-launching of WCF Service Host"
ms.date: "03/30/2017"
f1_keywords: 
  - "WcfOptions"
ms.assetid: 6abe5d34-519b-4cef-8f02-3c0a7f125585
---
# Controlling Auto-launching of WCF Service Host
You can control the auto-launching capability of Windows Communication Foundation (WCF) Service Host (WcfSvcHost.exe) for a WCF Service Library project, when you debug another project in the same Visual Studio solution containing multiple projects.  
  
 To do so, right-click the WCF Service Project in **Solution Explorer**, choose **Properties**, and click **WCF Options** tab. The **Start WCF Service Host when debugging another project in the same solution** check box is enabled by default. You can clear the box so that WCF Service Host for this specific project is not launched when another project is debugged in the same solution.  
  
 This behavior does not affect the F5 debugging, or Add Service Reference functionalities for this project.  
  
 This option is available to the following projects:  
  
-   WCF Service Library Project.  
  
-   Sequential Workflow Service Library Project.  
  
-   State Machine Workflow Service Library Project.  
  
-   Syndication Service Library Project.  
  
## See also
 [WCF Service Host (WcfSvcHost.exe)](../../../docs/framework/wcf/wcf-service-host-wcfsvchost-exe.md)
