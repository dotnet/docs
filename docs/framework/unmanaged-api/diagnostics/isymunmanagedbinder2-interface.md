---
description: "Learn more about: ISymUnmanagedBinder2 Interface"
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
---
# ISymUnmanagedBinder2 Interface

Represents a symbol binder for unmanaged code, and extends the [ISymUnmanagedBinder](isymunmanagedbinder-interface.md) interface.  
  
> [!IMPORTANT]
> It is a security risk to open a program database (PDB) file from an untrusted source.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetReaderForFile2 Method](isymunmanagedbinder2-getreaderforfile2-method.md)|Given a metadata interface and a file name, returns the correct [ISymUnmanagedReader](isymunmanagedreader-interface.md) interface that will read the debugging symbols associated with the module. Provides a more extensive search than the [ISymUnmanagedBinder::GetReaderForFile](isymunmanagedbinder-getreaderforfile-method.md) method.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
- [ISymUnmanagedBinder Interface](isymunmanagedbinder-interface.md)
- [ISymUnmanagedBinder3 Interface](isymunmanagedbinder3-interface.md)
