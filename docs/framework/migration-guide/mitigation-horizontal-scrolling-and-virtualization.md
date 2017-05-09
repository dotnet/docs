---
title: "Mitigation: Horizontal Scrolling and Virtualization | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d5bafd9b-a3b3-4f92-8241-2aad254fb1a9
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Mitigation: Horizontal Scrolling and Virtualization
This change applies to an <xref:System.Windows.Controls.ItemsControl> that does its own virtualization in the direction orthogonal to the main scrolling direction. (The chief  example is a <xref:System.Windows.Controls.DataGrid> control with <xref:System.Windows.Controls.DataGrid.EnableColumnVirtualization%2A> set to `true`.)  The outcome of certain  horizontal scrolling operations has been changed to produce results that are more intuitive and more analogous to the results of comparable vertical operations.  The specific operations include **Scroll Here** and **Right Edge**, to use the names from the menu obtained by right-clicking a horizontal scrollbar.  Both of these compute a  candidate offset and call <xref:System.Windows.Controls.Primitives.IScrollInfo.SetHorizontalOffset%2A?displayProperty=fullName>.  After scrolling to the new offset, the definition of "here" or "right edge" may have changed because newly de-virtualized content has changed the value of <xref:System.Windows.Controls.Primitives.IScrollInfo.ExtentWidth%2A?displayProperty=fullName>.  
  
## Description of the change  
 Prior to the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], the scroll operation simply uses the candidate offset, even though it may not be "here" or at the "right edge" any more.  This results in effects like "bouncing" the scroll thumb, best illustrated by example.  Suppose a <xref:System.Windows.Controls.DataGrid> control has <xref:System.Windows.Controls.Primitives.IScrollInfo.ExtentWidth%2A> set to 1000 and <xref:System.Windows.FrameworkElement.Width%2A> set to 200.  A scroll to "Right Edge" uses candidate offset  1000 - 200 = 800.  While scrolling to that offset, new columns are de-virtualized; let's suppose they are very wide, so that the <xref:System.Windows.Controls.Primitives.IScrollInfo.ExtentWidth%2A> changes to 2000.  The scroll ends with <xref:System.Windows.Controls.Primitives.IScrollInfo.HorizontalOffset%2A>=800, and the thumb "bounces" back to near the middle of the scrollbar -- precisely at 800/2000 = 40%.  
  
 Starting with the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], a new candidate offset is recomputed when this situation occurs. (This is how vertical scrolling works already.)  
  
## Impact  
 The change produces a more predictable and intuitive experience for the end user, but it could also affect any app that depends on the exact value of <xref:System.Windows.Controls.Primitives.IScrollInfo.HorizontalOffset%2A?displayProperty=fullName> after a horizontal scroll, whether invoked by the end user or by an explicit call to <xref:System.Windows.Controls.Primitives.IScrollInfo.SetHorizontalOffset%2A?displayProperty=fullName>.  
  
## Mitigation  
 An app that uses a predicted value for <xref:System.Windows.Controls.Primitives.IScrollInfo.HorizontalOffset%2A?displayProperty=fullName> should be changed to retrieve the actual value (and the value of <xref:System.Windows.Controls.Primitives.IScrollInfo.ExtentWidth%2A>) after any horizontal scroll that could change <xref:System.Windows.Controls.Primitives.IScrollInfo.ExtentWidth%2A> due to de-virtualization.  
  
## See Also  
 [Runtime Changes](../../../docs/framework/migration-guide/runtime-changes-in-the-net-framework-4-6-2.md)