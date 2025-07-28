---
description: "Learn more about: IMetaDataDispenserEx::GetOption Method"
title: "IMetaDataDispenserEx::GetOption Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataDispenserEx.GetOption"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataDispenserEx::GetOption"
  - "IMetaDataDispenserEx::GetOption method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataDispenserEx::GetOption Method

Gets the value of the specified option for the current metadata scope. The option controls how calls to the current metadata scope are handled.

## Syntax

```cpp
HRESULT GetOption (
    [in]  REFGUID         optionId,
    [out] const VARIANT   *pValue
);
```

## Parameters

 `optionId`
 [in] A pointer to a GUID that specifies the option to be retrieved. See the Remarks section for a list of supported GUIDs.

 `pValue`
 [out] The value of the returned option. The type of this value will be a variant of the specified option's type.

## Remarks

 The following list shows the GUIDs that are supported for this method. For descriptions, see the [IMetaDataDispenserEx::SetOption](imetadatadispenserex-setoption-method.md) method. If `optionId` is not in this list, this method returns HRESULT `E_INVALIDARG`, indicating an incorrect parameter.

- MetaDataCheckDuplicatesFor

- MetaDataRefToDefCheck

- MetaDataNotificationForTokenMovement

- MetaDataSetENC

- MetaDataErrorIfEmitOutOfOrder

- MetaDataGenerateTCEAdapters

- MetaDataLinkerOptions

## Requirements

 **Platform:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataDispenserEx Interface](imetadatadispenserex-interface.md)
- [IMetaDataDispenser Interface](imetadatadispenser-interface.md)
