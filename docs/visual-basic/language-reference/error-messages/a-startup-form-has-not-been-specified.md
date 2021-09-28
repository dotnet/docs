---
description: "Learn more about: A startup form has not been specified"
title: "A startup form has not been specified"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrAppModel_NoStartupForm"
ms.assetid: 8e04af49-4bef-49de-a7ec-e407e9873da7
---
# A startup form has not been specified

The application uses the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase> class but does not specify the startup form.  
  
 This can occur if the **Enable application framework** check box is selected in the project designer but the **Startup form** is not specified. For more information, see [Application Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/application-page-project-designer-visual-basic).  
  
## To correct this error  
  
1. Specify a startup object for the application.  
  
     For more information, see [Application Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/application-page-project-designer-visual-basic).  
  
2. Override the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnCreateMainForm%2A> method to set the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.MainForm%2A> property to the startup form.  
  
## See also

- <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase>
- <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnCreateMainForm%2A>
- <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.MainForm%2A>
- [Overview of the Visual Basic Application Model](../../developing-apps/development-with-my/overview-of-the-visual-basic-application-model.md)
