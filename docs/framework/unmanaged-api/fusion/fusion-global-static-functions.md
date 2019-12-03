---
title: "Fusion Global Static Functions"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "unmanaged global static functions [.NET Framework], fusion"
  - "fusion global static functions [.NET Framework]"
  - "global static functions [.NET Framework fusion]"
ms.assetid: 229b2188-9168-4b44-a987-e1f515494688
---
# Fusion Global Static Functions
This section describes the unmanaged global static functions that the fusion API uses.  
  
## In This Section  
 [ClearDownloadCache Function](cleardownloadcache-function.md)  
 Clears the global assembly cache of downloaded assemblies.  
  
 [CompareAssemblyIdentity Function](compareassemblyidentity-function.md)  
 Compares two assembly identities to determine whether they are equivalent.  
  
 [CreateApplicationContext Function](createapplicationcontext-function.md)  
 Internal only. (This function supports the .NET Framework infrastructure and is not intended to be used directly from your code.)  
  
 [CreateAssemblyCache Function](createassemblycache-function.md)  
 Gets a pointer to a new [IAssemblyCache](iassemblycache-interface.md) instance that represents the global assembly cache.  
  
 [CreateAssemblyEnum Function](createassemblyenum-function.md)  
 Gets a pointer to an [IAssemblyEnum](iassemblyenum-interface.md) instance that represents a list of objects that exist in the specified assembly.  
  
 [CreateAssemblyNameObject Function](createassemblynameobject-function.md)  
 Gets a pointer to an [IAssemblyName](iassemblyname-interface.md) instance that represents the unique identity of the assembly with the specified name.  
  
 [CreateHistoryReader Function](createhistoryreader-function.md)  
 Creates a history reader for the specified file.  
  
 [CreateInstallReferenceEnum Function](createinstallreferenceenum-function.md)  
 Gets a pointer to an [IInstallReferenceEnum](iinstallreferenceenum-interface.md) instance that represents a list of an application's references to the specified assembly.  
  
 [GetAppIdAuthority Function](getappidauthority-function.md)  
 Gets a pointer to an [IAppIdAuthority](iappidauthority-interface.md) instance that manages keys for application identities and references.  
  
 [GetAssemblyIdentityFromFile Function](getassemblyidentityfromfile-function.md)  
 Gets a pointer to an `IUnknown` object with the specified `IID` in the assembly at the specified file path.  
  
 [GetCachePath Function](getcachepath-function.md)  
 Gets the path to the cached assembly, using the specified flags.  
  
 [GetHistoryFileDirectory Function](gethistoryfiledirectory-function.md)  
 Retrieves the path of the application history directory.  
  
 [GetIdentityAuthority Function](getidentityauthority-function.md)  
 Gets a pointer to an [IIdentityAuthority](iidentityauthority-interface.md) instance that manages keys for code objects.  
  
 [IsFrameworkAssembly Function](isframeworkassembly-function.md)  
 Gets a value that indicates whether the specified assembly is managed.  
  
 [NukeDownloadedCache Function](nukedownloadedcache-function.md)  
 Deletes the common language runtime download cache.  
  
 [PreBindAssemblyEx Function](prebindassemblyex-function.md)  
 Gets the post-policy display name for an assembly.  
  
## Related Sections  
 [Fusion Interfaces](fusion-interfaces.md)  
  
 [Fusion Enumerations](fusion-enumerations.md)  
  
 [Fusion Structures](fusion-structures.md)  
  
 [Global Assembly Cache](../../app-domains/gac.md)
