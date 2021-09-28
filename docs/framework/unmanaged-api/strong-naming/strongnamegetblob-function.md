---
description: "Learn more about: StrongNameGetBlob Function"
title: "StrongNameGetBlob Function"
ms.date: "03/30/2017"
api_name: 
  - "StrongNameGetBlob"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameGetBlob"
helpviewer_keywords: 
  - "StrongNameGetBlob function [.NET Framework strong naming]"
ms.assetid: 15d09166-be00-4696-913f-2c1fbc7ac2e1
topic_type: 
  - "apiref"
---
# StrongNameGetBlob Function

Fills the specified buffer with the binary representation of the executable file at the specified address.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameGetBLob](../hosting/iclrstrongname-strongnamegetblob-method.md) method instead.  
  
## Syntax  
  
```cpp  
BOOLEAN StrongNameGetBlob (  
    [in]  LPCWSTR    wszFilePath,  
    [in]  BYTE       *pbBlob,  
    [in, out] DWORD  *pcbBlob  
);  
```  
  
## Parameters  

 `wszFilePath`  
 [in] A valid path to the executable file to be loaded.  
  
 `pbBlob`  
 [in] The buffer into which to load the executable file.  
  
 `pcbBlob`  
 [in, out] The requested maximum size, in bytes, of `pbBlob`. Upon return, the actual size, in bytes, of `pbBlob`.  
  
## Return Value  

 `true` on successful completion; otherwise, `false`.  
  
## Remarks  

 If the `StrongNameGetBlob` function does not complete successfully, call the [StrongNameErrorInfo](strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [StrongNameGetBlob Method](../hosting/iclrstrongname-strongnamegetblob-method.md)
- [StrongNameGetBlobFromImage Method](../hosting/iclrstrongname-strongnamegetblobfromimage-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
