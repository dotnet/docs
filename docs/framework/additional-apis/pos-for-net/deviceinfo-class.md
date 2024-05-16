---
title: DeviceInfo Class
description: DeviceInfo Class (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# DeviceInfo Class (POS for .NET v1.14 SDK Documentation)

The <xref:Microsoft.PointOfService.DeviceInfo> class supplies Microsoft Point of Service for .NET (POS for .NET) applications with information about POS devices and the Service Objects associated with them. The <xref:Microsoft.PointOfService.PosExplorer> methods, <xref:Microsoft.PointOfService.PosExplorer.GetDevice(System.String,System.String)> and <xref:Microsoft.PointOfService.PosExplorer.GetDevices> return instances of **DeviceInfo**.

## DeviceInfo Properties

The following table shows the **DeviceInfo** properties.

| Property             | Type                  | Description                                                                                                            |
|----------------------|-----------------------|------------------------------------------------------------------------------------------------------------------------|
| Compatibility        | DeviceCompatibilities | Lists the valid compatibility levels for a POS device (an OLE for Retail POS (OPOS) or .NET Service Object).           |
| Description          | string                | Describes the Service Object.                                                                                          |
| HardwareDescription  | string                | Describes the physical device.                                                                                         |
| HardwareId           | string                | Provides the ID of the physical device.                                                                                |
| HardwarePath         | string                | Provides the physical hardware path of the device.                                                                     |
| IsDefault            | bool                  | Returns true if the device is the default for its type.                                                                |
| LogicalNames         | strings[]             | Provides the alternative name(s) assigned to the device in the global configuration fileby POS Device Manager (POSDM). |
| ManufacturerName     | string                | Provides the physical device manufacturer name.                                                                        |
| ServiceObjectName    | string                | Provides the name of the Service Object.                                                                               |
| ServiceObjectVersion | Version               | Provides the Service Object version.                                                                                   |
| DeviceType           | string                | Provides the physical device type.                                                                                     |
| UposVersion          | Version               | Provides the UPOS version number.                                                                                      |

## DeviceInfo Methods

The following table shows the **DeviceInfo** methods.

| Method         | Return Type | Description                                                                        |
|----------------|-------------|------------------------------------------------------------------------------------|
| IsDeviceInfoOf | bool        | Returns true if the Service Object corresponds to the DeviceInfo class properties. |
| ToString       | string      | Returns a string that describes the properties of the device.                      |

## See Also

#### Concepts

- [PosExplorer Class](posexplorer-class.md)
- [Exception Classes](exception-classes.md)

#### Other Resources

- [Developing a POS Application](developing-a-pos-application.md)
- [POS for .NET API Support](pos-for-net-api-support.md)
- [POS Device Manager](pos-device-manager.md)
