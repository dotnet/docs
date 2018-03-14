---
title: "IAppIdAuthority Interface"
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
  - "IAppIdAuthority"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAppIdAuthority"
helpviewer_keywords: 
  - "IAppIdAuthority interface [.NET Framework fusion]"
ms.assetid: ec354fa1-1efd-41b0-bc43-b90597b6e253
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IAppIdAuthority Interface
Provides methods that generate and compare keys for application identities and references.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|`IAppIdAuthority::AreDefinitionsEqual`|Gets a value that indicates whether the two specified [IDefinitionAppId](../../../../docs/framework/unmanaged-api/fusion/idefinitionappid-interface.md) instances are equal. You can pass the flag value IAPPIDAUTHORITY_ARE_DEFINITIONS_EQUAL_FLAG_IGNORE_VERSION to ignore their respective version information.|  
|`IAppIdAuthority::AreReferencesEqual`|Gets a value that indicates whether the two specified [IReferenceAppId](../../../../docs/framework/unmanaged-api/fusion/ireferenceappid-interface.md) instances are equal. You can pass the flag value IAPPIDAUTHORITY_ARE_REFERENCES_EQUAL_FLAG_IGNORE_VERSION to ignore their respective version information.|  
|`IAppIdAuthority::AreTextualDefinitionsEqual`|Gets a value that indicates whether the two specified string definitions are equal. You can pass the flag value IAPPIDAUTHORITY_ARE_DEFINITIONS_EQUAL_FLAG_IGNORE_VERSION to ignore their respective version information.|  
|`IAppIdAuthority::AreTextualReferencesEqual`|Gets a value that indicates whether the two specified string references are equal. You can pass the flag value IAPPIDAUTHORITY_ARE_REFERENCES_EQUAL_FLAG_IGNORE_VERSION to ignore their respective version information.|  
|`IAppIdAuthority::CreateDefinition`|Gets an interface pointer to a newly generated `IDefinitionAppId` instance that represents the assembly in the current scope.|  
|`IAppIdAuthority::CreateReference`|Gets an interface pointer to a newly created `IReferenceAppId` that represents the assembly in the current scope.|  
|`IAppIdAuthority::DefinitionToText`|Gets a string version of the specified `IDefinitionAppId`, using the specified flag values.|  
|`IAppIdAuthority::DoesDefinitionMatchReference`|Gets a value that indicates whether the specified `IDefinitionAppId` and `IReferenceAppId` represent the same assembly.|  
|`IAppIdAuthority::DoesTextualDefinitionMatchTextualReference`|Gets a value that indicates whether the specified definition string and reference string represent the same assembly.|  
|`IAppIdAuthority::GenerateDefinitionKey`|Gets a string key that represents the specified `IDefinitionAppId` instance.|  
|`IAppIdAuthority::GenerateReferenceKey`|Gets a string key that represents the specified `IReferenceAppId` instance.|  
|`IAppIdAuthority::HashDefinition`|Gets a hash key for the specified `IDefinitionAppId` instance.|  
|`IAppIdAuthority::HashReference`|Gets a hash key for the specified `IReferenceAppId` instance.|  
|`IAppIdAuthority::ReferenceToText`|Gets a string version of the specified `IReferenceAppId`, using the specified flag values.|  
|`IAppIdAuthority::TextToDefinition`|Gets an interface pointer to an `IDefinitionAppId` instance that represents the assembly referenced by the specified string key.|  
|`IAppIdAuthority::TextToReference`|Gets an interface pointer to an `IReferenceAppId` instance that represents the assembly referenced by the specified string key.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Fusion Interfaces](../../../../docs/framework/unmanaged-api/fusion/fusion-interfaces.md)
