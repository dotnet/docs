---
title: PinPad Implementation
description: PinPad Implementation (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# PinPad Implementation (POS for .NET v1.14 SDK Documentation)

A **PinPad** device provides a mechanism for customers to perform PIN entry and acts as a cryptographic engine for communicating with an EFT Transaction Host. To perform these tasks, a **PinPad** Service Object may implement one or more PIN Pad Management Systems. A **PinPad** Management System defines the manner in which the **PinPad** performs functions such as PIN Encryption, Message Authentication Code calculations, and Key Updating. Examples of **PinPad** management systems include Master-Session, DUKPT, APACS40, HGEP02, AS2805, and JDEBIT2, along with many others.

A **PinPad** Service Object must have the following minimum capability:

- Accepts a PIN Entry at its keyboard and provides an Encrypted PIN to the application.

A **PinPad** Service Object may also have the following additional capabilities:

- Computes Message Authentication Codes.
- Performs Key Updating in accordance with the selected PIN Pad Management System.
- Allows use of the PIN Pad Keyboard, Display, and Tone Generator for application usage. If one or more of these features are available, then the application opens and uses the associated POS Keyboard, Line Display, or Tone Indicator Device Objects.

## In This Section

- [PinPad Capabilities](pinpad-capabilities.md)
    Outlines the programming model and capabilities for **PinPad** Service Objects.

- [PinPad Sample](pinpad-sample.md)
    Provides the **PinPad** sample code.

## Reference

- <xref:Microsoft.PointOfService.BaseServiceObjects.PinPadBase>
    Provides the Microsoft Point of Service for .NET (POS for .NET) reference for the **PinPadBase** class.

- [Developing a Custom Service Object](developing-a-custom-service-object.md)
    Describes the POS for .NET Service Object development.
