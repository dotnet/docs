---
title: "ISymUnmanagedWriter::Initialize Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ISymUnmanagedWriter.Initialize"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::Initialize"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::Initialize method [.NET Framework debugging]"
  - "Initialize method, ISymUnmanagedWriter interface [.NET Framework debugging]"
ms.assetid: e0ebd793-3764-4df0-8f12-0e95f60b9eae
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::Initialize Method
Sets the metadata emitter interface with which this writer will be associated, and sets the output file name to which the debugging symbols will be written.  
  
 This method can be called only once, and it must be called before any other writer methods. Some writers may require a file name. However, you can always pass a file name to this method without any negative effect on writers that do not use the file name.  
  
## Syntax  
  
```  
HRESULT Initialize(  
    [in] IUnknown     *emitter,  
    [in] const WCHAR  *filename,  
    [in] IStream      *pIStream,  
    [in] BOOL         fFullBuild);  
```  
  
#### Parameters  
 `emitter`  
 [in] A pointer to the metadata emitter interface.  
  
 `filename`  
 [in] The file name to which the debugging symbols are written. If a file name is specified for a writer that does not use file names, this parameter is ignored.  
  
 `pIStream`  
 [in] If specified, the symbol writer will emit the symbols into the given <xref:System.Runtime.InteropServices.ComTypes.IStream> rather than to the file specified in the `filename` parameter. The `pIStream` parameter is optional.  
  
 `fFullBuild`  
 [in] `true` if this is a full rebuild; `false` if this is an incremental compilation.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)  
 [Initialize2 Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-initialize2-method.md)
