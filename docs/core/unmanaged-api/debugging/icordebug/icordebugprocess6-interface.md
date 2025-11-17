---
description: "Learn more about: ICorDebugProcess6 Interface"
title: "ICorDebugProcess6 Interface"
ms.date: "03/30/2017"
---
# ICorDebugProcess6 Interface

Logically extends the ICorDebugProcess interface to enable features such as decoding managed debug events that are encoded in native exception debug events and virtual module splitting.

## Methods

|Method|Description|
|------------|-----------------|
|[DecodeEvent Method](icordebugprocess6-decodeevent-method.md)|Decodes managed debug events that have been encapsulated in the payload of specially crafted native exception debug events.|
|[EnableVirtualModuleSplitting Method](icordebugprocess6-enablevirtualmodulesplitting-method.md)|Enables or disables virtual module splitting.|
|[GetCode Method](icordebugprocess6-getcode-method.md)|Gets information about the managed code at a particular code address.|
|[GetExportStepInfo Method](icordebugprocess6-getexportstepinfo-method.md)|Provides information on runtime exported functions to help step through managed code.|
|[MarkDebuggerAttached Method](icordebugprocess6-markdebuggerattached-method.md)|Changes the internal state of the debugee so that the <xref:System.Diagnostics.Debugger.IsAttached%2A?displayProperty=nameWithType> method returns `true`.|
|[ProcessStateChanged Method](icordebugprocess6-processstatechanged-method.md)|Notifies [ICorDebug](icordebug-interface.md) that the process is running.|

## Remarks

> [!NOTE]
> The interface is available with .NET Native only. Attempting to call `QueryInterface` to retrieve an interface pointer returns `E_NOINTERFACE` for ICorDebug scenarios outside of .NET Native.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6
