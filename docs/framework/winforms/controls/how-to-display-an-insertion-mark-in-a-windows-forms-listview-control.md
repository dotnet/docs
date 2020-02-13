---
title: "How to: Display an Insertion Mark in a Windows Forms ListView Control"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "ListView control [Windows Forms], drag operations"
  - "graphics [Windows Forms], insertion marks"
  - "drop and drag [Windows Forms], insertion marks"
  - "insertion marks"
ms.assetid: 88d0a15b-25fd-4dc3-a685-297351311940
---
# How to: Display an Insertion Mark in a Windows Forms ListView Control
The insertion mark in the <xref:System.Windows.Forms.ListView> control shows users the point where dragged items will be inserted. When a user drags an item to a point between two other items, the insertion mark shows the item's expected new location.  
  
 The following image shows an insertion mark:  
  
 ![Screenshot that shows a ListView insertion mark.](./media/how-to-display-an-insertion-mark-in-a-windows-forms-listview-control/listview-insertion-mark.gif "ListViewInsertion")  
  
 The following code example demonstrates how to use this feature.  
  
## Example  
 [!code-cpp[System.Windows.Forms.ListView.InsertionMark#1](~/samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.ListView.InsertionMark/CPP/listviewinsertionmarkexample.cpp#1)]
 [!code-csharp[System.Windows.Forms.ListView.InsertionMark#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ListView.InsertionMark/CS/listviewinsertionmarkexample.cs#1)]
 [!code-vb[System.Windows.Forms.ListView.InsertionMark#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ListView.InsertionMark/VB/listviewinsertionmarkexample.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System and System.Windows.Forms assemblies.  
  
## See also

- <xref:System.Windows.Forms.ListView>
- <xref:System.Windows.Forms.ListView.InsertionMark%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.ListViewInsertionMark>
- [ListView Control](listview-control-windows-forms.md)
- [ListView Control Overview](listview-control-overview-windows-forms.md)
- [Walkthrough: Performing a Drag-and-Drop Operation in Windows Forms](../advanced/walkthrough-performing-a-drag-and-drop-operation-in-windows-forms.md)
