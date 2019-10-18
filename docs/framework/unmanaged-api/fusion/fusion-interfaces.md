---
title: "Fusion Interfaces"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "interfaces [.NET Framework fusion]"
  - "fusion interfaces [.NET Framework]"
  - "unmanaged interfaces [.NET Framework], fusion"
ms.assetid: e2cf98b7-40c1-4f74-86c7-8a76dd9da677
author: "rpetrusha"
ms.author: "ronpet"
---
# Fusion Interfaces
This section describes the unmanaged interfaces that the fusion API uses to access the properties of an application's resources and to locate the correct versions of those resources for the application.  
  
## In This Section  
 [IAppIdAuthority Interface](iappidauthority-interface.md)  
 Provides methods that generate and compare keys for application identities and references.  
  
 [IAssemblyCache Interface](iassemblycache-interface.md)  
 Provides a representation of the global assembly cache.  
  
 [IAssemblyCacheItem Interface](iassemblycacheitem-interface.md)  
 Represents a single assembly in the global assembly cache.  
  
 [IAssemblyEnum Interface](iassemblyenum-interface.md)  
 Represents an enumerator for an array of `IAssemblyName` objects.  
  
 [IAssemblyName Interface](iassemblyname-interface.md)  
 Provides methods for describing and working with an assembly's unique identity.  
  
 [IDefinitionAppId Interface](idefinitionappid-interface.md)  
 Represents a unique identifier for the code that defines the application in the current scope.  
  
 [IDefinitionIdentity Interface](idefinitionidentity-interface.md)  
 Represents the unique signature of the code that defines the application in the current scope.  
  
 [IEnumDefinitionIdentity Interface](ienumdefinitionidentity-interface.md)  
 Serves as the enumerator for a collection of `IDefinitionIdentity` objects.  
  
 [IEnumIDENTITY_ATTRIBUTE Interface](ienumidentity-attribute-interface.md)  
 Serves as an enumerator for the attributes of the code object in the current scope.  
  
 [IEnumReferenceIdentity Interface](ienumreferenceidentity-interface.md)  
 Serves as an enumerator for a collection of `IReferenceIdentity` objects.  
  
 [IIdentityAuthority Interface](iidentityauthority-interface.md)  
 Manages identity keys for code objects.  
  
 [IInstallReferenceEnum Interface](iinstallreferenceenum-interface.md)  
 Represents an enumerator for the referenced assemblies installed in the global assembly cache.  
  
 [IInstallReferenceItem Interface](iinstallreferenceitem-interface.md)  
 Represents an item installed in the global assembly cache.  
  
 [IReferenceAppId Interface](ireferenceappid-interface.md)  
 Represents a reference to the unique identifier for the application in the current scope.  
  
 [IReferenceIdentity Interface](ireferenceidentity-interface.md)  
 Represents a reference to the unique signature of a code object.  
  
## Reference  
 <xref:System.Reflection>  
  
 <xref:System.Reflection.Emit>  
  
## Related Sections  
 [Fusion Global Static Functions](fusion-global-static-functions.md)  
  
 [Fusion Enumerations](fusion-enumerations.md)  
  
 [Fusion Structures](fusion-structures.md)
