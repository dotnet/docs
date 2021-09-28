---
description: "Learn more about: ISymUnmanagedSymbolSearchInfo Interface"
title: "ISymUnmanagedSymbolSearchInfo Interface"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedSymbolSearchInfo"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedSymbolSearchInfo"
helpviewer_keywords: 
  - "ISymUnmanagedSymbolSearchInfo interface [.NET Framework debugging]"
ms.assetid: 30817373-0a21-49c1-a0c4-8e8daeecb8db
topic_type: 
  - "apiref"
---
# ISymUnmanagedSymbolSearchInfo Interface

Provides methods that get information about the search path. Obtain this interface by calling `QueryInterface` on an object that implements the [ISymUnmanagedReader](isymunmanagedreader-interface.md) interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetHRESULT Method](isymunmanagedsymbolsearchinfo-gethresult-method.md)|Gets the HRESULT.|  
|[GetSearchPath Method](isymunmanagedsymbolsearchinfo-getsearchpath-method.md)|Gets the search path.|  
|[GetSearchPathLength Method](isymunmanagedsymbolsearchinfo-getsearchpathlength-method.md)|Gets the search path length.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
