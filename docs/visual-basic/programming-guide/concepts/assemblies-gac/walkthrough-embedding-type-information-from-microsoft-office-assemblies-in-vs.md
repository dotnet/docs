---
title: "Walkthrough: Embedding Type Information from Microsoft Office Assemblies in Visual Studio (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 26b44286-5066-4ad4-8e6a-c24902be347c
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Walkthrough: Embedding Type Information from Microsoft Office Assemblies in Visual Studio (Visual Basic)
If you embed type information in an application that references COM objects, you can eliminate the need for a primary interop assembly (PIA). Additionally, the embedded type information enables you to achieve version independence for your application. That is, your program can be written to use types from multiple versions of a COM library without requiring a specific PIA for each version. This is a common scenario for applications that use objects from Microsoft Office libraries. Embedding type information enables the same build of a program to work with different versions of Microsoft Office on different computers without the need to redeploy either the program or the PIA for each version of Microsoft Office.  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
## Prerequisites  
 This walkthrough requires the following:  
  
-   A computer on which Visual Studio and Microsoft Excel are installed.  
  
-   A second computer on which the .NET Framework 4 or higher and a different version of Excel are installed.  
  
##  <a name="BKMK_createapp"></a> To create an application that works with multiple versions of Microsoft Office  
  
1.  Start Visual Studio on a computer on which Excel is installed.  
  
2.  On the **File** menu, choose **New**, **Project**.  
  
3.  In the **New Project** dialog box, in the **Project Types** pane, make sure that **Windows** is selected. Select **Console Application** in the **Templates** pane. In the **Name** box, enter `CreateExcelWorkbook`, and then choose the **OK** button. The new project is created.  
  
4.  Open the shortcut menu for the CreateExcelWorkbook project and then choose **Properties**. Choose the **References** tab. Choose the **Add** button.  
  
5.  On the **.NET** tab, choose the most recent version of `Microsoft.Office.Interop.Excel`. For example, **Microsoft.Office.Interop.Excel 14.0.0.0**. Choose the **OK** button.  
  
6.  In the list of references for the **CreateExcelWorkbook** project, select the reference for `Microsoft.Office.Interop.Excel` that you added in the previous step. In the **Properties** window, make sure that the `Embed Interop Types` property is set to `True`.  
  
    > [!NOTE]
    >  The application created in this walkthrough runs with different versions of Microsoft Office because of the embedded interop type information. If the `Embed Interop Types` property is set to `False`, you must include a PIA for each version of Microsoft Office that the application will run with.  
  
7.  Open the Module1.vb file. Replace the code in the file with the following code:  
  
    ```vb  
    Imports Excel = Microsoft.Office.Interop.Excel  
  
    Module Module1  
  
        Sub Main()  
            Dim values = {4, 6, 18, 2, 1, 76, 0, 3, 11}  
  
            CreateWorkbook(values, "C:\SampleFolder\SampleWorkbook.xls")  
        End Sub  
  
        Sub CreateWorkbook(ByVal values As Integer(), ByVal filePath As String)  
            Dim excelApp As Excel.Application = Nothing  
            Dim wkbk As Excel.Workbook  
            Dim sheet As Excel.Worksheet  
  
            Try  
                ' Start Excel and create a workbook and worksheet.  
                excelApp = New Excel.Application  
                wkbk = excelApp.Workbooks.Add()  
                sheet = CType(wkbk.Sheets.Add(), Excel.Worksheet)  
                sheet.Name = "Sample Worksheet"  
  
                ' Write a column of values.  
                ' In the For loop, both the row index and array index start at 1.  
                ' Therefore the value of 4 at array index 0 is not included.  
                For i = 1 To values.Length - 1  
                    sheet.Cells(i, 1) = values(i)  
                Next  
  
                ' Suppress any alerts and save the file. Create the directory   
                ' if it does not exist. Overwrite the file if it exists.  
                excelApp.DisplayAlerts = False  
                Dim folderPath = My.Computer.FileSystem.GetParentPath(filePath)  
                If Not My.Computer.FileSystem.DirectoryExists(folderPath) Then  
                    My.Computer.FileSystem.CreateDirectory(folderPath)  
                End If  
                wkbk.SaveAs(filePath)  
    	Catch  
  
            Finally  
                sheet = Nothing  
                wkbk = Nothing  
  
                ' Close Excel.  
                excelApp.Quit()  
                excelApp = Nothing  
            End Try  
  
        End Sub  
    End Module  
    ```  
  
8.  Save the project.  
  
9. Press CTRL+F5 to build and run the project. Verify that an Excel workbook has been created at the location specified in the example code: C:\SampleFolder\SampleWorkbook.xls.  
  
##  <a name="BKMK_publishapp"></a> To publish the application to a computer on which a different version of Microsoft Office is installed  
  
1.  Open the project created by this walkthrough in Visual Studio.  
  
2.  On the **Build** menu, choose **Publish CreateExcelWorkbook**. Follow the steps of the Publish Wizard to create an installable version of the application. For more information, see [Publish Wizard (Office Development in Visual Studio)](https://msdn.microsoft.com/library/bb625071).  
  
3.  Install the application on a computer on which the .NET Framework 4 or higher and a different version of Excel are installed.  
  
4.  When the installation is finished, run the installed program.  
  
5.  Verify that an Excel workbook has been created at the location specified in the sample code: C:\SampleFolder\SampleWorkbook.xls.  
  
## See Also  
 [Walkthrough: Embedding Types from Managed Assemblies in Visual Studio (Visual Basic)](../../../../visual-basic/programming-guide/concepts/assemblies-gac/walkthrough-embedding-types-from-managed-assemblies-in-vs.md)  
 [/link (Visual Basic)](../../../../visual-basic/reference/command-line-compiler/link.md)
