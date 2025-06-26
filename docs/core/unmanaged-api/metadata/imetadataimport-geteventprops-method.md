---
description: "Learn more about: IMetaDataImport::GetEventProps Method"
title: "IMetaDataImport::GetEventProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetEventProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetEventProps"
helpviewer_keywords:
  - "IMetaDataImport::GetEventProps method [.NET Framework metadata]"
  - "GetEventProps method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetEventProps Method

Gets metadata information for the event represented by the specified event token, including the declaring type, the add and remove methods for delegates, and any flags and other associated data.

## Syntax

```cpp
HRESULT GetEventProps (
   [in]  mdEvent       ev,
   [out] mdTypeDef     *pClass,
   [out] LPCWSTR       szEvent,
   [in]  ULONG         cchEvent,
   [out] ULONG         *pchEvent,
   [out] DWORD         *pdwEventFlags,
   [out] mdToken       *ptkEventType,
   [out] mdMethodDef   *pmdAddOn,
   [out] mdMethodDef   *pmdRemoveOn,
   [out] mdMethodDef   *pmdFire,
   [out] mdMethodDef   rmdOtherMethod[],
   [in]  ULONG         cMax,
   [out] ULONG         *pcOtherMethod
);
```

## Parameters

 `ev`
 [in] The event metadata token representing the event to get metadata for.

 `pClass`
 [out] A pointer to the TypeDef token representing the class that declares the event.

 `szEvent`
 [out] The name of the event referenced by `ev`.

 `pchEvent`
 [in] The requested length in wide characters of `szEvent`.

 `pdwEventFlags`
 [out] The returned length in wide characters of `szEvent`.

 `ptkEventType`
 [out] A pointer to a TypeRef or TypeDef metadata token representing the <xref:System.Delegate> type of the event.

 `pmdAddOn`
 [out] A pointer to the metadata token representing the method that adds handlers for the event.

 `pmdRemoveOn`
 [out] A pointer to the metadata token representing the method that removes handlers for the event.

 `pmdFire`
 [out] A pointer to the metadata token representing the method that raises the event.

 `rmdOtherMethod`
 [out] An array of token pointers to other methods associated with the event.

 `cMax`
 [in] The maximum size of the `rmdOtherMethod` array.

 `pcOtherMethod`
 [out] The number of tokens returned in `rmdOtherMethod`.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
