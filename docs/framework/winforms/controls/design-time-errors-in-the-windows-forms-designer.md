---
title: Design-time errors in the Windows Forms Designer
ms.date: 09/09/2019
f1_keywords:
  - "DTELErrorList"
  - "WhyDTELPage"
helpviewer_keywords:
  - "errors [Windows Forms Designer]"
  - "design-time errors [Windows Forms Designer]"
ms.assetid: ad408380-825a-46d8-9a4a-531b130b88ce
author: gewarren
ms.author: gewarren
manager: jillfra
---
# Windows Forms Designer error page

If the Windows Forms Designer fails to load due to an error in your code, you'll see an error page instead of the designer. This error page does not signify a bug in the designer but rather somewhere in the code-behind page that's named \<your-form-name>.Designer.cs. Errors appear in collapsible, yellow  bars with a link to jump to the location of the error on the code page.

![Windows Forms Designer error page](media/windows-forms-designer-error-page-collapsed.png)

You can choose to ignore the errors and continue loading the designer by clicking **Ignore and Continue**. This action may result in unexpected behavior, for example, controls may not appear on the design surface.

## Instances of this error

When the yellow error bar is expanded, each instance of the error is listed. Many error types include an exact location in the following format: *[Project Name]* *[Form Name]* Line:*[Line Number]* Column:*[Column Number]*. If a call stack is associated with the error, you can click the **Show Call Stack** link to see it. Examining the call stack may further help you resolve the error.

![Windows Forms Designer expanded error](media/windows-forms-designer-error-page-expanded.png)

> [!NOTE]
> - For Visual Basic apps, the design-time error page does not display more than one error, but it may display multiple instances of the same error.
> - For C++ apps, errors don't have code location links.

## Help with this error

If a help topic for the error is available, click the **MSDN Help** link to navigate directly to the help page on docs.microsoft.com.

## Forum posts about this error

Click the **Search the MSDN Forums for posts related to this error** link to navigate to the Microsoft Developer Network forums. You may want to specifically search the [Windows Forms Designer](https://social.msdn.microsoft.com/Forums/windows/home?forum=winformsdesigner) or [Windows Forms](https://social.msdn.microsoft.com/Forums/windows/home?category=windowsforms) forums.

## See also

- [Troubleshooting Design-Time Development](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/ms171843(v=vs.120))
- [Troubleshooting Control and Component Authoring](troubleshooting-control-and-component-authoring.md)
- [Developing Windows Forms Controls at Design Time](developing-windows-forms-controls-at-design-time.md)
- [Windows Forms Designer Error Messages](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/ms233640(v=vs.100))
