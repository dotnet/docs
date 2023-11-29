---
title: Capability Properties
description: Capability Properties (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Capability Properties (POS for .NET v1.14 SDK Documentation)

Certain properties cannot be set directly within a Service Object. This comes up most often in the case of capability properties; those with the **Cap** prefix in their names. According to the Unified Point Of Service (UnifiedPOS) specification, these properties must be read-only; therefore, an implementation-specific mechanism is needed for the Service Object to change the value of these properties.

## BaseClass Properties

Microsoft Point of Service for .NET (POS for .NET) **Base** classes have a protected property, **Properties**, for this purpose. This property returns a helper class which has writable versions of the read-only properties implemented in the **Base** class. For example, <xref:Microsoft.PointOfService.BaseServiceObjects.PinPadBase> has a property called <xref:Microsoft.PointOfService.BaseServiceObjects.PinPadBase.Properties> that returns an object of type <xref:Microsoft.PointOfService.BaseServiceObjects.PinPadProperties>. And this object contains properties used to set various **PinPad**-specific capability properties, such as <xref:Microsoft.PointOfService.PinPad.CapDisplay>.

## PosCommon Properties

In addition to device-specific property classes, all POS for .NET **Base** and **Basic** classes also have a protected property called **CommonProperties** which returns an object of type **CommonProperties**. This helper class is used to modify capability and status properties found in **PosCommon**.

## Setting Properties Using Helper Classes

In general, a Service Object should always access the value of its common and class-specific properties using the helper classes. These properties may be written to by the Service Object and always contain the appropriate values.

The Service Object developer should be aware of what the POS for .NET framework may do when a particular value is changed. For example, the Service Object should generally not change **CommonProperties.State** since this may interfere with the POS for .NET internal state. Similarly, the Service Object developer should be aware that changing **CommonProperties.PowerState** may send a **StatusUpdateEvent** event to the application.

> [!NOTE]
> When deriving from the POS for .NET **Base** or **Basic** classes, the Service Object should generally not change the value of **CommonProperties.State** to **ControlState.Closed**. Doing so prevents cleanup of the event queue, and POS for .NET may later throw exceptions as it tries to process events already in the queue.

## See also

- <xref:Microsoft.PointOfService.BaseServiceObjects.PinPadProperties>
- <xref:Microsoft.PointOfService.StatusUpdateEventHandler>
