---
title: "Walkthrough: Embedding Type Information from Microsoft Office Assemblies in Visual Studio (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 3320e866-01f1-4b7f-8932-049a7b2d2a9b
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Walkthrough: Embedding Type Information from Microsoft Office Assemblies in Visual Studio (C#)
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
  
4.  In **Solution Explorer**, open the shortcut menu for the **References** folder and then choose **Add Reference**.  
  
5.  On the **.NET** tab, choose the most recent version of `Microsoft.Office.Interop.Excel`. For example, **Microsoft.Office.Interop.Excel 14.0.0.0**. Choose the **OK** button.  
  
6.  In the list of references for the **CreateExcelWorkbook** project, select the reference for `Microsoft.Office.Interop.Excel` that you added in the previous step. In the **Properties** window, make sure that the `Embed Interop Types` property is set to `True`.  
  
    > [!NOTE]
    >  The application created in this walkthrough runs with different versions of Microsoft Office because of the embedded interop type information. If the `Embed Interop Types` property is set to `False`, you must include a PIA for each version of Microsoft Office that the application will run with.  
  
7.  Open the **Program.cs** file. Replace the code in the file with the following code:  
  
    ```csharp  
    using System;  
    using System.Collections.Generic;  
    using System.Linq;  
    using System.Text;  
    using System.IO;  
    using Excel = Microsoft.Office.Interop.Excel;  
  
    namespace CreateExcelWorkbook  
    {  
        class Program  
        {  
            static void Main(string[] args)  
            {  
                int[] values = {4, 6, 18, 2, 1, 76, 0, 3, 11};  
  
                CreateWorkbook(values, @"C:\SampleFolder\SampleWorkbook.xls");  
            }  
  
            static void CreateWorkbook(int[] values, string filePath)  
            {  
                Excel.Application excelApp = null;  
                Excel.Workbook wkbk;  
                Excel.Worksheet sheet;  
  
                try  
                {  
                        // Start Excel and create a workbook and worksheet.  
                        excelApp = new Excel.Application();  
                        wkbk = excelApp.Workbooks.Add();  
                        sheet = wkbk.Sheets.Add() as Excel.Worksheet;  
                        sheet.Name = "Sample Worksheet";  
  
                        // Write a column of values.  
                        // In the For loop, both the row index and array index start at 1.  
                        // Therefore the value of 4 at array index 0 is not included.  
                        for (int i = 1; i < values.Length; i++)  
                        {  
                            sheet.Cells[i, 1] = values[i];  
                        }  
  
                        // Suppress any alerts and save the file. Create the directory   
                        // if it does not exist. Overwrite the file if it exists.  
                        excelApp.DisplayAlerts = false;  
                        string folderPath = Path.GetDirectoryName(filePath);  
                        if (!Directory.Exists(folderPath))  
                        {  
                            Directory.CreateDirectory(folderPath);  
                        }  
                        wkbk.SaveAs(filePath);  
                }  
                catch  
                {  
                }  
                finally  
                {  
                    sheet = null;  
                    wkbk = null;  
  
                    // Close Excel.  
                    excelApp.Quit();  
                    excelApp = null;  
                }  
            }  
        }  
    }  
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
 [Walkthrough: Embedding Types from Managed Assemblies in Visual Studio (C#)](../../../../csharp/programming-guide/concepts/assemblies-gac/walkthrough-embedding-types-from-managed-assemblies-in-visual-studio.md)  
 [/link (C# Compiler Options)](../../../../csharp/language-reference/compiler-options/link-compiler-option.md)
