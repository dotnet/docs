---
description: "Learn more about: ICorDebugProcess7::SetWriteableMetadataUpdateMode Method"
title: "ICorDebugProcess7::SetWriteableMetadataUpdateMode Method"
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorDebugProcess7.SetWriteableMetadataUpdateMode"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 8589bba7-7304-45ba-9e31-7bf43dfd5c19
topic_type: 
  - "apiref"
---
# ICorDebugProcess7::SetWriteableMetadataUpdateMode Method

[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Configures how the debugger handles in-memory updates to metadata within the target process.  
  
## Syntax  
  
```cpp
HRESULT SetWriteableMetadataUpdateMode(  
   WriteableMetadataUpdateMode flags  
);  
```  
  
## Parameters  

 `flags`  
 A [WriteableMetadataUpdateMode](writeablemetadataupdatemode-enumeration.md) enumeration value that specifies whether in-memory updates to metadata in the target process are visible (`WriteableMetadataUpdateMode::AlwaysShowUpdates`) or not visible (`WriteableMetadataUpdateMode::LegacyCompatPolicy`) to the debugger.  
  
## Remarks  

 Updates to the metadata of the target process can come from Edit and Continue, a profiler, or <xref:System.Reflection.Emit?displayProperty=nameWithType>.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See also

- [ICorDebugProcess7 Interface](icordebugprocess7-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
