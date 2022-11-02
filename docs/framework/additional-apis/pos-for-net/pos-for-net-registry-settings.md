---
title: POS for .NET Registry Settings
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# POS for .NET Registry Settings (POS for .NET v1.14 SDK Documentation)

Microsoft Point of Service for .NET (POS for .NET) stores certain configuration information in the system registry. During installation, default values are written to the registry. The POS for .NET values are stored under the key **\\HKLM\\SOFTWARE\\POSfor.NET**. Below is a list of registry keys and their values that POS for .NET uses.

## POSfor.NET Key

This key contains the following values.

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<thead>
<tr class="header">
<th>Name</th>
<th>Description</th>
<th>Data Type</th>
<th>Default value</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><strong>Configuration</strong></p></td>
<td><p>Name of the configuration file written by the POS Device Manager.</p></td>
<td><p>REG_SZ</p></td>
<td><p>C:\Documents and Settings\All Users\Application Data\Microsoft\Point Of Service\Configuration\Configuration.xml</p></td>
</tr>
<tr class="even">
<td><p><strong>StatisticsFile</strong></p></td>
<td><p>Name of the file used to record POS for .NET statistics.</p></td>
<td><p>REG_SZ</p></td>
<td><p>C:\Documents and Settings\All Users\Application Data\Microsoft\Point Of Service\Statistics\PosDeviceStatistics.xml</p></td>
</tr>
</tbody>
</table>

The **POSfor.NET** registry key has three subkeys:

- ControlAssemblies
- ControlConfigs
- Logging

## POSfor.NET\\ControlAssemblies Key

This key may contain any number of values of type REG\_SZ, each of which contains the name of a directory. [PosExplorer](ms884843\(v=winembedded.11\).md) will iterate through the entire list of values, searching each directory. Therefore, the names of the values are not important.

These values will need to be modified during system configuration so that they point to the locations appropriate for the specific requirements of the installation.

The following table shows the default values that are written during the POS for .NET SDK setup process.

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<thead>
<tr class="header">
<th>Name</th>
<th>Default Values</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>(Default)</p></td>
<td><p>C:\Program Files\Common Files\Microsoft Shared\Point Of Service\Control Assemblies\</p></td>
</tr>
<tr class="even">
<td><p><strong>ExampleSOs</strong></p></td>
<td><p>C:\Program Files\Microsoft Point Of Service\SDK\Samples\Example Service Objects\</p></td>
</tr>
<tr class="odd">
<td><p><strong>Simulators</strong></p></td>
<td><p>C:\Program Files\Microsoft Point Of Service\SDK\Samples\Simulator Service Objects\</p></td>
</tr>
</tbody>
</table>

## POSfor.NET\\ControlConfigs Key

In most cases, POS devices are paired with specific Service Objects using the [HardwareId](aa460209\(v=winembedded.11\).md) attribute, but in some rare situations, a Service Object provider may need the ability to assign a different device to a Service Object without redistributing the entire assembly.

To accommodate these situations, POS for .NET supports the ability to associate the device to a Service Object in a [Plug and Play XML Configuration](plug-and-play-xml-configuration.md) file.

This key contains a value which points to the location of these Plug and Play configuration files.

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<thead>
<tr class="header">
<th>Name</th>
<th>Default Value</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>(Default)</p></td>
<td><p>C:\Program Files\Common Files\Microsoft Shared\Point Of Service\Control Configurations\</p></td>
</tr>
</tbody>
</table>

## POSfor.NET\\Logging Key

This key contains values which dictate how POS for .NET handles log files. Both POS for .NET and applications, using the [Logger](ms884546\(v=winembedded.11\).md) object, may write to the log file.

The following table shows the values of this key.

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<thead>
<tr class="header">
<th>Name</th>
<th>Description</th>
<th>Data Type</th>
<th>Default</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><strong>Enabled</strong></p></td>
<td><p>Set to <strong>true</strong> if logging is enabled.</p></td>
<td><p>REG_DWORD</p></td>
<td><p>0 (not enabled)</p></td>
</tr>
<tr class="even">
<td><p><strong>Location</strong></p></td>
<td><p>The location where the log files will be written.</p></td>
<td><p>REG_SZ</p></td>
<td><p>%TEMP%</p></td>
</tr>
<tr class="odd">
<td><p><strong>MaxLogFileSizeMB</strong></p></td>
<td><p>The maximum allowed log size, in megabytes.</p></td>
<td><p>REG_DWORD</p></td>
<td><p>10</p></td>
</tr>
<tr class="even">
<td><p><strong>Name</strong></p></td>
<td><p>The <strong>Base</strong> name of the log file. Date and time information follows the file name. The .txt extension is appended.</p></td>
<td><p>REG_SZ</p></td>
<td><p>CCL</p></td>
</tr>
</tbody>
</table>

## See Also

#### Reference

[Logger](ms884546\(v=winembedded.11\).md)

#### Concepts

[Log Files](log-files.md)
[Plug and Play XML Configuration](plug-and-play-xml-configuration.md)
[Plug and Play Support](plug-and-play-support.md)

#### Other Resources

[System Configuration](system-configuration.md)
