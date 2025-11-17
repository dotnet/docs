---
description: "Learn more about: Debugging Interfaces"
title: "Debugging Interfaces"
ms.date: "02/07/2019"
helpviewer_keywords:
  - "unmanaged interfaces [.NET Framework], debugging"
  - "debugging interfaces [.NET Framework]"
  - "interfaces [.NET Framework debugging]"
ms.assetid: b6297c26-7624-4431-8af4-14112d07bcd5
---
# Debugging Interfaces

This section describes the unmanaged interfaces that handle the debugging of a program that is executing in the common language runtime (CLR).

## In This Section

 [ICLRDataEnumMemoryRegions Interface](iclrdataenummemoryregions-interface.md)\
 Provides a method to enumerate regions of memory that are specified by callers.

 [ICLRDataEnumMemoryRegionsCallback Interface](iclrdataenummemoryregionscallback-interface.md)\
 Provides a callback method for `EnumMemoryRegions` to report to the debugger, the result of an attempt to enumerate a specified region of memory.

 [ICLRDataTarget Interface](iclrdatatarget-interface.md)\
 Provides methods for interaction with a target CLR process.

 [ICLRDataTarget2 Interface](iclrdatatarget2-interface.md)\
 A subclass of `ICLRDataTarget` that is used by the data access services layer to manipulate virtual memory regions in the target process.

 [ICLRDataTarget3 Interface](iclrdatatarget3-interface.md)\
 A subclass of [ICLRDataTarget2](iclrdatatarget2-interface.md) that provides access to exception information.

 [ICLRDebugging Interface](iclrdebugging-interface.md)\
 Provides methods that handle loading and unloading modules for debugging.

 [ICLRDebuggingLibraryProvider Interface](iclrdebugginglibraryprovider-interface.md)\
 Includes the [ProvideLibrary Method](iclrdebugginglibraryprovider-providelibrary-method.md) method, which gets a library provider callback interface that allows common language runtime version-specific debugging libraries to be located and loaded on demand.

 [ICLRMetadataLocator Interface](iclrmetadatalocator-interface.md)\
 Interface used by the data access services layer to locate metadata of assemblies in a target process.

 [ICorPublish Interface](icorpublish-interface.md)\
 Serves as the general interface for the publishing processes.

 [ICorPublishAppDomain Interface](icorpublishappdomain-interface.md)\
 Represents and provides information about an application domain.

 [ICorPublishAppDomainEnum Interface](icorpublishappdomainenum-interface.md)\
 Provides methods that traverse a collection of `ICorPublishAppDomain` objects that currently exist within a process.

 [ICorPublishEnum Interface](icorpublishenum-interface.md)\
 Serves as the abstract base for publishing enumerators.

 [ICorPublishProcess Interface](icorpublishprocess-interface.md)\
 Provides methods that access information about a process.

 [ICorPublishProcessEnum Interface](icorpublishprocessenum-interface.md)\
 Provides methods that traverse a collection of `ICorPublishProcess` objects.

 [ISOSDacInterface Interface](isosdacinterface-interface.md)\
 Provides helper methods to access data from `SOS`.

 [IXCLRDataAppDomain Interface](ixclrdataappdomain-interface.md)\
 Provides methods for querying information about an AppDomain.

 [IXCLRDataExceptionNotification Interface](ixclrdataexceptionnotification-interface.md)\
 Provides a set of callbacks to notify a caller about managed events.

 [IXCLRDataExceptionNotification2 Interface](ixclrdataexceptionnotification2-interface.md)\
 Provides a set of callbacks to notify a caller about managed events.

 [IXCLRDataExceptionNotification3 Interface](ixclrdataexceptionnotification3-interface.md)\
 Provides a set of callbacks to notify a caller about managed events.

 [IXCLRDataExceptionNotification4 Interface](ixclrdataexceptionnotification4-interface.md)\
 Provides a set of callbacks to notify a caller about managed events.

 [IXCLRDataExceptionNotification5 Interface](ixclrdataexceptionnotification5-interface.md)\
 Provides a set of callbacks to notify a caller about managed events.

 [IXCLRDataExceptionState Interface](ixclrdataexceptionstate-interface.md)\
 Provides methods for querying information about a managed exception.

 [IXCLRDataFrame Interface](ixclrdataframe-interface.md)\
 Provides methods for querying information about a stack frame

 [IXCLRDataMethodDefinition Interface](ixclrdatamethoddefinition-interface.md)\
 Provides methods for querying information about a method definition.

 [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)\
 Provides methods for querying information about a method instance.

 [IXCLRDataModule Interface](ixclrdatamodule-interface.md)\
 Provides methods for querying information about a loaded module.

 [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)\
 Provides methods for querying information about a process.

 [IXCLRDataStackWalk Interface](ixclrdatastackwalk-interface.md)\
 Provides methods for walking the stack.

 [IXCLRDataTask Interface](ixclrdatatask-interface.md)\
 Provides methods for querying information about a managed task.

 [IXCLRDataTypeDefinition Interface](ixclrdatatypedefinition-interface.md)\
 Provides methods for querying information about a type definition.

 [IXCLRDataTypeInstance Interface](ixclrdatatypeinstance-interface.md)\
 Provides methods for querying information about a type instance.

 [IXCLRDataValue Interface](ixclrdatavalue-interface.md)\
 Provides methods for querying information about a managed value.

## Related Sections

 [Debugging Coclasses](debugging-coclasses.md)\
 [Debugging Global Static Functions](debugging-global-static-functions.md)\
 [Debugging Enumerations](debugging-enumerations.md)\
 [Debugging Structures](debugging-structures.md)\
