---
title: Supported Device Classes (POS for .NET v1.14 SDK Documentation)
description: Supported Device Classes (POS for .NET v1.14 SDK Documentation) (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Supported Device Classes (POS for .NET v1.14 SDK Documentation)

Microsoft Point of Service for .NET (POS for .NET) v1.14 represents the 36 peripheral devices identified in the Unified Point of Service (UnifiedPOS) v1.14 specification by abstract **Interface** and **Basic** device classes. POS for .NET also provides nine abstract **Base** device classes that further implement core POS functionality specific to those particular device types.

Hardware vendors use the device classes to create Service Objects that link their peripheral devices to the applications.

## Interface Classes

POS for .NET supplies **Interface** classes for all 36 UnifiedPOS devices. The **Interface** classes provide the entry points as specified in the UnifiedPOS specification, but offer minimal functionality.

## Basic Classes

POS for .NET **Basic** classes contain basic functional support for all 36 devices. **Basic** classes provide generic support for opening, claiming, and enabling the device, device statistics, and management of delivering events to the application. In addition, each **Basic** class contains a set of inherited and protected methods that can be implemented by the Service Object.

## Base Classes

For the nine primary UnifiedPOS device types, POS for .NET supplies fully functional **Base** classes that extend their corresponding **Basic** classes with device-specific members. You could think of these classes as enhanced or extended **Basic** classes. Because **Base** classes provide a nearly complete implementation, Service Object developers should derive from these classes whenever possible.

## UnifiedPOS Devices and POS for .NET Device Classes

The following table lists the UnifiedPOS devices with their equivalent POS for .NET **Basic** and **Base** device classes (where applicable).

| UnifiedPOS Device                         | Interface Class    | Basic Class             | Base Class       |
|-------------------------------------------|--------------------|-------------------------|------------------|
| Belt                                      | Belt               | BeltBasic               |
| Biometrics                                | Biometrics         | BiometricsBasic         |
| Bill Acceptor                             | BillAcceptor       | BillAcceptorBasic       |
| Bill Dispenser                            | BillDispenser      | BillDispenserBasic      |
| Bump Bar                                  | BumpBar            | BumpBarBasic            |
| Cash Changer                              | CashChanger        | CashChangerBasic        |
| Cash Drawer                               | CashDrawer         | CashDrawerBasic         | CashDrawerBase   |
| CAT - Credit Authorization Terminal       | Cat                | CatBasic                |
| Check Scanner                             | CheckScanner       | CheckScannerBasic       | CheckScannerBase |
| Coin Acceptor                             | CoinAcceptor       | CoinAcceptorBasic       |
| Coin Dispenser                            | CoinDispenser      | CoinDispenserBasic      |
| Electronic Journal                        | ElectronicJournal  | ElectronicJournalBasic  |
| Electronic Value Reader / Writer          | ElectronicValueRW  | ElectronicValueRWBasic  |
| Fiscal Printer                            | FiscalPrinter      | FiscalPrinterBasic      |
| Gate                                      | Gate               | GateBasic               |
| Hard Totals                               | HardTotals         | HardTotalsBasic         |
| Image Scanner                             | ImageScanner       | ImageScannerBasic       |
| Item Dispenser                            | ItemDispenser      | ItemDispenserBasic      |
| Keylock                                   | Keylock            | KeylockBasic            |
| Lights                                    | Lights             | LightsBasic             |
| Line Display                              | LineDisplay        | LineDisplayBasic        | LineDisplayBase  |
| MICR - Magnetic Ink Character Recognition | Micr               | MicrBasic               |
| Motion Sensor                             | MotionSensor       | MotionSensorBasic       |
| MSR - Magnetic Stripe Reader              | Msr                | MsrBasic                | MsrBase          |
| PIN Pad                                   | PinPad             | PinPadBasic             | PinPadBase       |
| Point Card Reader / Writer                | PointCardRW        | PointCardRWBasic        |
| POS Keyboard                              | PosKeyboard        | PosKeyboardBasic        | PosKeyboardBase  |
| POS Power                                 | PosPower           | PosPowerBasic           |
| POS Printer                               | PosPrinter         | PosPrinterBasic         | PosPrinterBase   |
| Remote Order Display                      | RemoteOrderDisplay | RemoteOrderDisplayBasic |
| RFID Scanner                              | RFIDScanner        | RFIDScannerBasic        | RFIDScannerBase  |
| Scale                                     | Scale              | ScaleBasic              |
| Scanner (Bar Code Reader)                 | Scanner            | ScannerBasic            | ScannerBase      |
| Signature Capture                         | SignatureCapture   | SignatureCaptureBasic   |
| Smart Card Reader / Writer                | SmartCardRW        | SmartCardRWBasic        |
| Tone Indicator                            | ToneIndicator      | ToneIndicatorBasic      |

## See Also

#### Reference

- <xref:Microsoft.PointOfService>
- <xref:Microsoft.PointOfService.BaseServiceObjects>

#### Concepts

- [What's New in POS for .NET v1.14](whats-new-in-pos-for-net-v114-and-v1141.md)

#### Other Resources

- [POS for .NET v1.14 Features](pos-for-net-v1141-features.md)
