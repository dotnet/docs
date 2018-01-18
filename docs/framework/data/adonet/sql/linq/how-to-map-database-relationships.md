---
title: "How to: Map Database Relationships"
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
ms.assetid: 538def39-8399-46fb-b02d-60ede4e050af
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# How to: Map Database Relationships
You can encode as property references in your entity class any data relationships that will always be the same. In the Northwind sample database, for example, because customers typically place orders, there is always a relationship in the model between customers and their orders.  
  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] defines an <xref:System.Data.Linq.Mapping.AssociationAttribute> attribute to help represent such relationships. This attribute is used together with the <xref:System.Data.Linq.EntitySet%601> and <xref:System.Data.Linq.EntityRef%601> types to represent what would be a foreign key relationship in a database. For more information, see the Association Attribute section of [Attribute-Based Mapping](../../../../../../docs/framework/data/adonet/sql/linq/attribute-based-mapping.md).  
  
> [!NOTE]
>  AssociationAttribute and ColumnAttribute Storage property values are case sensitive. For example, ensure that values used in the attribute for the AssociationAttribute.Storage property match the case for the corresponding property names used elsewhere in the code. This applies to all .NET programming languages, even those which are not typically case sensitive, including [!INCLUDE[vb_current_short](../../../../../../includes/vb-current-short-md.md)]. For more information about the Storage property, see <xref:System.Data.Linq.Mapping.DataAttribute.Storage%2A?displayProperty=nameWithType>.  
  
 Most relationships are one-to-many, as in the example later in this topic. You can also represent one-to-one and many-to-many relationships as follows:  
  
-   One-to-one: Represent this kind of relationship by including <xref:System.Data.Linq.EntitySet%601> on both sides.  
  
     For example, consider a `Customer`-`SecurityCode` relationship, created so that the customer's security code will not be found in the `Customer` table and can be accessed only by authorized persons.  
  
-   Many-to-many: In many-to-many relationships, the primary key of the link table (also named the *junction* table) is often formed by a composite of the foreign keys from the other two tables.  
  
     For example, consider an `Employee`-`Project` many-to-many relationship formed by using link table `EmployeeProject`. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] requires that such a relationship be modeled by using three classes: `Employee`, `Project`, and `EmployeeProject`. In this case, changing the relationship between an `Employee` and a `Project` can appear to require an update of the primary key `EmployeeProject`. However, this situation is best modeled as deleting an existing `EmployeeProject` and the creating a new `EmployeeProject`.  
  
    > [!NOTE]
    >  Relationships in relational databases are typically modeled as foreign key values that refer to primary keys in other tables. To navigate between them you explicitly associate the two tables by using a relational *join* operation.  
    >   
    >  Objects in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], on the other hand, refer to each other by using property references or collections of references that you navigate by using *dot* notation.  
  
## Example  
 In the following one-to-many example, the `Customer` class has a property that declares the relationship between customers and their orders.  The `Orders` property is of type <xref:System.Data.Linq.EntitySet%601>. This type signifies that this relationship is one-to-many (one customer to many orders). The <xref:System.Data.Linq.Mapping.AssociationAttribute.OtherKey%2A> property is used to describe how this association is accomplished, namely, by specifying the name of the property in the related class to be compared with this one. In this example, the `CustomerID` property is compared, just as a database *join* would compare that column value.  
  
> [!NOTE]
>  If you are using [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)], you can use the [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] to create an association between classes.  
  
 [!code-csharp[DlinqCustomize#3](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqCustomize/cs/Program.cs#3)]
 [!code-vb[DlinqCustomize#3](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqCustomize/vb/Module1.vb#3)]  
  
## Example  
 You can also reverse the situation. Instead of using the `Customer` class to describe the association between customers and orders, you can use the `Order` class. The `Order` class uses the <xref:System.Data.Linq.EntityRef%601> type to describe the relationship back to the customer, as in the following code example.  
  
> [!NOTE]
>  The <xref:System.Data.Linq.EntityRef%601> class supports *deferred loading*. For more information, *see* [Deferred versus Immediate Loading](../../../../../../docs/framework/data/adonet/sql/linq/deferred-versus-immediate-loading.md).  
  
 [!code-csharp[DLinqCustomize#5](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqCustomize/cs/Program.cs#5)]
 [!code-vb[DLinqCustomize#5](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqCustomize/vb/Module1.vb#5)]  
  
## See Also  
 [How to: Customize Entity Classes by Using the Code Editor](../../../../../../docs/framework/data/adonet/sql/linq/how-to-customize-entity-classes-by-using-the-code-editor.md)  
 [The LINQ to SQL Object Model](../../../../../../docs/framework/data/adonet/sql/linq/the-linq-to-sql-object-model.md)
