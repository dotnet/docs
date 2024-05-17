---
title: DeviceProperty Class
description: DeviceProperty Class (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# DeviceProperty Class (POS for .NET v1.14 SDK Documentation)

The **DeviceProperty** class represents a name/value pair of a configuration property for a physical device. There may be multiple **DeviceProperty** classes associated with a **PosDevice**.

## Properties

| Name   | Description                                          |
|--------|------------------------------------------------------|
| Type   | String representing the POS device category.         |
| SoName | String representing the name of the Service Object.  |
| Path   | String representing the path of the physical device. |
| Name   | String representing the name of this property.       |
| Value  | String representing the data of this property.       |

## See Also

#### Tasks

- [Using VBScript to Manage Devices](using-vbscript-to-manage-devices.md)

#### Concepts

- [PosDevice Class](posdevice-class.md)

#### Other Resources

- [Using the WMI API to Manage Devices](using-the-wmi-api-to-manage-devices.md)
