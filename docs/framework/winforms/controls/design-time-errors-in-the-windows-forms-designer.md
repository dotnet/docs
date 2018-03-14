---
title: "Design-Time Errors in the Windows Forms Designer"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "DTELErrorList"
  - "WhyDTELPage"
helpviewer_keywords: 
  - "errors [Windows Forms Designer]"
  - "design-time errors [Windows Forms Designer]"
ms.assetid: ad408380-825a-46d8-9a4a-531b130b88ce
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Design-Time Errors in the Windows Forms Designer
This topic explains the meaning and use of the design-time error list that appears in Microsoft Visual Studio when the Windows Forms Designer fails to load. If this error list appears, you should not interpret it as a bug in the designer, but as an aid to correcting errors in your code.  
  
 A basic understanding of this error list will help you debug your applications by providing detailed information about the errors and suggesting possible solutions.  
  
## The Design-Time Error List Interface  
 If the Windows Forms Designer fails to load, an error list will appear in the designer. The errors are grouped into categories. For example, if you have four instances of undeclared variables, these will be grouped into the same error category. Each error category includes a brief description that summarizes the error.  
  
 You can expand or collapse an error category by either clicking on the error category heading or by clicking the expand/collapse chevron. When you expand an error category, the following additional help is displayed:  
  
-   Instances of this error.  
  
-   Help with this error.  
  
-   Forum posts about this error.  
  
### Instances of This Error  
 The additional help list all instances of the error in your current project. Many errors include an exact location in the following format: *[Project Name]* *[Form Name]* Line:*[Line Number]* Column:*[Column Number]*. The **Go to code** link takes you to the location in your code where the error occurs.  
  
 If a call stack is associated with the error, you can click the **Show Call Stack** link, which further expands the error to show the call stack. Examining the stack can provide valuable debugging information. For example, you can track the functions that were called before the error occurred. The call stack is selectable so that you can copy and save it.  
  
> [!NOTE]
>  In Visual Basic, the design-time error list does not display more than one error, but it may display multiple instances of the same error. In Visual C++, the errors do not have goto code links/line number links.  
  
### Help with This Error  
 If the error contains a link to an associated MSDN help topic, the additional help will include a link to the help topic. When you click the link, the associated help topic appears in Visual Studio.  
  
### Forum posts about this error  
 The additional help will include a link to MSDN forum posts related to the error. The forums are searched based on the string of the error message. You can also try searching the following forums:  
  
-   [Windows Forms Designer Forum](http://go.microsoft.com/fwlink/?LinkId=203524)  
  
-   [Windows Forms Forums](http://go.microsoft.com/fwlink/?LinkId=203523)  
  
### Ignore and Continue  
 You can choose to ignore the error condition and continue loading the designer. Choosing this action may result in unexpected behavior. For example, controls may not appear on the design surface.  
  
## See Also  
 [Troubleshooting Design-Time Development](http://msdn.microsoft.com/library/e048d08e-fa7c-4be8-b238-4abaa199a0a6)  
 [Troubleshooting Control and Component Authoring](../../../../docs/framework/winforms/controls/troubleshooting-control-and-component-authoring.md)  
 [Developing Windows Forms Controls at Design Time](../../../../docs/framework/winforms/controls/developing-windows-forms-controls-at-design-time.md)  
 [Windows Forms Designer Error Messages](http://msdn.microsoft.com/library/cf610bf4-5fe4-471c-bce7-6a05ece07bd2)
