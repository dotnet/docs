---
title: PosCommon Information for Service Object Developers
ms.date: 02/27/2008
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# PosCommon Information for Service Object Developers (POS for .NET v1.12 SDK Documentation)

At the base of the POS for .NET Server Object class tree (**Interface**, **Basic**, **Base**) is [PosCommon](ms884820\(v=winembedded.11\).md). This class is a direct implementation of the "Common Properties, Methods, and Events" chapter in the UPOS specification.

Each POS for .NET **Basic** class overrides or implements **PosCommon** properties and methods which are of particular importance to a Service Object developer. This topic provides information about these methods and properties.

## CapPowerReporting Property

Once POS for .NET has successfully opened a device, it tries to retrieve the current value of the [CapPowerReporting](ms861089\(v=winembedded.11\).md) property. The [PowerReporting](aa460845\(v=winembedded.11\).md) class is initialized to **None**, indicating that the Service Object is not able to provide power reporting. If, however, the Service Object's device does support power reporting, the Service Object may set **PowerReporting** to **Standard** or **Advanced** in the Service Object's method.

## CapStatisticsReporting Property

POS for .NET verifies that the device has been opened and then retrieves the current value of the [CapStatisticsReporting](ms861090\(v=winembedded.11\).md) property.

When statistics are created for the device, POS for .NET sets **CapStatisticsReporting** to **true**.

## CapUpdateStatistics Property

POS for .NET verifies that the device has been opened and then retrieves the current value of the [CapUpdateStatistics](ms861092\(v=winembedded.11\).md) property.

When statistics are created for the device, and if those statistics can be reset or updated, then POS for .NET sets **CapUpdateStatistics** to **true**.

## Claimed Property

POS for .NET verifies that the device has been opened, and then retrieves the current value of the [Claimed](ms861094\(v=winembedded.11\).md) property.

**Claimed** is initialized to **false**. **Claimed** should be set to **true** when the application calls the [Claim](ms843023\(v=winembedded.11\).md) method, then set back to **false** when the application calls the [Release](ms843031\(v=winembedded.11\).md) method.

## DeviceDescription Property

POS for .NET verifies that the device has been opened, and then retrieves the current value of the [DeviceDescription](ms861095\(v=winembedded.11\).md) property.

## DeviceEnabled Property

[DeviceEnabled](ms861096\(v=winembedded.11\).md) is a read/write property.

It can be used to return the object's current state; enabled or disabled. If this object has not been previously opened and enabled, this property returns **false**.

This property is also used to enable or disable the device by setting the property of the value to **true** or **false**. It is common for Service Objects to override this property and perform its hardware initialization and release here.

## DeviceName Property

POS for .NET verifies that the device has been opened, and then retrieves the current value of the [DeviceName](ms861097\(v=winembedded.11\).md) property.

Within **Base** class implementations, this value is set automatically based on the contents of the **ServiceObject** attribute.

If you are not deriving from a POS for .NET **Base** class, and are instead deriving from an **Interface**-level or **Basic**-level class, then **DeviceName** should be set by the Service Subject during the [Open](ms843030\(v=winembedded.11\).md) method.

## FreezeEvents Property

[FreezeEvents](ms861099\(v=winembedded.11\).md) is a read/write property.

POS for .NET verifies that the device has been opened and claimed, then retrieves or sets the current value of the **FreezeEvents** property. When this property is set to **true**, POS for .NET queues events until this property is set to **false**, not that the queuing mechanism can vary from one device type to another.

The **FreezeEvents** property is initialized to **false**.

## PowerNotify Property

[PowerNotify](ms861100\(v=winembedded.11\).md) is a read/write property.

POS for .NET verifies that the device has been opened, then retrieves or sets the current value of **PowerNotify**. If **PowerNotify** is set, then power state notifications will be sent to the application.

**PowerNotify** is initialized to **Disabled**.

Attempting to set **PowerNotify** can cause the following exceptions to be thrown.

<!-- markdownlint-disable MD033 -->
<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<thead>
<tr class="header">
<th><strong>Value</strong></th>
<th><strong>Meaning</strong></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>Illegal</p></td>
<td><p>One of the following conditions has occurred:</p>
<ul>
<li>The device is enabled.<br />
</li>
<li>P:Microsoft.PointOfService.PosCommon.CapPowerReporting is set to <strong>None</strong>, indicating that the device does not support power notification.<br />
</li>
<li>The specified value is not a valid T:Microsoft.PointOfService.PowerNotification enumeration value.<br />
</li>
</ul></td>
</tr>
</tbody>
</table>
<!-- markdownlint-enable MD033 -->

## PowerState Property

POS for .NET verifies that the device has been opened, and then retrieves the current value of the [PowerState](ms861101\(v=winembedded.11\).md) property. If **CapPowerReporting** is set to **None**, **PowerNotify** is set to **Disabled**, or **DeviceEnabled** set to **false**, **PowerState** is returned as **Unknown**.

**PowerState** is initialized to **Unknown**. When **PowerNotify** is set to **Enabled** and **DeviceEnabled** is **true**, **PowerState** should be updated as the Service Object detects power condition changes. POS for .NET detects the state change when the Service Object sets **PowerState** and—if **PowerNotify** is set to **Enabled**—queues a [StatusUpdateEvent](ms831427\(v=winembedded.11\).md) event, notifying the application.

Setting [PowerState](aa460847\(v=winembedded.11\).md) can cause the following exceptions to be thrown.

<!-- markdownlint-disable MD033 -->
<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<thead>
<tr class="header">
<th><strong>Value</strong></th>
<th><strong>Meaning</strong></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p>Illegal</p></td>
<td><p>One of the following conditions has occurred:</p>
<ul>
<li><strong>CapPowerReporting</strong> = <strong>Standard</strong> and <strong>PowerNotify</strong> is set to <strong>Online</strong>, <strong>Off</strong>, or <strong>Offline</strong>.<br />
</li>
<li><strong>CapPowerReporting</strong> = <strong>Advanced</strong> and <strong>PowerState</strong> is set to <strong>Online</strong>, <strong>Off</strong>, or <strong>Offline</strong>.<br />
</li>
</ul></td>
</tr>
</tbody>
</table>
<!-- markdownlint-enable MD033 -->

## ServiceObjectDescription Property

POS for .NET verifies that the device has been opened, and then retrieves the current value of the [ServiceObjectDescription](ms861102\(v=winembedded.11\).md) property. The Service Object developer should not have to set this value, since it is set by the POS for .NET **Basic** class using the description information provided in the **ServiceObject** attribute.

## ServiceObjectVersion Property

POS for .NET verifies that the device has been opened, and then retrieves the current value of the [ServiceObjectVersion](ms861103\(v=winembedded.11\).md) property. The Service Object developer should not have to set this value, since it is set by the POS for .NET **Basic** class using the version information provided in the **ServiceObject** attribute.

## State Property

No device state verification is required—the application can retrieve the current value of the [State](ms861104\(v=winembedded.11\).md) property.at any time.

**State** is initialized to **Closed**. If the Service Object sets **State** to an invalid [ControlState](ms884018\(v=winembedded.11\).md) value, POS for .NET throws an Illegal exception. Changes in **State** cause POS for .NET to queue a **StateChangedEvent** event.

## Claim Method

POS for .NET verifies that the application has the device opened.

If the *timeout* parameter is set to a value less than -1, POS for .NET throws an exception. If *the timeout* value is set to -1, the **Claim** method will wait forever.

If the device is already claimed by the application, POS for .NET simply returns.

If the device is in use by another application, *timeout* is reached; POS for .NET throws a time-out exception.

If **Claim** is successful, POS for .NET loads the statistics for the device and sets the **Claimed** property to **true**.

## Close Method

If the application calls the [Close](ms843024\(v=winembedded.11\).md) method when **State** is set to **Closed**, POS for .NET throws a **Closed** exception. If **State** is set to **Busy**, POS for .NET throws a **Busy** exception.

If the **DeviceEnabled** method when **Claimed** is set to **false**, POS for .NET throws an Illegal exception. If **State** is set to **Busy**, POS for .NET calls the **ClearOutput** method. If the device is enabled, POS for .NET sets **DeviceEnabled** to **false**. POS for .NET clears the event queue, and then sets **Claimed** to **false**.

## ResetStatistic Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the [ResetStatistic](ms843035\(v=winembedded.11\).md) method.

## ResetStatistics() Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the [ResetStatistics](ms843032\(v=winembedded.11\).md) method.

## ResetStatistics(categories parameter) Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the [ResetStatistics](ms843034\(v=winembedded.11\).md) method.

## ResetStatistics(string parameter) Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the [ResetStatistics](ms843033\(v=winembedded.11\).md) method.

## RetrieveStatistic Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the [RetrieveStatistic](ms843039\(v=winembedded.11\).md) method.

## RetrieveStatistics() Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the [RetrieveStatistics](ms843036\(v=winembedded.11\).md) method.

## RetrieveStatistics(categories parameter) Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the [RetrieveStatistics](ms843038\(v=winembedded.11\).md) method.

## RetrieveStatistics(string parameter) Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the [RetrieveStatistics](ms843037\(v=winembedded.11\).md) method.

## UpdateStatistic Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the [UpdateStatistic](ms843044\(v=winembedded.11\).md) method.

## UpdateStatistics(categories parameter) Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the [UpdateStatistics](ms843043\(v=winembedded.11\).md) method.

## UpdateStatistics(statistic array parameter) Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the [UpdateStatistics](ms843042\(v=winembedded.11\).md) method.

## See Also

#### Reference

[PosCommon](ms884820\(v=winembedded.11\).md)

#### Concepts

[POS for .NET Class Tree](pos-for-net-class-tree.md)

#### Other Resources

[Service Object Samples: Getting Started](service-object-samples-getting-started.md)
