---
title: "StrongNameHashSize Function"
ms.date: "03/30/2017"
api_name: 
  - "StrongNameHashSize"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameHashSize"
helpviewer_keywords: 
  - "StrongNameHashSize function [.NET Framework strong naming]"
ms.assetid: 738c98d7-a60c-45fe-a296-220af05e6991
topic_type: 
  - "apiref"
---
# StrongNameHashSize Function
Gets the buffer size required for a hash, using the specified hash algorithm.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameHashSize](../hosting/iclrstrongname-strongnamehashsize-method.md) method instead.  
  
## Syntax  
  
```cpp  
BOOLEAN StrongNameHashSize (  
    [in]  ULONG   ulHashAlg,  
    [out] DWORD   *pcbSize  
);  
```  
  
## Parameters  
 `ulHashAlg`  
 [in] The hash algorithm used to compute the buffer size.  
  
 `pcbSize`  
 [out] The returned buffer size, in bytes.  
  
## Return Value  
 `true` on successful completion; otherwise, `false`.  
  
## Remarks  
 If the `StrongNameHashSize` function does not complete successfully, call the [StrongNameErrorInfo](strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [StrongNameHashSize Method](../hosting/iclrstrongname-strongnamehashsize-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
