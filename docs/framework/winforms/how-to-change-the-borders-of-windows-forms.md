---
title: "How to: Change the Borders of Windows Forms"
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
  - "cpp"
helpviewer_keywords: 
  - "Windows Forms, changing the borders"
ms.assetid: b3d5fa56-80c6-4b10-b505-f9672307ed55
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Change the Borders of Windows Forms
You have several border styles to choose from when you are determining the appearance and behavior of your Windows Forms. By changing the <xref:System.Windows.Forms.Form.FormBorderStyle%2A> property, you can control the resizing behavior of the form. In addition, setting the <xref:System.Windows.Forms.Form.FormBorderStyle%2A> affects how the caption bar is displayed as well as what buttons might appear on it. For more information, see <xref:System.Windows.Forms.FormBorderStyle>.  
  
 There is extensive support for this task in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)].  
  
 See also [How to: Change the Borders of Windows Forms Using the Designer](http://msdn.microsoft.com/library/yettzh3e\(v=vs.110\)).  
  
### To set the border style of Windows Forms programmatically  
  
-   Set the <xref:System.Windows.Forms.Form.FormBorderStyle%2A> property to the style you want. The following code example sets the border style of form `DlgBx1` to <xref:System.Windows.Forms.FormBorderStyle.FixedDialog>.  
  
    ```vb  
    DlgBx1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog  
    ```  
  
    ```csharp  
    DlgBx1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;  
    ```  
  
    ```cpp  
    DlgBx1->FormBorderStyle =  
       System::Windows::Forms::FormBorderStyle::FixedDialog;  
    ```  
  
     Also see [How to: Create Dialog Boxes at Design Time](http://msdn.microsoft.com/library/55cz5x2c\(v=vs.110\)).  
  
     Additionally, if you have chosen a border style for the form that provides optional **Minimize** and **Maximize** buttons, you can specify whether you want either or both of these buttons to be functional. These buttons are useful when you want to closely control the user experience. The **Minimize** and **Maximize** buttons are enabled by default, and their functionality is manipulated through the **Properties** window.  
  
## See Also  
 <xref:System.Windows.Forms.FormBorderStyle>  
 <xref:System.Windows.Forms.FormBorderStyle.FixedDialog>  
 [Getting Started with Windows Forms](../../../docs/framework/winforms/getting-started-with-windows-forms.md)
