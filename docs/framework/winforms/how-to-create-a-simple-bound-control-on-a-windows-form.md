---
title: "How to: Create a Simple-Bound Control on a Windows Form"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "data binding [Windows Forms], simple data binding"
  - "Windows Forms controls, data binding"
ms.assetid: 3bcaded8-0f1a-4cc0-8830-f59be253bf4e
---
# How to: Create a Simple-Bound Control on a Windows Form
With *simple binding*, you can display a single data element, such as a column value from a dataset table, in a control. You can simple-bind any property of a control to a data value.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Personalize the Visual Studio IDE](/visualstudio/ide/personalizing-the-visual-studio-ide).  
  
### To simple-bind a control  
  
1.  Connect to a data source. For more information, see [Connecting to a Data Source](../data/adonet/connecting-to-a-data-source.md).  
  
2.  In the form, select the control and display the **Properties** window.  
  
3.  Expand the **(DataBindings)** property.  
  
     The properties most often bound are displayed underneath the **(DataBindings)** property. For example, in most controls, the **Text** property is most frequently bound.  
  
4.  If the property you want to bind is not one of the commonly bound properties, click the **Ellipsis** button (![VisualStudioEllipsesButton screenshot](./media/vbellipsesbutton.png "vbEllipsesButton")) in the **(Advanced)** box to display the **Formatting and Advanced Binding** dialog box with a complete list of properties for that control.  
  
5.  Select the property you want to bind and click the drop-down arrow under **Binding**.  
  
     A list of available data sources is displayed.  
  
6.  Expand the data source you want to bind to until you find the single data element you want. For example, if you are binding to a column value in a dataset's table, expand the name of the dataset, and then expand the table name to display column names.  
  
7.  Click the name of an element to bind to.  
  
8.  If you were working in the **Formatting and Advanced Binding** dialog box, click **OK** to return to the **Properties** window.  
  
9. If you want to bind additional properties of the control, repeat steps 3 through 7.  
  
    > [!NOTE]
    >  Because simple-bound controls show only a single data element, it is very typical to include navigation logic in a Windows Form with simple-bound controls.  
  
## See also

- <xref:System.Windows.Forms.Binding>
- [Windows Forms Data Binding](windows-forms-data-binding.md)
- [Data Binding and Windows Forms](data-binding-and-windows-forms.md)
