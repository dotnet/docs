---
title: Scanner Implementation
description: Scanner Implementation (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Scanner Implementation (POS for .NET v1.14 SDK Documentation)

A scanner device is used to read bar code data.

The scanner is an exclusive-use device, as follows:

- The application must claim the device before enabling it.
- The application must claim and enable the device before the device begins reading input.

The scanner object follows the general model for event-drive input:

- When input is received from the device, a **DataEvent** event is queued using the Microsoft helper method, **ScannerBase.GoodRead**. If the device receives bad data, the Service Object may also queue an **ErrorEvent** event by calling **ScannerBase.FailedRead**.
- If the **PosCommon.AutoDisable** property is set to **true**, the **ScannerBase** class will set the **PosCommon.EnableDevice** property to **false**. If your Service Object has implemented this method, it will need to disable the device as appropriate.

A queued **DataEvent** event will only be delivered to the application when the property **ScannerBase.DataEventEnabled** is set to **true**.

- The Unified Point Of Service (UnifiedPOS) specification requires that data from the incoming **DataEvent** must be copied into the corresponding properties before being delivered to the application. The method **ScannerBase.PreFireEvent**, which is called just before delivering the **DataEvent** to the application, meets this requirement by calling **ScannerBase.DecodeScanDataLabel** and **ScannerBase.DecodeScanDataType** if the **DecodeData** property is set to **true**. Usually you have to implement these methods in your Service Object.
- Scanned data is placed into the **Scanner.BaseScanData** property. If the application has set the **ScannerBase.DecodeData** property to **true**, then data is decoded into the **ScannerBase.ScanDataLabel** and **ScanDataType** properties.
- Before the **DataEvent** is delivered to the application, the property **ScannerBase.DataEventEnabled** is set to **false**. This prevents further **DataEvents** from being delivered to the application until it has finished processing the current one. The application sets **ScannerBase.DataEventEnabled** to **true** when it is ready to process incoming events.
- The **ScannerBasic.DataCount** property may be read to obtain the total number of queued events.
- All queued events may be deleted by calling the **ScannerBasic.ClearInput** method.

## In This Section

- [Data Decoding](data-decoding.md)
    Describes the code necessary to decode device-specific data.

- [Scanner Events](scanner-events.md)
    Demonstrates how a scanner Service Object uses POS for .NET queuing to raise events to applications.
