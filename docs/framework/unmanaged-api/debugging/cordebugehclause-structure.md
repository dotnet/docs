---
title: "CorDebugEHClause Structure"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
dev_langs: 
  - "cpp"
api_name: 
  - "CorDebugEHClause"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 0e350a1b-6997-46d0-bfc5-962a5011ef43
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorDebugEHClause Structure
[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Represents an exception handling (EH) clause for a given piece of intermediate language (IL) code.  
  
## Syntax  
  
```cpp
typedef struct _CorDebugEHClause {  
   ULONG32 Flags;  
   ULONG32 TryOffset;  
   ULONG32 TryLength;  
   ULONG32 HandlerOffset;  
   ULONG32 HandlerLength;  
   ULONG32 ClassToken;  
   ULONG32 FilterOffset;  
} CorDebugEHClause;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`Flags`|A bit field that describes the exception information in the EH clause. For more information, see the Remarks section.|  
|`TryOffset`|The offset, in bytes, of the `try` block from the start of the method body.|  
|`TryLength`|The length, in bytes, of the `try` block.|  
|`HandlerOffset`|The location of the handler for this `try` block.|  
|`HandlerLength`|The size of the handler code in bytes.|  
|`ClassToken`|The metadata token for a type-based exception handler.|  
|`FilterOffset`|The offset, in bytes, from the start of the method body for a filter-based exception handler.|  
  
## Remarks  
 An array of `CoreDebugEHClause` values is returned by the [GetEHClauses](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode-getehclauses-method.md) method.  
  
 The EH clause information is defined by the CLI specification. For more information, see [Standard ECMA-355: Common Language Infrastructure (CLI), 6th Edition](http://www.ecma-international.org/publications/standards/Ecma-335.htm).  
  
 The `flags` field can contain the following flags. Note that they are not defined in CorDebug.idl or CorDebug.h.  
  
|Flag|Value|Description|  
|----------|-----------|-----------------|  
|`COR_ILEXCEPTION_CLAUSE_EXCEPTION`|0x00000000|A typed exception clause.|  
|`COR_ILEXCEPTION_CLAUSE_FILTER`|0x00000001|An exception filter and handler clause.|  
|`COR_ILEXCEPTION_CLAUSE_FINALLY`|0x00000002|A `finally` clause.|  
|`COR_ILEXCEPTION_CLAUSE_FAULT`|0x00000004|A fault clause (a `finally` clause that is called only when an exception is thrown).|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See Also  
 [GetEHClauses Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode-getehclauses-method.md)  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)
