---
description: "Learn more about: IMapToken::Map Method"
title: "IMapToken::Map Method"
ms.date: "03/30/2017"
api_name: 
  - "IMapToken.Map"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMapToken::Map"
helpviewer_keywords: 
  - "IMapToken::Map method [.NET Framework metadata]"
  - "Map method [.NET Framework metadata]"
ms.assetid: b9b4bf2f-1098-43d6-9619-a99b4bda1940
topic_type: 
  - "apiref"
---
# IMapToken::Map Method

Maps a relationship between the assemblies using metadata signatures.  
  
## Syntax  
  
```cpp  
HRESULT Map (  
    [in]  mdToken tkImp,
    [in]  mdToken tkEmit  
);  
```  
  
## Parameters  

 `tkImp`  
 [in] The metadata token that represents the imported code object.  
  
 `tkEmit`  
 [in] The metadata token that represents the emitted code object.  
  
## Remarks  

 When the token re-map occurs during a merge, the original token is scoped in the imported (source) metadata scope and the new token is scoped in the emitted (target) metadata scope.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMapToken Interface](imaptoken-interface.md)
