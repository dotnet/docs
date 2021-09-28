---
description: "Learn more about: How to: Specify Which Members are Tested for Concurrency Conflicts"
title: "How to: Specify Which Members are Tested for Concurrency Conflicts"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: d2cda293-1e2f-4878-af0e-5aaf0d092120
---
# How to: Specify Which Members are Tested for Concurrency Conflicts

Apply one of three enums to the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] <xref:System.Data.Linq.Mapping.ColumnAttribute.UpdateCheck%2A> property on a <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute to specify which members are to be included in update checks for the detection of optimistic concurrency conflicts.  
  
 The <xref:System.Data.Linq.Mapping.ColumnAttribute.UpdateCheck%2A> property (mapped at design time) is used together with run-time concurrency features in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)]. For more information, see [Optimistic Concurrency: Overview](optimistic-concurrency-overview.md).  
  
> [!NOTE]
> Original member values are compared with the current database state as long as no member is designated as `IsVersion=true`. For more information, see <xref:System.Data.Linq.Mapping.ColumnAttribute.IsVersion%2A>.  
  
 For code examples, see <xref:System.Data.Linq.Mapping.ColumnAttribute.UpdateCheck%2A>.  
  
### To always use this member for detecting conflicts  
  
1. Add the <xref:System.Data.Linq.Mapping.ColumnAttribute.UpdateCheck%2A> property to the <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute.  
  
2. Set the <xref:System.Data.Linq.Mapping.ColumnAttribute.UpdateCheck%2A> property value to `Always`.  
  
### To never use this member for detecting conflicts  
  
1. Add the <xref:System.Data.Linq.Mapping.ColumnAttribute.UpdateCheck%2A> property to the <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute.  
  
2. Set the <xref:System.Data.Linq.Mapping.ColumnAttribute.UpdateCheck%2A> property value to `Never`.  
  
### To use this member for detecting conflicts only when the application has changed the value of the member  
  
1. Add the <xref:System.Data.Linq.Mapping.ColumnAttribute.UpdateCheck%2A> property to the <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute.  
  
2. Set the <xref:System.Data.Linq.Mapping.ColumnAttribute.UpdateCheck%2A> property value to `WhenChanged`.  
  
## Example  

 The following example specifies that `HomePage` objects should never be tested during update checks. For more information, see <xref:System.Data.Linq.Mapping.ColumnAttribute.UpdateCheck%2A>.  
  
 [!code-csharp[System.Data.Linq.Mapping.UpdateCheck#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/system.data.linq.mapping.updatecheck/cs/northwind.cs#1)]
 [!code-vb[System.Data.Linq.Mapping.UpdateCheck#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/system.data.linq.mapping.updatecheck/vb/northwind.vb#1)]  
  
## See also

- [How to: Manage Change Conflicts](how-to-manage-change-conflicts.md)
- [Making and Submitting Data Changes](making-and-submitting-data-changes.md)
