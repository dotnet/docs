---
title: "Runtime Changes in the .NET Framework 4.7 | Microsoft Docs"
ms.custom: ""
ms.date: "04/07/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "runtime changes,.NET Framework"
  - "runtime changes,.NET Framework 4.7"
  - "application compatibility"
ms.assetid: 268eb334-7906-4e0b-a1e3-c74b745de2a5
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Runtime Changes in the .NET Framework 4.7

In rare cases, runtime changes may affect existing apps that target the previous versions of the .NET Framework but run on a later version of the .NET Framework runtime. They also include differences in behavior between applications that run on different .NET Framework runtime environments. The .NET Framework 4.6.2 includes changes in the following areas:

- [Windows Presentation Foundation (WPF)](#WPF)

The Scope column in the following tables specifies the significance of each change:

- Major. A significant change that affects a large number of apps or that requires substantial modification of code. Note that none of the retargeting changes fall into this category.

- Minor. A change that either affects a small number of apps or that requires minor modification of code.

- Edge. A change that affects apps under very specific scenarios that are not common.

- Transparent. A change that has no noticeable effect on the app's developer or user. The app should not require modification because of this change.

## <a name="WPF" /> Windows Presentation Foundation (WPF)

<xref:System.Windows.Controls.DataGridCellsPanel.BringIndexIntoView(System.Int32)>

| Feature | Change | Impact | Scope |
|---|---|---|---|
| <xref:System.Windows.Controls.DataGridCellsPanel.BringIndexIntoView%2A> method | In the .NET Framework 4.6.2, the <xref:System.Windows.Controls.DataGridCellsPanel.BringIndexIntoView%2A> method executes asynchronously when column virtualization is enabled but the column widths have not been determined. If columns are removed before the asynchronous operation completes, an <xref:System.ArgumentOutOfRangeException> can occur.<br/></br>Starting with the .NET Framework 4.7, the exception is no longer thrown in this scenario. | This change increases the reliability of the method. | Edge | 
|<xref:System.Windows.Controls.Ribbon.RibbonGroup> background | In the .NET Framework 4.6.2 and earlier versions, the <xref:System.Windows.Controls.Ribbon.RibbonGroup> background on localized builds was painted with a transparent brush, resulting in a poor UI experience. In the .NET Framework 4.7, WPF updates the localized resources for the <xref:System.Windows.Controls.Ribbon.RibbonGroup> control, which ensures that the correct brush is selected. | To take advantage of the new behavior, upgrade to the .NET Framework 4.7. | Edge |
| WPF spellchecker | Starting with the .NET Framework 4.6.1, the spellchecker in WPF applications occasionally throws an <xref:System.ObjectDisposedException> during application shutdown. <br/><br/>In the .NET Framework 4.7, the exception is handled gracefully by the runtime, thus ensuring that applications are no longer adversely affected. It should be noted that occasional first-chance exceptions continue to be observed in applications running under a debugger.  | To take advantage of the new behavior, upgrade to the .NET Framework 4.7.   | Edge |

## See also

[Application Compatibility in the .NET Framework 4.7](../../../docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-7.md)

