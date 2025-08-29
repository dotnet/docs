---
title: "Debugging Enumerations"
description: "Learn more about: Debugging Enumerations"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "debugging enumerations [.NET Framework]"
  - "unmanaged enumerations [.NET Framework], debugging"
  - "enumerations [.NET Framework debugging]"
---
# Debugging Enumerations

This section describes the unmanaged enumerations that the debugging API uses.

## In This Section

 [CLR_DEBUGGING_PROCESS_FLAGS Enumeration](clr-debugging-process-flags-enumeration.md)\
 Provides values that are used by the [ICLRDebugging::OpenVirtualProcess](iclrdebugging-openvirtualprocess-method.md) method.

 [CLRDataAddressType Enumeration](clrdataaddresstype-enumeration.md)\
 Indicates the type of data contained at a given address by the [IXCLRDataProcess::GetAddressType](ixclrdataprocess-getaddresstype-method.md).

 [CLRDataByNameFlag Enumeration](clrdatabynameflag-enumeration.md)\
 Indicates how names should match in a search.

 [CLRDataDetailedFrameType Enumeration](clrdatadetailedframetype-enumeration.md)\
 Describes a type of frame in the call stack in detail from the [IXCLRDataStackWalk::GetFrameType](ixclrdatastackwalk-getframetype-method.md) method.

 [CLRDataEnumMemoryFlags Enumeration](clrdataenummemoryflags-enumeration.md)\
 Indicates which memory regions a call to the [ICLRDataEnumMemoryRegions::EnumMemoryRegions](iclrdataenummemoryregions-enummemoryregions-method.md) method should include.

 [CLRDataExceptionSameFlag Enumeration](clrdataexceptionsameflag-enumeration.md)\
 Indicates how exception states should match against system records.

 [CLRDataFieldFlag Enumeration](clrdatafieldflag-enumeration.md)\
 Indicates various attributes of a field.

 [CLRDataFollowStubInFlag Enumeration](clrdatafollowstubinflag-enumeration.md)\
 A set of flags passed to [IXCLRDataProcess::FollowStub](ixclrdataprocess-followstub-method.md) and [IXCLRDataProcess::FollowStub2](ixclrdataprocess-followstub2-method.md) that define how to follow the stub.

 [CLRDataFollowStubOutFlag Enumeration](clrdatafollowstuboutflag-enumeration.md)\
 A set of flags returned from [IXCLRDataProcess::FollowStub](ixclrdataprocess-followstub-method.md) and [IXCLRDataProcess::FollowStub2](ixclrdataprocess-followstub2-method.md) that indicate the result of following a stub.

 [CLRDataMethodCodeNotification Enumeration](clrdatamethodcodenotification-enumeration.md)\
 Indicates the type of notifications pertaining to method instance code that should be delivered. Used in calls to [IXCLRDataProcess::SetCodeNotifications](ixclrdataprocess-setcodenotifications-method.md) and [IXCLRDataProcess::SetAllCodeNotifications Method](ixclrdataprocess-setallcodenotifications-method.md).

 [CLRDataModuleExtentType Enumeration](clrdatamoduleextenttype-enumeration.md)\
 Indicates the type of memory region associated with a module via [IXCLRDataModule::EnumExtent](ixclrdatamodule-enumextent-method.md).

 [CLRDataOtherNotifyFlag Enumeration](clrdataothernotifyflag-enumeration.md)\
 Indicates the type of notifications that should be delivered. Used in calls to [IXCLRDataProcess::SetOtherNotificationFlags Method](ixclrdataprocess-setothernotificationflags-method.md).

 [CLRDataSimpleFrameType Enumeration](clrdatasimpleframetype-enumeration.md)\
 Describes a type of frame in the call stack from [IXCLRDataStackWalk::GetFrameType](ixclrdatastackwalk-getframetype-method.md).

 [CLRDataSourceType Enumeration](clrdatasourcetype-enumeration.md)\
 Provides values that are used by the CLRDATA_IL_ADDRESS_MAP structure.

 [CLRDataValueFlag Enumeration](clrdatavalueflag-enumeration.md)\
 Indicates various attributes of a value.

## Related Sections

 [Debugging Coclasses](debugging-coclasses.md)

 [Debugging Interfaces](debugging-interfaces.md)

 [Debugging Global Static Functions](debugging-global-static-functions.md)

 [Debugging Structures](debugging-structures.md)
