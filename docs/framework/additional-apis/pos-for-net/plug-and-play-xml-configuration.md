---
title: Plug and Play XML Configuration
description: Plug and Play XML Configuration (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Plug and Play XML Configuration (POS for .NET v1.14 SDK Documentation)

Although the Plug and Play hardware ID should generally be specified using the <xref:Microsoft.PointOfService.DeviceInfo.HardwareId> property within the Service Object source code, there may be times when Service Object vendors require more flexibility. For example, the hardware ID needs to be changed without redistributing the entire Service Object assembly.

To support these cases, Microsoft Point of Service for .NET (POS for .NET) specifies hardware associations in an XML file. These XML files are read from the directory that is specified in the registry key **HKEY\_LOCAL\_MACHINE/SOFTWARE/POSfor.NET/ControlConfigs**. When constructing the list of available Service Objects and devices, <xref:Microsoft.PointOfService.PosExplorer> processes each file in that directory and associates the device where possible. No additional action is required by either the Service Object or the application.

## Schema

A Plug and Play configuration file must begin with a top-level node named **PointOfServiceConfig** and have the attribute **Version** to indicate the XML version of the file.

Following that, there may be any number of **ServiceObject** subnodes. Each service object node must include **Type** and **Name** attributes to indicate the POS device type and name of the Service Object. These two fields will be matched against available Service Objects to determine which, if any, should be associated with devices specified in the subnode **HardwareId**. There is also an optional attribute on the **ServiceObject** node, **Override**. If this attribute is set, then the device associations in the XML file overrides those contained in the assembly.

The **ServiceObject** node contains subnodes with the name **HardwareId**, which have **From** and **To** attributes. The contents of these attributes are the same as would be found in the **HardwareId** attribute in a Service Object assembly and specify the range of hardware IDs to associate with the Service Object.

## Example

The example shows a typical XML Plug and Play configuration file.

```xml
<PointOfServiceConfig Version="1.0">
    <ServiceObject Type="Msr" Name="ExampleMsr" Override="yes">
        <HardwareId From="HID\Vid_0801&Pid_0002&Rev_0100"
                    To="HID\Vid_0801&Pid_0002&Rev_9999" />
    </ServiceObject>
</PointOfServiceConfig>
```

## Hardware ID Precedence

If the **Override** attribute on the **ServiceObject** node is set, then the device association specified in the XML takes precedence, and any **HardwareId** attribute on the Service Object will be discarded.

If the **Override** attribute is not set, then neither the XML nor the **HardwareId** has precedence. Instead, **PosExplorer** associates the union of all specified devices with the Service Object.

## See Also

#### Tasks

- [Adding Plug and Play Support](adding-plug-and-play-support.md)

#### Concepts

- [Plug and Play Support](plug-and-play-support.md)
- [POS for .NET Registry Settings](pos-for-net-registry-settings.md)
