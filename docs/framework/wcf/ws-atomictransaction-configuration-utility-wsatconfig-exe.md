---
description: "Learn more about: WS-AtomicTransaction Configuration Utility (wsatConfig.exe)"
title: "WS-AtomicTransaction Configuration Utility (wsatConfig.exe)"
ms.date: "03/30/2017"
ms.topic: reference
---
# WS-AtomicTransaction Configuration Utility (wsatConfig.exe)

The WS-AtomicTransaction Configuration Utility is used to configure basic WS-AtomicTransaction support settings.  
  
## Syntax  
  
```console  
wsatConfig [Options]  
```  
  
## Remarks

 This command-line tool can be used to configure basic WS-AT settings in a local machine only. If you have to configure settings on both local and remote machines, you should use the MMC snap-in as described in [Configuring WS-Atomic Transaction Support](./feature-details/configuring-ws-atomic-transaction-support.md).  
  
 The command-line tool can be found in the Windows SDK installation location:
  
 %SystemRoot%\Microsoft.Net\Framework\v3.0\Windows Communication Foundation\wsatConfig.exe
  
 The following table shows the options that can be used with WS-AtomicTransaction Configuration Utility (wsatConfig.exe).  
  
> [!NOTE]
> When you set an SSL certificate for a selected port, you overwrite the original SSL certificate associated with that port if one exists.  
  
|Options|Description|  
|-------------|-----------------|  
|-accounts:\<account,>|Specifies a comma-separated list of accounts that can participate in WS-AtomicTransaction. The validity of these accounts is not checked.|  
|-accountsCerts:\<thumb>&#124;"Issuer\SubjectName",>|Specifies a comma-separated list of certificates that can participate in WS-AtomicTransaction. The certificates are indicated by thumbprint or by the Issuer\SubjectName pair. Use {EMPTY} for subject name if it is empty.|  
|-endpointCert:<machine&#124;\<thumb>&#124;"Issuer\SubjectName">|Uses the machine certificate or another local endpoint certificate specified by thumbprint or Issuer\SubjectName pair. Uses {EMPTY} for the subject name if it is empty.|  
|-maxTimeout:\<sec>|Specifies the maximum timeout in seconds. Valid values are from 0 to 3600.|  
|-network:\<enable&#124;disable>|Enables or disables the WS-AtomicTransaction network support.|  
|-port:\<portNum>|Sets the HTTPS port for WS-AtomicTransaction.<br /><br /> If you have already enabled firewall before running this tool, the port is automatically registered in the exception list. If firewall is disabled before running this tool, nothing additional is configured regarding the firewall.<br /><br /> If you enable firewall after configuring WS-AT, you have to run this tool again and supply the port number using this parameter. If you disable firewall after configuring, WS-AT continues to work without additional input.|  
|-timeout:\<sec>|Specifies the default timeout in seconds. Valid values are from 1 to 3600.|  
|-traceActivity:\<enable&#124;disable>|Enables or disables the tracing of activity events.|  
|-traceLevel:\<Off&#124;Error&#124;Critical&#124;Warning&#124;Information&#124; Verbose&#124;All>}|Specifies the trace level.|  
|-tracePII:\<enable&#124;disable>|Enables or disables the tracing of personally identifiable information.|  
|-traceProp:\<enable&#124;disable>|Enables or disables the tracing of propagation events.|  
|-restart|Restarts MSDTC to activate changes immediately. If this is not specified, the changes take effect when MSDTC is restarted.|  
|-show|Displays the current WS-AtomicTransaction protocol settings.|  
|-virtualServer:\<virtualServer>|Specifies the DTC resource cluster name.|  
  
## See also

- [Using WS-AtomicTransaction](./feature-details/using-ws-atomictransaction.md)
- [Configuring WS-Atomic Transaction Support](./feature-details/configuring-ws-atomic-transaction-support.md)
