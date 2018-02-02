---
title: "Fusion Interfaces"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "interfaces [.NET Framework fusion]"
  - "fusion interfaces [.NET Framework]"
  - "unmanaged interfaces [.NET Framework], fusion"
ms.assetid: e2cf98b7-40c1-4f74-86c7-8a76dd9da677
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Fusion Interfaces
This section describes the unmanaged interfaces that the fusion API uses to access the properties of an application's resources and to locate the correct versions of those resources for the application.  
  
## In This Section  
 [IAppIdAuthority Interface](../../../../docs/framework/unmanaged-api/fusion/iappidauthority-interface.md)  
 Provides methods that generate and compare keys for application identities and references.  
  
 [IAssemblyCache Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblycache-interface.md)  
 Provides a representation of the global assembly cache.  
  
 [IAssemblyCacheItem Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblycacheitem-interface.md)  
 Represents a single assembly in the global assembly cache.  
  
 [IAssemblyEnum Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyenum-interface.md)  
 Represents an enumerator for an array of `IAssemblyName` objects.  
  
 [IAssemblyName Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md)  
 Provides methods for describing and working with an assembly's unique identity.  
  
 [IDefinitionAppId Interface](../../../../docs/framework/unmanaged-api/fusion/idefinitionappid-interface.md)  
 Represents a unique identifier for the code that defines the application in the current scope.  
  
 [IDefinitionIdentity Interface](../../../../docs/framework/unmanaged-api/fusion/idefinitionidentity-interface.md)  
 Represents the unique signature of the code that defines the application in the current scope.  
  
 [IEnumDefinitionIdentity Interface](../../../../docs/framework/unmanaged-api/fusion/ienumdefinitionidentity-interface.md)  
 Serves as the enumerator for a collection of `IDefinitionIdentity` objects.  
  
 [IEnumIDENTITY_ATTRIBUTE Interface](../../../../docs/framework/unmanaged-api/fusion/ienumidentity-attribute-interface.md)  
 Serves as an enumerator for the attributes of the code object in the current scope.  
  
 [IEnumReferenceIdentity Interface](../../../../docs/framework/unmanaged-api/fusion/ienumreferenceidentity-interface.md)  
 Serves as an enumerator for a collection of `IReferenceIdentity` objects.  
  
 [IIdentityAuthority Interface](../../../../docs/framework/unmanaged-api/fusion/iidentityauthority-interface.md)  
 Manages identity keys for code objects.  
  
 [IInstallReferenceEnum Interface](../../../../docs/framework/unmanaged-api/fusion/iinstallreferenceenum-interface.md)  
 Represents an enumerator for the referenced assemblies installed in the global assembly cache.  
  
 [IInstallReferenceItem Interface](../../../../docs/framework/unmanaged-api/fusion/iinstallreferenceitem-interface.md)  
 Represents an item installed in the global assembly cache.  
  
 [IReferenceAppId Interface](../../../../docs/framework/unmanaged-api/fusion/ireferenceappid-interface.md)  
 Represents a reference to the unique identifier for the application in the current scope.  
  
 [IReferenceIdentity Interface](../../../../docs/framework/unmanaged-api/fusion/ireferenceidentity-interface.md)  
 Represents a reference to the unique signature of a code object.  
  
## Reference  
 <xref:System.Reflection>  
  
 <xref:System.Reflection.Emit>  
  
## Related Sections  
 [Fusion Global Static Functions](../../../../docs/framework/unmanaged-api/fusion/fusion-global-static-functions.md)  
  
 [Fusion Enumerations](../../../../docs/framework/unmanaged-api/fusion/fusion-enumerations.md)  
  
 [Fusion Structures](../../../../docs/framework/unmanaged-api/fusion/fusion-structures.md)
