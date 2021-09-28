---
description: "Learn more about: ICorProfilerInfo7::ReadInMemorySymbols"
title: "ICorProfilerInfo7::ReadInMemorySymbols"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo7.ReadInMemorySymbols"
api_location: 
  - "CorProf.idl"
  - "CorProf.h"
  - "CorGuids.lib"
api_type: 
  - "COM"
ms.assetid: 1745a0b9-8332-4777-a670-b549bff3b901
---
# ICorProfilerInfo7::ReadInMemorySymbols

[Supported in the .NET Framework 4.6.1 and later versions]  
  
 Reads bytes from an in-memory symbol stream.  
  
## Syntax  
  
```cpp  
HRESULT ReadInMemorySymbols(  
        [in] ModuleID moduleId,  
        [in] DWORD symbolsReadOffset,  
        [out] BYTE* pSymbolBytes,  
        [in] DWORD countSymbolBytes,  
        [out] DWORD* pCountSymbolBytesRead  
);  
```  
  
## Parameters  

 `moduleId`  
 [in] The identifier of the module containing the in-memory stream.  
  
 `symbolsReadOffset`  
 [in] The offset within the in-memory stream at which to start reading bytes.  
  
 `pSymbolBytes`  
 [out] A pointer to the buffer to which the data will be copied. The buffer should have `countSymbolBytes` of space available.  
  
 `countSymbolBytes`  
 [in] The number of bytes to copy.  
  
 `pCountSymbolBytesRead`  
 [out] When the method returns, contains the actual number of bytes read.  
  
## Return Value  

 `S_OK`, if a non-zero number of bytes were read.  
  
 `CORPROF_E_MODULE_IS_DYNAMIC`, if the module was created using <xref:System.Reflection.Emit>.  
  
## Remarks  

 The `ReadInMemorySymbols` method attempts to read `countSymbolBytes` of data starting at offset      `symbolsReadOffset` within the in-memory stream. The data is copied to `pSymbolBytes`, which is expected to have `countSymbolBytes` of space available.     `pCountSymbolsBytesRead` contains the actual number of bytes read, which may be less than `countSymbolBytes` if the end of the stream is reached.  
  
> [!NOTE]
> The current implementation does not support Reflection.Emit. If the module was created by using Reflection.Emit, the method returns `CORPROF_E_MODULE_IS_DYNAMIC`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v461plus](../../../../includes/net-current-v461plus-md.md)]  
  
## See also

- [ICorProfilerInfo7 Interface](icorprofilerinfo7-interface.md)
