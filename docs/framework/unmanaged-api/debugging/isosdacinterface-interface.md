---
description: "Learn more about: ISOSDacInterface Interface"
title: "ISOSDacInterface Interface"
ms.date: "02/01/2019"
api.name:
  - "ISOSDacInterface Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface Interface"
helpviewer.keywords:
  - "ISOSDacInterface Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
---
# ISOSDacInterface Interface

Provides helper methods to access data from `SOS`.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method | Description |
| ------ | ----------- |
| [GetAppDomainData](isosdacinterface-getappdomaindata-method.md) | Retrieves data for the application domain at the specified address. |
| [GetAppDomainList](isosdacinterface-getappdomainlist-method.md) | Retrieves the list of application domains in the runtime. |
| [GetAppDomainStoreData](isosdacinterface-getappdomainstoredata-method.md) | Retrieves data about the runtime application domain store. |
| [GetAssemblyData](isosdacinterface-getassemblydata-method.md) | Retrieves data for the assembly at the specified address. |
| [GetCCWData](isosdacinterface-getccwdata-method.md) | Retrieves COM callable wrapper (CCW) data for a COM wrapper address. |
| [GetCCWInterfaces](isosdacinterface-getccwinterfaces-method.md) | Retrieves COM interface pointer data for a COM callable wrapper (CCW). |
| [GetCodeHeaderData](isosdacinterface-getcodeheaderdata-method.md) | Retrieves code header data for the JIT-compiled method that contains the specified instruction pointer. |
| [GetCodeHeapList](isosdacinterface-getcodeheaplist-method.md) | Retrieves the list of code heaps for the specified JIT manager. |
| [GetDomainLocalModuleData](isosdacinterface-getdomainlocalmoduledata-method.md) | Retrieves data for the domain-local module at the specified address. |
| [GetDomainLocalModuleDataFromAppDomain](isosdacinterface-getdomainlocalmoduledatafromappdomain-method.md) | Retrieves domain-local module data for the specified application domain and module identifier. |
| [GetDomainLocalModuleDataFromModule](isosdacinterface-getdomainlocalmoduledatafrommodule-method.md) | Retrieves domain-local module data for the specified module. |
| [GetFieldDescData](isosdacinterface-getfielddescdata-method.md) | Gets data for a FieldDesc address. |
| [GetGCHeapData](isosdacinterface-getgcheapdata-method.md) | Retrieves general information about the garbage-collected heap. |
| [GetGCHeapDetails](isosdacinterface-getgcheapdetails-method.md) | Retrieves detailed information for the specified garbage collection heap. |
| [GetGCHeapList](isosdacinterface-getgcheaplist-method.md) | Retrieves the list of server garbage collection heap addresses. |
| [GetGCHeapStaticData](isosdacinterface-getgcheapstaticdata-method.md) | Retrieves static garbage collection heap details. |
| [GetHandleEnum](isosdacinterface-gethandleenum-method.md) | Retrieves an enumerator for runtime handles. |
| [GetHandleEnumForTypes](isosdacinterface-gethandleenumfortypes-method.md) | Retrieves an enumerator for runtime handles whose types match the specified type values. |
| [GetHeapAnalyzeData](isosdacinterface-getheapanalyzedata-method.md) | Retrieves heap analysis data for the specified garbage collection heap. |
| [GetHeapAnalyzeStaticData](isosdacinterface-getheapanalyzestaticdata-method.md) | Retrieves static heap analysis data for the garbage collector. |
| [GetHeapSegmentData](isosdacinterface-getheapsegmentdata-method.md) | Retrieves information for the specified garbage collection heap segment. |
| [GetILForModule](isosdacinterface-getilformodule-method.md) | Gets the intermediate language (IL) address that corresponds to a relative virtual address in a module. |
| [GetJitManagerList](isosdacinterface-getjitmanagerlist-method.md) | Retrieves the list of JIT managers known to the runtime. |
| [GetMethodDescData](isosdacinterface-getmethoddescdata-method.md) | Gets the data for the given MethodDesc pointer. |
| [GetMethodDescFromToken](isosdacinterface-getmethoddescfromtoken-method.md) | Gets a MethodDesc address for a metadata token in a module. |
| [GetMethodDescName](isosdacinterface-getmethoddescname-method.md) | Gets the name that corresponds to a MethodDesc address. |
| [GetMethodDescPtrFromFrame](isosdacinterface-getmethoddescptrfromframe-method.md) | Gets the MethodDesc pointer that corresponds to a frame address. |
| [GetMethodDescPtrFromIP](isosdacinterface-getmethoddescptrfromip-method.md) | Retrieves the pointer of the MethodDesc corresponding the method containing the given native instruction address. |
| [GetMethodTableData](isosdacinterface-getmethodtabledata-method.md) | Gets data for a method table. |
| [GetMethodTableFieldData](isosdacinterface-getmethodtablefielddata-method.md) | Gets field data for a method table. |
| [GetMethodTableForEEClass](isosdacinterface-getmethodtableforeeclass-method.md) | Gets the method table address that corresponds to an EEClass address. |
| [GetMethodTableSlot](isosdacinterface-getmethodtableslot-method.md) | Gets the value of a slot in a method table. |
| [GetModule](isosdacinterface-getmodule-method.md) | Gets an `IXCLRDataModule` interface for a module address. |
| [GetModuleData](isosdacinterface-getmoduledata-method.md) | Fetches the data corresponding to the module loaded at a given address. |
| [GetObjectData](isosdacinterface-getobjectdata-method.md) | Retrieves data for the object at the specified address. |
| [GetOOMData](isosdacinterface-getoomdata-method.md) | Retrieves out-of-memory data for the specified garbage collection heap. |
| [GetOOMStaticData](isosdacinterface-getoomstaticdata-method.md) | Retrieves static out-of-memory data for the garbage collector. |
| [GetRCWData](isosdacinterface-getrcwdata-method.md) | Retrieves runtime callable wrapper (RCW) data for a COM wrapper address. |
| [GetRCWInterfaces](isosdacinterface-getrcwinterfaces-method.md) | Retrieves COM interface pointer data for a runtime callable wrapper (RCW). |
| [GetRegisterName](isosdacinterface-getregistername-method.md) | Retrieves the display name for a runtime register identifier. |
| [GetStackReferences](isosdacinterface-getstackreferences-method.md) | Retrieves an enumerator for references on a thread call stack. |
| [GetStressLogAddress](isosdacinterface-getstresslogaddress-method.md) | Retrieves the address of the runtime stress log. |
| [GetSyncBlockCleanupData](isosdacinterface-getsyncblockcleanupdata-method.md) | Retrieves cleanup data for the sync block at the specified address. |
| [GetSyncBlockData](isosdacinterface-getsyncblockdata-method.md) | Retrieves data for the sync block with the specified number. |
| [GetThreadData](isosdacinterface-getthreaddata-method.md) | Retrieves data for the managed thread at the specified address. |
| [GetThreadFromThinlockID](isosdacinterface-getthreadfromthinlockid-method.md) | Retrieves the managed thread address that corresponds to a thin-lock identifier. |
| [GetThreadLocalModuleData](isosdacinterface-getthreadlocalmoduledata-method.md) | Retrieves thread-local module data for the specified thread and module index. |
| [GetThreadpoolData](isosdacinterface-getthreadpooldata-method.md) | Retrieves data for the runtime thread pool. |
| [GetThreadStoreData](isosdacinterface-getthreadstoredata-method.md) | Retrieves data about the runtime thread store. |
| [GetTLSIndex](isosdacinterface-gettlsindex-method.md) | Retrieves the thread-local storage index used by the runtime. |
| [GetUsefulGlobals](isosdacinterface-getusefulglobals-method.md) | Retrieves global runtime addresses that are commonly useful to diagnostic tools. |
| [GetWorkRequestData](isosdacinterface-getworkrequestdata-method.md) | Retrieves data for the work request at the specified address. |
| [TraverseLoaderHeap](isosdacinterface-traverseloaderheap-method.md) | Enumerates blocks in the specified loader heap. |
| [TraverseModuleMap](isosdacinterface-traversemodulemap-method.md) | Traverses a module map and invokes a callback for each entry. |
| [TraverseRCWCleanupList](isosdacinterface-traversercwcleanuplist-method.md) | Traverses the runtime callable wrapper (RCW) cleanup list and calls a visitor callback for each entry. |
| [TraverseVirtCallStubHeap](isosdacinterface-traversevirtcallstubheap-method.md) | Enumerates blocks in a virtual call stub heap for the specified application domain. |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `436f00f2-b42a-4b9f-870c-e73db66ae930` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
