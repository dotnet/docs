---
title: "PrintForm Component (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "PrintForm component [Visual Basic]"
ms.assetid: 03de98b8-b54c-4764-91d7-83c64e974750
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# PrintForm Component (Visual Basic)
The <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component for [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] enables you to print an image of a Windows Form at run time. Its behavior replaces that of the `PrintForm` method in earlier versions of Visual Basic.  
  
 The PowerPack controls are no longer included in Visual Studio, but you can download them from the [Download Center](http://www.microsoft.com/en-us/download/details.aspx?id=25169).  
  
## PrintForm Component Overview  
 A common scenario for Windows Forms is to create a form that is formatted to resemble a paper form or a report, and then to print an image of the form. Although you can use a <xref:System.Drawing.Printing.PrintDocument> component to do this, it would require a lot of code. The <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component enables you to print an image of a form to a printer, to a print preview window, or to a file without using a <xref:System.Drawing.Printing.PrintDocument> component.  
  
 The <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component is located on the **Visual Basic PowerPacks** tab of the **Toolbox**. When it is dragged onto a form it appears in the component tray, the small area under the bottom border of the form. When the component is selected, properties that define its behavior can be set in the **Properties** window. All of these properties can also be set in code. You can also create an instance of the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component in code without adding the component at design time.  
  
 When you print a form, everything in the client area of the form is printed. This includes all controls and any text or graphics drawn on the form by graphics methods. By default, the form's title bar, scroll bars, and border are not printed. Also by default, the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component prints only the visible part of the form. For example, if the user resizes the form at run time, only the controls and graphics that are currently visible are printed.  
  
 The default printer used by the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component is determined by the operating system's Control Panel settings.  
  
 After printing is initiated, a standard <xref:System.Drawing.Printing.PrintDocument> printing dialog box is displayed. This dialog box enables users to cancel the print job.  
  
### Key Methods, Properties, and Events  
 The key method of the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component is the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.Print%2A> method, which prints an image of the form to a printer, print preview window, or file. There are two versions of the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.Print%2A> method:  
  
-   A basic version without parameters: `Print()`  
  
-   An overloaded version with parameters that specify printing behavior: `Print(printForm As Form, printFormOption As PrintOption)`  
  
     The `PrintOption` parameter of the overloaded method determines the underlying implementation used to print the form, whether the form's title bar, scroll bars, and border are printed, and whether scrollable parts of the form are printed.  
  
 The <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintAction%2A> property is a key property of the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component. This property determines whether the output is sent to a printer, displayed in a print preview window, or saved as an Encapsulated PostScript file. If the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintAction%2A> property is set to <xref:System.Drawing.Printing.PrintAction.PrintToFile>, the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintFileName%2A> property specifies the path and file name.  
  
 The <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrinterSettings%2A> property provides access to an underlying <xref:System.Drawing.Printing.PrintDocument.PrinterSettings%2A> object that enables you to specify such settings as the printer to use and the number of copies to print. You can also query the printer's capabilities, such as color or duplex support. This property does not appear in the **Properties** window; it can be accessed only from code.  
  
 The <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.Form%2A> property is used to specify the form to print when you invoke the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component programmatically. If the component is added to a form at design time, that form is the default.  
  
 Key events for the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component include the following:  
  
-   <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.BeginPrint> event. Occurs when the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.Print%2A> method is called and before the first page of the document prints.  
  
-   <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.EndPrint> event. Occurs after the last page is printed.  
  
-   <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.QueryPageSettings> event. Occurs immediately before each page is printed.  
  
### Remarks  
 If a form contains text or graphics drawn by <xref:System.Drawing.Graphics> methods, use the basic <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.Print%2A> (`Print()`) method to print it. Graphics may not render on some operating systems when the overloaded <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.Print%2A> method is used.  
  
 If the width of a form is wider than the width of the paper in the printer, the right side of the form might be cut off. When you design forms for printing, make sure that the form fits on standard-sized paper.  
  
## Example  
 The following example shows a common use of the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component.  
  
```  
' Visual Basic.  
Dim pf As New PrintForm  
pf.Form = Me  
pf.PrintAction = PrintToPrinter  
pf.Print()  
```  
  
## See Also  
 <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.Print%2A>  
 <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintAction%2A>  
 [How to: Print a Form by Using the PrintForm Component](../../../visual-basic/developing-apps/printing/how-to-print-a-form-by-using-the-printform-component.md)  
 [How to: Print the Client Area of a Form](../../../visual-basic/developing-apps/printing/how-to-print-the-client-area-of-a-form.md)  
 [How to: Print Client and Non-Client Areas of a Form](../../../visual-basic/developing-apps/printing/how-to-print-client-and-non-client-areas-of-a-form.md)  
 [How to: Print a Scrollable Form](../../../visual-basic/developing-apps/printing/how-to-print-a-scrollable-form.md)
