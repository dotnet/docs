---
description: "Learn more about: ISymUnmanagedReader2 Interface"
title: "ISymUnmanagedReader2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader2"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader2"
helpviewer_keywords: 
  - "ISymUnmanagedReader2 interface [.NET Framework debugging]"
ms.assetid: a01a881b-82a3-4b3e-a3a9-9dc305c2e5f7
topic_type: 
  - "apiref"
---
# ISymUnmanagedReader2 Interface

Represents a symbol reader that provides access to documents, methods, and variables within a symbol store. This interface extends the [ISymUnmanagedReader](isymunmanagedreader-interface.md) interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetMethodByVersionPreRemap Method](isymunmanagedreader2-getmethodbyversionpreremap-method.md)|Get a symbol reader method, given a method token and an edit-and-continue version number.|  
|[GetMethodsInDocument Method](isymunmanagedreader2-getmethodsindocument-method.md)|Gets every method that has line information in the provided document.|  
|[GetSymAttributePreRemap Method](isymunmanagedreader2-getsymattributepreremap-method.md)|Gets a custom attribute based upon its name.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
- [ISymUnmanagedReader Interface](isymunmanagedreader-interface.md)
