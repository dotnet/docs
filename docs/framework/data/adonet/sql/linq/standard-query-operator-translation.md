---
title: "Standard Query Operator Translation"
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
ms.assetid: a60c30fa-1e68-45fe-b984-f6abb9ede40e
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Standard Query Operator Translation
[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] translates Standard Query Operators to SQL commands. The query processor of the database determines the execution semantics of SQL translation.  
  
 Standard Query Operators are defined against *sequences*. A sequence is *ordered* and relies on reference identity for each element of the sequence. For more information, see [Standard Query Operators Overview](http://msdn.microsoft.com/library/24cda21e-8af8-4632-b519-c404a839b9b2).  
  
 SQL deals primarily with *unordered sets of values*. Ordering is typically an explicitly stated, post-processing operation that is applied to the final result of a query rather than to intermediate results. Identity is defined by values. For this reason, SQL queries are understood to deal with multisets (*bags*) instead of *sets*.  
  
 The following paragraphs describe the differences between the Standard Query Operators and their SQL translation for the SQL Server provider for [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)].  
  
## Operator Support  
  
### Concat  
 The <xref:System.Linq.Enumerable.Concat%2A> method is defined for ordered multisets where the order of the receiver and the order of the argument are the same. <xref:System.Linq.Enumerable.Concat%2A> works as `UNION ALL` over the multisets followed by the common order.  
  
 The final step is ordering in SQL before results are produced. <xref:System.Linq.Enumerable.Concat%2A> does not preserve the order of its arguments. To ensure appropriate ordering, you must explicitly order the results of <xref:System.Linq.Enumerable.Concat%2A>.  
  
### Intersect, Except, Union  
 The <xref:System.Linq.Enumerable.Intersect%2A> and <xref:System.Linq.Enumerable.Except%2A> methods are well defined only on sets. The semantics for multisets is undefined.  
  
 The <xref:System.Linq.Enumerable.Union%2A> method is defined for multisets as the unordered concatenation of the multisets (effectively the result of the UNION ALL clause in SQL).  
  
### Take, Skip  
 <xref:System.Linq.Enumerable.Take%2A> and <xref:System.Linq.Enumerable.Skip%2A> methods are well defined only against *ordered sets*. The semantics for unordered sets or multisets are undefined.  
  
> [!NOTE]
>  <xref:System.Linq.Enumerable.Take%2A> and <xref:System.Linq.Enumerable.Skip%2A> have certain limitations when they are used in queries against SQL Server 2000. For more information, see the "Skip and Take Exceptions in SQL Server 2000" entry in [Troubleshooting](../../../../../../docs/framework/data/adonet/sql/linq/troubleshooting.md).  
  
 Because of limitations on ordering in SQL, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] tries to move the ordering of the argument of these methods to the result of the method. For example, consider the following [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] query:  
  
 [!code-csharp[DLinqSQOTranslation#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqSQOTranslation/cs/Program.cs#1)]
 [!code-vb[DLinqSQOTranslation#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqSQOTranslation/vb/Module1.vb#1)]  
  
 The generated SQL for this code moves the ordering to the end, as follows:  
  
```  
SELECT TOP 1 [t0].[CustomerID], [t0].[CompanyName],  
FROM [Customers] AS [t0]  
WHERE (NOT (EXISTS(  
    SELECT NULL AS [EMPTY]  
    FROM (  
        SELECT TOP 1 [t1].[CustomerID]  
        FROM [Customers] AS [t1]  
        WHERE [t1].[City] = @p0  
        ORDER BY [t1].[CustomerID]  
        ) AS [t2]  
    WHERE [t0].[CustomerID] = [t2].[CustomerID]  
    ))) AND ([t0].[City] = @p1)  
ORDER BY [t0].[CustomerID]  
```  
  
 It becomes obvious that all the specified ordering must be consistent when <xref:System.Linq.Enumerable.Take%2A> and <xref:System.Linq.Enumerable.Skip%2A> are chained together. Otherwise, the results are undefined.  
  
 Both <xref:System.Linq.Enumerable.Take%2A> and <xref:System.Linq.Enumerable.Skip%2A> are well-defined for non-negative, constant integral arguments based on the Standard Query Operator specification.  
  
### Operators with No Translation  
 The following methods are not translated by [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)]. The most common reason is the difference between unordered multisets and sequences.  
  
|Operators|Rationale|  
|---------------|---------------|  
|<xref:System.Linq.Enumerable.TakeWhile%2A>, <xref:System.Linq.Enumerable.SkipWhile%2A>|SQL queries operate on multisets, not on sequences. `ORDER BY` must be the last clause applied to the results. For this reason, there is no general-purpose translation for these two methods.|  
|<xref:System.Linq.Enumerable.Reverse%2A>|Translation of this method is possible for an ordered set but is not currently translated by [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)].|  
|<xref:System.Linq.Enumerable.Last%2A>, <xref:System.Linq.Enumerable.LastOrDefault%2A>|Translation of these methods is possible for an ordered set but is not currently translated by [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)].|  
|<xref:System.Linq.Enumerable.ElementAt%2A>, <xref:System.Linq.Enumerable.ElementAtOrDefault%2A>|SQL queries operate on multisets, not on indexable sequences.|  
|<xref:System.Linq.Enumerable.DefaultIfEmpty%2A> (overload with default arg)|In general, a default value cannot be specified for an arbitrary tuple. Null values for tuples are possible in some cases through outer joins.|  
  
## Expression Translation  
  
### Null semantics  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not impose null comparison semantics on SQL. Comparison operators are syntactically translated to their SQL equivalents. For this reason, the semantics reflect SQL semantics that are defined by server or connection settings. For example, two null values are considered unequal under default SQL Server settings, but you can change the settings to change the semantics. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not consider server settings when it translates queries.  
  
 A comparison with the literal null is translated to the appropriate SQL version (`is null` or `is not null`).  
  
 The value of `null` in collation is defined by SQL Server. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not change the collation.  
  
### Aggregates  
 The Standard Query Operator aggregate method <xref:System.Linq.Enumerable.Sum%2A> evaluates to zero for an empty sequence or for a sequence that contains only nulls. In [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], the semantics of SQL are left unchanged, and <xref:System.Linq.Enumerable.Sum%2A> evaluates to `null` instead of zero for an empty sequence or for a sequence that contains only nulls.  
  
 SQL limitations on intermediate results apply to aggregates in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)]. The <xref:System.Linq.Enumerable.Sum%2A> of 32-bit integer quantities is not computed by using 64-bit results. Overflow might occur for a [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] translation of <xref:System.Linq.Enumerable.Sum%2A>, even if the Standard Query Operator implementation does not cause an overflow for the corresponding in-memory sequence.  
  
 Likewise, the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] translation of <xref:System.Linq.Enumerable.Average%2A> of integer values is computed as an `integer`, not as a `double`.  
  
### Entity Arguments  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] enables entity types to be used in the <xref:System.Linq.Enumerable.GroupBy%2A> and <xref:System.Linq.Enumerable.OrderBy%2A> methods. In the translation of these operators, the use of an argument of a type is considered to be the equivalent to specifying all members of that type. For example, the following code is equivalent:  
  
 [!code-csharp[DLinqSQOTranslation#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqSQOTranslation/cs/Program.cs#2)]
 [!code-vb[DLinqSQOTranslation#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqSQOTranslation/vb/Module1.vb#2)]  
  
### Equatable / Comparable Arguments  
 Equality of arguments is required in the implementation of the following methods:  
  
 <xref:System.Linq.Enumerable.Contains%2A>  
  
 <xref:System.Linq.Enumerable.Skip%2A>  
  
 <xref:System.Linq.Enumerable.Union%2A>  
  
 <xref:System.Linq.Enumerable.Intersect%2A>  
  
 <xref:System.Linq.Enumerable.Except%2A>  
  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] supports equality and comparison for *flat* arguments, but not for arguments that are or contain sequences. A flat argument is a type that can be mapped to a SQL row. A projection of one or more entity types that can be statically determined not to contain a sequence is considered a flat argument.  
  
 Following are examples of flat arguments:  
  
 [!code-csharp[DLinqSQOTranslation#3](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqSQOTranslation/cs/Program.cs#3)]
 [!code-vb[DLinqSQOTranslation#3](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqSQOTranslation/vb/Module1.vb#3)]  
  
 The following are examples of non-flat (hierarchical) arguments.  
  
 [!code-csharp[DLinqSQOTranslation#4](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqSQOTranslation/cs/Program.cs#4)]
 [!code-vb[DLinqSQOTranslation#4](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqSQOTranslation/vb/Module1.vb#4)]  
  
### Visual Basic Function Translation  
 The following helper functions that are used by the Visual Basic compiler are translated to corresponding SQL operators and functions:  
  
 `CompareString`  
  
 `DateTime.Compare`  
  
 `Decimal.Compare`  
  
 `IIf (in Microsoft.VisualBasic.Interaction)`  
  
 Conversion methods:  
  
|||||  
|-|-|-|-|  
|ToBoolean|ToSByte|ToByte|ToChar|  
|ToCharArrayRankOne|ToDate|ToDecimal|ToDouble|  
|ToInteger|ToUInteger|ToLong|ToULong|  
|ToShort|ToUShort|ToSingle|ToString|  
  
## Inheritance Support  
  
### Inheritance Mapping Restrictions  
 For more information, see [How to: Map Inheritance Hierarchies](../../../../../../docs/framework/data/adonet/sql/linq/how-to-map-inheritance-hierarchies.md).  
  
### Inheritance in Queries  
 C# casts are supported only in projection. Casts that are used elsewhere are not translated and are ignored. Aside from SQL function names, SQL really only performs the equivalent of the common language runtime (CLR) <xref:System.Convert>. That is, SQL can change the value of one type to another. There is no equivalent of CLR cast because there is no concept of reinterpreting the same bits as those of another type. That is why a C# cast works only locally. It is not remoted.  
  
 The operators, `is` and `as`, and the `GetType` method are not restricted to the `Select` operator. They can be used in other query operators also.  
  
## SQL Server 2008 Support  
 Starting with the .NET Framework 3.5 SP1, LINQ to SQL supports mapping to new date and time types introduced with SQL Server 2008. But, there are some limitations to the LINQ to SQL query operators that you can use when operating against values mapped to these new types.  
  
### Unsupported Query Operators  
 The following query operators are not supported on values mapped to the new SQL Server date and time types: `DATETIME2`, `DATE`, `TIME`, and `DATETIMEOFFSET`.  
  
-   `Aggregate`  
  
-   `Average`  
  
-   `LastOrDefault`  
  
-   `OfType`  
  
-   `Sum`  
  
 For more information about mapping to these SQL Server date and time types, see [SQL-CLR Type Mapping](../../../../../../docs/framework/data/adonet/sql/linq/sql-clr-type-mapping.md).  
  
## SQL Server 2005 Support  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not support the following SQL Server 2005 features:  
  
-   Stored procedures written for SQL CLR.  
  
-   User-defined type.  
  
-   XML query features.  
  
## SQL Server 2000 Support  
 The following [!INCLUDE[ss2k](../../../../../../includes/ss2k-md.md)] limitations (compared to [!INCLUDE[sqprsqext](../../../../../../includes/sqprsqext-md.md)]) affect [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] support.  
  
### Cross Apply and Outer Apply Operators  
 These operators are not available in [!INCLUDE[ss2k](../../../../../../includes/ss2k-md.md)]. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] tries a series of rewrites to replace them with appropriate joins.  
  
 `Cross Apply` and `Outer Apply` are generated for relationship navigations. The set of queries for which such rewrites are possible is not well defined. For this reason, the minimal set of queries that is supported for [!INCLUDE[ss2k](../../../../../../includes/ss2k-md.md)] is the set that does not involve relationship navigation.  
  
### text / ntext  
 Data types `text` / `ntext` cannot be used in certain query operations against `varchar(max)` / `nvarchar(max)`, which are supported by [!INCLUDE[sqprsqext](../../../../../../includes/sqprsqext-md.md)].  
  
 No resolution is available for this limitation. Specifically, you cannot use `Distinct()` on any result that contains members that are mapped to `text` or `ntext` columns.  
  
### Behavior Triggered by Nested Queries  
 [!INCLUDE[ss2k](../../../../../../includes/ss2k-md.md)] (through SP4) binder has some idiosyncrasies that are triggered by nested queries. The set of SQL queries that triggers these idiosyncrasies is not well defined. For this reason, you cannot define the set of [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] queries that might cause SQL Server exceptions.  
  
### Skip and Take Operators  
 <xref:System.Linq.Enumerable.Take%2A> and <xref:System.Linq.Enumerable.Skip%2A> have certain limitations when they are used in queries against [!INCLUDE[ss2k](../../../../../../includes/ss2k-md.md)]. For more information, see the "Skip and Take Exceptions in SQL Server 2000" entry in [Troubleshooting](../../../../../../docs/framework/data/adonet/sql/linq/troubleshooting.md).  
  
## Object Materialization  
 Materialization creates CLR objects from rows that are returned by one or more SQL queries.  
  
-   The following calls are *executed locally* as a part of materialization:  
  
    -   Constructors  
  
    -   `ToString` methods in projections  
  
    -   Type casts in projections  
  
-   Methods that follow the <xref:System.Linq.Enumerable.AsEnumerable%2A> method are *executed locally*. This method does not cause immediate execution.  
  
-   You can use a `struct` as the return type of a query result or as a member of the result type. Entities are required to be classes. Anonymous types are materialized as class instances, but named structs (non-entities) can be used in projection.  
  
-   A member of the return type of a query result can be of type <xref:System.Linq.IQueryable%601>. It is materialized as a local collection.  
  
-   The following methods cause the *immediate materialization* of the sequence that the methods are applied to:  
  
    -   <xref:System.Linq.Enumerable.ToList%2A>  
  
    -   <xref:System.Linq.Enumerable.ToDictionary%2A>  
  
    -   <xref:System.Linq.Enumerable.ToArray%2A>  
  
## See Also  
 [Reference](../../../../../../docs/framework/data/adonet/sql/linq/reference.md)  
 [Return Or Skip Elements in a Sequence](../../../../../../docs/framework/data/adonet/sql/linq/return-or-skip-elements-in-a-sequence.md)  
 [Concatenate Two Sequences](../../../../../../docs/framework/data/adonet/sql/linq/concatenate-two-sequences.md)  
 [Return the Set Difference Between Two Sequences](../../../../../../docs/framework/data/adonet/sql/linq/return-the-set-difference-between-two-sequences.md)  
 [Return the Set Intersection of Two Sequences](../../../../../../docs/framework/data/adonet/sql/linq/return-the-set-intersection-of-two-sequences.md)  
 [Return the Set Union of Two Sequences](../../../../../../docs/framework/data/adonet/sql/linq/return-the-set-union-of-two-sequences.md)
