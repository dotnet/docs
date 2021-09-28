---
description: "Learn more about: ICeeGen::GetIlSection Method"
title: "ICeeGen::GetIlSection Method"
ms.date: "03/30/2017"
api_name: 
  - "ICeeGen.GetIlSection"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICeeGen::GetIlSection"
helpviewer_keywords: 
  - "GetIlSection method [.NET Framework metadata]"
  - "ICeeGen::GetIlSection method [.NET Framework metadata]"
ms.assetid: 6f2db2ca-203f-4ac3-9530-208642ca385e
topic_type: 
  - "apiref"
---
# ICeeGen::GetIlSection Method

Gets the section of the intermediate language code base referenced by the specified handle.  
  
 This method is obsolete and should not be used.  
  
## Syntax  
  
```cpp  
HRESULT GetIlSection (  
    [in] HCEESECTION  *section  
);  
```  
  
## Parameters  

 `section`  
 [in] The handle to the section to get.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICeeGen Interface](iceegen-interface.md)
