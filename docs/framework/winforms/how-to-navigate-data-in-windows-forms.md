---
title: "How to: Navigate Data in Windows Forms"
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
helpviewer_keywords: 
  - "cursors [Windows Forms], data sources"
  - "data sources [Windows Forms], Windows Forms"
  - "Windows Forms, navigating"
  - "CurrencyManager class [Windows Forms], navigating Windows Forms data"
  - "data [Windows Forms], navigating"
ms.assetid: 97360f7b-b181-4084-966a-4c62518f735b
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Navigate Data in Windows Forms
In a Windows application, the easiest way to navigate through records in a data source is to bind a <xref:System.Windows.Forms.BindingSource> component to the data source and then bind controls to the <xref:System.Windows.Forms.BindingSource>. You can then use the built-in navigation method on the <xref:System.Windows.Forms.BindingSource> such a <xref:System.Windows.Forms.BindingSource.MoveNext%2A>, <xref:System.Windows.Forms.BindingSource.MoveLast%2A>, <xref:System.Windows.Forms.BindingSource.MovePrevious%2A> and <xref:System.Windows.Forms.BindingSource.MoveFirst%2A>. Using these methods will adjust the <xref:System.Windows.Forms.BindingSource.Position%2A> and <xref:System.Windows.Forms.BindingSource.Current%2A> properties of the <xref:System.Windows.Forms.BindingSource> appropriately. You can also find an item and set it as the current item by setting the <xref:System.Windows.Forms.BindingSource.Position%2A> property.  
  
### To increment the position in a data source  
  
1.  Set the <xref:System.Windows.Forms.BindingSource.Position%2A> property of the <xref:System.Windows.Forms.BindingSource> for your bound data to the record position to go to. The following example illustrates using the <xref:System.Windows.Forms.BindingSource.MoveNext%2A> method of the <xref:System.Windows.Forms.BindingSource> to increment the <xref:System.Windows.Forms.BindingSource.Position%2A> property when the `nextButton` is clicked. The <xref:System.Windows.Forms.BindingSource> is associated with the `Customers` table of a dataset `Northwind`.  
  
    > [!NOTE]
    >  Setting the <xref:System.Windows.Forms.BindingSource.Position%2A> property to a value beyond the first or last record does not result in an error, as the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] will not allow you to set the position to a value outside the bounds of the list. If it is important in your application to know whether you have gone past the first or last record, include logic to test whether you will exceed the data element count.  
  
     [!code-csharp[System.Windows.Forms.NavigatingData#4](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.NavigatingData/CS/Form1.cs#4)]
     [!code-vb[System.Windows.Forms.NavigatingData#4](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.NavigatingData/VB/Form1.vb#4)]  
  
### To check whether you have passed the end or beginning  
  
1.  Create an event handler for the <xref:System.Windows.Forms.BindingSource.PositionChanged> event. In the handler, you can test whether the proposed position value has exceeded the actual data element count.  
  
     The following example illustrates how you can test whether you have reached the last data element. In the example, if you are at the last element, the **Next** button on the form is disabled.  
  
    > [!NOTE]
    >  Be aware that, should you change the list you are navigating in code, you should re-enable the **Next** button, so that users may browse the entire length of the new list. Additionally, be aware that the above <xref:System.Windows.Forms.BindingSource.PositionChanged> event for the specific <xref:System.Windows.Forms.BindingSource> you are working with needs to be associated with its event-handling method. The following is an example of a method for handling the <xref:System.Windows.Forms.BindingSource.PositionChanged> event:  
  
     [!code-csharp[System.Windows.Forms.NavigatingData#3](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.NavigatingData/CS/Form1.cs#3)]
     [!code-vb[System.Windows.Forms.NavigatingData#3](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.NavigatingData/VB/Form1.vb#3)]  
  
### To find an item and set it as the current item  
  
1.  Find the record you wish to set as the current item. You can do this using the <xref:System.Windows.Forms.BindingSource.Find%2A> method of the <xref:System.Windows.Forms.BindingSource>, if your data source implements <xref:System.ComponentModel.IBindingList>. Some examples of data sources that implement <xref:System.ComponentModel.IBindingList> are <xref:System.ComponentModel.BindingList%601> and <xref:System.Data.DataView>.  
  
     [!code-csharp[System.Windows.Forms.NavigatingData#2](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.NavigatingData/CS/Form1.cs#2)]
     [!code-vb[System.Windows.Forms.NavigatingData#2](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.NavigatingData/VB/Form1.vb#2)]  
  
## See Also  
 [Data Sources Supported by Windows Forms](../../../docs/framework/winforms/data-sources-supported-by-windows-forms.md)  
 [Change Notification in Windows Forms Data Binding](../../../docs/framework/winforms/change-notification-in-windows-forms-data-binding.md)  
 [Data Binding and Windows Forms](../../../docs/framework/winforms/data-binding-and-windows-forms.md)  
 [Windows Forms Data Binding](../../../docs/framework/winforms/windows-forms-data-binding.md)
