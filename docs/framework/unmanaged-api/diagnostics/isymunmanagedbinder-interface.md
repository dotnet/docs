---
description: "Learn more about: ISymUnmanagedBinder Interface"
title: "ISymUnmanagedBinder Interface"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedBinder"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedBinder"
helpviewer_keywords: 
  - "ISymUnmanagedBinder interface [.NET Framework debugging]"
ms.assetid: b22fbe19-b30f-4696-8175-e6b91da9edab
topic_type: 
  - "apiref"
---
# ISymUnmanagedBinder Interface

Represents a symbol binder for unmanaged code.  
  
> [!IMPORTANT]
> It is a security risk to open a program database (PDB) file from an untrusted source.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetReaderForFile Method](isymunmanagedbinder-getreaderforfile-method.md)|Given a metadata interface and a file name, returns the correct [ISymUnmanagedReader](isymunmanagedreader-interface.md) structure that will read the debugging symbols associated with the module.|  
|[GetReaderFromStream Method](isymunmanagedbinder-getreaderfromstream-method.md)|Given a metadata interface and a stream that contains the symbol store, returns the correct [ISymUnmanagedReader](isymunmanagedreader-interface.md) structure that will read the debugging symbols from the given symbol store.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
- [ISymUnmanagedBinder2 Interface](isymunmanagedbinder2-interface.md)
- [ISymUnmanagedBinder3 Interface](isymunmanagedbinder3-interface.md)
