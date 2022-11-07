---
title: POS for .NET Integration with Plug and Play
description: POS for .NET Integration with Plug and Play (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# POS for .NET Integration with Plug and Play (POS for .NET v1.14 SDK Documentation)

Microsoft Point of Service for .NET (POS for .NET) leverages Windows Embedded Plug and Play technology specifications to detect peripheral POS devices that are enabled for Plug and Play. Plug and Play support simplifies the installation and maintenance of POS devices.

## PosExplorer

The POS for .NET <xref:Microsoft.PointOfService.PosExplorer> class serves as the interface between Plug and Play notifications and POS applications. **PosExplorer** translates the relevant Plug and Play notifications into POS for .NET events, which it then sends to the POS application.

## Plug and Play Events

The **PosExplorer** class exposes two Plug and Play events for use by POS applications:

- <xref:Microsoft.PointOfService.PosExplorer.DeviceAddedEvent>
    The **DeviceAddedEvent** triggers when a POS device is connected to the system.
- <xref:Microsoft.PointOfService.PosExplorer.DeviceRemovedEvent>
    The **DeviceRemovedEvent** triggers when a POS device is disconnected from the system.

## See Also

#### Reference

- <xref:Microsoft.PointOfService.PosExplorer.DeviceAddedEvent>
- <xref:Microsoft.PointOfService.PosExplorer.DeviceRemovedEvent>

#### Concepts

- [PosExplorer Class](posexplorer-class.md)
- [Supported Device Classes](supported-device-classes.md)
- [Plug and Play Support](plug-and-play-support.md)

#### Other Resources

- [POS for .NET v1.14 Features](pos-for-net-v1141-features.md)
