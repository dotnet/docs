---
title: "Type System (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 818a505b-a196-41dd-aaac-2ccd5f7a2f1a
---
# Type System (Entity SQL)
[!INCLUDE[esql](../../../../../../includes/esql-md.md)] supports a number of types:  
  
- Primitive (simple) types such as `Int32` and `String.`  
  
- Nominal types that are defined in the schema, such as <xref:System.Data.Metadata.Edm.EntityType>, <xref:System.Data.Metadata.Edm.ComplexType>, and <xref:System.Data.Metadata.Edm.RelationshipType>.  
  
- Anonymous types that are not defined in the schema explicitly: <xref:System.Data.Metadata.Edm.CollectionType>, <xref:System.Data.Metadata.Edm.RowType>, and <xref:System.Data.Metadata.Edm.RefType>.  
  
 This section discusses the anonymous types that are not defined in the schema explicitly but are supported by Entity SQL. For information on primitive and nominal types, see [Conceptual Model Types (CSDL)](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec#conceptual-model-types-csdl).  
  
## Rows  
 The structure of a row depends on the sequence of typed and named members that the row consists of. A row type has no identity and cannot be inherited from. Instances of the same row type are equivalent if the members are respectively equivalent. Rows have no behavior beyond their structural equivalence and have no equivalent in the common language runtime. Queries can result in structures that contain rows or collections of rows. The API binding between the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] queries and the host language defines how rows are realized in the query that produced the result. For information on how to construct a row instance, see [Constructing Types](constructing-types-entity-sql.md).  
  
## Collections  
 Collection types represent zero or more instances of other objects. For information on how to construct collection, see [Constructing Types](constructing-types-entity-sql.md).  
  
## References  
 A reference is a logical pointer to a specific entity in a specific entity set.  
  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] supports the following operators to construct, deconstruct, and navigate through references:  
  
- [REF](ref-entity-sql.md)  
  
- [CREATEREF](createref-entity-sql.md)  
  
- [KEY](key-entity-sql.md)  
  
- [DEREF](deref-entity-sql.md)  
  
 You can navigate through a reference by using the member access (dot) operator(`.`). The following snippet extracts the Id property (of Order) by navigating through the r (reference) property.  
  
```sql  
select o2.r.Id   
from (select ref(o) as r from LOB.Orders as o) as o2   
```  
  
 If the reference value is null, or if the target of the reference does not exist, the result is null.  
  
## See also

- [Entity SQL Overview](entity-sql-overview.md)
- [Entity SQL Reference](entity-sql-reference.md)
- [CAST](cast-entity-sql.md)
- [CSDL, SSDL, and MSL Specifications](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec)
