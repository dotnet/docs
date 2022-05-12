---
title: "Breaking change: Casting RCW to InterfaceIsIInspectable throws exception"
description: Learn about the interop breaking change in .NET 5 where casting an RCW to an InterfaceIsIInspectable interface throws a PlatformNotSupportedException.
ms.date: 09/13/2020
---
# Casting RCW to an `InterfaceIsIInspectable` interface throws PlatformNotSupportedException

Casting a runtime callable wrapper (RCW) to an interface marked as <xref:System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIInspectable> now throws a <xref:System.PlatformNotSupportedException>. This change is a follow up to the [removal of WinRT support from .NET](built-in-support-for-winrt-removed.md).

## Version introduced

.NET 5

## Change description

In previous .NET versions, casting an RCW to an interface marked as <xref:System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIInspectable> worked as expected. Starting in .NET 5, casting an RCW to an interface marked as <xref:System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIInspectable> throws a <xref:System.PlatformNotSupportedException> at cast time.

## Reason for change

The support for <xref:System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIInspectable> was [removed](built-in-support-for-winrt-removed.md). Since the underlying support in the runtime no longer exists, throwing a <xref:System.PlatformNotSupportedException> enables a graceful failure path. Throwing an exception also makes it more discoverable that this feature is no longer supported.

## Recommended action

- If you can define the interface in a Windows runtime metadata (WinMD) file, use the C#/WinRT tool instead.

- Otherwise, mark the interface as <xref:System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIUnknown> instead of <xref:System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIInspectable>, and add three dummy entries to the start of the interface for the <xref:System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIInspectable> methods. The following code snippet shows an example.

  ```csharp
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  interface IMine
  {
      // Do not call these three methods.
      // They're exclusively to fill in the slots in the vtable.
      void GetIIdsSlot();
      void GetRuntimeClassNameSlot();
      void GetTrustLevelSlot();

      // The original members of the IMine interface go here.
      ...
  }
  ```

## Affected APIs

- <xref:System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIInspectable?displayProperty=fullName>
