---
description: "Learn more about: Introduction to LINQ in Visual Basic"
title: "Intro to LINQ"
ms.date: 08/28/2018
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
---
# Introduction to LINQ in Visual Basic

Language-Integrated Query (LINQ) adds query capabilities to Visual Basic and provides simple and powerful capabilities when you work with all kinds of data. Rather than sending a query to a database to be processed, or working with different query syntax for each type of data that you are searching, LINQ introduces queries as part of the Visual Basic language. It uses a unified syntax regardless of the type of data.  
  
 LINQ enables you to query data from a SQL Server database, XML, in-memory arrays and collections, ADO.NET datasets, or any other remote or local data source that supports LINQ. You can do all this with common Visual Basic language elements. Because your queries are written in the Visual Basic language, your query results are returned as strongly typed objects. These objects support IntelliSense, which enables you to write code faster and catch errors in your queries at compile time instead of at run time. LINQ queries can be used as the source of additional queries to refine results. They can also be bound to controls so that users can easily view and modify your query results.  
  
 For example, the following code example shows a LINQ query that returns a list of customers from a collection and groups them based on their location.  
  
 [!code-vb[VbVbalrIntroToLINQ#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/class2.vb#1)]  
  
## Running the examples  

 To run the examples in the introduction and in the [Structure of a LINQ Query](#structure-of-a-linq-query) section, include the following code, which returns lists of customers and orders.  
  
 [!code-vb[VbVbalrIntroToLINQ#31](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/class2.vb#31)]  
  
## LINQ providers  

 A *LINQ provider* maps your Visual Basic LINQ queries to the data source being queried. When you write a LINQ query, the provider takes that query and translates it into commands that the data source will be able to execute. The provider also converts data from the source to the objects that make up your query result. Finally, it converts objects to data when you send updates to the data source.  
  
 Visual Basic includes the following LINQ providers.  
  
|Provider|Description|  
|---|---|  
|LINQ to Objects|The LINQ to Objects provider enables you to query in-memory collections and arrays. If an object supports either the <xref:System.Collections.IEnumerable> or <xref:System.Collections.Generic.IEnumerable%601> interface, the LINQ to Objects provider enables you to query it.<br /><br /> You can enable the LINQ to Objects provider by importing the <xref:System.Linq> namespace, which is imported by default for all Visual Basic projects.<br /><br /> For more information about the LINQ to Objects provider, see [LINQ to Objects](../../concepts/linq/linq-to-objects.md).|  
|LINQ to SQL|The LINQ to SQL provider enables you to query and modify data in a SQL Server database. This makes it easy to map the object model for an application to the tables and objects in a database.<br /><br /> Visual Basic makes it easier to work with LINQ to SQL by including the Object Relational Designer (O/R Designer). This designer is used to create an object model in an application that maps to objects in a database. The O/R Designer also provides functionality to map stored procedures and functions to the <xref:System.Data.Linq.DataContext> object, which manages communication with the database and stores state for optimistic concurrency checks.<br /><br /> For more information about the LINQ to SQL provider, see [LINQ to SQL](../../../../framework/data/adonet/sql/linq/index.md). For more information about the Object Relational Designer, see [LINQ to SQL Tools in Visual Studio](/visualstudio/data-tools/linq-to-sql-tools-in-visual-studio2).|  
|LINQ to XML|The LINQ to XML provider enables you to query and modify XML. You can modify in-memory XML, or you can load XML from and save XML to a file.<br /><br /> Additionally, the LINQ to XML provider enables XML literals and XML axis properties that enable you to write XML directly in your Visual Basic code. For more information, see [XML](../xml/index.md).|  
|LINQ to DataSet|The LINQ to DataSet provider enables you to query and update data in an ADO.NET dataset. You can add the power of LINQ to applications that use datasets in order to simplify and extend your capabilities for querying, aggregating, and updating the data in your dataset.<br /><br /> For more information, see [LINQ to DataSet](../../../../framework/data/adonet/linq-to-dataset.md).|  
  
## Structure of a LINQ query  

 A LINQ query, often referred to as a *query expression*, consists of a combination of query clauses that identify the data sources and iteration variables for the query. A query expression can also include instructions for sorting, filtering, grouping, and joining, or calculations to apply to the source data. Query expression syntax resembles the syntax of SQL; therefore, you may find much of the syntax familiar.  
  
 A query expression starts with a `From` clause. This clause identifies the source data for a query and the variables that are used to refer to each element of the source data individually. These variables are named *range variables* or *iteration variables*. The `From` clause is required for a query, except for `Aggregate` queries, where the `From` clause is optional. After the scope and source of the query are identified in the `From` or `Aggregate` clauses, you can include any combination of query clauses to refine the query. For details about query clauses, see Visual Basic LINQ Query Operators later in this topic. For example, the following query identifies a source collection of customer data as the `customers` variable, and an iteration variable named `cust`.  
  
 [!code-vb[VbVbalrIntroToLINQ#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/class2.vb#2)]  
  
 This example is a valid query by itself; however, the query becomes far more powerful when you add more query clauses to refine the result. For example, you can add a `Where` clause to filter the result by one or more values. Query expressions are a single line of code; you can just append additional query clauses to the end of the query. You can break up a query across multiple lines of text to improve readability by using the underscore (\_) line-continuation character. The following code example shows an example of a query that includes a `Where` clause.  
  
 [!code-vb[VbVbalrIntroToLINQ#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/class2.vb#3)]  
  
 Another powerful query clause is the `Select` clause, which enables you to return only selected fields from the data source. LINQ queries return enumerable collections of strongly typed objects. A query can return a collection of anonymous types or named types. You can use the `Select` clause to return only a single field from the data source. When you do this, the type of the collection returned is the type of that single field. You can also use the `Select` clause to return multiple fields from the data source. When you do this, the type of the collection returned is a new anonymous type. You can also match the fields returned by the query to the fields of a specified named type. The following code example shows a query expression that returns a collection of anonymous types that have members populated with data from the selected fields from the data source.  
  
 [!code-vb[VbVbalrIntroToLINQ#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/class2.vb#4)]  
  
 LINQ queries can also be used to combine multiple sources of data and return a single result. This can be done with one or more `From` clauses, or by using the `Join` or `Group Join` query clauses. The following code example shows a query expression that combines customer and order data and returns a collection of anonymous types containing customer and order data.  
  
 [!code-vb[VbVbalrIntroToLINQ#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/class2.vb#5)]  
  
 You can use the `Group Join` clause to create a hierarchical query result that contains a collection of customer objects. Each customer object has a property that contains a collection of all orders for that customer. The following code example shows a query expression that combines customer and order data as a hierarchical result and returns a collection of anonymous types. The query returns a type that includes a `CustomerOrders` property that contains a collection of order data for the customer. It also includes an `OrderTotal` property that contains the sum of the totals for all the orders for that customer. (This query is equivalent to a LEFT OUTER JOIN.)  
  
 [!code-vb[VbVbalrIntroToLINQ#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/class2.vb#6)]  
  
 There are several additional LINQ query operators that you can use to create powerful query expressions. The next section of this topic discusses the various query clauses that you can include in a query expression. For details about Visual Basic query clauses, see [Queries](../../../language-reference/queries/index.md).  
  
## Visual Basic LINQ query operators  

The classes in the <xref:System.Linq> namespace and the other namespaces that support LINQ queries include methods that you can call to create and refine queries based on the needs of your application. Visual Basic includes keywords for the following common query clauses. For details about Visual Basic query clauses, see [Queries](../../../language-reference/queries/index.md).

### From clause

Either a [`From` clause](../../../language-reference/queries/from-clause.md) or an `Aggregate` clause is required to begin a query. A `From` clause specifies a source collection and an iteration variable for a query. For example:

 [!code-vb[VbVbalrIntroToLINQ#7](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#7)]

### Select clause

Optional. A [`Select` clause](../../../language-reference/queries/select-clause.md) declares a set of iteration variables for a query. For example:

 [!code-vb[VbVbalrIntroToLINQ#8](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#8)]

If a `Select` clause is not specified, the iteration variables for the query consist of the iteration variables specified by the `From` or `Aggregate` clause.

### Where clause

Optional. A [`Where` clause](../../../language-reference/queries/where-clause.md) specifies a filtering condition for a query. For example:

 [!code-vb[VbVbalrIntroToLINQ#9](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#9)]

### Order By clause

Optional. An [`Order By` clause](../../../language-reference/queries/order-by-clause.md) specifies the sort order for columns in a query. For example:

 [!code-vb[VbVbalrIntroToLINQ#10](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#10)]

### Join clause

Optional. A [`Join` clause](../../../language-reference/queries/join-clause.md) combines two collections into a single collection. For example:

 [!code-vb[VbVbalrIntroToLINQ#11](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#11)]

### Group By clause

Optional. A [`Group By` clause](../../../language-reference/queries/group-by-clause.md) groups the elements of a query result. It can be used to apply aggregate functions to each group. For example:

 [!code-vb[VbVbalrIntroToLINQ#12](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#12)]

### Group Join clause

Optional. A [`Group Join` clause](../../../language-reference/queries/group-join-clause.md) combines two collections into a single hierarchical collection. For example:

 [!code-vb[VbVbalrIntroToLINQ#13](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#13)]

### Aggregate clause

Either an [`Aggregate` clause](../../../language-reference/queries/aggregate-clause.md) or a `From` clause is required to begin a query. An `Aggregate` clause applies one or more aggregate functions to a collection. For example, you can use the `Aggregate` clause to calculate a sum for all the elements returned by a query, as the following example does.

 [!code-vb[VbVbalrIntroToLINQ#14](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#14)]

You can also use the `Aggregate` clause to modify a query. For example, you can use the `Aggregate` clause to perform a calculation on a related query collection. For example:

 [!code-vb[VbVbalrIntroToLINQ#15](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#15)]

### Let clause

Optional. A [`Let` clause](../../../language-reference/queries/let-clause.md) computes a value and assigns it to a new variable in the query. For example:

 [!code-vb[VbVbalrIntroToLINQ#16](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#16)]

### Distinct clause

Optional. A `Distinct` clause restricts the values of the current iteration variable to eliminate duplicate values in query results. For example:

 [!code-vb[VbVbalrIntroToLINQ#17](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#17)]

### Skip clause

Optional. A [`Skip` clause](../../../language-reference/queries/skip-clause.md) bypasses a specified number of elements in a collection and then returns the remaining elements. For example:

 [!code-vb[VbVbalrIntroToLINQ#18](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#18)]

### Skip While clause

Optional. A [`Skip While` clause](../../../language-reference/queries/skip-while-clause.md) bypasses elements in a collection as long as a specified condition is `true` and then returns the remaining elements. For example:

 [!code-vb[VbVbalrIntroToLINQ#19](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#19)]

### Take clause

Optional. A [`Take` clause](../../../language-reference/queries/take-clause.md) returns a specified number of contiguous elements from the start of a collection. For example:

 [!code-vb[VbVbalrIntroToLINQ#20](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#20)]

### Take While clause

Optional. A [`Take While` clause](../../../language-reference/queries/take-while-clause.md) includes elements in a collection as long as a specified condition is `true` and bypasses the remaining elements. For example:

 [!code-vb[VbVbalrIntroToLINQ#21](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#21)]
  
## Use additional LINQ query features  
  
You can use additional LINQ query features by calling members of the enumerable and queryable types provided by LINQ. You can use these additional capabilities by calling a particular query operator on the result of a query expression. For example, the following example uses the <xref:System.Linq.Enumerable.Union%2A?displayProperty=nameWithType> method to combine the results of two queries into one query result. It uses the <xref:System.Linq.Enumerable.ToList%2A?displayProperty=nameWithType> method to return the query result as a generic list.
  
 [!code-vb[VbVbalrIntroToLINQ#22](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrIntroToLINQ/VB/Class1.vb#22)]  
  
 For details about additional LINQ capabilities, see [Standard Query Operators Overview](../../concepts/linq/standard-query-operators-overview.md).  
  
## Connect to a database by using LINQ to SQL  

 In Visual Basic, you identify the SQL Server database objects, such as tables, views, and stored procedures, that you want to access by using a LINQ to SQL file. A LINQ to SQL file has an extension of .dbml.  
  
 When you have a valid connection to a SQL Server database, you can add a **LINQ to SQL Classes** item template to your project. This will display the Object Relational Designer (O/R designer). The O/R Designer enables you to drag the items that you want to access in your code from the **Server Explorer**/**Database Explorer** onto the designer surface. The LINQ to SQL file adds a <xref:System.Data.Linq.DataContext> object to your project. This object includes properties and collections for the tables and views that you want access to, and methods for the stored procedures that you want to call. After you have saved your changes to the LINQ to SQL (.dbml) file, you can access these objects in your code by referencing the <xref:System.Data.Linq.DataContext> object that is defined by the O/R Designer. The <xref:System.Data.Linq.DataContext> object for your project is named based on the name of your LINQ to SQL file. For example, a LINQ to SQL file that is named Northwind.dbml will create a <xref:System.Data.Linq.DataContext> object named `NorthwindDataContext`.  
  
 For examples with step-by-step instructions, see [How to: Query a Database](how-to-query-a-database-by-using-linq.md) and [How to: Call a Stored Procedure](how-to-call-a-stored-procedure-by-using-linq.md).  
  
## Visual Basic features that support LINQ  

 Visual Basic includes other notable features that make the use of LINQ simple and reduce the amount of code that you must write to perform LINQ queries. These include the following:  
  
- **Anonymous types**, which enable you to create a new type based on a query result.  
  
- **Implicitly typed variables**, which enable you to defer specifying a type and let the compiler infer the type based on the query result.  
  
- **Extension methods**, which enable you to extend an existing type with your own methods without modifying the type itself.  
  
 For details, see [Visual Basic Features That Support LINQ](../../concepts/linq/features-that-support-linq.md).  
  
## Deferred and immediate query execution

 Query execution is separate from creating a query. After a query is created, its execution is triggered by a separate mechanism. A query can be executed as soon as it is defined (*immediate execution*), or the definition can be stored and the query can be executed later (*deferred execution*).  
  
 By default, when you create a query, the query itself does not execute immediately. Instead, the query definition is stored in the variable that is used to reference the query result. When the query result variable is accessed later in code, such as in a `For…Next` loop, the query is executed. This process is referred to as *deferred execution*.  
  
 Queries can also be executed when they are defined, which is referred to as *immediate execution*. You can trigger immediate execution by applying a method that requires access to individual elements of the query result. This can be the result of including an aggregate function, such as `Count`, `Sum`, `Average`, `Min`, or `Max`. For more information about aggregate functions, see [Aggregate Clause](../../../language-reference/queries/aggregate-clause.md).  
  
 Using the `ToList` or `ToArray` methods will also force immediate execution. This can be useful when you want to execute the query immediately and cache the results. For more information about these methods, see [Converting Data Types](../../concepts/linq/converting-data-types.md).  
  
 For more information about query execution, see [Writing Your First LINQ Query](../../concepts/linq/writing-your-first-linq-query.md).  
  
## XML in Visual Basic  

 The XML features in Visual Basic include XML literals and XML axis properties, which enable you easily to create, access, query, and modify XML in your code. XML literals enable you to write XML directly in your code. The Visual Basic compiler treats the XML as a first-class data object.  
  
 The following code example shows how to create an XML element, access its sub-elements and attributes, and query the contents of the element by using LINQ.  
  
 [!code-vb[VbXmlSamples#8](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples3.vb#8)]  
  
 For more information, see [XML](../xml/index.md).  
  
## Related resources  
  
|Topic|Description|  
|---|---|  
|[XML](../xml/index.md)|Describes the XML features in Visual Basic that can be queried and that enable you to include XML as first-class data objects in your Visual Basic code.|  
|[Queries](../../../language-reference/queries/index.md)|Provides reference information about the query clauses that are available in Visual Basic.|  
|[LINQ (Language-Integrated Query)](../../concepts/linq/index.md)|Includes general information, programming guidance, and samples for LINQ.|  
|[LINQ to SQL](../../../../framework/data/adonet/sql/linq/index.md)|Includes general information, programming guidance, and samples for LINQ to SQL.|  
|[LINQ to Objects](../../concepts/linq/linq-to-objects.md)|Includes general information, programming guidance, and samples for LINQ to Objects.|  
|[LINQ to ADO.NET (Portal Page)](../../concepts/linq/linq-to-adonet-portal-page.md)|Includes links to general information, programming guidance, and samples for LINQ to ADO.NET.|  
|[LINQ to XML](../../../../standard/linq/linq-xml-overview.md)|Includes general information, programming guidance, and samples for LINQ to XML.|  
  
## How to and walkthrough topics

 [How to: Query a Database](how-to-query-a-database-by-using-linq.md)  
  
 [How to: Call a Stored Procedure](how-to-call-a-stored-procedure-by-using-linq.md)  
  
 [How to: Modify Data in a Database](how-to-modify-data-in-a-database-by-using-linq.md)  
  
 [How to: Combine Data with Joins](how-to-combine-data-with-linq-by-using-joins.md)  
  
 [How to: Sort Query Results](how-to-sort-query-results-by-using-linq.md)  
  
 [How to: Filter Query Results](how-to-filter-query-results-by-using-linq.md)  
  
 [How to: Count, Sum, or Average Data](how-to-count-sum-or-average-data-by-using-linq.md)  
  
 [How to: Find the Minimum or Maximum Value in a Query Result](how-to-find-the-minimum-or-maximum-value-in-a-query-result.md)  
  
 [How to: Assign stored procedures to perform updates, inserts, and deletes (O/R Designer)](/visualstudio/data-tools/how-to-assign-stored-procedures-to-perform-updates-inserts-and-deletes-o-r-designer)  
  
## Featured book chapters  

 [Chapter 17: LINQ](/previous-versions/visualstudio/visual-studio-2008/ff652502(v=orm.10)) in [Programming Visual Basic 2008](/previous-versions/visualstudio/visual-studio-2008/ff652504(v=orm.10))  
  
## See also

- [LINQ (Language-Integrated Query)](../../concepts/linq/index.md)
- [Overview of LINQ to XML in Visual Basic](../xml/overview-of-linq-to-xml.md)
- [LINQ to DataSet Overview](../../../../framework/data/adonet/linq-to-dataset-overview.md)
- [LINQ to SQL](../../../../framework/data/adonet/sql/linq/index.md)
- [LINQ to SQL Tools in Visual Studio](/visualstudio/data-tools/linq-to-sql-tools-in-visual-studio2)
- [DataContext Methods (O/R Designer)](/visualstudio/data-tools/datacontext-methods-o-r-designer)
