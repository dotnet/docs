---
title: "IIdentityAuthority Interface"
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
  - "IIdentityAuthority"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IIdentityAuthority"
helpviewer_keywords: 
  - "IIdentityAuthority interface [.NET Framework fusion]"
ms.assetid: 6277f914-51a8-49be-bec6-52d6d648527d
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IIdentityAuthority Interface
Manages identity keys for code objects.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|`IIdentityAuthority::AreDefinitionsEqual`|Gets a value that indicates whether the two specified [IDefinitionIdentity](../../../../docs/framework/unmanaged-api/fusion/idefinitionidentity-interface.md) instances are equal.|  
|`IIdentityAuthority::AreReferencesEqual`|Gets a value that indicates whether the two specified [IReferenceIdentity](../../../../docs/framework/unmanaged-api/fusion/ireferenceidentity-interface.md) instances are equal.|  
|`IIdentityAuthority::AreTextualDefinitionsEqual`|Gets a value that indicates whether the two specified string definition identity representations are equal.|  
|`IIdentityAuthority::AreTextualReferencesEqual`|Gets a value that indicates whether the two specified string reference identity representations are equal.|  
|`IIdentityAuthority::CreateDefinition`|Gets a pointer to a new `IDefinitionIdentity` instance that represents the code object in the current scope.|  
|`IIdentityAuthority::CreateReference`|Gets a pointer to a new `IReferenceIdentity` instance that represents the code object in the current scope.|  
|`IIdentityAuthority::DefinitionToText`|Gets a formatted string version of the specified `IDefinitionIdentity`.|  
|`IIdentityAuthority::DefinitionToTextBuffer`|Fills the specified wide character buffer with a string version of the specified `IDefinitionIdentity`.|  
|`IIdentityAuthority::DoesDefinitionMatchReference`|Gets a value that indicates whether the specified `IDefinitionIdentity` and `IReferenceIdentity` instances refer to the same code object.|  
|`IIdentityAuthority::DoesTextualDefinitionMatchTextualReference`|Gets a value that indicates whether the specified strings refer to the same code object.|  
|`IIdentityAuthority::GenerateDefinitionKey`|Gets a pointer to a newly created string key for the specified `IDefinitionIdentity`.|  
|`IIdentityAuthority::GenerateReferenceKey`|Gets a pointer to a newly created string key for the specified `IReferenceIdentity`.|  
|`IIdentityAuthority::HashDefinition`|Gets a hash value for the specified `IDefinitionIdentity`.|  
|`IIdentityAuthority::HashReference`|Gets a hash value for the specified `IreferenceIdentity`.|  
|`IIdentityAuthority::ReferenceToText`|Gets a formatted string version of the specified `IReferenceIdentity`.|  
|`IIdentityAuthority::ReferenceToTextBuffer`|Fills the specified wide character buffer with a string version of the specified `IReferenceIdentity`.|  
|`IIdentityAuthority::TextToDefinition`|Gets an interface pointer to an `IDefinitionIdentity` instance generated from the specified formatted string.|  
|`IIdentityAuthority::TextToReference`|Gets an interface pointer to an `IReferenceIdentity` instance generated from the specified formatted string.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Fusion Interfaces](../../../../docs/framework/unmanaged-api/fusion/fusion-interfaces.md)
