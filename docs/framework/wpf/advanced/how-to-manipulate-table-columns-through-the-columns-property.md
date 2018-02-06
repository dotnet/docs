---
title: "How to: Manipulate a Table&#39;s Columns through the Columns Property"
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
  - "documents [WPF], manipulating table columns"
  - "properties [WPF], Columns [WPF], manipulating table columns"
  - "tables [WPF], manipulating columns"
  - "Columns property [WPF]"
ms.assetid: 3f8884f4-7e1f-456b-be06-fbd3cf469bf3
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Manipulate a Table&#39;s Columns through the Columns Property
This example demonstrates some of the more common operations that can be performed on a table's columns through the <xref:System.Windows.Documents.Table.Columns%2A> property.  
  
## Example  
 The following example creates a new table and then uses the <xref:System.Windows.Documents.TableColumnCollection.Add%2A> method to add columns to the table's <xref:System.Windows.Documents.Table.Columns%2A> collection.  
  
 [!code-csharp[TableSnippets2#_Table_Columns_Add](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TableSnippets2/CSharp/Window1.xaml.cs#_table_columns_add)]
 [!code-vb[TableSnippets2#_Table_Columns_Add](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/TableSnippets2/visualbasic/window1.xaml.vb#_table_columns_add)]  
  
## Example  
 The following example inserts a new <xref:System.Windows.Documents.TableColumn>.  The new column is inserted at index position 0, making it the new first column in the table.  
  
> [!NOTE]
>  The <xref:System.Windows.Documents.TableColumnCollection> collection uses standard zero-based indexing.  
  
 [!code-csharp[TableSnippets2#_Table_Columns_Insert](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TableSnippets2/CSharp/Window1.xaml.cs#_table_columns_insert)]
 [!code-vb[TableSnippets2#_Table_Columns_Insert](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/TableSnippets2/visualbasic/window1.xaml.vb#_table_columns_insert)]  
  
## Example  
 The following example accesses some arbitrary properties on columns in the <xref:System.Windows.Documents.TableColumnCollection> collection, referring to particular columns by index.  
  
 [!code-csharp[TableSnippets2#_Table_Columns_Manip](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TableSnippets2/CSharp/Window1.xaml.cs#_table_columns_manip)]
 [!code-vb[TableSnippets2#_Table_Columns_Manip](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/TableSnippets2/visualbasic/window1.xaml.vb#_table_columns_manip)]  
  
## Example  
 The following example gets the number of columns currently hosted by the table.  
  
 [!code-csharp[TableSnippets2#_Table_Columns_Count](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TableSnippets2/CSharp/Window1.xaml.cs#_table_columns_count)]
 [!code-vb[TableSnippets2#_Table_Columns_Count](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/TableSnippets2/visualbasic/window1.xaml.vb#_table_columns_count)]  
  
## Example  
 The following example removes a particular column by reference.  
  
 [!code-csharp[TableSnippets2#_Table_Columns_DelRef](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TableSnippets2/CSharp/Window1.xaml.cs#_table_columns_delref)]
 [!code-vb[TableSnippets2#_Table_Columns_DelRef](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/TableSnippets2/visualbasic/window1.xaml.vb#_table_columns_delref)]  
  
## Example  
 The following example removes a particular column by index.  
  
 [!code-csharp[TableSnippets2#_Table_Columns_DelIndex](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TableSnippets2/CSharp/Window1.xaml.cs#_table_columns_delindex)]
 [!code-vb[TableSnippets2#_Table_Columns_DelIndex](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/TableSnippets2/visualbasic/window1.xaml.vb#_table_columns_delindex)]  
  
## Example  
 The following example removes all columns from the table's columns collection.  
  
 [!code-csharp[TableSnippets2#_Table_Columns_Clear](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TableSnippets2/CSharp/Window1.xaml.cs#_table_columns_clear)]
 [!code-vb[TableSnippets2#_Table_Columns_Clear](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/TableSnippets2/visualbasic/window1.xaml.vb#_table_columns_clear)]  
  
## See Also  
 [Table Overview](../../../../docs/framework/wpf/advanced/table-overview.md)  
 [Define a Table with XAML](../../../../docs/framework/wpf/advanced/how-to-define-a-table-with-xaml.md)  
 [Build a Table Programmatically](../../../../docs/framework/wpf/advanced/how-to-build-a-table-programmatically.md)  
 [Manipulate a Table's Row Groups through the RowGroups Property](../../../../docs/framework/wpf/advanced/how-to-manipulate-table-row-groups-through-the-rowgroups-property.md)  
 [Manipulate a FlowDocument through the Blocks Property](../../../../docs/framework/wpf/advanced/how-to-manipulate-a-flowdocument-through-the-blocks-property.md)  
 [Manipulate a Table's Row Groups through the RowGroups Property](../../../../docs/framework/wpf/advanced/how-to-manipulate-table-row-groups-through-the-rowgroups-property.md)
