---
title: "How to: Raise Change Notifications Using a BindingSource and the INotifyPropertyChanged Interface"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "change notifications [Windows Forms], raising"
  - "BindingSource component [Windows Forms], and IPropertyChange"
  - "data sources [Windows Forms], detecting changes"
  - "examples [Windows Forms], BindingSource component"
  - "change notifications"
  - "INotifyPropertyChanged interface [Windows Forms], using with BindingSource"
  - "BindingSource component [Windows Forms], examples"
ms.assetid: 7fa2cf51-c09f-4375-adf0-e36c5617f099
---
# How to: Raise Change Notifications Using a BindingSource and the INotifyPropertyChanged Interface
The <xref:System.Windows.Forms.BindingSource> component will automatically detect changes in a data source when the type contained in the data source implements the <xref:System.ComponentModel.INotifyPropertyChanged> interface and raises <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> events when a property value is changed. This is useful because controls bound to the <xref:System.Windows.Forms.BindingSource> will then automatically update as the data source values change.  
  
> [!NOTE]
> If your data source implements <xref:System.ComponentModel.INotifyPropertyChanged> and you are performing asynchronous operations, you should not make changes to the data source on a background thread. Instead, you should read the data on a background thread and merge the data into a list on the UI thread.  
  
## Example  
 The following code example demonstrates a simple implementation of the <xref:System.ComponentModel.INotifyPropertyChanged> interface. It also shows how the <xref:System.Windows.Forms.BindingSource> automatically passes a data source change to a bound control when the <xref:System.Windows.Forms.BindingSource> is bound to a list of the <xref:System.ComponentModel.INotifyPropertyChanged> type.  
  
 If you use the `CallerMemberName` attribute, calls to the `NotifyPropertyChanged` method don't have to specify the property name as a string argument. For more information, see [Caller Information (C#)](../../../csharp/programming-guide/concepts/caller-information.md) or [Caller Information (Visual Basic)](../../../visual-basic/programming-guide/concepts/caller-information.md).  
  
 [!code-csharp[System.ComponentModel.IPropertyChangeExample#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.IPropertyChangeExample/CS/Form1.cs#1)]
 [!code-vb[System.ComponentModel.IPropertyChangeExample#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.IPropertyChangeExample/VB/Form1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Data, System.Drawing and System.Windows.Forms assemblies.  
  
## See also

- <xref:System.ComponentModel.INotifyPropertyChanged>
- [BindingSource Component](bindingsource-component.md)
- [How to: Raise Change Notifications Using the BindingSource ResetItem Method](how-to-raise-change-notifications-using-the-bindingsource-resetitem-method.md)
