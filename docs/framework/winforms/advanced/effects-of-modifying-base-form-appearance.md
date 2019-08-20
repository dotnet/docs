---
title: "Effects of Modifying a Base Form's Appearance"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "parent forms [Windows Forms]"
  - "inherited forms [Windows Forms], modifications to base form"
  - "Windows Forms, base form appearance"
  - "base forms"
  - "inheritance [Windows Forms], forms"
ms.assetid: 1c3f2b29-a05c-4c6f-aa1a-4e66b94f343a
---
# Effects of modifying a base form's appearance

During application development, you may often need to change the appearance of the base form from which other forms in the project (or in other projects) are inheriting.

At design time, changes to the base form's appearance (be it the setting of properties or the addition and subtraction of controls) are reflected on inherited forms when the project containing the base form is built. It is not sufficient for you to simply save the changes to the base form. To build a project, choose **Build** from the **Build** menu.

Modifications made to the base form at run time have no affect on inherited forms that are already instantiated.

## See also

- [base](~/docs/csharp/language-reference/keywords/base.md)
- [How to: Inherit Windows Forms](how-to-inherit-windows-forms.md)
- [Windows Forms Visual Inheritance](windows-forms-visual-inheritance.md)
