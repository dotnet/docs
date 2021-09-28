---
description: "Learn more about: Inheritance Support"
title: "Inheritance Support"
ms.date: "03/30/2017"
ms.assetid: 19bb2794-b4e7-402e-8307-1d1517381a08
---
# Inheritance Support

[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] supports *single-table mapping*. In other words, a complete inheritance hierarchy is stored in a single database table. The table contains the flattened union of all possible data columns for the whole hierarchy. (A union is the result of combining two tables into one table that has the rows that were present in either of the original tables.) Each row has nulls in the columns that do not apply to the type of the instance represented by the row.  
  
 The single-table mapping strategy is the simplest representation of inheritance and provides good performance characteristics for many different categories of queries.  
  
 To implement this mapping in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], you must specify the attributes and attribute properties on the root class of the inheritance hierarchy. For more information, see [How to: Map Inheritance Hierarchies](how-to-map-inheritance-hierarchies.md).  
  
 Developers using Visual Studio can also use the Object Relational Designer to map inheritance hierarchies.  
  
## See also

- [Background Information](background-information.md)
