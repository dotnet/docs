---
title: "Object Identity"
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
ms.assetid: c788f2f9-65cc-4455-9907-e8388a268e00
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Object Identity
Objects in the runtime have unique identities. Two variables that refer to the same object actually refer to the same instance of the object. Because of this fact, changes that you make by way of a path through one variable are immediately visible through the other.  
  
 Rows in a relational database table do not have unique identities. Because each row has a unique primary key, no two rows share the same key value. However, this fact constrains only the contents of the database table.  
  
 In reality, data is most often brought out of the database and into a different tier, where an application works with it. This is the model that [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] supports. When data is brought out of the database as rows, you have no expectation that two rows that represent the same data actually correspond to the same row instances. If you query for a specific customer two times, you get two rows of data. Each row contains the same information.  
  
 With objects you expect something very different. You expect that if you ask the <xref:System.Data.Linq.DataContext> for the same information repeatedly, it will in fact give you the same object instance. You expect this behavior because objects have special meaning for your application and you expect them to behave like objects. You designed them as hierarchies or graphs. You expect to retrieve them as such and not to receive multitudes of replicated instances just because you asked for the same thing more than one time.  
  
 In [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], the <xref:System.Data.Linq.DataContext> manages object identity. Whenever you retrieve a new row from the database, the row is logged in an identity table by its primary key, and a new object is created. Whenever you retrieve that same row, the original object instance is handed back to the application. In this manner the <xref:System.Data.Linq.DataContext> translates the concept of identity as seen by the database (that is, primary keys) into the concept of identity seen by the language (that is, instances). The application only sees the object in the state that it was first retrieved. The new data, if different, is discarded. For more information, see [Retrieving Objects from the Identity Cache](../../../../../../docs/framework/data/adonet/sql/linq/retrieving-objects-from-the-identity-cache.md).  
  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] uses this approach to manage the integrity of local objects in order to support optimistic updates. Because the only changes that occur after the object is at first created are those made by the application, the intent of the application is clear. If changes by an outside party have occurred in the interim, they are identified at the time `SubmitChanges()` is called.  
  
> [!NOTE]
>  If the object requested by the query is easily identifiable as one already retrieved, no query is executed. The identity table acts as a cache of all previously retrieved objects.  
  
## Examples  
  
### Object Caching Example 1  
 In this example, if you execute the same query two times, you receive a reference to the same object in memory every time.  
  
 [!code-csharp[DLinqObjectIdentity#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqObjectIdentity/cs/Program.cs#1)]
 [!code-vb[DLinqObjectIdentity#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqObjectIdentity/vb/Module1.vb#1)]  
  
### Object Caching Example 2  
 In this example, if you execute different queries that return the same row from the database, you receive a reference to the same object in memory every time.  
  
 [!code-csharp[DLinqObjectIdentity#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqObjectIdentity/cs/Program.cs#2)]
 [!code-vb[DLinqObjectIdentity#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqObjectIdentity/vb/Module1.vb#2)]  
  
## See Also  
 [Background Information](../../../../../../docs/framework/data/adonet/sql/linq/background-information.md)
