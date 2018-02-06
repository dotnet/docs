---
title: "How to: Access Office Interop Objects by Using Visual C# Features (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "optional parameters [C#], Office programming"
  - "named and optional arguments [C#], Office programming"
  - "dynamic [C#], Office programming"
  - "optional arguments [C#], Office programming"
  - "named arguments [C#], Office programming"
  - "Office programming [C#]"
ms.assetid: 041b25c2-3512-4e0f-a4ea-ceb2999e4d5e
caps.latest.revision: 33
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Access Office Interop Objects by Using Visual C# Features (C# Programming Guide)
Visual C# has features that simplify access to Office API objects. The new features include named and optional arguments, a new type called `dynamic`, and the ability to pass arguments to reference parameters in COM methods as if they were value parameters.  
  
 In this topic you will use the new features to write code that creates and displays a Microsoft Office Excel worksheet. You will then write code to add an Office Word document that contains an icon that is linked to the Excel worksheet.  
  
 To complete this walkthrough, you must have Microsoft Office Excel 2007 and Microsoft Office Word 2007, or later versions, installed on your computer.  
  
 If you are using an operating system that is older than [!INCLUDE[windowsver](~/includes/windowsver-md.md)], make sure that [!INCLUDE[dnprdnlong](~/includes/dnprdnlong-md.md)] is installed.  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
### To create a new console application  
  
1.  Start Visual Studio.  
  
2.  On the **File** menu, point to **New**, and then click **Project**. The **New Project** dialog box appears.  
  
3.  In the **Installed Templates** pane, expand **Visual C#**, and then click **Windows**.  
  
4.  Look at the top of the **New Project** dialog box to make sure that **.NET Framework 4** (or later version) is selected as a target framework.  
  
5.  In the **Templates** pane, click **Console Application**.  
  
6.  Type a name for your project in the **Name** field.  
  
7.  Click **OK**.  
  
     The new project appears in **Solution Explorer**.  
  
### To add references  
  
1.  In **Solution Explorer**, right-click your project's name and then click **Add Reference**. The **Add Reference** dialog box appears.  
  
2.  On the **Assemblies**  page, select **Microsoft.Office.Interop.Word** in the **Component Name** list, and then hold down the CTRL key and select **Microsoft.Office.Interop.Excel**.  If you do not see the assemblies, you may need to ensure they are installed and displayed (see [How to: Install Office Primary Interop Assemblies](/visualstudio/vsto/how-to-install-office-primary-interop-assemblies))  
  
3.  Click **OK**.  
  
### To add necessary using directives  
  
1.  In **Solution Explorer**, right-click the **Program.cs** file and then click **View Code**.  
  
2.  Add the following `using` directives to the top of the code file.  
  
     [!code-csharp[csProgGuideOfficeHowTo#1](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_1.cs)]  
  
### To create a list of bank accounts  
  
1.  Paste the following class definition into **Program.cs**, under the `Program` class.  
  
     [!code-csharp[csProgGuideOfficeHowTo#2](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_2.cs)]  
  
2.  Add the following code to the `Main` method to create a `bankAccounts` list that contains two accounts.  
  
     [!code-csharp[csProgGuideOfficeHowTo#3](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_3.cs)]  
  
### To declare a method that exports account information to Excel  
  
1.  Add the following method to the `Program` class to set up an Excel worksheet.  
  
     Method [Add](https://msdn.microsoft.com/library/microsoft.office.interop.excel.workbooks.add.aspx) has an optional parameter for specifying a particular template. Optional parameters, new in [!INCLUDE[csharp_dev10_long](~/includes/csharp-dev10-long-md.md)], enable you to omit the argument for that parameter if you want to use the parameter's default value. Because no argument is sent in the following code, `Add` uses the default template and creates a new workbook. The equivalent statement in earlier versions of C# requires a placeholder argument: `ExcelApp.Workbooks.Add(Type.Missing)`.  
  
     [!code-csharp[csProgGuideOfficeHowTo#4](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_4.cs)]  
  
2.  Add the following code at the end of `DisplayInExcel`. The code inserts values into the first two columns of the first row of the worksheet.  
  
     [!code-csharp[csProgGuideOfficeHowTo#5](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_5.cs)]  
  
3.  Add the following code at the end of `DisplayInExcel`. The `foreach` loop puts the information from the list of accounts into the first two columns of successive rows of the worksheet.  
  
     [!code-csharp[csProgGuideOfficeHowTo#7](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_6.cs)]  
  
4.  Add the following code at the end of `DisplayInExcel` to adjust the column widths to fit the content.  
  
     [!code-csharp[csProgGuideOfficeHowTo#13](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_7.cs)]  
  
     Earlier versions of C# require explicit casting for these operations because `ExcelApp.Columns[1]` returns an `Object`, and `AutoFit` is an Excel [Range](https://msdn.microsoft.com/library/microsoft.office.interop.excel.range.aspx) method. The following lines show the casting.  
  
     [!code-csharp[csProgGuideOfficeHowTo#14](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_8.cs)]  
  
     [!INCLUDE[csharp_dev10_long](~/includes/csharp-dev10-long-md.md)], and later versions, converts the returned `Object` to `dynamic` automatically if the assembly is referenced by the [/link](../../../csharp/language-reference/compiler-options/link-compiler-option.md) compiler option or, equivalently, if the Excel **Embed Interop Types** property is set to true. True is the default value for this property.  
  
### To run the project  
  
1.  Add the following line at the end of `Main`.  
  
     [!code-csharp[csProgGuideOfficeHowTo#8](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_9.cs)]  
  
2.  Press CTRL+F5.  
  
     An Excel worksheet appears that contains the data from the two accounts.  
  
### To add a Word document  
  
1.  To illustrate additional ways in which [!INCLUDE[csharp_dev10_long](~/includes/csharp-dev10-long-md.md)], and later versions, enhances Office programming, the following code opens a Word application and creates an icon that links to the Excel worksheet.  
  
     Paste method `CreateIconInWordDoc`, provided later in this step, into the `Program` class. `CreateIconInWordDoc` uses named and optional arguments to reduce the complexity of the method calls to [Add](https://msdn.microsoft.com/library/microsoft.office.interop.word.documents.add.aspx) and [PasteSpecial](https://msdn.microsoft.com/library/microsoft.office.interop.word.selection.pastespecial.aspx). These calls incorporate two other new features introduced in [!INCLUDE[csharp_dev10_long](~/includes/csharp-dev10-long-md.md)] that simplify calls to COM methods that have reference parameters. First, you can send arguments to the reference parameters as if they were value parameters. That is, you can send values directly, without creating a variable for each reference parameter. The compiler generates temporary variables to hold the argument values, and discards the variables when you return from the call. Second, you can omit the `ref` keyword in the argument list.  
  
     The `Add` method has four reference parameters, all of which are optional. In [!INCLUDE[csharp_dev10_long](~/includes/csharp-dev10-long-md.md)], or later versions, you can omit arguments for any or all of the parameters if you want to use their default values. In [!INCLUDE[csharp_orcas_long](~/includes/csharp-orcas-long-md.md)] and earlier versions, an argument must be provided for each parameter, and the argument must be a variable because the parameters are reference parameters.  
  
     The `PasteSpecial` method inserts the contents of the Clipboard. The method has seven reference parameters, all of which are optional. The following code specifies arguments for two of them: `Link`, to create a link to the source of the Clipboard contents, and `DisplayAsIcon`, to display the link as an icon. In [!INCLUDE[csharp_dev10_long](~/includes/csharp-dev10-long-md.md)], you can use named arguments for those two and omit the others. Although these are reference parameters, you do not have to use the `ref` keyword, or to create variables to send in as arguments. You can send the values directly. In [!INCLUDE[csharp_orcas_long](~/includes/csharp-orcas-long-md.md)] and earlier versions, you must send a variable argument for each reference parameter.  
  
     [!code-csharp[csProgGuideOfficeHowTo#9](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_10.cs)]  
  
     In [!INCLUDE[csharp_orcas_long](~/includes/csharp-orcas-long-md.md)] or earlier versions of the language, the following more complex code is required.  
  
     [!code-csharp[csProgGuideOfficeHowTo#10](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_11.cs)]  
  
2.  Add the following statement at the end of `Main`.  
  
     [!code-csharp[csProgGuideOfficeHowTo#11](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_12.cs)]  
  
3.  Add the following statement at the end of `DisplayInExcel`. The `Copy` method adds the worksheet to the Clipboard.  
  
     [!code-csharp[csProgGuideOfficeHowTo#12](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_13.cs)]  
  
4.  Press CTRL+F5.  
  
     A Word document appears that contains an icon. Double-click the icon to bring the worksheet to the foreground.  
  
### To set the Embed Interop Types property  
  
1.  Additional enhancements are possible when you call a COM type that does not require a primary interop assembly (PIA) at run time. Removing the dependency on PIAs results in version independence and easier deployment. For more information about the advantages of programming without PIAs, see [Walkthrough: Embedding Types from Managed Assemblies](http://msdn.microsoft.com/library/b28ec92c-1867-4847-95c0-61adfe095e21).  
  
     In addition, programming is easier because the types that are required and returned by COM methods can be represented by using the type `dynamic` instead of `Object`. Variables that have type `dynamic` are not evaluated until run time, which eliminates the need for explicit casting. For more information, see [Using Type dynamic](../../../csharp/programming-guide/types/using-type-dynamic.md).  
  
     In [!INCLUDE[csharp_dev10_long](~/includes/csharp-dev10-long-md.md)], embedding type information instead of using PIAs is default behavior. Because of that default, several of the previous examples are simplified because explicit casting is not required. For example, the declaration of `worksheet` in `DisplayInExcel` is written as `Excel._Worksheet workSheet = excelApp.ActiveSheet` rather than `Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet`. The calls to `AutoFit` in the same method also would require explicit casting without the default, because `ExcelApp.Columns[1]` returns an `Object`, and `AutoFit` is an Excel  method. The following code shows the casting.  
  
     [!code-csharp[csProgGuideOfficeHowTo#14](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_8.cs)]  
  
2.  To change the default and use PIAs instead of embedding type information, expand the **References** node in **Solution Explorer** and then select **Microsoft.Office.Interop.Excel** or **Microsoft.Office.Interop.Word**.  
  
3.  If you cannot see the **Properties** window, press **F4**.  
  
4.  Find **Embed Interop Types** in the list of properties, and change its value to **False**. Equivalently, you can compile by using the [/reference](../../../csharp/language-reference/compiler-options/reference-compiler-option.md) compiler option instead of [/link](../../../csharp/language-reference/compiler-options/link-compiler-option.md) at a command prompt.  
  
### To add additional formatting to the table  
  
1.  Replace the two calls to `AutoFit` in `DisplayInExcel` with the following statement.  
  
     [!code-csharp[csProgGuideOfficeHowTo#15](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_14.cs)]  
  
     The [AutoFormat](https://msdn.microsoft.com/library/microsoft.office.interop.excel.range.autoformat.aspx) method has seven value parameters, all of which are optional. Named and optional arguments enable you to provide arguments for none, some, or all of them. In the previous statement, an argument is supplied for only one of the parameters, `Format`. Because `Format` is the first parameter in the parameter list, you do not have to provide the parameter name. However, the statement might be easier to understand if the parameter name is included, as is shown in the following code.  
  
     [!code-csharp[csProgGuideOfficeHowTo#16](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_15.cs)]  
  
2.  Press CTRL+F5 to see the result. Other formats are listed in the [XlRangeAutoFormat](https://msdn.microsoft.com/library/microsoft.office.interop.excel.xlrangeautoformat.aspx) enumeration.  
  
3.  Compare the statement in step 1 with the following code, which shows the arguments that are required in [!INCLUDE[csharp_orcas_long](~/includes/csharp-orcas-long-md.md)] or earlier versions.  
  
     [!code-csharp[csProgGuideOfficeHowTo#17](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_16.cs)]  
  
## Example  
 The following code shows the complete example.  
  
 [!code-csharp[csProgGuideOfficeHowTo#18](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-access-office-onterop-objects_17.cs)]  
  
## See Also  
 <xref:System.Type.Missing?displayProperty=nameWithType>  
 [dynamic](../../../csharp/language-reference/keywords/dynamic.md)  
 [Using Type dynamic](../../../csharp/programming-guide/types/using-type-dynamic.md)  
 [Named and Optional Arguments](../../../csharp/programming-guide/classes-and-structs/named-and-optional-arguments.md)  
 [How to: Use Named and Optional Arguments in Office Programming](../../../csharp/programming-guide/classes-and-structs/how-to-use-named-and-optional-arguments-in-office-programming.md)
