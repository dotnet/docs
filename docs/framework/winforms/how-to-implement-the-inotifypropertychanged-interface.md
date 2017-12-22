---
title: "How to: Implement the INotifyPropertyChanged Interface"
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
  - "INotifyPropertyChanged interface [Windows Forms], implementing"
ms.assetid: eac428af-b43b-46ac-80d9-1a5f88658725
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Implement the INotifyPropertyChanged Interface
The following code example demonstrates how to implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface. Implement this interface on business objects that are used in Windows Forms data binding. When implemented, the interface  communicates to a bound control the property changes on a business object.  
  
## Example  
 [!code-csharp[System.ComponentModel.IPropertyChangeExample#1](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.IPropertyChangeExample/CS/Form1.cs#1)]
 [!code-vb[System.ComponentModel.IPropertyChangeExample#1](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.IPropertyChangeExample/VB/Form1.vb#1)]  
  
## See Also  
 [How to: Apply the PropertyNameChanged Pattern](../../../docs/framework/winforms/how-to-apply-the-propertynamechanged-pattern.md)  
 [Windows Forms Data Binding](../../../docs/framework/winforms/windows-forms-data-binding.md)  
 [How to: Raise Change Notifications Using a BindingSource and the INotifyPropertyChanged Interface](../../../docs/framework/winforms/controls/raise-change-notifications--bindingsource.md)  
 [Change Notification in Windows Forms Data Binding](../../../docs/framework/winforms/change-notification-in-windows-forms-data-binding.md)
