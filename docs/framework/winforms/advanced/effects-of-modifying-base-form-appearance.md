---
title: "Effects of Modifying a Base Form&#39;s Appearance"
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
  - "parent forms [Windows Forms]"
  - "inherited forms [Windows Forms], modifications to base form"
  - "Windows Forms, base form appearance"
  - "base forms"
  - "inheritance [Windows Forms], forms"
ms.assetid: 1c3f2b29-a05c-4c6f-aa1a-4e66b94f343a
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Effects of Modifying a Base Form&#39;s Appearance
During application development, you may often need to change the appearance of the base form from which other forms in the project (or in other projects) are inheriting.  
  
 At design time, changes to the base form's appearance (be it the setting of properties or the addition and subtraction of controls) are reflected on inherited forms when the project containing the base form is built. It is not sufficient for you to simply save the changes to the base form. To build a project, choose **Build** from the **Build** menu.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
 Modifications made to the base form at run time have no affect on inherited forms that are already instantiated.  
  
## See Also  
 [base](~/docs/csharp/language-reference/keywords/base.md)  
 [How to: Inherit Windows Forms](../../../../docs/framework/winforms/advanced/how-to-inherit-windows-forms.md)  
 [Windows Forms Visual Inheritance](../../../../docs/framework/winforms/advanced/windows-forms-visual-inheritance.md)
