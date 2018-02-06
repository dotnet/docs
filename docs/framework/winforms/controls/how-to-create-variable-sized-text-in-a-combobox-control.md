---
title: "How to: Create Variable Sized Text in a ComboBox Control"
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
  - "vb"
helpviewer_keywords: 
  - "text [Windows Forms], drawing in combo boxes"
  - "examples [Windows Forms], ComboBox control"
  - "combo boxes [Windows Forms], drawing text"
  - "ComboBox control [Windows Forms], examples [C#]"
  - "ComboBox control [Windows Forms], drawing custom text"
ms.assetid: ce39b9ea-e626-49fe-bd5a-f567f6d157df
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create Variable Sized Text in a ComboBox Control
This example demonstrates custom drawing of text in a <xref:System.Windows.Forms.ComboBox> control. When an item meets a certain criteria, it is drawn in a larger font and turned red.  
  
## Example  
  
```vb  
Private Sub ComboBox1_MeasureItem(ByVal sender As Object, ByVal e As _  
System.Windows.Forms.MeasureItemEventArgs) Handles ComboBox1.MeasureItem  
    Dim bFont As New Font("Arial", 8, FontStyle.Bold)  
    Dim lFont As New Font("Arial", 12, FontStyle.Bold)  
    Dim siText As SizeF  
  
    If ComboBox1.Items().Item(e.Index) = "Two" Then  
        siText = e.Graphics.MeasureString(ComboBox1.Items().Item(e.Index), _  
lFont)  
    Else  
        siText = e.Graphics.MeasureString(ComboBox1.Items().Item(e.Index), bFont)  
    End If  
  
    e.ItemHeight = siText.Height  
    e.ItemWidth = siText.Width  
End Sub  
  
Private Sub ComboBox1_DrawItem(ByVal sender As Object, ByVal e As _  
System.Windows.Forms.DrawItemEventArgs) Handles ComboBox1.DrawItem  
    Dim g As Graphics = e.Graphics  
    Dim bFont As New Font("Arial", 8, FontStyle.Bold)  
    Dim lFont As New Font("Arial", 12, FontStyle.Bold)  
  
    If ComboBox1.Items().Item(e.Index) = "Two" Then  
        g.DrawString(ComboBox1.Items.Item(e.Index), lfont, Brushes.Red, _  
e.Bounds.X, e.Bounds.Y)  
    Else  
        g.DrawString(ComboBox1.Items.Item(e.Index), bFont, Brushes.Black, e.Bounds.X, e.Bounds.Y)  
    End If  
End Sub  
```  
  
## Compiling the Code  
 This example requires:  
  
-   A Windows form.  
  
-   A <xref:System.Windows.Forms.ComboBox> control named `ListBox1` with three items in the <xref:System.Windows.Forms.ComboBox.Items%2A> property. In this example, the three items are named `"One", Two", and Three"`. The <xref:System.Windows.Forms.ComboBox.DrawMode%2A> property of `ComboBox1` must be set to <xref:System.Windows.Forms.DrawMode.OwnerDrawVariable>.  
  
    > [!NOTE]
    >  This technique is also applicable to the <xref:System.Windows.Forms.ListBox> control — you can substitute a <xref:System.Windows.Forms.ListBox> for the <xref:System.Windows.Forms.ComboBox>.  
  
-   References to the <xref:System.Windows.Forms?displayProperty=nameWithType> and <xref:System.Drawing?displayProperty=nameWithType> namespaces.  
  
## See Also  
 <xref:System.Windows.Forms.ComboBox.DrawItem>  
 <xref:System.Windows.Forms.DrawItemEventArgs>  
 <xref:System.Windows.Forms.ComboBox.MeasureItem>  
 [Controls with Built-In Owner-Drawing Support](../../../../docs/framework/winforms/controls/controls-with-built-in-owner-drawing-support.md)  
 [ListBox Control](../../../../docs/framework/winforms/controls/listbox-control-windows-forms.md)  
 [ComboBox Control](../../../../docs/framework/winforms/controls/combobox-control-windows-forms.md)
