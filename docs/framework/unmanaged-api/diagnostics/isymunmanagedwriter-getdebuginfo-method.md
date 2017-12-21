---
title: "ISymUnmanagedWriter::GetDebugInfo Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ISymUnmanagedWriter.GetDebugInfo"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::GetDebugInfo"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::GetDebugInfo method [.NET Framework debugging]"
  - "GetDebugInfo method [.NET Framework debugging]"
ms.assetid: dd31c210-6829-45eb-927e-cc53932638b7
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::GetDebugInfo Method
Returns the information necessary for a compiler to write the debug directory entry in the portable executable (PE) file header. The symbol writer fills out all fields except for `TimeDateStamp` and `PointerToRawData`. (The compiler is responsible for setting these two fields appropriately.)  
  
 A compiler should call this method, emit the data blob to the PE file, set the `PointerToRawData` field in the IMAGE_DEBUG_DIRECTORY to point to the emitted data, and write the IMAGE_DEBUG_DIRECTORY to the PE file. The compiler should also set the `TimeDateStamp` field to equal the `TimeDateStamp` of the PE file being generated.  
  
## Syntax  
  
```  
HRESULT GetDebugInfo(  
    [in, out] IMAGE_DEBUG_DIRECTORY *pIDD,  
    [in]  DWORD cData,  
    [out] DWORD *pcData,  
    [out, size_is(cData),  
        length_is(*pcData)] BYTE data[]);  
```  
  
#### Parameters  
 `pIDD`  
 [in, out] A pointer to an IMAGE_DEBUG_DIRECTORY that the symbol writer will fill out.  
  
 `cData`  
 [in] A `DWORD` that contains the size of the debug data.  
  
 `pcData`  
 [out] A pointer to a `DWORD` that receives the size of the buffer required to contain the debug data.  
  
 `data`  
 [out] A pointer to a buffer that is large enough to hold the debug data for the symbol store.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)
