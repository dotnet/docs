---
title: "Best Practices for the TableLayoutPanel Control"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "layout [Windows Forms]"
  - "TableLayoutPanel control [Windows Forms], best practices"
  - "forms [Windows Forms], best practices"
  - "AutoSize property [Windows Forms], tableLayoutPanel control"
  - "controls [Windows Forms], sizing"
  - "TableLayoutPanel control [Windows Forms], AutoSize behavior"
  - "layout [Windows Forms], AutoSize"
  - "layout [Windows Forms], best practices"
  - "best practices [Windows Forms], tableLayoutPanel control"
  - "sizing [Windows Forms], automatic"
  - "automatic sizing"
ms.assetid: b6706efb-d7a4-45ec-8cf4-08fa993e3afb
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Best Practices for the TableLayoutPanel Control
The <xref:System.Windows.Forms.TableLayoutPanel> control provides powerful layout features that you should consider carefully before using on your Windows Forms.  
  
## Recommendations  
 The following recommendations will help you use the <xref:System.Windows.Forms.TableLayoutPanel> control to its best advantage.  
  
### Targeted Use  
 Use the <xref:System.Windows.Forms.TableLayoutPanel> control sparingly. You should not use it in all situations that require a resizable layout. The following list describes layouts that benefit most from the use of the <xref:System.Windows.Forms.TableLayoutPanel> control:  
  
-   Layouts in which there are multiple parts of the form that resize proportionally to each other.  
  
-   Layouts that will be modified or generated dynamically at run time, such as data entry forms that have user-customizable fields added or subtracted based on preferences.  
  
-   Layouts that should remain at an overall fixed size. For example, you may have a dialog box that should remain smaller than 800 x 600, but you need to support localized strings.  
  
 The following list describes layouts that do not benefit greatly from using the <xref:System.Windows.Forms.TableLayoutPanel> control:  
  
-   Simple data entry forms with a single column of labels and a single column of text-entry areas.  
  
-   Forms with a single large display area that should fill all the available space when a resize occurs. An example of this is a form that displays a single <xref:System.Windows.Forms.PropertyGrid> control. In this case, use anchoring, because nothing else should expand when the form is resized.  
  
 Choose carefully which controls need to be in a <xref:System.Windows.Forms.TableLayoutPanel> control. If you have room for your text to grow by 30% using anchoring, consider using the <xref:System.Windows.Forms.Control.Anchor%2A> property only. If you can estimate the space required by your layout, use of <xref:System.Windows.Forms.Control.Dock%2A> and <xref:System.Windows.Forms.Control.Anchor%2A> is easier than estimating the details of remaining space and <xref:System.Windows.Forms.Control.AutoSize%2A> behavior.  
  
 In general, when designing your layout with the <xref:System.Windows.Forms.TableLayoutPanel> control, keep the design as simple as possible.  
  
### Use the Document Outline Window  
 The Document Outline window gives you a tree view of your layout, which you can use to manipulate the z-order and parent-child relationships of your controls. From the **View menu**, select **Other Windows**, then select **Document Outline**.  
  
### Avoid Nesting  
 Avoid nesting other <xref:System.Windows.Forms.TableLayoutPanel> controls within a <xref:System.Windows.Forms.TableLayoutPanel> control. Debugging nested layouts can be difficult.  
  
### Avoid Visual Inheritance  
 The <xref:System.Windows.Forms.TableLayoutPanel> control does not support visual inheritance in the Windows Forms Designer. A <xref:System.Windows.Forms.TableLayoutPanel> control in a derived class appears as "locked" at design time.  
  
## See Also  
 <xref:System.Windows.Forms.TableLayoutPanel>  
 <xref:System.Windows.Forms.FlowLayoutPanel>
