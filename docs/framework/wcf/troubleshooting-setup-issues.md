---
title: "Troubleshooting Setup Issues"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1644f885-c408-4d5f-a5c7-a1a907bc8acd
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Troubleshooting Setup Issues
This topic describes how to troubleshoot [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] set up issues.  
  
## Some Windows Communication Foundation Registry Keys are not Repaired by Performing an MSI Repair Operation on the .NET Framework 3.0  
 If you delete any of the following registry keys:  
  
-   HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\ServiceModelService 3.0.0.0  
  
-   HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\ServiceModelOperation 3.0.0.0  
  
-   HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\ServiceModelEndpoint 3.0.0.0  
  
-   HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SMSvcHost 3.0.0.0  
  
-   HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\MSDTC Bridge 3.0.0.0  
  
 The keys are not re-created if you run repair by using the .NET Framework 3.0 installer launched from the **Add/Remove Programs** applet in **Control Panel**. To recreate these keys correctly, the user must uninstall and reinstall the .NET Framework 3.0.  
  
## WMI Service Corruption Blocks Installation of the Windows Communication Foundation WMI provider during installation of .NET Framework 3.0 package  
 WMI Service Corruption may block the installation of the Windows Communication Foundation WMI provider. During installation the Windows Communication Foundation installer is unable to register the WCF .mof file using the mofcomp.exe component. The following is a list of symptoms:  
  
1.  .NET Framework 3.0 installation completes successfully, but the WCF WMI provider is not registered.  
  
2.  An error event appears in the application event log that references problems registering the WMI provider for WCF, or running mofcomp.exe.  
  
3.  The setup log file named dd_wcf_retCA* in the user's %temp% directory contains references to failure to register the WCF WMI provider.  
  
4.  An exception such as one the following may be listed in the event log or setup trace log file:  
  
     ServiceModelReg [11:09:59:046]: System.ApplicationException: Unexpected result 3 executing E:\WINDOWS\system32\wbem\mofcomp.exe with "E:\WINDOWS\Microsoft.NET\Framework\v3.0\Windows Communication Foundation\ServiceModel.mof"  
  
     or:  
  
     ServiceModelReg [07:19:33:843]: System.TypeInitializationException: The type initializer for 'System.Management.ManagementPath' threw an exception. ---> System.Runtime.InteropServices.COMException (0x80040154): Retrieving the COM class factory for component with CLSID {CF4CC405-E2C5-4DDD-B3CE-5E7582D8C9FA} failed due to the following error: 80040154.  
  
     or:  
  
     ServiceModelReg [07:19:32:750]: System.IO.FileNotFoundException: Could not load file or assembly 'C:\WINDOWS\system32\wbem\mofcomp.exe' or one of its dependencies. The system cannot find the file specified.  
  
     File name: 'C:\WINDOWS\system32\wbem\mofcomp.exe  
  
 The following steps must be followed to resolve the problem described previously.  
  
1.  Run [the WMI Diagnosis Utility, version 2.0](http://go.microsoft.com/fwlink/?LinkId=94685) to repair the WMI service. [!INCLUDE[crabout](../../../includes/crabout-md.md)] using this tool, see the [WMI Diagnosis Utility](http://go.microsoft.com/fwlink/?LinkId=94686) topic.  
  
 Repair the .NET Framework 3.0 installation by using the **Add/Remove Programs** applet located in **Control Panel**, or uninstall/reinstall the .NET Framework 3.0.  
  
## Repairing .NET Framework 3.0 after .NET Framework 3.5 Installation Removes Configuration Elements Introduced by .NET Framework 3.5 in machine.config  
 If you do a repair of .NET Framework 3.0 after you installed [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)], configuration elements introduced by [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] in machine.config are removed. However, the web.config remains intact. The workaround is to repair [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] after this via ARP, or use the [WorkFlow Service Registration Tool (WFServicesReg.exe)](../../../docs/framework/wcf/workflow-service-registration-tool-wfservicesreg-exe.md) with the `/c` switch.  
  
 [WorkFlow Service Registration Tool (WFServicesReg.exe)](../../../docs/framework/wcf/workflow-service-registration-tool-wfservicesreg-exe.md) can be found at %windir%\Microsoft.NET\framework\v3.5\ or %windir%\Microsoft.NET\framework64\v3.5\  
  
## Configure IIS Properly for WCF/WF Webhost after Installing .NET Framework 3.5  
 When [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] installation fails to configure additional [!INCLUDE[indigo2](../../../includes/indigo2-md.md)]-related IIS configuration settings, it logs an error in the installation log and continues. Any attempt to run WorkflowServices applications will fail, since the required configuration settings are missing. For example, loading xoml or rules service can fail.  
  
 To workaround this problem, use the [WorkFlow Service Registration Tool (WFServicesReg.exe)](../../../docs/framework/wcf/workflow-service-registration-tool-wfservicesreg-exe.md) with the `/c` switch to properly configure IIS script maps on the machine. [WorkFlow Service Registration Tool (WFServicesReg.exe)](../../../docs/framework/wcf/workflow-service-registration-tool-wfservicesreg-exe.md) can be found at %windir%\Microsoft.NET\framework\v3.5\ or %windir%\Microsoft.NET\framework64\v3.5\  
  
## Could not load type ‘System.ServiceModel.Activation.HttpModule’ from assembly ‘System.ServiceModel, Version 3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089’  
 This error occurs if [!INCLUDE[netfx40_short](../../../includes/netfx40-short-md.md)] is installed and then [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)][!INCLUDE[indigo2](../../../includes/indigo2-md.md)] HTTP Activation is enabled. To resolve the issue run the following command-line from inside the [!INCLUDE[vs2010](../../../includes/vs2010-md.md)] Command Prompt:  
  
```Output  
aspnet_regiis.exe -i -enable  
```  
  
## See Also  
 [Set-Up Instructions](../../../docs/framework/wcf/samples/set-up-instructions.md)
