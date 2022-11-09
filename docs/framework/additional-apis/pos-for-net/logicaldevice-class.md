---
title: LogicalDevice Class
description: LogicalDevice Class (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# LogicalDevice Class (POS for .NET v1.14 SDK Documentation)

The **LogicalDevice** class represents a logical device associated with a **PosDevice**. It provides a naming mechanism so that applications can be developed independently and refers to the same device without conflict.

## Properties

| Name   | Description                                                                     |
|--------|---------------------------------------------------------------------------------|
| Type   | String representing the POS device category that the logical device belongs to. |
| SoName | String representing the name of the Service Object.                             |
| Path   | String representing the path of the physical device.                            |
| Name   | String representing the name for the logical device.                            |

## See Also

#### Tasks

- [Using VBScript to Manage Devices](using-vbscript-to-manage-devices.md)

#### Other Resources

- [Using the WMI API to Manage Devices](using-the-wmi-api-to-manage-devices.md)
