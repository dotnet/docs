---
title: POS for .NET Service Object Architecture
description: POS for .NET Service Object Architecture (POS for .NET v1.14 SDK Documentation)
ms.date: 02/27/2008
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# POS for .NET Service Object Architecture (POS for .NET v1.14 SDK Documentation)

There are features and design elements in POS for .NET that must be taken into account by Service Object developers. This section includes topics discussing several of these important concepts.

## In This Section

- [POS for .NET Class Tree](pos-for-net-class-tree.md)
    Provides an overview of the POS for .NET class structure. POS for .NET Service Object classes are derived from an appropriate class in this tree.

- [Attributes for Identifying Service Objects and Assigning Hardware](attributes-for-identifying-service-objects-and-assigning-hardware.md)
    Explains how POS for .NET uses reflection and .NET attributes to locate POS for .NET assemblies and identify valid Service Objects within those assemblies.

- [Hydra Devices](hydra-devices.md)
    Provides a broad overview of the problems involved when developing for hardware that may be in use by several Service Objects simultaneously.

- [Plug and Play Support](plug-and-play-support.md)
    Provides an overview of Plug and Play support available to Service Object developers.

- [PosCommon Information for Service Object Developers](poscommon-information-for-service-object-developers.md)
    Describes methods and properties of <xref:Microsoft.PointOfService.PosCommon> that are useful to Service Object developers.

- [POS for .NET Device Basic Classes](pos-for-net-device-basic-classes.md)
    Provides information about using the POS for .NET **Basic** classes as the starting point for Service Objects.

## Related Sections

- [POS for .NET Architecture](pos-for-net-architecture.md)
    Describes the components that support developers writing POS applications as well as peripheral device hardware vendors writing .NET-based Service Objects.

- [Typical POS Application Architecture](typical-pos-application-architecture.md)
    Describes event handlers and the public interface to Service Objects and the [PosExplorer Class](posexplorer-class.md) as the principal elements of POS application architecture.

- [Service Object Samples: Getting Started](service-object-samples-getting-started.md)
    Includes a step-by-step guide to creating a functioning Service Object and demonstrates how the features discussed above are utilized.

- [Developing a POS Application](developing-a-pos-application.md)
    Explains how to create POS for .NET applications, the ultimate consumers of POS for .NET Service Objects.

- [System Configuration](system-configuration.md)
    Describes how to configure POS for .NET to meet the requirements of your installation.
