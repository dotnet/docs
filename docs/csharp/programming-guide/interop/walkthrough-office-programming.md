---
title: "Walkthrough: Office Programming (C# and Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Office, programming in Visual Basic and C#"
  - "Office programming [C#]"
  - "Office programming [Visual Basic]"
ms.assetid: 519cff31-f80b-4f0e-a56b-26358d0f8c51
author: "BillWagner"
ms.author: "wiwagn"
---
# Walkthrough: Office Programming (C# and Visual Basic)
Visual Studio offers features in C# and Visual Basic that improve Microsoft Office programming. Helpful C# features include named and optional arguments and return values of type `dynamic`. In COM programming, you can omit the `ref` keyword and gain access to indexed properties. Features in Visual Basic include auto-implemented properties, statements in lambda expressions, and collection initializers.

Both languages enable embedding of type information, which allows deployment of assemblies that interact with COM components without deploying primary interop assemblies (PIAs) to the user's computer. For more information, see [Walkthrough: Embedding Types from Managed Assemblies](https://msdn.microsoft.com/library/b28ec92c-1867-4847-95c0-61adfe095e21).  
  
This walkthrough demonstrates these features in the context of Office programming, but many of these features are also useful in general programming. In the walkthrough, you use an Excel Add-in application to create an Excel workbook. Next, you create a Word document that contains a link to the workbook. Finally, you see how to enable and disable the PIA dependency.  
  
## Prerequisites  

You must have Microsoft Office Excel and Microsoft Office Word installed on your computer to complete this walkthrough.  
  
 If you are using an operating system that is older than [!INCLUDE[windowsver](~/includes/windowsver-md.md)], make sure that [!INCLUDE[dnprdnlong](~/includes/dnprdnlong-md.md)] is installed.  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
### To set up an Excel Add-in application  
  
1.  Start Visual Studio.  
  
2.  On the **File** menu, point to **New**, and then click **Project**.  
  
3.  In the **Installed Templates** pane, expand **Visual Basic** or **Visual C#**, expand **Office**, and then click the version year of the Office product.  
  
4.  In the **Templates** pane, click **Excel \<version> Add-in**.  
  
5.  Look at the top of the **Templates** pane to make sure that **.NET Framework 4**, or a later version, appears in the **Target Framework** box.  
  
6.  Type a name for your project in the **Name** box, if you want to.  
  
7.  Click **OK**.  
  
8.  The new project appears in **Solution Explorer**.  
  
### To add references  
  
1.  In **Solution Explorer**, right-click your project's name and then click **Add Reference**. The **Add Reference** dialog box appears.  
  
2.  On the **Assemblies** tab, select **Microsoft.Office.Interop.Excel**, version `<version>.0.0.0` (for a key to the Office product version numbers, see [Microsoft Versions](https://en.wikipedia.org/wiki/Microsoft_Office#Versions)), in the **Component Name** list, and then hold down the CTRL key and select **Microsoft.Office.Interop.Word**, `version <version>.0.0.0`. If you do not see the assemblies, you may need to ensure they are installed and displayed (see [How to: Install Office Primary Interop Assemblies](/visualstudio/vsto/how-to-install-office-primary-interop-assemblies)).  
  
3.  Click **OK**.  
  
### To add necessary Imports statements or using directives  
  
1.  In **Solution Explorer**, right-click the **ThisAddIn.vb** or **ThisAddIn.cs** file and then click **View Code**.  
  
2.  Add the following `Imports` statements (Visual Basic) or `using` directives (C#) to the top of the code file if they are not already present.  
  
     [!code-csharp[csOfficeWalkthrough#1](../../../csharp/programming-guide/interop/codesnippet/CSharp/walkthrough-office-programming_1.cs)]

     [!code-vb[csOfficeWalkthrough#1](../../../csharp/programming-guide/interop/codesnippet/VisualBasic/walkthrough-office-programming_1.vb)]
  
### To create a list of bank accounts  
  
1.  In **Solution Explorer**, right-click your project's name, click **Add**, and then click **Class**. Name the class Account.vb if you are using Visual Basic or Account.cs if you are using C#. Click **Add**.  
  
2.  Replace the definition of the `Account` class with the following code. The class definitions use *auto-implemented properties*. For more information, see [Auto-Implemented Properties](../../../visual-basic/programming-guide/language-features/procedures/auto-implemented-properties.md).  
  
     [!code-csharp[csOfficeWalkthrough#2](../../../csharp/programming-guide/interop/codesnippet/CSharp/walkthrough-office-programming_2.cs)]

     [!code-vb[csOfficeWalkthrough#2](../../../csharp/programming-guide/interop/codesnippet/VisualBasic/walkthrough-office-programming_2.vb)]  
  
3.  To create a `bankAccounts` list that contains two accounts, add the following code to the `ThisAddIn_Startup` method in *ThisAddIn.vb* or *ThisAddIn.cs*. The list declarations use *collection initializers*. For more information, see [Collection Initializers](../../../visual-basic/programming-guide/language-features/collection-initializers/index.md).  
  
     [!code-csharp[csOfficeWalkthrough#3](../../../csharp/programming-guide/interop/codesnippet/CSharp/walkthrough-office-programming_3.cs)]

     [!code-vb[csOfficeWalkthrough#3](../../../csharp/programming-guide/interop/codesnippet/VisualBasic/walkthrough-office-programming_3.vb)]  
  
### To export data to Excel  
  
1.  In the same file, add the following method to the `ThisAddIn` class. The method sets up an Excel workbook and exports data to it.  
  
     [!code-csharp[csOfficeWalkthrough#4](../../../csharp/programming-guide/interop/codesnippet/CSharp/walkthrough-office-programming_4.cs)]

     [!code-vb[csOfficeWalkthrough#4](../../../csharp/programming-guide/interop/codesnippet/VisualBasic/walkthrough-office-programming_4.vb)]  
  
     Two new C# features are used in this method. Both of these features already exist in Visual Basic.  
  
    -   Method [Add](https://msdn.microsoft.com/library/microsoft.office.interop.excel.workbooks.add.aspx) has an *optional parameter* for specifying a particular template. Optional parameters, new in [!INCLUDE[csharp_dev10_long](~/includes/csharp-dev10-long-md.md)], enable you to omit the argument for that parameter if you want to use the parameter's default value. Because no argument is sent in the previous example, `Add` uses the default template and creates a new workbook. The equivalent statement in earlier versions of C# requires a placeholder argument: `excelApp.Workbooks.Add(Type.Missing)`.  
  
         For more information, see [Named and Optional Arguments](../../../csharp/programming-guide/classes-and-structs/named-and-optional-arguments.md).  
  
    -   The `Range` and `Offset` properties of the [Range](https://msdn.microsoft.com/library/microsoft.office.interop.excel.range.aspx) object use the *indexed properties* feature. This feature enables you to consume these properties from COM types by using the following typical C# syntax. Indexed properties also enable you to use the `Value` property of the `Range` object, eliminating the need to use the `Value2` property. The `Value` property is indexed, but the index is optional. Optional arguments and indexed properties work together in the following example.  
  
         [!code-csharp[csOfficeWalkthrough#5](../../../csharp/programming-guide/interop/codesnippet/CSharp/walkthrough-office-programming_5.cs)]  
  
         In earlier versions of the language, the following special syntax is required.  
  
         [!code-csharp[csOfficeWalkthrough#6](../../../csharp/programming-guide/interop/codesnippet/CSharp/walkthrough-office-programming_6.cs)]  
  
         You cannot create indexed properties of your own. The feature only supports consumption of existing indexed properties.  
  
         For more information, see [How to: Use Indexed Properties in COM Interop Programming](../../../csharp/programming-guide/interop/how-to-use-indexed-properties-in-com-interop-rogramming.md).  
  
2.  Add the following code at the end of `DisplayInExcel` to adjust the column widths to fit the content.  
  
     [!code-csharp[csOfficeWalkthrough#7](../../../csharp/programming-guide/interop/codesnippet/CSharp/walkthrough-office-programming_7.cs)]

     [!code-vb[csOfficeWalkthrough#7](../../../csharp/programming-guide/interop/codesnippet/VisualBasic/walkthrough-office-programming_7.vb)]  
  
     These additions demonstrate another feature in C#: treating `Object` values returned from COM hosts such as Office as if they have type [dynamic](../../../csharp/language-reference/keywords/dynamic.md). This happens automatically when **Embed Interop Types** is set to its default value, `True`, or, equivalently, when the assembly is referenced by the [/link](../../../csharp/language-reference/compiler-options/link-compiler-option.md) compiler option. Type `dynamic` allows late binding, already available in Visual Basic, and avoids the explicit casting required in Visual C# 2008 and earlier versions of the language.  
  
     For example, `excelApp.Columns[1]` returns an `Object`, and `AutoFit` is an Excel  [Range](https://msdn.microsoft.com/library/microsoft.office.interop.excel.range.aspx) method. Without `dynamic`, you must cast the object returned by `excelApp.Columns[1]` as an instance of `Range` before calling method `AutoFit`.  
  
     [!code-csharp[csOfficeWalkthrough#8](../../../csharp/programming-guide/interop/codesnippet/CSharp/walkthrough-office-programming_8.cs)]  
  
     For more information about embedding interop types, see procedures "To find the PIA reference" and "To restore the PIA dependency" later in this topic. For more information about `dynamic`, see [dynamic](../../../csharp/language-reference/keywords/dynamic.md) or [Using Type dynamic](../../../csharp/programming-guide/types/using-type-dynamic.md).  
  
### To invoke DisplayInExcel  
  
1.  Add the following code at the end of the `ThisAddIn_StartUp` method. The call to `DisplayInExcel` contains two arguments. The first argument is the name of the list of accounts to be processed. The second argument is a multiline lambda expression that defines how the data is to be processed. The `ID` and `balance` values for each account are displayed in adjacent cells, and the row is displayed in red if the balance is less than zero. For more information, see [Lambda Expressions](../../../visual-basic/programming-guide/language-features/procedures/lambda-expressions.md).  
  
     [!code-csharp[csOfficeWalkthrough#9](../../../csharp/programming-guide/interop/codesnippet/CSharp/walkthrough-office-programming_9.cs)]

     [!code-vb[csOfficeWalkthrough#9](../../../csharp/programming-guide/interop/codesnippet/VisualBasic/walkthrough-office-programming_9.vb)]  
  
2.  To run the program, press F5. An Excel worksheet appears that contains the data from the accounts.  
  
### To add a Word document  
  
1.  Add the following code at the end of the `ThisAddIn_StartUp` method to create a Word document that contains a link to the Excel workbook.  
  
     [!code-csharp[csOfficeWalkthrough#10](../../../csharp/programming-guide/interop/codesnippet/CSharp/walkthrough-office-programming_10.cs)]

     [!code-vb[csOfficeWalkthrough#10](../../../csharp/programming-guide/interop/codesnippet/VisualBasic/walkthrough-office-programming_10.vb)]  
  
     This code demonstrates several of the new features in C#: the ability to omit the `ref` keyword in COM programming, named arguments, and optional arguments. These features already exist in Visual Basic. The [PasteSpecial](https://msdn.microsoft.com/library/microsoft.office.interop.word.selection.pastespecial.aspx) method has seven parameters, all of which are defined as optional reference parameters. Named and optional arguments enable you to designate the parameters you want to access by name and to send arguments to only those parameters. In this example, arguments are sent to indicate that a link to the workbook on the Clipboard should be created (parameter `Link`) and that the link is to be displayed in the Word document as an icon (parameter `DisplayAsIcon`). Visual C# also enables you to omit the `ref` keyword for these arguments.
  
### To run the application  
  
1.  Press F5 to run the application. Excel starts and displays a table that contains the information from the two accounts in `bankAccounts`. Then a Word document appears that contains a link to the Excel table.  
  
### To clean up the completed project  
  
1.  In Visual Studio, click **Clean Solution** on the **Build** menu. Otherwise, the add-in will run every time that you open Excel on your computer.  
  
### To find the PIA reference  
  
1.  Run the application again, but do not click **Clean Solution**.  
  
2.  Select the **Start**. Locate **Microsoft Visual Studio \<version>** and open a developer command prompt.  
  
3.  Type `ildasm` in the Visual Studio Command Prompt window, and then press ENTER. The IL DASM window appears.  
  
4.  On the **File** menu in the IL DASM window, select **File** > **Open**. Double-click **Visual Studio \<version>**, and then double-click **Projects**. Open the folder for your project, and look in the bin/Debug folder for *your project name*.dll. Double-click *your project name*.dll. A new window displays your project's attributes, in addition to references to other modules and assemblies. Note that namespaces `Microsoft.Office.Interop.Excel` and `Microsoft.Office.Interop.Word` are included in the assembly. By default in Visual Studio, the compiler imports the types you need from a referenced PIA into your assembly.  
  
     For more information, see [How to: View Assembly Contents](../../../framework/app-domains/how-to-view-assembly-contents.md).  
  
5.  Double-click the **MANIFEST** icon. A window appears that contains a list of assemblies that contain items referenced by the project. `Microsoft.Office.Interop.Excel` and `Microsoft.Office.Interop.Word` are not included in the list. Because the types your project needs have been imported into your assembly, references to a PIA are not required. This makes deployment easier. The PIAs do not have to be present on the user's computer, and because an application does not require deployment of a specific version of a PIA, applications can be designed to work with multiple versions of Office, provided that the necessary APIs exist in all versions.  
  
     Because deployment of PIAs is no longer necessary, you can create an application in advanced scenarios that works with multiple versions of Office, including earlier versions. However, this works only if your code does not use any APIs that are not available in the version of Office you are working with. It is not always clear whether a particular API was available in an earlier version, and for that reason working with earlier versions of Office is not recommended.  
  
    > [!NOTE]
    > Office did not publish PIAs before Office 2003. Therefore, the only way to generate an interop assembly for Office 2002 or earlier versions is by importing the COM reference.  
  
6.  Close the manifest window and the assembly window.  
  
### To restore the PIA dependency  
  
1.  In **Solution Explorer**, click the **Show All Files** button. Expand the **References** folder and select **Microsoft.Office.Interop.Excel**. Press F4 to display the **Properties** window.  
  
2.  In the **Propertie**s window, change the **Embed Interop Types** property from **True** to **False**.  
  
3.  Repeat steps 1 and 2 in this procedure for `Microsoft.Office.Interop.Word`.  
  
4.  In C#, comment out the two calls to `Autofit` at the end of the `DisplayInExcel` method.  
  
5.  Press F5 to verify that the project still runs correctly.  
  
6.  Repeat steps 1-3 from the previous procedure to open the assembly window. Notice that `Microsoft.Office.Interop.Word` and `Microsoft.Office.Interop.Excel` are no longer in the list of embedded assemblies.  
  
7.  Double-click the **MANIFEST** icon and scroll through the list of referenced assemblies. Both `Microsoft.Office.Interop.Word` and `Microsoft.Office.Interop.Excel` are in the list. Because the application references the Excel and Word PIAs, and the **Embed Interop Types** property is set to **False**, both assemblies must exist on the end user's computer.  
  
8.  In Visual Studio, click **Clean Solution** on the **Build** menu to clean up the completed project.  
  
## See Also  
 [Auto-Implemented Properties (Visual Basic)](../../../visual-basic/programming-guide/language-features/procedures/auto-implemented-properties.md)  
 [Auto-Implemented Properties (C#)](../../../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md)  
 [Collection Initializers](../../../visual-basic/programming-guide/language-features/collection-initializers/index.md)  
 [Object and Collection Initializers](../../../csharp/programming-guide/classes-and-structs/object-and-collection-initializers.md)  
 [Optional Parameters](../../../visual-basic/programming-guide/language-features/procedures/optional-parameters.md)  
 [Passing Arguments by Position and by Name](../../../visual-basic/programming-guide/language-features/procedures/passing-arguments-by-position-and-by-name.md)  
 [Named and Optional Arguments](../../../csharp/programming-guide/classes-and-structs/named-and-optional-arguments.md)  
 [Early and Late Binding](../../../visual-basic/programming-guide/language-features/early-late-binding/index.md)  
 [dynamic](../../../csharp/language-reference/keywords/dynamic.md)  
 [Using Type dynamic](../../../csharp/programming-guide/types/using-type-dynamic.md)  
 [Lambda Expressions (Visual Basic)](../../../visual-basic/programming-guide/language-features/procedures/lambda-expressions.md)  
 [Lambda Expressions (C#)](../../../csharp/programming-guide/statements-expressions-operators/lambda-expressions.md)  
 [How to: Use Indexed Properties in COM Interop Programming](../../../csharp/programming-guide/interop/how-to-use-indexed-properties-in-com-interop-rogramming.md)  
 [Walkthrough: Embedding Type Information from Microsoft Office Assemblies](https://msdn.microsoft.com/library/85b55e05-bc5e-4665-b6ae-e1ada9299fd3(v=vs.100))  
 [Walkthrough: Embedding Types from Managed Assemblies](https://msdn.microsoft.com/library/b28ec92c-1867-4847-95c0-61adfe095e21)  
 [Walkthrough: Creating Your First VSTO Add-in for Excel](https://msdn.microsoft.com/library/a855e2be-3ecf-4112-a7f5-ec0f7fad3b5f)  
 [COM Interop](../../../visual-basic/programming-guide/com-interop/index.md)  
 [Interoperability](../../../csharp/programming-guide/interop/index.md)
