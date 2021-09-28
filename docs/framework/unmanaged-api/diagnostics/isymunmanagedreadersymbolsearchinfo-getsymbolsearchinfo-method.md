---
description: "Learn more about: ISymUnmanagedReaderSymbolSearchInfo::GetSymbolSearchInfo Method"
title: "ISymUnmanagedReaderSymbolSearchInfo::GetSymbolSearchInfo Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReaderSymbolSearchInfo.GetSymbolSearchInfo"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReaderSymbolSearchInfo::GetSymbolSearchInfo"
helpviewer_keywords: 
  - "GetSymbolSearchInfo method [.NET Framework debugging]"
  - "ISymUnmanagedReaderSymbolSearchInfo::GetSymbolSearchInfo method [.NET Framework debugging]"
ms.assetid: 40fcdbc5-3bb2-41e9-b995-40984c209a7f
topic_type: 
  - "apiref"
---
# ISymUnmanagedReaderSymbolSearchInfo::GetSymbolSearchInfo Method

Gets symbol search information.  
  
## Syntax  
  
```cpp  
HRESULT GetSymbolSearchInfo(  
    [in]  ULONG32  cSearchInfo,  
    [out] ULONG32  *pcSearchInfo,  
    [out, size_is(cSearchInfo), length_is(*pcSearchInfo)]  
        ISymUnmanagedSymbolSearchInfo **rgpSearchInfo);  
```  
  
## Parameters  

 `cSearchInfo`  
 [in] A `ULONG32` that indicates the size of `rgpSearchInfo`.  
  
 `pcSearchInfo`  
 [out] A pointer to a `ULONG32` that receives the size of the buffer required to contain the search information.  
  
 `rgpSearchInfo`  
 [out] A pointer that is set to the returned [ISymUnmanagedSymbolSearchInfo](isymunmanagedsymbolsearchinfo-interface.md) interface.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedReaderSymbolSearchInfo Interface](isymunmanagedreadersymbolsearchinfo-interface.md)
