---
description: "Learn more about: Typed DataSets"
title: "Typed DataSets"
ms.date: "03/30/2017"
ms.assetid: 033d2548-cf24-4c05-8179-67d8b009c048
---
# Typed DataSets

Along with late bound access to values through weakly typed variables, the <xref:System.Data.DataSet> provides access to data through a strongly typed metaphor. Tables and columns that are part of the **DataSet** can be accessed using user-friendly names and strongly typed variables.  
  
 A typed **DataSet** is a class that derives from a **DataSet**. As such, it inherits all the methods, events, and properties of a **DataSet**. Additionally, a typed **DataSet** provides strongly typed methods, events, and properties. This means you can access tables and columns by name, instead of using collection-based methods. Aside from the improved readability of the code, a typed **DataSet** also allows the Visual Studio .NET code editor to automatically complete lines as you type.  
  
 Additionally, the strongly typed **DataSet** provides access to values as the correct type at compile time. With a strongly typed **DataSet**, type mismatch errors are caught when the code is compiled rather than at run time.  
  
## In This Section  

 [Generating Strongly Typed DataSets](generating-strongly-typed-datasets.md)  
 Describes how to create and use a strongly typed **DataSet**.  
  
 [Annotating Typed DataSets](annotating-typed-datasets.md)  
 Describes how to annotate the XML Schema definition language (XSD) schema used to generate a strongly typed **DataSet**, to give **DataSet** elements friendly names without altering the underlying schema.  
  
## See also

- [DataSets, DataTables, and DataViews](index.md)
- [ADO.NET Overview](../ado-net-overview.md)
