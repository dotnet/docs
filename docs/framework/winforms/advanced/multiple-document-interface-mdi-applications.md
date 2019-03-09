---
title: "Multiple-Document Interface (MDI) Applications"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "forms [Windows Forms], MDI"
  - "windows [Windows Forms], mDI"
  - "Windows Forms, MDI applications"
  - "MDI"
ms.assetid: 599faf75-13cf-49cc-ad3c-255545e5cb97
---
# Multiple-Document Interface (MDI) Applications
Multiple-document interface (MDI) applications enable you to display multiple documents at the same time, with each document displayed in its own window. MDI applications often have a Window menu item with submenus for switching between windows or documents.  
  
> [!NOTE]
>  There are some behavior differences between MDI forms and single-document interface (SDI) windows in Windows Forms. The `Opacity` property does not affect the appearance of MDI child forms. Additionally, the <xref:System.Windows.Forms.Form.CenterToParent%2A> method does not affect the behavior of MDI child forms.  
  
## In This Section  
 [How to: Create MDI Parent Forms](how-to-create-mdi-parent-forms.md)  
 Gives directions for creating the container for the multiple documents within an MDI application.  
  
 [How to: Create MDI Child Forms](how-to-create-mdi-child-forms.md)  
 Gives directions for creating one or more windows that operate within an MDI parent form.  
  
 [How to: Determine the Active MDI Child](how-to-determine-the-active-mdi-child.md)  
 Gives directions for verifying the child window that has focus (and sending its contents to the Clipboard).  
  
 [How to: Send Data to the Active MDI Child](how-to-send-data-to-the-active-mdi-child.md)  
 Gives directions for transporting information to the active child window.  
  
 [How to: Arrange MDI Child Forms](how-to-arrange-mdi-child-forms.md)  
 Gives directions for tiling, cascading, or arranging the child windows of an MDI application.
