---
title: "Getting Started"
description: With this sample code, get started using LINQ to SQL to use the LINQ technology to access SQL databases just as you would access an in-memory collection.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: db8a557a-fef8-4f4f-bb91-8cff7250ee25
---
# Getting Started

By using [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], you can use the LINQ technology to access SQL databases just as you would access an in-memory collection.  
  
 For example, the `nw` object in the following code is created to represent the `Northwind` database, the `Customers` table is targeted, the rows are filtered for `Customers` from `London`, and a string for `CompanyName` is selected for retrieval.  
  
 When the loop is executed, the collection of `CompanyName` values is retrieved.  
  
 [!code-csharp[DLinqGettingStarted#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqGettingStarted/cs/Program.cs#1)]
 [!code-vb[DLinqGettingStarted#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqGettingStarted/vb/Module1.vb#1)]  
  
## Next Steps  

 For some additional examples, including inserting and updating, see [What You Can Do With LINQ to SQL](what-you-can-do-with-linq-to-sql.md).  
  
 Next, try some walkthroughs and tutorials to have a hands-on experience of using [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)]. See [Learning by Walkthroughs](learning-by-walkthroughs.md).  
  
 Finally, learn how to get started on your own [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] project by reading [Typical Steps for Using LINQ to SQL](typical-steps-for-using-linq-to-sql.md).  
  
## See also

- [LINQ to SQL](index.md)
- [Introduction to LINQ (C#)](../../../../../csharp/programming-guide/concepts/linq/index.md)
- [Introduction to LINQ (Visual Basic)](../../../../../visual-basic/programming-guide/concepts/linq/introduction-to-linq.md)
- [The LINQ to SQL Object Model](the-linq-to-sql-object-model.md)
