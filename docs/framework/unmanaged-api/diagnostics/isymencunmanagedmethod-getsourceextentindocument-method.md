---
description: "Learn more about: ISymENCUnmanagedMethod::GetSourceExtentInDocument Method"
title: "ISymENCUnmanagedMethod::GetSourceExtentInDocument Method"
ms.date: "03/30/2017"
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
---
# ISymENCUnmanagedMethod::GetSourceExtentInDocument Method

Gets the smallest start line and largest end line for the method in a specific document.  
  
## Syntax  
  
```cpp  
HRESULT GetSourceExtentInDocument(  
    [in]  ISymUnmanagedDocument *document,  
    [out] ULONG32* pstartLine,  
    [out] ULONG32* pendLine);  
```  
  
## Parameters  

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
  
## See also

- [ISymENCUnmanagedMethod Interface](isymencunmanagedmethod-interface.md)
