---
description: "Learn more about: ISymUnmanagedReaderSymbolSearchInfo::GetSymbolSearchInfoCount Method"
title: "ISymUnmanagedReaderSymbolSearchInfo::GetSymbolSearchInfoCount Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReaderSymbolSearchInfo.GetSymbolSearchInfoCount"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReaderSymbolSearchInfo::GetSymbolSearchInfoCount"
helpviewer_keywords: 
  - "GetSymbolSearchInfoCount method [.NET Framework debugging]"
  - "ISymUnmanagedReaderSymbolSearchInfo::GetSymbolSearchInfoCount method [.NET Framework debugging]"
ms.assetid: 4068b6ec-525f-4446-8818-0296178cbd19
topic_type: 
  - "apiref"
---
# ISymUnmanagedReaderSymbolSearchInfo::GetSymbolSearchInfoCount Method

Gets a count of symbol search information.  
  
## Syntax  
  
```cpp  
HRESULT GetSymbolSearchInfoCount(  
    [out] ULONG32 *pcSearchInfo);  
```  
  
## Parameters  

 `pcSearchInfo`  
 ]out] A pointer to a `ULONG32` that receives the size of the buffer required to contain the search information.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedReaderSymbolSearchInfo Interface](isymunmanagedreadersymbolsearchinfo-interface.md)
