---
title: "ISymUnmanagedWriter::SetSymAttribute Method"
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
  - "ISymUnmanagedWriter.SetSymAttribute"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::SetSymAttribute"
helpviewer_keywords: 
  - "SetSymAttribute method [.NET Framework debugging]"
  - "ISymUnmanagedWriter::SetSymAttribute method [.NET Framework debugging]"
ms.assetid: 64d9b80e-b883-4539-89c7-03573185a1eb
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::SetSymAttribute Method
Defines a custom attribute based upon its name. These attributes are held in the symbol store, unlike metadata custom attributes.  
  
## Syntax  
  
```  
HRESULT SetSymAttribute(  
    [in] mdToken parent,  
    [in] const WCHAR *name,  
    [in] ULONG32 cData,  
    [in, size_is(cData)] unsigned char data[]);  
```  
  
#### Parameters  
 `parent`  
 [in] The metadata token for which the attribute is being defined.  
  
 `name`  
 [in] A pointer to a `WCHAR` that contains the attribute name.  
  
 `cData`  
 [in] A `ULONG32` that indicates the size of the `data` array.  
  
 `data`  
 [in] The attribute value.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)
