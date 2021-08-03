---
description: "Learn more about: Troubleshoot setup issues"
title: "Troubleshooting Setup Issues"
ms.date: "03/30/2017"
ms.assetid: 1644f885-c408-4d5f-a5c7-a1a907bc8acd
---
# Troubleshoot setup issues

This article describes how to troubleshoot Windows Communication Foundation (WCF) setup issues.

## Some Windows Communication Foundation Registry Keys are not Repaired by Performing an MSI Repair Operation on the .NET Framework 3.0

 If you delete any of the following registry keys:

- HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\ServiceModelService 3.0.0.0

- HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\ServiceModelOperation 3.0.0.0

- HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\ServiceModelEndpoint 3.0.0.0

- HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SMSvcHost 3.0.0.0

- HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\MSDTC Bridge 3.0.0.0

 The keys are not recreated if you run repair by using the .NET Framework 3.0 installer launched from the **Add/Remove Programs** applet in **Control Panel**. To recreate these keys correctly, the user must uninstall and reinstall the .NET Framework 3.0.

## WMI Service Corruption Blocks Installation of the WMI provider

 WMI Service Corruption may block the installation of the Windows Communication Foundation WMI provider when installing the .NET Framework 3.0 package. During installation, the Windows Communication Foundation installer is unable to register the WCF *.mof* file using the *mofcomp.exe* component. The following is a list of symptoms:

1. .NET Framework 3.0 installation completes successfully, but the WCF WMI provider is not registered.

2. An error event appears in the application event log that references problems registering the WMI provider for WCF, or running mofcomp.exe.

3. The setup log file named dd_wcf_retCA* in the user's %temp% directory contains references to failure to register the WCF WMI provider.

4. An exception such as one the following may be listed in the event log or setup trace log file:

     ServiceModelReg [11:09:59:046]: System.ApplicationException: Unexpected result 3 executing E:\WINDOWS\system32\wbem\mofcomp.exe with "E:\WINDOWS\Microsoft.NET\Framework\v3.0\Windows Communication Foundation\ServiceModel.mof"

     or:

     ServiceModelReg [07:19:33:843]: System.TypeInitializationException: The type initializer for 'System.Management.ManagementPath' threw an exception. ---> System.Runtime.InteropServices.COMException (0x80040154): Retrieving the COM class factory for component with CLSID {CF4CC405-E2C5-4DDD-B3CE-5E7582D8C9FA} failed due to the following error: 80040154.

     or:

     ServiceModelReg [07:19:32:750]: System.IO.FileNotFoundException: Could not load file or assembly 'C:\WINDOWS\system32\wbem\mofcomp.exe' or one of its dependencies. The system cannot find the file specified.

     File name: 'C:\WINDOWS\system32\wbem\mofcomp.exe

 The following steps must be followed to resolve the problem described previously.

1. Run the WMI Diagnosis Utility to repair the WMI service. For more information about using this tool, see [WMI Diagnosis Utility](/previous-versions/tn-archive/ff404265(v%3dmsdn.10)).

 Repair the .NET Framework 3.0 installation by using the **Add/Remove Programs** applet located in **Control Panel**, or uninstall/reinstall the .NET Framework 3.0.

## Repair .NET Framework 3.0 after .NET Framework 3.5 Installation

 If you do a repair of .NET Framework 3.0 after you installed .NET Framework 3.5, configuration elements introduced by .NET Framework 3.5 in *machine.config* are removed. However, the *web.config* file remains intact. The workaround is to repair .NET Framework 3.5 after this via ARP, or use the [WorkFlow Service Registration Tool (WFServicesReg.exe)](workflow-service-registration-tool-wfservicesreg-exe.md) with the `/c` switch.

 [WorkFlow Service Registration Tool (WFServicesReg.exe)](workflow-service-registration-tool-wfservicesreg-exe.md) can be found at %windir%\Microsoft.NET\framework\v3.5\ or %windir%\Microsoft.NET\framework64\v3.5\

## Configure IIS Properly for WCF/WF Webhost after Installing .NET Framework 3.5

 When .NET Framework 3.5 installation fails to configure additional WCF-related IIS configuration settings, it logs an error in the installation log and continues. Any attempt to run WorkflowServices applications will fail, since the required configuration settings are missing. For example, loading xoml or rules service can fail.

 To workaround this problem, use the [WorkFlow Service Registration Tool (WFServicesReg.exe)](workflow-service-registration-tool-wfservicesreg-exe.md) with the `/c` switch to properly configure IIS script maps on the machine. [WorkFlow Service Registration Tool (WFServicesReg.exe)](workflow-service-registration-tool-wfservicesreg-exe.md) can be found at %windir%\Microsoft.NET\framework\v3.5\ or %windir%\Microsoft.NET\framework64\v3.5\

## Could not load type 'System.ServiceModel.Activation.HttpModule'

**Could not load type 'System.ServiceModel.Activation.HttpModule' from assembly 'System.ServiceModel, Version 3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'**

 This error occurs if .NET Framework 4 is installed and then WCF HTTP Activation is enabled. To resolve the issue, run the following command from inside the Developer Command Prompt for Visual Studio:

```console
aspnet_regiis.exe -i -enable
```
