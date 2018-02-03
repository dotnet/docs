---
title: "Compiled Queries  (LINQ to Entities)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 8025ba1d-29c7-4407-841b-d5a3bed40b7a
caps.latest.revision: 5
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Compiled Queries  (LINQ to Entities)
When you have an application that executes structurally similar queries many times in the Entity Framework, you can frequently increase performance by compiling the query one time and executing it several times with different parameters. For example, an application might have to retrieve all the customers in a particular city; the city is specified at runtime by the user in a form. LINQ to Entities supports using compiled queries for this purpose.  
  
 Starting with the .NET Framework 4.5, LINQ queries are cached automatically. However, you can still use compiled LINQ queries to reduce this cost in later executions and compiled queries can be more efficient than LINQ queries that are automatically cached. Note that LINQ to Entities queries that apply the `Enumerable.Contains` operator to in-memory collections are not automatically cached. Also parameterizing in-memory collections in compiled LINQ queries is not allowed.  
  
 The <xref:System.Data.Objects.CompiledQuery> class provides compilation and caching of queries for reuse. Conceptually, this class contains a <xref:System.Data.Objects.CompiledQuery>'s `Compile` method with several overloads. Call the `Compile` method to create a new delegate to represent the compiled query. The `Compile` methods, provided with a <xref:System.Data.Objects.ObjectContext> and parameter values, return a delegate that produces some result (such as an <xref:System.Linq.IQueryable%601> instance). The query compiles once during only the first execution. The merge options set for the query at the time of the compilation cannot be changed later. Once the query is compiled you can only supply parameters of primitive type but you cannot replace parts of the query that would change the generated SQL. For more information, see [Entity Framework Merge Options and Compiled Queries](http://go.microsoft.com/fwlink/?LinkId=199591)  
  
 The [!INCLUDE[linq_entities](../../../../../../includes/linq-entities-md.md)] query expression that the <xref:System.Data.Objects.CompiledQuery>'s `Compile` method compiles is represented by one of the generic `Func` delegates, such as <xref:System.Func%605>. At most, the query expression can encapsulate an `ObjectContext` parameter, a return parameter, and 16 query parameters. If more than 16 query parameters are required, you can create a structure whose properties represent query parameters. You can then use the properties on the structure in the query expression after you set the properties.  
  
## Example  
 The following example compiles and then invokes a query that accepts a <xref:System.Decimal> input parameter and returns a sequence of orders where the total due is greater than or equal to $200.00:  
  
 [!code-csharp[DP L2E Conceptual Examples#CompiledQuery2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DP L2E Conceptual Examples/CS/Program.cs#compiledquery2)]
 [!code-vb[DP L2E Conceptual Examples#CompiledQuery2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP L2E Conceptual Examples/VB/Module1.vb#compiledquery2)]  
  
## Example  
 The following example compiles and then invokes a query that returns an <xref:System.Data.Objects.ObjectQuery%601> instance:  
  
 [!code-csharp[DP L2E Conceptual Examples#CompiledQuery1_MQ](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DP L2E Conceptual Examples/CS/Program.cs#compiledquery1_mq)]
 [!code-vb[DP L2E Conceptual Examples#CompiledQuery1_MQ](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP L2E Conceptual Examples/VB/Module1.vb#compiledquery1_mq)]  
  
## Example  
 The following example compiles and then invokes a query that returns the average of the product list prices as a <xref:System.Decimal> value:  
  
 [!code-csharp[DP L2E Conceptual Examples#CompiledQuery3_MQ](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DP L2E Conceptual Examples/CS/Program.cs#compiledquery3_mq)]
 [!code-vb[DP L2E Conceptual Examples#CompiledQuery3_MQ](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP L2E Conceptual Examples/VB/Module1.vb#compiledquery3_mq)]  
  
## Example  
 The following example compiles and then invokes a query that accepts a <xref:System.String> input parameter and then returns a `Contact` whose email address starts with the specified string:  
  
 [!code-csharp[DP L2E Conceptual Examples#CompiledQuery4_MQ](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DP L2E Conceptual Examples/CS/Program.cs#compiledquery4_mq)]
 [!code-vb[DP L2E Conceptual Examples#CompiledQuery4_MQ](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP L2E Conceptual Examples/VB/Module1.vb#compiledquery4_mq)]  
  
## Example  
 The following example compiles and then invokes a query that accepts <xref:System.DateTime> and <xref:System.Decimal> input parameters and returns a sequence of orders where the order date is later than March 8, 2003, and the total due is less than $300.00:  
  
 [!code-csharp[DP L2E Conceptual Examples#CompiledQuery5](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DP L2E Conceptual Examples/CS/Program.cs#compiledquery5)]
 [!code-vb[DP L2E Conceptual Examples#CompiledQuery5](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP L2E Conceptual Examples/VB/Module1.vb#compiledquery5)]  
  
## Example  
 The following example compiles and then invokes a query that accepts a <xref:System.DateTime> input parameter and returns a sequence of orders where the order date is later than March 8, 2004. This query returns the order information as a sequence of anonymous types. Anonymous types are inferred by the compiler, so you cannot specify type parameters in the <xref:System.Data.Objects.CompiledQuery>'s `Compile` method and the type is defined in the query itself.  
  
 [!code-csharp[DP L2E Conceptual Examples#CompiledQuery6](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DP L2E Conceptual Examples/CS/Program.cs#compiledquery6)]
 [!code-vb[DP L2E Conceptual Examples#CompiledQuery6](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP L2E Conceptual Examples/VB/Module1.vb#compiledquery6)]  
  
## Example  
 The following example compiles and then invokes a query that accepts a user-defined structure input parameter and returns a sequence of orders. The structure defines start date, end date, and total due query parameters, and the query returns orders shipped between March 3 and March 8, 2003 with a total due greater than $700.00.  
  
 [!code-csharp[DP L2E Conceptual Examples#CompiledQuery7](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DP L2E Conceptual Examples/CS/Program.cs#compiledquery7)]
 [!code-vb[DP L2E Conceptual Examples#CompiledQuery7](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP L2E Conceptual Examples/VB/Module1.vb#compiledquery7)]  
  
 The structure that defines the query parameters:  
  
 [!code-csharp[DP L2E Conceptual Examples#MyParamsStruct](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DP L2E Conceptual Examples/CS/Program.cs#myparamsstruct)]
 [!code-vb[DP L2E Conceptual Examples#MyParamsStruct](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP L2E Conceptual Examples/VB/Module1.vb#myparamsstruct)]  
  
## See Also  
 [ADO.NET Entity Framework](../../../../../../docs/framework/data/adonet/ef/index.md)  
 [LINQ to Entities](../../../../../../docs/framework/data/adonet/ef/language-reference/linq-to-entities.md)  
 [Entity Framework Merge Options and Compiled Queries](http://go.microsoft.com/fwlink/?LinkId=199591)
