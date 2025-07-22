---
description: "Learn more about: ICeeGen::ComputePointer Method"
title: "ICeeGen::ComputePointer Method"
ms.date: "03/30/2017"
api_name: 
  - "ICeeGen.ComputePointer"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICeeGen::ComputePointer"
helpviewer_keywords: 
  - "ICeeGen::ComputePointer method [.NET Framework metadata]"
  - "ComputePointer method [.NET Framework metadata]"
ms.assetid: b6b95c04-0f2c-4fcc-a8bc-3b1dcbdba731
topic_type: 
  - "apiref"
---
# ICeeGen::ComputePointer Method

Determines the buffer for the specified code section.  
  
 This method is obsolete and should not be used.  
  
## Syntax  
  
```cpp  
HRESULT ComputePointer (  
    [in]  HCEESECTION  section,  
    [in]  ULONG        RVA,
    [out] UCHAR        **lpBuffer  
);  
```  
  
## Parameters  

 `section`  
 [in] The code section for which to return a buffer.  
  
 `RVA`  
 [in] The relative virtual address of the method for which to get a pointer.  
  
 `lpBuffer`  
 [out] A pointer to the returned buffer.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICeeGen Interface](iceegen-interface.md)
