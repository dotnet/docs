---
title: PosDevice Class
description: PosDevice Class (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# PosDevice Class (POS for .NET v1.14 SDK Documentation)

The **PosDevice** class represents a single physical POS device. The class provides properties and methods that are needed to manage that physical device.

## Properties

| Name                | Description                                                                                                                                                                                                                                                                             |
|---------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Type                | String representation of the POS device type or category.                                                                                                                                                                                                                               |
| SoName              | The name of the Service Object for this physical device, in string format.                                                                                                                                                                                                              |
| Path                | The hardware path of a device, in string format. For Plug and Play devices, this path comes from the Plug and Play engine. For non-Plug and Play devices, it is provided via the AddDevice method of ServiceObject. For devices using legacy (OPOS) Service Objects, this may be blank. |
| HardwareDescription | The device description of the logical device, returned from the registry in string format and used by the Plug and Play engine. This may be blank for devices using legacy (OPOS) Service Objects.                                                                                      |
| IsPlugNPlay         | A Boolean indicator of whether the device supports Plug and Play.                                                                                                                                                                                                                       |
| IsLegacy            | A Boolean indicator of whether the device is using a legacy (OPOS) Service Object.                                                                                                                                                                                                      |
| Enabled             | A Boolean representation of whether the device is enabled or not. This property allows write access.                                                                                                                                                                                    |
| Default             | A Boolean representation of whether the device is the default device in a POS device category. This property allows write access.                                                                                                                                                       |

## Methods

<!-- markdownlint-disable MD033 -->
<table>
<colgroup>
<col />
<col />
</colgroup>
<thead>
<tr class="header">
<th><strong>Name</strong></th>
<th><strong>Description</strong></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><strong>AddName</strong></p></td>
<td><p>Adds a logical name for the device.</p>
<p>Accepts one string parameter, *Name*, which is the name of the logical device to add. The name must be unique within a device class (type). There is no returned value.</p>
<p>Logical names are represented by the <strong>LogicalDevice</strong> class.</p></td>
</tr>
<tr class="even">
<td><p><strong>Deletename</strong></p></td>
<td><p>Deletes the logical name from the device.</p>
<p>Accepts one string parameter, *Name*, which is the name of the logical device to delete. There is no returned value.</p>
<p>Logical names are represented by the <strong>LogicalDevice</strong> class.</p></td>
</tr>
<tr class="odd">
<td><p><strong>AddProperty</strong></p></td>
<td><p>Adds a property (a name/value pair) to this device.</p>
<p>Accepts two string parameters, *Name*, which is the name of the property, and *Value*, which is the value of the property. There is no returned value.</p>
<p>Device properties are represented by the <strong>Property</strong> class.</p></td>
</tr>
<tr class="even">
<td><p><strong>DeleteProperty</strong></p></td>
<td><p>Deletes a property from this device.</p>
<p>Accepts one string parameter, *Name*, which is the name of the property to be deleted. There is no return value.</p>
<p>Device properties are represented by the <strong>Property</strong> class.</p></td>
</tr>
</tbody>
</table>
<!-- markdownlint-enable MD033 -->

## See Also

#### Tasks

- [Using VBScript to Manage Devices](using-vbscript-to-manage-devices.md)

#### Other Resources

- [Using the WMI API to Manage Devices](using-the-wmi-api-to-manage-devices.md)
