---
title: PosCommon Class (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# PosCommon Class (POS for .NET v1.14 SDK Documentation)

[PosCommon](ms884820\(v=winembedded.11\).md) is the **Base** class for all specific **Interface** classes, and all Service Objects indirectly derive from it. **PosCommon** defines the common properties, methods, and events that the Unified Point Of Service (UnifiedPOS) specification requires in all device classes.

## PosCommon Properties

The following table describes the properties of the **PosCommon** class available to POS applications.

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
<td><p><a href="ms861088(v=winembedded.11).md">CapCompareFirmwareVersion</a></p></td>
<td><p>bool</p></td>
<td><p>Indicates whether the Service Object and device supports comparing the firmware version in the physical device against that of a firmware file.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms861089(v=winembedded.11).md">CapPowerReporting</a></p></td>
<td><p>PowerReporting enum</p></td>
<td><p>Indicates the power reporting capabilities of the device.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms861090(v=winembedded.11).md">CapStatisticsReporting</a></p></td>
<td><p>bool</p></td>
<td><p>Indicates whether the device can accumulate and can provide various statistics regarding usage.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms861092(v=winembedded.11).md">CapUpdateStatistics</a></p></td>
<td><p>bool</p></td>
<td><p>If set to <strong>true</strong>, some or all of the device statistics can be reset to 0 (zero) using the <strong>ResetStatistic</strong> method for one update and <strong>ResetStatistics</strong> method for a list of updates, or updated using the <strong>UpdateStatistic</strong> method for one update and the <strong>UpdateStatistics</strong> method for a list of updates with the corresponding specified values.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms861091(v=winembedded.11).md">CapUpdateFirmware</a></p></td>
<td><p>bool</p></td>
<td><p>Indicates whether the device's firmware can be updated via the <a href="ms843041(v=winembedded.11).md">UpdateFirmware</a> method.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms861093(v=winembedded.11).md">CheckHealthText</a></p></td>
<td><p>string</p></td>
<td><p>Indicates the health of the device.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms861094(v=winembedded.11).md">Claimed</a></p></td>
<td><p>bool</p></td>
<td><p>Indicates whether the device is claimed for exclusive access.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms861095(v=winembedded.11).md">DeviceDescription</a></p></td>
<td><p>string</p></td>
<td><p>Holds a string identifying the device and the company that manufactured it.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms861096(v=winembedded.11).md">DeviceEnabled</a></p></td>
<td><p>bool</p></td>
<td><p>Indicates whether the device is in an operational state.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms861097(v=winembedded.11).md">DeviceName</a></p></td>
<td><p>string</p></td>
<td><p>UnifiedPOS calls it <strong>PhysicalDeviceName</strong>; OLE for Retail POS (OPOS) calls it <strong>DeviceName</strong>.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms861098(v=winembedded.11).md">DevicePath</a></p></td>
<td><p>string</p></td>
<td><p>Set by POS for .NET for Plug and Play devices. For non-Plug and Play devices, <strong>DevicePath</strong> can be assigned using a configuration file.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms861099(v=winembedded.11).md">FreezeEvents</a></p></td>
<td><p>bool</p></td>
<td><p>When set to <strong>true</strong>, the application has requested that the Service Object not deliver events.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms861100(v=winembedded.11).md">PowerNotify</a></p></td>
<td><p>PowerNotification enum</p></td>
<td><p>Holds the type of power notification selection made by the application.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms861101(v=winembedded.11).md">PowerState</a></p></td>
<td><p>PowerState enum</p></td>
<td><p>Holds the current power condition.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms861102(v=winembedded.11).md">ServiceObjectDescription</a></p></td>
<td><p>string</p></td>
<td><p>Identifies the Service Object supporting the device and the company that produced it. This property is listed as <strong>DeviceServiceDescription</strong> in the UnifiedPOS specification.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms861103(v=winembedded.11).md">ServiceObjectVersion</a></p></td>
<td><p>System.Version</p></td>
<td><p>Holds the Service Object version number. This property is listed as <strong>DeviceServiceVersion</strong> in the UnifiedPOS specification.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms861104(v=winembedded.11).md">State</a></p></td>
<td><p>ControlState enum</p></td>
<td><p>Holds the current state of the device.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms861105(v=winembedded.11).md">SynchronizingObject</a></p></td>
<td><p>ISynchronizeInvoke</p></td>
<td><p>Gets or sets the marshalling object for event handler calls from a POS event.</p></td>
</tr>
</tbody>
</table>

## PosCommon Methods

The following table describes the methods of the **PosCommon** class available to applications.

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
<td><p><a href="ms843022(v=winembedded.11).md">CheckHealth</a></p></td>
<td><p>string</p></td>
<td><p>Performs a health check on the device. The type of check to be performed is indicated by the <a href="ms884527(v=winembedded.11).md">HealthCheckLevel</a> parameter. The method also updates the <strong>CheckHealthText</strong> property.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms843023(v=winembedded.11).md">Claim</a></p></td>
<td><p>void</p></td>
<td><p>Requests exclusive access to the device.</p>
<p>Service Object writers are advised to only throw exceptions in unexpected conditions; for example, <strong>OutOfMemory</strong>. Otherwise, Service Objects should return <strong>True</strong> if the device was claimed and <strong>False</strong> if a time-out occurred.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms843024(v=winembedded.11).md">Close</a></p></td>
<td><p>void</p></td>
<td><p>Releases the device and its resources.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms843025(v=winembedded.11).md">CompareFirmwareVersion</a></p></td>
<td><p>CompareFirmwareResult</p></td>
<td><p>Determines whether the version of the specified firmware is newer than, older than, or the same as the version of firmware in the physical device.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms843027(v=winembedded.11).md">DirectIO</a></p></td>
<td><p>DirectIOData</p></td>
<td><p>Used to communicate directly with the Service Object.</p>
<p>In the UnifiedPOS specification, it has two in/out parameters. As used by POS for .NET, this method returns a structure and no in/out parameters.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms843030(v=winembedded.11).md">Open</a></p></td>
<td><p>void</p></td>
<td><p>Opens a device for subsequent input/output processing.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms843031(v=winembedded.11).md">Release</a></p></td>
<td><p>void</p></td>
<td><p>Releases exclusive access to the device.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms843035(v=winembedded.11).md">ResetStatistic</a></p></td>
<td><p>void</p></td>
<td><p>Resets the specified statistic to zero.</p>
<p>Used in POS for .NET for operations on a single statistic.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms843034(v=winembedded.11).md">ResetStatistics</a></p></td>
<td><p>void</p></td>
<td><p>Resets all statistics for a specified category to 0 (zero).</p></td>
</tr>
<tr class="even">
<td><p><a href="ms843033(v=winembedded.11).md">ResetStatistics</a></p></td>
<td><p>void</p></td>
<td><p>Resets the specified statistics to 0 (zero).</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms843032(v=winembedded.11).md">ResetStatistics</a></p></td>
<td><p>void</p></td>
<td><p>Resets all statistics associated with a device to 0 (zero).</p></td>
</tr>
<tr class="even">
<td><p><a href="ms843039(v=winembedded.11).md">RetrieveStatistic</a></p></td>
<td><p>string</p></td>
<td><p>Retrieves the specified device statistic.</p>
<p>Used in POS for .NET for operations on a single statistic.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms843036(v=winembedded.11).md">RetrieveStatistics</a></p></td>
<td><p>string</p></td>
<td><p>Retrieves all device statistics.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms843038(v=winembedded.11).md">RetrieveStatistics</a></p></td>
<td><p>void</p></td>
<td><p>Retrieves the statistics for the specified category.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms843037(v=winembedded.11).md">RetrieveStatistics</a></p></td>
<td><p>void</p></td>
<td><p>Retrieves the specified statistics.</p></td>
</tr>
<tr class="even">
<td><p><strong>UpdateFirmware</strong></p></td>
<td><p>void</p></td>
<td><p>Updates the firmware of a device with the version of the firmware contained in the specified filename.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms843044(v=winembedded.11).md">UpdateStatistic</a></p></td>
<td><p>void</p></td>
<td><p>Updates a statistic.</p>
<p>Added to POS for .NET for operations on a single statistic.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms843042(v=winembedded.11).md">UpdateStatistics</a></p></td>
<td><p>void</p></td>
<td><p>Updates a list of statistics with the corresponding specified values.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms843043(v=winembedded.11).md">UpdateStatistics</a></p></td>
<td><p>void</p></td>
<td><p>Updates the specified category of statistics with the specified value.</p></td>
</tr>
</tbody>
</table>

## PosCommon Events

The following table describes the **PosCommon** class events.

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<thead>
<tr class="header">
<th>Method</th>
<th>Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><a href="ms831426(v=winembedded.11).md">DirectIOEvent</a></p></td>
<td><p>Raised by the Service Object to communicate information directly to the application.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms831427(v=winembedded.11).md">StatusUpdateEvent</a></p></td>
<td><p>Raised by the Service Object to alert the application of a device status change.</p></td>
</tr>
</tbody>
</table>

## Example

The following code example demonstrates how to use the properties and methods common to all Service Objects to display information about a connected device.

```
    // Create a dervied class of PosCommon
    public class PosCommonSample: PosCommon
    {
        // Implement all base methods and properties.
        // ...
    }

    // Create instances for the example.
    PosExplorer explorer = new PosExplorer();
    PosCommonSample pcs = new PosCommonSample();
    DeviceInfo device = explorer.GetDevice("MSR");
    pcs = (PosCommonSample)explorer.CreateInstance(device);

    // Open and claim the device, then print information
    // about the device to the console.
    pcs.Open();
    pcs.Claim(1000);
    Console.WriteLine("Name: {0}", pcs.DeviceName);
    Console.WriteLine("Description: {0}", pcs.DeviceDescription);
    Console.WriteLine("Path: {0}", pcs.DevicePath);
    Console.WriteLine("Enabled: {0}", pcs.DeviceEnabled);

    pcs.Close();
```

## See Also

#### Concepts

[POS for .NET Class Tree](pos-for-net-class-tree.md)
