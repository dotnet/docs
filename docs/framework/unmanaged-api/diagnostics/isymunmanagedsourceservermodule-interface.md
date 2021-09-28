---
description: "Learn more about: ISymUnmanagedSourceServerModule Interface"
title: "ISymUnmanagedSourceServerModule Interface"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedSourceServerModule"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedSourceServerModule"
helpviewer_keywords: 
  - "ISymUnmanagedSourceServerModule interface [.NET Framework debugging]"
ms.assetid: a19b23bd-2061-476e-b67d-252f57404f8b
topic_type: 
  - "apiref"
---
# ISymUnmanagedSourceServerModule Interface

Provides source server data for a module. Obtain this interface by calling `QueryInterface` on an object that implements the [ISymUnmanagedReader](isymunmanagedreader-interface.md) interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetSourceServerData Method](isymunmanagedsourceservermodule-getsourceserverdata-method.md)|Returns the source server data for the module.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
