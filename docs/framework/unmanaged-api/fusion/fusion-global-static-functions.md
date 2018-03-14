---
title: "Fusion Global Static Functions"
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
  - "unmanaged global static functions [.NET Framework], fusion"
  - "fusion global static functions [.NET Framework]"
  - "global static functions [.NET Framework fusion]"
ms.assetid: 229b2188-9168-4b44-a987-e1f515494688
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Fusion Global Static Functions
This section describes the unmanaged global static functions that the fusion API uses.  
  
## In This Section  
 [ClearDownloadCache Function](../../../../docs/framework/unmanaged-api/fusion/cleardownloadcache-function.md)  
 Clears the global assembly cache of downloaded assemblies.  
  
 [CompareAssemblyIdentity Function](../../../../docs/framework/unmanaged-api/fusion/compareassemblyidentity-function.md)  
 Compares two assembly identities to determine whether they are equivalent.  
  
 [CreateApplicationContext Function](../../../../docs/framework/unmanaged-api/fusion/createapplicationcontext-function.md)  
 Internal only. (This function supports the .NET Framework infrastructure and is not intended to be used directly from your code.)  
  
 [CreateAssemblyCache Function](../../../../docs/framework/unmanaged-api/fusion/createassemblycache-function.md)  
 Gets a pointer to a new [IAssemblyCache](../../../../docs/framework/unmanaged-api/fusion/iassemblycache-interface.md) instance that represents the global assembly cache.  
  
 [CreateAssemblyEnum Function](../../../../docs/framework/unmanaged-api/fusion/createassemblyenum-function.md)  
 Gets a pointer to an [IAssemblyEnum](../../../../docs/framework/unmanaged-api/fusion/iassemblyenum-interface.md) instance that represents a list of objects that exist in the specified assembly.  
  
 [CreateAssemblyNameObject Function](../../../../docs/framework/unmanaged-api/fusion/createassemblynameobject-function.md)  
 Gets a pointer to an [IAssemblyName](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md) instance that represents the unique identity of the assembly with the specified name.  
  
 [CreateHistoryReader Function](../../../../docs/framework/unmanaged-api/fusion/createhistoryreader-function.md)  
 Creates a history reader for the specified file.  
  
 [CreateInstallReferenceEnum Function](../../../../docs/framework/unmanaged-api/fusion/createinstallreferenceenum-function.md)  
 Gets a pointer to an [IInstallReferenceEnum](../../../../docs/framework/unmanaged-api/fusion/iinstallreferenceenum-interface.md) instance that represents a list of an application's references to the specified assembly.  
  
 [GetAppIdAuthority Function](../../../../docs/framework/unmanaged-api/fusion/getappidauthority-function.md)  
 Gets a pointer to an [IAppIdAuthority](../../../../docs/framework/unmanaged-api/fusion/iappidauthority-interface.md) instance that manages keys for application identities and references.  
  
 [GetAssemblyIdentityFromFile Function](../../../../docs/framework/unmanaged-api/fusion/getassemblyidentityfromfile-function.md)  
 Gets a pointer to an `IUnknown` object with the specified `IID` in the assembly at the specified file path.  
  
 [GetCachePath Function](../../../../docs/framework/unmanaged-api/fusion/getcachepath-function.md)  
 Gets the path to the cached assembly, using the specified flags.  
  
 [GetHistoryFileDirectory Function](../../../../docs/framework/unmanaged-api/fusion/gethistoryfiledirectory-function.md)  
 Retrieves the path of the application history directory.  
  
 [GetIdentityAuthority Function](../../../../docs/framework/unmanaged-api/fusion/getidentityauthority-function.md)  
 Gets a pointer to an [IIdentityAuthority](../../../../docs/framework/unmanaged-api/fusion/iidentityauthority-interface.md) instance that manages keys for code objects.  
  
 [IsFrameworkAssembly Function](../../../../docs/framework/unmanaged-api/fusion/isframeworkassembly-function.md)  
 Gets a value that indicates whether the specified assembly is managed.  
  
 [NukeDownloadedCache Function](../../../../docs/framework/unmanaged-api/fusion/nukedownloadedcache-function.md)  
 Deletes the common language runtime download cache.  
  
 [PreBindAssemblyEx Function](../../../../docs/framework/unmanaged-api/fusion/prebindassemblyex-function.md)  
 Gets the post-policy display name for an assembly.  
  
## Related Sections  
 [Fusion Interfaces](../../../../docs/framework/unmanaged-api/fusion/fusion-interfaces.md)  
  
 [Fusion Enumerations](../../../../docs/framework/unmanaged-api/fusion/fusion-enumerations.md)  
  
 [Fusion Structures](../../../../docs/framework/unmanaged-api/fusion/fusion-structures.md)  
  
 [Global Assembly Cache](../../../../docs/framework/app-domains/gac.md)
