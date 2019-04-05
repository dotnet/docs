---
title: "How to: Display More than One Month in the Windows Forms MonthCalendar Control"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "calendars [Windows Forms], formatting display"
  - "examples [Windows Forms], calendar controls"
  - "calendars [Windows Forms], multiple months"
  - "MonthCalendar control [Windows Forms], formatting display"
ms.assetid: d197caa2-38a5-4cb4-acc3-562130c2ace3
---
# How to: Display More than One Month in the Windows Forms MonthCalendar Control
The Windows Forms <xref:System.Windows.Forms.MonthCalendar> control can display up to 12 months at a time. By default, the control displays only one month, but you can specify how many months are displayed and how they are arranged within the control. When you change the calendar dimensions, the control is resized, so be sure there is enough room on the form for the new dimensions.  
  
### To display multiple months  
  
-   Set the <xref:System.Windows.Forms.MonthCalendar.CalendarDimensions%2A> property to the number of months to display horizontally and vertically.  
  
    ```vb  
    MonthCalendar1.CalendarDimensions = New System.Drawing.Size (3,2)  
    ```  
  
    ```csharp  
    monthCalendar1.CalendarDimensions = new System.Drawing.Size (3,2);  
    ```  
  
    ```cpp  
    monthCalendar1->CalendarDimensions = System::Drawing::Size (3,2);  
    ```  
  
## See also

- [MonthCalendar Control](monthcalendar-control-windows-forms.md)
- [How to: Select a Range of Dates in the Windows Forms MonthCalendar Control](how-to-select-a-range-of-dates-in-the-windows-forms-monthcalendar-control.md)
- [How to: Change the Windows Forms MonthCalendar Control's Appearance](how-to-change-monthcalendar-control-appearance.md)
