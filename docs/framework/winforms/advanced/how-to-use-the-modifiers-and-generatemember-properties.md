---
title: "How to: Use the Modifiers and GenerateMember Properties"
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
f1_keywords: 
  - "Designer_GenerateMember"
  - "Designer_Modifiers"
helpviewer_keywords: 
  - "base forms"
  - "inheritance [Windows Forms], forms"
  - "inherited forms [Windows Forms], Windows Forms"
  - "inherited forms"
  - "form inheritance"
  - "Windows Forms, inheritance"
ms.assetid: 3381a5e4-e1a3-44e2-a765-a0b758937b85
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Use the Modifiers and GenerateMember Properties
When you place a component on a Windows Form, two properties are provided by the design environment: `GenerateMember` and `Modifiers`. The `GenerateMember` property specifies when the Windows Forms Designer generates a member variable for a component. The `Modifiers` property is the access modifier assigned to that member variable. If the value of the `GenerateMember` property is `false`, the value of the `Modifiers` property has no effect.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To specify whether a component is a member of the form  
  
1.  In the Windows Forms Designer, open your form.  
  
2.  Open the **Toolbox**, and on the form, place three <xref:System.Windows.Forms.Button> controls.  
  
3.  Set the `GenerateMember` and `Modifiers` properties for each <xref:System.Windows.Forms.Button> control according to the following table.  
  
    |Button name|GenerateMember value|Modifiers value|  
    |-----------------|--------------------------|---------------------|  
    |`button1`|`true`|`private`|  
    |`button2`|`true`|`protected`|  
    |`button3`|`false`|No change|  
  
4.  Build the solution.  
  
5.  In **Solution Explorer**, click the **Show All Files** button.  
  
6.  Open the **Form1** node, and in the **Code Editor**,open the **Form1.Designer.vb** or **Form1.Designer.cs** file. This file contains the code emitted by the Windows Forms Designer.  
  
7.  Find the declarations for the three buttons. The following code example shows the differences specified by the `GenerateMember` and `Modifiers` properties.  
  
     [!code-csharp[System.Windows.Forms.GenerateMember#3](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.GenerateMember/CS/Form1.cs#3)]
     [!code-vb[System.Windows.Forms.GenerateMember#3](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.GenerateMember/VB/Form1.vb#3)]  
  
     [!code-csharp[System.Windows.Forms.GenerateMember#2](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.GenerateMember/CS/Form1.cs#2)]
     [!code-vb[System.Windows.Forms.GenerateMember#2](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.GenerateMember/VB/Form1.vb#2)]  
  
> [!NOTE]
>  By default, the Windows Forms Designer assigns the `private` (`Friend` in Visual Basic) modifier to container controls like <xref:System.Windows.Forms.Panel>. If your base <xref:System.Windows.Forms.UserControl> or <xref:System.Windows.Forms.Form> has a container control, it will not accept new children in inherited controls and forms. The solution is to change the modifier of the base container control to `protected` or `public`.  
  
## See Also  
 <xref:System.Windows.Forms.Button>  
 [Windows Forms Visual Inheritance](../../../../docs/framework/winforms/advanced/windows-forms-visual-inheritance.md)  
 [Walkthrough: Demonstrating Visual Inheritance](../../../../docs/framework/winforms/advanced/walkthrough-demonstrating-visual-inheritance.md)  
 [How to: Inherit Windows Forms](../../../../docs/framework/winforms/advanced/how-to-inherit-windows-forms.md)
