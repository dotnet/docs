---
title: "How to use named and optional arguments in Office programming - C# Programming Guide"
description: Learn how to use named arguments and optional arguments to facilitate access to COM interfaces such as the Microsoft Office automation APIs.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "named and optional arguments [C#], Office programming"
  - "optional arguments [C#], Office programming"
  - "named arguments [C#], Office programming"
ms.topic: how-to
ms.custom: contperf-fy21q2
ms.assetid: 65b8a222-bcd8-454c-845f-84adff5a356f
---
# How to use named and optional arguments in Office programming (C# Programming Guide)

Named arguments and optional arguments, introduced in C# 4, enhance convenience, flexibility, and readability in C# programming. In addition, these features greatly facilitate access to COM interfaces such as the Microsoft Office automation APIs.

In the following example, method [ConvertToTable](<xref:Microsoft.Office.Interop.Word.Range.ConvertToTable%2A>) has sixteen parameters that represent characteristics of a table, such as number of columns and rows, formatting, borders, fonts, and colors. All sixteen parameters are optional, because most of the time you do not want to specify particular values for all of them. However, without named and optional arguments, a value or a placeholder value has to be provided for each parameter. With named and optional arguments, you specify values only for the parameters that are required for your project.

You must have Microsoft Office Word installed on your computer to complete these procedures.

[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]

## To create a new console application

1. Start Visual Studio.

2. On the **File** menu, point to **New**, and then click **Project**.

3. In the **Templates Categories** pane, expand **Visual C#**, and then click **Windows**.

4. Look in the top of the **Templates** pane to make sure that **.NET Framework 4** appears in the **Target Framework** box.

5. In the **Templates** pane, click **Console Application**.

6. Type a name for your project in the **Name** field.

7. Click **OK**.

     The new project appears in **Solution Explorer**.

## To add a reference

1. In **Solution Explorer**, right-click your project's name and then click **Add Reference**. The **Add Reference** dialog box appears.

2. On the **.NET** page, select **Microsoft.Office.Interop.Word** in the **Component Name** list.

3. Click **OK**.

## To add necessary using directives

1. In **Solution Explorer**, right-click the *Program.cs* file and then click **View Code**.

2. Add the following `using` directives to the top of the code file:

     [!code-csharp[csProgGuideNamedAndOptional#4](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidenamedandoptional/cs/wordprogram.cs#4)]

## To display text in a Word document

1. In the `Program` class in *Program.cs*, add the following method to create a Word application and a Word document. The [Add](<xref:Microsoft.Office.Interop.Word.Documents.Add%2A>) method has four optional parameters. This example uses their default values. Therefore, no arguments are necessary in the calling statement.

     [!code-csharp[csProgGuideNamedAndOptional#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidenamedandoptional/cs/wordprogram.cs#6)]

2. Add the following code at the end of the method to define where to display text in the document, and what text to display:

     [!code-csharp[csProgGuideNamedAndOptional#7](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidenamedandoptional/cs/wordprogram.cs#7)]

## To run the application

1. Add the following statement to Main:

     [!code-csharp[csProgGuideNamedAndOptional#8](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidenamedandoptional/cs/wordprogram.cs#8)]

2. Press <kbd>CTRL</kbd>+<kbd>F5</kbd> to run the project. A Word document appears that contains the specified text.

## To change the text to a table
  
1. Use the `ConvertToTable` method to enclose the text in a table. The method has sixteen optional parameters. IntelliSense encloses optional parameters in brackets, as shown in the following illustration.

     ![List of parameters for ConvertToTable method](./media/how-to-use-named-and-optional-arguments-in-office-programming/convert-table-parameters.png)

     Named and optional arguments enable you to specify values for only the parameters that you want to change. Add the following code to the end of method `DisplayInWord` to create a simple table. The argument specifies that the commas in the text string in `range` separate the cells of the table.

     [!code-csharp[csProgGuideNamedAndOptional#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidenamedandoptional/cs/wordprogram.cs#9)]

     In earlier versions of C#, the call to `ConvertToTable` requires a reference argument for each parameter, as shown in the following code:
  
     [!code-csharp[csProgGuideNamedAndOptional#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidenamedandoptional/cs/wordprogram.cs#14)]

2. Press <kbd>CTRL</kbd>+<kbd>F5</kbd> to run the project.

## To experiment with other parameters

1. To change the table so that it has one column and three rows, replace the last line in `DisplayInWord` with the following statement and then type <kbd>CTRL</kbd>+<kbd>F5</kbd>.  

     [!code-csharp[csProgGuideNamedAndOptional#10](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidenamedandoptional/cs/wordprogram.cs#10)]

2. To specify a predefined format for the table, replace the last line in `DisplayInWord` with the following statement and then type <kbd>CTRL</kbd>+<kbd>F5</kbd>. The format can be any of the [WdTableFormat](<xref:Microsoft.Office.Interop.Word.WdTableFormat>) constants.

     [!code-csharp[csProgGuideNamedAndOptional#11](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidenamedandoptional/cs/wordprogram.cs#11)]

## Example

The following code includes the full example:

 [!code-csharp[csProgGuideNamedAndOptional#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidenamedandoptional/cs/wordprogram.cs#12)]

## See also

- [Named and Optional Arguments](./named-and-optional-arguments.md)
