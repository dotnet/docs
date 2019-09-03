---
title: "How to: Generate the Object Model in Visual Basic or C#"
ms.date: "03/30/2017"
ms.assetid: a0c73b33-5650-420c-b9dc-f49310c201ee
---
# How to: Generate the Object Model in Visual Basic or C\#
In [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], an object model in your own programming language is mapped to a relational database. Two tools are available for automatically generating a Visual Basic or C# model from the metadata of an existing database.  
  
- If you are using Visual Studio, you can use the Object Relational Designer to generate an object model. The O/R Designer provides a rich user interface to help you generate a [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] object model. For more information see, [Linq to SQL Tools in Visual Studio](https://docs.microsoft.com/visualstudio/data-tools/linq-to-sql-tools-in-visual-studio2).
  
- The SQLMetal command-line tool. For more information, see [SqlMetal.exe (Code Generation Tool)](../../../../../../docs/framework/tools/sqlmetal-exe-code-generation-tool.md).  
  
    > [!NOTE]
    > If you do not have an existing database and want to create one from an object model, you can create your object model by using your code editor and <xref:System.Data.Linq.DataContext.CreateDatabase%2A>. For more information, see [How to: Dynamically Create a Database](../../../../../../docs/framework/data/adonet/sql/linq/how-to-dynamically-create-a-database.md).  
  
 Documentation for the O/R Designer provides examples of how to generate a Visual Basic or C# object model by using the O/R Designer. The following information provide examples of how to use the SQLMetal command-line tool. For more information, see [SqlMetal.exe (Code Generation Tool)](../../../../../../docs/framework/tools/sqlmetal-exe-code-generation-tool.md).  
  
## Example  
 The SQLMetal command line shown in the following example produces Visual Basic code as the attribute-based object model of the Northwind sample database. Stored procedures and functions are also rendered.  
  
```  
sqlmetal /code:northwind.vb /language:vb "c:\northwnd.mdf" /sprocs /functions  
```  
  
## Example  
 The SQLMetal command line shown in the following example produces C# code as the attribute-based object model of the Northwind sample database. Stored procedures and functions are also rendered, and table names are automatically pluralized.  
  
```  
sqlmetal /code:northwind.cs /language:csharp "c:\northwnd.mdf" /sprocs /functions /pluralize  
```  
  
## See also

- [Programming Guide](../../../../../../docs/framework/data/adonet/sql/linq/programming-guide.md)
- [The LINQ to SQL Object Model](../../../../../../docs/framework/data/adonet/sql/linq/the-linq-to-sql-object-model.md)
- [Learning by Walkthroughs](../../../../../../docs/framework/data/adonet/sql/linq/learning-by-walkthroughs.md)
- [How to: Customize Entity Classes by Using the Code Editor](../../../../../../docs/framework/data/adonet/sql/linq/how-to-customize-entity-classes-by-using-the-code-editor.md)
- [Attribute-Based Mapping](../../../../../../docs/framework/data/adonet/sql/linq/attribute-based-mapping.md)
- [SqlMetal.exe (Code Generation Tool)](../../../../../../docs/framework/tools/sqlmetal-exe-code-generation-tool.md)
- [External Mapping](../../../../../../docs/framework/data/adonet/sql/linq/external-mapping.md)
- [Downloading Sample Databases](../../../../../../docs/framework/data/adonet/sql/linq/downloading-sample-databases.md)
- [Creating the Object Model](../../../../../../docs/framework/data/adonet/sql/linq/creating-the-object-model.md)
