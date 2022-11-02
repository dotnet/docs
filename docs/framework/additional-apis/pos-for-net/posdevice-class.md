---
title: PosDevice Class
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# PosDevice Class (POS for .NET v1.14 SDK Documentation)

The **PosDevice** class represents a single physical POS device. The class provides properties and methods that are needed to manage that physical device.

## Properties

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<thead>
<tr class="header">
<th><strong>Name</strong></th>
<th><strong>Description</strong></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><strong>Type</strong></p></td>
<td><p>String representation of the POS device type or category.</p></td>
</tr>
<tr class="even">
<td><p><strong>SoName</strong></p></td>
<td><p>The name of the Service Object for this physical device, in string format.</p></td>
</tr>
<tr class="odd">
<td><p><strong>Path</strong></p></td>
<td><p>The hardware path of a device, in string format. For Plug and Play devices, this path comes from the Plug and Play engine. For non-Plug and Play devices, it is provided via the <strong>AddDevice</strong> method of <strong>ServiceObject</strong>. For devices using legacy (OPOS) Service Objects, this may be blank.</p></td>
</tr>
<tr class="even">
<td><p><strong>HardwareDescription</strong></p></td>
<td><p>The device description of the logical device, returned from the registry in string format and used by the Plug and Play engine. This may be blank for devices using legacy (OPOS) Service Objects.</p></td>
</tr>
<tr class="odd">
<td><p><strong>IsPlugNPlay</strong></p></td>
<td><p>A Boolean indicator of whether the device supports Plug and Play.</p></td>
</tr>
<tr class="even">
<td><p><strong>IsLegacy</strong></p></td>
<td><p>A Boolean indicator of whether the device is using a legacy (OPOS) Service Object.</p></td>
</tr>
<tr class="odd">
<td><p><strong>Enabled</strong></p></td>
<td><p>A Boolean representation of whether the device is enabled or not. This property allows write access.</p></td>
</tr>
<tr class="even">
<td><p><strong>Default</strong></p></td>
<td><p>A Boolean representation of whether the device is the default device in a POS device category. This property allows write access.</p></td>
</tr>
</tbody>
</table>

## Methods

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
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
<p>Accepts one string parameter, <em>Name</em>, which is the name of the logical device to add. The name must be unique within a device class (type). There is no returned value.</p>
<p>Logical names are represented by the <strong>LogicalDevice</strong> class.</p></td>
</tr>
<tr class="even">
<td><p><strong>Deletename</strong></p></td>
<td><p>Deletes the logical name from the device.</p>
<p>Accepts one string parameter, <em>Name</em>, which is the name of the logical device to delete. There is no returned value.</p>
<p>Logical names are represented by the <strong>LogicalDevice</strong> class.</p></td>
</tr>
<tr class="odd">
<td><p><strong>AddProperty</strong></p></td>
<td><p>Adds a property (a name/value pair) to this device.</p>
<p>Accepts two string parameters, <em>Name</em>, which is the name of the property, and <em>Value</em>, which is the value of the property. There is no returned value.</p>
<p>Device properties are represented by the <strong>Property</strong> class.</p></td>
</tr>
<tr class="even">
<td><p><strong>DeleteProperty</strong></p></td>
<td><p>Deletes a property from this device.</p>
<p>Accepts one string parameter, <em>Name</em>, which is the name of the property to be deleted. There is no return value.</p>
<p>Device properties are represented by the <strong>Property</strong> class.</p></td>
</tr>
</tbody>
</table>

## See Also

#### Tasks

[Using VBScript to Manage Devices](using-vbscript-to-manage-devices.md)

#### Other Resources

[Using the WMI API to Manage Devices](using-the-wmi-api-to-manage-devices.md)
