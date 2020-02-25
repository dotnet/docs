---
title: "CodeChunkInfo Structure"
ms.date: "03/30/2017"
api_name: 
  - "CodeChunkInfo"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CodeChunkInfo"
helpviewer_keywords: 
  - "CodeChunkInfo structure [.NET Framework debugging]"
ms.assetid: 0f482454-8517-48de-ba7a-d7aedab13bb5
topic_type: 
  - "apiref"
---
# CodeChunkInfo Structure

Represents a single chunk of code in memory.  
  
## Syntax  
  
```cpp  
typedef struct _CodeChunkInfo {  
    CORDB_ADDRESS startAddr;  
    ULONG32       length;  
} CodeChunkInfo;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`startAddr`|A `CORDB_ADDRESS` value that specifies the starting address of the chunk.|  
|`length`|The size, in bytes, of the chunk.|  
  
## Remarks  
 The single chunk of code is a region of native code that is part of a code object such as a function.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [GetCodeChunks Method](icordebugcode2-getcodechunks-method.md)
- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)
