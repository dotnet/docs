---
title: "ISymUnmanagedMethod::GetRanges Method"
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
  - "ISymUnmanagedMethod.GetRanges"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedMethod::GetRanges"
helpviewer_keywords: 
  - "ISymUnmanagedMethod::GetRanges method [.NET Framework debugging]"
  - "GetRanges method [.NET Framework debugging]"
ms.assetid: a85283d8-379c-417a-9736-ddeeef9bcf50
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedMethod::GetRanges Method
Given a position in a document, returns an array of start and end offset pairs that correspond to the ranges of Microsoft intermediate language (MSIL) that the position covers within this method. The array is an array of integers and has the format [start, end, start, end]. The number of range pairs is the length of the array divided by 2.  
  
## Syntax  
  
```  
HRESULT GetRanges(  
    [in]  ISymUnmanagedDocument* document,  
    [in]  ULONG32                line,  
    [in]  ULONG32                column,  
    [in]  ULONG32                cRanges,  
    [out] ULONG32                *pcRanges,  
    [out, size_is(cRanges),  
        length_is(*pcRanges)] ULONG32 ranges[]);  
```  
  
#### Parameters  
 `document`  
 [in] The document for which the offset is requested.  
  
 `line`  
 [in] The document line corresponding to the ranges.  
  
 `column`  
 [in] The document column corresponding to the ranges.  
  
 `cRanges`  
 [in] The size of the `ranges` array.  
  
 `pcRanges`  
 [out] A pointer to a `ULONG32` that receives the size of the buffer required to contain the ranges.  
  
 `ranges`  
 [out] A pointer to the buffer that receives the ranges.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedmethod-interface.md)
