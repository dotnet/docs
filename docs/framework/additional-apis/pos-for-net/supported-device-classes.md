---
title: Supported Device Classes (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
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

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<thead>
<tr class="header">
<th>UnifiedPOS Device</th>
<th>Interface Class</th>
<th>Basic Class</th>
<th>Base Class</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>Belt</p></td>
<td><p><a href="cc297518(v=winembedded.11).md">Belt</a></p></td>
<td><p>BeltBasic</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>Biometrics</p></td>
<td><p><a href="bb411893(v=winembedded.11).md">Biometrics</a></p></td>
<td><p>BiometricsBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>Bill Acceptor</p></td>
<td><p><a href="bb411820(v=winembedded.11).md">BillAcceptor</a></p></td>
<td><p>BillAcceptorBasic</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>Bill Dispenser</p></td>
<td><p><a href="bb411849(v=winembedded.11).md">BillDispenser</a></p></td>
<td><p>BillDispenserBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>Bump Bar</p></td>
<td><p><a href="ms883538(v=winembedded.11).md">BumpBar</a></p></td>
<td><p>BumpBarBasic</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>Cash Changer</p></td>
<td><p><a href="ms883669(v=winembedded.11).md">CashChanger</a></p></td>
<td><p>CashChangerBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>Cash Drawer</p></td>
<td><p><a href="ms883867(v=winembedded.11).md">CashDrawer</a></p></td>
<td><p>CashDrawerBasic</p></td>
<td><p><a href="aa460345(v=winembedded.11).md">CashDrawerBase</a></p></td>
</tr>
<tr class="even">
<td><p>CAT - Credit Authorization Terminal</p></td>
<td><p><a href="ms883970(v=winembedded.11).md">Cat</a></p></td>
<td><p>CatBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>Check Scanner</p></td>
<td><p><a href="ms884001(v=winembedded.11).md">CheckScanner</a></p></td>
<td><p>CheckScannerBasic</p></td>
<td><p><a href="aa460371(v=winembedded.11).md">CheckScannerBase</a></p></td>
</tr>
<tr class="even">
<td><p>Coin Acceptor</p></td>
<td><p><a href="bb411823(v=winembedded.11).md">CoinAcceptor</a></p></td>
<td><p>CoinAcceptorBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>Coin Dispenser</p></td>
<td><p><a href="ms884010(v=winembedded.11).md">CoinDispenser</a></p></td>
<td><p>CoinDispenserBasic</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>Electronic Journal</p></td>
<td><p><a href="bb404543(v=winembedded.11).md">ElectronicJournal</a></p></td>
<td><p>ElectronicJournalBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>Electronic Value Reader / Writer</p></td>
<td><p><a href="cc297622(v=winembedded.11).md">ElectronicValueRW</a></p></td>
<td><p>ElectronicValueRWBasic</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>Fiscal Printer</p></td>
<td><p><a href="ms884287(v=winembedded.11).md">FiscalPrinter</a></p></td>
<td><p>FiscalPrinterBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>Gate</p></td>
<td><p><a href="cc297632(v=winembedded.11).md">Gate</a></p></td>
<td><p>GateBasic</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>Hard Totals</p></td>
<td><p><a href="ms884348(v=winembedded.11).md">HardTotals</a></p></td>
<td><p>HardTotalsBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>Image Scanner</p></td>
<td><p><a href="bb411828(v=winembedded.11).md">ImageScanner</a></p></td>
<td><p>ImageScannerBasic</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>Item Dispenser</p></td>
<td><p><a href="cc297403(v=winembedded.11).md">ItemDispenser</a></p></td>
<td><p>ItemDispenserBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>Keylock</p></td>
<td><p><a href="ms884534(v=winembedded.11).md">Keylock</a></p></td>
<td><p>KeylockBasic</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>Lights</p></td>
<td><p><a href="cc297577(v=winembedded.11).md">Lights</a></p></td>
<td><p>LightsBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>Line Display</p></td>
<td><p><a href="ms884540(v=winembedded.11).md">LineDisplay</a></p></td>
<td><p>LineDisplayBasic</p></td>
<td><p><a href="aa460464(v=winembedded.11).md">LineDisplayBase</a></p></td>
</tr>
<tr class="even">
<td><p>MICR - Magnetic Ink Character Recognition</p></td>
<td><p><a href="ms884551(v=winembedded.11).md">Micr</a></p></td>
<td><p>MicrBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>Motion Sensor</p></td>
<td><p><a href="ms884558(v=winembedded.11).md">MotionSensor</a></p></td>
<td><p>MotionSensorBasic</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>MSR - Magnetic Stripe Reader</p></td>
<td><p><a href="ms884564(v=winembedded.11).md">Msr</a></p></td>
<td><p>MsrBasic</p></td>
<td><p><a href="aa460596(v=winembedded.11).md">MsrBase</a></p></td>
</tr>
<tr class="odd">
<td><p>PIN Pad</p></td>
<td><p><a href="ms884787(v=winembedded.11).md">PinPad</a></p></td>
<td><p>PinPadBasic</p></td>
<td><p><a href="aa460647(v=winembedded.11).md">PinPadBase</a></p></td>
</tr>
<tr class="even">
<td><p>Point Card Reader / Writer</p></td>
<td><p><a href="ms884808(v=winembedded.11).md">PointCardRW</a></p></td>
<td><p>PointCardRWBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>POS Keyboard</p></td>
<td><p><a href="ms884848(v=winembedded.11).md">PosKeyboard</a></p></td>
<td><p>PosKeyboardBasic</p></td>
<td><p><a href="aa460659(v=winembedded.11).md">PosKeyboardBase</a></p></td>
</tr>
<tr class="even">
<td><p>POS Power</p></td>
<td><p><a href="ms884862(v=winembedded.11).md">PosPower</a></p></td>
<td><p>PosPowerBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>POS Printer</p></td>
<td><p><a href="ms884868(v=winembedded.11).md">PosPrinter</a></p></td>
<td><p>PosPrinterBasic</p></td>
<td><p><a href="aa460669(v=winembedded.11).md">PosPrinterBase</a></p></td>
</tr>
<tr class="even">
<td><p>Remote Order Display</p></td>
<td><p><a href="aa460863(v=winembedded.11).md">RemoteOrderDisplay</a></p></td>
<td><p>RemoteOrderDisplayBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>RFID Scanner</p></td>
<td><p><a href="cc297328(v=winembedded.11).md">RFIDScanner</a></p></td>
<td><p>RFIDScannerBasic</p></td>
<td><p><a href="cc297693(v=winembedded.11).md">RFIDScannerBase</a></p></td>
</tr>
<tr class="even">
<td><p>Scale</p></td>
<td><p><a href="aa460872(v=winembedded.11).md">Scale</a></p></td>
<td><p>ScaleBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>Scanner (Bar Code Reader)</p></td>
<td><p><a href="aa460878(v=winembedded.11).md">Scanner</a></p></td>
<td><p>ScannerBasic</p></td>
<td><p><a href="ms881268(v=winembedded.11).md">ScannerBase</a></p></td>
</tr>
<tr class="even">
<td><p>Signature Capture</p></td>
<td><p><a href="aa460889(v=winembedded.11).md">SignatureCapture</a></p></td>
<td><p>SignatureCaptureBasic</p></td>
<td></td>
</tr>
<tr class="odd">
<td><p>Smart Card Reader / Writer</p></td>
<td><p><a href="aa460898(v=winembedded.11).md">SmartCardRW</a></p></td>
<td><p>SmartCardRWBasic</p></td>
<td></td>
</tr>
<tr class="even">
<td><p>Tone Indicator</p></td>
<td><p><a href="aa460918(v=winembedded.11).md">ToneIndicator</a></p></td>
<td><p>ToneIndicatorBasic</p></td>
<td></td>
</tr>
</tbody>
</table>

## See Also

#### Reference

[Microsoft.PointOfService](ms843373\(v=winembedded.11\).md)
[Microsoft.PointOfService.BaseServiceObjects](ms843374\(v=winembedded.11\).md)

#### Concepts

[What's New in POS for .NET v1.14](whats-new-in-pos-for-net-v114-and-v1141.md)

#### Other Resources

[POS for .NET v1.14 Features](pos-for-net-v1141-features.md)
