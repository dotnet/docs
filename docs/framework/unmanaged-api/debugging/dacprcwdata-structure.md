---
description: "Learn more about: DacpRCWData Structure"
title: "DacpRCWData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpRCWData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpRCWData Structure"
helpviewer.keywords:
  - "DacpRCWData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpRCWData Structure

Defines a transport buffer for runtime callable wrapper (RCW) information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpRCWData : ZeroInit<DacpRCWData>
{
    CLRDATA_ADDRESS identityPointer;
    CLRDATA_ADDRESS unknownPointer;
    CLRDATA_ADDRESS managedObject;
    CLRDATA_ADDRESS jupiterObject;
    CLRDATA_ADDRESS vtablePtr;
    CLRDATA_ADDRESS creatorThread;
    CLRDATA_ADDRESS ctxCookie;
    
    LONG refCount;
    LONG interfaceCount;

    BOOL isJupiterObject;
    BOOL supportsIInspectable;
    BOOL isAggregated;
    BOOL isContained;
    BOOL isFreeThreaded;
    BOOL isDisconnected;
    
    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS rcw)
    {
        return sos->GetRCWData(rcw, this);
    }

    HRESULT IsDCOMProxy(ISOSDacInterface *sos, CLRDATA_ADDRESS rcw, BOOL* isDCOMProxy)
    {
        ISOSDacInterface2 *pSOS2 = nullptr;
        HRESULT hr = sos->QueryInterface(__uuidof(ISOSDacInterface2), reinterpret_cast<LPVOID*>(&pSOS2));
        if (SUCCEEDED(hr))
        {
            hr = pSOS2->IsRCWDCOMProxy(rcw, isDCOMProxy);
            pSOS2->Release();
        }

        return hr;
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `identityPointer` | The address of the COM identity pointer. |
| `unknownPointer` | The address of the `IUnknown` pointer. |
| `managedObject` | The address of the managed object associated with the RCW. |
| `jupiterObject` | The address of the associated Jupiter object. |
| `vtablePtr` | The address of the vtable pointer. |
| `creatorThread` | The address of the thread that created the RCW. |
| `ctxCookie` | The context cookie for the RCW. |
| `refCount` | The reference count for the RCW. |
| `interfaceCount` | The number of interfaces associated with the RCW. |
| `isJupiterObject` | A value that indicates whether the RCW represents a Jupiter object. |
| `supportsIInspectable` | A value that indicates whether the RCW supports `IInspectable`. |
| `isAggregated` | A value that indicates whether the RCW is aggregated. |
| `isContained` | A value that indicates whether the RCW is contained. |
| `isFreeThreaded` | A value that indicates whether the RCW is free-threaded. |
| `isDisconnected` | A value that indicates whether the RCW is disconnected. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetRCWData`. |
| `IsDCOMProxy` | Determines whether the RCW is a DCOM proxy by using `ISOSDacInterface2::IsRCWDCOMProxy`, when that interface is available. |

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [Debugging Structures](debugging-structures.md)
