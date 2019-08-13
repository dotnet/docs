---
title: "How to: Bind Data to the Windows Forms DataGridView Control Using the Designer"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Windows Forms controls, binding to a data source"
  - "data sources [Windows Forms], binding to Windows Forms controls"
  - "DataGridView control [Windows Forms], data binding"
ms.assetid: f4f46009-cec2-441b-8668-6b5af057558b
---
# How to: Bind Data to the Windows Forms DataGridView Control Using the Designer
You can use the designer to connect a <xref:System.Windows.Forms.DataGridView> control to data sources of several different varieties, including databases, business objects, or Web services. When you bind the control to a data source using the designer, the control is automatically bound to a <xref:System.Windows.Forms.BindingSource> component that represents the data source. Additionally, columns are automatically generated in the control to match the schema information provided by the data source.

 After columns have been generated, you can modify them to meet your needs. For example, you can remove or hide columns you are not interested in displaying, you can rearrange the columns, or you can modify the column types. For more information about modifying columns, see the topics listed in the See Also section.

 You can also bind multiple <xref:System.Windows.Forms.DataGridView> controls to related tables to create master/detail relationships. In this configuration, one control displays a parent table and another control displays only those rows from a child table that are related to the current row in the parent table. For more information, see [How to: Display Related Data in a Windows Forms Application](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/57tx3hhe(v=vs.120)).

 The following procedure requires a **Windows Application** project with a form that contains a <xref:System.Windows.Forms.DataGridView> control or two controls for a master/detail relationship. For information about starting such a project, see [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project) and [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md).

### To bind the control to a data source

1. Click the smart tag glyph (![Smart Tag Glyph](./media/vs-winformsmttagglyph.gif "VS_WinFormSmtTagGlyph")) on the upper-right corner of the <xref:System.Windows.Forms.DataGridView> control.

2. Click the drop-down arrow for the **Choose Data Source** option.

3. If your project does not already have a data source, click **Add Project Data Source** and follow the steps indicated by the wizard.

     For more information, see [Data Source Configuration Wizard](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/w4dd7z6t(v=vs.120)). Your new data source will appear in the **Choose Data Source** drop-down window. If your new data source contains only one member, such as a single database table, the control will automatically bind to that member. Otherwise, continue to the next step.

4. Expand the **Other Data Sources** and **Project Data Sources** nodes if they are not already expanded, and then select the data source to bind the control to.

5. If your data source contains more than one member, such as if you have created a <xref:System.Data.DataSet?displayProperty=nameWithType> that contains multiple tables, expand the data source, and then select the specific member to bind to.

6. To create a master/detail relationship, in the **Choose Data Source** drop-down window for a second <xref:System.Windows.Forms.DataGridView> control, expand the <xref:System.Windows.Forms.BindingSource> created for the parent table, and then select the related child table from the list shown.

    > [!NOTE]
    >  If your project already has a data source, you can also use the **Data Sources** window to create a data form. For more information, see [Data Sources Window](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/6ckyxa83(v=vs.120)).

## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.BindingSource>
- <xref:System.Windows.Forms.DataGridView.DataMember%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.DataGridView.DataSource%2A?displayProperty=nameWithType>
- [How to: Connect to Data in a Database](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/fxk9yw1t(v=vs.120))
- [How to: Add and Remove Columns in the Windows Forms DataGridView Control Using the Designer](add-and-remove-columns-in-the-datagrid-using-the-designer.md)
- [How to: Change the Order of Columns in the Windows Forms DataGridView Control Using the Designer](change-the-order-of-columns-in-the-datagrid-using-the-designer.md)
- [How to: Change the Type of a Windows Forms DataGridView Column Using the Designer](change-the-type-of-a-wf-datagridview-column-using-the-designer.md)
- [How to: Freeze Columns in the Windows Forms DataGridView Control Using the Designer](freeze-columns-in-the-datagrid-using-the-designer.md)
- [How to: Hide Columns in the Windows Forms DataGridView Control Using the Designer](hide-columns-in-the-datagrid-using-the-designer.md)
- [How to: Make Columns Read-Only in the Windows Forms DataGridView Control Using the Designer](make-columns-read-only-in-the-datagrid-using-the-designer.md)
- [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project)
- [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md)
- [Data Sources Window](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/6ckyxa83(v=vs.120))
- [How to: Display Related Data in a Windows Forms Application](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/57tx3hhe(v=vs.120))
