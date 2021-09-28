---
description: "Learn more about: ISymUnmanagedBinder3 Interface"
title: "ISymUnmanagedBinder3 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedBinder3"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedBinder3 Interface"
helpviewer_keywords: 
  - "ISymUnmanagedBinder3 interface [.NET Framework debugging]"
ms.assetid: 37527a84-4b03-4f08-8135-94d898599089
topic_type: 
  - "apiref"
---
# ISymUnmanagedBinder3 Interface

Extends the symbol binder interface. Obtain this interface by calling `QueryInterface` on an object that implements the `ISymUnmanagedBinder` interface.  
  
> [!IMPORTANT]
> It is a security risk to open a program database (PDB) file from an untrusted source.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetReaderFromCallback Method](isymunmanagedbinder3-getreaderfromcallback-method.md)|Allows the user to implement or supply via callback either an `IID_IDiaReadExeAtRVACallback` or `IID_IDiaReadExeAtOffsetCallback` to obtain the Debug directory information from memory|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
- [ISymUnmanagedBinder Interface](isymunmanagedbinder-interface.md)
- [ISymUnmanagedBinder2 Interface](isymunmanagedbinder2-interface.md)
