---
description: "Learn more about: CreateICeeFileGen Function"
title: "CreateICeeFileGen Function"
ms.date: "03/30/2017"
api_name: 
  - "CreateICeeFileGen"
api_location: 
  - "mscoree.dll"
  - "mscorpehost.dll"
  - "mscorpe.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CreateICeeFileGen"
helpviewer_keywords: 
  - "CreateICeeFileGen function [.NET Framework hosting]"
ms.assetid: e36e1fd8-8456-4359-bdc3-3ec1765f041f
topic_type: 
  - "apiref"
---
# CreateICeeFileGen Function

Creates an [ICeeFileGen](iceefilegen-class.md) object.  
  
 This function has been deprecated in the .NET Framework 4.  
  
## Syntax  
  
```cpp  
HRESULT CreateICeeFileGen (  
    [out] ICeeFileGen  **ceeFileGen  
);  
```  
  
## Parameters  

 `ceeFileGen`  
 [out] A pointer to the address of a new `ICeeFileGen` object.  
  
## Return Value  

 This method returns standard COM error codes.  
  
## Remarks  

 The `ICeeFileGen` object is used to create common language runtime (CLR) portable executable (PE) files.  
  
 Call the [DestroyICeeFileGen](destroyiceefilegen-function.md) function to destroy the `ICeeFileGen` object when finished.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** ICeeFileGen.h  
  
 **Library:** MSCorPE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
