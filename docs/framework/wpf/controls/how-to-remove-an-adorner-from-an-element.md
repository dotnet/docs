---
title: "How to: Remove an Adorner from an Element"
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
ms.assetid: 97cf4d9f-0596-429e-8526-32a30aa4ae99
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Remove an Adorner from an Element
This example shows how to programmatically remove a specific adorner from a specified <xref:System.Windows.UIElement>.  
  
## Example  
 This verbose code example removes the first adorner in the array of adorners returned by <xref:System.Windows.Documents.AdornerLayer.GetAdorners%2A>.  This example happens to retrieve the adorners on a <xref:System.Windows.UIElement> named *myTextBox*.  If the element specified in the call to <xref:System.Windows.Documents.AdornerLayer.GetAdorners%2A> has no adorners, `null` is returned.  This code explicitly checks for a null array, and is best suited for applications where a null array is expected to be relatively common.  
  
 [!code-csharp[AdornersMiscCode#_RemoveSpecificAdornerLong](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdornersMiscCode/CSharp/Window1.xaml.cs#_removespecificadornerlong)]
 [!code-vb[AdornersMiscCode#_RemoveSpecificAdornerLong](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/AdornersMiscCode/visualbasic/window1.xaml.vb#_removespecificadornerlong)]  
  
## Example  
 This condensed code example is functionally equivalent to the verbose example shown above. This code does not explicitly check for a null array, so it is possible that a <xref:System.NullReferenceException> exception may be raised.  This code is best suited for applications where a null array is expected to be rare.  
  
 [!code-csharp[AdornersMiscCode#_RemoveSpecificAdornerShort](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdornersMiscCode/CSharp/Window1.xaml.cs#_removespecificadornershort)]
 [!code-vb[AdornersMiscCode#_RemoveSpecificAdornerShort](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/AdornersMiscCode/visualbasic/window1.xaml.vb#_removespecificadornershort)]  
  
## See Also  
 [Adorners Overview](../../../../docs/framework/wpf/controls/adorners-overview.md)
