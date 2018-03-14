---
title: "How to: Select a Range of Dates in the Windows Forms MonthCalendar Control"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "dates [Windows Forms], selecting range in calendar controls"
  - "examples [Windows Forms], calendar controls"
  - "calendars [Windows Forms], selecting date range"
  - "MonthCalendar control [Windows Forms], selecting date range"
ms.assetid: 95d9ab95-b0f8-4c19-9f63-b5cd4593a5d0
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Select a Range of Dates in the Windows Forms MonthCalendar Control
An important feature of the Windows Forms <xref:System.Windows.Forms.MonthCalendar> control is that the user can select a range of dates. This feature is an improvement over the date-selection feature of the <xref:System.Windows.Forms.DateTimePicker> control, which only enables the user to select a single date/time value. You can set a range of dates or get a selection range set by the user by using properties of the <xref:System.Windows.Forms.MonthCalendar> control. The following code example demonstrates how to set a selection range.  
  
### To select a range of dates  
  
1.  Create <xref:System.DateTime> objects that represent the first and last dates in a range.  
  
    ```vb  
    Dim projectStart As Date = New DateTime(2001, 2, 13)  
    Dim projectEnd As Date = New DateTime(2001, 2, 28)  
    ```  
  
    ```csharp  
    DateTime projectStart = new DateTime(2001, 2, 13);  
    DateTime projectEnd = new DateTime(2001, 2, 28);  
    ```  
  
    ```cpp  
    DateTime projectStart = DateTime(2001, 2, 13);  
    DateTime projectEnd = DateTime(2001, 2, 28);  
    ```  
  
2.  Set the <xref:System.Windows.Forms.MonthCalendar.SelectionRange%2A> property.  
  
    ```vb  
    MonthCalendar1.SelectionRange = New SelectionRange(projectStart, projectEnd)  
    ```  
  
    ```csharp  
    monthCalendar1.SelectionRange = new SelectionRange(projectStart, projectEnd);  
    ```  
  
    ```cpp  
    monthCalendar1->SelectionRange = gcnew  
       SelectionRange(projectStart, projectEnd);  
    ```  
  
     –or–  
  
     Set the <xref:System.Windows.Forms.MonthCalendar.SelectionStart%2A> and <xref:System.Windows.Forms.MonthCalendar.SelectionEnd%2A> properties.  
  
    ```vb  
    MonthCalendar1.SelectionStart = projectStart  
    MonthCalendar1.SelectionEnd = projectEnd  
    ```  
  
    ```csharp  
    monthCalendar1.SelectionStart = projectStart;  
    monthCalendar1.SelectionEnd = projectEnd;  
    ```  
  
    ```cpp  
    monthCalendar1->SelectionStart = projectStart;  
    monthCalendar1->SelectionEnd = projectEnd;  
    ```  
  
## See Also  
 [MonthCalendar Control](../../../../docs/framework/winforms/controls/monthcalendar-control-windows-forms.md)  
 [How to: Change the Windows Forms MonthCalendar Control's Appearance](../../../../docs/framework/winforms/controls/how-to-change-monthcalendar-control-appearance.md)  
 [How to: Display Specific Days in Bold with the Windows Forms MonthCalendar Control](../../../../docs/framework/winforms/controls/display-specific-days-in-bold-with-wf-monthcalendar-control.md)  
 [How to: Display More than One Month in the Windows Forms MonthCalendar Control](../../../../docs/framework/winforms/controls/display-more-than-one-month-wf-monthcalendar-control.md)
