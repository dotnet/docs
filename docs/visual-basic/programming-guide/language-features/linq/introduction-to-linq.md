---
title: "Introduction to LINQ in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "queries [LINQ in Visual Basic], about LINQ in Visual Basic queries"
  - "query execution [LINQ in Visual Basic]"
  - "range variables [Visual Basic]"
  - "LINQ [Visual Basic]"
  - "LINQ [Visual Basic], about LINQ in Visual Basic"
  - "query expressions [LINQ in Visual Basic]"
  - "LINQ"
  - "deferred execution"
  - "iteration variables [Visual Basic]"
ms.assetid: 3047d86e-0d49-40e2-928b-dc02e46c7984
caps.latest.revision: 28
author: dotnet-bot
ms.author: dotnetcontent
---
# Introduction to LINQ in Visual Basic
Language-Integrated Query (LINQ) adds query capabilities to [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] and provides simple and powerful capabilities when you work with all kinds of data. Rather than sending a query to a database to be processed, or working with different query syntax for each type of data that you are searching, LINQ introduces queries as part of the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] language. It uses a unified syntax regardless of the type of data.  
  
 LINQ enables you to query data from a SQL Server database, XML, in-memory arrays and collections, [!INCLUDE[vstecado](~/includes/vstecado-md.md)] datasets, or any other remote or local data source that supports LINQ. You can do all this with common [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] language elements. Because your queries are written in the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] language, your query results are returned as strongly-typed objects. These objects support IntelliSense, which enables you to write code faster and catch errors in your queries at compile time instead of at run time. LINQ queries can be used as the source of additional queries to refine results. They can also be bound to controls so that users can easily view and modify your query results.  
  
 For example, the following code example shows a LINQ query that returns a list of customers from a collection and groups them based on their location.  
  
 [!code-vb[VbVbalrIntroToLINQ#1](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_1.vb)]  
  
 In this topic, you will find information about the following areas:  
  
-   [Running the Examples](#RunningtheExamples)  
  
-   [LINQ Providers](#LINQProviders)  
  
-   [Structure of a LINQ Query](#StructureOfALINQQuery)  
  
-   [Visual Basic LINQ Query Operators](#VisualBasicLINQQueryOperators)  
  
-   [Connecting to a Database by Using LINQ to SQL](#ConnectingToADatabase)  
  
-   [Visual Basic Features That Support LINQ](#VisualBasicFeaturesThatSupportLINQ)  
  
-   [Deferred and Immediate Query Execution](#QueryExecution)  
  
-   [XML in Visual Basic](#XMLInVisualBasic)  
  
-   [Related Resources](#RelatedResources)  
  
-   [How To and Walkthrough Topics](#HowToAndWalkthroughTopics)  
  
##  <a name="RunningtheExamples"></a> Running the Examples  
 To run the examples in the introduction and in the "Structure of a LINQ Query" section, include the following code, which returns lists of customers and orders.  
  
 [!code-vb[VbVbalrIntroToLINQ#31](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_2.vb)]  
  
##  <a name="LINQProviders"></a> LINQ Providers  
 A *LINQ provider* maps your [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] LINQ queries to the data source being queried. When you write a LINQ query, the provider takes that query and translates it into commands that the data source will be able to execute. The provider also converts data from the source to the objects that make up your query result. Finally, it converts objects to data when you send updates to the data source.  
  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] includes the following LINQ providers.  
  
|Provider|Description|  
|---|---|  
|LINQ to Objects|The LINQ to Objects provider enables you to query in-memory collections and arrays. If an object supports either the <xref:System.Collections.IEnumerable> or <xref:System.Collections.Generic.IEnumerable%601> interface, the LINQ to Objects provider enables you to query it.<br /><br /> You can enable the LINQ to Objects provider by importing the <xref:System.Linq> namespace, which is imported by default for all [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] projects.<br /><br /> For more information about the LINQ to Objects provider, see [LINQ to Objects](http://msdn.microsoft.com/library/73cafe73-37cf-46e7-bfa7-97c7eea7ced9).|  
|LINQ to SQL|The LINQ to SQL provider enables you to query and modify data in a SQL Server database. This makes it easy to map the object model for an application to the tables and objects in a database.<br /><br /> [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] makes it easier to work with LINQ to SQL by including the Object Relational Designer (O/R Designer). This designer is used to create an object model in an application that maps to objects in a database. The O/R Designer also provides functionality to map stored procedures and functions to the <xref:System.Data.Linq.DataContext> object, which manages communication with the database and stores state for optimistic concurrency checks.<br /><br /> For more information about the LINQ to SQL provider, see [LINQ to SQL](../../../../framework/data/adonet/sql/linq/index.md). For more information about the Object Relational Designer, see [LINQ to SQL Tools in Visual Studio](/visualstudio/data-tools/linq-to-sql-tools-in-visual-studio2).|  
|LINQ to XML|The LINQ to XML provider enables you to query and modify XML. You can modify in-memory XML, or you can load XML from and save XML to a file.<br /><br /> Additionally, the LINQ to XML provider enables XML literals and XML axis properties that enable you to write XML directly in your [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] code. For more information, see [XML](../../../../visual-basic/programming-guide/language-features/xml/index.md).|  
|LINQ to DataSet|The LINQ to DataSet provider enables you to query and update data in an [!INCLUDE[vstecado](~/includes/vstecado-md.md)] dataset. You can add the power of LINQ to applications that use datasets in order to simplify and extend your capabilities for querying, aggregating, and updating the data in your dataset.<br /><br /> For more information, see [LINQ to DataSet](../../../../framework/data/adonet/linq-to-dataset.md).|  
  
##  <a name="StructureOfALINQQuery"></a> Structure of a LINQ Query  
 A LINQ query, often referred to as a *query expression*, consists of a combination of query clauses that identify the data sources and iteration variables for the query. A query expression can also include instructions for sorting, filtering, grouping, and joining, or calculations to apply to the source data. Query expression syntax resembles the syntax of SQL; therefore, you may find much of the syntax familiar.  
  
 A query expression starts with a `From` clause. This clause identifies the source data for a query and the variables that are used to refer to each element of the source data individually. These variables are named *range variables* or *iteration variables*. The `From` clause is required for a query, except for `Aggregate` queries, where the `From` clause is optional. After the scope and source of the query are identified in the `From` or `Aggregate` clauses, you can include any combination of query clauses to refine the query. For details about query clauses, see [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] LINQ Query Operators later in this topic. For example, the following query identifies a source collection of customer data as the `customers` variable, and an iteration variable named `cust`.  
  
 [!code-vb[VbVbalrIntroToLINQ#2](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_3.vb)]  
  
 This example is a valid query by itself; however, the query becomes far more powerful when you add more query clauses to refine the result. For example, you can add a `Where` clause to filter the result by one or more values. Query expressions are a single line of code; you can just append additional query clauses to the end of the query. You can break up a query across multiple lines of text to improve readability by using the underscore (_) line-continuation character. The following code example shows an example of a query that includes a `Where` clause.  
  
 [!code-vb[VbVbalrIntroToLINQ#3](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_4.vb)]  
  
 Another powerful query clause is the `Select` clause, which enables you to return only selected fields from the data source. LINQ queries return enumerable collections of strongly typed objects. A query can return a collection of anonymous types or named types. You can use the `Select` clause to return only a single field from the data source. When you do this, the type of the collection returned is the type of that single field. You can also use the `Select` clause to return multiple fields from the data source. When you do this, the type of the collection returned is a new anonymous type. You can also match the fields returned by the query to the fields of a specified named type. The following code example shows a query expression that returns a collection of anonymous types that have members populated with data from the selected fields from the data source.  
  
 [!code-vb[VbVbalrIntroToLINQ#4](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_5.vb)]  
  
 LINQ queries can also be used to combine multiple sources of data and return a single result. This can be done with one or more `From` clauses, or by using the `Join` or `Group Join` query clauses. The following code example shows a query expression that combines customer and order data and returns a collection of anonymous types containing customer and order data.  
  
 [!code-vb[VbVbalrIntroToLINQ#5](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_6.vb)]  
  
 You can use the `Group Join` clause to create a hierarchical query result that contains a collection of customer objects. Each customer object has a property that contains a collection of all orders for that customer. The following code example shows a query expression that combines customer and order data as a hierarchical result and returns a collection of anonymous types. The query returns a type that includes a `CustomerOrders` property that contains a collection of order data for the customer. It also includes an `OrderTotal` property that contains the sum of the totals for all the orders for that customer. (This query is equivalent to a LEFT OUTER JOIN.)  
  
 [!code-vb[VbVbalrIntroToLINQ#6](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_7.vb)]  
  
 There are several additional LINQ query operators that you can use to create powerful query expressions. The next section of this topic discusses the various query clauses that you can include in a query expression. For details about [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] query clauses, see [Queries](../../../../visual-basic/language-reference/queries/queries.md).  
  
##  <a name="VisualBasicLINQQueryOperators"></a> Visual Basic LINQ Query Operators  
 The classes in the <xref:System.Linq> namespace and the other namespaces that support LINQ queries include methods that you can call to create and refine queries based on the needs of your application. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] includes keywords for the most common query clauses, as described by the following table.  
  
|Term|Definition|  
|---|---|  
|[From Clause](../../../../visual-basic/language-reference/queries/from-clause.md)|Either a `From` clause or an `Aggregate` clause is required to begin a query. A `From` clause specifies a source collection and an iteration variable for a query. For example:<br /><br /> [!code-vb[VbVbalrIntroToLINQ#7](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_8.vb)]|  
|[Select Clause](../../../../visual-basic/language-reference/queries/select-clause.md)|Optional. Declares a set of iteration variables for a query. For example:<br /><br /> [!code-vb[VbVbalrIntroToLINQ#8](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_9.vb)]<br /><br /> If a `Select` clause is not specified, the iteration variables for the query consist of the iteration variables specified by the `From` or `Aggregate` clause.|  
|[Where Clause](../../../../visual-basic/language-reference/queries/where-clause.md)|Optional. Specifies a filtering condition for a query. For example:<br /><br /> [!code-vb[VbVbalrIntroToLINQ#9](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_10.vb)]|  
|[Order By Clause](../../../../visual-basic/language-reference/queries/order-by-clause.md)|Optional. Specifies the sort order for columns in a query. For example:<br /><br /> [!code-vb[VbVbalrIntroToLINQ#10](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_11.vb)]|  
|[Join Clause](../../../../visual-basic/language-reference/queries/join-clause.md)|Optional. Combines two collections into a single collection. For example:<br /><br /> [!code-vb[VbVbalrIntroToLINQ#11](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_12.vb)]|  
|[Group By Clause](../../../../visual-basic/language-reference/queries/group-by-clause.md)|Optional. Groups the elements of a query result. Can be used to apply aggregate functions to each group. For example:<br /><br /> [!code-vb[VbVbalrIntroToLINQ#12](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_13.vb)]|  
|[Group Join Clause](../../../../visual-basic/language-reference/queries/group-join-clause.md)|Optional. Combines two collections into a single hierarchical collection. For example:<br /><br /> [!code-vb[VbVbalrIntroToLINQ#13](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_14.vb)]|  
|[Aggregate Clause](../../../../visual-basic/language-reference/queries/aggregate-clause.md)|Either a `From` clause or an `Aggregate` clause is required to begin a query. An `Aggregate` clause applies one or more aggregate functions to a collection. For example, you can use the `Aggregate` clause to calculate a sum for all the elements returned by a query.<br /><br /> [!code-vb[VbVbalrIntroToLINQ#14](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_15.vb)]<br /><br /> You can also use the `Aggregate` clause to modify a query. For example, you can use the `Aggregate` clause to perform a calculation on a related query collection.<br /><br /> [!code-vb[VbVbalrIntroToLINQ#15](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_16.vb)]|  
|[Let Clause](../../../../visual-basic/language-reference/queries/let-clause.md)|Optional. Computes a value and assigns it to a new variable in the query. For example:<br /><br /> [!code-vb[VbVbalrIntroToLINQ#16](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_17.vb)]|  
|[Distinct Clause](../../../../visual-basic/language-reference/queries/distinct-clause.md)|Optional. Restricts the values of the current iteration variable to eliminate duplicate values in query results. For example:<br /><br /> [!code-vb[VbVbalrIntroToLINQ#17](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_18.vb)]|  
|[Skip Clause](../../../../visual-basic/language-reference/queries/skip-clause.md)|Optional. Bypasses a specified number of elements in a collection and then returns the remaining elements. For example:<br /><br /> [!code-vb[VbVbalrIntroToLINQ#18](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_19.vb)]|  
|[Skip While Clause](../../../../visual-basic/language-reference/queries/skip-while-clause.md)|Optional. Bypasses elements in a collection as long as a specified condition is `true` and then returns the remaining elements. For example:<br /><br /> [!code-vb[VbVbalrIntroToLINQ#19](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_20.vb)]|  
|[Take Clause](../../../../visual-basic/language-reference/queries/take-clause.md)|Optional. Returns a specified number of contiguous elements from the start of a collection. For example:<br /><br /> [!code-vb[VbVbalrIntroToLINQ#20](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_21.vb)]|  
|[Take While Clause](../../../../visual-basic/language-reference/queries/take-while-clause.md)|Optional. Includes elements in a collection as long as a specified condition is `true` and bypasses the remaining elements. For example:<br /><br /> [!code-vb[VbVbalrIntroToLINQ#21](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_22.vb)]|  
  
 For details about [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] query clauses, see [Queries](../../../../visual-basic/language-reference/queries/queries.md).  
  
 You can use additional LINQ query features by calling members of the enumerable and queryable types provided by LINQ. You can use these additional capabilities by calling a particular query operator on the result of a query expression. For example, the following code example uses the <xref:System.Linq.Enumerable.Union%2A> method to combine the results of two queries into one query result. It uses the <xref:System.Linq.Enumerable.ToList%2A> method to return the query result as a generic list.  
  
 [!code-vb[VbVbalrIntroToLINQ#22](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/introduction-to-linq_23.vb)]  
  
 For details about additional LINQ capabilities, see [Standard Query Operators Overview](http://msdn.microsoft.com/library/24cda21e-8af8-4632-b519-c404a839b9b2).  
  
##  <a name="ConnectingToADatabase"></a> Connecting to a Database by Using LINQ to SQL  
 In [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], you identify the SQL Server database objects, such as tables, views, and stored procedures, that you want to access by using a LINQ to SQL file. A LINQ to SQL file has an extension of .dbml.  
  
 When you have a valid connection to a SQL Server database, you can add a **LINQ to SQL Classes** item template to your project. This will display the Object Relational Designer (O/R designer). The O/R Designer enables you to drag the items that you want to access in your code from the **Server Explorer**/**Database Explorer** onto the designer surface. The LINQ to SQL file adds a <xref:System.Data.Linq.DataContext> object to your project. This object includes properties and collections for the tables and views that you want access to, and methods for the stored procedures that you want to call. After you have saved your changes to the LINQ to SQL (.dbml) file, you can access these objects in your code by referencing the <xref:System.Data.Linq.DataContext> object that is defined by the O/R Designer. The <xref:System.Data.Linq.DataContext> object for your project is named based on the name of your LINQ to SQL file. For example, a LINQ to SQL file that is named Northwind.dbml will create a <xref:System.Data.Linq.DataContext> object named `NorthwindDataContext`.  
  
 For examples with step-by-step instructions, see [How to: Query a Database](../../../../visual-basic/programming-guide/language-features/linq/how-to-query-a-database-by-using-linq.md) and [How to: Call a Stored Procedure](../../../../visual-basic/programming-guide/language-features/linq/how-to-call-a-stored-procedure-by-using-linq.md).  
  
##  <a name="VisualBasicFeaturesThatSupportLINQ"></a> Visual Basic Features That Support LINQ  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] includes other notable features that make the use of LINQ simple and reduce the amount of code that you must write to perform LINQ queries. These include the following:  
  
-   **Anonymous types**, which enable you to create a new type based on a query result.  
  
-   **Implicitly typed variables**, which enable you to defer specifying a type and let the compiler infer the type based on the query result.  
  
-   **Extension methods**, which enable you to extend an existing type with your own methods without modifying the type itself.  
  
 For details, see [Visual Basic Features That Support LINQ](../../../../visual-basic/programming-guide/concepts/linq/features-that-support-linq.md).  
  
##  <a name="QueryExecution"></a> Deferred and Immediate Query Execution  
 Query execution is separate from creating a query. After a query is created, its execution is triggered by a separate mechanism. A query can be executed as soon as it is defined (*immediate execution*), or the definition can be stored and the query can be executed later (*deferred execution*).  
  
 By default, when you create a query, the query itself does not execute immediately. Instead, the query definition is stored in the variable that is used to reference the query result. When the query result variable is accessed later in code, such as in a `For…Next` loop, the query is executed. This process is referred to as *deferred execution*.  
  
 Queries can also be executed when they are defined, which is referred to as *immediate execution*. You can trigger immediate execution by applying a method that requires access to individual elements of the query result. This can be the result of including an aggregate function, such as `Count`, `Sum`, `Average`, `Min`, or `Max`. For more information about aggregate functions, see [Aggregate Clause](../../../../visual-basic/language-reference/queries/aggregate-clause.md).  
  
 Using the `ToList` or `ToArray` methods will also force immediate execution. This can be useful when you want to execute the query immediately and cache the results. For more information about these methods, see [Converting Data Types](../../../../visual-basic/programming-guide/concepts/linq/converting-data-types.md).  
  
 For more information about query execution, see [Writing Your First LINQ Query](../../../../visual-basic/programming-guide/concepts/linq/writing-your-first-linq-query.md).  
  
##  <a name="XMLInVisualBasic"></a> XML in Visual Basic  
 The XML features in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] include XML literals and XML axis properties, which enable you easily to create, access, query, and modify XML in your code. XML literals enable you to write XML directly in your code. The Visual Basic compiler treats the XML as a first-class data object.  
  
 The following code example shows how to create an XML element, access its sub-elements and attributes, and query the contents of the element by using LINQ.  
  
 [!code-vb[VbXmlSamples#8](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/introduction-to-linq_24.vb)]  
  
 For more information, see [XML](../../../../visual-basic/programming-guide/language-features/xml/index.md).  
  
##  <a name="RelatedResources"></a> Related Resources  
  
|Topic|Description|  
|---|---|  
|[XML](../../../../visual-basic/programming-guide/language-features/xml/index.md)|Describes the XML features in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] that can be queried and that enable you to include XML as first-class data objects in your [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] code.|  
|[Queries](../../../../visual-basic/language-reference/queries/queries.md)|Provides reference information about the query clauses that are available in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)].|  
|[LINQ (Language-Integrated Query)](http://msdn.microsoft.com/library/a73c4aec-5d15-4e98-b962-1274021ea93d)|Includes general information, programming guidance, and samples for LINQ.|  
|[LINQ to SQL](../../../../framework/data/adonet/sql/linq/index.md)|Includes general information, programming guidance, and samples for LINQ to SQL.|  
|[LINQ to Objects](http://msdn.microsoft.com/library/73cafe73-37cf-46e7-bfa7-97c7eea7ced9)|Includes general information, programming guidance, and samples for LINQ to Objects.|  
|[LINQ to ADO.NET (Portal Page)](http://msdn.microsoft.com/library/dd7d3c6a-ff98-47e9-a1a7-2d4cfc42d150)|Includes links to general information, programming guidance, and samples for LINQ to [!INCLUDE[vstecado](~/includes/vstecado-md.md)].|  
|[LINQ to XML](http://msdn.microsoft.com/library/f0fe21e9-ee43-4a55-b91a-0800e5782c13)|Includes general information, programming guidance, and samples for LINQ to XML.|  
  
##  <a name="HowToAndWalkthroughTopics"></a> How To and Walkthrough Topics  
 [How to: Query a Database](how-to-query-a-database-by-using-linq.md)  
  
 [How to: Call a Stored Procedure](how-to-call-a-stored-procedure-by-using-linq.md)  
  
 [How to: Modify Data in a Database](how-to-modify-data-in-a-database-by-using-linq.md)  
  
 [How to: Combine Data with Joins](how-to-combine-data-with-linq-by-using-joins.md)  
  
 [How to: Sort Query Results](how-to-sort-query-results-by-using-linq.md)  
  
 [How to: Filter Query Results](how-to-filter-query-results-by-using-linq.md)  
  
 [How to: Count, Sum, or Average Data](how-to-count-sum-or-average-data-by-using-linq.md)  
  
 [How to: Find the Minimum or Maximum Value in a Query Result](how-to-find-the-minimum-or-maximum-value-in-a-query-result.md)  
  
 [How to: Assign stored procedures to perform updates, inserts, and deletes (O/R Designer)](http://msdn.microsoft.com/library/e88224ab-ff61-4a3a-b6b8-6f3694546cac)  
  
## Featured Book Chapters  
 [Chapter 17: LINQ](http://go.microsoft.com/fwlink/?LinkId=195277) in [Programming Visual Basic 2008](http://go.microsoft.com/fwlink/?LinkId=195383)  
  
## See Also  
 [LINQ (Language-Integrated Query)](http://msdn.microsoft.com/library/a73c4aec-5d15-4e98-b962-1274021ea93d)  
 [Overview of LINQ to XML in Visual Basic](../../../../visual-basic/programming-guide/language-features/xml/overview-of-linq-to-xml.md)  
 [LINQ to DataSet Overview](../../../../framework/data/adonet/linq-to-dataset-overview.md)  
 [LINQ to SQL](../../../../framework/data/adonet/sql/linq/index.md)  
 [LINQ to SQL Tools in Visual Studio](/visualstudio/data-tools/linq-to-sql-tools-in-visual-studio2)  
 [DataContext Methods (O/R Designer)](/visualstudio/data-tools/datacontext-methods-o-r-designer)
