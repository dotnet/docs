---
description: "Learn more about: ISymUnmanagedDocumentWriter::SetCheckSum Method"
title: "ISymUnmanagedDocumentWriter::SetCheckSum Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedDocumentWriter.SetCheckSum"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocumentWriter::SetCheckSum"
helpviewer_keywords: 
  - "ISymUnmanagedDocumentWriter::SetCheckSum method [.NET Framework debugging]"
  - "SetCheckSum method [.NET Framework debugging]"
ms.assetid: c7e99879-421f-43ce-b193-34733cf30085
topic_type: 
  - "apiref"
---
# ISymUnmanagedDocumentWriter::SetCheckSum Method

Sets checksum information.  
  
## Syntax  
  
```cpp  
HRESULT SetCheckSum(  
    [in]  GUID     algorithmId,  
    [in]  ULONG32  checkSumSize,  
    [in, size_is(checkSumSize)]  BYTE checkSum[]);  
```  
  
## Parameters  

 `algorithmId`  
 [in] The GUID that represents the algorithm identifier.  
  
 `checkSumSize`  
 [in] A `ULONG32` that indicates the size, in bytes, of the `checkSum` buffer.  
  
 `checkSum`  
 [in] The buffer that stores the checksum information.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedDocumentWriter Interface](isymunmanageddocumentwriter-interface.md)
