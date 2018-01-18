---
title: "How to: Use Named and Optional Arguments in Office Programming (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "named and optional arguments [C#], Office programming"
  - "optional arguments [C#], Office programming"
  - "named arguments [C#], Office programming"
ms.assetid: 65b8a222-bcd8-454c-845f-84adff5a356f
caps.latest.revision: 34
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Use Named and Optional Arguments in Office Programming (C# Programming Guide)
Named arguments and optional arguments, introduced in [!INCLUDE[csharp_dev10_long](~/includes/csharp-dev10-long-md.md)], enhance convenience, flexibility, and readability in C# programming. In addition, these features greatly facilitate access to COM interfaces such as the Microsoft Office automation APIs.  
  
 In the following example, method [ConvertToTable](https://msdn.microsoft.com/library/bb216993.aspx) has sixteen parameters that represent characteristics of a table, such as number of columns and rows, formatting, borders, fonts, and colors. All sixteen parameters are optional, because most of the time you do not want to specify particular values for all of them. However, without named and optional arguments, a value or a placeholder value has to be provided for each parameter. With named and optional arguments, you specify values only for the parameters that are required for your project.  
  
 You must have Microsoft Office Word installed on your computer to complete these procedures.  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
### To create a new console application  
  
1.  Start Visual Studio.  
  
2.  On the **File** menu, point to **New**, and then click **Project**.  
  
3.  In the **Templates Categories** pane, expand **Visual C#**, and then click **Windows**.  
  
4.  Look in the top of the **Templates** pane to make sure that **.NET Framework 4** appears in the **Target Framework** box.  
  
5.  In the **Templates** pane, click **Console Application**.  
  
6.  Type a name for your project in the **Name** field.  
  
7.  Click **OK**.  
  
     The new project appears in **Solution Explorer**.  
  
### To add a reference  
  
1.  In **Solution Explorer**, right-click your project's name and then click **Add Reference**. The **Add Reference** dialog box appears.  
  
2.  On the **.NET** page, select **Microsoft.Office.Interop.Word** in the **Component Name** list.  
  
3.  Click **OK**.  
  
### To add necessary using directives  
  
1.  In **Solution Explorer**, right-click the **Program.cs** file and then click **View Code**.  
  
2.  Add the following `using` directives to the top of the code file.  
  
     [!code-csharp[csProgGuideNamedAndOptional#4](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-use-named-and-optional-arguments-in-office-programming_1.cs)]  
  
### To display text in a Word document  
  
1.  In the `Program` class in Program.cs, add the following method to create a Word application and a Word document. The [Add](https://msdn.microsoft.com/library/microsoft.office.interop.word.documents.add.aspx) method has four optional parameters. This example uses their default values. Therefore, no arguments are necessary in the calling statement.  
  
     [!code-csharp[csProgGuideNamedAndOptional#6](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-use-named-and-optional-arguments-in-office-programming_2.cs)]  
  
2.  Add the following code at the end of the method to define where to display text in the document, and what text to display.  
  
     [!code-csharp[csProgGuideNamedAndOptional#7](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-use-named-and-optional-arguments-in-office-programming_3.cs)]  
  
### To run the application  
  
1.  Add the following statement to Main.  
  
     [!code-csharp[csProgGuideNamedAndOptional#8](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-use-named-and-optional-arguments-in-office-programming_4.cs)]  
  
2.  Press CTRL+F5 to run the project. A Word document appears that contains the specified text.  
  
### To change the text to a table  
  
1.  Use the `ConvertToTable` method to enclose the text in a table. The method has sixteen optional parameters. IntelliSense encloses optional parameters in brackets, as shown in the following illustration.  
  
     ![List of parameters for ConvertToTable method.](../../../csharp/programming-guide/classes-and-structs/media/convert_tableparameters.png "Convert_TableParameters")  
ConvertToTable parameters  
  
     Named and optional arguments enable you to specify values for only the parameters that you want to change. Add the following code to the end of method `DisplayInWord` to create a simple table. The argument specifies that the commas in the text string in `range` separate the cells of the table.  
  
     [!code-csharp[csProgGuideNamedAndOptional#9](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-use-named-and-optional-arguments-in-office-programming_5.cs)]  
  
     In earlier versions of C#, the call to `ConvertToTable` requires a reference argument for each parameter, as shown in the following code.  
  
     [!code-csharp[csProgGuideNamedAndOptional#14](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-use-named-and-optional-arguments-in-office-programming_6.cs)]  
  
2.  Press CTRL+F5 to run the project.  
  
### To experiment with other parameters  
  
1.  To change the table so that it has one column and three rows, replace the last line in `DisplayInWord` with the following statement and then type CTRL+F5.  
  
     [!code-csharp[csProgGuideNamedAndOptional#10](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-use-named-and-optional-arguments-in-office-programming_7.cs)]  
  
2.  To specify a predefined format for the table, replace the last line in `DisplayInWord` with the following statement and then type CTRL+F5. The format can be any of the [WdTableFormat](https://msdn.microsoft.com/library/microsoft.office.interop.word.wdtableformat.aspx) constants.  
  
     [!code-csharp[csProgGuideNamedAndOptional#11](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-use-named-and-optional-arguments-in-office-programming_8.cs)]  
  
## Example  
 The following code includes the full example.  
  
 [!code-csharp[csProgGuideNamedAndOptional#12](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-use-named-and-optional-arguments-in-office-programming_9.cs)]  
  
## See Also  
 [Named and Optional Arguments](../../../csharp/programming-guide/classes-and-structs/named-and-optional-arguments.md)
