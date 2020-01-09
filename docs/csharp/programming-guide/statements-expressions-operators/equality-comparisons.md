---
title: "Equality Comparisons - C# Programming Guide"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "object equality [C#]"
ms.assetid: 10b865ea-4e7b-4127-9242-c9b8f57d9f04
---
# Equality comparisons (C# Programming Guide)

It is sometimes necessary to compare two values for equality. In some cases, you are testing for *value equality*, also known as *equivalence*, which means that the values that are contained by the two variables are equal. In other cases, you have to determine whether two variables refer to the same underlying object in memory. This type of equality is called *reference equality*, or *identity*. This topic describes these two kinds of equality and provides links to other topics for more information.  
  
## Reference equality

 Reference equality means that two object references refer to the same underlying object. This can occur through simple assignment, as shown in the following example.  
  
 [!code-csharp[csProgGuideStatements#18](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStatements/CS/Statements.cs#18)]  
  
 In this code, two objects are created, but after the assignment statement, both references refer to the same object. Therefore they have reference equality. Use the <xref:System.Object.ReferenceEquals%2A> method to determine whether two references refer to the same object.  
  
The concept of reference equality applies only to reference types. Value type objects cannot have reference equality because when an instance of a value type is assigned to a variable, a copy of the value is made. Therefore you can never have two unboxed structs that refer to the same location in memory. Furthermore, if you use <xref:System.Object.ReferenceEquals%2A> to compare two value types, the result will always be `false`, even if the values that are contained in the objects are all identical. This is because each variable is boxed into a separate object instance. For more information, see [How to test for reference equality (Identity)](./how-to-test-for-reference-equality-identity.md).

## Value equality

 Value equality means that two objects contain the same value or values. For primitive value types such as [int](../../language-reference/builtin-types/integral-numeric-types.md) or [bool](../../language-reference/builtin-types/bool.md), tests for value equality are straightforward. You can use the [==](../../language-reference/operators/equality-operators.md#equality-operator-) operator, as shown in the following example.  
  
```csharp  
int a = GetOriginalValue();  
int b = GetCurrentValue();  
  
// Test for value equality.   
if( b == a)   
{  
    // The two integers are equal.  
}  
```  
  
 For most other types, testing for value equality is more complex because it requires that you understand how the type defines it. For classes and structs that have multiple fields or properties, value equality is often defined to mean that all fields or properties have the same value. For example, two `Point` objects might be defined to be equivalent if pointA.X is equal to pointB.X and pointA.Y is equal to pointB.Y.  
  
However, there is no requirement that equivalence be based on all the fields in a type. It can be based on a subset. When you compare types that you do not own, you should make sure to understand specifically how equivalence is defined for that type. For more information about how to define value equality in your own classes and structs, see [How to define value equality for a type](./how-to-define-value-equality-for-a-type.md).
  
### Value equality for floating-point values

 Equality comparisons of floating-point values ([double](../../language-reference/builtin-types/floating-point-numeric-types.md) and [float](../../language-reference/builtin-types/floating-point-numeric-types.md)) are problematic because of the imprecision of floating-point arithmetic on binary computers. For more information, see the remarks in the topic <xref:System.Double?displayProperty=nameWithType>.  
  
## Related topics  
  
|Title|Description|  
|-----------|-----------------|  
|[How to test for reference equality (Identity)](./how-to-test-for-reference-equality-identity.md)|Describes how to determine whether two variables have reference equality.|  
|[How to define value equality for a type](./how-to-define-value-equality-for-a-type.md)|Describes how to provide a custom definition of value equality for a type.|  
|[C# Programming Guide](../index.md)|Provides links to detailed information about important C# language features and features that are available to C# through the .NET Framework.|  
|[Types](../types/index.md)|Provides information about the C# type system and links to additional information.|  
  
## See also

- [C# Programming Guide](../index.md)
