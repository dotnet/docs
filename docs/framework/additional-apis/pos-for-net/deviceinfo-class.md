---
title: DeviceInfo Class
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# DeviceInfo Class (POS for .NET v1.14 SDK Documentation)

The [DeviceInfo](ms884041\(v=winembedded.11\).md) class supplies Microsoft Point of Service for .NET (POS for .NET) applications with information about POS devices and the Service Objects associated with them. The [PosExplorer](ms884843\(v=winembedded.11\).md) methods, [GetDevice](ms843054\(v=winembedded.11\).md) and [GetDevices](ms843049\(v=winembedded.11\).md) return instances of **DeviceInfo**.

## DeviceInfo Properties

The following table shows the **DeviceInfo** properties.

<table>
<colgroup>
<col style="width: 33%" />
<col style="width: 33%" />
<col style="width: 33%" />
</colgroup>
<thead>
<tr class="header">
<th>Property</th>
<th>Type</th>
<th>Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><a href="aa460206(v=winembedded.11).md">Compatibility</a></p></td>
<td><p><a href="ms884035(v=winembedded.11).md">DeviceCompatibilities</a></p></td>
<td><p>Lists the valid compatibility levels for a POS device (an OLE for Retail POS (OPOS) or .NET Service Object).</p></td>
</tr>
<tr class="even">
<td><p><a href="aa460207(v=winembedded.11).md">Description</a></p></td>
<td><p>string</p></td>
<td><p>Describes the Service Object.</p></td>
</tr>
<tr class="odd">
<td><p><a href="aa460208(v=winembedded.11).md">HardwareDescription</a></p></td>
<td><p>string</p></td>
<td><p>Describes the physical device.</p></td>
</tr>
<tr class="even">
<td><p><a href="aa460209(v=winembedded.11).md">HardwareId</a></p></td>
<td><p>string</p></td>
<td><p>Provides the ID of the physical device.</p></td>
</tr>
<tr class="odd">
<td><p><a href="aa460210(v=winembedded.11).md">HardwarePath</a></p></td>
<td><p>string</p></td>
<td><p>Provides the physical hardware path of the device.</p></td>
</tr>
<tr class="even">
<td><p><a href="aa460211(v=winembedded.11).md">IsDefault</a></p></td>
<td><p>bool</p></td>
<td><p>Returns <strong>true</strong> if the device is the default for its type.</p></td>
</tr>
<tr class="odd">
<td><p><a href="aa460212(v=winembedded.11).md">LogicalNames</a></p></td>
<td><p>strings[]</p></td>
<td><p>Provides the alternative name(s) assigned to the device in the global configuration fileby POS Device Manager (POSDM).</p></td>
</tr>
<tr class="even">
<td><p><a href="aa460213(v=winembedded.11).md">ManufacturerName</a></p></td>
<td><p>string</p></td>
<td><p>Provides the physical device manufacturer name.</p></td>
</tr>
<tr class="odd">
<td><p><a href="aa460214(v=winembedded.11).md">ServiceObjectName</a></p></td>
<td><p>string</p></td>
<td><p>Provides the name of the Service Object.</p></td>
</tr>
<tr class="even">
<td><p><a href="aa460215(v=winembedded.11).md">ServiceObjectVersion</a></p></td>
<td><p>Version</p></td>
<td><p>Provides the Service Object version.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms884045(v=winembedded.11).md">DeviceType</a></p></td>
<td><p>string</p></td>
<td><p>Provides the physical device type.</p></td>
</tr>
<tr class="even">
<td><p><a href="aa460217(v=winembedded.11).md">UposVersion</a></p></td>
<td><p>Version</p></td>
<td><p>Provides the UPOS version number.</p></td>
</tr>
</tbody>
</table>

## DeviceInfo Methods

The following table shows the **DeviceInfo** methods.

<table>
<colgroup>
<col style="width: 33%" />
<col style="width: 33%" />
<col style="width: 33%" />
</colgroup>
<thead>
<tr class="header">
<th>Method</th>
<th>Return Type</th>
<th>Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><a href="ms842196(v=winembedded.11).md">IsDeviceInfoOf</a></p></td>
<td><p>bool</p></td>
<td><p>Returns <strong>true</strong> if the Service Object corresponds to the <strong>DeviceInfo</strong> class properties.</p></td>
</tr>
<tr class="even">
<td><p><a href="bb412014(v=winembedded.11).md">ToString</a></p></td>
<td><p>string</p></td>
<td><p>Returns a string that describes the properties of the device.</p></td>
</tr>
</tbody>
</table>

## Populating DeviceInfo Properties

The following table provides the sources for the information used by the **PosExplorer** methods **GetDevice(System.String)**, and **GetDevices** when populating and returning instances of **DeviceInfo**. The table describes how **PosExplorer** populates **DeviceInfo** properties for three types of devices:

- POS for .NET devices using Plug and Play
- POS for .NET devices that are not using Plug and Play
- Legacy OPOS devices

Numbered lists show the sequence in which information sources are accessed. Iteration through the sequence stops when the sought-after data is first acquired.

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<thead>
<tr class="header">
<th>DeviceInfo Property</th>
<th>Information Source(s) for POS for .NET Plug and Play Devices</th>
<th>Information Source(s) for POS for .NET Non-Plug and Play Devices</th>
<th>Information Source(s) for Legacy OPOS Devices</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><strong>Compatibility</strong></p></td>
<td><p><strong>PosExplorer</strong> sets to <strong>CompatibilityLevel1</strong>.</p></td>
<td><p><strong>PosExplorer</strong> sets to <strong>CompatibilityLevel1</strong>.</p></td>
<td><p><strong>PosExplorer</strong> sets to <strong>Opos</strong>.</p></td>
</tr>
<tr class="even">
<td><p><strong>Description</strong></p></td>
<td><p><strong>ServiceObject</strong> attribute in a Service Object assembly.</p></td>
<td><p><strong>ServiceObject</strong> attribute in Service Object assembly.</p></td>
<td><ol>
<li>OPOS registry <strong>Description</strong> value under <strong>Device Name Key</strong>.<br />
</li>
<li>OPOS registry <strong>Device Name Key</strong> subkey under <strong>Device Class Key</strong>.<br />
</li>
</ol></td>
</tr>
<tr class="odd">
<td><p><strong>HardwareDescription</strong></p></td>
<td><p>Windows Plug and Play subsystem.</p></td>
<td><p>Blank.</p></td>
<td><p>Blank.</p></td>
</tr>
<tr class="even">
<td><p><strong>HardwareId</strong></p></td>
<td><ol>
<li><strong>HardwareId</strong> attribute in a Service Object assembly.<br />
</li>
<li>XML configuration file in location specified by the <strong>ControlConfigs</strong> registry key.<br />
</li>
</ol></td>
<td><p>Blank.</p></td>
<td><p>Blank.</p></td>
</tr>
<tr class="odd">
<td><p><strong>HardwarePath</strong></p></td>
<td><p>Windows Plug and Play subsystem.</p></td>
<td><ul>
<li>Blank, or<br />
</li>
<li>POS Device Manager (POSDM) global configuration file as specified by <strong>adddevice</strong> or <strong>setpath</strong>.<br />
</li>
</ul></td>
<td><p>Blank.</p></td>
</tr>
<tr class="even">
<td><p><strong>IsDefault</strong></p></td>
<td><p>POSDM global configuration file as specified by <strong>setdefault</strong>.</p></td>
<td><p>POSDM global configuration file as specified by <strong>setdefault</strong>.</p></td>
<td><p>POSDM global configuration file as specified by <strong>setdefault</strong>.</p></td>
</tr>
<tr class="odd">
<td><p><strong>LogicalNames</strong></p></td>
<td><p>POSDM global configuration file as specified by <strong>addname</strong>.</p></td>
<td><p>POSDM global configuration file as specified by <strong>addname</strong>.</p></td>
<td><ol>
<li>POSDM global configuration file as specified by <strong>addname</strong>.<br />
</li>
<li>The logical device name(s) as defined in the OPOS registry.<br />
</li>
</ol></td>
</tr>
<tr class="even">
<td><p><strong>ManufacturerName</strong></p></td>
<td><p><strong>PosAssembly</strong> attribute in a Service Object assembly.</p></td>
<td><p><strong>PosAssembly</strong> attribute in Service Object assembly.</p></td>
<td><p>Blank.</p></td>
</tr>
<tr class="odd">
<td><p><strong>ServiceObjectName</strong></p></td>
<td><p><strong>ServiceObject</strong> attribute in a Service Object assembly.</p></td>
<td><p><strong>ServiceObject</strong> attribute in Service Object assembly.</p></td>
<td><p>OPOS registry <strong>Device Name Key</strong> subkey under <strong>Device Class Key</strong>.</p></td>
</tr>
<tr class="even">
<td><p><strong>ServiceObjectVersion</strong></p></td>
<td><p>Service Object <strong>AssemblyVersion</strong> attribute.</p></td>
<td><p>Service Object <strong>AssemblyVersion</strong> attribute.</p></td>
<td><p>OPOS registry <strong>Version</strong> value under <strong>Device Name Key</strong>.</p></td>
</tr>
<tr class="odd">
<td><p><strong>DeviceType</strong></p></td>
<td><p><strong>ServiceObject</strong> attribute in a Service Object assembly.</p></td>
<td><p><strong>ServiceObject</strong> attribute in Service Object assembly.</p></td>
<td><p>OPOS registry <strong>Device Class Key</strong>.</p></td>
</tr>
<tr class="even">
<td><p><strong>UposVersion</strong></p></td>
<td><p><strong>ServiceObject</strong> attribute in a Service Object assembly.</p></td>
<td><p><strong>ServiceObject</strong> attribute in Service Object assembly.</p></td>
<td><p>OPOS registry <strong>Version</strong> value under <strong>Device Name Key</strong>.</p></td>
</tr>
</tbody>
</table>

## See Also

#### Concepts

[PosExplorer Class](posexplorer-class.md)
[Exception Classes](exception-classes.md)

#### Other Resources

[Developing a POS Application](developing-a-pos-application.md)
[POS for .NET API Support](pos-for-net-api-support.md)
[POS Device Manager](pos-device-manager.md)
