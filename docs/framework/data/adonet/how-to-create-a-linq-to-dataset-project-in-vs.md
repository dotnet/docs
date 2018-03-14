---
title: "How to: Create a LINQ to DataSet Project In Visual Studio"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 49ba6cb0-cdd2-4571-aeaa-25bf0f40e9b3
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# How to: Create a LINQ to DataSet Project In Visual Studio
The different types of [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] projects require certain imported namespaces (Visual Basic) or `using` directives (C#) and references. The minimum requirement is a reference to System.Core.dll and a `using` directive for <xref:System.Linq>. By default, these are supplied if you create a new [!INCLUDE[csharp_orcas_long](../../../../includes/csharp-orcas-long-md.md)] project. [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] also requires a reference to System.Data.dll and System.Data.DataSetExtensions.dll and an `Imports` (Visual Basic) or `using` (C#) directive.  
  
 If you are upgrading a project from an earlier version of Visual Studio, you might have to supply these LINQ-related references manually. You might also have to manually set the project to target the .NET Framework version 3.5.  
  
> [!NOTE]
>  If you are building from a command prompt, you must manually reference the LINQ-related DLLs in `drive`**:**\Program Files\Reference Assemblies\Microsoft\Framework\v3.5.  
  
### To target the .NET Framework 3.5  
  
1.  In [!INCLUDE[vs_orcas_long](../../../../includes/vs-orcas-long-md.md)], create a new Visual Basic or C# project. Alternatively, you can open a Visual Basic or C# project that was created in Visual Studio 2005 and follow the prompts to convert it to a [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] project.  
  
2.  For a C# project, click the **Project** menu, and then click **Properties**.  
  
    1.  In the **Application** property page, select .NET Framework 3.5 in the **Target Framework** drop-down list.  
  
3.  For a Visual Basic project, click the **Project** menu, and then click **Properties**.  
  
    1.  In the **Compile** property page, click **Advanced Compile Options** and then select .NET Framework 3.5 in the **Target Framework (all configurations)** drop-down list.  
  
4.  On the **Project** menu, click **Add Reference**, click the **.NET** tab, scroll down to **System.Core**, click it, and then click **OK**.  
  
5.  Add a `using` directive or imported namespace for <xref:System.Linq> to your source code file or project.  
  
     For more information, see [using Directive](~/docs/csharp/language-reference/keywords/using-directive.md) or [How to: Add or Remove Imported Namespaces (Visual Basic)](/visualstudio/ide/how-to-add-or-remove-imported-namespaces-visual-basic).  
  
### To enable LINQ to DataSet functionality  
  
1.  If necessary, follow the steps earlier in this topic to add a reference to System.Core.dll and a `using` directive or imported namespace for System.Linq.  
  
2.  In C# or Visual Basic, click the **Project** menu, and then click **Add Reference**.  
  
3.  In the **Add Reference** dialog box, click the **.NET** tab if it is not on top. Scroll down to **System.Data** and **System.Data.DataSetExtensions** and click on them. Click the **OK** button.  
  
4.  Add a `using` directive or imported namespace for <xref:System.Data> to your source code file or project. For more information, see [using Directive](~/docs/csharp/language-reference/keywords/using-directive.md) or [How to: Add or Remove Imported Namespaces (Visual Basic)](/visualstudio/ide/how-to-add-or-remove-imported-namespaces-visual-basic).  
  
5.  Add a reference to System.Data.DataSetExtensions.dll for LINQ to Dataset functionality. Add a reference to System.Data.dll if it does not already exist.  
  
6.  Optionally, add a `using` directive or imported namespace for `System.Data.Common` or `System.Data.SqlClient`, depending on how you connect to the database.  
  
## See Also  
 [Getting Started](../../../../docs/framework/data/adonet/getting-started-linq-to-dataset.md)  
 [Getting Started with LINQ](http://msdn.microsoft.com/library/6cc9af04-950a-4cc3-83d4-2aeb4abe4de9)
