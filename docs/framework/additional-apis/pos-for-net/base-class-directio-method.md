---
title: Base Class DirectIO Method
description: Base Class DirectIO Method (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Base Class DirectIO Method (POS for .NET v1.14 SDK Documentation)

The **DirectIO** method and the **DirectIOEvent** event are used to provide functionality to the application that is not otherwise supported by the standard Unified Point Of Service (UnifiedPOS) specification for a particular device type.

## DirectIO Method

If a device has features that are not supported by the standard UnifiedPOS specification, a Service Object may implement a **DirectIO** method to give the application access to those features.

An example might be a **LineDisplay** device that supports multicolor output. Few, if any, **LineDisplay**-type devices support color output, but an independent hardware vendor (IHV) might produce such a device and want to have the new features available to applications.

Use of this method will make the application nonportable, since the implementation of the **DirectIO** method is vendor-specific. An application that uses a **DirectIO** method on Vendor A's **LineDisplay** device cannot depend on using a Vendor B's device.

### DirectIOEvent

This event can be used to send vendor-specific information directly to the application. This event provides a means for a vendor-specific UnifiedPOS service to provide events to the application that are not otherwise supported by the UnifiedPOS control.

Using this event will make an application incompatible with devices from other vendors.

## See Also

#### Other Resources

- [Developing Service Objects Using Base Classes](developing-service-objects-using-base-classes.md)
