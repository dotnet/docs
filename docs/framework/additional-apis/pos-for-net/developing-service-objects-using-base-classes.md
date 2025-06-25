---
title: Developing Service Objects Using Base Classes
description: Developing Service Objects Using Base Classes (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Developing Service Objects Using Base Classes (POS for .NET v1.14 SDK Documentation)

The Unified Point of Service (UnifiedPOS) v1.14 specification defines 36 UnifiedPOS device types. Microsoft Point of Service for .NET (POS for .NET) provides **Base** class for nine of those. This section builds on the basics covered in the [Service Object Samples: Getting Started](service-object-samples-getting-started.md) and provides additional information specific to each device type.

## In This Section

- [Scanner Implementation](scanner-implementation.md)
    Provides additional details about developing a **ScannerDrawer** Service Object.

- [CashDrawer Implementation](cashdrawer-implementation.md)
    Provides additional details about developing a **CashDrawer** Service Object.

- [LineDisplay Implementation](linedisplay-implementation.md)
    Provides additional details about developing a **LineDisplay** Service Object.

- [PinPad Implementation](pinpad-implementation.md)
    Provides additional details about developing a **PinPad** Service Object.

- [PosKeyboard Implementation](poskeyboard-implementation.md)
    Provides additional details about developing a **PosKeyboard** Service Object.

- [Using Impl Methods for Synchronous or Asynchronous Output](using-impl-methods-for-synchronous-or-asynchronous-output.md)
    Describes how these special helper methods allow for a single implementation of an output method that supports both synchronous and asynchronous operations.

## Related Sections

- [Service Object Samples: Getting Started](service-object-samples-getting-started.md)
    Provides a step-by-step guide to creating a functional, multithreaded Service Object.

- [Developing a Custom Service Object](developing-a-custom-service-object.md)
    Discusses the procedures, issues, and conventions for developing a custom Service Object.
