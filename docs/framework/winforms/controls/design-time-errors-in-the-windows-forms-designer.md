---
title: "Design-Time Errors in the Windows Forms Designer"
ms.date: "03/30/2017"
f1_keywords: 
  - "DTELErrorList"
  - "WhyDTELPage"
helpviewer_keywords: 
  - "errors [Windows Forms Designer]"
  - "design-time errors [Windows Forms Designer]"
ms.assetid: ad408380-825a-46d8-9a4a-531b130b88ce
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
  
-   [Windows Forms Designer Forum](https://go.microsoft.com/fwlink/?LinkId=203524)  
  
-   [Windows Forms Forums](https://go.microsoft.com/fwlink/?LinkId=203523)  
  
### Ignore and Continue  
 You can choose to ignore the error condition and continue loading the designer. Choosing this action may result in unexpected behavior. For example, controls may not appear on the design surface.  
  
## See also

- [Troubleshooting Design-Time Development](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/ms171843(v=vs.120))
- [Troubleshooting Control and Component Authoring](troubleshooting-control-and-component-authoring.md)
- [Developing Windows Forms Controls at Design Time](developing-windows-forms-controls-at-design-time.md)
- [Windows Forms Designer Error Messages](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/ms233640(v=vs.100))
