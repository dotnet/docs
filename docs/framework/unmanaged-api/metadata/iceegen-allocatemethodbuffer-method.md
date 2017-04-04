---
title: "ICeeGen::AllocateMethodBuffer Method | Microsoft Docs"
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
  - "ICeeGen.AllocateMethodBuffer"
apilocation: 
  - "mscoree.dll"
apitype: "COM"
f1_keywords: 
  - "ICeeGen::AllocateMethodBuffer"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "AllocateMethodBuffer method [.NET Framework metadata]"
  - "ICeeGen::AllocateMethodBuffer method [.NET Framework metadata]"
ms.assetid: 845ab77e-9639-47f5-99fb-f3b619e3e779
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ICeeGen::AllocateMethodBuffer Method
Creates a buffer of the specified size for a method, and gets the relative virtual address of the method.  
  
 This method is obsolete and should not be used.  
  
## Syntax  
  
```  
HRESULT AllocateMethodBuffer (   
    [in]  ULONG    cchBuffer,   
    [out] UCHAR    **lpBuffer,  
    [out] ULONG    *RVA  
);  
```  
  
#### Parameters  
 `cchBuffer`  
 [in] The length of the buffer to create.  
  
 `lpBuffer`  
 [out] The returned buffer.  
  
 `RVA`  
 [out] The relative virtual address of the method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICeeGen Interface](../../../../docs/framework/unmanaged-api/metadata/iceegen-interface.md)