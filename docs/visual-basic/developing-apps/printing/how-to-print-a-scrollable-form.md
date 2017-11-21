---
title: "How to: Print a Scrollable Form (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "entire form [Visual Basic], printing"
  - "scrollable form [Visual Basic], printing"
ms.assetid: 1196e1cf-b77f-4928-a3e4-85b51ba3787d
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Print a Scrollable Form (Visual Basic)
The <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component enables you to quickly print an image of a form without using a <xref:System.Drawing.Printing.PrintDocument> component. By default, only the currently visible part of the form is printed; if a user has resized the form at run time, the image may not print as intended. The following procedure shows how to print the complete client area of a scrollable form, even if the form has been resized.  
  
 The PowerPack controls are no longer included in Visual Studio, but you can download them from the [Download Center](http://www.microsoft.com/en-us/download/details.aspx?id=25169).  
  
### To print the complete client area of a scrollable form  
  
1.  In the **Toolbox**, click the **Visual Basic PowerPacks** tab and then drag the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component onto the form.  
  
     The <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm> component will be added to the component tray.  
  
2.  In the **Properties** window, set the <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintAction%2A> property to <xref:System.Drawing.Printing.PrintAction.PrintToPrinter>.  
  
3.  Add the following code in the appropriate event handler (for example, in the `Click` event handler for a **Print**`Button`).  
  
    ```  
    PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.Scrollable)  
    ```  
  
    > [!NOTE]
    >  On some operating systems, text or graphics drawn by <xref:System.Drawing.Graphics> methods may not print correctly. In this case, you will not be able to print with the `Scrollable` parameter.  
  
## See Also  
 <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintAction%2A>  
 <xref:Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.Print%2A>  
 [PrintForm Component](../../../visual-basic/developing-apps/printing/printform-component.md)  
 [How to: Print the Client Area of a Form](../../../visual-basic/developing-apps/printing/how-to-print-the-client-area-of-a-form.md)  
 [How to: Print Client and Non-Client Areas of a Form](../../../visual-basic/developing-apps/printing/how-to-print-client-and-non-client-areas-of-a-form.md)
