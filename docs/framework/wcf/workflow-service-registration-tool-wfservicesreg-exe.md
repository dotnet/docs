---
title: "WorkFlow Service Registration Tool (WFServicesReg.exe)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9e92c87b-99c5-4e8d-9d53-7944cc2b47d3
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WorkFlow Service Registration Tool (WFServicesReg.exe)
Workflow Services Registration tool (WFServicesReg.exe) is a stand-alone tool that can be used to add, remove, or repair the configuration elements for Windows Workflow Foundation (WF) services.  
  
## Syntax  
  
```  
WFServicesReg.exe [-c | -r | -v | -m | -i]  
```  
  
## Remarks  
 The tool can be found at the [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] installation location, specifically, %windir%\Microsoft.NET\Framework\v3.5, or at %windir%\Microsoft.NET\Framework64\v3.5 in 64-bit machines.  
  
 The following tables describe the options that can be used with the Workflow Services Registration tool (WFServicesReg.exe).  
  
|Option|Description|  
|------------|-----------------|  
|`/c`|Configures Windows Workflow Services. Used in install and repair scenarios.|  
|`/r`|Removes Windows Workflow Services Configuration.|  
|`/v`|Print verbose information (for either configuration or removal).|  
|`/m`|Enables MSI logging format.|  
|`/i`|Minimizes the window when the application runs.|  
  
## Registration  
 The tool inspects the Web.config file and registers the following:  
  
-   [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] reference assemblies.  
  
-   A build provider for .xoml files.  
  
-   HTTP handlers for .xoml and .rules files.  
  
 The tool inspects the Machine.config file and registers the following extensions:  
  
-   behaviorExtensions  
  
-   bindingElementExtensions  
  
-   bindingExtensions  
  
 The tool also registers the following client metadata importers:  
  
-   policyImporters  
  
-   wsdlImporters  
  
 The tool also registers .xoml and .rules scriptmaps and handlers in the IIS metabase.  
  
 On [!INCLUDE[ws2003](../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../includes/wxp-md.md)] machines (IIS 5.1 and [!INCLUDE[iis601](../../../includes/iis601-md.md)]), one set of .xoml and .rules scriptmaps are registered.  
  
 On 64-bit machines, the tool registers WOW mode scriptmaps if the `Enable32BitAppOnWin64` switch is enabled, or native 64-bit scriptmaps if the `Enable32BitAppOnWin64` switch is disabled.  
  
 On [!INCLUDE[wv](../../../includes/wv-md.md)] and Windows Server 2008 (IIS 7.0 and above) machines, two sets of .xoml and .rules handlers are registered: one for Integrated mode and one for Classic mode.  
  
 On 64-bit machines, three sets of handlers are registered (regardless of the state of the `Enable32BitAppOnWin64` switch): one for Integrated mode, one for WOW Classic mode and one for native 64-bit Classic mode.  
  
> [!NOTE]
>  Unlike ServiceModelreg.exe, WFServicesReg.exe does not allow adding, removing, or repairing scriptmaps or handlers for a particular Web site. For a workaround to this issue, see the "Repairing the Scriptmaps" section.  
  
## Usage Scenarios  
  
### Installing IIS after .NET Framework 3.5 is installed  
 On a [!INCLUDE[ws2003](../../../includes/ws2003-md.md)] machine, [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] is installed prior to IIS installation. Due to the unavailability of the IIS metabase, installation of [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] succeeds without installing .xoml and .rules scriptmaps.  
  
 After IIS is installed, you can use the WFServicesReg.exe tool with the `/c` switch to install these specific scriptmaps.  
  
### Repairing the Scriptmaps  
  
#### Scriptmap deleted under Web Sites node  
 On a [!INCLUDE[ws2003](../../../includes/ws2003-md.md)] machine, .xoml or .rules is accidentally deleted from the Web Sites node. This can be repaired by running the WFServicesReg.exe tool with the `/c` switch.  
  
#### Scriptmap deleted under a particular Web site  
 On a [!INCLUDE[ws2003](../../../includes/ws2003-md.md)] machine, .xoml or .rules is accidentally deleted from a particular Web site (for example, the Default Web Site) rather than from the Web Sites node.  
  
 To repair deleted handlers for a particular Web site, you should run "WFServicesReg.exe /r" to remove handlers from all Web sites, then run "WFServicesReg.exe /c" to create the appropriate handlers for all Web sites.  
  
### Configuring handlers after switching IIS mode  
 When IIS is in shared configuration mode and [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] is installed, the IIS metabase is configured under a shared location. If you switch IIS to non-shared configuration mode, the local metabase will not contain the required handlers. To configure the local metabase properly, you can either import the shared metabase to local, or run "WFServicesReg.exe /c", which configures the local metabase.
