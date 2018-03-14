---
title: "Responsibilities of the Developer In Overriding Default Behavior"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c6909ddd-e053-46a8-980c-0e12a9797be1
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Responsibilities of the Developer In Overriding Default Behavior
[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not enforce the following requirements, but behavior is undefined if these requirements are not satisfied.  
  
-   The overriding method must not call <xref:System.Data.Linq.DataContext.SubmitChanges%2A> or <xref:System.Data.Linq.Table%601.Attach%2A>. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] throws an exception if these methods are called in an override method.  
  
-   Override methods cannot be used to start, commit, or stop a transaction. The <xref:System.Data.Linq.DataContext.SubmitChanges%2A> operation is performed under a transaction. An inner nested transaction can interfere with the outer transaction. Load override methods can start a transaction only after they determine that the operation is not being performed in a <xref:System.Transactions.Transaction>.  
  
-   Override methods are expected to follow the applicable optimistic concurrency mapping. The override method is expected to throw a <xref:System.Data.Linq.ChangeConflictException> when an optimistic concurrency conflict occurs. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] catches this exception so that you can correctly process the <xref:System.Data.Linq.DataContext.SubmitChanges%2A> option provided on <xref:System.Data.Linq.DataContext.SubmitChanges%2A>.  
  
-   Create (`Insert`) and `Update` override methods are expected to flow back the values for database-generated columns to corresponding object members when the operation is successfully completed.  
  
     For example, if `Order.OrderID` is mapped to an identity column (*autoincrement* primary key), then the `InsertOrder()` override method must retrieve the database-generated ID and set the `Order.OrderID` member to that ID. Likewise, timestamp members must be updated to the database-generated timestamp values to make sure that the updated objects are consistent. Failure to propagate the database-generated values can cause an inconsistency between the database and the objects tracked by the <xref:System.Data.Linq.DataContext>.  
  
-   It is the user's responsibility to invoke the correct dynamic API. For example, in the update override method, only the <xref:System.Data.Linq.DataContext.ExecuteDynamicUpdate%2A> can be called. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not detect or verify whether the invoked dynamic method matches the applicable operation. If an inapplicable method is called (for example, <xref:System.Data.Linq.DataContext.ExecuteDynamicDelete%2A> for an object to be updated), the results are undefined.  
  
-   Finally, the overriding method is expected to perform the stated operation. The semantics of [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] operations such as eager loading, deferred loading, and <xref:System.Data.Linq.DataContext.SubmitChanges%2A>) require the overrides to provide the stated service. For example, a load override that just returns an empty collection without checking the contents in the database will likely lead to inconsistent data.  
  
## See Also  
 [Customizing Insert, Update, and Delete Operations](../../../../../../docs/framework/data/adonet/sql/linq/customizing-insert-update-and-delete-operations.md)
