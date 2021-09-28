---
description: "Learn more about: How to: Use Scalar-Valued User-Defined Functions"
title: "How to: Use Scalar-Valued User-Defined Functions"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 714e252f-c053-4bbb-b1f3-924111cd4d97
---
# How to: Use Scalar-Valued User-Defined Functions

You can map a client method defined on a class to a user-defined function by using the <xref:System.Data.Linq.Mapping.FunctionAttribute> attribute. Note that the body of the method constructs an expression that captures the intent of the method call, and passes that expression to the <xref:System.Data.Linq.DataContext> for translation and execution.  
  
> [!NOTE]
> Direct execution occurs only if the function is called outside a query. For more information, see [How to: Call User-Defined Functions Inline](how-to-call-user-defined-functions-inline.md).  
  
## Example  

 The following SQL code presents a scalar-valued user-defined function `ReverseCustName()`.  
  
```sql  
CREATE FUNCTION ReverseCustName(@string varchar(100))  
RETURNS varchar(100)  
AS  
BEGIN  
    DECLARE @custName varchar(100)  
    -- Implementation left as exercise for users.  
    RETURN @custName  
END  
```  
  
 You would map a client method such as the following for this code:  
  
 [!code-csharp[DLinqUDFS#3](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqUDFS/cs/northwind-tfunc.cs#3)]
 [!code-vb[DLinqUDFS#3](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqUDFS/vb/northwind-tfunc.vb#3)]  
  
## See also

- [User-Defined Functions](user-defined-functions.md)
