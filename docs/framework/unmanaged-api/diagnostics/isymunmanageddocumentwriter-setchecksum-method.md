---
title: "ISymUnmanagedDocumentWriter::SetCheckSum Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ISymUnmanagedDocumentWriter.SetCheckSum"
apilocation: 
  - "diasymreader.dll"
apitype: "COM"
f1_keywords: 
  - "ISymUnmanagedDocumentWriter::SetCheckSum"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ISymUnmanagedDocumentWriter::SetCheckSum method [.NET Framework debugging]"
  - "SetCheckSum method [.NET Framework debugging]"
ms.assetid: c7e99879-421f-43ce-b193-34733cf30085
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ISymUnmanagedDocumentWriter::SetCheckSum Method
Sets checksum information.  
  
## Syntax  
  
```  
HRESULT SetCheckSum(  
    [in]  GUID     algorithmId,  
    [in]  ULONG32  checkSumSize,  
    [in, size_is(checkSumSize)]  BYTE checkSum[]);  
```  
  
#### Parameters  
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
  
## See Also  
 [ISymUnmanagedDocumentWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocumentwriter-interface.md)