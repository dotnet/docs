---
title: Adding Plug and Play Support
description: Adding Plug and Play Support (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Adding Plug and Play Support (POS for .NET v1.14 SDK Documentation)

Microsoft Point of Service for .NET (POS for .NET) includes support for Plug and Play devices. By adding Plug and Play support to your Service Objects, applications can become more simple, reliable, and efficient. Service Objects should support it whenever possible.

Implementing Plug and Play support at the Service Object level is very simple. Once you know the hardware ID of your device, simply add a single attribute to your class, <xref:Microsoft.PointOfService.HardwareIdAttribute>. The **HardwareId** attribute is used by <xref:Microsoft.PointOfService.PosExplorer> to intelligently filter out Service Objects from the list of available devices depending on the state of the device. If the Service Object has a **HardwareId** attribute that refers to an installed Plug and Play device, but that device is not connected, the Service Object will be excluded from the **PosExplorer** device list. This list is returned when applications call <xref:Microsoft.PointOfService.PosExplorer.GetDevices>.

Service Objects may also have more than one **HardwareId** attribute, in which case **PosExplorer** associates a union of all specified devices with the Service Object. It is possible to override the **HardwareId** attributes or add to the list of associated hardware on the Service Object without rebuilding the Service Object assembly. For information about overriding or adding the **HardwareId** attribute, see [Plug and Play XML Configuration](plug-and-play-xml-configuration.md).

Only the application is responsible for catching <xref:Microsoft.PointOfService.PosExplorer.DeviceAddedEvent> and <xref:Microsoft.PointOfService.PosExplorer.DeviceRemovedEvent> events and updating its status as appropriate based on the updated device list returned from **PosExplorer**. The Service Object does not need to detect these events.

## To add a HardwareId attribute to your Service Object class

1. Determine the range of hardware IDs for the device or devices that your Service Object supports.

2. Add a **HardwareId** attribute before your class definition using the lowest hardware ID used by your device and the highest. Multiple **HardwareId** attributes may be used to identify multiple ranges of hardware IDs.

## Example

The following sample adds a **HardwareId** attribute to the basic template shown in the previous section.

```csharp
using System;

using Microsoft.PointOfService;
using Microsoft.PointOfService.BaseServiceObjects;

namespace SOTemplate
{

    [HardwareId("HID\\Vid_05e0&amp;Pid_038a",
                "HID\\Vid_05e0&amp;Pid_038a")]

    [ServiceObject(
                DeviceType.Msr,
                "ServiceObjectTemplate",
                "Bare bones Service Object class",
                1,
                9)]
    public class MyServiceObject : MsrBase
    {
        public MyServiceObject()
        {
        }
    }
}
```

## See Also

#### Tasks

- [Creating a Basic Service Object Code Template](creating-a-basic-service-object-code-template.md)
- [Creating a Service Object Sample](creating-a-service-object-sample.md)

#### Concepts

- [Attributes for Identifying Service Objects and Assigning Hardware](attributes-for-identifying-service-objects-and-assigning-hardware.md)
- [Plug and Play XML Configuration](plug-and-play-xml-configuration.md)

#### Other Resources

- [Service Object Samples: Getting Started](service-object-samples-getting-started.md)
- [POS for .NET Service Object Architecture](pos-for-net-service-object-architecture.md)
