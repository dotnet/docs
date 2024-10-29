---
title: "Walkthrough: Office Programming - Visual Basic"
description: Learn about the features Visual Studio offers in Visual Basic that improve Microsoft Office programming.
ms.date: 02/15/2023
ms.topic: tutorial
dev_langs:
  - "vb"
helpviewer_keywords:
  - "Office programming [Visual Basic]"
---
# Walkthrough: Office Programming in Visual Basic

Visual Studio offers features in Visual Basic that improve Microsoft Office programming. Features in Visual Basic include automatically implemented properties, statements in lambda expressions, and collection initializers. You can embed type information, which allows deployment of assemblies that interact with COM components without deploying primary interop assemblies (PIAs) to the user's computer. For more information, see [Walkthrough: Embedding Types from Managed Assemblies](../../../standard/assembly/embed-types-visual-studio.md).

This walkthrough demonstrates these features in the context of Office programming, but many of these features are also useful in general programming. In the walkthrough, you use an Excel Add-in application to create an Excel workbook. Next, you create a Word document that contains a link to the workbook. Finally, you see how to enable and disable the PIA dependency.

## Prerequisites

You must have Microsoft Office Excel and Microsoft Office Word installed on your computer to complete this walkthrough.

[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]

## Set up an Excel Add-in application

1. Start Visual Studio.

2. On the **File** menu, point to **New**, and then click **Project**.

3. In the **Installed Templates** pane, expand **Visual Basic**, expand **Office**, and then click the version year of the Office product.

4. In the **Templates** pane, click **Excel \<version> Add-in**.

5. Look at the top of the **Templates** pane to make sure that **.NET Framework 4**, or a later version, appears in the **Target Framework** box.

6. Type a name for your project in the **Name** box, if you want to.

7. Click **OK**.

8. The new project appears in **Solution Explorer**.

## Add references

1. In **Solution Explorer**, right-click your project's name and then click **Add Reference**. The **Add Reference** dialog box appears.

2. On the **Assemblies** tab, select **Microsoft.Office.Interop.Excel**, version `<version>.0.0.0` (for a key to the Office product version numbers, see [Microsoft Versions](https://en.wikipedia.org/wiki/Microsoft_Office#Versions)), in the **Component Name** list, and then hold down the CTRL key and select **Microsoft.Office.Interop.Word**, `version <version>.0.0.0`. If you do not see the assemblies, you may need to ensure they are installed and displayed (see [How to: Install Office Primary Interop Assemblies](/visualstudio/vsto/how-to-install-office-primary-interop-assemblies)).

3. Click **OK**.

## Add necessary Imports statements or using directives

1. In **Solution Explorer**, right-click the **ThisAddIn.vb** or **ThisAddIn.cs** file and then click **View Code**.

2. Add the following `Imports` statements to the top of the code file if they are not already present.

     [!code-vb[csOfficeWalkthrough#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/csofficewalkthrough/vb/thisaddin.vb#1)]

## Create a list of bank accounts

1. In **Solution Explorer**, right-click your project's name, click **Add**, and then click **Class**. Name the class Account.vb. Click **Add**.

2. Replace the definition of the `Account` class with the following code. The class definitions use *automatically implemented properties*. For more information, see [Automatically implemented properties](../../../visual-basic/programming-guide/language-features/procedures/auto-implemented-properties.md).

     [!code-vb[csOfficeWalkthrough#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/csofficewalkthrough/vb/account.vb#2)]

3. To create a `bankAccounts` list that contains two accounts, add the following code to the `ThisAddIn_Startup` method in *ThisAddIn.vb*. The list declarations use *collection initializers*. For more information, see [Collection Initializers](../../../visual-basic/programming-guide/language-features/collection-initializers/index.md).

     [!code-vb[csOfficeWalkthrough#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/csofficewalkthrough/vb/thisaddin.vb#3)]

## Export data to Excel

1. In the same file, add the following method to the `ThisAddIn` class. The method sets up an Excel workbook and exports data to it.

     [!code-vb[csOfficeWalkthrough#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/csofficewalkthrough/vb/thisaddin.vb#4)]

    - Method [Add](<xref:Microsoft.Office.Interop.Excel.Workbooks.Add%2A>) has an *optional parameter* for specifying a particular template. Optional parameters enable you to omit the argument for that parameter if you want to use the parameter's default value. Because no argument is sent in the previous example, `Add` uses the default template and creates a new workbook.

    - The `Range` and `Offset` properties of the [Range](<xref:Microsoft.Office.Interop.Excel.Range>) object use the *indexed properties* feature. Indexed properties also enable you to use the `Value` property of the `Range` object, eliminating the need to use the `Value2` property. The `Value` property is indexed, but the index is optional. Optional arguments and indexed properties work together in the following example.

2. Add the following code at the end of `DisplayInExcel` to adjust the column widths to fit the content.

     [!code-vb[csOfficeWalkthrough#7](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/csofficewalkthrough/vb/thisaddin.vb#7)]

     For more information about embedding interop types, see procedures "To find the PIA reference" and "To restore the PIA dependency" later in this article.

## Invoke DisplayInExcel

1. Add the following code at the end of the `ThisAddIn_StartUp` method. The call to `DisplayInExcel` contains two arguments. The first argument is the name of the list of accounts to be processed. The second argument is a multiline lambda expression that defines how the data is to be processed. The `ID` and `balance` values for each account are displayed in adjacent cells, and the row is displayed in red if the balance is less than zero.

     [!code-vb[csOfficeWalkthrough#9](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/csofficewalkthrough/vb/thisaddin.vb#9)]

2. To run the program, press F5. An Excel worksheet appears that contains the data from the accounts.

## Add a Word document

1. Add the following code at the end of the `ThisAddIn_StartUp` method to create a Word document that contains a link to the Excel workbook.

     [!code-vb[csOfficeWalkthrough#10](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/csofficewalkthrough/vb/thisaddin.vb#10)]

     The [PasteSpecial](<xref:Microsoft.Office.Interop.Word.Selection.PasteSpecial%2A>) method has seven parameters, all of which are defined as optional reference parameters. Named and optional arguments enable you to designate the parameters you want to access by name and to send arguments to only those parameters. In this example, arguments are sent to indicate that a link to the workbook on the Clipboard should be created (parameter `Link`) and that the link is to be displayed in the Word document as an icon (parameter `DisplayAsIcon`).

## Run the application

1. Press F5 to run the application. Excel starts and displays a table that contains the information from the two accounts in `bankAccounts`. Then a Word document appears that contains a link to the Excel table.

## Clean up the completed project

1. In Visual Studio, click **Clean Solution** on the **Build** menu. Otherwise, the add-in will run every time that you open Excel on your computer.

## Find the PIA reference

1. Run the application again, but do not click **Clean Solution**.

2. Select the **Start**. Locate **Microsoft Visual Studio \<version>** and open a developer command prompt.

3. Type `ildasm` in the Developer Command Prompt for Visual Studio window, and then press <kbd>Enter</kbd>. The IL DASM window appears.

4. On the **File** menu in the IL DASM window, select **File** > **Open**. Double-click **Visual Studio \<version>**, and then double-click **Projects**. Open the folder for your project, and look in the bin/Debug folder for *your project name*.dll. Double-click *your project name*.dll. A new window displays your project's attributes, in addition to references to other modules and assemblies. Note that namespaces `Microsoft.Office.Interop.Excel` and `Microsoft.Office.Interop.Word` are included in the assembly. By default in Visual Studio, the compiler imports the types you need from a referenced PIA into your assembly.

     For more information, see [How to: View Assembly Contents](../../../standard/assembly/view-contents.md).

5. Double-click the **MANIFEST** icon. A window appears that contains a list of assemblies that contain items referenced by the project. `Microsoft.Office.Interop.Excel` and `Microsoft.Office.Interop.Word` are not included in the list. Because the types your project needs have been imported into your assembly, references to a PIA are not required. This makes deployment easier. The PIAs do not have to be present on the user's computer, and because an application does not require deployment of a specific version of a PIA, applications can be designed to work with multiple versions of Office, provided that the necessary APIs exist in all versions.

     Because deployment of PIAs is no longer necessary, you can create an application in advanced scenarios that works with multiple versions of Office, including earlier versions. However, this works only if your code does not use any APIs that are not available in the version of Office you are working with. It is not always clear whether a particular API was available in an earlier version, and for that reason working with earlier versions of Office is not recommended.

    > [!NOTE]
    > Office did not publish PIAs before Office 2003. Therefore, the only way to generate an interop assembly for Office 2002 or earlier versions is by importing the COM reference.

6. Close the manifest window and the assembly window.

## Restore the PIA dependency

1. In **Solution Explorer**, click the **Show All Files** button. Expand the **References** folder and select **Microsoft.Office.Interop.Excel**. Press F4 to display the **Properties** window.
1. In the **Properties** window, change the **Embed Interop Types** property from **True** to **False**.
1. Repeat steps 1 and 2 in this procedure for `Microsoft.Office.Interop.Word`.
1. Press F5 to verify that the project still runs correctly.
1. Repeat steps 1-3 from the previous procedure to open the assembly window. Notice that `Microsoft.Office.Interop.Word` and `Microsoft.Office.Interop.Excel` are no longer in the list of embedded assemblies.
1. Double-click the **MANIFEST** icon and scroll through the list of referenced assemblies. Both `Microsoft.Office.Interop.Word` and `Microsoft.Office.Interop.Excel` are in the list. Because the application references the Excel and Word PIAs, and the **Embed Interop Types** property is set to **False**, both assemblies must exist on the end user's computer.
1. In Visual Studio, click **Clean Solution** on the **Build** menu to clean up the completed project.

## See also

- [Automatically implemented properties (Visual Basic)](../language-features/procedures/auto-implemented-properties.md)
- [Collection Initializers](../language-features/collection-initializers/index.md)
- [Optional Parameters](../language-features/procedures/optional-parameters.md)
- [Passing Arguments by Position and by Name](../language-features/procedures/passing-arguments-by-position-and-by-name.md)
- [Early and Late Binding](../language-features/early-late-binding/index.md)
- [Lambda Expressions](..//language-features/procedures/lambda-expressions.md)
- [Walkthrough: Embedding Types from Managed Assemblies](../../../standard/assembly/embed-types-visual-studio.md)
- [Walkthrough: Creating Your First VSTO Add-in for Excel](/visualstudio/vsto/walkthrough-creating-your-first-vsto-add-in-for-excel)
- [COM Interop](index.md)
