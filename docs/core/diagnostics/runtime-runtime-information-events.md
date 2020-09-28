
# Runtime Information Events
These runtime events log information about the runtime, including the SKU, version number, the manner in which the runtime was activated, the command-line parameters it was started with, the GUID (if applicable), and other relevant information. If multiple runtimes are executing within a process, the information provided by these events (the ClrInstanceID) helps disambiguate the runtimes.  
  
 The following table shows the two runtime information events. The events can be raised under any keyword or mask. (For more information, see [CLR ETW Keywords and Levels](coreclr-etw-keywords-and-levels.md).)  

## TODO: IMPORT THIS!!!!!!!^^^^^

|Event|Event ID|Provider|Description|  
|-----------|--------------|--------------|-----------------|  
|`RuntimeInformationEvent`|187|CLRRuntime|Raised when a runtime is loaded.|  
|`RuntimeInformationDCStart`|187|CLRRundown|Enumerates the runtimes that are loaded.|  
  
 The following table shows event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|  
|Sku|win:UInt16|1 – Framework CLR.<br /><br /> 2 – CoreCLR.|  
|BclVersion – Major Version|win:UInt16|Major version of System.Private.CoreLib.dll.|  
|BclVersion – Minor Version|win:UInt16|Minor version number of System.Private.CoreLib.dll.|  
|BclVersion – Build Number|win:UInt16|Build number of System.Private.CoreLib.dll|  
|BclVersion – QFE|win:UInt16|Hotfix version number of System.Private.CoreLib.dll.|  
|VMVersion – Major Version|win:UInt16|Version of coreclr.dll, depending on SKU.|  
|VMVersion – Minor Version|win:UInt16|Minor version of coreclr.dll, depending on SKU.|  
|VMVersion – Build Number|win:UInt16|Build number of coreclr.dll.|  
|VMVersion – QFE|win:UInt16|Hotfix version number of coreclr.dll.|  
|StartupFlags|win:UInt32|Startup flags defined in mscoree.h.|  
|StartupMode|win:UInt8|0x01 - Managed executable.<br /><br /> 0x02 - Hosted CLR.<br /><br /> 0x04 - C++ managed interop.<br /><br /> 0x08 - COM-activated.<br /><br /> 0x10 - Other.|  
|CommandLine|win:UnicodeString|Non-null only if StartupMode=0x01.|  
|ComObjectGUID|win:GUID|Non-null only if StartupMode=0x08.| 
|RuntimeDLLPath|win:UnicodeString|Path to the coreclr.dll file that was loaded into the process.|  