---
title: "ISymUnmanagedBinder2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedBinder2"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedBinder2 Interface"
helpviewer_keywords: 
  - "ISymUnmanagedBinder2 interface [.NET Framework debugging]"
ms.assetid: 7a59f405-73e8-4434-8bcc-a9dc45ea08e6
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedBinder2 Interface
Represents a symbol binder for unmanaged code, and extends the [ISymUnmanagedBinder](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedbinder-interface.md) interface.  
  
> [!IMPORTANT]
> It is a security risk to open a program database (PDB) file from an untrusted source.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetReaderForFile2 Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedbinder2-getreaderforfile2-method.md)|Given a metadata interface and a file name, returns the correct [ISymUnmanagedReader](isymunmanagedreader-interface.md) interface that will read the debugging symbols associated with the module. Provides a more extensive search than the [ISymUnmanagedBinder::GetReaderForFile](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedbinder-getreaderforfile-method.md) method.|  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](../../../../docs/framework/unmanaged-api/diagnostics/diagnostics-symbol-store-interfaces.md)
- [ISymUnmanagedBinder Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedbinder-interface.md)
- [ISymUnmanagedBinder3 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedbinder3-interface.md)
