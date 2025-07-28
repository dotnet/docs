---
description: "Learn more about: IMetaDataEmit::DefineEvent Method"
title: "IMetaDataEmit::DefineEvent Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefineEvent"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefineEvent"
  - "DefineEvent method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefineEvent Method

Creates a definition for an event with the specified metadata signature, and gets a token to that event definition.

## Syntax

```cpp
HRESULT DefineEvent (
    [in]  mdTypeDef    td,
    [in]  LPCWSTR      szEvent,
    [in]  DWORD        dwEventFlags,
    [in]  mdToken      tkEventType,
    [in]  mdMethodDef  mdAddOn,
    [in]  mdMethodDef  mdRemoveOn,
    [in]  mdMethodDef  mdFire,
    [in]  mdMethodDef  rmdOtherMethods[],
    [out] mdEvent      *pmdEvent
);
```

## Parameters

 `td`
 [in] The token for the target class or interface. This is either a `mdTypeDef` or `mdTypeDefNil` token.

 `szEvent`
 [in] The name of the event.

 `dwEventFlags`
 [in] Event flags.

 `tkEventType`
 [in] The token for the event class. This is a `mdTypeDef`, a `mdTypeRef`, or a `mdTokenNil` token.

 `mdAddOn`
 [in] The method used to subscribe to the event, or null.

 `mdRemoveOn`
 [in] The method used to unsubscribe to the event, or null.

 `mdFire`
 [in] The method used (by a derived class) to raise the event.

 `rmdOtherMethods[]`
 [in] An array of tokens for other methods associated with the event. The array is terminated with a `mdMethodDefNil` token.

 `pmdEvent`
 [out] The metadata token assigned to the event.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
