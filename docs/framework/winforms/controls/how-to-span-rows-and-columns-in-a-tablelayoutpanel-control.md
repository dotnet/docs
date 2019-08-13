---
title: "How to: Span Rows and Columns in a TableLayoutPanel Control"
ms.date: "03/30/2017"
f1_keywords:
  - "net.ComponentModel.StyleCollectionEditor.TLP.SpanRowsColumns"
helpviewer_keywords:
  - "columns [Windows Forms], spanning"
  - "merging cells"
  - "TableLayoutPanel control [Windows Forms], spanning rows and columns"
  - "rows [Windows Forms], spanning"
  - "cells [Windows Forms], merging"
ms.assetid: a8a2fdd3-a848-48b0-a4cd-4e85ebded87e
---
# How to: Span Rows and Columns in a TableLayoutPanel Control
Controls in a <xref:System.Windows.Forms.TableLayoutPanel> control can span adjacent rows and columns.

### To span columns and rows

1. Drag a <xref:System.Windows.Forms.TableLayoutPanel> control from the **Toolbox** onto your form.

2. Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** into the upper-left cell of the <xref:System.Windows.Forms.TableLayoutPanel> control.

3. Set the <xref:System.Windows.Forms.Button> control's **ColumnSpan** property to **2**. Note that the <xref:System.Windows.Forms.Button> control spans the first and second columns.

4. Set the <xref:System.Windows.Forms.Button> control's **RowSpan** property to **2**. Note that the <xref:System.Windows.Forms.Button> control spans the first and second rows.

5. Set the <xref:System.Windows.Forms.Button> control's **ColumnSpan** property to **1**. Note that the <xref:System.Windows.Forms.Button> control moves into the first column and spans the first and second rows.

## See also

- [TableLayoutPanel Control](tablelayoutpanel-control-windows-forms.md)
