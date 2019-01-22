---
title: "Null Semantics"
ms.date: "03/30/2017"
ms.assetid: a97017ae-d634-4cf3-bbaf-054a528fd683
---
# Null Semantics
The following table provides links to various parts of the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] documentation where `null` (`Nothing` in Visual Basic) issues are discussed.  
  
|Topic|Description|  
|-----------|-----------------|  
|[SQL-CLR Type Mismatches](../../../../../../docs/framework/data/adonet/sql/linq/sql-clr-type-mismatches.md)|The "Null Semantics" section of this topic includes discussion of the three-state SQL Boolean versus the two-state common language runtime (CLR) <xref:System.Boolean>, the literal `Nothing` (Visual Basic) and `null` (C#), and other similar issues.|  
|[Standard Query Operator Translation](../../../../../../docs/framework/data/adonet/sql/linq/standard-query-operator-translation.md)|The "Null Semantics" section of this topic describes null comparison semantics in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)].|  
|[System.String Methods](../../../../../../docs/framework/data/adonet/sql/linq/system-string-methods.md)|The "Differences from .NET" section of this topic describes how a return of 0 from <xref:System.String.LastIndexOf%2A> might mean either that the string is null or that the found position is 0.|  
|[Compute the Sum of Values in a Numeric Sequence](../../../../../../docs/framework/data/adonet/sql/linq/compute-the-sum-of-values-in-a-numeric-sequence.md)|Describes how the <xref:System.Linq.Enumerable.Sum%2A> operator evaluates to `null` (`Nothing` in Visual Basic) instead of 0 for a sequence that contains only nulls or for an empty sequence.|  
  
## See also
 [Data Types and Functions](../../../../../../docs/framework/data/adonet/sql/linq/data-types-and-functions.md)
