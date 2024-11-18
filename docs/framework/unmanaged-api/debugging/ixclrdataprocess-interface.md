---
description: "Learn more about: IXCLRDataProcess Interface"
title: "IXCLRDataProcess Interface"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataProcess Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess Interface"
helpviewer.keywords:
  - "IXCLRDataProcess Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess Interface

Provides methods for querying information about a process.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                                               | Description                                                                                     |
| ---------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| [GetRuntimeNameByAddress](ixclrdataprocess-getruntimenamebyaddress-method.md)                     | Gets a name for the given address.                                                               |
| [GetAppDomainByUniqueId](ixclrdataprocess-getappdomainbyuniqueid-method.md)                       | Gets an `AppDomain` in a process by its unique id.                                              |
| [StartEnumModules](ixclrdataprocess-startenummodules-method.md)                                   | Provides a handle to enumerate the modules of a process.                                        |
| [EnumModule](ixclrdataprocess-enummodule-method.md)                                               | Enumerates the modules of this process.                                                         |
| [EndEnumModules](ixclrdataprocess-endenummodules-method.md)                                       | Releases the resources used by internal iterators used during module enumeration.               |
| [StartEnumMethodInstancesByAddress](ixclrdataprocess-startenummethodinstancesbyaddress-method.md) | Provides a handle to enumerate the method instances of `AppDomain` starting at a given address. |
| [EnumMethodInstanceByAddress](ixclrdataprocess-enummethodinstancebyaddress-method.md)             | Enumerates the method instances of this process starting at an address offset.                  |
| [EndEnumMethodInstancesByAddress](ixclrdataprocess-endenummethodinstancesbyaddress-method.md)     | Releases the resources used by internal iterators used during instance enumeration.             |
| [GetTaskByOSThreadID](ixclrdataprocess-gettaskbyosthreadid-method.md)                             | Gets a managed task by its OS thread ID. |
| [GetTaskByUniqueID](ixclrdataprocess-gettaskbyuniqueid-method.md)                                 | Gets a managed task by its unique ID. |
| [GetModuleByAddress](ixclrdataprocess-getmodulebyaddress-method.md)                               | Looks up a managed module by address. |
| [StartEnumMethodDefinitionsByAddress](ixclrdataprocess-startenummethoddefinitionsbyaddress-method.md) | Provides a handle to enumerate method instances by IL code address. |
| [EnumMethodDefinitionByAddress](ixclrdataprocess-enummethoddefinitionbyaddress-method.md)         | Enumerates method instances by IL code address. |
| [EndEnumMethodDefinitionsByAddress](ixclrdataprocess-endenummethoddefinitionsbyaddress-method.md) | Releases the resources used by internal iterators used during instance enumeration. |
| [FollowStub](ixclrdataprocess-followstub-method.md)                                               | Given an address which is a CLR stub (and potentially state from a previous follow) determine the next execution address at which to check whether the stub has been exited. |
| [FollowStub2](ixclrdataprocess-followstub2-method.md)                                             | Given an address which is a CLR stub (and potentially state from a previous follow) determine the next execution address at which to check whether the stub has been exited. |
| [TranslateExceptionRecordToNotification](ixclrdataprocess-translateexceptionrecordtonotification-method.md) | Translates a system exception record into a particular kind of notification if possible. |
| [GetAddressType](ixclrdataprocess-getaddresstype-method.md)                                       | Returns an indication of the type of data referred to by the given address. |
| [SetCodeNotifications](ixclrdataprocess-setcodenotifications-method.md)                           | Requests notifications when code is generated or discarded for a method. |
| [SetAllCodeNotifications](ixclrdataprocess-setallcodenotifications-method.md)                     | Requests notifications when code is generated or discarded for any method instance in a given `IXCLRDataModule`. |
| [Request](ixclrdataprocess-request-method.md)                                                     | Requests to populate the buffer given with the process's data. |
| [SetOtherNotificationFlags](ixclrdataprocess-setothernotificationflags-method.md)                 | Requests notifications when specific events are raised by the CLR. |
| [StartEnumAppDomains](ixclrdataprocess-startenumappdomains-method.md)                             | Provides a handle to enumerate AppDomains in the process. |
| [EnumAppDomain](ixclrdataprocess-enumappdomain-method.md)                                         | Enumerates AppDomains in the process. |
| [EndEnumAppDomains](ixclrdataprocess-endenumappdomains-method.md)                                 | Releases the resources used by internal iterators used during AppDomain enumeration. |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `5c552ab6-fc09-4cb3-8e36-22fa03c798b7` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
