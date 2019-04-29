---
title: "WriteableMetadataUpdateMode Enumeration"
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "WriteableMetadataUpdateMode"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 6758f4d3-6bc7-4c99-8582-e9be00566784
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# WriteableMetadataUpdateMode Enumeration
[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Provides values that specify whether in-memory updates to metadata are visible to a debugger.  
  
## Syntax  
  
```cpp
typedef enum WriteableMetadataUpdateMode {  
   LegacyCompatPolicy,  
   AlwaysShowUpdates  
} WriteableMetadataUpdateMode;  
```  
  
## Members  
  
|Member name|Description|  
|-----------------|-----------------|  
|`LegacyCompatPolicy`|Maintain compatibility with previous versions of the .NET Framework when making in-memory updates to metadata visible. See the Remarks section for more information.|  
|`AlwaysShowUpdates`|Make in-memory updates to metadata visible to the debugger.|  
  
## Remarks  
 A member of the `WriteableMetadataUpdateMode` enumeration can be passed to the [SetWriteableMetadataUpdateMode](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess7-setwriteablemetadataupdatemode-method.md) method to control whether in-memory updates to metadata in the target process are visible to the debugger.  
  
 The `LegacyCompatPolicy` option enforces the same behavior as in versions of the .NET Framework before 4.5.2. This often means that metadata from updates is not visible. However, calls to a number of debugging methods implicitly coerce the debugger to make updates visible. For example, if the debugger passes [ICorDebugILFrame::GetLocalVariable](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-getlocalvariable-method.md) the index of a variable not found in the method's original metadata, all metadata for the module is updated to a snapshot matching the current state of the process. In other words, with the `LegacyCompatPolicy` option, the debugger might see none, some, or all of the available metadata updates, depending on how it uses other parts of the unmanaged debugging API.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See also

- [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
- [SetWriteableMetadataUpdateMode Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess7-setwriteablemetadataupdatemode-method.md)
