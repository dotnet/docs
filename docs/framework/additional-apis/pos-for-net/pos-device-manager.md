---
title: POS Device Manager
description: POS Device Manager (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# POS Device Manager (POS for .NET v1.14 SDK Documentation)

With Microsoft Point of Service for .NET (POS for .NET), you can manage your POS devices in various ways, including:

- Adding and deleting POS devices from computers (non-Plug and Play devices only).
- Listing POS devices and/or Service Objects for particular computers.
- Configuring a POS for .NET Service Object (SO) to run for a particular device port (non-Plug and Play devices only).
- Setting a default device for a POS device class.
- Preventing a Service Object from running for a device.
- Assigning a logical name by which a POS application can access the Service Object for a device.

POS devices are managed via a Windows Management Instrumentation (WMI) provider installed on the POS device host as part of the POS for .NET installation. Instructions in this Guide assume that you have already installed POS for .NET.

You can access this WMI provider through the WMI API or by using the command-line tool included in POS for .NET, POSDM.EXE.

## In This Section

- [Configure a device for remote management](configure-a-device-for-remote-management.md)
    Describes how you can configure devices to enable remote management.

- [Using the WMI API to Manage Devices](using-the-wmi-api-to-manage-devices.md)
    Describes how to use WMI tools to manage your POS devices.

- [Using Visual Studio .NET Management Extensions and the POS for .NET WMI Management Classes](using-visual-studio-net-management-extensions-and-the-pos-for-net-wmi-management-classes.md)
    Describes how to use Microsoft Visual Studio 2013 and the POS for .NET WMI management classes with your POS devices.

- [Using the POS Device Manager Command-Line Tool](using-the-pos-device-manager-command-line-tool.md)
    Demonstrates how to use the POSDM command line to enable remote device management.

## Related Sections

- [POS for .NET v1.14 Features](pos-for-net-v1141-features.md)
    Provides a high-level overview of the Microsoft Point of Service for .NET (POS for .NET) architecture.

- [Developing a POS Application](developing-a-pos-application.md)
    Outlines POS for .NET key concepts and features that are useful to programmers developing POS applications.

- [Developing a Custom Service Object](developing-a-custom-service-object.md)
    Demonstrates how to create POS for .NET applications which use Service Objects to communicate with hardware devices.
