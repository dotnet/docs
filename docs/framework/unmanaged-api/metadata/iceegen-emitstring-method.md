---
title: "ICeeGen::EmitString Method"
ms.date: "03/30/2017"
api_name: 
  - "ICeeGen.EmitString"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICeeGen::EmitString"
helpviewer_keywords: 
  - "EmitString method [.NET Framework metadata]"
  - "ICeeGen::EmitString method [.NET Framework metadata]"
ms.assetid: ad2710a7-edb8-4493-8619-3fce235e3334
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICeeGen::EmitString Method
Emits the specified string into the code base.  
  
 This method is obsolete and should not be used.  
  
## Syntax  
  
```  
HRESULT EmitString (  
    [in]  LPWSTR    lpString,  
    [out] ULONG     *RVA  
);  
```  
  
#### Parameters  
 `lpString`  
 [in] The string to emit.  
  
 `RVA`  
 [out] The relative virtual address of the emitted string.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
 [ICeeGen Interface](../../../../docs/framework/unmanaged-api/metadata/iceegen-interface.md)
