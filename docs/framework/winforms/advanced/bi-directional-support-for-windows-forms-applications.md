---
title: "Bi-Directional Support for Windows Forms Applications"
ms.date: "09/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-winforms"
ms.topic: "article"
helpviewer_keywords: 
  - "globalization [Windows Forms], bi-directional support in Windows"
  - "Windows Forms, international"
  - "localization [Windows Forms], bi-directional support in Windows"
  - "bi-directional language support [Windows Forms], Windows applications"
  - "Windows Forms, bi-directional support"
author: rpetrusha
ms.author: ronpet
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Bi-Directional Support for Windows Forms Applications
You can use [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] to create Windows-based applications that support bi-directional (right-to-left) languages such as Arabic and Hebrew. This includes standard forms, dialog boxes, MDI forms, and all the controls you can work with in these forms—that is, all the objects in the <xref:System.Windows.Forms.Control> namespace.  
  
## Culture Support  
 Culture and UI culture settings determine how an application works with dates, times, currency, and other information. Support for culture and UI culture is the same for bi-directional languages as it is for any other languages.   Also see [Culture-Specific Classes for Global Windows Forms and Web Forms](http://msdn.microsoft.com/library/94ye9x8c\(v=vs.110\)) or [Culture-Specific Classes for Global Windows Forms and Web Forms](http://msdn.microsoft.com/library/94ye9x8c\(v=vs.120\))  
  
## RightToLeft and RightToLeftLayout Properties  
 The base <xref:System.Windows.Forms.Control> class, from which forms derive, includes a <xref:System.Windows.Forms.Control.RightToLeft%2A> property that you can set to change the reading order of a form and its controls. If you set the form's <xref:System.Windows.Forms.Control.RightToLeft%2A> property, by default controls on the form inherit this setting. However, you can also set the <xref:System.Windows.Forms.Control.RightToLeft%2A> property individually on most controls. Also see [How to: Display Right-to-Left Text in Windows Forms for Globalization](http://msdn.microsoft.com/library/7d3337xw\(v=vs.110\)).  
  
 The effect of the <xref:System.Windows.Forms.Control.RightToLeft%2A> property can differ from one control to another. In some controls the property only sets the reading order, as in the <xref:System.Windows.Forms.Button>, <xref:System.Windows.Forms.TreeView> and <xref:System.Windows.Forms.ToolTip> controls. In other controls, the <xref:System.Windows.Forms.Control.RightToLeft%2A> property changes both reading order and layout. This includes the <xref:System.Windows.Forms.RadioButton>, <xref:System.Windows.Forms.ComboBox> and <xref:System.Windows.Forms.CheckBox> controls. Other controls require that the <xref:System.Windows.Forms.Form.RightToLeftLayout%2A> property be applied to mirror its layout from right to left. The following table provides details on how the <xref:System.Windows.Forms.Control.RightToLeft%2A> and <xref:System.Windows.Forms.Form.RightToLeftLayout%2A> properties affect individual Windows Forms controls.  
  
|Control/Component|Effect of RightToLeft property|Effect of RightToLeftLayout property|Requires mirroring?|  
|------------------------|------------------------------------|------------------------------------------|-------------------------|  
|<xref:System.Windows.Forms.Button>|Sets the RTL reading order. Reverses <xref:System.Windows.Forms.ButtonBase.TextAlign%2A>, <xref:System.Windows.Forms.ButtonBase.ImageAlign%2A>, and <xref:System.Windows.Forms.ButtonBase.TextImageRelation%2A>|No effect|No|  
|<xref:System.Windows.Forms.CheckBox>|The check box is displayed on the right side of the text|No effect|No|  
|<xref:System.Windows.Forms.CheckedListBox>|All the check boxes are displayed on the right side of the text|No effect|No|  
|<xref:System.Windows.Forms.ColorDialog>|Not affected; depends on the language of the operating system|No effect|No|  
|<xref:System.Windows.Forms.ComboBox>|Items in combo box control are right-aligned|No effect|No|  
|<xref:System.Windows.Forms.ContextMenu>|Appears right-aligned with RTL reading order|No effect|No|  
|<xref:System.Windows.Forms.DataGrid>|Appears right-aligned with RTL reading order|No effect|No|  
|<xref:System.Windows.Forms.DataGridView>|Affects both RTL reading order and control layout|No effect|No|  
|<xref:System.Windows.Forms.DateTimePicker>|Not affected; depends on the language of the operating system|Mirrors the control|Yes|  
|<xref:System.Windows.Forms.DomainUpDown>|Left-aligns the up and down buttons|No effect|No|  
|<xref:System.Windows.Forms.ErrorProvider>|Not supported|No effect|No|  
|<xref:System.Windows.Forms.FontDialog>|Depends on the language of the operating system|No effect|No|  
|<xref:System.Windows.Forms.Form>|Sets RTL reading order, and reverses scrollbars|Mirrors the form|Yes|  
|<xref:System.Windows.Forms.GroupBox>|The caption is displayed right aligned. Child controls may inherit this property.|Use a <xref:System.Windows.Forms.TableLayoutPanel> within the control for right-to-left mirroring support|No|  
|<xref:System.Windows.Forms.HScrollBar>|Starts with the scroll box (thumb) right-aligned|No effect|No|  
|<xref:System.Windows.Forms.ImageList>|Not required|No effect|No|  
|<xref:System.Windows.Forms.Label>|Displayed right-aligned. Reverses <xref:System.Windows.Forms.Label.TextAlign%2A> and <xref:System.Windows.Forms.Label.ImageAlign%2A>|No effect|No|  
|<xref:System.Windows.Forms.LinkLabel>|Displayed right-aligned. Reverses <xref:System.Windows.Forms.Label.TextAlign%2A> and <xref:System.Windows.Forms.Label.ImageAlign%2A>|No effect|No|  
|<xref:System.Windows.Forms.ListBox>|Items are right-aligned|No effect|No|  
|<xref:System.Windows.Forms.ListView>|Sets the reading order to RTL; elements stay left-aligned|Mirrors the control|Yes|  
|<xref:System.Windows.Forms.MainMenu>|Displayed right-aligned with RTL reading order at run time (not at design time)|No effect|No|  
|<xref:System.Windows.Forms.MaskedTextBox>|Displays text from right to left.|No effect|No|  
|<xref:System.Windows.Forms.MonthCalendar>|Not affected; depends on the language of the operating system|Mirrors the control|Yes|  
|<xref:System.Windows.Forms.NotifyIcon>|Not supported|Not supported|No|  
|<xref:System.Windows.Forms.NumericUpDown>|Up and down buttons are left-aligned|No effect|No|  
|<xref:System.Windows.Forms.OpenFileDialog>|On right-to-left operating systems, setting the containing form's <xref:System.Windows.Forms.Control.RightToLeft> property to <xref:System.Windows.Forms.RightToLeft.Yes?displayProperty=nameWithType> localizes the dialog |No effect|No|  
|<xref:System.Windows.Forms.PageSetupDialog>|Not affected; depends on the language of the operating system|No effect|No|  
|<xref:System.Windows.Forms.Panel>|Child controls may inherit this property|Use <xref:System.Windows.Forms.TableLayoutPanel> within the control for right to left support|Yes|  
|<xref:System.Windows.Forms.PictureBox>|Not supported|No effect|No|  
|<xref:System.Windows.Forms.PrintDialog>|Not affected; depends on the language of the operating system|No effect|No|  
|<xref:System.Drawing.Printing.PrintDocument>|The vertical scroll bar become left-aligned and the horizontal scroll bar starts from the left|No effect|No|  
|<xref:System.Windows.Forms.PrintPreviewDialog>|Not supported|Not supported|No|  
|<xref:System.Windows.Forms.ProgressBar>|Not affect by this property|Mirrors the control|Yes|  
|<xref:System.Windows.Forms.RadioButton>|The radio button is displayed on the right side of the text|No effect|No|  
|<xref:System.Windows.Forms.RichTextBox>|Control elements that include text are displayed from right to left with RTL reading order|No effect|No|  
|<xref:System.Windows.Forms.SaveFileDialog>|Not affected; depends on the language of the operating system|No effect|No|  
|<xref:System.Windows.Forms.SplitContainer>|Panel layout is reversed; vertical scrollbar appears on the left; horizontal scrollbar starts from the right|Use a <xref:System.Windows.Forms.TableLayoutPanel> to mirror order of child controls|No|  
|<xref:System.Windows.Forms.Splitter>|Not supported|No effect|No|  
|<xref:System.Windows.Forms.StatusBar>|Not supported; use <xref:System.Windows.Forms.StatusStrip> instead|No effect; use <xref:System.Windows.Forms.StatusStrip> instead|No|  
|<xref:System.Windows.Forms.TabControl>|Not affected by this property|Mirrors the control|Yes|  
|<xref:System.Windows.Forms.TextBox>|Displays text from right to left with RTL reading order|No effect|No|  
|<xref:System.Windows.Forms.Timer>|Not required|Not required|No|  
|<xref:System.Windows.Forms.ToolBar>|Not affected by this property; use <xref:System.Windows.Forms.ToolStrip> instead|No effect; use <xref:System.Windows.Forms.ToolStrip> instead|Yes|  
|<xref:System.Windows.Forms.ToolTip>|Sets the RTL reading order|No effect|No|  
|<xref:System.Windows.Forms.TrackBar>|The scroll or track starts from the right; when <xref:System.Windows.Forms.TrackBar.Orientation%2A> is vertical, ticks occur from the right|No effect|No|  
|<xref:System.Windows.Forms.TreeView>|Sets the RTL reading order only|Mirrors the control|Yes|  
|<xref:System.Windows.Forms.UserControl>|Vertical scrollbar appears on the left; horizontal scrollbar has thumb on the right|No direct support; use a <xref:System.Windows.Forms.TableLayoutPanel>|No|  
|<xref:System.Windows.Forms.VScrollBar>|Displayed on the left side instead of right side of scrollable controls|No effect|No|  
  
## Encoding  
 Windows Forms support Unicode, so you can include any character set when you create your bi-directional applications. However, not all Windows Forms controls support Unicode on all platforms. For more information, see [Encoding and Windows Forms Globalization](../../../../docs/framework/winforms/advanced/encoding-and-windows-forms-globalization.md).  
  
## GDI+  
 You can use [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] to draw text with right-to-left reading order. The <xref:System.Drawing.Graphics.DrawString%2A> method, which is used to draw text, supports a `StringFormat` parameter that you can set to the <xref:System.Drawing.StringFormatFlags.DirectionRightToLeft> member of the <xref:System.Drawing.StringFormatFlags> enumeration in order to reverse the point of origin for the text.  
  
## Common Dialog Boxes  
 System tools such as the File Open dialog box are under the control of Windows. They inherit language elements from the operating system. If you are using a version of Windows with the correct language settings, these dialog boxes will work correctly with bi-directional languages.  
  
 Similarly, message boxes go through the operating system and support bi-directional text. The captions on message box buttons are based on the current language setting. By default, message boxes do not use right-to-left reading order, but you can specify a parameter to change the reading order when the message boxes are displayed.  
  
## RightToLeft, Scrollbars, and ScrollableControl  
 There is currently a limitation in Windows Forms that prevents all classes derived from <xref:System.Windows.Forms.ScrollableControl> from acting properly when both <xref:System.Windows.Forms.Control.RightToLeft%2A> is enabled and <xref:System.Windows.Forms.ScrollableControl.AutoScroll%2A> is set to <xref:System.Windows.Forms.RightToLeft.Yes>. For example, let's say that you place a control such as <xref:System.Windows.Forms.Panel>—or a container class derived from <xref:System.Windows.Forms.Panel> (such as <xref:System.Windows.Forms.FlowLayoutPanel> or <xref:System.Windows.Forms.TableLayoutPanel>)—on your form. If you set <xref:System.Windows.Forms.ScrollableControl.AutoScroll%2A> on the container to <xref:System.Windows.Forms.RightToLeft.Yes> and then set the <xref:System.Windows.Forms.Control.Anchor%2A> property on one or more of the controls inside of the container to <xref:System.Windows.Forms.AnchorStyles.Right>, then no scrollbar ever appears. The class derived from <xref:System.Windows.Forms.ScrollableControl> acts as if <xref:System.Windows.Forms.ScrollableControl.AutoScroll%2A> were set to <xref:System.Windows.Forms.RightToLeft.No>.  
  
 Currently, the only workaround is to nest the <xref:System.Windows.Forms.ScrollableControl> inside another <xref:System.Windows.Forms.ScrollableControl>. For instance, if you need <xref:System.Windows.Forms.TableLayoutPanel> to work in this situation, you can place it inside of a <xref:System.Windows.Forms.Panel> control and set <xref:System.Windows.Forms.ScrollableControl.AutoScroll%2A> on the <xref:System.Windows.Forms.Panel> to <xref:System.Windows.Forms.RightToLeft.Yes>.  
  
## Mirroring  
 *Mirroring* refers to reversing the layout of UI elements so that they flow from right to left. In a mirrored Windows Form, for example, the Minimize, Maximize, and Close buttons appear left-most on the title bar, not right-most.  
  
 Setting a form or control's <xref:System.Windows.Forms.Control.RightToLeft%2A> property to `true` reverses the reading order of elements on a form, but this setting does not reverse the layout to be right-to-left— that is, it does not cause mirroring. For example, setting this property does not move the **Minimize**, **Maximize**, and **Close** buttons in the form's title bar to the left side of the form. Similarly, some controls, such as the <xref:System.Windows.Forms.TreeView> control, require mirroring in order to change their display to be appropriate for Arabic or Hebrew. You can mirror these controls by settings the <xref:System.Windows.Forms.Form.RightToLeftLayout%2A> property.  
  
 You can create mirrored versions of the following controls:  
  
-   <xref:System.Windows.Forms.ColumnHeader.ListView%2A>  
  
-   <xref:System.Windows.Forms.Panel>  
  
-   <xref:System.Windows.Forms.StatusBar>  
  
-   <xref:System.Windows.Forms.TabControl>  
  
-   <xref:System.Windows.Forms.TabPage>  
  
-   <xref:System.Windows.Forms.ToolBar>  
  
-   <xref:System.Windows.Forms.TreeView>  
  
 Some controls are sealed. Therefore, you cannot derive a new control from them. These include the <xref:System.Windows.Forms.ImageList> and <xref:System.Windows.Forms.ProgressBar> controls.  
  
## See Also  
 [Bidirectional Support for ASP.NET Web Applications](http://msdn.microsoft.com/library/5576f9b1-9b86-41ef-8354-092d366bcd03)  
 [Globalizing Windows Forms](../../../../docs/framework/winforms/advanced/globalizing-windows-forms.md)
