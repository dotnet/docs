---
title: "ISymENCUnmanagedMethod::GetSourceExtentInDocument Method"
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
  - "ISymENCUnmanagedMethod.GetSourceExtentInDocument"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymENCUnmanagedMethod::GetSourceExtentInDocument"
helpviewer_keywords: 
  - "GetSourceExtentInDocument method [.NET Framework debugging]"
  - "ISymENCUnmanagedMethod::GetSourceExtentInDocument method [.NET Framework debugging]"
ms.assetid: 9c5566ab-4ec7-4b61-9753-839bb90ae78c
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymENCUnmanagedMethod::GetSourceExtentInDocument Method
Gets the smallest start line and largest end line for the method in a specific document.  
  
## Syntax  
  
```  
HRESULT GetSourceExtentInDocument(  
    [in]  ISymUnmanagedDocument *document,  
    [out] ULONG32* pstartLine,  
    [out] ULONG32* pendLine);  
```  
  
#### Parameters  
 `document`  
 [in] A pointer to the document.  
  
 `pstartLine`  
 [out] A pointer to a `ULONG32` that receives the start line.  
  
 `pendLine`  
 [out] A pointer to a `ULONG32` that receives the end line.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymENCUnmanagedMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymencunmanagedmethod-interface.md)
