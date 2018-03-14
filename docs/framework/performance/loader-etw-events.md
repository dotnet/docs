---
title: "Loader ETW Events"
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
  - "loader events [.NET Framework]"
  - "ETW, loader events (CLR)"
ms.assetid: cb403cc6-56f8-4609-b467-cdfa09f07909
caps.latest.revision: 18
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Loader ETW Events
<a name="top"></a> These events collect information relating to loading and unloading application domains, assemblies, and modules.  
  
 All loader events are raised under the `LoaderKeyword` (0x8) keyword. The `DCStart` and the `DCEnd` events are raised under `LoaderRundownKeyword` (0x8) with `StartRundown`/`EndRundown` enabled. (For more information, see [CLR ETW Keywords and Levels](../../../docs/framework/performance/clr-etw-keywords-and-levels.md).)  
  
 Loader events are subdivided into the following:  
  
-   [Application Domain Events](#application_domain_events)  
  
-   [CLR Loader Assembly Events](#clr_loader_assembly_events)  
  
-   [Module Events](#module_events)  
  
-   [CLR Domain Module Events](#clr_domain_module_events)  
  
-   [Module Range Events](#module_range_events)  
  
<a name="application_domain_events"></a>   
## Application Domain Events  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`LoaderKeyword` (0x8)|`AppDomainLoad_V1` and `AppDomainUnLoad_V1`|Informational (4)|  
|`LoaderRundownKeyword` (0x8) +<br /><br /> `StartRundownKeyword`|`AppDomainDCStart_V1`|Informational (4)|  
|`LoaderRundownKeyword` (0x8) +<br /><br /> `EndRundownKeyword`|`AppDomainDCEnd_V1`|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`AppDomainLoad_V1` (logged for all application domains)|156|Raised whenever an application domain is created during the lifetime of a process.|  
|`AppDomainUnLoad_V1`|157|Raised whenever an application domain is destroyed during the lifetime of a process.|  
|`AppDomainDCStart_V1`|157|Enumerates the application domains during a start rundown.|  
|`AppDomainDCEnd_V1`|158|Enumerates the application domains during an end rundown.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|AppDomainID|win:UInt64|The unique identifier for an application domain.|  
|AppDomainFlags|win:UInt32|0x1: Default domain.<br /><br /> 0x2: Executable.<br /><br /> 0x4: Application domain, bit 28-31: Sharing policy of this domain.<br /><br /> 0: A shared domain.|  
|AppDomainName|win:UnicodeString|Friendly application domain name. Might change during the lifetime of the process.|  
|AppDomainIndex|Win:UInt32|The index of this application domain.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="clr_loader_assembly_events"></a>   
## CLR Loader Assembly Events  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`LoaderKeyword` (0x8)|`AssemblyLoad` and `AssemblyUnload`|Informational (4)|  
|`LoaderRundownKeyword` (0x8) +<br /><br /> `StartRundownKeyword`|`AssemblyDCStart`|Informational (4)|  
|`LoaderRundownKeyword` (0x8) +<br /><br /> `EndRundownKeyword`|`AssemblyDCEnd`|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`AssemblyLoad_V1`|154|Raised when an assembly is loaded.|  
|`AssemblyUnload_V1`|155|Raised when an assembly is unloaded.|  
|`AssemblyDCStart_V1`|155|Enumerates assemblies during a start rundown.|  
|`AssemblyDCEnd_V1`|156|Enumerates assemblies during an end rundown.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|AssemblyID|win:UInt64|Unique ID for the assembly.|  
|AppDomainID|win:UInt64|ID of the domain of this assembly.|  
|BindingID|win:UInt64|ID that uniquely identifies the assembly binding.|  
|AssemblyFlags|win:UInt32|0x1: Domain neutral assembly.<br /><br /> 0x2: Dynamic assembly.<br /><br /> 0x4: Assembly has a native image.<br /><br /> 0x8: Collectible assembly.|  
|AssemblyName|win:UnicodeString|Fully qualified assembly name.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="module_events"></a>   
## Module Events  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`LoaderKeyword` (0x8)|`ModuleLoad_V2` and `ModuleUnload_V2`|Informational (4)|  
|`LoaderRundownKeyword` (0x8) +<br /><br /> `StartRundownKeyword`|`ModuleDCStart_V2`|Informational (4)|  
|`LoaderRundownKeyword` (0x8) +<br /><br /> `EndRundownKeyword`|`ModuleDCEnd_V2`|Informational (4)|  
||||  
  
 The following table shows the event information.  
  
|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`ModuleLoad_V2`|152|Raised when a module is loaded during the lifetime of a process.|  
|`ModuleUnload_V2`|153|Raised when a module is unloaded during the lifetime of a process.|  
|`ModuleDCStart_V2`|153|Enumerates modules during a start rundown.|  
|`ModuleDCEnd_V2`|154|Enumerates modules during an end rundown.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|ModuleID|win:UInt64|Unique ID for the module.|  
|AssemblyID|win:UInt64|ID of the assembly in which this module resides.|  
|ModuleFlags|win:UInt32|0x1: Domain neutral module.<br /><br /> 0x2: Module has a native image.<br /><br /> 0x4: Dynamic module.<br /><br /> 0x8: Manifest module.|  
|Reserved1|win:UInt32|Reserved field.|  
|ModuleILPath|win:UnicodeString|Path of the Microsoft intermediate language (MSIL) image for the module, or dynamic module name if it is a dynamic assembly (null-terminated).|  
|ModuleNativePath|win:UnicodeString|Path of the module native image, if present (null-terminated).|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
|ManagedPdbSignature|win:GUID|GUID signature of the managed program database (PDB) that matches this module. (See Remarks.)|  
|ManagedPdbAge|win:UInt32|Age number written to the managed PDB that matches this module. (See Remarks.)|  
|ManagedPdbBuildPath|win:UnicodeString|Path to the location where the managed PDB that matches this module was built. In some cases, this may just be a file name. (See Remarks.)|  
|NativePdbSignature|win:GUID|GUID signature of the Native Image Generator (NGen) PDB that matches this module, if applicable. (See Remarks.)|  
|NativePdbAge|win:UInt32|Age number written to the NGen PDB that matches this module, if applicable. (See Remarks.)|  
|NativePdbBuildPath|win:UnicodeString|Path to the location where the NGen PDB that matches this module was built, if applicable. In some cases, this may just be a file name. (See Remarks.)|  
  
### Remarks  
  
-   The fields that have "Pdb" in their names can be used by profiling tools to locate PDBs that match the modules that were loaded during the profiling session. The values of these fields correspond to the data written into the IMAGE_DIRECTORY_ENTRY_DEBUG sections of the module normally used by debuggers to help locate PDBs that match the loaded modules.  
  
-   The field names that begin with "ManagedPdb" refer to the managed PDB corresponding to the MSIL module that was generated by the managed compiler (such as the C# or Visual Basic compiler). This PDB uses the managed PDB format, and describes how elements from the original managed source code, such as files, line numbers, and symbol names, map to MSIL elements that are compiled into the MSIL module.  
  
-   The field names that begin with "NativePdb" refer to the NGen PDB generated by calling `NGEN createPDB`. This PDB uses the native PDB format, and describes how elements from the original managed source code, such as files, line numbers, and symbol names, map to native elements that are compiled into the NGen module.  
  
 [Back to top](#top)  
  
<a name="clr_domain_module_events"></a>   
## CLR Domain Module Events  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|  
|`LoaderRundownKeyword` (0x8) +<br /><br /> `StartRundownKeyword`|`DomainModuleDCStart_V1`|Informational (4)|  
|`LoaderRundownKeyword` (0x8) +<br /><br /> `EndRundownKeyword`|`DomainModuleDCEnd_V1`|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`DomainModuleLoad_V1`|151|Raised when a module is loaded for an application domain.|  
|`DomainModuleDCStart_V1`|151|Enumerates modules loaded for an application domain during a start rundown, and is logged for all application domains.|  
|`DomainModuleDCEnd_V1`|152|Enumerates modules loaded for an application domain during an end rundown, and is logged for all application domains.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|ModuleID|win:UInt64|Identifies the assembly to which this module belongs.|  
|AssemblyID|win:UInt64|ID of the assembly in which this module resides.|  
|AppDomainID|win:UInt64|ID of the application domain in which this module is used.|  
|ModuleFlags|win:UInt32|0x1: Domain neutral module.<br /><br /> 0x2: Module has a native image.<br /><br /> 0x4: Dynamic module.<br /><br /> 0x8: Manifest module.|  
|Reserved1|win:UInt32|Reserved field.|  
|ModuleILPath|win:UnicodeString|Path of the MSIL image for the module, or dynamic module name if it is a dynamic assembly (null-terminated).|  
|ModuleNativePath|win:UnicodeString|Path of the module native image, if present (null-terminated).|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="module_range_events"></a>   
## Module Range Events  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`PerfTrackKeyWord`)|`ModuleRange`|Informational (4)|  
|`PerfTrackKeyWord`|`ModuleRangeDCStart`|Informational (4)|  
|`PerfTrackKeyWord`|`ModuleRangeDCEnd`|Informational (4)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`ModuleRange`|158|This event is present if a loaded Native Image Generator (NGen) image has been optimized with IBC and contains information about the hot sections of the NGen image.|  
|`ModuleRangeDCStart`|160|A `ModuleRange` event fired at the start of a rundown.|  
|`ModuleRangeDCEnd`|161|A `ModuleRange` event fired at the end of a rundown.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|ClrInstanceID|win:UInt16|Uniquely identifies a specific instance of the CLR in a process if multiple instances of the CLR are loaded.|  
|ModuleID|win:UInt64|Identifies the assembly to which this module belongs.|  
|RangeBegin|win:UInt32|The offset in the module that represents the start of the range for the specified range type.|  
|RangeSize|win:UInt32|The size of the specified range in bytes.|  
|RangeType|win:UInt32|A single value, 0x4, to represent Cold IBC ranges. This field can represent more values in the future.|  
|RangeSize1|win:UInt32|0 indicates bad data.|  
|RangeBegin2|win:UnicodeString||  
  
### Remarks  
 If a loaded NGen image in a .NET Framework process has been optimized with IBC, the `ModuleRange` event that contains the hot ranges in the NGen image is logged along with its `moduleID` and `ClrInstanceID`.  If the NGen image is not optimized with IBC, this event isn't logged. To determine the module name, this event must be collated with the module load ETW events.  
  
 The payload size for this event is variable; the `Count` field indicates the number of range offsets contained in the event.  This event has to be collated with the Windows `IStart` event to determine the actual ranges. The Windows Image Load event is logged whenever an image is loaded, and contains the virtual address of the loaded image.  
  
 Module range events are fired under any ETW level greater than or equal to 4 and are classified as informational events.  
  
## See Also  
 [CLR ETW Events](../../../docs/framework/performance/clr-etw-events.md)
