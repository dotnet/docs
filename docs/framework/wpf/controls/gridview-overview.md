---
title: "GridView Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "GridView view mode [WPF]"
  - "ListView controls [WPF], GridView view mode"
  - "controls [WPF], ListView"
ms.assetid: b2d02267-32b3-40ce-8e9f-06972d8749d9
caps.latest.revision: 26
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# GridView Overview
<xref:System.Windows.Controls.GridView> view mode is one of the view modes for a <xref:System.Windows.Controls.ListView> control. The <xref:System.Windows.Controls.GridView> class and its supporting classes enable you and your users to view item collections in a table that typically uses buttons as interactive column headers. This topic introduces the <xref:System.Windows.Controls.GridView> class and outlines its use.  
  
  
  
<a name="DefiningaListViewthatusesGridViewView"></a>   
## What Is a GridView View?  
 The <xref:System.Windows.Controls.GridView> view mode displays a list of data items by binding data fields to columns and by displaying a column header to identify the field. The default <xref:System.Windows.Controls.GridView> style implements buttons as column headers. By using buttons for column headers, you can implement important user interaction capabilities; for example, users can click the column header to sort <xref:System.Windows.Controls.GridView> data according to the contents of a specific column.  
  
> [!NOTE]
>  The button controls that <xref:System.Windows.Controls.GridView> uses for column headers are derived from <xref:System.Windows.Controls.Primitives.ButtonBase>.  
  
 The following illustration shows a <xref:System.Windows.Controls.GridView> view of <xref:System.Windows.Controls.ListView> content.  
  
 **GridView view of ListView content**  
  
 ![Styled ListView](../../../../docs/framework/wpf/controls/media/styledlistview.PNG "StyledListView")  
  
 <xref:System.Windows.Controls.GridView> columns are represented by <xref:System.Windows.Controls.GridViewColumn> objects, which can automatically size to their content. Optionally, you can explicitly set a <xref:System.Windows.Controls.GridViewColumn> to a specific width. You can resize columns by dragging the gripper between column headers. You can also dynamically add, remove, replace, and reorder columns because this functionality is built into <xref:System.Windows.Controls.GridView>. However, <xref:System.Windows.Controls.GridView> cannot directly update the data that it displays.  
  
 The following example shows how to define a <xref:System.Windows.Controls.GridView> that displays employee data. In this example, <xref:System.Windows.Controls.ListView> defines the `EmployeeInfoDataSource` as the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A>. The property definitions of <xref:System.Windows.Controls.GridViewColumn.DisplayMemberBinding%2A> bind <xref:System.Windows.Controls.GridViewColumn> content to `EmployeeInfoDataSource` data categories.  
  
 [!code-xaml[ListViewCode#ListViewEmployee](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ListViewCode/CSharp/Window1.xaml#listviewemployee)]  
  
 The following illustration shows the table that the previous example creates.  
  
 **GridView that displays data from an ItemsSource**  
  
 ![ListView with GridView output](../../../../docs/framework/wpf/controls/media/listviewgridview.JPG "ListViewGridView")  
  
<a name="GridViewLayoutandStyle"></a>   
## GridView Layout and Style  
 The column cells and the column header of a <xref:System.Windows.Controls.GridViewColumn> have the same width. By default, each column sizes its width to fit its content. Optionally, you can set a column to a fixed width.  
  
 Related data content displays in horizontal rows. For example, in the previous illustration, each employee's last name, first name, and ID number are displayed as a set because they appear in a horizontal row.  
  
<a name="DefiningandStylingColumnsinaGridView"></a>   
### Defining and Styling Columns in a GridView  
 When defining the data field to display in a <xref:System.Windows.Controls.GridViewColumn>, use the <xref:System.Windows.Controls.GridViewColumn.DisplayMemberBinding%2A>, <xref:System.Windows.Controls.GridViewColumn.CellTemplate%2A>, or <xref:System.Windows.Controls.GridViewColumn.CellTemplateSelector%2A> properties. The <xref:System.Windows.Controls.GridViewColumn.DisplayMemberBinding%2A> property takes precedence over either of the template properties.  
  
 To specify the alignment of content in a column of a <xref:System.Windows.Controls.GridView>, define a <xref:System.Windows.Controls.GridViewColumn.CellTemplate%2A>. Do not use the <xref:System.Windows.Controls.Control.HorizontalContentAlignment%2A> and <xref:System.Windows.Controls.Control.VerticalContentAlignment%2A> properties for <xref:System.Windows.Controls.ListView> content that is displayed by using a <xref:System.Windows.Controls.GridView>.  
  
 To specify template and style properties for column headers, use the <xref:System.Windows.Controls.GridView>, <xref:System.Windows.Controls.GridViewColumn>, and <xref:System.Windows.Controls.GridViewColumnHeader> classes. For more information, see [GridView Column Header Styles and Templates Overview](../../../../docs/framework/wpf/controls/gridview-column-header-styles-and-templates-overview.md).  
  
<a name="AddingVisualElementstoaGridViewView"></a>   
### Adding Visual Elements to a GridView  
 To add visual elements, such as <xref:System.Windows.Controls.CheckBox> and <xref:System.Windows.Controls.Button> controls, to a <xref:System.Windows.Controls.GridView> view mode, use templates or styles.  
  
 If you explicitly define a visual element as a data item, it can appear only one time in a <xref:System.Windows.Controls.GridView>. This limitation exists because an element can have only one parent and therefore, can appear only one time in the visual tree.  
  
<a name="StylingRowsinaGridViewView"></a>   
### Styling Rows in a GridView  
 Use the <xref:System.Windows.Controls.GridViewRowPresenter> and <xref:System.Windows.Controls.GridViewHeaderRowPresenter> classes to format and display the rows of a <xref:System.Windows.Controls.GridView>. For an example of how to style rows in a <xref:System.Windows.Controls.GridView> view mode, see [Style a Row in a ListView That Implements a GridView](../../../../docs/framework/wpf/controls/how-to-style-a-row-in-a-listview-that-implements-a-gridview.md).  
  
<a name="AlignmentIssuesWhenUsingItemContainerStyle"></a>   
### Alignment Issues When You Use ItemContainerStyle  
 To prevent alignment issues between column headers and cells, do not set a property or specify a template that affects the width of an item in an <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A>. For example, do not set the <xref:System.Windows.FrameworkElement.Margin%2A> property or specify a <xref:System.Windows.Controls.ControlTemplate> that adds a <xref:System.Windows.Controls.CheckBox> to an <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A> that is defined on a <xref:System.Windows.Controls.ListView> control. Instead, specify the properties and templates that affect column width directly on classes that define a <xref:System.Windows.Controls.GridView> view mode.  
  
 For example, to add a <xref:System.Windows.Controls.CheckBox> to the rows in <xref:System.Windows.Controls.GridView> view mode, add the <xref:System.Windows.Controls.CheckBox> to a <xref:System.Windows.DataTemplate>, and then set the <xref:System.Windows.Controls.GridViewColumn.CellTemplate%2A> property to that <xref:System.Windows.DataTemplate>.  
  
<a name="InteractingwithaGridViewControl"></a>   
## User Interactions with a GridView  
 When you use a <xref:System.Windows.Controls.GridView> in your application, users can interact with and modify the formatting of the <xref:System.Windows.Controls.GridView>. For example, users can reorder columns, resize a column, select items in a table, and scroll through content. You can also define an event handler that responds when a user clicks the column header button. The event handler can perform operations like sorting the data that is displayed in the <xref:System.Windows.Controls.GridView> according to the contents of a column.  
  
 The following list discusses in more detail the capabilities of using <xref:System.Windows.Controls.GridView> for user interaction:  
  
-   **Reorder columns by using the drag-and-drop method.**  
  
     Users can reorder columns in a <xref:System.Windows.Controls.GridView> by pressing the left mouse button while it is over a column header and then dragging that column to a new position. While the user drags the column header, a floating version of the header is displayed as well as a solid black line that shows where to insert the column.  
  
     If you want to modify the default style for the floating version of a header, specify a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.GridViewColumnHeader> type that is triggered when the <xref:System.Windows.Controls.GridViewColumnHeader.Role%2A> property is set to <xref:System.Windows.Controls.GridViewColumnHeaderRole.Floating>. For more information, see [Create a Style for a Dragged GridView Column Header](../../../../docs/framework/wpf/controls/how-to-create-a-style-for-a-dragged-gridview-column-header.md).  
  
-   **Resize a column to its content.**  
  
     Users can double-click the gripper to the right of a column header in order to resize a column to fit its content.  
  
    > [!NOTE]
    >  You can set the <xref:System.Windows.Controls.GridViewColumn.Width%2A> property to `Double.NaN` to produce the same effect.  
  
-   **Select row items.**  
  
     Users can select one or more items in a <xref:System.Windows.Controls.GridView>.  
  
     If you want to change the <xref:System.Windows.Style> of a selected item, see [Use Triggers to Style Selected Items in a ListView](../../../../docs/framework/wpf/controls/how-to-use-triggers-to-style-selected-items-in-a-listview.md).  
  
-   **Scroll to view content that is not initially visible on the screen.**  
  
     If the size of the <xref:System.Windows.Controls.GridView> is not large enough to display all the items, users can scroll horizontally or vertically by using scrollbars, which are provided by a <xref:System.Windows.Controls.ScrollViewer> control. A <xref:System.Windows.Controls.Primitives.ScrollBar> is hidden if all the content is visible in a specific direction. Column headers do not scroll with a vertical scroll bar, but do scroll horizontally.  
  
-   **Interact with columns by clicking the column header buttons.**  
  
     When users click a column header button, they can sort the data that is displayed in the column if you have provided a sorting algorithm.  
  
     You can handle the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event for column header buttons in order to provide functionality like a sorting algorithm. To handle the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event for a single column header, set an event handler on the <xref:System.Windows.Controls.GridViewColumnHeader>. To set an event handler that handles the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event for all column headers, set the handler on the <xref:System.Windows.Controls.ListView> control.  
  
<a name="Obtaining_Other_Custom_Views"></a>   
## Obtaining Other Custom Views  
 The <xref:System.Windows.Controls.GridView> class, which is derived from the <xref:System.Windows.Controls.ViewBase> abstract class, is just one of the possible view modes for the <xref:System.Windows.Controls.ListView> class. You can create other custom views for <xref:System.Windows.Controls.ListView> by deriving from the <xref:System.Windows.Controls.ViewBase> class. For an example of a custom view mode, see [Create a Custom View Mode for a ListView](../../../../docs/framework/wpf/controls/how-to-create-a-custom-view-mode-for-a-listview.md).  
  
<a name="GridViewSupportingClasses"></a>   
## GridView Supporting Classes  
 The following classes support the <xref:System.Windows.Controls.GridView> view mode.  
  
-   <xref:System.Windows.Controls.GridViewColumn>  
  
-   <xref:System.Windows.Controls.GridViewColumnHeader>  
  
-   <xref:System.Windows.Controls.GridViewRowPresenter>  
  
-   <xref:System.Windows.Controls.GridViewHeaderRowPresenter>  
  
-   <xref:System.Windows.Controls.GridViewColumnCollection>  
  
-   <xref:System.Windows.Controls.GridViewColumnHeaderRole>  
  
## See Also  
 <xref:System.Windows.Controls.ListView>  
 <xref:System.Windows.Controls.ListViewItem>  
 <xref:System.Windows.Controls.GridViewColumn>  
 <xref:System.Windows.Controls.GridViewColumnHeader>  
 <xref:System.Windows.Controls.GridViewRowPresenter>  
 <xref:System.Windows.Controls.GridViewHeaderRowPresenter>  
 <xref:System.Windows.Controls.ViewBase>  
 [ListView Overview](../../../../docs/framework/wpf/controls/listview-overview.md)  
 [Sort a GridView Column When a Header Is Clicked](../../../../docs/framework/wpf/controls/how-to-sort-a-gridview-column-when-a-header-is-clicked.md)  
 [How-to Topics](../../../../docs/framework/wpf/controls/listview-how-to-topics.md)
