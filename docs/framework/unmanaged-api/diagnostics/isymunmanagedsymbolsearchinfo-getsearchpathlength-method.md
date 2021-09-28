---
description: "Learn more about: ISymUnmanagedSymbolSearchInfo::GetSearchPathLength Method"
title: "ISymUnmanagedSymbolSearchInfo::GetSearchPathLength Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedSymbolSearchInfo.GetSearchPathLength"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedSymbolSearchInfo::GetSearchPathLength"
helpviewer_keywords: 
  - "GetSearchPathLength method [.NET Framework debugging]"
  - "ISymUnmanagedSymbolSearchInfo::GetSearchPathLength method [.NET Framework debugging]"
ms.assetid: 274e73cf-8333-47ba-ac12-70214e2b0112
topic_type: 
  - "apiref"
---
# ISymUnmanagedSymbolSearchInfo::GetSearchPathLength Method

Gets the search path length.  
  
## Syntax  
  
```cpp  
HRESULT GetSearchPathLength(  
    [out] ULONG32 *pcchPath);  
```  
  
## Parameters  

 `pcchPath`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the search path length.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedSymbolSearchInfo Interface](isymunmanagedsymbolsearchinfo-interface.md)
