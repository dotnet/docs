---
title: "Runtime Information ETW Events"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "runtime information events [.NET Framework]"
  - "ETW, runtime information events"
ms.assetid: 68b4edbc-7f3b-45f6-ab75-4fd066d6af9a
caps.latest.revision: 6
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Runtime Information ETW Events
These ETW events log information about the runtime, including the SKU, version number, the manner in which the runtime was activated, the command-line parameters it was started with, the GUID (if applicable), and other relevant information. If multiple runtimes are executing within a process, the information provided by these events (the ClrInstanceID) helps disambiguate the runtimes.  
  
 The following table shows the two runtime information events. The events can be raised under any keyword or mask. (For more information, see [CLR ETW Keywords and Levels](../../../docs/framework/performance/clr-etw-keywords-and-levels.md).)  
  
|Event|Event ID|Provider|Description|  
|-----------|--------------|--------------|-----------------|  
|`RuntimeInformationEvent`|187|CLRRuntime|Raised when a runtime is loaded.|  
|`RuntimeInformationDCStart`|187|CLRRundown|Enumerates the runtimes that are loaded.|  
  
 The following table shows event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
|Sku|win:UInt16|1 – Desktop CLR.<br /><br /> 2 – CoreCLR.|  
|BclVersion – Major Version|win:UInt16|Major version of mscorlib.dll.|  
|BclVersion – Minor Version|win:UInt16|Minor version number of mscorlib.dll.|  
|BclVersion – Build Number|win:UInt16|Build number of mscorlib.dll.|  
|BclVersion – QFE|win:UInt16|Hotfix version number of mscorlib.dll.|  
|VMVersion – Major Version|win:UInt16|Version of clr.dll or coreclr.dll, depending on SKU.|  
|VMVersion – Minor Version|win:UInt16|Minor version of clr.dll or coreclr.dll, depending on SKU.|  
|VMVersion – Build Number|win:UInt16|Build number of clr.dll or coreclr.dll.|  
|VMVersion – QFE|win:UInt16|Hotfix version number of clr.dll or coreclr.dll.|  
|StartupFlags|win:UInt32|Startup flags defined in mscoree.h.|  
|StartupMode|win:UInt8|0x01 - Managed executable.<br /><br /> 0x02 - Hosted CLR.<br /><br /> 0x04 - C++ managed interop.<br /><br /> 0x08 - COM-activated.<br /><br /> 0x10 - Other.|  
|CommandLine|win:UnicodeString|Non-null only if StartupMode=0x01.|  
|ComObjectGUID|win:GUID|Non-null only if StartupMode=0x08.|  
|RuntimeDLLPath|win:UnicodeString|Path to the CLR .dll file that was loaded into the process.|  
  
## See Also  
 [CLR ETW Events](../../../docs/framework/performance/clr-etw-events.md)
