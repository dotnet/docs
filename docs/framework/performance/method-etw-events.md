---
title: "Method ETW Events"
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
  - "ETW, method events (CLR)"
  - "method events [.NET Framework]"
ms.assetid: 167a4459-bb6e-476c-9046-7920880f2bb5
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Method ETW Events
<a name="top"></a> These events collect information that is specific to methods. The payload of these events is required for symbol resolution. In addition, these events provide helpful information such as the number of times a method was called.  
  
 All method events have a level of "Informational (4)". All method verbose events have a level of "Verbose (5)".  
  
 All method events are raised by the `JITKeyword` (0x10) keyword or the `NGenKeyword` (0x20) keyword under the runtime provider, or `JitRundownKeyword` (0x10) or `NGENRundownKeyword` (0x20) under the rundown provider.  
  
 CLR method events are further subdivided into the following:  
  
-   [CLR Method Events](#clr_method_events)  
  
-   [CLR Method Marker Events](#clr_method_marker_events)  
  
-   [CLR Method Verbose Events](#clr_method_verbose_events)  
  
-   [MethodJittingStarted Event](#methodjittingstarted_event)  
  
<a name="clr_method_events"></a>   
## CLR Method Events  
 The following table shows the keyword and level. (For more information, see [CLR ETW Keywords and Levels](../../../docs/framework/performance/clr-etw-keywords-and-levels.md).)  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`JITKeyword` (0x10) runtime provider|Informational (4)|  
|`NGenKeyword` (0x20) runtime provider|Informational (4)|  
|`JitRundownKeyword` (0x10) rundown provider|Informational (4)|  
|`NGENRundownKeyword` (0x20) rundown provider|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`MethodLoad_V1`|136|Raised when a method is just-in-time loaded (JIT-loaded) or an NGEN image is loaded. Dynamic and generic methods do not use this version for method loads. JIT helpers never use this version.|  
|`MethodUnLoad_V1`|137|Raised when a module is unloaded, or an application domain is destroyed. Dynamic methods never use this version for method unloads.|  
|`MethodDCStart_V1`|137|Enumerates methods during a start rundown.|  
|`MethodDCEnd_V1`|138|Enumerates methods during an end rundown.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|MethodID|win:UInt64|Unique identifier of a method. For JIT helper methods, this is set to the start address of the method.|  
|ModuleID|win:UInt64|Identifier of the module to which this method belongs (0 for JIT helpers).|  
|MethodStartAddress|win:UInt64|Start address of the method.|  
|MethodSize|win:UInt32|Size of the method.|  
|MethodToken|win:UInt32|0 for dynamic methods and JIT helpers.|  
|MethodFlags|win:UInt32|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled code method (otherwise NGEN native image code).<br /><br /> 0x8: Helper method.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="clr_method_marker_events"></a>   
## CLR Method Marker Events  
 These events are raised only under the rundown provider. They signify the end of method enumeration during a start or end rundown. (That is, they are raised when the `NGENRundownKeyword`, `JitRundownKeyword`, `LoaderRundownKeyword`, or `AppDomainResourceManagementRundownKeyword` keyword is enabled.)  
  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`AppDomainResourceManagementRundownKeyword` (0x800) rundown provider|Informational (4)|  
|`JitRundownKeyword` (0x10) rundown provider|Informational (4)|  
|`NGENRundownKeyword` (0x20) rundown provider|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Desciption|  
|-----------|--------------|----------------|  
|`DCStartInit_V1`|147|Sent before the start of the enumeration during a start rundown.|  
|`DCStartComplete_V1`|145|Sent at the end of the enumeration during a start rundown.|  
|`DCEndInit_V1`|148|Sent before the start of the enumeration during an end rundown.|  
|`DCEndComplete_V1`|146|Sent at the end of the enumeration during an end rundown.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="clr_method_verbose_events"></a>   
## CLR Method Verbose Events  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`JITKeyword` (0x10) runtime provider|Verbose (5)|  
|`NGenKeyword` (0x20) runtime provider|Verbose (5)|  
|`JitRundownKeyword` (0x10) rundown provider|Verbose (5)|  
|`NGENRundownKeyword` (0x20) rundown provider|Verbose (5)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`MethodLoadVerbose_V1`|143|Raised when a method is JIT-loaded or an NGEN image is loaded. Dynamic and generic methods always use this version for method loads. JIT helpers always use this version.|  
|`MethodUnLoadVerbose_V1`|144|Raised when a dynamic method is destroyed, a module is unloaded, or an application domain is destroyed. Dynamic methods always use this version for method unloads.|  
|`MethodDCStartVerbose_V1`|141|Enumerates methods during a start rundown.|  
|`MethodDCEndVerbose_V1`|142|Enumerates methods during an end rundown.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|MethodID|win:UInt64|Unique identifier of the method. For JIT helper methods, set to the start address of the method.|  
|ModuleID|win:UInt64|Identifier of the module to which this method belongs (0 for JIT helpers).|  
|MethodStartAddress|win:UInt64|Start address.|  
|MethodSize|win:UInt32|Method length.|  
|MethodToken|win:UInt32|0 for dynamic methods and JIT helpers.|  
|MethodFlags|win:UInt32|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled method (otherwise, generated by NGen.exe)<br /><br /> 0x8: Helper method.|  
|MethodNameSpace|win:UnicodeString|Full namespace name associated with the method.|  
|MethodName|win:UnicodeString|Full class name associated with the method.|  
|MethodSignature|win:UnicodeString|Signature of the method (comma-separated list of type names).|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="methodjittingstarted_event"></a>   
## MethodJittingStarted Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`JITKeyword` (0x10) runtime provider|Verbose (5)|  
|`NGenKeyword` (0x20) runtime provider|Verbose (5)|  
|`JitRundownKeyword` (0x10) rundown provider|Verbose (5)|  
|`NGENRundownKeyword` (0x20) rundown provider|Verbose (5)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`MethodJittingStarted`|145|Raised when a method is being JIT-compiled.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|MethodID|win:UInt64|Unique identifier of the method.|  
|ModuleID|win:UInt64|Identifier of the module to which this method belongs.|  
|MethodToken|win:UInt32|0 for dynamic methods and JIT helpers.|  
|MethodILSize|win:UInt32|The size of the Microsoft intermediate language (MSIL) for the method that is being JIT-compiled.|  
|MethodNameSpace|win:UnicodeString|Full class name associated with the method.|  
|MethodName|win:UnicodeString|Name of the method.|  
|MethodSignature|win:UnicodeString|Signature of the method (comma-separated list of type names).|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
## See Also  
 [CLR ETW Events](../../../docs/framework/performance/clr-etw-events.md)
