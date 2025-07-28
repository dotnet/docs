---
description: "Learn more about: IMetaDataEmit::SetClassLayout Method"
title: "IMetaDataEmit::SetClassLayout Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SetClassLayout"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SetClassLayout"
  - "SetClassLayout method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SetClassLayout Method

Completes the layout of fields for a class that has been defined by a prior call to [DefineTypeDef Method](imetadataemit-definetypedef-method.md).

## Syntax

```cpp
HRESULT SetClassLayout (
    [in]  mdTypeDef           td,
    [in]  DWORD               dwPackSize,
    [in]  COR_FIELD_OFFSET    rFieldOffsets[],
    [in]  ULONG               ulClassSize
);
```

## Parameters

 `td`
 [in] An `mdTypeDef` token that specifies the class to be laid out.

 `dwPackSize`
 [in] The packing size: 1, 2, 4, 8 or 16 bytes. The packing size is the number of bytes between adjacent fields.

 `rFieldOffsets`
 [in] An array of [COR_FIELD_OFFSET](../structures/cor-field-offset-structure.md) structures, each of which specifies a field of the class and the field's offset within the class. Terminate the array with `mdTokenNil`.

 `ulClassSize`
 [in] The size, in bytes, of the class.

## Remarks

 The class is initially defined by calling the [IMetaDataEmit::DefineTypeDef](imetadataemit-definetypedef-method.md) method, and specifying one of three layouts for the fields of the class: automatic, sequential, or explicit. Normally, you would use automatic layout and let the runtime choose the best way to lay out the fields.

 However, you might want the fields laid out according to the arrangement that unmanaged code uses. In this case, choose either sequential or explicit layout and call `SetClassLayout` to complete the layout of the fields:

- Sequential layout: Specify the packing size. A field is aligned according to either its natural size or the packing size, whichever results in the smaller offset of the field. Set `rFieldOffsets` and `ulClassSize` to zero.

- Explicit layout: Either specify the offset of each field or specify the class size and the packing size.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
