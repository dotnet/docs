---
title: POS for .NET Class Tree
description: POS for .NET Class Tree (POS for .NET v1.14 SDK Documentation)
ms.date: 02/27/2008
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# POS for .NET Class Tree (POS for .NET v1.14 SDK Documentation)

The POS for .NET SDK contains a set of classes which provide the Service Object with much of the functionality needed to meet the UPOS specification. There are three levels of base classes, referred to as **Interface**, **Basic**, and **Base** classes.

At the base of the class tree is [PosCommon Class](poscommon-class.md)**. Interface** classes are derived from **PosCommon**, **Basic** classes are derived from **Interface** classes, and **Base** classes are derived from **Basic** classes. For each POS device type, there are separate **Interface**, **Basic**, and **Base** classes.

The POS for .NET base classes follow a specific naming convention. **Interface** classes are represented by just the short name of the device type (for example, **Scanner** or **Msr**). **Basic** classes append the suffix **Basic** after the name used for the **Interface** class (for example, **MsrBasic** or **ScannerBasic**). And finally, **Base** classes use the suffix **Base** (for example, **MsrBase** or **ScannerBase**). For the complete list of class names, see [Supported Device Classes](supported-device-classes.md).

## Interface Classes

The **Interface** classes are the most fundamental base classes provided by POS for .NET. There is an **Interface** class for each of the 36 device types in the UPOS specification, and they contain methods and properties that correspond to those required by the specification. They provide no device-specific functionality so deriving from these classes requires the Service Object developer to provide the greatest amount of additional code and therefore should rarely be used directly.

## Basic Classes

**Basic** classes are derived from their corresponding **Interface** class. There is a **Basic** class for all 36 devices supported by the UPOS specification. These classes provide some functionality and are the best choice if no **Base** class exists for your device type. **Basic** classes, however, implement only the UPOS common members.

## Base Classes

The **Base** classes, each of which is derived from its corresponding **Basic** class, offer the greatest level of functionality. The **Base** classes provide nearly complete Service Object implementations. By deriving from these classes, the Service Object developer only needs to implement code to control the specific hardware device. Since **Base** classes provide so much functionality, Service Object developers should use them whenever possible. POS for .NET provides **Base**-level support for only nine **primary** device types.

| UPOS Device               | Corresponding POS for .NET Base Class |
|---------------------------|---------------------------------------|
| Cash Drawer               | CashDrawerBase                        |
| Check Scanner             | CheckScannerBase                      |
| Line Displays             | LineDisplayBase                       |
| Magnetic Stripe Reader    | MsrBase                               |
| Pin Pad                   | PinPadBase                            |
| POS Keyboards             | PosKeyboardBase                       |
| POS Printers              | PosPrinterBase                        |
| RFIDScanner               | RFIDScanner                           |
| Scanner (Bar Code Reader) | ScannerBase                           |

## See Also

#### Concepts

- [Supported Device Classes](supported-device-classes.md)

#### Other Resources

- [Developing a Custom Service Object](developing-a-custom-service-object.md)
- [POS for .NET Service Object Architecture](pos-for-net-service-object-architecture.md)
