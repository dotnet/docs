---
description: "Learn more about: Group By Clause (Visual Basic)"
title: "Group By Clause"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.QueryGroupByInto"
  - "vb.QueryGroupBy"
  - "vb.QueryGroupRef"
  - "vb.QueryGroupInto"
  - "vb.QueryGroup"
helpviewer_keywords: 
  - "queries [Visual Basic], Group By"
  - "Group By statement [Visual Basic]"
  - "Group By clause [Visual Basic]"
ms.assetid: b1b5dcea-6654-473b-a2db-01f7e4c265d7
---
# Group By Clause (Visual Basic)

Groups the elements of a query result. Can also be used to apply aggregate functions to each group. The grouping operation is based on one or more keys.  
  
## Syntax  
  
```vb  
Group [ listField1 [, listField2 [...] ] By keyExp1 [, keyExp2 [...] ]  
  Into aggregateList  
```  
  
## Parts  
  
- `listField1`, `listField2`  
  
     Optional. One or more fields of the query variable or variables that explicitly identify the fields to be included in the grouped result. If no fields are specified, all fields of the query variable or variables are included in the grouped result.  
  
- `keyExp1`  
  
     Required. An expression that identifies the key to use to determine the groups of elements. You can specify more than one key to specify a composite key.  
  
- `keyExp2`  
  
     Optional. One or more additional keys that are combined with `keyExp1` to create a composite key.  
  
- `aggregateList`  
  
     Required. One or more expressions that identify how the groups are aggregated. To identify a member name for the grouped results, use the `Group` keyword, which can be in either of the following forms:  
  
    ```vb  
    Into Group  
    ```  
  
     -or-  
  
    ```vb  
    Into <alias> = Group  
    ```  
  
     You can also include aggregate functions to apply to the group.  
  
## Remarks  

 You can use the `Group By` clause to break the results of a query into groups. The grouping is based on a key or a composite key consisting of multiple keys. Elements that are associated with matching key values are included in the same group.  
  
 You use the `aggregateList` parameter of the `Into` clause and the `Group` keyword to identify the member name that is used to reference the group. You can also include aggregate functions in the `Into` clause to compute values for the grouped elements. For a list of standard aggregate functions, see [Aggregate Clause](aggregate-clause.md).  
  
## Example  

 The following code example groups a list of customers based on their location (country/region) and provides a count of the customers in each group. The results are ordered by country/region name. The grouped results are ordered by city name.  
  
 [!code-vb[VbSimpleQuerySamples#11](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbSimpleQuerySamples/VB/QuerySamples1.vb#11)]  
  
## See also

- [Introduction to LINQ in Visual Basic](../../programming-guide/language-features/linq/introduction-to-linq.md)
- [Queries](index.md)
- [Select Clause](select-clause.md)
- [From Clause](from-clause.md)
- [Order By Clause](order-by-clause.md)
- [Aggregate Clause](aggregate-clause.md)
- [Group Join Clause](group-join-clause.md)
