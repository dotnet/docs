---
title: "How to: Complete Windows Forms Print Jobs"
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
  - "cpp"
helpviewer_keywords: 
  - "print jobs [Windows Forms], completing in Windows Forms"
  - "printing [Windows Forms], print jobs"
ms.assetid: 23ec74f7-34c5-4710-82a0-ee2914518548
caps.latest.revision: 23
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Complete Windows Forms Print Jobs
Frequently, word processors and other applications that involve printing will provide the option to display a message to users that a print job is complete. You can provide this functionality in your Windows Forms by handling the <xref:System.Drawing.Printing.PrintDocument.EndPrint> event of the <xref:System.Drawing.Printing.PrintDocument> component.  
  
 The following procedure requires that you have created a Windows-based application with a <xref:System.Drawing.Printing.PrintDocument> component on it, which is the standard way of enabling printing from a Windows-based application. For more information about printing from Windows Forms using the <xref:System.Drawing.Printing.PrintDocument> component, see [How to: Create Standard Windows Forms Print Jobs](../../../../docs/framework/winforms/advanced/how-to-create-standard-windows-forms-print-jobs.md).  
  
### To complete a print job  
  
1.  Set the <xref:System.Drawing.Printing.PrintDocument.DocumentName%2A> property of the <xref:System.Drawing.Printing.PrintDocument> component.  
  
    ```vb  
    PrintDocument1.DocumentName = "MyTextFile"  
    ```  
  
    ```csharp  
    printDocument1.DocumentName = "MyTextFile";  
    ```  
  
    ```cpp  
    printDocument1->DocumentName = "MyTextFile";  
    ```  
  
2.  Write code to handle the <xref:System.Drawing.Printing.PrintDocument.EndPrint> event.  
  
     In the following code example, a message box is displayed, indicating that the document has finished printing.  
  
    ```vb  
    Private Sub PrintDocument1_EndPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.EndPrint  
       MessageBox.Show(PrintDocument1.DocumentName + " has finished printing.")  
    End Sub  
    ```  
  
    ```csharp  
    private void printDocument1_EndPrint(object sender,   
    System.Drawing.Printing.PrintEventArgs e)  
    {  
       MessageBox.Show(printDocument1.DocumentName +   
          " has finished printing.");  
    }  
    ```  
  
    ```cpp  
    private:  
       void printDocument1_EndPrint(System::Object ^ sender,  
          System::Drawing::Printing::PrintEventArgs ^ e)  
       {  
          MessageBox::Show(String::Concat(printDocument1->DocumentName,  
             " has finished printing."));  
       }  
    ```  
  
     ([!INCLUDE[csprcs](../../../../includes/csprcs-md.md)] and [!INCLUDE[vcprvc](../../../../includes/vcprvc-md.md)]) Place the following code in the form's constructor to register the event handler.  
  
    ```csharp  
    this.printDocument1.EndPrint += new  
       System.Drawing.Printing.PrintEventHandler  
       (this.printDocument1_EndPrint);  
    ```  
  
    ```cpp  
    this->printDocument1->EndPrint += gcnew  
       System::Drawing::Printing::PrintEventHandler  
       (this, &Form1::printDocument1_EndPrint);  
    ```  
  
## See Also  
 <xref:System.Drawing.Printing.PrintDocument>  
 [Windows Forms Print Support](../../../../docs/framework/winforms/advanced/windows-forms-print-support.md)
