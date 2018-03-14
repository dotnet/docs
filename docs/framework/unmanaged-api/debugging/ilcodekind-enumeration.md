---
title: "ILCodeKind Enumeration"
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
  - "ILCodeKind"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: b91765e4-82db-46f9-a6dc-6b80610276af
topic_type: 
  - "apiref"
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
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
 A member of the `ILCodeKind` enumeration can be passed to the [EnumerateLocalVariablesEx](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe4-enumeratelocalvariablesex-method.md) and [GetLocalVariableEx](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe4-getlocalvariableex-method.md) methods to determine whether the debugger can access variables added in profiler ReJIT instrumentation, and to the [GetCodeEx](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe4-getcodeex-method.md) method to determine whether the debugger can access instrumented IL.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See Also  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)  
 [ICorDebugILFrame4 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe4-interface.md)  
 [ReJIT: A How-To Guide](http://blogs.msdn.com/b/davbr/archive/2011/10/12/rejit-a-how-to-guide.aspx)
