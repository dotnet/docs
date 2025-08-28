---
description: "Learn more about: ICorDebugMergedAssemblyRecord Interface"
title: "ICorDebugMergedAssemblyRecord Interface"
ms.date: "03/30/2017"
---
# ICorDebugMergedAssemblyRecord Interface

Provides information about a merged assembly.

## Methods

|Method|Description|
|------------|-----------------|
|[GetCulture Method](icordebugmergedassemblyrecord-getculture-method.md)|Gets the culture name string of the assembly.|
|[GetIndex Method](icordebugmergedassemblyrecord-getindex-method.md)|Gets the assembly's prefix index.|
|[GetPublicKey Method](icordebugmergedassemblyrecord-getpublickey-method.md)|Gets the assembly's public key.|
|[GetPublicKeyToken Method](icordebugmergedassemblyrecord-getpublickeytoken-method.md)|Gets the assembly's public key token.|
|[GetSimpleName Method](icordebugmergedassemblyrecord-getsimplename-method.md)|Gets the simple name of the assembly.|
|[GetVersion Method](icordebugmergedassemblyrecord-getversion-method.md)|Gets the assembly's version information.|

## Remarks

> [!NOTE]
> This interface is available with .NET Native only. If you implement this interface for ICorDebug scenarios outside of .NET Native, the common language runtime will ignore this interface.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6
