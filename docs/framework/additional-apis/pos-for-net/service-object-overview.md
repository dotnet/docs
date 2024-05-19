---
title: Service Object Overview
description: Service Object Overview (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Service Object Overview (POS for .NET v1.14 SDK Documentation)

Service Objects function as the interface between an application and a POS device. Each Service Object facilitates communication between the application and its associated device by implementing one device interface. The device interfaces provide the properties, methods, and events required by unique POS devices. This enables the application to manage and read data from them.

Not all devices receive the same level of support in POS for .NET. Each POS device that POS for .NET recognizes is provided with up to three levels of **Interface** classes that provide some level of functional support. The three levels of **Interface** classes are **Interface** classes, **Basic** classes, and **Base** classes. For more information about POS for .NET **Interface** classes, see [POS for .NET Class Tree](pos-for-net-class-tree.md). For more information about the default level of support provided by Service Objects, see the individual entries for each Service Object in <xref:Microsoft.PointOfService.BaseServiceObjects> and [Supported Device Classes](supported-device-classes.md).

Because each Service Object facilitates communications with a specific device, a different Service Object instance must be created for each connected peripheral device.

## See Also

#### Reference

- <xref:Microsoft.PointOfService.PosCommon>
- <xref:Microsoft.PointOfService.BaseServiceObjects>

#### Concepts

- [POS for .NET Architecture](pos-for-net-architecture.md)
- [Supported Device Classes](supported-device-classes.md)
- [POS for .NET Device Basic Classes](pos-for-net-device-basic-classes.md)

#### Other Resources

- [Developing a Custom Service Object](developing-a-custom-service-object.md)
- [POS for .NET Service Object Architecture](pos-for-net-service-object-architecture.md)
