---
title: System.Runtime.InteropServices.Marshal.GetActiveObject method
description: Learn about the System.Runtime.InteropServices.Marshal.GetActiveObject method.
ms.date: 01/24/2024
---
# System.Runtime.InteropServices.Marshal.GetActiveObject method

[!INCLUDE [context](includes/context.md)]

<xref:System.Runtime.InteropServices.Marshal.GetActiveObject%2A> exposes the COM [GetActiveObject](/windows/win32/api/oleauto/nf-oleauto-getactiveobject) function from OLEAUT32.DLL; however, the latter expects a class identifier (CLSID) instead of the programmatic identifier (`ProgID`) expected by this method. To obtain a running instance of a COM object without a registered `ProgID`, use platform invoke to define the COM [GetActiveObject](/windows/win32/api/oleauto/nf-oleauto-getactiveobject) function. For a description of platform invoke, see [Consuming Unmanaged DLL Functions](../../framework/interop/consuming-unmanaged-dll-functions.md).

## ProgID and CLSID

Keys in the HKEY_CLASSES_ROOT subtree of the registry contain a variety of subkey types. Most of the subkeys are ProgIDs, which map a user-friendly string to a CLSID. Applications often use these human-readable strings instead of the numeric CLSIDs. Often, a component has a version-independent ProgID that is mapped to the latest version of the component that is installed on the system.

Applications and components primarily use ProgIDs to retrieve their corresponding CLSIDs.
