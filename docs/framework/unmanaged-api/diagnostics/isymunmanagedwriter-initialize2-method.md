---
description: "Learn more about: ISymUnmanagedWriter::Initialize2 Method"
title: "ISymUnmanagedWriter::Initialize2 Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedWriter.Initialize2"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::Initialize2"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::Initialize2 method [.NET Framework debugging]"
  - "Initialize2 method [.NET Framework debugging]"
ms.assetid: 93de56b6-4ae8-4cca-acdc-25a434623509
topic_type: 
  - "apiref"
---
# ISymUnmanagedWriter::Initialize2 Method

Sets the metadata emitter interface with which this writer will be associated, and sets the output file name to which the debugging symbols will be written. This method also lets you set the final location of the program database (PDB) file.  
  
## Syntax  
  
```cpp  
HRESULT Initialize2(  
    [in] IUnknown     *emitter,  
    [in] const WCHAR  *tempfilename,  
    [in] IStream      *pIStream,  
    [in] BOOL         fFullBuild,  
    [in] const WCHAR  *finalfilename);  
```  
  
## Parameters  

 `emitter`  
 [in] A pointer to the metadata emitter interface.  
  
 `tempfilename`  
 [in] A pointer to a `WCHAR` that contains the file name to which the debugging symbols are written. If a file name is specified for a writer that does not use file names, this parameter is ignored.  
  
 `pIStream`  
 [in] If specified, the symbol writer emits the symbols into the given <xref:System.Runtime.InteropServices.ComTypes.IStream> rather than to the file specified in the `filename` parameter. The `pIStream` parameter is optional.  
  
 `fFullBuild`  
 [in] `true` if this is a full rebuild; `false` if this is an incremental compilation.  
  
 `finalfilename`  
 [in] A pointer to a `WCHAR` that is the path string to the final location of the PDB file.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedWriter Interface](isymunmanagedwriter-interface.md)
- [Initialize Method](isymunmanagedwriter-initialize-method.md)
