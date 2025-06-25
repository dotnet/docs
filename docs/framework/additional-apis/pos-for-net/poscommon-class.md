---
title: PosCommon Class (POS for .NET v1.14 SDK Documentation)
description: PosCommon Class (POS for .NET v1.14 SDK Documentation) (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# PosCommon Class (POS for .NET v1.14 SDK Documentation)

<xref:Microsoft.PointOfService.PosCommon> is the **Base** class for all specific **Interface** classes, and all Service Objects indirectly derive from it. **PosCommon** defines the common properties, methods, and events that the Unified Point Of Service (UnifiedPOS) specification requires in all device classes.

## PosCommon Properties

The following table describes the properties of the **PosCommon** class available to POS applications.

| Property | Type | Description |
|----------|------|-------------|
| CapCompareFirmwareVersion | bool | Indicates whether the Service Object and device supports comparing the firmware version in the physical device against that of a firmware file. |
| CapPowerReporting | PowerReporting enum | Indicates the power reporting capabilities of the device. |
| CapStatisticsReporting | bool | Indicates whether the device can accumulate and can provide various statistics regarding usage. |
| CapUpdateStatistics | bool | If set to true, some or all of the device statistics can be reset to 0 (zero) using the ResetStatistic method for one update and ResetStatistics method for a list of updates, or updated using the UpdateStatistic method for one update and the UpdateStatistics method for a list of updates with the corresponding specified values. |
| CapUpdateFirmware | bool | Indicates whether the device's firmware can be updated via the UpdateFirmware method. |
| CheckHealthText | string | Indicates the health of the device. |
| Claimed | bool | Indicates whether the device is claimed for exclusive access. |
| DeviceDescription | string | Holds a string identifying the device and the company that manufactured it. |
| DeviceEnabled | bool | Indicates whether the device is in an operational state. |
| DeviceName | string | UnifiedPOS calls it PhysicalDeviceName; OLE for Retail POS (OPOS) calls it DeviceName. |
| DevicePath | string | Set by POS for .NET for Plug and Play devices. For non-Plug and Play devices, DevicePath can be assigned using a configuration file. |
| FreezeEvents | bool | When set to true, the application has requested that the Service Object not deliver events. |
| PowerNotify | PowerNotification enum | Holds the type of power notification selection made by the application. |
| PowerState | PowerState enum | Holds the current power condition. |
| ServiceObjectDescription | string | Identifies the Service Object supporting the device and the company that produced it. This property is listed as DeviceServiceDescription in the UnifiedPOS specification. |
| ServiceObjectVersion | System.Version | Holds the Service Object version number. This property is listed as DeviceServiceVersion in the UnifiedPOS specification. |
| State | ControlState enum | Holds the current state of the device. |
| SynchronizingObject | ISynchronizeInvoke | Gets or sets the marshalling object for event handler calls from a POS event. |

## PosCommon Methods

The following table describes the methods of the **PosCommon** class available to applications.

| Method | Return Type | Description |
|--------|-------------|-------------|
| CheckHealth | string | Performs a health check on the device. The type of check to be performed is indicated by the HealthCheckLevel parameter. The method also updates the CheckHealthText property. |
| Claim | void | Requests exclusive access to the device. Service Object writers are advised to only throw exceptions in unexpected conditions; for example, OutOfMemory. Otherwise, Service Objects should return True if the device was claimed and False if a time-out occurred. |
| Close | void | Releases the device and its resources. |
| CompareFirmwareVersion | CompareFirmwareResult | Determines whether the version of the specified firmware is newer than, older than, or the same as the version of firmware in the physical device. |
| DirectIO | DirectIOData | Used to communicate directly with the Service Object. In the UnifiedPOS specification, it has two in/out parameters. As used by POS for .NET, this method returns a structure and no in/out parameters. |
| Open | void | Opens a device for subsequent input/output processing. |
| Release | void | Releases exclusive access to the device. |
| ResetStatistic | void | Resets the specified statistic to zero. Used in POS for .NET for operations on a single statistic. |
| ResetStatistics | void | Resets all statistics for a specified category to 0 (zero). |
| ResetStatistics | void | Resets the specified statistics to 0 (zero). |
| ResetStatistics | void | Resets all statistics associated with a device to 0 (zero). |
| RetrieveStatistic | string | Retrieves the specified device statistic. Used in POS for .NET for operations on a single statistic. |
| RetrieveStatistics | string | Retrieves all device statistics. |
| RetrieveStatistics | void | Retrieves the statistics for the specified category. |
| RetrieveStatistics | void | Retrieves the specified statistics. |
| UpdateFirmware | void | Updates the firmware of a device with the version of the firmware contained in the specified filename. |
| UpdateStatistic | void | Updates a statistic. Added to POS for .NET for operations on a single statistic. |
| UpdateStatistics | void | Updates a list of statistics with the corresponding specified values. |
| UpdateStatistics | void | Updates the specified category of statistics with the specified value. |

## PosCommon Events

The following table describes the **PosCommon** class events.

| Method            | Description                                                                          |
|-------------------|--------------------------------------------------------------------------------------|
| DirectIOEvent     | Raised by the Service Object to communicate information directly to the application. |
| StatusUpdateEvent | Raised by the Service Object to alert the application of a device status change.     |

## Example

The following code example demonstrates how to use the properties and methods common to all Service Objects to display information about a connected device.

```csharp
// Create a derived class of PosCommon
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

- [POS for .NET Class Tree](pos-for-net-class-tree.md)
