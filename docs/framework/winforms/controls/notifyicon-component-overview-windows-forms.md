---
title: "NotifyIcon Component Overview (Windows Forms)"
ms.date: "03/30/2017"
f1_keywords:
  - "NotifyIcon"
helpviewer_keywords:
  - "NotifyIcon component [Windows Forms], about NotifyIcon component"
  - "system tray icons [Windows Forms], about system tray icons"
  - "system tray icons [Windows Forms], using in Windows Forms"
ms.assetid: 5b9189fa-d4ae-41a6-9b97-eb1f44bb1a69
---
# NotifyIcon Component Overview (Windows Forms)

The Windows Forms <xref:System.Windows.Forms.NotifyIcon> component is typically used to display icons for processes that run in the background and do not show a user interface much of the time. An example would be a virus protection program that can be accessed by clicking an icon in the status notification area of the taskbar.

## Key Properties of NotifyIcons

Each <xref:System.Windows.Forms.NotifyIcon> component displays a single icon in the status area. If you have three background processes and wish to display an icon for each, you must add three <xref:System.Windows.Forms.NotifyIcon> components to the form. The key properties of the <xref:System.Windows.Forms.NotifyIcon> component are <xref:System.Windows.Forms.NotifyIcon.Icon%2A> and <xref:System.Windows.Forms.NotifyIcon.Visible%2A>. The <xref:System.Windows.Forms.NotifyIcon.Icon%2A> property sets the icon that appears in the status area. In order for the icon to appear, the <xref:System.Windows.Forms.NotifyIcon.Visible%2A> property must be set to `true`.

## NotifyIcons Options

You can associate balloon tips, shortcut menus, and ToolTips with a <xref:System.Windows.Forms.NotifyIcon> to assist the user.

You can display balloon tips for a <xref:System.Windows.Forms.NotifyIcon> by calling the <xref:System.Windows.Forms.NotifyIcon.ShowBalloonTip%2A> method specifying the time span you wish the balloon tip to display. You can also specify the text, icon and title of the balloon tip with the <xref:System.Windows.Forms.NotifyIcon.BalloonTipText%2A>, <xref:System.Windows.Forms.NotifyIcon.BalloonTipIcon%2A> and <xref:System.Windows.Forms.NotifyIcon.BalloonTipTitle%2A>, respectively. <xref:System.Windows.Forms.NotifyIcon> components can also have associated ToolTips and shortcut menus. For more information, see [ToolTip Component Overview](tooltip-component-overview-windows-forms.md) and [ContextMenu Component Overview](contextmenu-component-overview-windows-forms.md).

## See also

- <xref:System.Windows.Forms.NotifyIcon>
- [NotifyIcon Component](notifyicon-component-windows-forms.md)