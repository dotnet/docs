---
title: "ICeeGen::GetString Method | Microsoft Docs"
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
  - "ICeeGen.GetString"
apilocation: 
  - "mscoree.dll"
apitype: "COM"
f1_keywords: 
  - "ICeeGen::GetString"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICeeGen::GetString method [.NET Framework metadata]"
  - "GetString method, ICeeGen interface [.NET Framework metadata]"
ms.assetid: 7cc22562-128c-440a-9147-55ff20f173d7
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ICeeGen::GetString Method
Gets the string stored at the specified relative virtual address.  
  
 This method is obsolete and should not be used.  
  
## Syntax  
  
```  
HRESULT GetString (  
    [in]  ULONG      RVA,   
    [out] LPWSTR     *lpString  
);  
```  
  
#### Parameters  
 `RVA`  
 [in] The relative virtual address of the string to return.  
  
 `lpString`  
 [out] The returned string.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICeeGen Interface](../../../../docs/framework/unmanaged-api/metadata/iceegen-interface.md)