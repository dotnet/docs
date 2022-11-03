---
title: POS for .NET Device Basic Classes
description: POS for .NET Device Basic Classes (POS for .NET v1.14 SDK Documentation)
ms.date: 02/27/2008
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# POS for .NET Device Basic Classes (POS for .NET v1.14 SDK Documentation)

Each hardware device in POS for .NET is represented by both an abstract interface, such as <xref:Microsoft.PointOfService.CashDrawer> class, and a **Basic** class, such as **CashDrawerBasic**. **Basic** classes derive from the underlying interface and contain basic functional support for the device. POS for .NET provides generic support for opening, claiming, and enabling the device, device statistics, and for managing delivery of events to the application. In addition, each **Basic** class contains a set of inherited and protected methods that can be implemented by the Service Object. This topic provides summary information about **Basic** classes that can be used by Service Objects that derive from the device’s **Basic** class, rather than taking advantage of the more fully implemented device **Base** class.

## Constructor

Each **Basic** class includes a constructor that creates an instance of the class and initializes statistics for the UPOS version, the device category, and the installation date.

## Common Properties and Methods

Each **Basic** class provides overridden <xref:Microsoft.PointOfService.PosCommon> property and method definitions. For each of these properties and methods, the **Basic** class handles state validation—that is, verification that the application has opened, claimed, or enabled the device—and then calls the POS for .NET implementation of that property or method. For more information about the **PosCommon** class, see **PosCommon**.

The Service Object can use the **CommonProperties** class to update **PosCommon** properties that are designated read-only for the application, or to update those properties without worrying about state validation.

## Dispose Methods

Each **Basic** class includes two implemented **Dispose** methods for use by the Service Object. For information about how these work, see the .NET Framework documentation for the **IDisposable** class.

## Opening, Claiming, and Enabling Devices

Each **Basic** class provides the core functionality for opening, claiming, and enabling devices. Typically, though, Service Objects want to override these methods to add their own custom processing.

## Protected Methods and Events for Service Object Developers

Each **Basic** class contains a group of methods and events for the Service Object developer.

The following protected properties are defined as follows:

- **CommonProperties** property, which returns an instance of **CommonProperties** with get and set values for all **PosCommon** properties. The Service Object can use **CommonProperties** to update properties without worrying about state validation or whether the property is designated read-only for the application.
- **ExternallyClaimed** property, which Service Objects can retrieve to determine if another instance of the device has been claimed (in which case, the property is set to **true**).
- **ErrorCount** property. When the Service Object queries for the value of **ErrorCount**, the basic class checks the event queue and tallies the number of **ErrorEvent** events found, and then returns that tally as the value of **ErrorCount**.
- **DataCount** property. POS for .NET verifies that the device has been opened, and then returns the number of **DataEvent** events currently queued for the device.

The following protected methods are defined:

- **StateChangedEvent** and delegate **StateChangedEventHandler** (**EventArgs** class). The Service Object can implement these to receive notification when the device’s **State** property has changed.
- **PreFireEvent** protected methods for each type of event supported by the device. Each basic class provides a default, generic implementation of **PreFireEvent** that returns immediately. If the Service Object needs to update its internal state prior to an event being sent to the application, the Service Object can override the default implementation of **PreFireEvent** and provide its own implementation for the event type in question.
- **QueueEvent** protected methods for each type of event supported by the device. The Service Object calls **QueueEvent** to add an event to the event queue. The **Basic** class verifies that the device is enabled, and then adds the event to the event queue to be delivered to the application. Immediately before delivery, the **Basic** class calls the appropriate **PreFireEvent** to give the Service Object an opportunity to update its internal state. When **PreFireEvent** returns, the **Basic** class delivers the event to the application.
- **QueueEventAndWait** protected methods. The Service Object calls **QueueEventAndWait** to add an **ErrorEvent** event or **DirectIOEvent** event to the event queue, from which the Service Object expects a response from the application. The **Basic** class verifies that the device is enabled, and then adds the event to the event queue, to be delivered to the application when conditions are correct. Immediately before delivery, the **Basic** class calls **PreFireEvent** to give the Service Object an opportunity to update its internal state. When **PreFireEvent** returns, the **Basic** class delivers the event to the application.
- **VerifyState** method, which takes two Boolean values, *mustBeClaimed* and *mustBeEnabled*. The Service Object can call the POS for .NET implementation of this method to perform the necessary state validation for the device, prior to a method or property call.
- **CreateStatistic** method. The Service Object should use these methods to create custom (that is, manufacturer-specific) statistics. POS for .NET handles the creation and management of all UPOS-defined statistics.
- **SetStatisticValue** and **IncrementStatistic** methods allow the Service Object to update a specified statistic even if it is not defined as resettable (that is, these methods bypass the rules enforced by the **PosCommon**<xref:Microsoft.PointOfService.BaseServiceObjects.DeviceStatistics.ResetStatistic(System.String)> and <xref:Microsoft.PointOfService.BaseServiceObjects.DeviceStatistics.UpdateStatistic(System.String,System.Object)> methods).
- <xref:Microsoft.PointOfService.BaseServiceObjects.DeviceStatistics.SetStatisticHandlers(System.String,Microsoft.PointOfService.BaseServiceObjects.GetStatistic,Microsoft.PointOfService.BaseServiceObjects.SetStatistic)> method, which allows Service Objects to provide external callback functions for the retrieval and setting of hardware-based statistics. If a get property is not defined, the **Basic** class assumes that the statistic is software-based, and its value is maintained in the statistics XML file. If both get and set properties are defined, the **Basic** class calls these functions whenever the statistic needs to be updated or reset. It is up to the Service Object to provide code to update the statistic in the hardware.
- **ClearInput** method. POS for .NET clears the event queues for the device and then calls the Service Object’s implementation of **ClearInputImpl**.
- **ClearInputImpl** method. The Service Object should implement this method to clear any hardware buffers for the device.

## See Also

#### Other Resources

- [Developing a Custom Service Object](developing-a-custom-service-object.md)
- [POS for .NET Service Object Architecture](pos-for-net-service-object-architecture.md)
