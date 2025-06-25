---
title: Attributes for Identifying Service Objects and Assigning Hardware
description: Attributes for Identifying Service Objects and Assigning Hardware (POS for .NET v1.14 SDK Documentation)
ms.date: 02/27/2008
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Attributes for Identifying Service Objects and Assigning Hardware (POS for .NET v1.14 SDK Documentation)

POS for .NET uses .NET reflection and .NET attributes to locate Service Object assemblies, identify Service Objects within those assemblies, and finally to associate a Plug and Play device with that Service Object. By leveraging these .NET features, <xref:Microsoft.PointOfService.PosExplorer> can identify Service Objects within an assembly and quickly assess their Plug and Play requirements. The expensive process of loading a .NET assembly is delayed until needed by the application.

In order to provide these features, POS for .NET depends on three different .NET attributes:

- **PosAssembly**
    This is a global, assembly-level attribute that tells **PosExplorer** that this is a POS for .NET assembly which contains one or more Service Objects. Generally, it should be set in your **AssemblyInfo.cs** source file. For an example, see [Setting up a Service Object Project](setting-up-a-service-object-project.md).
- **ServiceObject**
    This attribute is applied to the Service Object class and specifies the type, name, and version information for the Service Object. See the [Creating a Basic Service Object Code Template](creating-a-basic-service-object-code-template.md) section for an example.
- **HardwareId**
    This attribute is used to specify which hardware IDs will be used by this Service Object. This information is used by **PosExplorer** to filter out Service Objects that use Plug and Play hardware which is not currently plugged in. The **HardwareId** attribute allows multiples, so there may be several attached to a Server Object class. See the sample topic [Adding Plug and Play Support](adding-plug-and-play-support.md) for an example. For a more lengthy discussion of Plug and Play features, including how the **HardwareId** attribute is utilized, see the topics [Adding Plug and Play Support](adding-plug-and-play-support.md) and POS for .NET [POS for .NET Integration with Plug and Play](pos-for-net-integration-with-plug-and-play.md).

## See Also

#### Reference

- <xref:Microsoft.PointOfService.PosAssemblyAttribute>
- <xref:Microsoft.PointOfService.HardwareIdAttribute>
- <xref:Microsoft.PointOfService.ServiceObjectAttribute>

#### Concepts

- [Plug and Play Support](plug-and-play-support.md)
- [POS for .NET Registry Settings](pos-for-net-registry-settings.md)

#### Other Resources

- [POS for .NET Service Object Architecture](pos-for-net-service-object-architecture.md)
- [System Configuration](system-configuration.md)
- [Service Object Samples: Getting Started](service-object-samples-getting-started.md)
