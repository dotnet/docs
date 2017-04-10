---
title: "ISymUnmanagedDocument::GetCheckSum Method | Microsoft Docs"
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
  - "ISymUnmanagedDocument.GetCheckSum"
apilocation: 
  - "diasymreader.dll"
apitype: "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::GetCheckSum"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ISymUnmanagedDocument::GetCheckSum method [.NET Framework debugging]"
  - "GetCheckSum method [.NET Framework debugging]"
ms.assetid: 9bc881b3-e2ce-48a7-ad69-17eaaa304120
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ISymUnmanagedDocument::GetCheckSum Method
Gets the checksum.  
  
## Syntax  
  
```  
HRESULT GetCheckSum(  
    [in]  ULONG32  cData,  
    [out] ULONG32  *pcData,  
    [out, size_is(cData), length_is(*pcData)] BYTE data[]);  
```  
  
#### Parameters  
 `cData`  
 [in] The length of the buffer provided by the `data` parameter  
  
 `pcData`  
 [out] The size and length of the checksum, in bytes.  
  
 `data`  
 [out] The buffer that receives the checksum.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, an error code.  
  
## See Also  
 [ISymUnmanagedDocument Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocument-interface.md)