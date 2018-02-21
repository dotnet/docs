---
title: "Boxing Nullable Types (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "boxing [C#], nullable types"
  - "unboxing [C#], nullable types"
  - "nullable types [C#], boxing and unboxing"
ms.assetid: bdb5b626-abc0-405d-8f64-0f0a0bf883a4
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
---
# Boxing Nullable Types (C# Programming Guide)
Objects based on nullable types are only boxed if the object is non-null. If <xref:System.Nullable%601.HasValue%2A> is `false`, the object reference is assigned to `null` instead of boxing. For example:  
  
```csharp  
bool? b = null;  
object o = b;  
// Now o is null.  
```  
  
 If the object is non-null -- if <xref:System.Nullable%601.HasValue%2A> is `true` -- then boxing occurs, but only the underlying type that the nullable object is based on is boxed. Boxing a non-null nullable value type boxes the value type itself, not the <xref:System.Nullable%601?displayProperty=nameWithType> that wraps the value type. For example:  
  
```csharp  
bool? b = false;  
int? i = 44;  
object bBoxed = b; // bBoxed contains a boxed bool.  
object iBoxed = i; // iBoxed contains a boxed int.  
```  
  
 The two boxed objects are identical to those created by boxing non-nullable types. And, just like non-nullable boxed types, they can be unboxed into nullable types, as in the following example:  
  
```csharp  
bool? b2 = (bool?)bBoxed;  
int? i2 = (int?)iBoxed;  
```  
  
## Remarks  
 The behavior of nullable types when boxed provides two advantages:  
  
1.  Nullable objects and their boxed counterpart can be tested for null:  
  
    ```csharp  
    bool? b = null;  
    object boxedB = b;  
    if (b == null)  
    {  
      // True.  
    }  
    if (boxedB == null)  
    {  
      // Also true.  
    }  
    ```  
  
2.  Boxed nullable types fully support the functionality of the underlying type:  
  
    ```csharp  
    double? d = 44.4;  
    object iBoxed = d;  
    // Access IConvertible interface implemented by double.  
    IConvertible ic = (IConvertible)iBoxed;  
    int i = ic.ToInt32(null);  
    string str = ic.ToString();  
    ```  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Nullable Types](../../../csharp/programming-guide/nullable-types/index.md)  
 [How to: Identify a Nullable Type](../../../csharp/programming-guide/nullable-types/how-to-identify-a-nullable-type.md)
