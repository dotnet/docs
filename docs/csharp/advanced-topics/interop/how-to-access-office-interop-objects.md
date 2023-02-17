---
title: "How to access Office interop objects - C# Programming Guide"
description: Learn about C# features that simplify access to Office API objects. Use the new features to write code that creates and displays an Excel worksheet.
ms.topic: how-to
ms.date: 02/15/2023
helpviewer_keywords:
  - "optional parameters [C#], Office programming"
  - "named and optional arguments [C#], Office programming"
  - "dynamic [C#], Office programming"
  - "optional arguments [C#], Office programming"
  - "named arguments [C#], Office programming"
  - "Office programming [C#]"
---
# How to access Office interop objects

C# has features that simplify access to Office API objects. The new features include named and optional arguments, a new type called `dynamic`, and the ability to pass arguments to reference parameters in COM methods as if they were value parameters.

In this article, you use the new features to write code that creates and displays a Microsoft Office Excel worksheet. You write code to add an Office Word document that contains an icon that is linked to the Excel worksheet.

To complete this walkthrough, you must have Microsoft Office Excel 2007 and Microsoft Office Word 2007, or later versions, installed on your computer.

[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]

## To create a new console application

1. Start Visual Studio.
1. On the **File** menu, point to **New**, and then select **Project**. The **New Project** dialog box appears.
1. In the **Installed Templates** pane, expand **C#**, and then select **Windows**.
1. Look at the top of the **New Project** dialog box to make sure to select **.NET Framework 4** (or later version) as a target framework.
1. In the **Templates** pane, select **Console Application**.
1. Type a name for your project in the **Name** field.
1. Select **OK**.

The new project appears in **Solution Explorer**.

## To add references

1. In **Solution Explorer**, right-click your project's name and then select **Add Reference**. The **Add Reference** dialog box appears.
1. On the **Assemblies**  page, select **Microsoft.Office.Interop.Word** in the **Component Name** list, and then hold down the CTRL key and select **Microsoft.Office.Interop.Excel**.  If you don't see the assemblies, you may need to install them. See [How to: Install Office Primary Interop Assemblies](/visualstudio/vsto/how-to-install-office-primary-interop-assemblies).
1. Select **OK**.

## To add necessary using directives

In **Solution Explorer**, right-click the *Program.cs* file and then select **View Code**. Add the following `using` directives to the top of the code file:

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet1":::

## To create a list of bank accounts

Paste the following class definition into **Program.cs**, under the `Program` class.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet2":::

Add the following code to the `Main` method to create a `bankAccounts` list that contains two accounts.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet3":::

## To declare a method that exports account information to Excel

1. Add the following method to the `Program` class to set up an Excel worksheet. Method <xref:Microsoft.Office.Interop.Excel.Workbooks.Add%2A> has an optional parameter for specifying a particular template. Optional parameters enable you to omit the argument for that parameter if you want to use the parameter's default value. Because you didn't supply an argument, `Add` uses the default template and creates a new workbook. The equivalent statement in earlier versions of C# requires a placeholder argument: `ExcelApp.Workbooks.Add(Type.Missing)`.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet4":::

Add the following code at the end of `DisplayInExcel`. The code inserts values into the first two columns of the first row of the worksheet.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet5":::

Add the following code at the end of `DisplayInExcel`. The `foreach` loop puts the information from the list of accounts into the first two columns of successive rows of the worksheet.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet7":::

Add the following code at the end of `DisplayInExcel` to adjust the column widths to fit the content.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet13":::

Earlier versions of C# require explicit casting for these operations because `ExcelApp.Columns[1]` returns an `Object`, and `AutoFit` is an Excel <xref:Microsoft.Office.Interop.Excel.Range> method. The following lines show the casting.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet14":::

C# converts the returned `Object` to `dynamic` automatically if the assembly is referenced by the [**EmbedInteropTypes**](../../language-reference/compiler-options/inputs.md#embedinteroptypes) compiler option or, equivalently, if the Excel **Embed Interop Types** property is true. True is the default value for this property.

## To run the project

Add the following line at the end of `Main`.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet8":::

Press CTRL+F5. An Excel worksheet appears that contains the data from the two accounts.

## To add a Word document

The following code opens a Word application and creates an icon that links to the Excel worksheet. Paste method `CreateIconInWordDoc`, provided later in this step, into the `Program` class. `CreateIconInWordDoc` uses named and optional arguments to reduce the complexity of the method calls to <xref:Microsoft.Office.Interop.Word.Documents.Add%2A> and <xref:Microsoft.Office.Interop.Word.Selection.PasteSpecial%2A>. These calls incorporate two other features that simplify calls to COM methods that have reference parameters. First, you can send arguments to the reference parameters as if they were value parameters. That is, you can send values directly, without creating a variable for each reference parameter. The compiler generates temporary variables to hold the argument values, and discards the variables when you return from the call. Second, you can omit the `ref` keyword in the argument list.

The `Add` method has four reference parameters, all of which are optional. You can omit arguments for any or all of the parameters if you want to use their default values.

The `PasteSpecial` method inserts the contents of the Clipboard. The method has seven reference parameters, all of which are optional. The following code specifies arguments for two of them: `Link`, to create a link to the source of the Clipboard contents, and `DisplayAsIcon`, to display the link as an icon. You can use named arguments for those two arguments and omit the others. Although these arguments are reference parameters, you don't have to use the `ref` keyword, or to create variables to send in as arguments. You can send the values directly.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet9":::

Add the following statement at the end of `Main`.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet11":::

Add the following statement at the end of `DisplayInExcel`. The `Copy` method adds the worksheet to the Clipboard.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet12":::

Press CTRL+F5. A Word document appears that contains an icon. Double-click the icon to bring the worksheet to the foreground.

## To set the Embed Interop Types property

More enhancements are possible when you call a COM type that doesn't require a primary interop assembly (PIA) at run time. Removing the dependency on PIAs results in version independence and easier deployment. For more information about the advantages of programming without PIAs, see [Walkthrough: Embedding Types from Managed Assemblies](../../../standard/assembly/embed-types-visual-studio.md).

In addition, programming is easier because the `dynamic` type represents the required and returned types declared in COM methods. Variables that have type `dynamic` aren't evaluated until run time, which eliminates the need for explicit casting. For more information, see [Using Type dynamic](using-type-dynamic.md).

Embedding type information instead of using PIAs is default behavior. Because of that default, several of the previous examples are simplified. You don't need any explicit casting. For example, the declaration of `worksheet` in `DisplayInExcel` is written as `Excel._Worksheet workSheet = excelApp.ActiveSheet` rather than `Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet`. The calls to `AutoFit` in the same method also would require explicit casting without the default, because `ExcelApp.Columns[1]` returns an `Object`, and `AutoFit` is an Excel  method. The following code shows the casting.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet14":::

To change the default and use PIAs instead of embedding type information, expand the References node in Solution Explorer,** and then select **Microsoft.Office.Interop.Excel** or **Microsoft.Office.Interop.Word**. If you can't see the **Properties** window, press **F4**. Find **Embed Interop Types** in the list of properties, and change its value to **False**. Equivalently, you can compile by using the [**References**](../../language-reference/compiler-options/inputs.md#references) compiler option instead of [**EmbedInteropTypes**](../../language-reference/compiler-options/inputs.md#embedinteroptypes) at a command prompt.

## To add additional formatting to the table

Replace the two calls to `AutoFit` in `DisplayInExcel` with the following statement.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet15":::

The <xref:Microsoft.Office.Interop.Excel.Range.AutoFormat%2A> method has seven value parameters, all of which are optional. Named and optional arguments enable you to provide arguments for none, some, or all of them. In the previous statement, you supply an argument for only one of the parameters, `Format`. Because `Format` is the first parameter in the parameter list, you don't have to provide the parameter name. However, the statement might be easier to understand if you include the parameter name, as shown in the following code.

:::code language="csharp" source="./snippets/OfficeInterop/program.cs" id="Snippet16":::

Press CTRL+F5 to see the result. You can find other formats in the listed in the <xref:Microsoft.Office.Interop.Excel.XlRangeAutoFormat> enumeration.

## Example

The following code shows the complete example.

:::code language="csharp" source="./snippets/OfficeInterop/walkthrough.cs" id="Snippet18":::

## See also

- <xref:System.Type.Missing?displayProperty=nameWithType>
- [dynamic](../../language-reference/builtin-types/reference-types.md)
- [Named and Optional Arguments](../../programming-guide/classes-and-structs/named-and-optional-arguments.md)
- [How to use named and optional arguments in Office programming](how-to-use-named-and-optional-arguments-in-office-programming.md)
