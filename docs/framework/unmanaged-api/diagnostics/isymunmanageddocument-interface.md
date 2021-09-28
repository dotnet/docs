---
description: "Learn more about: ISymUnmanagedDocument Interface"
title: "ISymUnmanagedDocument Interface"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedDocument"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocument"
helpviewer_keywords: 
  - "ISymUnmanagedDocument interface [.NET Framework debugging]"
ms.assetid: 5c26b366-6e81-467c-9dd0-02dd26fee0a3
topic_type: 
  - "apiref"
---
# ISymUnmanagedDocument Interface

Represents a document referenced by a symbol store. A document is defined by a uniform resource locator (URL) and a document type GUID. You can locate the document regardless of how it is stored by using the URL and document type GUID. You can store the document source in the symbol store and retrieve it through this interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[FindClosestLine Method](isymunmanageddocument-findclosestline-method.md)|Returns the closest line that is a sequence point, given a line in this document that may or may not be a sequence point.|  
|[GetCheckSum Method](isymunmanageddocument-getchecksum-method.md)|Gets the checksum.|  
|[GetCheckSumAlgorithmId Method](isymunmanageddocument-getchecksumalgorithmid-method.md)|Gets the checksum algorithm identifier, or returns a GUID of all zeros if there is no checksum.|  
|[GetDocumentType Method](isymunmanageddocument-getdocumenttype-method.md)|Gets the document type of this document.|  
|[GetLanguage Method](isymunmanageddocument-getlanguage-method.md)|Gets the language identifier of this document.|  
|[GetLanguageVendor Method](isymunmanageddocument-getlanguagevendor-method.md)|Gets the language vendor of this document.|  
|[GetSourceLength Method](isymunmanageddocument-getsourcelength-method.md)|Gets the length, in bytes, of the embedded source.|  
|[GetSourceRange Method](isymunmanageddocument-getsourcerange-method.md)|Returns the specified range of the embedded source into the given buffer.|  
|[GetURL Method](isymunmanageddocument-geturl-method.md)|Returns the URL for this document.|  
|[HasEmbeddedSource Method](isymunmanageddocument-hasembeddedsource-method.md)|Returns `true` if the document has source embedded in the debugging symbols; otherwise, returns `false`.|  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
