---
title: "Windows Forms Controls by Function"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "controls [Windows Forms], by function"
  - "Windows Forms, controls by function"
  - "Windows Forms controls, list of"
ms.assetid: 5e65a6c3-5d6f-480d-beb8-b28f865f07e3
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Windows Forms Controls by Function
Windows Forms offers controls and components that perform a number of functions. The following table lists the Windows Forms controls and components according to general function. In addition, where multiple controls exist that serve the same function, the recommended control is listed with a note regarding the control it superseded. In a separate subsequent table, the superseded controls are listed with their recommended replacements.  
  
> [!NOTE]
>  The following tables do not list every control or component you can use in Windows Forms; for a more comprehensive list, see [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)  
  
## Recommended Controls and Components by Function  
  
|Function|Control|Description|  
|--------------|-------------|-----------------|  
|Data display|<xref:System.Windows.Forms.DataGridView> control|The <xref:System.Windows.Forms.DataGridView> control provides a customizable table for displaying data. The <xref:System.Windows.Forms.DataGridView> class enables customization of cells, rows, columns, and borders. **Note:**  The <xref:System.Windows.Forms.DataGridView> control provides numerous basic and advanced features that are missing in the <xref:System.Windows.Forms.DataGrid> control. For more information, see [Differences Between the Windows Forms DataGridView and DataGrid Controls](../../../../docs/framework/winforms/controls/differences-between-the-windows-forms-datagridview-and-datagrid-controls.md)|  
|Data binding and navigation|<xref:System.Windows.Forms.BindingSource> component|Simplifies binding controls on a form to data by providing currency management, change notification, and other services.|  
||<xref:System.Windows.Forms.BindingNavigator> control|Provides a toolbar-type interface to navigate and manipulate data on a form.|  
|Text editing|<xref:System.Windows.Forms.TextBox> control|Displays text entered at design time that can be edited by users at run time, or changed programmatically.|  
||<xref:System.Windows.Forms.RichTextBox> control|Enables text to be displayed with formatting in plain text or rich-text format (RTF).|  
||<xref:System.Windows.Forms.MaskedTextBox> control|Constrains the format of user input|  
|Information display (read-only)|<xref:System.Windows.Forms.Label> control|Displays text that users cannot directly edit.|  
||<xref:System.Windows.Forms.LinkLabel> control|Displays text as a Web-style link and triggers an event when the user clicks the special text. Usually the text is a link to another window or a Web site.|  
||<xref:System.Windows.Forms.StatusStrip> control|Displays information about the application's current state using a framed area, usually at the bottom of a parent form.|  
||<xref:System.Windows.Forms.ProgressBar> control|Displays the current progress of an operation to the user.|  
|Web page display|<xref:System.Windows.Forms.WebBrowser> control|Enables the user to navigate Web pages inside your form.|  
|Selection from a list|<xref:System.Windows.Forms.CheckedListBox> control|Displays a scrollable list of items, each accompanied by a check box.|  
||<xref:System.Windows.Forms.ComboBox> control|Displays a drop-down list of items.|  
||<xref:System.Windows.Forms.DomainUpDown> control|Displays a list of text items that users can scroll through with up and down buttons.|  
||<xref:System.Windows.Forms.ListBox> control|Displays a list of text and graphical items (icons).|  
||<xref:System.Windows.Forms.ListView> control|Displays items in one of four different views. Views include text only, text with small icons, text with large icons, and a details view.|  
||<xref:System.Windows.Forms.NumericUpDown> control|Displays a list of numerals that users can scroll through with up and down buttons.|  
||<xref:System.Windows.Forms.TreeView> control|Displays a hierarchical collection of node objects that can consist of text with optional check boxes or icons.|  
|Graphics display|<xref:System.Windows.Forms.PictureBox> control|Displays graphical files, such as bitmaps and icons, in a frame.|  
|Graphics storage|<xref:System.Windows.Forms.ImageList> control|Serves as a repository for images. <xref:System.Windows.Forms.ImageList> controls and the images they contain can be reused from one application to the next.|  
|Value setting|<xref:System.Windows.Forms.CheckBox> control|Displays a check box and a label for text. Generally used to set options.|  
||<xref:System.Windows.Forms.CheckedListBox> control|Displays a scrollable list of items, each accompanied by a check box.|  
||<xref:System.Windows.Forms.RadioButton> control|Displays a button that can be turned on or off.|  
||<xref:System.Windows.Forms.TrackBar> control|Allows users to set values on a scale by moving a "thumb" along a scale.|  
|Date setting|<xref:System.Windows.Forms.DateTimePicker> control|Displays a graphical calendar to allow users to select a date or a time.|  
||<xref:System.Windows.Forms.MonthCalendar> control|Displays a graphical calendar to allow users to select a range of dates.|  
|Dialog boxes|<xref:System.Windows.Forms.ColorDialog> control|Displays the color picker dialog box that allows users to set the color of an interface element.|  
||<xref:System.Windows.Forms.FontDialog> control|Displays a dialog box that allows users to set a font and its attributes.|  
||<xref:System.Windows.Forms.OpenFileDialog> control|Displays a dialog box that allows users to navigate to and select a file.|  
||<xref:System.Windows.Forms.PrintDialog> control|Displays a dialog box that allows users to select a printer and set its attributes.|  
||<xref:System.Windows.Forms.PrintPreviewDialog> control|Displays a dialog box that displays how a control <xref:System.Drawing.Printing.PrintDocument> component will appear when printed.|  
||<xref:System.Windows.Forms.FolderBrowserDialog> control|Displays a dialog that allows users to browse, create, and eventually select a folder|  
||<xref:System.Windows.Forms.SaveFileDialog> control|Displays a dialog box that allows users to save a file.|  
|Menu controls|<xref:System.Windows.Forms.MenuStrip> control|Creates custom menus. **Note:**  The <xref:System.Windows.Forms.MenuStrip> is designed to replace the <xref:System.Windows.Forms.MainMenu> control.|  
||<xref:System.Windows.Forms.ContextMenuStrip> control|Creates custom context menus. **Note:**  The <xref:System.Windows.Forms.ContextMenuStrip> is designed to replace the <xref:System.Windows.Forms.ContextMenu> control.|  
|Commands|<xref:System.Windows.Forms.Button> control|Starts, stops, or interrupts a process.|  
||<xref:System.Windows.Forms.LinkLabel> control|Displays text as a Web-style link and triggers an event when the user clicks the special text. Usually the text is a link to another window or a Web site.|  
||<xref:System.Windows.Forms.NotifyIcon> control|Displays an icon in the status notification area of the taskbar that represents an application running in the background.|  
||<xref:System.Windows.Forms.ToolStrip> control|Creates toolbars that can have a Microsoft Windows XP, Microsoft Office, Microsoft Internet Explorer, or custom look and feel, with or without themes, and with support for overflow and run-time item reordering. **Note:**  The <xref:System.Windows.Forms.ToolStrip> control is designed to replace the <xref:System.Windows.Forms.ToolBar> control.|  
|User Help|<xref:System.Windows.Forms.HelpProvider> component|Provides pop-up or online Help for controls.|  
||<xref:System.Windows.Forms.ToolTip> component|Provides a pop-up window that displays a brief description of a control's purpose when the user rests the pointer on the control.|  
|Grouping other controls|<xref:System.Windows.Forms.Panel> control|Groups a set of controls on an unlabeled, scrollable frame.|  
||<xref:System.Windows.Forms.GroupBox> control|Groups a set of controls (such as radio buttons) on a labeled, nonscrollable frame.|  
||<xref:System.Windows.Forms.TabControl> control|Provides a tabbed page for organizing and accessing grouped objects efficiently.|  
||<xref:System.Windows.Forms.SplitContainer> control|Provides two panels separated by a movable bar. **Note:**  The <xref:System.Windows.Forms.SplitContainer> control is designed to replace the <xref:System.Windows.Forms.Splitter> control.|  
||<xref:System.Windows.Forms.TableLayoutPanel> control|Represents a panel that dynamically lays out its contents in a grid composed of rows and columns.|  
||<xref:System.Windows.Forms.FlowLayoutPanel> control|Represents a panel that dynamically lays out its contents horizontally or vertically.|  
|Audio|<xref:System.Media.SoundPlayer> control|Plays sound files in the .wav format. Sounds can be loaded or played asynchronously.|  
  
## Superseded Controls and Components by Function  
  
|Function|Superseded control|Recommended replacement|  
|--------------|------------------------|-----------------------------|  
|Data display|<xref:System.Windows.Forms.DataGrid>|<xref:System.Windows.Forms.DataGridView>|  
|Information Display (Read-only controls)|<xref:System.Windows.Forms.StatusBar>|<xref:System.Windows.Forms.StatusStrip>|  
|Menu controls|<xref:System.Windows.Forms.ContextMenu>|<xref:System.Windows.Forms.ContextMenuStrip>|  
||<xref:System.Windows.Forms.MainMenu>|<xref:System.Windows.Forms.MenuStrip>|  
|Commands|<xref:System.Windows.Forms.ToolBar>|<xref:System.Windows.Forms.ToolStrip>|  
||<xref:System.Windows.Forms.StatusBar>|<xref:System.Windows.Forms.StatusStrip>|  
|Form layout|<xref:System.Windows.Forms.Splitter>|<xref:System.Windows.Forms.SplitContainer>|  
  
## See Also  
 [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)  
 [Developing Custom Windows Forms Controls with the .NET Framework](../../../../docs/framework/winforms/controls/developing-custom-windows-forms-controls.md)
