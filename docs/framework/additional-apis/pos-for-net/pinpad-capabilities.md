---
title: PinPad Capabilities
description: PinPad Capabilities (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# PinPad Capabilities (POS for .NET v1.14 SDK Documentation)

A PIN Pad performs encryption functions under control of a PIN Pad Management System. Some **PinPad** Service Objects support multiple PIN Pad Management Systems and some PIN Pad Management Systems support multiple key sets for different Electronic Funds Transfer (EFT) Transaction Hosts. Thus, for each EFT transaction, the application needs to select the PIN Pad Management System and EFT Transaction Host to be used.

## Programming model

Depending on the PIN Pad Management System, one or more EFT transaction parameters need to be provided to the PIN Pad for use in the encryption functions. The application should set the value of ALL EFT Transaction parameter properties to enable easier migration to EFT Transaction Hosts that require a different PIN Pad Management System.

- After opening, claiming, and enabling the PIN Pad Control, an application should use the following general scenario for each EFT Transaction.
- Set the EFT transaction parameters (**AccountNumber**, **Amount**, **MerchantID**, **TerminalID**, **Track1Data**, **Track2Data**, **Track3Data**, **Track4Data**, and **TransactionType** properties) and then call the <xref:Microsoft.PointOfService.BaseServiceObjects.PinPadBase.BeginEftTransaction(Microsoft.PointOfService.PinPadSystem,System.Int32)> method. This will initialize the device to perform the encryption functions for the EFT transaction.

If PIN Entry is **OnFailure**, call the <xref:Microsoft.PointOfService.BaseServiceObjects.PinPadBase.EnablePinEntry> method. Then set the **DataEventEnabled** property and wait for the **DataEvent** event.

- If Message Authentication Codes are required, use the <xref:Microsoft.PointOfService.PinPad.ComputeMac(System.String)> and <xref:Microsoft.PointOfService.BaseServiceObjects.PinPadBase.VerifyMac(System.String)> methods as needed.
- Call the <xref:Microsoft.PointOfService.BaseServiceObjects.PinPadBase.EndEftTransaction(Microsoft.PointOfService.EftTransactionCompletion)> method to notify the device that all operations for the EFT transaction have been completed. This specification supports two models of usage of the display. The **CapDisplay** property indicates one of the following models:
      - An application has complete control of the text that is to be displayed. For this model, there is an associated **LineDisplay** control that is used by the application to interact with the display.
      - An application cannot supply the text to be displayed. Instead, it can only select from a list of predefined messages to be displayed. For this model, there is a set of PIN Pad properties that are used to control the display.

### Device sharing

The PIN Pad is an exclusive-use device, therefore:

- The application must claim the device before enabling it.
- The application must claim and enable the device before the device begins reading input, or before calling methods that manipulate the device.

### Microsoft Point of Service for .NET (POS for .NET) ~Impl methods

The protected abstract methods that end with the suffix, "Impl" are called from their POS for .NET public counterparts. This allows the **Base** class implementation to perform appropriate status and error checking before and after the **~Impl** method is called. These methods must be implemented in the Service Object code, but the public, nonabstract counterparts should be overridden only in special cases, such as when the Service Object code needs to remove or change the standard validation tests.

### POS for .NET events

A **PinPad** Service Object may send the following events to the application:

- DataEvent
- DirectIOEvent
- StatusUpdateEvent
- ErrorEvent

## See Also

#### Other Resources

- [PinPad Implementation](pinpad-implementation.md)
