---
title: "Windows Forms Data Binding"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "data [Windows Forms]"
  - "Windows Forms, data binding"
  - "data [Windows Forms], architecture"
  - "Windows Forms controls, data binding"
ms.assetid: c3826d8e-ea25-4ad4-a669-45bfb19192aa
---
# Windows Forms Data Binding
Data binding in Windows Forms gives you the means to display and make changes to information from a data source in controls on the form. You can bind to both traditional data sources as well as almost any structure that contains data.  
  
## In This Section  
 [Data Binding and Windows Forms](data-binding-and-windows-forms.md)  
 Provides an overview of data binding in Windows Forms.  
  
 [Data Sources Supported by Windows Forms](data-sources-supported-by-windows-forms.md)  
 Describes the data sources that can be used with Windows Forms.  
  
 [Interfaces Related to Data Binding](interfaces-related-to-data-binding.md)  
 Describes several of the interfaces used with Windows Forms data binding.  
  
 [How to: Navigate Data in Windows Forms](how-to-navigate-data-in-windows-forms.md)  
 Shows how to navigate through items in a data source.  
  
 [Change Notification in Windows Forms Data Binding](change-notification-in-windows-forms-data-binding.md)  
 Describes different types of change notification for Windows Forms data binding.  
  
 [How to: Implement the INotifyPropertyChanged Interface](how-to-implement-the-inotifypropertychanged-interface.md)  
 Shows how to implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface. The interface  communicates to a bound control the property changes on a business object  
  
 [How to: Apply the PropertyNameChanged Pattern](how-to-apply-the-propertynamechanged-pattern.md)  
 Shows how to apply the *PropertyName*Changed pattern to properties of a Windows Forms user control.  
  
 [How to: Implement the ITypedList Interface](how-to-implement-the-itypedlist-interface.md)  
 Shows how to enable discovery of the schema for a bindable list by implementing the <xref:System.ComponentModel.ITypedList> interface.  
  
 [How to: Implement the IListSource Interface](how-to-implement-the-ilistsource-interface.md)  
 Shows how to implement the <xref:System.ComponentModel.IListSource> interface to create a bindable class does not implement <xref:System.Collections.IList>, but provides a list from another location.  
  
 [How to: Ensure Multiple Controls Bound to the Same Data Source Remain Synchronized](multiple-controls-bound-to-data-source-synchronized.md)  
 Shows how to handle the <xref:System.Windows.Forms.BindingSource.BindingComplete> event to ensure all controls bound to a data source remain synchronized.  
  
 [How to: Ensure the Selected Row in a Child Table Remains at the Correct Position](ensure-the-selected-row-in-a-child-table-correct.md)  
 Shows how to ensure the selected row of a child table does not change, when a change is made to a field of the parent table.  
  
 Also see [Interfaces Related to Data Binding](interfaces-related-to-data-binding.md), [How to: Navigate Data in Windows Forms](how-to-navigate-data-in-windows-forms.md), and [How to: Create a Simple-Bound Control on a Windows Form](how-to-create-a-simple-bound-control-on-a-windows-form.md).  
  
## Reference  
 <xref:System.Windows.Forms.Binding?displayProperty=nameWithType>  
 Describes the class that represents the binding between a bindable component and a data source.  
  
 <xref:System.Windows.Forms.BindingSource?displayProperty=nameWithType>  
 Describes the class that encapsulates a data source for binding to controls.  
  
## Related Sections  
 [BindingSource Component](./controls/bindingsource-component.md)  
 Contains a list of topics that demonstrate how to use the <xref:System.Windows.Forms.BindingSource> component.  
  
 [DataGridView Control](./controls/datagridview-control-windows-forms.md)  
 Provides a list of topics that demonstrate how to use a bindable datagrid control.  
  
 Also see [Accessing Data in Visual Studio](/visualstudio/data-tools/accessing-data-in-visual-studio).
