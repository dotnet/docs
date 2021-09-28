---
description: "Learn more about: ICorDebugSymbolProvider::GetAssemblyImageBytes Method"
title: "ICorDebugSymbolProvider::GetAssemblyImageBytes Method"
ms.date: "03/30/2017"
ms.assetid: 3db215aa-e180-4f70-8d23-6d5a0ffbc8e5
---
# ICorDebugSymbolProvider::GetAssemblyImageBytes Method

Reads data from a merged assembly given a relative virtual address (RVA) in the merged assembly.  
  
## Syntax  
  
```cpp  
HRESULT GetAssemblyImageBytes(  
   [in] CORDB_ADDRESS rva,
   [in] ULONG32 length,
   [out] ICorDebugMemoryBuffer** ppMemoryBuffer  
);  
```  
  
## Parameters  

 `rva`  
 [in] A relative virtual address (RVA) in a merged assembly.  
  
 `length`  
 The number of bytes to read from the merged assembly.  
  
 `ppMemoryBuffer`  
 A pointer to the address of an [ICorDebugMemoryBuffer](icordebugmemorybuffer-interface.md) object that contains information about the memory buffer with merged assembly metadata.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugSymbolProvider Interface](icordebugsymbolprovider-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
