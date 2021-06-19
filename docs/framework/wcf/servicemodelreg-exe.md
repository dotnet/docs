---
title: "ServiceModel Registration Tool (ServiceModelReg.exe)"
description: Use this command-line tool to manage the registration of WCF and WF components on a single machine if you experience problems with service activation.
ms.date: "03/30/2017"
ms.topic: reference
---
# ServiceModel Registration Tool (ServiceModelReg.exe)

This command-line tool provides the ability to manage the registration of WCF and WF components on a single machine. Under normal circumstances you should not need to use this tool as WCF and WF components are configured when installed. But if you are experiencing problems with service activation, you can try to register the components using this tool.  
  
## Syntax  
  
```console  
ServiceModelReg.exe[(-ia|-ua|-r)|((-i|-u) -c:<command>)] [-v|-q] [-nologo] [-?]  
```  
  
## Remarks  

 The tool can be found in the following location:  
  
 %SystemRoot%\Microsoft.Net\Framework\v3.0\Windows Communication Foundation\  
  
> [!NOTE]
> When the ServiceModel Registration Tool is run on Windows Vista, the **Windows Features** dialog may not reflect that the **Windows Communication Foundation HTTP Activation** option under **Microsoft .NET Framework 3.0** is turned on. The **Windows Features** dialog can be accessed by clicking **Start**, then click **Run** and then typing **OptionalFeatures**.  
  
 The following tables describe the options that can be used with ServiceModelReg.exe.  
  
|Option|Description|  
|------------|-----------------|  
|`-ia`|Installs all WCF and WF components.|  
|`-ua`|Uninstalls all WCF and WF components.|  
|`-r`|Repairs all WCF and WF components.|  
|`-i`|Installs WCF and WF components specified with –c.|  
|`-u`|Uninstalls WCF and WF components specified with –c.|  
|`-c`|Installs or uninstalls a component:<br /><br /> -   httpnamespace – HTTP Namespace Reservation<br />-   tcpportsharing – TCP port sharing service<br />-   tcpactivation – TCP activation service (unsupported on .NET 4 Client Profile)<br />-   namedpipeactivation – Named pipe activation service (unsupported on .NET 4 Client Profile<br />-   msmqactivation – MSMQ activation service (unsupported on .NET 4 Client Profile<br />-   etw – ETW event tracing manifests (Windows Vista or later)|  
|`-q`|Quiet mode (only display error logging)|  
|`-v`|Verbose mode.|  
|`-nologo`|Suppresses the copyright and banner message.|  
|`-?`|Displays help text|  
  
## Fixing the FileLoadException Error  

 If you installed previous versions of WCF on your machine, you may get a `FileLoadFoundException` error when you run the ServiceModelReg tool to register a new installation. This can happen even if you have manually removed files from the previous install, but left the machine.config settings intact.  
  
 The error message is similar to the following.  
  
```console  
Error: System.IO.FileLoadException: Could not load file or assembly 'System.ServiceModel, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089' or one of its dependencies. The located assembly's manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)  
File name: 'System.ServiceModel, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'  
```  
  
 You should note from the error message that the System.ServiceModel Version 2.0.0.0 assembly was installed by an early Customer Technology Preview (CTP) release. The current version of the System.ServiceModel assembly released is 3.0.0.0 instead. Therefore, this issue is encountered when you want to install the official WCF release on a machine where an early CTP release of WCF was installed, but not completely uninstalled.  
  
 ServiceModelReg.exe cannot clean up prior version entries, nor can it register the new version's entries. The only workaround is to manually edit machine.config. You can locate this file at the following location.  
  
```console  
%windir%\Microsoft.NET\Framework\v2.0.50727\config\machine.config
```  
  
 If you are running WCF on a 64-bit machine, you should also edit the same file at this location.  
  
```console  
%windir%\Microsoft.NET\Framework64\v2.0.50727\config\machine.config
```  
  
 Locate any XML nodes in this file that refer to "System.ServiceModel, Version=2.0.0.0", delete them and any child nodes. Save the file and re-run ServiceModelReg.exe resolves this problem.  
  
## Examples  

 The following examples show how to use the most common options of the ServiceModelReg.exe tool.  
  
```console  
ServiceModelReg.exe -ia  
  Installs all components  
ServiceModelReg.exe -i -c:httpnamespace -c:etw  
  Installs HTTP namespace reservation and ETW manifests  
ServiceModelReg.exe -u -c:etw  
  Uninstalls ETW manifests  
ServiceModelReg.exe -r  
  Repairs an extended install  
```
