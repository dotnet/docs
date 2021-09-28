---
description: "Learn more about: IEnumDefinitionIdentity Interface"
title: "IEnumDefinitionIdentity Interface"
ms.date: "03/30/2017"
api_name: 
  - "IEnumDefinitionIdentity"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IEnumDefinitionIdentity"
helpviewer_keywords: 
  - "IEnumDefinitionIdentity interface [.NET Framework fusion]"
ms.assetid: 8263e75d-251b-4abc-8a1a-c62884142232
topic_type: 
  - "apiref"
---
# IEnumDefinitionIdentity Interface

Serves as the enumerator for a collection of `IDefinitionIdentity` objects.  
  
## Syntax  
  
```cpp  
IEnumDefinitionIdentity : IUnknown {  
  
    HRESULT Clone (  
        [out] IEnumDefinitionIdentity **ppIEnumDefinitionIdentity  
    );  
  
    HRESULT Next (  
        [in]  ULONG               celt,  
        [out, length_is(celt), size_is(*pceltWritten)]  
              IDefinitionIdentity *rgpIDefinitionIdentity[],  
        [out] ULONG               *pceltWritten  
    );  
  
    HRESULT Reset ();  
  
    HRESULT Skip (  
        [in] ULONG celt  
    );  
  
};  
```  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|`IEnumDefinitionIdentity::Clone`|Gets an interface pointer to a new `IEnumDefinitionIdentity` object that contains the same members as this `IEnumDefinitionIdentity`.|  
|`IEnumDefinitionIdentity::Next`|Gets the specified number of `IDefinitionIdentity` objects, starting at the current position.|  
|`IEnumDefinitionIdentity::Reset`|Moves the instruction pointer to the beginning of this `IEnumDefinitionIdentity`.|  
|`IEnumDefinitionIdentity::Skip`|Moves the instruction pointer forward by the specified number of elements, starting at the current position.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Fusion Interfaces](fusion-interfaces.md)
- [IDefinitionIdentity Interface](idefinitionidentity-interface.md)
