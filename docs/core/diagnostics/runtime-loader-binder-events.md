# Loader ETW Events
These events collect information relating to loading and unloading assemblies and modules.

This category consists of the following events:
- [DomainModuleLoad_V1](#domainmoduleload_v1-event)
- [ModuleLoad_V2](#moduleload_v2-event)
- [ModuleUnload_V2](#moduleunload_v2-event)
- [ModuleDCStart_V2](#moduledcstart_v2-event)
- [ModuleEnd_V2](#moduledcend_v2-event)
- [AssemblyLoad_V1](#assemblyload_v1-event)
- [AssemblyUnload_V1](#assemblyunload_v1-event)
- [AssemblyDCStart_V1](#assemblydcstart_v1-event)
- [AssemblyLoadStart](#assemblyloadstart-event)
- [AssemblyLoadStop](#assemblyloadstop-event)
- [ResolutionAttempted](#resolutionattempted-event)
- [AssemblyLoadContextResolvingHandlerInvoked](#assemblyloadcontextresolvinghandlerinvoked-event)
- [AppDomainAssemblyResolveHandlerInvoked](#appdomainassemblyresolvehandlerinvoked-event)
- [AssemblyLoadFromResolveHandlerInvoked](#assemblyloadfromresolvehandlerinvoked-event)
- [KnownPathProbed](#knownpathprobed-event)

## DomainModuleLoad_V1 Event

|Keyword for raising the event|Event|Level|
|-----------------------------------|-----------|-----------|
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`DomainModuleLoad_V1`|151|Raised when a module is loaded for an application domain.|

## ModuleLoad_V2 Event

|Keyword for raising the event|Event|Level|
|-----------------------------------|-----------|-----------|
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`ModuleLoad_V2`|152|Raised when a module is loaded during the lifetime of a process.|

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

## ModuleUnload_V2 Event

|Keyword for raising the event|Event|Level|
|-----------------------------------|-----------|-----------|
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`ModuleUnload_V2`|153|Raised when a module is unloaded during the lifetime of a process.
|Field name|Data type|Description

|----------------|---------------|-----------------
|ModuleID|win:UInt64|Unique ID for the module.
|AssemblyID|win:UInt64|ID of the assembly in which this module resides.
|ModuleFlags|win:UInt32|0x1: Domain neutral module.<br /><br /> 0x2: Module has a native image.<br /><br /> 0x4: Dynamic module.<br /><br /> 0x8: Manifest module.
|Reserved1|win:UInt32|Reserved field.
|ModuleILPath|win:UnicodeString|Path of the Microsoft intermediate language (MSIL) image for the module, or dynamic module name if it is a dynamic assembly (null-terminated).
|ModuleNativePath|win:UnicodeString|Path of the module native image, if present (null-terminated).
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.
|ManagedPdbSignature|win:GUID|GUID signature of the managed program database (PDB) that matches this module. (See Remarks.)
|ManagedPdbAge|win:UInt32|Age number written to the managed PDB that matches this module. (See Remarks.)
|ManagedPdbBuildPath|win:UnicodeString|Path to the location where the managed PDB that matches this module was built. In some cases, this may just be a file name. (See Remarks.)
|NativePdbSignature|win:GUID|GUID signature of the Native Image Generator (NGen) PDB that matches this module, if applicable. (See Remarks.)
|NativePdbAge|win:UInt32|Age number written to the NGen PDB that matches this module, if applicable. (See Remarks.)
|NativePdbBuildPath|win:UnicodeString|Path to the location where the NGen PDB that matches this module was built, if applicable. In some cases, this may just be a file name. (See Remarks.)|

## ModuleDCStart_V2 Event

|Keyword for raising the event|Event|Level|
|-----------------------------------|-----------|-----------
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)

|Event|Event ID|Description
|-----------|--------------|-----------------
|`ModuleDCStart_V2`|153|Enumerates modules during a start rundown.

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

## ModuleDCEnd_V2 Event

|Keyword for raising the event|Event|Level|
|-----------------------------------|-----------|-----------|
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`ModuleDCEnd_V2`|154|Enumerates modules during an end rundown.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|ModuleID|win:UInt64|Unique ID for the module.|
|AssemblyID|win:UInt64|ID of the assembly in which this module resides.|
|ModuleFlags|win:UInt32|0x1: Domain neutral module.<br /><br /> 0x2: Module has a native image.<br /><br /> 0x4: Dynamic module.<br /><br /> 0x8: Manifest module.|
|Reserved1|win:UInt32|Reserved field.|
|ModuleILPath|win:UnicodeString|Path of the Microsoft intermediate language (MSIL) image for the module, or dynamic module name if it is a dynamic assembly (null-terminated).|
|ModuleNativePath|win:UnicodeString|Path of the module native image, if present (null-terminated).|
|ClrInstanceID|win:UInt16|Unique ID for the instance       of CLR or CoreCLR.|
|ManagedPdbSignature|win:GUID|GUID signature of the managed program database (PDB) that matches this module. (See Remarks.)|
|ManagedPdbAge|win:UInt32|Age number written to the managed PDB that matches this module. (See Remarks.)|
|ManagedPdbBuildPath|win:UnicodeString|Path to the location where the managed PDB that matches this module was built. In some cases, this may just be a file name. (See Remarks.)|
|NativePdbSignature|win:GUID|GUID signature of the Native Image Generator (NGen) PDB that matches this module, if applicable. (See Remarks.)|
|NativePdbAge|win:UInt32|Age number written to the NGen PDB that matches this module, if applicable. (See Remarks.)|
|NativePdbBuildPath|win:UnicodeString|Path to the location where the NGen PDB that matches this module was built, if applicable. In some cases, this may just be a file name. (See Remarks.)|


## AssemblyLoad_V1 Event

|Keyword for raising the event|Event|Level|
|-----------------------------------|-----------|-----------|
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`AssemblyLoad_V1`|154|Raised when an assembly is loaded.|


|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AssemblyID|win:UInt64|Unique ID for the assembly.|
|AppDomainID|win:UInt64|ID of the domain of this assembly.|
|BindingID|win:UInt64|ID that uniquely identifies the assembly binding.|
|AssemblyFlags|win:UInt32|0x1: Domain neutral assembly.<br /><br /> 0x2: Dynamic assembly.<br /><br /> 0x4: Assembly has a native image.<br /><br /> 0x8: Collectible assembly.|
|AssemblyName|win:UnicodeString|Fully qualified assembly name.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.

## AssemblyUnload_V1 Event

|Keyword for raising the event|Event|Level|
|-----------------------------------|-----------|-----------|
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`FireAssemblyUnload_V1`|155|Raised when an assembly is loaded.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AssemblyID|win:UInt64|Unique ID for the assembly.|
|AppDomainID|win:UInt64|ID of the domain of this assembly.|
|BindingID|win:UInt64|ID that uniquely identifies the assembly binding.|
|AssemblyFlags|win:UInt32|0x1: Domain neutral assembly.<br /><br /> 0x2: Dynamic assembly.<br /><br /> 0x4: Assembly has a native image.<br /><br /> 0x8: Collectible assembly.|
|AssemblyName|win:UnicodeString|Fully qualified assembly name.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.

## AssemblyDCStart_V1

|Keyword for raising the event|Event|Level|
|-----------------------------------|-----------|-----------|
|`LoaderKeyword` (0x8)|`DomainModuleLoad_V1`|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`AssemblyDCStart_V1`|155|Enumerates assemblies during a start rundown.|


|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AssemblyID|win:UInt64|Unique ID for the assembly.|
|AppDomainID|win:UInt64|ID of the domain of this assembly.|
|BindingID|win:UInt64|ID that uniquely identifies the assembly binding.|
|AssemblyFlags|win:UInt32|0x1: Domain neutral assembly.<br /><br /> 0x2: Dynamic assembly.<br /><br /> 0x4: Assembly has a native image.<br /><br /> 0x8: Collectible assembly.|
|AssemblyName|win:UnicodeString|Fully qualified assembly name.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


## AssemblyLoadStart Event

|Keyword for raising the event|Event|Level|
|-----------------------------------|-----------|-----------|
|`Binder` (0x4)|`AssemblyLoadStart`|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`AssemblyLoadStart`|290|An assembly load has been requested.

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AssemblyName|win:UnicodeString|Name of assembly name.|
|AssemblyPath|win:UnicodeString|Path of assembly name.|
|RequestingAssembly|win:UnicodeString|Name of the requesting ("parent") assemb.|
|AssemblyLoadContext|win:UnicodeString|Load context of the assembly.|
|RequestingAssemblyLoadContext|win:UnicodeString|Load context of the requesting ("parent") assembly.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|


## AssemblyLoadStop Event

|Keyword for raising the event|Event|Level|
|-----------------------------------|-----------|-----------|
|`Binder` (0x4)|`AssemblyLoadStart`|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`AssemblyLoadStart`|291|An assembly load has been requested.


|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AssemblyName|win:UnicodeString|Name of assembly name.|
|AssemblyPath|win:UnicodeString|Path of assembly name.|
|RequestingAssembly|win:UnicodeString|Name of the requesting ("parent") assemb.|
|AssemblyLoadContext|win:UnicodeString|Load context of the assembly.|
|RequestingAssemblyLoadContext|win:UnicodeString|Load context of the requesting ("parent") assembly.|
|Success|win:Boolean|Whether the assembly load succeeded.|
|ResultAssemblyName|win:UnicodeString|The name of assembly that was loaded.|
|ResultAssemblyPath|win:UnicodeString|The path of the assembly that was loaded from.|
|Cached|win:UnicodeString|Whether the load was cached.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

## ResolutionAttempted Event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|-----------|
|`Binder` (0x4)|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`ResolutionAttempted`|292|An assembly load has been requested.


|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AssemblyName|win:UnicodeString|Name of assembly name.|
|Stage|win:UInt16|The resolution stage.<br/><br/>0: Find in load.<br/><br/>1: Assembly Load Context</br><br/>2: Application assemblies.<br/><br/>3: Default assembly load context fallback. <br/><br/>4: Resolve satellite assembly. <br/><br/>5: Assembly load context resolving.<br/><br/>6: AppDomain assembly resolving.
|AssemblyLoadContext|win:UnicodeString|Load context of the assembly.|
|Result|win:UInt16|The result of resolution attempt.<br/><br/>0: Success<br/><br/>1: Assembly NotFound<br/><br/>2: Incompatible Version<br/><br/>3: Mismatched Assembly Name<br/><br/>4: Failure<br/><br/>5: Exception|
|ResultAssemblyName|win:UnicodeString|The name of assembly that was resolved.|
|ResultAssemblyPath|win:UnicodeString|The path of the assembly that was resolved from.|
|ErrorMessage|win:UnicodeString|Error message if there is an exception.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

## AssemblyLoadContextResolvingHandlerInvoked Event


|Keyword for raising the event|Level|
|-----------------------------------|-----------|-----------|
|`Binder` (0x4)|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`AssemblyLoadContextResolvingHandlerInvoked`|293|An [AssemblyLoadContext.Resolving](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.loader.assemblyloadcontext.resolving) handler has been invoked.|


|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AssemblyName|win:UnicodeString|Name of assembly name.|
|HandlerName|win:UnicodeString|Name of the handler invoked.|
|AssemblyLoadContext|win:UnicodeString|Load context of the assembly.|
|ResultAssemblyName|win:UnicodeString|The name of assembly that was resolved.|
|ResultAssemblyPath|win:UnicodeString|The path of the assembly that was resolved from.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

## AppDomainAssemblyResolveHandlerInvoked Event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|-----------|
|`Binder` (0x4)|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`AppDomainAssemblyResolveHandlerInvoked`|294|An <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> handler has been invoked.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AssemblyName|win:UnicodeString|Name of assembly name.|
|HandlerName|win:UnicodeString|Name of the handler invoked.|
|ResultAssemblyName|win:UnicodeString|The name of assembly that was resolved.|
|ResultAssemblyPath|win:UnicodeString|The path of the assembly that was resolved from.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

## AssemblyLoadFromResolveHandlerInvoked Event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|-----------|
|`Binder` (0x4)|Informational (4)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`AssemblyLoadFromResolveHandlerInvoked`|295|An <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType> handler has been invoked.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AssemblyName|win:UnicodeString|Name of assembly name.|
|IsTrackedLoad|win:Boolean|Whether the assembly load is tracked.|
|RequestingAssemblyPath|win:UnicodeString|The path of the requesting assembly.|
|ComputedRequestedAssemblyPath|win:UnicodeString|The path of the assembly that was requested.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

## KnownPathProbed Event


|Keyword for raising the event|Level|
|-----------------------------------|-----------|-----------|
|`Binder` (0x4)|Informational (4)|


|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`KnownPathProbed`|296|A known path was probed for an assembly.|

|Field Name|Data Type|Description|
|----------------|---------------|-----------------|
|FilePath|win:UnicodeString|Path probed.|
|Source|win:UInt16|Source of the path probed.<br/><br/>0x0:Application Assemblies.<br/><br/>0x1:App native image path.<br/><br/>0x2:App path.</br><br/>0x3:Platform resource roots.<br/><br/>0x4:Satellite Subdirectory.</br>|
|Result|win:win:UInt32|HRESULT for the probe.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|
