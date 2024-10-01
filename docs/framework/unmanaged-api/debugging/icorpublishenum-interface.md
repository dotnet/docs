---
description: "Learn more about: ICorPublishEnum Interface"
title: "ICorPublishEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorPublishEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorPublishEnum"
helpviewer_keywords:
  - "ICorPublishEnum interface [.NET Framework debugging]"
ms.assetid: 76a136b5-e444-417a-8ade-f1596d597dc7
topic_type:
  - "apiref"
---
# ICorPublishEnum Interface

Serves as the abstract base interface for the enumerators that are used in the publishing of information about processes and application domains.

## Methods

|Method|Description|
|------------|-----------------|
|[Clone Method](icorpublishenum-clone-method.md)|Creates a copy of this `ICorPublishEnum` object.|
|[GetCount Method](icorpublishenum-getcount-method.md)|Gets the number of items in the enumeration.|
|[Reset Method](icorpublishenum-reset-method.md)|Moves the cursor of to the beginning of the enumeration.|
|[Skip Method](icorpublishenum-skip-method.md)|Moves the cursor forward in the enumeration by the specified number of items.|

## Remarks

 The following enumerators derive from `ICorPublishEnum`:

- [ICorPublishAppDomainEnum](icorpublishappdomainenum-interface.md)

- [ICorPublishProcessEnum](icorpublishprocessenum-interface.md)

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorPub.idl, CorPub.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [CorpubPublish Coclass](corpubpublish-coclass.md)
- [Debugging Interfaces](debugging-interfaces.md)
