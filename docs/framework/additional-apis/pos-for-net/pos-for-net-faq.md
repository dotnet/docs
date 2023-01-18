---
title: POS for .NET FAQ (POS for .NET v1.14 SDK Documentation)
description: POS for .NET FAQ (POS for .NET v1.14 SDK Documentation)
ms.date: 04/01/2017
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# POS for .NET FAQ (POS for .NET v1.14 SDK Documentation)

Microsoft Corporation

## Contents

Installation

- How do I install POS for .NET 1.14 on my device?
- How do I install POS for .NET with my product?
- What platforms are supported for POS for .NET 1.14?

Device Types

- Which device types or categories does POS for .NET support?
- Which OPOS device types or categories does POS for .NET support?
- Which device simulators does POS for .NET include?

Service Objects

- How do I write a .NET service object? How do I get started?
- Where can I find the service object that I need for a specific device?

## Installation

### How do I install POS for .NET 1.14 on my device?

You can install Microsoft Point of Service for .NET (POS for .NET) v1.14 on your device by double clicking on the **POSforDotNet-1.14.msi** installer and following the installer wizard.

### How do I install POS for .NET with my product?

You can silently run the POS for .NET v1.14 installer from within your own product installer by using the following commands:

## To install the POS for .NET 1.14 runtime only

- Add the following command to your product installer:

    `msiexec /i POSforDotNet-1.14.msi /passive`

## To install the complete POS for .NET 1.14 including the SDK

1. Add the following command to your product installer:

    `msiexec /i POSforDotNet-1.14.msi INSTALLLEVEL=1000 /passive`

### What platforms are supported for POS for .NET 1.14?

POS for .NET v1.14 can be installed on the following platforms:

- Windows 11
- Windows 11 IoT Enterprise
- Windows 10
- Windows 10 IoT Enterprise
- Windows 10 IoT Enterprise LTSC 2021
- Windows 10 IoT Enterprise LTSC 2019

## Device Types

### Which device types or categories does POS for .NET support?

POS for .NET v1.14 supports all the point of service (POS) peripheral device categories defined in the Unified Point of Service (UnifiedPOS) v1.14 international standard. Therefore, POS for .NET supports the following device categories:

- Belt
- Bill Acceptor
- Bill Dispenser
- Biometrics
- Bump Bar
- Cash Changer
- Cash Drawer
- Check Scanner
- Coin Acceptor
- Coin Dispenser
- Credit Authorization Terminal (CAT)
- Electronic Journal
- Electronic Value Reader/Writer
- Fiscal Printer
- Gate
- Hard Totals
- Image Scanner
- Item Dispenser
- Keylock
- Lights
- Line Display
- Magnetic Ink Character Recognition Reader (MICR)
- Magnetic Stripe Reader (MSR)
- Motion Sensor
- PIN Pad
- Point Card Reader/Writer
- POS Keyboard
- POS Power
- POS Printer
- Radio Frequency Identification (RFID) Scanner
- Remote Order Display
- Scale
- Scanner (Barcode Reader)
- Signature Capture
- Smart Card Reader/Writer
- Tone Indicator

### Which OPOS device types or categories POS for .NET support?

POS for .NET fully supports any previously created OLE for Retail POS (OPOS) service objects for the following device categories:

- Bar Code Scanner
- Bump Bar
- Cash Changer
- Cash Drawer
- Check Scanner
- Coin Dispenser
- Credit Authorization Terminal (CAT)
- Fiscal Printer
- Hard Totals
- Keylock
- Line Display
- Magnetic Ink Character Recognition Reader (MICR)
- Magnetic Stripe Reader (MSR)
- Motion Sensor
- PIN Pad
- Point Card Reader/Writer
- POS Keyboard
- POS Power
- POS Printer
- Remote Order Display
- Scale
- Signature Capture
- Smart Card Reader/Writer
- Tone Indicator

### Which device simulators does POS for .NET include?

When you install the POS for .NET Software Development Kit (SDK), it includes several device simulators. The simulators provide a simple means of simulating a device when no physical device is available. The simulators are helpful during the early stages of development, during prototyping, and for testing configurations before deployment. POS for .NET includes simulators for the following device categories:

- Bar Code Scanner
- Cash Drawer
- Check Scanner
- Keylock
- Line Display
- Magnetic Stripe Reader (MSR)
- PIN Pad
- POS Keyboard
- POS Printer

## Service Objects

### How do I write a .NET service object? How do I get started?

It depends on the type of device that you want to support:

- For some devices, we offer base classes that implement most of the UnifiedPOS-specific functionality; therefore, you can focus on only the communications between the service object and the device.
- For other device categories, you can take advantage of our basic class for much of the functionally but implement certain aspects of the UnifiedPOS-specific functionally yourself.
- Finally, you can choose to do everything yourself. In this case, you implement the whole class based on a provided interface. To help you get started, POS for .NET SDK includes documentation and code for sample service objects.

### Where can I find the service object that I need for a specific device?

You should contact the device manufacturer or your vendor to see whether they offer a .NET Service Object or a legacy OPOS service object for one of the supported legacy devices. Anyone can develop a .NET service object, and there are no requirements to register the service object with Microsoft. Therefore, we do not have a list available that identifies which devices are compatible with POS for .NET or OPOS.
