---
title: "How to: Print a Form by Using the PrintForm Component (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Form [Visual Basic], printing"
ms.assetid: df963bf6-3ee1-49f4-8b2e-1d95d1beb0be
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Print a Form by Using the PrintForm Component (Visual Basic)
The <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component enables you to quickly print an image of a form exactly as it appears on screen without using a <xref:System.Drawing.Printing.PrintDocument> component. The following procedures show how to print a form to a printer, to a print preview window, and to an Encapsulated PostScript file.  
  
 The PowerPack controls are no longer included in Visual Studio, but you can download them from the [Download Center](http://www.microsoft.com/en-us/download/details.aspx?id=25169).  
  
### To print a form to the default printer  
  
1.  In the **Toolbox**, click the **Visual Basic PowerPacks** tab and then drag the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component onto the form.  
  
     The <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component is added to the component tray.  
  
2.  In the **Properties** window, set the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintAction%2A> property to <xref:System.Drawing.Printing.PrintAction.PrintToPrinter>.  
  
3.  Add the following code in the appropriate event handler (for example, in the `Click` event handler for a **Print**`Button`).  
  
    ```  
    PrintForm1.Print()  
    ```  
  
### To display a form in a print preview window  
  
1.  In the **Toolbox**, click the **Visual Basic PowerPacks** tab and then drag the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component onto the form.  
  
     The <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component is added to the component tray.  
  
2.  In the **Properties** window, set the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintAction%2A> property to <xref:System.Drawing.Printing.PrintAction.PrintToPreview>.  
  
3.  Add the following code in the appropriate event handler (for example, in the `Click` event handler for a **Print**`Button`).  
  
    ```  
    PrintForm1.Print()  
    ```  
  
### To print a form to a file  
  
1.  In the **Toolbox**, click the **Visual Basic PowerPacks** tab and then drag the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component onto the form.  
  
     The <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component is added to the component tray.  
  
2.  In the **Properties** window, set the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintAction%2A> property to <xref:System.Drawing.Printing.PrintAction.PrintToFile>.  
  
3.  Optionally, select the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintFileName%2A> property and type the full path and file name for the destination file.  
  
     If you skip this step, the user will be prompted for a file name at run time.  
  
4.  Add the following code in the appropriate event handler (for example, in the `Click` event handler for a **Print**`Button`).  
  
    ```  
    PrintForm1.Print()  
    ```  
  
## See Also  
 <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintAction%2A>  
 <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintFileName%2A>  
 [How to: Print the Client Area of a Form](../../../visual-basic/developing-apps/printing/how-to-print-the-client-area-of-a-form.md)  
 [How to: Print Client and Non-Client Areas of a Form](../../../visual-basic/developing-apps/printing/how-to-print-client-and-non-client-areas-of-a-form.md)  
 [How to: Print a Scrollable Form](../../../visual-basic/developing-apps/printing/how-to-print-a-scrollable-form.md)  
 [PrintForm Component](../../../visual-basic/developing-apps/printing/printform-component.md)
