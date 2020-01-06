---
title: Create a LINQ to DataSet project in Visual Studio
ms.date: 08/15/2018
ms.assetid: 49ba6cb0-cdd2-4571-aeaa-25bf0f40e9b3
---
# How to: Create a LINQ to DataSet project in Visual Studio

The different types of LINQ projects require certain assembly references and imported namespaces (Visual Basic) or [using](../../../csharp/language-reference/keywords/using-directive.md) directives (C#). The minimum requirement for LINQ is a reference to *System.Core.dll* and a `using` directive for <xref:System.Linq>.

These requirements are supplied by default if you create a new C# console app project in Visual Studio 2017 or a later version. If you're upgrading a project from an earlier version of Visual Studio, you might have to supply these LINQ-related references manually.

LINQ to DataSet requires two additional references to *System.Data.dll* and *System.Data.DataSetExtensions.dll*.

> [!NOTE]
> If you're building from a command prompt, you must manually reference the LINQ-related DLLs in *%ProgramFiles%\Reference Assemblies\Microsoft\Framework\v3.5*.

## To enable LINQ to DataSet functionality

Follow these steps to enable LINQ to DataSet functionality in an existing project.

1. Add references to **System.Core**, **System.Data**, and **System.Data.DataSetExtensions**.

   In **Solution Explorer**, right-click on the **References** node and select **Add Reference**. In the **Reference Manager** dialog box, select **System.Core**, **System.Data**, and **System.Data.DataSetExtensions**. Select **OK**.

1. Add [using](../../../csharp/language-reference/keywords/using-directive.md) directives (or [Imports statements](../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md) in Visual Basic) for **System.Data** and **System.Linq**.

   ```csharp
   using System.Data;
   using System.Linq;
   ```

1. Optionally, add a `using` directive (or `Imports` statement) for **System.Data.Common** or **System.Data.SqlClient**, depending on how you connect to the database.

## See also

- [Get started with LINQ to DataSet](getting-started-linq-to-dataset.md)
