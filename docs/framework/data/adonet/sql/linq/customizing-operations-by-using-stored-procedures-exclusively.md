---
description: "Learn more about: Customizing Operations by Using Stored Procedures Exclusively"
title: "Customizing Operations by Using Stored Procedures Exclusively"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 441e8ef3-998c-4d12-8825-ce66a178f90f
---
# Customizing Operations by Using Stored Procedures Exclusively

Access to data by using only stored procedures is a common scenario.  
  
## Example  
  
### Description  

 You can modify the example provided in [Customizing Operations By Using Stored Procedures](customizing-operations-by-using-stored-procedures.md) by replacing even the first query (which causes dynamic SQL execution) with a method call that wraps a stored procedure.  
  
 Assume `CustomersByCity` is the method, as in the following example.  
  
### Code  

 [!code-csharp[DLinqOverrideDefaultSproc#4](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqOverrideDefaultSproc/cs/northwind.cs#4)]
 [!code-vb[DLinqOverrideDefaultSproc#4](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqOverrideDefaultSproc/vb/northwind.vb#4)]  
  
 The following code executes without any dynamic SQL.  
  
 [!code-csharp[DLinqOverrideDefaultSproc#5](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqOverrideDefaultSproc/cs/Program.cs#5)]
 [!code-vb[DLinqOverrideDefaultSproc#5](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqOverrideDefaultSproc/vb/Module1.vb#5)]  
  
## See also

- [Responsibilities of the Developer In Overriding Default Behavior](responsibilities-of-the-developer-in-overriding-default-behavior.md)
