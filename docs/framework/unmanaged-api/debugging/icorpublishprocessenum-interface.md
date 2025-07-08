---
description: "Learn more about: ICorPublishProcessEnum Interface"
title: "ICorPublishProcessEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorPublishProcessEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorPublishProcessEnum"
helpviewer_keywords:
  - "ICorPublishProcessEnum interface [.NET Framework debugging]"
ms.assetid: aac8fcf9-ac09-437c-bd5c-2fda14ae1007
topic_type:
  - "apiref"
---
# ICorPublishProcessEnum Interface

A subclass of the [ICorPublishEnum](icorpublishenum-interface.md) interface that provides methods to traverse a collection of [ICorPublishProcess](icorpublishprocess-interface.md) objects.

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icorpublishprocessenum-next-method.md)|Gets the specified number of `ICorPublishProcess` instances from the collection, starting at the current position.|

## Remarks

 The `ICorPublishProcessEnum` interface implements the methods of the abstract interface, [ICorPublishEnum](icorpublishenum-interface.md).

 An `ICorPublishProcessEnum` instance is created by the [ICorPublish::EnumProcesses](icorpublish-enumprocesses-method.md) method. The traversal of the collection of `ICorPublishProcess` objects is based on the filter criteria given at the time the `ICorPublishProcessEnum` instance was created.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorPub.idl, CorPub.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [CorpubPublish Coclass](corpubpublish-coclass.md)
