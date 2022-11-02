---
title: PosExplorer Class (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# PosExplorer Class (POS for .NET v1.14 SDK Documentation)

[PosExplorer](ms884843\(v=winembedded.11\).md) provides Point of Service (POS) applications with a single entry point to Microsoft Point of Service for .NET (POS for .NET) services. **PosExplorer** supports applications by:

- Enumerating installed POS devices.
- Instantiating Service Objects.
- Receiving Plug and Play events when a POS peripheral device is connected or disconnected.

## PosExplorer Properties

The following table describes **PosExplorer** properties.

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
<td><p><a href="ms861788(v=winembedded.11).md">PosRegistryKey</a></p></td>
<td><p>string</p></td>
<td><p>Returns POS for .NET configuration root registry key relative to HKEY_LOCAL_MACHINE.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms861791(v=winembedded.11).md">StatisticsFile</a></p></td>
<td><p>string</p></td>
<td><p>Returns a path to the file where device statistics are contained.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms861792(v=winembedded.11).md">SynchronizingObject</a></p></td>
<td><p>ISynchronizeInvoke</p></td>
<td><p>Holds the ISynchronizeInvoke object.</p></td>
</tr>
</tbody>
</table>

## PosExplorer Methods

The following table describes **PosExplorer** methods.

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
<td><p><a href="ms843048(v=winembedded.11).md">CreateInstance</a></p></td>
<td><p>PosDevice</p></td>
<td><p>Instantiates a Service Object for the device.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms843053(v=winembedded.11).md">GetDevice</a></p></td>
<td><p>DeviceInfo</p></td>
<td><p>Returns a device of the specified type (must be only one in the system).</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms843054(v=winembedded.11).md">GetDevice</a></p></td>
<td><p>DeviceInfo</p></td>
<td><p>Returns a device of the type with the specified logical name or alias.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms843049(v=winembedded.11).md">GetDevices</a></p></td>
<td><p>DeviceCollection</p></td>
<td><p>Returns all POS devices.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms843051(v=winembedded.11).md">GetDevices</a></p></td>
<td><p>DeviceCollection</p></td>
<td><p>Returns all POS devices with the specified compatibility level.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms843050(v=winembedded.11).md">GetDevices</a></p></td>
<td><p>DeviceCollection</p></td>
<td><p>Returns POS devices of the type.</p></td>
</tr>
<tr class="odd">
<td><p><a href="ms843052(v=winembedded.11).md">GetDevices</a></p></td>
<td><p>DeviceCollection</p></td>
<td><p>Returns POS devices of the type and compatibility level.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms843055(v=winembedded.11).md">Refresh</a></p></td>
<td><p>None</p></td>
<td><p>Re-enumerates the list of attached POS devices and rebuilds internal data structures.</p></td>
</tr>
</tbody>
</table>

## PosExplorer Events

The following table describes **PosExplorer** events.

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<thead>
<tr class="header">
<th>Event</th>
<th>Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><a href="ms831428(v=winembedded.11).md">DeviceAddedEvent</a></p></td>
<td><p>Received when a Plug and Play-compatible POS device is connected.</p></td>
</tr>
<tr class="even">
<td><p><a href="ms831429(v=winembedded.11).md">DeviceRemovedEvent</a></p></td>
<td><p>Received when a Plug and Play-compatible POS device is disconnected.</p></td>
</tr>
</tbody>
</table>

## Example

The following code example demonstrates how to create an instance of **PosExplorer**, connect to Plug and Play events, and use it to identify all connected Magnetic Stripe Reader (MSR) devices. The code example prints information about the MSR to the console and closes the device after it has finished.

```
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

[POS for .NET Integration with Plug and Play](pos-for-net-integration-with-plug-and-play.md)

#### Other Resources

[POS for .NET API Support](pos-for-net-api-support.md)
[Developing Service Objects Using Base Classes](developing-service-objects-using-base-classes.md)
