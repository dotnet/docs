---
description: "Learn more about: ILCodeKind Enumeration"
title: "ILCodeKind Enumeration"
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "ILCodeKind"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: b91765e4-82db-46f9-a6dc-6b80610276af
topic_type: 
  - "apiref"
---
# ILCodeKind Enumeration

[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Provides values that specify whether the debugger is able to access local variables or code added in profiler ReJIT instrumentation.  
  
## Syntax  
  
```cpp
typedef enum ILCodeKind {  
   ILCODE_ORIGINAL_IL = 0x1,  
   ILCODE_REJIT_IL = 0x2,  
} ILCodeKind;  
```  
  
## Members  
  
|Member name|Description|  
|-----------------|-----------------|  
|`ILCODE_ORIGINAL_IL`|The debugger does not have access to information from ReJIT instrumentation.|  
|`ILCODE_REJIT_IL`|The debugger has access to information from ReJIT instrumentation.|  
  
## Remarks  

 A member of the `ILCodeKind` enumeration can be passed to the [EnumerateLocalVariablesEx](icordebugilframe4-enumeratelocalvariablesex-method.md) and [GetLocalVariableEx](icordebugilframe4-getlocalvariableex-method.md) methods to determine whether the debugger can access variables added in profiler ReJIT instrumentation, and to the [GetCodeEx](icordebugilframe4-getcodeex-method.md) method to determine whether the debugger can access instrumented IL.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
- [ICorDebugILFrame4 Interface](icordebugilframe4-interface.md)
- [ReJIT: A How-To Guide](/archive/blogs/davbr/rejit-a-how-to-guide)
