---
title: "How to: Manipulate Flow Content Elements through the Blocks Property"
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
  - "documents [WPF], manipulating flow content elements through Blocks property"
  - "flow content elements [WPF], manipulating through Blocks property"
  - "properties [WPF], Blocks [WPF], manipulating flow content elements"
  - "Blocks property [WPF], manipulating flow content elements"
ms.assetid: aeda4ece-b979-4818-a093-ef938e908751
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Manipulate Flow Content Elements through the Blocks Property
These examples demonstrate some of the more common operations that can be performed on flow content elements through the **Blocks** property. This property is used to add and remove items from <xref:System.Windows.Documents.BlockCollection>. Flow content elements that feature a **Blocks** property include:  
  
-   <xref:System.Windows.Documents.Figure>  
  
-   <xref:System.Windows.Documents.Floater>  
  
-   <xref:System.Windows.Documents.ListItem>  
  
-   <xref:System.Windows.Documents.Section>  
  
-   <xref:System.Windows.Documents.TableCell>  
  
 These examples happen to use <xref:System.Windows.Documents.Section> as the flow content element, but these techniques are applicable to all elements that host a flow content element collection.  
  
## Example  
 The following example creates a new <xref:System.Windows.Documents.Section> and then uses the **Add** method to add a new Paragraph to the **Section** contents.  
  
 [!code-csharp[FlowDocumentSnippets#_SectionBlocksAdd](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FlowDocumentSnippets/CSharp/Window1.xaml.cs#_sectionblocksadd)]
 [!code-vb[FlowDocumentSnippets#_SectionBlocksAdd](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FlowDocumentSnippets/visualbasic/window1.xaml.vb#_sectionblocksadd)]  
  
## Example  
 The following example creates a new <xref:System.Windows.Documents.Paragraph> element and inserts it at the beginning of the <xref:System.Windows.Documents.Section>.  
  
 [!code-csharp[FlowDocumentSnippets#_SectionBlocksInsert](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FlowDocumentSnippets/CSharp/Window1.xaml.cs#_sectionblocksinsert)]
 [!code-vb[FlowDocumentSnippets#_SectionBlocksInsert](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FlowDocumentSnippets/visualbasic/window1.xaml.vb#_sectionblocksinsert)]  
  
## Example  
 The following example gets the number of top-level <xref:System.Windows.Documents.Block> elements contained in the <xref:System.Windows.Documents.Section>.  
  
 [!code-csharp[FlowDocumentSnippets#_SectionBlocksCount](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FlowDocumentSnippets/CSharp/Window1.xaml.cs#_sectionblockscount)]
 [!code-vb[FlowDocumentSnippets#_SectionBlocksCount](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FlowDocumentSnippets/visualbasic/window1.xaml.vb#_sectionblockscount)]  
  
## Example  
 The following example deletes the last <xref:System.Windows.Documents.Block> element in the <xref:System.Windows.Documents.Section>.  
  
 [!code-csharp[FlowDocumentSnippets#_SectionBlocksRemoveLast](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FlowDocumentSnippets/CSharp/Window1.xaml.cs#_sectionblocksremovelast)]
 [!code-vb[FlowDocumentSnippets#_SectionBlocksRemoveLast](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FlowDocumentSnippets/visualbasic/window1.xaml.vb#_sectionblocksremovelast)]  
  
## Example  
 The following example clears all of the contents (<xref:System.Windows.Documents.Block> elements) from the <xref:System.Windows.Documents.Section>.  
  
 [!code-csharp[FlowDocumentSnippets#_SectionBlocksClear](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FlowDocumentSnippets/CSharp/Window1.xaml.cs#_sectionblocksclear)]
 [!code-vb[FlowDocumentSnippets#_SectionBlocksClear](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FlowDocumentSnippets/visualbasic/window1.xaml.vb#_sectionblocksclear)]  
  
## See Also  
 <xref:System.Windows.Documents.BlockCollection>  
 <xref:System.Windows.Documents.InlineCollection>  
 <xref:System.Windows.Documents.ListItemCollection>  
 [Flow Document Overview](../../../../docs/framework/wpf/advanced/flow-document-overview.md)  
 [Manipulate a Table's Row Groups through the RowGroups Property](../../../../docs/framework/wpf/advanced/how-to-manipulate-table-row-groups-through-the-rowgroups-property.md)  
 [Manipulate a Table's Columns through the Columns Property](../../../../docs/framework/wpf/advanced/how-to-manipulate-table-columns-through-the-columns-property.md)  
 [Manipulate a Table's Row Groups through the RowGroups Property](../../../../docs/framework/wpf/advanced/how-to-manipulate-table-row-groups-through-the-rowgroups-property.md)
