---
title: "ISymUnmanagedMethod::GetSequencePoints Method"
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
  - "ISymUnmanagedMethod.GetSequencePoints"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedMethod::GetSequencePoints"
helpviewer_keywords: 
  - "ISymUnmanagedMethod::GetSequencePoints method [.NET Framework debugging]"
  - "GetSequencePoints method [.NET Framework debugging]"
ms.assetid: f909ac48-3d8f-49fb-a369-e3d9959151cd
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedMethod::GetSequencePoints Method
Gets all the sequence points within this method.  
  
## Syntax  
  
```  
HRESULT GetSequencePoints(  
    [in]  ULONG32  cPoints,  
    [out] ULONG32  *pcPoints,  
    [in, size_is(cPoints)] ULONG32  offsets[],  
    [in, size_is(cPoints)] ISymUnmanagedDocument* documents[],  
    [in, size_is(cPoints)] ULONG32  lines[],  
    [in, size_is(cPoints)] ULONG32  columns[],  
    [in, size_is(cPoints)] ULONG32  endLines[],  
    [in, size_is(cPoints)] ULONG32  endColumns[]);  
```  
  
#### Parameters  
 `cPoints`  
 [in] A `ULONG32` that receives the size of the `offsets`, `documents`, `lines`, `columns`, `endLines`, and `endColumns` arrays.  
  
 `pcPoints`  
 [out] A pointer to a `ULONG32` that receives the length of the buffer required to contain the sequence points.  
  
 `offsets`  
 [in] An array in which to store the Microsoft intermediate language (MSIL) offsets from the beginning of the method for the sequence points.  
  
 `documents`  
 [in] An array in which to store the documents in which the sequence points are located.  
  
 `lines`  
 [in] An array in which to store the lines in the documents at which the sequence points are located.  
  
 `columns`  
 [in] An array in which to store the columns in the documents at which the sequence points are located.  
  
 `endLines`  
 [in] The array of lines in the documents at which the sequence points end.  
  
 `endColumns`  
 [in] The array of columns in the documents at which the sequence points end.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedmethod-interface.md)
