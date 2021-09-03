---
title: "UI Automation Support for Standard Controls"
description: Get information about UI Automation support for standard controls in applications developed for Windows Presentation Foundation (WPF), Win32, and Windows Forms.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "controls, UI Automation support for"
  - "UI Automation, support for standard controls"
ms.assetid: 3770ea8a-2655-4add-9c59-fe0610ad5084
---
# UI Automation Support for Standard Controls

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic contains information about Microsoft UI Automation support for standard controls in applications developed for the WPF, Win32, and Windows Forms frameworks.

<a name="Windows_Presentation_Foundation_Controls"></a>

## Windows Presentation Foundation Controls

 All WPF control elements that provide information or support for user interaction have full native support for UI Automation. Other elements, such as panels, are not visible to UI Automation.

<a name="Win32_Controls"></a>

## Win32 Controls

 Most Win32 controls are exposed to Microsoft UI Automation through client-side providers in UIAutomationClientsideProviders.dll. This assembly is automatically registered for use with UI Automation client applications.

 Full support is provided only for controls from version 6 of *ComCtrl32.dll*.

 The following controls are supported.

|Class name|Control Type|
|----------------|------------------|
|Button|Button|
|Button|RadioButton|
|Button|Group|
|Button|CheckBox|
|Button|Hyperlink|
|Button|SplitButton|
|Button|CheckBox|
|ComboBoxEx32|ComboBox|
|ComboBox|ComboBox|
|Edit|Document|
|Edit|Edit|
|SysLink|Hyperlink|
|Static|Text|
|Static|Image|
|SysIPAddress32|Custom|
|SysHeader32|Header/HeaderItem|
|SysListView32|DataGrid|
|SysListView32|List|
|ListBox|List|
|ListBox|ListItem|
|#32768|Menu|
|#32768|MenuItem|
|msctls_progress32|ProgressBar|
|RichEdit|Document. See note.|
|RichEdit20A|Document|
|RichEdit20W|Document|
|RichEdit50W|Document|
|ScrollBar|Slider|
|msctls_trackbar32|Slider|
|msctls_updown32|Spinner|
|msctls_statusbar32|StatusBar|
|SysTabControl32|Tab|
|SysTabControl32|TabItem|
|ToolbarWindow32|ToolBar|
|ToolbarWindow32|MenuItem|
|ToolbarWindow32|Button|
|ToolbarWindow32|CheckBox|
|ToolbarWindow32|RadioButton|
|ToolbarWindow32|Separator|
|tooltips_class32|ToolTip|
|#32774|ToolTip|
|ReBarWindow32|Toolbar|
|SysTreeView32|Tree|
|SysTreeView32|TreeItem|

 **Note** The RichEdit control is supported only for versions shipped with Windows Vista (in RichEd20.dll version 3.1 and later, and MsftEdit.dll version 4.1 and later).

 The following controls are not supported.

|Class name|Control type|
|----------------|------------------|
|SysAnimate32|Image|
|SysPager|Spinner|
|SysDateTimePick32|Custom|
|SysMonthCal32|Calendar|
|MS_WINNOTE|Tooltip|
|VBBubble|Tooltip|
|ScrollBar (when used as a standalone control)|Slider|
|SuperGrid|Custom|

<a name="Windows_Forms_Controls"></a>

## Windows Forms Controls

 Windows Forms controls are exposed to Microsoft UI Automation through client-side providers in UIAutomationClientsideProviders.dll. This assembly is automatically registered for use with UI Automation client applications.

 Typically, Windows Forms controls that are managed wrappers for Win32 common controls are supported by UI Automation. The following controls are supported.

|Class Name|
|----------------|
|Button|
|CheckBox|
|CheckedListBox|
|ColorDialog|
|ComboBox|
|FolderBrowser|
|FontDialog|
|GroupBox|
|HscrollBar|
|ImageList|
|Label|
|ListBox|
|ListView|
|MainMenu/ContextMenu|
|MonthCalendar|
|NotifyIcon|
|OpenFileDialog|
|PageSetupDialog|
|PrintDialog|
|ProgressBar|
|RadioButton|
|RichTextBox|
|SaveFileDialog|
|ScrollableControl|
|SoundPlayer|
|StatusBar|
|TabControl/TabPage|
|TextBox|
|Timer|
|Toolbar|
|ToolTip|
|TrackBar|
|TreeView|
|VscrollBar|
|WebBrowser|

 The following controls are exposed to Microsoft UI Automation only through their support for Microsoft Active Accessibility. Some functionality may not be available.

|Control Name|
|------------------|
|BindingSource|
|DataGrid|
|DataGridView|
|DataNavigator|
|DomainUpDown|
|ErrorProvider|
|FlowLayoutPanel|
|Form|
|LinkLabel|
|HelpProvider|
|MaskedTextBox|
|MenuStrip/ContextMenuStrip|
|NumericUpDown|
|Panel|
|PictureBox|
|PrintDocument|
|PrintPreview-Control|
|PrintPreview-Dialog|
|PropertyGrid|
|UserControl|
|ToolStrip|
|TableLayoutPanel|
|SplitContainer/SplitterPanel|
|Splitter|
|RaftingContainer|
|StatusStrip|

## See also

- [UI Automation Control Types](ui-automation-control-types.md)
