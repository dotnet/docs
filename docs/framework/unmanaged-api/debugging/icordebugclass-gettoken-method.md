---
description: "Learn more about: ICorDebugClass::GetToken Method"
title: "ICorDebugClass::GetToken Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugClass.GetToken"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugClass::GetToken"
helpviewer_keywords: 
  - "GetToken method, ICorDebugClass interface [.NET Framework debugging]"
  - "ICorDebugClass::GetToken method [.NET Framework debugging]"
ms.assetid: ee5c848a-eac4-4462-b07a-07ccd76a75df
topic_type: 
  - "apiref"
---
# ICorDebugClass::GetToken Method

Gets the `TypeDef` metadata token that references the definition of this class.  
  
## Syntax  
  
```cpp  
HRESULT GetToken (  
    [out] mdTypeDef          *pTypeDef  
);  
```  
  
## Parameters  

 `pTypeDef`  
 [out] A pointer to an `mdTypeDef` token that references the definition of this class.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Interfaces](../metadata/metadata-interfaces.md)
