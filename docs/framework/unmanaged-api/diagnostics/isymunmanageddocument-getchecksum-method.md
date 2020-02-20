---
title: "ISymUnmanagedDocument::GetCheckSum Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedDocument.GetCheckSum"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::GetCheckSum"
helpviewer_keywords: 
  - "ISymUnmanagedDocument::GetCheckSum method [.NET Framework debugging]"
  - "GetCheckSum method [.NET Framework debugging]"
ms.assetid: 9bc881b3-e2ce-48a7-ad69-17eaaa304120
topic_type: 
  - "apiref"
---
# ISymUnmanagedDocument::GetCheckSum Method
Gets the checksum.  
  
## Syntax  
  
```cpp  
HRESULT GetCheckSum(  
    [in]  ULONG32  cData,  
    [out] ULONG32  *pcData,  
    [out, size_is(cData), length_is(*pcData)] BYTE data[]);  
```  
  
## Parameters  
 `cData`  
 [in] The length of the buffer provided by the `data` parameter  
  
 `pcData`  
 [out] The size and length of the checksum, in bytes.  
  
 `data`  
 [out] The buffer that receives the checksum.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, an error code.  
  
## See also

- [ISymUnmanagedDocument Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocument-interface.md)
