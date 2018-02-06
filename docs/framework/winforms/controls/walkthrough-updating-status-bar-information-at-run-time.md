---
title: "Walkthrough: Updating Status Bar Information at Run Time"
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
  - "status bars [Windows Forms], updating at run time"
  - "status bars [Windows Forms], refreshing panels"
  - "StatusBar control [Windows Forms], refreshing panels"
  - "panels [Windows Forms], refreshing status bar"
ms.assetid: cc2abb06-c082-49f7-a5a3-2fd1bbcb58d1
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Updating Status Bar Information at Run Time
> [!IMPORTANT]
>  The <xref:System.Windows.Forms.StatusStrip> and <xref:System.Windows.Forms.ToolStripStatusLabel> controls replace and add functionality to the <xref:System.Windows.Forms.StatusBar> and <xref:System.Windows.Forms.StatusBarPanel> controls; however, the <xref:System.Windows.Forms.StatusBar> and <xref:System.Windows.Forms.StatusBarPanel> controls are retained for both backward compatibility and future use, if you choose.  
  
 Often, a program will call for you to update the contents of status bar panels dynamically at run time, based on changes to application state or other user interaction. This is a common way to signal users that keys such as the CAPS LOCK, NUM LOCK, or SCROLL LOCK are enabled, or to provide the date or a clock as a convenient reference.  
  
 In the following example, you will use an instance of the <xref:System.Windows.Forms.StatusBarPanel> class to host a clock.  
  
### To get the status bar ready for updating  
  
1.  Create a new Windows form.  
  
2.  Add a <xref:System.Windows.Forms.StatusBar> control to your form. For details, see [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md).  
  
3.  Add a status bar panel to your <xref:System.Windows.Forms.StatusBar> control. For details, see [How to: Add Panels to a StatusBar Control](../../../../docs/framework/winforms/controls/how-to-add-panels-to-a-statusbar-control.md).  
  
4.  For the <xref:System.Windows.Forms.StatusBar> control you added to your form, set the <xref:System.Windows.Forms.StatusBar.ShowPanels%2A> property to `true`.  
  
5.  Add a Windows Forms <xref:System.Windows.Forms.Timer> component to the form.  
  
    > [!NOTE]
    >  The Windows Forms <xref:System.Windows.Forms.Timer?displayProperty=nameWithType> component is designed for a Windows Forms environment. If you need a timer that is suitable for a server environment, see [Introduction to Server-Based Timers](http://msdn.microsoft.com/library/adc0bc0a-a519-4812-bafc-fb9d1a5801fc).  
  
6.  Set the <xref:System.Windows.Forms.Timer.Enabled%2A> property to `true`.  
  
7.  Set the <xref:System.Windows.Forms.Timer.Interval%2A> property of the <xref:System.Windows.Forms.Timer> to 30000.  
  
    > [!NOTE]
    >  The <xref:System.Windows.Forms.Timer.Interval%2A> property of the <xref:System.Windows.Forms.Timer> component is set to 30 seconds (30,000 milliseconds) to ensure that an accurate time is reflected in the time displayed.  
  
### To implement the timer to update the status bar  
  
1.  Insert the following code into the event handler of the <xref:System.Windows.Forms.Timer> component to update the panel of the <xref:System.Windows.Forms.StatusBar> control.  
  
    ```vb  
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick  
       StatusBar1.Panels(0).Text = Now.ToShortTimeString  
    End Sub  
    ```  
  
    ```csharp  
    private void timer1_Tick(object sender, System.EventArgs e)  
    {  
       statusBar1.Panels[0].Text = DateTime.Now.ToShortTimeString();  
    }  
    ```  
  
    ```cpp  
    private:  
      System::Void timer1_Tick(System::Object ^ sender,  
        System::EventArgs ^ e)  
      {  
        statusBar1->Panels[0]->Text =  
          DateTime::Now.ToShortTimeString();  
      }  
    ```  
  
     At this point, you are ready to run the application and observe the clock running in the status bar panel.  
  
### To test the application  
  
1.  Debug the application and press F5 to run it. For details about debugging, see [Debugging in Visual Studio](/visualstudio/debugger/debugging-in-visual-studio).  
  
    > [!NOTE]
    >  It will take approximately 30 seconds for the clock to appear in the status bar. This is to get the most accurate time possible. Conversely, to make the clock appear sooner, you can reduce the value of the <xref:System.Windows.Forms.Timer.Interval%2A> property you set in step 7 in the previous procedure.  
  
## See Also  
 <xref:System.Windows.Forms.StatusBar>  
 <xref:System.Windows.Forms.ToolStripStatusLabel>  
 [How to: Add Panels to a StatusBar Control](../../../../docs/framework/winforms/controls/how-to-add-panels-to-a-statusbar-control.md)  
 [How to: Determine Which Panel in the Windows Forms StatusBar Control Was Clicked](../../../../docs/framework/winforms/controls/determine-which-panel-wf-statusbar-control-was-clicked.md)  
 [StatusBar Control Overview](../../../../docs/framework/winforms/controls/statusbar-control-overview-windows-forms.md)
