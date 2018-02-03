---
title: "StrongNameKeyInstall Function"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "StrongNameKeyInstall"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameKeyInstall"
helpviewer_keywords: 
  - "StrongNameKeyInstall function [.NET Framework strong naming]"
ms.assetid: e32fd546-7757-4681-be3d-658e93281e50
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# StrongNameKeyInstall Function
Imports a public/private key pair into a container.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameKeyInstall](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamekeyinstall-method.md) method instead.  
  
## Syntax  
  
```  
BOOLEAN StrongNameKeyInstall (  
    [in]  LPCWSTR   wszKeyContainer,  
    [in]  BYTE      *pbKeyBlob,  
    [in]  ULONG     cbKeyBlob  
);  
```  
  
#### Parameters  
 `wszKeyContainer`  
 [in] The name of the key container. `wszKeyContainer` must be a non-empty string.  
  
 `pbKeyBlob`  
 [in] The binary key pair.  
  
 `cbKeyBlob`  
 [in] The size, in bytes, of `pbKeyBlob`.  
  
## Return Value  
 `true` on successful completion; otherwise, `false`.  
  
## Remarks  
 Use the [StrongNameKeyDelete](../../../../docs/framework/unmanaged-api/strong-naming/strongnamekeydelete-function.md) function to delete the key container.  
  
 If the `StrongNameKeyInstall` function does not complete successfully, call the [StrongNameErrorInfo](../../../../docs/framework/unmanaged-api/strong-naming/strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## Requirements  
 **Platforms:** WindSee [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [StrongNameKeyInstall Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamekeyinstall-method.md)  
 [StrongNameKeyDelete Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamekeydelete-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
