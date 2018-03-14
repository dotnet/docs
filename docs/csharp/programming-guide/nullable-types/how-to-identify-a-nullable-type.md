---
title: "How to: Identify a Nullable Type (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "nullable types [C#], identifying"
ms.assetid: d4b67ee2-66e8-40c1-ae9d-545d32c71387
caps.latest.revision: 7
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Identify a Nullable Type (C# Programming Guide)
You can use the C# [typeof](../../../csharp/language-reference/keywords/typeof.md) operator to create a <xref:System.Type> object that represents a Nullable type:  
  
```  
System.Type type = typeof(int?);  
```  
  
 You can also use the classes and methods of the <xref:System.Reflection> namespace to generate <xref:System.Type> objects that represent Nullable types. However, if you try to obtain type information from Nullable variables at runtime by using the <xref:System.Object.GetType%2A> method or the `is` operator, the result is a <xref:System.Type> object that represents the underlying type, not the Nullable type itself.  
  
 Calling `GetType` on a Nullable type causes a boxing operation to be performed when the type is implicitly converted to <xref:System.Object>. Therefore <xref:System.Object.GetType%2A> always returns a <xref:System.Type> object that represents the underlying type, not the Nullable type.  
  
```  
int? i = 5;  
Type t = i.GetType();  
Console.WriteLine(t.FullName); //"System.Int32"  
```  
  
 The C# [is](../../../csharp/language-reference/keywords/is.md) operator also operates on a Nullable's underlying type. Therefore you cannot use `is` to determine whether a variable is a Nullable type. The following example shows that the `is` operator treats a Nullable\<int> variable as an int.  
  
```  
static void Main(string[] args)  
{  
  int? i = 5;  
  if (i is int) // true  
    //…  
}  
```  
  
## Example  
 Use the following code to determine whether a <xref:System.Type> object represents a Nullable type. Remember that this code always returns false if the `Type` object was returned from a call to <xref:System.Object.GetType%2A>, as explained earlier in this topic.  
  
```  
if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)) {…}  
```  
  
## See Also  
 [Nullable Types](../../../csharp/programming-guide/nullable-types/index.md)  
 [Boxing Nullable Types](../../../csharp/programming-guide/nullable-types/boxing-nullable-types.md)
