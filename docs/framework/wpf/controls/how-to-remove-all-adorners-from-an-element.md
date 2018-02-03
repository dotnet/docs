---
title: "How to: Remove all Adorners from an Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "adorners [WPF], removing"
ms.assetid: fe5303a3-b76e-4643-aafb-51419032b47b
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Remove all Adorners from an Element
This example shows how to programmatically remove all adorners from a specified <xref:System.Windows.UIElement>.  
  
## Example  
 This verbose code example removes all of the adorners in the array of adorners returned by <xref:System.Windows.Documents.AdornerLayer.GetAdorners%2A>.  This example happens to retrieve the adorners on a <xref:System.Windows.UIElement> named *myTextBox*.  If the element specified in the call to <xref:System.Windows.Documents.AdornerLayer.GetAdorners%2A> has no adorners, `null` is returned.  This code explicitly checks for a null array, and is best suited for applications where a null array is expected to be relatively common.  
  
 [!code-csharp[AdornersMiscCode#_RemoveAllAdornersLong](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdornersMiscCode/CSharp/Window1.xaml.cs#_removealladornerslong)]
 [!code-vb[AdornersMiscCode#_RemoveAllAdornersLong](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/AdornersMiscCode/visualbasic/window1.xaml.vb#_removealladornerslong)]  
  
## Example  
 This condensed code example is functionally equivalent to the verbose example shown above. This code does not explicitly check for a null array, so it is possible that a <xref:System.NullReferenceException> exception may be raised.  This code is best suited for applications where a null array is expected to be rare.  
  
 [!code-csharp[AdornersMiscCode#_RemoveAllAdornersShort](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdornersMiscCode/CSharp/Window1.xaml.cs#_removealladornersshort)]
 [!code-vb[AdornersMiscCode#_RemoveAllAdornersShort](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/AdornersMiscCode/visualbasic/window1.xaml.vb#_removealladornersshort)]  
  
## See Also  
 [Adorners Overview](../../../../docs/framework/wpf/controls/adorners-overview.md)
