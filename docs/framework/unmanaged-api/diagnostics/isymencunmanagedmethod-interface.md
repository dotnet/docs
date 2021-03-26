---
description: "Learn more about: ISymENCUnmanagedMethod Interface"
title: "ISymENCUnmanagedMethod Interface"
ms.date: "03/30/2017"
api_name: 
  - "ISymENCUnmanagedMethod"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymENCUnmanagedMethod"
helpviewer_keywords: 
  - "ISymENCUnmanagedMethod interface [.NET Framework debugging]"
ms.assetid: faebf594-67d5-4abf-b9c1-547fd3a1ff87
topic_type: 
  - "apiref"
---
# ISymENCUnmanagedMethod Interface

Provides information for the Edit and Continue feature.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetDocumentsForMethod Method](isymencunmanagedmethod-getdocumentsformethod-method.md)|Gets the documents that this method has lines in.|  
|[GetDocumentsForMethodCount Method](isymencunmanagedmethod-getdocumentsformethodcount-method.md)|Gets the number of documents that this method has lines in.|  
|[GetFileNameFromOffset Method](isymencunmanagedmethod-getfilenamefromoffset-method.md)|Gets the file name for the line associated with an offset.|  
|[GetLineFromOffset Method](isymencunmanagedmethod-getlinefromoffset-method.md)|Gets the line information associated with an offset.|  
|[GetSourceExtentInDocument Method](isymencunmanagedmethod-getsourceextentindocument-method.md)|Gets the smallest start line and largest end line for the method in a specific document.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
