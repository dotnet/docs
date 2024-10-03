---
description: "Learn more about: ICorPublishAppDomainEnum Interface"
title: "ICorPublishAppDomainEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorPublishAppDomainEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorPublishAppDomainEnum"
helpviewer_keywords:
  - "ICorPublishAppDomainEnum interface [.NET Framework debugging]"
ms.assetid: bb798c56-042e-475d-a245-b6fac36d0c07
topic_type:
  - "apiref"
---
# ICorPublishAppDomainEnum Interface

A subclass of the [ICorPublishEnum](icorpublishenum-interface.md) interface that provides methods to traverse a collection of [ICorPublishAppDomain](icorpublishappdomain-interface.md) objects that currently exist within a process.

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icorpublishappdomainenum-next-method.md)|Gets the specified number of `ICorPublishAppDomain` instances from the collection, starting at the current position.|

## Remarks

 The `ICorPublishAppDomainEnum` interface implements the methods of the abstract interface, [ICorPublishEnum](icorpublishenum-interface.md).

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorPub.idl, CorPub.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [CorpubPublish Coclass](corpubpublish-coclass.md)
