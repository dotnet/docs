---
title: LogicalDevice Class
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# LogicalDevice Class (POS for .NET v1.14 SDK Documentation)

The **LogicalDevice** class represents a logical device associated with a **PosDevice**. It provides a naming mechanism so that applications can be developed independently and refers to the same device without conflict.

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
<td><p>String representing the POS device category that the logical device belongs to.</p></td>
</tr>
<tr class="even">
<td><p><strong>SoName</strong></p></td>
<td><p>String representing the name of the Service Object.</p></td>
</tr>
<tr class="odd">
<td><p><strong>Path</strong></p></td>
<td><p>String representing the path of the physical device.</p></td>
</tr>
<tr class="even">
<td><p><strong>Name</strong></p></td>
<td><p>String representing the name for the logical device.</p></td>
</tr>
</tbody>
</table>

## See Also

#### Tasks

[Using VBScript to Manage Devices](using-vbscript-to-manage-devices.md)

#### Other Resources

[Using the WMI API to Manage Devices](using-the-wmi-api-to-manage-devices.md)
