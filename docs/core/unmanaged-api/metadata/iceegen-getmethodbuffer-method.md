---
description: "Learn more about: ICeeGen::GetMethodBuffer Method"
title: "ICeeGen::GetMethodBuffer Method"
ms.date: "03/30/2017"
api_name: 
  - "ICeeGen.GetMethodBuffer"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICeeGen::GetMethodBuffer"
helpviewer_keywords: 
  - "ICeeGen::GetMethodBuffer method [.NET Framework metadata]"
  - "GetMethodBuffer method [.NET Framework metadata]"
ms.assetid: c7c5b39a-d4ac-41f1-9d1e-44163f563a49
topic_type: 
  - "apiref"
---
# ICeeGen::GetMethodBuffer Method

Gets a buffer of the appropriate size for the method at the specified relative virtual address.  
  
 This method is obsolete and should not be used.  
  
## Syntax  
  
```cpp  
HRESULT GetMethodBuffer (  
    [in]  ULONG       RVA,  
    [out] UCHAR       **lpBuffer  
);  
```  
  
## Parameters  

 `RVA`  
 [in] The relative virtual address of the method for which to return a buffer.  
  
 `lpBuffer`  
 [out] A pointer to the returned buffer.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICeeGen Interface](iceegen-interface.md)
