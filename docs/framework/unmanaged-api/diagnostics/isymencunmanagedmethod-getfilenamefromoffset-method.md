---
title: "ISymENCUnmanagedMethod::GetFileNameFromOffset Method"
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
  - "ISymENCUnmanagedMethod.GetFileNameFromOffset"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymENCUnmanagedMethod::GetFileNameFromOffset"
helpviewer_keywords: 
  - "GetFileNameFromOffset method [.NET Framework debugging]"
  - "ISymENCUnmanagedMethod::GetFileNameFromOffset method [.NET Framework debugging]"
ms.assetid: 00e2e194-12f5-436e-a997-2b9d3e844d4f
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymENCUnmanagedMethod::GetFileNameFromOffset Method
Gets the file name for the line associated with an offset.  
  
## Syntax  
  
```  
HRESULT GetFileNameFromOffset(  
    [in]  ULONG32  dwOffset,  
    [in]  ULONG32  cchName,  
    [out] ULONG32  *pcchName,  
    [out, size_is(cchName),  
       length_is(*pcchName)] WCHAR szName[]);  
```  
  
#### Parameters  
 `dwOffset`  
 [in] A `ULONG32` that contains the offset.  
  
 `cchName`  
 [in] A `ULONG32` that indicates the size of the `szName` buffer.  
  
 `pcchName`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the file names.  
  
 `szName`  
 [out] The buffer that contains the file names.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymENCUnmanagedMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymencunmanagedmethod-interface.md)
