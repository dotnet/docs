---
title: CashDrawer Implementation
description: CashDrawer Implementation (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# CashDrawer Implementation (POS for .NET v1.14 SDK Documentation)

Most point-of-sale applications will use a cash drawer for financial transactions. Service Object developers can use the Microsoft Point of Service for .NET (POS for .NET) class, <xref:Microsoft.PointOfService.BaseServiceObjects.CashDrawerBase>, to easily implement a Unified Point Of Service (UnifiedPOS) compliant **CashDrawer** Service Object.

## Capabilities

All **CashDrawer** Service Objects must support, at a minimum, the ability to open the drawer. This is done by implementing the abstract method, **CashDrawerBase.OpenDrawerImpl**, in your Service Object class.

The Service Object may also be able to determine if the cash drawer is open or not. If the Service Object does have this capability, it should set the **CapStatus** property to **true**. If **CapStatus** is **true**, then applications may examine the state of the device using the **DrawerOpened** property. If **CapStatus** is not set, then **DrawerOpened** will always be set to **false** and any attempt to set it to **true** will generate an exception.

If **CapStatus** has been set to **true**, the Service Object needs to update the **DrawerOpened** property. You should do this in the Service Object's implementation of the **OpenDrawerImpl** method. A background thread monitoring the state of the device may also set the **DrawerOpened** property.

## CashDrawer Events

If the Service Object has set the **CapStatus** property to **true**, **CashDrawerBasic.DrawerOpened** sends a **StatusUpdateEvent** to the application.

Depending on the cash drawer device and the Service Object implementation, the Service Object may need a separate thread to monitor the state of the hardware and report any changes asynchronously. This would be necessary, for example, if the cash drawer could be opened manually by the operator and the application needs to be notified.

The **CashDrawer** Service Object may also send a **DirectIOEvent** to the application. The **DirectIOEvent** is used to send data to the application that is specific to the Service Object implementation and may therefore be incompatible with some applications. For more information, see [Device Input and Events](device-input-and-events.md).

## Device Sharing

A cash drawer is a shareable device. Multiple applications will be able to open, enable, and access all of its properties and methods. However, once an application has claimed the device, only that application may call **CashDrawerBase.OpenDrawer** or **CashDrawerBase.WaitForDrawerClose**. A **PosException** with **ErrorCode.Claimed** will be thrown if other applications attempt to call these methods.

If more than one application has opened and enabled the device, then each application will receive all events sent by the Service Object.

The code necessary to support this feature is implemented in the POS for .NET **CashDrawerBase** class.

## Multiple Cash Drawers

It is possible to have more than one cash drawer attached to the computer and using the same hardware port. In such situations, a **CashDrawer** Service Object may know to which cash drawer it is not specifically connected. If the Service Object can distinguish to which cash drawer device it is connected, it should set the **CapStatusMultiDrawerDetect** property to **true**. The value of this property will influence the behavior of the **DrawerOpened** property and the **WaitForDrawerClose** method.

If **CapStatusMultiDrawerDetect** is set to **false**, then a **DrawerOpened** value of **true** indicates that at least one drawer is open. The application is not able to determine whether any drawer in particular is open.

If **CapStatusMultiDrawerDetect** is set to **false**, the method **WaitForDrawerClose** waits for all open cash drawers to be closed before returning to the application.

## See Also

#### Other Resources

- [Developing Service Objects Using Base Classes](developing-service-objects-using-base-classes.md)
