---
description: "Learn more about: ICorDebugVariableHome Interface"
title: "ICorDebugVariableHome Interface"
ms.date: "03/30/2017"
dev_langs:
  - "cpp"
api_name:
  - "ICorDebugVariableHome"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugVariableHome"
helpviewer_keywords:
  - "ICorDebugVariableHome interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugVariableHome Interface

Represents a local variable or argument of a function.

## Methods

|Method|Description|
|------------|-----------------|
|[GetArgumentIndex Method](icordebugvariablehome-getargumentindex-method.md)|Gets the index of a function argument.|
|[GetCode Method](icordebugvariablehome-getcode-method.md)|Gets the "ICorDebugCode" instance that contains this `ICorDebugVariableHome` object.|
|[GetLiveRange Method](icordebugvariablehome-getliverange-method.md)|Gets the native range over which this variable is live.|
|[GetLocationType Method](icordebugvariablehome-getlocationtype-method.md)|Gets the type of the variable's native location.|
|[GetOffset Method](icordebugvariablehome-getoffset-method.md)|Gets the offset from the base register for a variable.|
|[GetRegister Method](icordebugvariablehome-getregister-method.md)|Gets the register that contains a variable with a location type of `VLT_REGISTER`, and the base register for a variable with a location type of `VLT_REGISTER_RELATIVE`.|
|[GetSlotIndex Method](icordebugvariablehome-getslotindex-method.md)|Gets the managed slot-index of a local variable.|

## Example

The following code fragment uses the [ICorDebugCode4](icordebugcode4-interface.md) object named `pCode4`.

```cpp
ICorDebugCode4 *pCode4 = NULL;
pCode->QueryInterface(IID_ICorDebugCode4, &pCode4);

ICorDebugVariableEnum *pVarLocEnum = NULL;
pCode4->EnumerateVariableHomes(&pVarLocEnum);

// retrieve local variables and arguments
ULONG celt = 0;
pVarLocEnum->GetCount(&celt);
ICorDebugVariableHome **homes = new ICorDebugVariableHome *[celt];
ULONG celtFetched = 0;
pVarLocEnum->Next(celt, homes, &celtFetched);

for (int i = 0; i < celtFetched; i++)
{
    VariableLocationType locType = VLT_INVALID;
    homes[i].GetLocationType(&locType);
    switch (locType)
    {
    case VLT_REGISTER:
        CorDebugRegister register = 0;
        locals[i].GetRegister(&register);
        // now we know which register it is in
        break;
    case VLT_REGISTER_RELATIVE:
        CorDebugRegister baseRegister = 0;
        LONG offset = 0;
        locals[i].GetRegister(&register);
        locals[i].GetOffset(&offset);
        // now we know the register-relative offset
        break;
    case VLT_INVALID:
        // handle case where we can't access the location
        break;
    }
}
```

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6.2

## See also

- [ICorDebugVariableHomeEnum Interface](icordebugvariablehomeenum-interface.md)
