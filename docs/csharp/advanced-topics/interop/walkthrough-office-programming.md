---
title: "Walkthrough: Office Programming - C#"
description: Learn about the features Visual Studio offers that improve Microsoft Office programming. 
ms.date: 02/15/2023
ms.topic: tutorial
dev_langs:
  - "csharp"
helpviewer_keywords:
  - "Office programming [C#]"
---
# Walkthrough: Office Programming in C\#

C# offers features that improve Microsoft Office programming. Helpful C# features include named and optional arguments and return values of type `dynamic`. In COM programming, you can omit the `ref` keyword and gain access to indexed properties.

Both languages enable embedding of type information, which allows deployment of assemblies that interact with COM components without deploying primary interop assemblies (PIAs) to the user's computer. For more information, see [Walkthrough: Embedding Types from Managed Assemblies](../../../standard/assembly/embed-types-visual-studio.md).

This walkthrough demonstrates these features in the context of Office programming, but many of these features are also useful in general programming. In the walkthrough, you use an Excel Add-in application to create an Excel workbook. Next, you create a Word document that contains a link to the workbook. Finally, you see how to enable and disable the PIA dependency.

> [!IMPORTANT]
> VSTO relies on the [.NET Framework](/dotnet/framework/get-started/overview). COM add-ins can also be written with the .NET Framework. Office Add-ins cannot be created with [.NET Core and .NET 5+](/dotnet/core/dotnet-five), the latest versions of .NET. This is because .NET Core/.NET 5+ cannot work together with .NET Framework in the same process and may lead to add-in load failures. You can continue to use .NET Framework to write VSTO and COM add-ins for Office. Microsoft will not be updating VSTO or the COM add-in platform to use .NET Core or .NET 5+. You can take advantage of .NET Core and .NET 5+, including ASP.NET Core, to create the server side of [Office Web Add-ins](/office/dev/add-ins/overview/office-add-ins).

## Prerequisites

You must have Microsoft Office Excel and Microsoft Office Word installed on your computer to complete this walkthrough.

[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]

## Set up an Excel Add-in application

1. Start Visual Studio.
1. On the **File** menu, point to **New**, and then select **Project**.
1. In the **Installed Templates** pane, expand **C#**, expand **Office**, and then select the version year of the Office product.
1. In the **Templates** pane, select **Excel \<version> Add-in**.
1. Look at the top of the **Templates** pane to make sure that **.NET Framework 4**, or a later version, appears in the **Target Framework** box.
1. Type a name for your project in the **Name** box, if you want to.
1. Select **OK**.
1. The new project appears in **Solution Explorer**.

## Add references

1. In **Solution Explorer**, right-click your project's name and then select **Add Reference**. The **Add Reference** dialog box appears.
1. On the **Assemblies** tab, select **Microsoft.Office.Interop.Excel**, version `<version>.0.0.0` (for a key to the Office product version numbers, see [Microsoft Versions](https://en.wikipedia.org/wiki/Microsoft_Office#Versions)), in the **Component Name** list, and then hold down the CTRL key and select **Microsoft.Office.Interop.Word**, `version <version>.0.0.0`. If you don't see the assemblies, you may need to install them (see [How to: Install Office Primary Interop Assemblies](/visualstudio/vsto/how-to-install-office-primary-interop-assemblies)).
1. Select **OK**.

## Add necessary Imports statements or using directives

In **Solution Explorer**, right-click the **ThisAddIn.cs** file and then select **View Code**. Add the following `using` directives (C#) to the top of the code file if they aren't already present.

:::code language="csharp" source="./snippets/OfficeWalkthrough/ThisAddIn.cs" id="Usings":::

## Create a list of bank accounts

In **Solution Explorer**, right-click your project's name, select **Add**, and then select **Class**. Name the class Account.cs. Select **Add**. Replace the definition of the `Account` class with the following code. The class definitions use *auto-implemented properties*.

:::code language="csharp" source="./snippets/OfficeWalkthrough/account.cs" id="AccountClass":::

To create a `bankAccounts` list that contains two accounts, add the following code to the `ThisAddIn_Startup` method in *ThisAddIn.cs*. The list declarations use *collection initializers*.

:::code language="csharp" source="./snippets/OfficeWalkthrough/ThisAddIn.cs" id="CreateAccount":::

## Export data to Excel

In the same file, add the following method to the `ThisAddIn` class. The method sets up an Excel workbook and exports data to it.

:::code language="csharp" source="./snippets/OfficeWalkthrough/ThisAddIn.cs" id="Display":::

- Method [Add](<xref:Microsoft.Office.Interop.Excel.Workbooks.Add%2A>) has an *optional parameter* for specifying a particular template. Optional parameters enable you to omit the argument for that parameter if you want to use the parameter's default value. Because the previous example has no arguments, `Add` uses the default template and creates a new workbook. The equivalent statement in earlier versions of C# requires a placeholder argument: `excelApp.Workbooks.Add(Type.Missing)`. For more information, see [Named and Optional Arguments](../../programming-guide/classes-and-structs/named-and-optional-arguments.md).
- The `Range` and `Offset` properties of the [Range](<xref:Microsoft.Office.Interop.Excel.Range>) object use the *indexed properties* feature. This feature enables you to consume these properties from COM types by using the following typical C# syntax. Indexed properties also enable you to use the `Value` property of the `Range` object, eliminating the need to use the `Value2` property. The `Value` property is indexed, but the index is optional. Optional arguments and indexed properties work together in the following example.

:::code language="csharp" source="./snippets/OfficeWalkthrough/ThisAddIn.cs" id="IndexedProperties":::

You can't create indexed properties of your own. The feature only supports consumption of existing indexed properties.

Add the following code at the end of `DisplayInExcel` to adjust the column widths to fit the content.

:::code language="csharp" source="./snippets/OfficeWalkthrough/ThisAddIn.cs" id="AutoFit":::

These additions demonstrate another feature in C#: treating `Object` values returned from COM hosts such as Office as if they have type [dynamic](../../language-reference/builtin-types/reference-types.md). COM objects are treated as `dynamic` automatically when **Embed Interop Types** has its default value, `True`, or, equivalently, when you reference the assembly with the [**EmbedInteropTypes**](../../language-reference/compiler-options/inputs.md#embedinteroptypes) compiler option. For more information about embedding interop types, see procedures "To find the PIA reference" and "To restore the PIA dependency" later in this article. For more information about `dynamic`, see [dynamic](../../language-reference/builtin-types/reference-types.md) or [Using Type dynamic](using-type-dynamic.md).

## Invoke DisplayInExcel

Add the following code at the end of the `ThisAddIn_StartUp` method. The call to `DisplayInExcel` contains two arguments. The first argument is the name of the list of accounts processed. The second argument is a multiline lambda expression defining how to process the data. The `ID` and `balance` values for each account are displayed in adjacent cells, and the row is displayed in red if the balance is less than zero. For more information, see [Lambda Expressions](../../language-reference/operators/lambda-expressions.md).

:::code language="csharp" source="./snippets/OfficeWalkthrough/ThisAddIn.cs" id="CallDisplay":::

To run the program, press F5. An Excel worksheet appears that contains the data from the accounts.

## Add a Word document

Add the following code at the end of the `ThisAddIn_StartUp` method to create a Word document that contains a link to the Excel workbook.

:::code language="csharp" source="./snippets/OfficeWalkthrough/ThisAddIn.cs" id="PasteIntoWord":::

This code demonstrates several of the features in C#: the ability to omit the `ref` keyword in COM programming, named arguments, and optional arguments.The [PasteSpecial](<xref:Microsoft.Office.Interop.Word.Selection.PasteSpecial%2A>) method has seven parameters, all of which are optional reference parameters. Named and optional arguments enable you to designate the parameters you want to access by name and to send arguments to only those parameters. In this example, arguments indicate creating a link to the workbook on the Clipboard (parameter `Link`) and displaying that the link in the Word document as an icon (parameter `DisplayAsIcon`). C# also enables you to omit the `ref` keyword for these arguments.

## Run the application

Press F5 to run the application. Excel starts and displays a table that contains the information from the two accounts in `bankAccounts`. Then a Word document appears that contains a link to the Excel table.

## Clean up the completed project

In Visual Studio, select **Clean Solution** on the **Build** menu. Otherwise, the add-in runs every time that you open Excel on your computer.

## Find the PIA reference

1. Run the application again, but don't select **Clean Solution**.
1. Select the **Start**. Locate **Microsoft Visual Studio \<version>** and open a developer command prompt.
1. Type `ildasm` in the Developer Command Prompt for Visual Studio window, and then press ENTER. The IL DASM window appears.
1. On the **File** menu in the IL DASM window, select **File** > **Open**. Double-click **Visual Studio \<version>**, and then double-click **Projects**. Open the folder for your project, and look in the bin/Debug folder for *your project name*.dll. Double-click *your project name*.dll. A new window displays your project's attributes, in addition to references to other modules and assemblies. The assembly includes the namespaces `Microsoft.Office.Interop.Excel` and `Microsoft.Office.Interop.Word`. By default in Visual Studio, the compiler imports the types you need from a referenced PIA into your assembly. For more information, see [How to: View Assembly Contents](../../../standard/assembly/view-contents.md).
1. Double-click the **MANIFEST** icon. A window appears that contains a list of assemblies that contain items referenced by the project. `Microsoft.Office.Interop.Excel` and `Microsoft.Office.Interop.Word` aren't in the list. Because you imported the types your project needs into your assembly, you aren't required to install references to a PIA. Importing the types into your assembly makes deployment easier. The PIAs don't have to be present on the user's computer. An application doesn't require deployment of a specific version of a PIA. Applications can work with multiple versions of Office, provided that the necessary APIs exist in all versions. Because deployment of PIAs is no longer necessary, you can create an application in advanced scenarios that works with multiple versions of Office, including earlier versions. Your code can't use any APIs that aren't available in the version of Office you're working with. It isn't always clear whether a particular API was available in an earlier version. Working with earlier versions of Office isn't recommended.
1. Close the manifest window and the assembly window.

## Restore the PIA dependency

1. In **Solution Explorer**, select the **Show All Files** button. Expand the **References** folder and select **Microsoft.Office.Interop.Excel**. Press F4 to display the **Properties** window.
1. In the **Properties** window, change the **Embed Interop Types** property from **True** to **False**.
1. Repeat steps 1 and 2 in this procedure for `Microsoft.Office.Interop.Word`.
1. In C#, comment out the two calls to `Autofit` at the end of the `DisplayInExcel` method.
1. Press F5 to verify that the project still runs correctly.
1. Repeat steps 1-3 from the previous procedure to open the assembly window. Notice that `Microsoft.Office.Interop.Word` and `Microsoft.Office.Interop.Excel` are no longer in the list of embedded assemblies.
1. Double-click the **MANIFEST** icon and scroll through the list of referenced assemblies. Both `Microsoft.Office.Interop.Word` and `Microsoft.Office.Interop.Excel` are in the list. Because the application references the Excel and Word PIAs, and the **Embed Interop Types** property is **False**, both assemblies must exist on the end user's computer.
1. In Visual Studio, select **Clean Solution** on the **Build** menu to clean up the completed project.

## See also

- [Auto-Implemented Properties (C#)](../../programming-guide/classes-and-structs/auto-implemented-properties.md)
- [Object and Collection Initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md)
- [Named and Optional Arguments](../../programming-guide/classes-and-structs/named-and-optional-arguments.md)
- [dynamic](../../language-reference/builtin-types/reference-types.md)
- [Using Type dynamic](using-type-dynamic.md)
- [Lambda Expressions (C#)](../../language-reference/operators/lambda-expressions.md)
- [Walkthrough: Embedding Type Information from Microsoft Office Assemblies in Visual Studio](/previous-versions/visualstudio/visual-studio-2013/ee317478(v=vs.120))
- [Walkthrough: Embedding Types from Managed Assemblies](../../../standard/assembly/embed-types-visual-studio.md)
- [Walkthrough: Creating Your First VSTO Add-in for Excel](/visualstudio/vsto/walkthrough-creating-your-first-vsto-add-in-for-excel)
