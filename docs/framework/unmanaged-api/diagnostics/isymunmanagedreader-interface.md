---
description: "Learn more about: ISymUnmanagedReader Interface"
title: "ISymUnmanagedReader Interface"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader"
helpviewer_keywords: 
  - "ISymUnmanagedReader interface [.NET Framework debugging]"
ms.assetid: aa3cc15d-058e-4e6f-b03e-39569646ba47
topic_type: 
  - "apiref"
---
# ISymUnmanagedReader Interface

Represents a symbol reader that provides access to documents, methods, and variables within a symbol store.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetDocument Method](isymunmanagedreader-getdocument-method.md)|Finds a document.|  
|[GetDocuments Method](isymunmanagedreader-getdocuments-method.md)|Returns an array of all the documents defined in the symbol store.|  
|[GetDocumentVersion Method](isymunmanagedreader-getdocumentversion-method.md)|Gets the specified version of the specified document.|  
|[GetGlobalVariables Method](isymunmanagedreader-getglobalvariables-method.md)|Returns all global variables.|  
|[GetMethod Method](isymunmanagedreader-getmethod-method.md)|Gets a symbol reader method, given a method token.|  
|[GetMethodByVersion Method](isymunmanagedreader-getmethodbyversion-method.md)|Gets a symbol reader method, given a method token and an edit-and-copy version number.|  
|[GetMethodFromDocumentPosition Method](isymunmanagedreader-getmethodfromdocumentposition-method.md)|Returns the method that contains the breakpoint at the given position in a document.|  
|[GetMethodsFromDocumentPosition Method](isymunmanagedreader-getmethodsfromdocumentposition-method.md)|Returns an array of methods, each of which contains the breakpoint at the given position in a document.|  
|[GetMethodVersion Method](isymunmanagedreader-getmethodversion-method.md)|Gets the method version.|  
|[GetNamespaces Method](isymunmanagedreader-getnamespaces-method.md)|Gets the namespaces defined at global scope within this symbol store.|  
|[GetSymAttribute Method](isymunmanagedreader-getsymattribute-method.md)|Gets a custom attribute based upon its name.|  
|[GetSymbolStoreFileName Method](isymunmanagedreader-getsymbolstorefilename-method.md)|Provides the on-disk file name of the symbol store.|  
|[GetUserEntryPoint Method](isymunmanagedreader-getuserentrypoint-method.md)|Returns the method that was specified as the user entry point for the module, if any.|  
|[GetVariables Method](isymunmanagedreader-getvariables-method.md)|Return a non-local variable, given its parent and name.|  
|[Initialize Method](isymunmanagedreader-initialize-method.md)|Initializes the symbol reader with the metadata importer interface that this reader will be associated with, along with the file name of the module.|  
|[ReplaceSymbolStore Method](isymunmanagedreader-replacesymbolstore-method.md)|Replaces the existing symbol store with a delta symbol store.|  
|[UpdateSymbolStore Method](isymunmanagedreader-updatesymbolstore-method.md)|Updates the existing symbol store with a delta symbol store.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
- [ISymUnmanagedReader2 Interface](isymunmanagedreader2-interface.md)
