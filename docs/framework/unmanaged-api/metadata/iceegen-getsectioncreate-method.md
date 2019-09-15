---
title: "ICeeGen::GetSectionCreate Method"
ms.date: "03/30/2017"
api_name: 
  - "ICeeGen.GetSectionCreate"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICeeGen::GetSectionCreate"
helpviewer_keywords: 
  - "ICeeGen::GetSectionCreate method [.NET Framework metadata]"
  - "GetSectionCreate method [.NET Framework metadata]"
ms.assetid: 154b2460-59ce-4874-a9f2-1b3353486ac5
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICeeGen::GetSectionCreate Method
Generates and gets a code section using the specified name and flag values.  
  
 This method is obsolete and should not be used.  
  
## Syntax  
  
```cpp  
HRESULT GetSectionCreate (  
    [in]  const char     *name,  
    [in]  DWORD          flags,  
    [out] HCEESECTION    *section  
);  
```  
  
## Parameters  
 `name`  
 [in] A pointer to a string that specifies the name of the section to be created.  
  
 `flags`  
 [in] Flags that specify options.  
  
 `section`  
 [out] A pointer to the newly created code section.  
  
## Remarks  
 Call `GetSectionCreate` only if you have special section requirements that are not handled by other methods.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICeeGen Interface](../../../../docs/framework/unmanaged-api/metadata/iceegen-interface.md)
