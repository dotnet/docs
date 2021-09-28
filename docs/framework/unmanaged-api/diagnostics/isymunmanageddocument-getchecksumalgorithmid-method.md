---
description: "Learn more about: ISymUnmanagedDocument::GetCheckSumAlgorithmId Method"
title: "ISymUnmanagedDocument::GetCheckSumAlgorithmId Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedDocument.GetCheckSumAlgorithmId"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::GetCheckSumAlgorithmId"
helpviewer_keywords: 
  - "ISymUnmanagedDocument::GetCheckSumAlgorithmId method [.NET Framework debugging]"
  - "GetCheckSumAlgorithmId method [.NET Framework debugging]"
ms.assetid: c7f941cd-e25b-4b85-b1ce-5f77c9208fa9
topic_type: 
  - "apiref"
---
# ISymUnmanagedDocument::GetCheckSumAlgorithmId Method

Gets the checksum algorithm identifier, or returns a GUID of all zeros if there is no checksum.  
  
## Syntax  
  
```cpp  
HRESULT GetCheckSumAlgorithmId(  
    [out, retval] GUID*  pRetVal);  
```  
  
## Parameters  

 `pRetVal`  
 [out] A pointer to a variable that receives the checksum algorithm identifier.  
  
## Return Value  

 S_OK if the method succeeds.  
  
## See also

- [ISymUnmanagedDocument Interface](isymunmanageddocument-interface.md)
