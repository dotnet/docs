---
description: "Learn more about: How to: Generate Customized Code by Modifying a DBML File"
title: "How to: Generate Customized Code by Modifying a DBML File"
ms.date: "03/30/2017"
ms.assetid: 50ad597a-8598-42d3-82dd-fc7d702ebc37
---
# How to: Generate Customized Code by Modifying a DBML File

You can generate Visual Basic or C# source code from a database markup language (.dbml) metadata file. This approach provides an opportunity to customize the default .dbml file before you generate the application mapping code. This is an advanced feature.  
  
 The steps in this process are as follows:  
  
1. Generate a .dbml file.  
  
2. Use an editor to modify the .dbml file. Note that the .dbml file must validate against the schema definition (.xsd) file for [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] .dbml files. For more information, see [Code Generation in LINQ to SQL](code-generation-in-linq-to-sql.md).  
  
3. Generate the Visual Basic or C# source code.  
  
 The following examples use the SQLMetal command-line tool. For more information, see [SqlMetal.exe (Code Generation Tool)](../../../../tools/sqlmetal-exe-code-generation-tool.md).  
  
## Example 1

 The following code generates a .dbml file from the Northwind sample database. As source for the database metadata, you can use either the name of the database or the name of the .mdf file.  
  
```console  
sqlmetal /server:myserver /database:northwind /dbml:mymeta.dbml  
sqlmetal /dbml:mymeta.dbml mydbfile.mdf  
```  
  
## Example 2  

 The following code generates Visual Basic or C# source code file from a .dbml file.  
  
```console
sqlmetal /namespace:nwind /code:nwind.vb /language:vb DBMLFile.dbml  
sqlmetal /namespace:nwind /code:nwind.cs /language:csharp DBMLFile.dbml  
```  
  
## See also

- [Code Generation in LINQ to SQL](code-generation-in-linq-to-sql.md)
- [SqlMetal.exe (Code Generation Tool)](../../../../tools/sqlmetal-exe-code-generation-tool.md)
- [Creating the Object Model](creating-the-object-model.md)
