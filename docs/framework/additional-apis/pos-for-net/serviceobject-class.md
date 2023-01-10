---
title: ServiceObject Class
description: ServiceObject Class (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# ServiceObject Class (POS for .NET v1.14 SDK Documentation)

The **ServiceObject** class represents the management view of a Service Object.

## Properties

| Name          | Description                                                                                       |
|---------------|---------------------------------------------------------------------------------------------------|
| Name          | Represents the name of the Service Object in string format.                                       |
| Type          | Represents the type of the POS device class that is implemented by the Service Object.            |
| UposVersion   | Represents version of the UPOS standard that the Service Object is implementing in string format. |
| Path          | Represents the path of the Service Object’s assembly as a string.                                 |
| Version       | The version number of the Service Object’s assembly in string format.                             |
| Compatibility | The major version of POS for .NET with which the Service Object is compatible.                    |
| Description   | A short string describing the Service Object.                                                     |
| IsPlugNPlay   | A Boolean indicator of whether the Service Object supports Plug and Play.                         |
| IsLegacy      | A Boolean indicator of whether the device is using a legacy (OPOS) Service Object.                |

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
<!-- markdownlint-enable MD033 -->

## See Also

#### Tasks

- [Using VBScript to Manage Devices](using-vbscript-to-manage-devices.md)

#### Other Resources

- [Using the WMI API to Manage Devices](using-the-wmi-api-to-manage-devices.md)
