---
title: "ICeeGen::GetSectionBlock Method"
ms.date: "03/30/2017"
api_name: 
  - "ICeeGen.GetSectionBlock"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICeeGen::GetSectionBlock"
helpviewer_keywords: 
  - "GetSectionBlock method [.NET Framework metadata]"
  - "ICeeGen::GetSectionBlock method [.NET Framework metadata]"
ms.assetid: 05c78aaf-5bbd-497e-9ae2-55f4fae0c5fb
topic_type: 
  - "apiref"
---
# ICeeGen::GetSectionBlock Method
Gets a section block of the code base.  
  
 This method is obsolete and should not be used.  
  
## Syntax  
  
```cpp  
HRESULT GetSectionBlock (  
    [in]  HCEESECTION    section,     
    [in]  ULONG          len,  
    [in]  ULONG          align     = 1,  
    [out] void           **ppBytes = 0  
);   
```  
  
## Parameters  
 `section`  
 [in] The section from which to retrieve a block of the code base.  
  
 `len`  
 [in] The length of the block to be retrieved.  
  
 `align`  
 [in] The byte, relative to the beginning of the section, with which to align the first byte of the block. This is the position of the block within the section.  
  
 `ppBytes`  
 [out] A pointer to a location that receives the address of the retrieved block.  
  
## Remarks  
 Call `GetSectionBlock` only if you have special section requirements that are not handled by other methods.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICeeGen Interface](../../../../docs/framework/unmanaged-api/metadata/iceegen-interface.md)
