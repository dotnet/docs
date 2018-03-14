---
title: "MonthCalendar Control Overview (Windows Forms)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "MonthCalendar"
helpviewer_keywords: 
  - "calendars [Windows Forms], Windows Forms controls"
  - "calendar controls [Windows Forms], Windows Forms"
  - "MonthCalendar control [Windows Forms], setting the first day of the week"
ms.assetid: 788c5325-b721-44ec-95bf-9b680ba0f6a2
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# MonthCalendar Control Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.MonthCalendar> control presents an intuitive graphical interface for users to view and set date information. The control displays a calendar: a grid containing the numbered days of the month, arranged in columns underneath the days of the week, with the selected range of dates highlighted. You can select a different month by clicking the arrow buttons on either side of the month caption. Unlike the similar <xref:System.Windows.Forms.DateTimePicker> control, you can select more than one date with this control. For more information about the <xref:System.Windows.Forms.DateTimePicker> control, see [DateTimePicker Control](../../../../docs/framework/winforms/controls/datetimepicker-control-windows-forms.md).  
  
## Configuring the MonthCalendar Control  
 The <xref:System.Windows.Forms.MonthCalendar> control's appearance is highly configurable. By default, today's date is displayed as circled, and is also noted at the bottom of the grid. You can change this feature by setting the <xref:System.Windows.Forms.MonthCalendar.ShowToday%2A> and <xref:System.Windows.Forms.MonthCalendar.ShowTodayCircle%2A> properties to `false`. You can also add week numbers to the calendar by setting the <xref:System.Windows.Forms.MonthCalendar.ShowWeekNumbers%2A> property to `true`. By setting the <xref:System.Windows.Forms.MonthCalendar.CalendarDimensions%2A> property, you can have multiple months displayed horizontally and vertically. By default, Sunday is shown as the first day of the week, but any day can be designated using the <xref:System.Windows.Forms.MonthCalendar.FirstDayOfWeek%2A> property.  
  
 You can also set certain dates to be displayed in bold on a one-time basis, annually, or monthly, by adding <xref:System.DateTime> objects to the <xref:System.Windows.Forms.MonthCalendar.BoldedDates%2A>, <xref:System.Windows.Forms.MonthCalendar.AnnuallyBoldedDates%2A>, and <xref:System.Windows.Forms.MonthCalendar.MonthlyBoldedDates%2A> properties. For more information, see [How to: Display Specific Days in Bold with the Windows Forms MonthCalendar Control](../../../../docs/framework/winforms/controls/display-specific-days-in-bold-with-wf-monthcalendar-control.md).  
  
 The key property of the <xref:System.Windows.Forms.MonthCalendar> control is <xref:System.Windows.Forms.MonthCalendar.SelectionRange%2A>, the range of dates selected in the control. The <xref:System.Windows.Forms.MonthCalendar.SelectionRange%2A> value cannot exceed the maximum number of days that can be selected, set in the <xref:System.Windows.Forms.MonthCalendar.MaxSelectionCount%2A> property. The earliest and latest dates the user can select are determined by the <xref:System.Windows.Forms.MonthCalendar.MaxDate%2A> and <xref:System.Windows.Forms.MonthCalendar.MinDate%2A> properties.  
  
## See Also  
 <xref:System.Windows.Forms.MonthCalendar>  
 [MonthCalendar Control](../../../../docs/framework/winforms/controls/monthcalendar-control-windows-forms.md)
