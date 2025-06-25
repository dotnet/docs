---
title: PosCommon Information for Service Object Developers
description: PosCommon Information for Service Object Developers (POS for .NET v1.14 SDK Documentation)
ms.date: 02/27/2008
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# PosCommon Information for Service Object Developers (POS for .NET v1.14 SDK Documentation)

At the base of the POS for .NET Server Object class tree (**Interface**, **Basic**, **Base**) is <xref:Microsoft.PointOfService.PosCommon>. This class is a direct implementation of the "Common Properties, Methods, and Events" chapter in the UPOS specification.

Each POS for .NET **Basic** class overrides or implements **PosCommon** properties and methods which are of particular importance to a Service Object developer. This topic provides information about these methods and properties.

## CapPowerReporting Property

Once POS for .NET has successfully opened a device, it tries to retrieve the current value of the <xref:Microsoft.PointOfService.PosCommon.CapPowerReporting> property. The <xref:Microsoft.PointOfService.PowerReporting> class is initialized to **None**, indicating that the Service Object is not able to provide power reporting. If, however, the Service Object's device does support power reporting, the Service Object may set **PowerReporting** to **Standard** or **Advanced** in the Service Object's method.

## CapStatisticsReporting Property

POS for .NET verifies that the device has been opened and then retrieves the current value of the <xref:Microsoft.PointOfService.PosCommon.CapStatisticsReporting> property.

When statistics are created for the device, POS for .NET sets **CapStatisticsReporting** to **true**.

## CapUpdateStatistics Property

POS for .NET verifies that the device has been opened and then retrieves the current value of the <xref:Microsoft.PointOfService.PosCommon.CapUpdateStatistics> property.

When statistics are created for the device, and if those statistics can be reset or updated, then POS for .NET sets **CapUpdateStatistics** to **true**.

## Claimed Property

POS for .NET verifies that the device has been opened, and then retrieves the current value of the <xref:Microsoft.PointOfService.PosCommon.Claimed> property.

**Claimed** is initialized to **false**. **Claimed** should be set to **true** when the application calls the <xref:Microsoft.PointOfService.PosCommon.Claim(System.Int32)> method, then set back to **false** when the application calls the <xref:Microsoft.PointOfService.PosCommon.Release> method.

## DeviceDescription Property

POS for .NET verifies that the device has been opened, and then retrieves the current value of the <xref:Microsoft.PointOfService.PosCommon.DeviceDescription> property.

## DeviceEnabled Property

<xref:Microsoft.PointOfService.PosCommon.DeviceEnabled> is a read/write property.

It can be used to return the object's current state; enabled or disabled. If this object has not been previously opened and enabled, this property returns **false**.

This property is also used to enable or disable the device by setting the property of the value to **true** or **false**. It is common for Service Objects to override this property and perform its hardware initialization and release here.

## DeviceName Property

POS for .NET verifies that the device has been opened, and then retrieves the current value of the <xref:Microsoft.PointOfService.PosCommon.DeviceName> property.

Within **Base** class implementations, this value is set automatically based on the contents of the **ServiceObject** attribute.

If you are not deriving from a POS for .NET **Base** class, and are instead deriving from an **Interface**-level or **Basic**-level class, then **DeviceName** should be set by the Service Subject during the <xref:Microsoft.PointOfService.PosCommon.Open> method.

## FreezeEvents Property

<xref:Microsoft.PointOfService.PosCommon.FreezeEvents> is a read/write property.

POS for .NET verifies that the device has been opened and claimed, then retrieves or sets the current value of the **FreezeEvents** property. When this property is set to **true**, POS for .NET queues events until this property is set to **false**, not that the queuing mechanism can vary from one device type to another.

The **FreezeEvents** property is initialized to **false**.

## PowerNotify Property

<xref:Microsoft.PointOfService.PosCommon.PowerNotify> is a read/write property.

POS for .NET verifies that the device has been opened, then retrieves or sets the current value of **PowerNotify**. If **PowerNotify** is set, then power state notifications will be sent to the application.

**PowerNotify** is initialized to **Disabled**.

Attempting to set **PowerNotify** can cause the following exceptions to be thrown.

<!-- markdownlint-disable MD033 -->
<table>
<colgroup>
<col />
<col />
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

POS for .NET verifies that the device has been opened, and then retrieves the current value of the <xref:Microsoft.PointOfService.PosCommon.PowerState> property. If **CapPowerReporting** is set to **None**, **PowerNotify** is set to **Disabled**, or **DeviceEnabled** set to **false**, **PowerState** is returned as **Unknown**.

**PowerState** is initialized to **Unknown**. When **PowerNotify** is set to **Enabled** and **DeviceEnabled** is **true**, **PowerState** should be updated as the Service Object detects power condition changes. POS for .NET detects the state change when the Service Object sets **PowerState** and—if **PowerNotify** is set to **Enabled**—queues a <xref:Microsoft.PointOfService.PosCommon.StatusUpdateEvent> event, notifying the application.

Setting <xref:Microsoft.PointOfService.PowerState> can cause the following exceptions to be thrown.

<!-- markdownlint-disable MD033 -->
<table>
<colgroup>
<col />
<col />
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

POS for .NET verifies that the device has been opened, and then retrieves the current value of the <xref:Microsoft.PointOfService.PosCommon.ServiceObjectDescription> property. The Service Object developer should not have to set this value, since it is set by the POS for .NET **Basic** class using the description information provided in the **ServiceObject** attribute.

## ServiceObjectVersion Property

POS for .NET verifies that the device has been opened, and then retrieves the current value of the <xref:Microsoft.PointOfService.PosCommon.ServiceObjectVersion> property. The Service Object developer should not have to set this value, since it is set by the POS for .NET **Basic** class using the version information provided in the **ServiceObject** attribute.

## State Property

No device state verification is required—the application can retrieve the current value of the <xref:Microsoft.PointOfService.PosCommon.State> property.at any time.

**State** is initialized to **Closed**. If the Service Object sets **State** to an invalid <xref:Microsoft.PointOfService.ControlState> value, POS for .NET throws an Illegal exception. Changes in **State** cause POS for .NET to queue a **StateChangedEvent** event.

## Claim Method

POS for .NET verifies that the application has the device opened.

If the *timeout* parameter is set to a value less than -1, POS for .NET throws an exception. If *the timeout* value is set to -1, the **Claim** method will wait forever.

If the device is already claimed by the application, POS for .NET simply returns.

If the device is in use by another application, *timeout* is reached; POS for .NET throws a time-out exception.

If **Claim** is successful, POS for .NET loads the statistics for the device and sets the **Claimed** property to **true**.

## Close Method

If the application calls the <xref:Microsoft.PointOfService.PosCommon.Close> method when **State** is set to **Closed**, POS for .NET throws a **Closed** exception. If **State** is set to **Busy**, POS for .NET throws a **Busy** exception.

If the **DeviceEnabled** method when **Claimed** is set to **false**, POS for .NET throws an Illegal exception. If **State** is set to **Busy**, POS for .NET calls the **ClearOutput** method. If the device is enabled, POS for .NET sets **DeviceEnabled** to **false**. POS for .NET clears the event queue, and then sets **Claimed** to **false**.

## ResetStatistic Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the <xref:Microsoft.PointOfService.PosCommon.ResetStatistic(System.String)> method.

## ResetStatistics() Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the <xref:Microsoft.PointOfService.PosCommon.ResetStatistics> method.

## ResetStatistics(categories parameter) Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the <xref:Microsoft.PointOfService.PosCommon.ResetStatistics(Microsoft.PointOfService.StatisticCategories)> method.

## ResetStatistics(string parameter) Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the <xref:Microsoft.PointOfService.PosCommon.ResetStatistics(System.String[])> method.

## RetrieveStatistic Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the <xref:Microsoft.PointOfService.PosCommon.RetrieveStatistic(System.String)> method.

## RetrieveStatistics() Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the <xref:Microsoft.PointOfService.PosCommon.RetrieveStatistics> method.

## RetrieveStatistics(categories parameter) Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the <xref:Microsoft.PointOfService.PosCommon.RetrieveStatistics(Microsoft.PointOfService.StatisticCategories)> method.

## RetrieveStatistics(string parameter) Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the <xref:Microsoft.PointOfService.PosCommon.RetrieveStatistics(System.String[])> method.

## UpdateStatistic Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the <xref:Microsoft.PointOfService.PosCommon.UpdateStatistic(System.String,System.Object)> method.

## UpdateStatistics(categories parameter) Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the <xref:Microsoft.PointOfService.PosCommon.UpdateStatistics(Microsoft.PointOfService.StatisticCategories,System.Object)> method.

## UpdateStatistics(statistic array parameter) Method

POS for .NET verifies that the application has opened, claimed, and enabled the device, then calls the <xref:Microsoft.PointOfService.PosCommon.UpdateStatistics(Microsoft.PointOfService.Statistic[])> method.

## See Also

#### Reference

- <xref:Microsoft.PointOfService.PosCommon>

#### Concepts

- [POS for .NET Class Tree](pos-for-net-class-tree.md)

#### Other Resources

- [Service Object Samples: Getting Started](service-object-samples-getting-started.md)
