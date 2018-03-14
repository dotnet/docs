---
title: "DateTimePicker Control Overview (Windows Forms)"
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
  - "DateTimePicker"
helpviewer_keywords: 
  - "DateTimePicker control [Windows Forms], about"
  - "date and time picker controls"
ms.assetid: 501af106-e9fc-4efc-b9b3-c9d8dcaf8c5c
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# DateTimePicker Control Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.DateTimePicker> control allows the user to select a single item from a list of dates or times. When used to represent a date, it appears in two parts: a drop-down list with a date represented in text, and a grid that appears when you click on the down-arrow next to the list. The grid looks like the <xref:System.Windows.Forms.MonthCalendar> control, which can be used for selecting multiple dates. For more information on the <xref:System.Windows.Forms.MonthCalendar> control, see [MonthCalendar Control Overview](../../../../docs/framework/winforms/controls/monthcalendar-control-overview-windows-forms.md).  
  
## Key Properties  
 If you wish the <xref:System.Windows.Forms.DateTimePicker> to appear as a control for picking or editing times instead of dates, set the <xref:System.Windows.Forms.DateTimePicker.ShowUpDown%2A> property to `true` and the <xref:System.Windows.Forms.DateTimePicker.Format%2A> property to <xref:System.Windows.Forms.DateTimePickerFormat.Time>. For more information see [How to: Display Time with the DateTimePicker Control](../../../../docs/framework/winforms/controls/how-to-display-time-with-the-datetimepicker-control.md).  
  
 When the <xref:System.Windows.Forms.DateTimePicker.ShowCheckBox%2A> property is set to `true`, a check box is displayed next to the selected date in the control. When the check box is checked, the selected date-time value can be updated. When the check box is empty, the value appears unavailable.  
  
 The control's <xref:System.Windows.Forms.DateTimePicker.MaxDate%2A> and <xref:System.Windows.Forms.DateTimePicker.MinDate%2A> properties determine the range of dates and times. The <xref:System.Windows.Forms.DateTimePicker.Value%2A> property contains the current date and time the control is set to. For details, see [How to: Set and Return Dates with the Windows Forms DateTimePicker Control](../../../../docs/framework/winforms/controls/how-to-set-and-return-dates-with-the-windows-forms-datetimepicker-control.md). The values can be displayed in four formats, which are set by the <xref:System.Windows.Forms.DateTimePicker.Format%2A> property: <xref:System.Windows.Forms.DateTimePickerFormat.Long>, <xref:System.Windows.Forms.DateTimePickerFormat.Short>, <xref:System.Windows.Forms.DateTimePickerFormat.Time>, or <xref:System.Windows.Forms.DateTimePickerFormat.Custom>. If a custom format is selected, you must set the <xref:System.Windows.Forms.DateTimePicker.CustomFormat%2A> property to an appropriate string. For details, see [How to: Display a Date in a Custom Format with the Windows Forms DateTimePicker Control](../../../../docs/framework/winforms/controls/display-a-date-in-a-custom-format-with-wf-datetimepicker-control.md).  
  
## See Also  
 [How to: Display a Date in a Custom Format with the Windows Forms DateTimePicker Control](../../../../docs/framework/winforms/controls/display-a-date-in-a-custom-format-with-wf-datetimepicker-control.md)  
 [How to: Set and Return Dates with the Windows Forms DateTimePicker Control](../../../../docs/framework/winforms/controls/how-to-set-and-return-dates-with-the-windows-forms-datetimepicker-control.md)
