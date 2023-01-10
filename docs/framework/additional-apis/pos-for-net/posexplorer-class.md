---
title: PosExplorer Class (POS for .NET v1.14 SDK Documentation)
description: PosExplorer Class (POS for .NET v1.14 SDK Documentation) (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# PosExplorer Class (POS for .NET v1.14 SDK Documentation)

<xref:Microsoft.PointOfService.PosExplorer> provides Point of Service (POS) applications with a single entry point to Microsoft Point of Service for .NET (POS for .NET) services. **PosExplorer** supports applications by:

- Enumerating installed POS devices.
- Instantiating Service Objects.
- Receiving Plug and Play events when a POS peripheral device is connected or disconnected.

## PosExplorer Properties

The following table describes **PosExplorer** properties.

| Property            | Type               | Description                                                                          |
|---------------------|--------------------|--------------------------------------------------------------------------------------|
| PosRegistryKey      | string             | Returns POS for .NET configuration root registry key relative to HKEY_LOCAL_MACHINE. |
| StatisticsFile      | string             | Returns a path to the file where device statistics are contained.                    |
| SynchronizingObject | ISynchronizeInvoke | Holds the ISynchronizeInvoke object.                                                 |

## PosExplorer Methods

The following table describes **PosExplorer** methods.

| Method         | Return Type      | Description                                                                           |
|----------------|------------------|---------------------------------------------------------------------------------------|
| CreateInstance | PosDevice        | Instantiates a Service Object for the device.                                         |
| GetDevice      | DeviceInfo       | Returns a device of the specified type (must be only one in the system).              |
| GetDevice      | DeviceInfo       | Returns a device of the type with the specified logical name or alias.                |
| GetDevices     | DeviceCollection | Returns all POS devices.                                                              |
| GetDevices     | DeviceCollection | Returns all POS devices with the specified compatibility level.                       |
| GetDevices     | DeviceCollection | Returns POS devices of the type.                                                      |
| GetDevices     | DeviceCollection | Returns POS devices of the type and compatibility level.                              |
| Refresh        | None             | Re-enumerates the list of attached POS devices and rebuilds internal data structures. |

## PosExplorer Events

The following table describes **PosExplorer** events.

| Event              | Description                                                          |
|--------------------|----------------------------------------------------------------------|
| DeviceAddedEvent   | Received when a Plug and Play-compatible POS device is connected.    |
| DeviceRemovedEvent | Received when a Plug and Play-compatible POS device is disconnected. |

## Example

The following code example demonstrates how to create an instance of **PosExplorer**, connect to Plug and Play events, and use it to identify all connected Magnetic Stripe Reader (MSR) devices. The code example prints information about the MSR to the console and closes the device after it has finished.

```csharp
// Creates a new instance of an MSR.
void CreateMsr(DeviceInfo msrinfo)
{
    msr = (Msr)explorer.CreateInstance(msrinfo);
    msr.Open();
    msr.Claim(1000);
    msr.DeviceEnabled = true;
}

static void Main(string[] args)
{

    // Create a new instance of PosExplorer and use it to
    // collect device information.
    PosExplorer explorer = new PosExplorer();
    DeviceCollection devices = explorer.GetDevices();

    // Search all connected devices for an MSR, print its service
    // object name to the console, and close it when finished.
    foreach (DeviceInfo device in devices)
    {
      if (device.Type == DeviceType.Msr)
      {
         if (device.ServiceObjectName == currentMsr)
         {
            CreateMsr(device);
            Console.WriteLine(device.ServiceObjectName);

            // It is important that applications close all open
            // Service Objects before terminating.
            msr.Close();
            msr = null;
         }
      }
    }
}
```

## See Also

#### Concepts

- [POS for .NET Integration with Plug and Play](pos-for-net-integration-with-plug-and-play.md)

#### Other Resources

- [POS for .NET API Support](pos-for-net-api-support.md)
- [Developing Service Objects Using Base Classes](developing-service-objects-using-base-classes.md)
