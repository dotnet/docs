---
title: Developing a Custom Service Object
description: Developing a Custom Service Object (POS for .NET v1.14 SDK Documentation)
ms.date: 02/27/2008
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Developing a Custom Service Object (POS for .NET v1.14 SDK Documentation)

The POS for .NET SDK delivers support for developing UPOS-compliant applications. The POS for .NET class tree delivers support for both applications that use a specific UPOS device, and Service Objects which provide the link between the physical hardware and the application.

Service Objects are typically implemented by independent hardware vendors (IHVs) to provide an interface between POS for .NET applications and the IHVs particular UPOS device. The POS for .NET SDK includes a set of .NET classes which you can use to create fully functional, UPOS-compliant Service Objects. By taking advantage of the POS for .NET SDK classes, you can write Service Objects quickly and with relatively little device-specific code.

## In This Section

- [POS for .NET Service Object Architecture](pos-for-net-service-object-architecture.md)
    Presents an overview of the POS for .NET architecture used for building custom Service Objects.

- [System Configuration](system-configuration.md)
    Provides information about settings and configuration for POS for .NET installations.

- [Service Object Samples: Getting Started](service-object-samples-getting-started.md)
    Provides a step-by-step guide to creating a functional, multithreaded Service Object.

- [Developing Service Objects Using Base Classes](developing-service-objects-using-base-classes.md)
    POS for .NET includes a nearly complete Base class implementation for nine POS device types. This section explains how to use these classes as a foundation for device-specific Service Objects.

- [Device Input and Events](device-input-and-events.md)
    Explains how events are used to send input from the POS device to the application.

- [Device Output Models](device-output-models.md)
    Explains the difference between synchronous and asynchronous output to POS devices.

- [Asynchronous Output Sample](asynchronous-output-sample.md)
    Implements a simple <xref:Microsoft.PointOfService.BaseServiceObjects.PosPrinterBase> Service Object in order to demonstrate how POS for .NET manages asynchronous output.

- [Statistics Sample](statistics-sample.md)
    Implements a sample Service Object that uses the POS for .NET statistics methods.

- [Base Class DirectIO Method](base-class-directio-method.md)
    Explains how Service Objects can implement the method **DirectIO** to provide access to manufacturer-specific data to the application.

- [Capability Properties](capability-properties.md)
    Demonstrates how certain properties, such as capability properties, are set by the Service Object.

## Related Sections

- [POS for .NET v1.14 Features](pos-for-net-v1141-features.md)
    Provides a high-level overview of the POS for .NET system.

- [Developing a POS Application](developing-a-pos-application.md)
    Provides details for creating a POS application using POS for .NET.

- [POS Device Manager](pos-device-manager.md)
    Describes using POS Device Manager to configure a POS for .NET installation.
