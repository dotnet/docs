---
title: "How to: Change the Windows Forms MonthCalendar Control&#39;s Appearance"
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
  - "examples [Windows Forms], calendar controls"
  - "MonthCalendar control [Windows Forms], formatting display"
ms.assetid: d09b95c9-e108-4608-9b31-b9100c0677bf
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Change the Windows Forms MonthCalendar Control&#39;s Appearance
The Windows Forms <xref:System.Windows.Forms.MonthCalendar> control allows you to customize the calendar's appearance in many ways. For example, you can set the color scheme and choose to display or hide week numbers and the current date.  
  
### To change the month calendar's color scheme  
  
-   Set properties such as <xref:System.Windows.Forms.MonthCalendar.TitleBackColor%2A>, <xref:System.Windows.Forms.MonthCalendar.TitleForeColor%2A> and <xref:System.Windows.Forms.MonthCalendar.TrailingForeColor%2A>. The <xref:System.Windows.Forms.MonthCalendar.TitleBackColor%2A> property also determines the font color for the days of the week. The <xref:System.Windows.Forms.MonthCalendar.TrailingForeColor%2A> property determines the color of the dates that precede and follow the displayed month or months.  
  
    ```vb  
    MonthCalendar1.TitleBackColor = System.Drawing.Color.Blue  
    MonthCalendar1.TrailingForeColor = System.Drawing.Color.Red  
    MonthCalendar1.TitleForeColor = System.Drawing.Color.Yellow  
    ```  
  
    ```csharp  
    monthCalendar1.TitleBackColor = System.Drawing.Color.Blue;  
    monthCalendar1.TrailingForeColor = System.Drawing.Color.Red;  
    monthCalendar1.TitleForeColor = System.Drawing.Color.Yellow;  
    ```  
  
    ```cpp  
    monthCalendar1->TitleBackColor = System::Drawing::Color::Blue;  
    monthCalendar1->TrailingForeColor = System::Drawing::Color::Red;  
    monthCalendar1->TitleForeColor = System::Drawing::Color::Yellow;  
    ```  
  
    > [!NOTE]
    >  Starting with Windows Vista and depending on the theme, setting some properties might not change the appearance of the calendar. For example, if Windows is set to use the Aero theme, setting the <xref:System.Windows.Forms.MonthCalendar.BackColor%2A>, <xref:System.Windows.Forms.MonthCalendar.TitleBackColor%2A>, <xref:System.Windows.Forms.MonthCalendar.TitleForeColor%2A>, or <xref:System.Windows.Forms.MonthCalendar.TrailingForeColor%2A> properties has no effect. This is because an updated version of the calendar is rendered with an appearance that is derived at run time from the current operating system theme. If you want to use these properties and enable the earlier version of the calendar, you can disable visual styles for your application. Disabling visual styles might affect the appearance and behavior of other controls in your application. To disable visual styles in Visual Basic, open the Project Designer and uncheck the **Enable XP visual styles** check box. To disable visual styles in C#, open Program.cs and comment out `Application.EnableVisualStyles();`. For more information about visual styles, see [How to: Enable Windows XP Visual Styles](http://msdn.microsoft.com/library/0a038ade-31cf-4e56-9cfe-7a1e6b83b57f).  
  
### To display the current date at the bottom of the control  
  
-   Set the <xref:System.Windows.Forms.MonthCalendar.ShowToday%2A> property to `true`. The example below toggles between displaying and omitting today's date when the form is double-clicked.  
  
    ```vb  
    Private Sub Form1_DoubleClick(ByVal sender As Object, _  
    ByVal e As System.EventArgs) Handles MyBase.DoubleClick  
       ' Toggle between True and False.  
       MonthCalendar1.ShowToday = Not MonthCalendar1.ShowToday  
    End Sub  
    ```  
  
    ```csharp  
    private void Form1_DoubleClick(object sender, System.EventArgs e)  
    {  
       // Toggle between True and False.  
       monthCalendar1.ShowToday = !monthCalendar1.ShowToday;  
    }  
    ```  
  
    ```cpp  
    private:  
       System::Void Form1_DoubleClick(System::Object ^  sender,  
          System::EventArgs ^  e)  
       {  
          // Toggle between True and False.  
          monthCalendar1->ShowToday = !monthCalendar1->ShowToday;  
       }  
    ```  
  
     ([!INCLUDE[csprcs](../../../../includes/csprcs-md.md)], [!INCLUDE[vcprvc](../../../../includes/vcprvc-md.md)]) Place the following code in the form's constructor to register the event handler.  
  
    ```csharp  
    this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);  
    ```  
  
    ```cpp  
    this->DoubleClick += gcnew System::EventHandler(this,  
       &Form1::Form1_DoubleClick);  
    ```  
  
### To display week numbers  
  
-   Set the <xref:System.Windows.Forms.MonthCalendar.ShowWeekNumbers%2A> property to `true`. You can set this property either in code or in the Properties window.  
  
     Week numbers appear in a separate column to the left of the first day of the week.  
  
    ```vb  
    MonthCalendar1.ShowWeekNumbers = True  
    ```  
  
    ```csharp  
    monthCalendar1.ShowWeekNumbers = true;  
    ```  
  
    ```cpp  
    monthCalendar1->ShowWeekNumbers = true;  
    ```  
  
## See Also  
 [MonthCalendar Control](../../../../docs/framework/winforms/controls/monthcalendar-control-windows-forms.md)  
 [How to: Select a Range of Dates in the Windows Forms MonthCalendar Control](../../../../docs/framework/winforms/controls/how-to-select-a-range-of-dates-in-the-windows-forms-monthcalendar-control.md)  
 [How to: Display Specific Days in Bold with the Windows Forms MonthCalendar Control](../../../../docs/framework/winforms/controls/display-specific-days-in-bold-with-wf-monthcalendar-control.md)  
 [How to: Display More than One Month in the Windows Forms MonthCalendar Control](../../../../docs/framework/winforms/controls/display-more-than-one-month-wf-monthcalendar-control.md)
