---
description: "Learn more about: How to: Call Custom Database Functions"
title: "How to: Call Custom Database Functions"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 4354e5eb-dd45-469d-97fb-1c495705ee59
---
# How to: Call Custom Database Functions

This topic describes how to call custom functions that are defined in the database from within LINQ to Entities queries.

Database functions that are called from LINQ to Entities queries are executed in the database. Executing functions in the database can improve application performance.

The procedure below provides a high-level outline for calling a custom database function. The example that follows provides more detail about the steps in the procedure.

## To call custom functions that are defined in the database

1. Create a custom function in your database.

     For more information about creating custom functions in SQL Server, see [CREATE FUNCTION (Transact-SQL)](/sql/t-sql/statements/create-function-transact-sql).

2. Declare a function in the store schema definition language (SSDL) of your .edmx file. The name of the function must be the same as the name of the function declared in the database.

     For more information, see [Function Element (SSDL)](/ef/ef6/modeling/designer/advanced/edmx/ssdl-spec#function-element-ssdl).

3. Add a corresponding method to a class in your application code and apply a <xref:System.Data.Objects.DataClasses.EdmFunctionAttribute> to the method Note that the <xref:System.Data.Objects.DataClasses.EdmFunctionAttribute.NamespaceName%2A> and <xref:System.Data.Objects.DataClasses.EdmFunctionAttribute.FunctionName%2A> parameters of the attribute are the namespace name of the conceptual model and the function name in the conceptual model respectively. Function name resolution for LINQ is case sensitive.

4. Call the method in a LINQ to Entities query.  

## Example 1

The following example demonstrates how to call a custom database function from within a LINQ to Entities query. The example uses the School model. For information about the School model, see [Creating the School Sample Database](/previous-versions/dotnet/netframework-4.0/bb399731(v=vs.100)) and [Generating the School .edmx File](/previous-versions/dotnet/netframework-4.0/bb399739(v=vs.100)).

The following code adds the `AvgStudentGrade` function to the School sample database.

> [!NOTE]
> The steps for calling a custom database function are the same regardless of the database server. However, the code below is specific to creating a function in a SQL Server database. The code for creating a custom function in other database servers might differ.

[!code-sql[DP L2E MapToDBFunction#1](~/samples/snippets/tsql/VS_Snippets_Data/dp l2e maptodbfunction/tsql/create_avgstudentgrade.sql#1)]

## Example 2

Next, declare a function in the store schema definition language (SSDL) of your *.edmx* file. The following code declares the `AvgStudentGrade` function in SSDL:

[!code-xml[DP L2E MapToDBFunction#2](~/samples/snippets/csharp/VS_Snippets_Data/dp l2e maptodbfunction/cs/school.edmx#2)]

## Example 3

Now, create a method and map it to the function declared in the SSDL. The method in the following class is mapped to the function defined in the SSDL (above) by using an <xref:System.Data.Objects.DataClasses.EdmFunctionAttribute>. When this method is called, the corresponding function in the database is executed.

[!code-csharp[DP L2E MapToDBFunction#3](~/samples/snippets/csharp/VS_Snippets_Data/dp l2e maptodbfunction/cs/program.cs#3)]
[!code-vb[DP L2E MapToDBFunction#3](~/samples/snippets/visualbasic/VS_Snippets_Data/dp l2e maptodbfunction/vb/module1.vb#3)]

## Example 4

Finally, call the method in a LINQ to Entities query. The following code displays students' last names and average grades to the console:

[!code-csharp[DP L2E MapToDBFunction#4](~/samples/snippets/csharp/VS_Snippets_Data/dp l2e maptodbfunction/cs/program.cs#4)]
[!code-vb[DP L2E MapToDBFunction#4](~/samples/snippets/visualbasic/VS_Snippets_Data/dp l2e maptodbfunction/vb/module1.vb#4)]

## See also

- [.edmx File Overview](/previous-versions/dotnet/netframework-4.0/cc982042(v=vs.100))
- [Queries in LINQ to Entities](queries-in-linq-to-entities.md)
