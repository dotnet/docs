---
description: "Learn more about: IManagedObject::GetObjectIdentity Method"
title: "IManagedObject::GetObjectIdentity Method"
ms.date: "03/30/2017"
api_name:
  - "IManagedObject.GetObjectIdentity"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "GetObjectIdentity"
helpviewer_keywords:
  - "GetObjectIdentity method [.NET Framework hosting]"
  - "IManagedObject::GetObjectIdentity method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IManagedObject::GetObjectIdentity Method

Gets the identity of this managed object.

## Syntax

```cpp
HRESULT GetObjectIdentity (
    [out] BSTR*   pBSTRGUID,
    [out] int*    AppDomainID,
    [out] CCW_PTR pCCW
);
```

## Parameters

 `pBSTRGUID`
 [out] A pointer to the GUID of the process in which the object resides.

 `AppDomainID`
 [out] A pointer to the ID of the object's application domain.

 `pCCW`
 [out] A pointer to object's index in the COM classic v-table.

## Remarks

 The identity of a managed object includes process GUID, application domain ID, and the object's index in the COM classic v-table.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IManagedObject Interface](imanagedobject-interface.md)
