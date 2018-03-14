---
title: "ISymUnmanagedReader2::GetSymAttributePreRemap Method"
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
  - "ISymUnmanagedReader2.GetSymAttributePreRemap"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader2::GetSymAttributePreRemap"
helpviewer_keywords: 
  - "GetSymAttributePreRemap method [.NET Framework debugging]"
  - "ISymUnmanagedReader2::GetSymAttributePreRemap method [.NET Framework debugging]"
ms.assetid: 7580d546-a709-40c5-ad02-aa70d774fd0b
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedReader2::GetSymAttributePreRemap Method
Gets a custom attribute based upon its name. Unlike metadata custom attributes, these attributes are held in the symbol store.  
  
## Syntax  
  
```  
HRESULT GetSymAttributePreRemap(  
    [in]  mdToken  parent,  
    [in]  WCHAR    *name,  
    [in]  ULONG32  cBuffer,  
    [out] ULONG32  *pcBuffer,  
    [out, size_is(cBuffer),  
        length_is(*pcBuffer)] BYTE buffer[]);  
```  
  
#### Parameters  
 `parent`  
 [in] The metadata token of the parent.  
  
 `name`  
 [in] A pointer to a `WCHAR` that contains the name.  
  
 `cBuffer`  
 [in] A `ULONG32` that indicates the size of the `buffer` array.  
  
 `pcBuffer`  
 [out] A pointer to a `ULONG32` that receives the size of the buffer required to contain the attribute bytes.  
  
 `buffer`  
 [out] A pointer to the buffer that receives the attribute bytes.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedReader2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader2-interface.md)
