---
title: Using the WMI API to Manage Devices
description: Using the WMI API to Manage Devices (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Using the WMI API to Manage Devices (POS for .NET v1.14 SDK Documentation)

The WMI provider serves a WMI namespace called /root/MicrosoftPointOfService. This namespace defines four classes:

- [ServiceObject Class](serviceobject-class.md)
- [PosDevice Class](posdevice-class.md)
- [LogicalDevice Class](logicaldevice-class.md)
- [DeviceProperty Class](deviceproperty-class.md)

**ServiceObject** represents a POS for .NET Service Object from a management perspective. **PosDevice** represents the physical device serviced by the Service Object. **LogicalDevice** represents a logical name assigned to a **PosDevice**, providing third-party applications with the ability to access a Service Object without conflicting with other applications that may also be accessing the same Service Object. **DeviceProperty** instances are name/value pairs that can be associated with a **PosDevice** to store optional configuration data for Service Objects.

## In This Section

- [ServiceObject Class](serviceobject-class.md)
    Lists the properties and methods of the **ServiceObject** Class.

- [PosDevice Class](posdevice-class.md)
    Lists the properties and methods of the **PosDevice** Class.

- [LogicalDevice Class](logicaldevice-class.md)
    Lists the properties and methods of the **LogicalDevice** Class.

- [DeviceProperty Class](deviceproperty-class.md)
    Lists the properties and methods of the **DeviceProperty** Class.

- [Using VBScript to Manage Devices](using-vbscript-to-manage-devices.md)
    Demonstrates how to programmatically manage devices using the WMI API.

## See Also

#### Other Resources

- [POS Device Manager](pos-device-manager.md)
