---
description: "Learn more about: ICLRStrongName::StrongNameKeyDelete Method"
title: "ICLRStrongName::StrongNameKeyDelete Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRStrongName.StrongNameKeyDelete"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameKeyDelete"
helpviewer_keywords: 
  - "StrongNameKeyDelete method, ICLRStrongName interface [.NET Framework hosting]"
  - "ICLRStrongName::StrongNameKeyDelete method [.NET Framework hosting]"
ms.assetid: 0163412f-f617-4428-89e0-03992fec31e8
topic_type: 
  - "apiref"
---
# ICLRStrongName::StrongNameKeyDelete Method

Deletes the specified key container.  
  
## Syntax  
  
```cpp  
HRESULT StrongNameKeyDelete (  
    [in]  LPCWSTR   wszKeyContainer  
);  
```  
  
## Parameters  

 `wszKeyContainer`  
 [in] The name of the key container to delete.  
  
## Return Value  

 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](/windows/win32/seccrypto/common-hresult-values) for a list).  
  
## Remarks  

 Use the [ICLRStrongName::StrongNameKeyInstall](iclrstrongname-strongnamekeyinstall-method.md) method to import a public/private key pair into a container.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [StrongNameKeyInstall Method](iclrstrongname-strongnamekeyinstall-method.md)
- [ICLRStrongName Interface](iclrstrongname-interface.md)
