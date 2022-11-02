---
title: ServiceObject Class
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# ServiceObject Class (POS for .NET v1.14 SDK Documentation)

The **ServiceObject** class represents the management view of a Service Object.

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
<td><p><strong>Name</strong></p></td>
<td><p>Represents the name of the Service Object in string format.</p></td>
</tr>
<tr class="even">
<td><p><strong>Type</strong></p></td>
<td><p>Represents the type of the POS device class that is implemented by the Service Object.</p></td>
</tr>
<tr class="odd">
<td><p><strong>UposVersion</strong></p></td>
<td><p>Represents version of the UPOS standard that the Service Object is implementing in string format.</p></td>
</tr>
<tr class="even">
<td><p><strong>Path</strong></p></td>
<td><p>Represents the path of the Service Object’s assembly as a string.</p></td>
</tr>
<tr class="odd">
<td><p><strong>Version</strong></p></td>
<td><p>The version number of the Service Object’s assembly in string format.</p></td>
</tr>
<tr class="even">
<td><p><strong>Compatibility</strong></p></td>
<td><p>The major version of POS for .NET with which the Service Object is compatible.</p></td>
</tr>
<tr class="odd">
<td><p><strong>Description</strong></p></td>
<td><p>A short string describing the Service Object.</p></td>
</tr>
<tr class="even">
<td><p><strong>IsPlugNPlay</strong></p></td>
<td><p>A Boolean indicator of whether the Service Object supports Plug and Play.</p></td>
</tr>
<tr class="odd">
<td><p><strong>IsLegacy</strong></p></td>
<td><p>A Boolean indicator of whether the device is using a legacy (OPOS) Service Object.</p></td>
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
<td><p><strong>AddDevice</strong></p></td>
<td><p>Adds a non-Plug and Play device for this Service Object.</p>
<p>Accepts one string parameter, Path, which is the hardware path of the non-Plug and Play device to add. There is no return value.</p></td>
</tr>
<tr class="even">
<td><p><strong>DeleteDevice</strong></p></td>
<td><p>Deletes a non-Plug and Play device associated with this Service Object.</p>
<p>Accepts one string parameter, Path, which is the hardware path of the non-Plug and Play device to delete. There is no return value.</p></td>
</tr>
</tbody>
</table>

## See Also

#### Tasks

[Using VBScript to Manage Devices](using-vbscript-to-manage-devices.md)

#### Other Resources

[Using the WMI API to Manage Devices](using-the-wmi-api-to-manage-devices.md)
