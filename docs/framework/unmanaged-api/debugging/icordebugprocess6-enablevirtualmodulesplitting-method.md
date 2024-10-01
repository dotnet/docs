---
description: "Learn more about: ICorDebugProcess6::EnableVirtualModuleSplitting Method"
title: "ICorDebugProcess6::EnableVirtualModuleSplitting Method"
ms.date: "03/30/2017"
ms.assetid: e7733bd3-68da-47f9-82ef-477db5f2e32d
---
# ICorDebugProcess6::EnableVirtualModuleSplitting Method

Enables or disables virtual module splitting.

## Syntax

```cpp
HRESULT EnableVirtualModuleSplitting(
   BOOL enableSplitting
);
```

## Parameters

 `enableSplitting`
 `true` to enable virtual module splitting; `false` to disable it.

## Remarks

 Virtual module splitting causes [ICorDebug](icordebug-interface.md) to recognize modules that were merged together during the build process and present them as a group of separate modules rather than a single large module. Doing this changes the behavior of various [ICorDebug](icordebug-interface.md) methods described below.

> [!NOTE]
> This method is available with .NET Native only.

 This method can be called and the value of `enableSplitting` can be changed at any time. It does not cause any stateful functional changes in an [ICorDebug](icordebug-interface.md) object, other than altering the behavior of the methods listed in the [Virtual module splitting and the unmanaged debugging APIs](#APIs) section at the time they are called. Using virtual modules does incur a performance penalty when calling those methods. In addition, significant in-memory caching of the virtualized metadata may be required to correctly implement the [IMetaDataImport](../metadata/imetadataimport-interface.md) APIs, and these caches may be retained even after virtual module splitting has been turned off.

## Terminology

 The following terms are used when describing virtual module splitting:

 container modules, or containers
 The aggregate modules.

 sub-modules, or virtual modules
 The modules found in a container.

 regular modules
 Modules that were not merged at build time. They are neither container modules nor sub-modules.

 Both container modules and sub-modules are represented by ICorDebugModule interface objects. However, the behavior of the interface is slightly different in each case, as the \<x-ref to section> section describes.

## Modules and assemblies

 Multi-module assemblies are not supported for assembly merging scenarios, so there is a one-to-one relationship between a module and an assembly. Each ICorDebugModule object, regardless of whether it represents a container module or a sub-module, has a corresponding ICorDebugAssembly object. The [ICorDebugModule::GetAssembly](icordebugmodule-getassembly-method.md) method converts from the module to the assembly. To map in the other direction, the [ICorDebugAssembly::EnumerateModules](icordebugassembly-enumeratemodules-method.md) method enumerates only 1 module. Because assembly and module form a tightly coupled pair in this case, the terms assembly and module become largely interchangeable.

## Behavioral differences

 Container modules have the following behaviors and characteristics:

- Their metadata for all of the constituent sub-modules is merged together.

- Their type names may be mangled.

- The [ICorDebugModule::GetName](icordebugmodule-getname-method.md) method returns the path to an on-disk module.

- The [ICorDebugModule::GetSize](icordebugmodule-getsize-method.md) method returns the size of that image.

- The ICorDebugAssembly3.EnumerateContainedAssemblies method lists the sub-modules.

- The ICorDebugAssembly3.GetContainerAssembly method returns `S_FALSE`.

 Sub-modules have the following behaviors and characteristics:

- They have a reduced set of metadata that corresponds only to the original assembly that was merged.

- The metadata names are not mangled.

- Metadata tokens are unlikely to match the tokens in the original assembly before it was merged in the build process.

- The [ICorDebugModule::GetName](icordebugmodule-getname-method.md) method returns the assembly name, not a file path.

- The [ICorDebugModule::GetSize](icordebugmodule-getsize-method.md) method returns the original unmerged image size.

- The ICorDebugModule3.EnumerateContainedAssemblies method returns `S_FALSE`.

- The ICorDebugAssembly3.GetContainerAssembly method returns the containing module.

## Interfaces retrieved from modules

 A variety of interfaces can be created or retrieved from modules. Some of these include:

- An ICorDebugClass object, which is returned by the [ICorDebugModule::GetClassFromToken](icordebugmodule-getclassfromtoken-method.md) method.

- An ICorDebugAssembly object, which is returned by the [ICorDebugModule::GetAssembly](icordebugmodule-getassembly-method.md) method.

 These objects are always cached by [ICorDebug](icordebug-interface.md), and they will have the same pointer identity regardless of whether they were created or queried from the container module or a sub-module. The sub-module provides a filtered view of these cached objects, not a separate cache with its own copies.

<a name="APIs"></a>

## Virtual module splitting and the unmanaged debugging APIs

 The following table shows how virtual module splitting affects the behavior of other methods in the unmanaged debugging API.

|Method|`enableSplitting` = `true`|`enableSplitting` = `false`|
|------------|---------------------------------|----------------------------------|
|[ICorDebugFunction::GetModule](icordebugfunction-getmodule-method.md)|Returns the sub-module this function was originally defined in|Returns the container module this function was merged into|
|[ICorDebugClass::GetModule](icordebugclass-getmodule-method.md)|Returns the sub-module this class was originally defined in.|Returns the container module this class was merged into.|
|ICorDebugModuleDebugEvent::GetModule|Returns the container module that was loaded. Sub-modules are not given load events regardless of this setting.|Returns the container module that was loaded.|
|[ICorDebugAppDomain::EnumerateAssemblies](icordebugappdomain-enumerateassemblies-method.md)|Returns a list of sub-assemblies and regular assemblies; no container assemblies are included. **Note:**  If any container assembly is missing symbols, none of its sub-assemblies will be enumerated. If any regular assembly is missing symbols, it may or may not be enumerated.|Returns a list of container assemblies and regular assemblies; no sub-assemblies are included. **Note:**  If any regular assembly is missing symbols, it may or may not be enumerated.|
|[ICorDebugCode::GetCode](icordebugcode-getcode-method.md) (when referring to IL code only)|Returns IL that would be valid in a pre-merge assembly image. Specifically, any inline metadata tokens will correctly be TypeRef or MemberRef tokens when the types being referred to are not defined in the virtual module containing the IL. These TypeRef or MemberRef tokens can be looked up in the [IMetaDataImport](../metadata/imetadataimport-interface.md) object for the corresponding virtual ICorDebugModule object.|Returns the IL in the post-merge assembly image.|

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]

## See also

- [ICorDebugProcess6 Interface](icordebugprocess6-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
