---
title: "Pointer types (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "unsafe code [C#], pointers"
  - "pointers [C#]"
ms.assetid: 3319faf9-336d-4148-9af2-1da2579cdd1e
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# Pointer types (C# Programming Guide)
In an unsafe context, a type may be a pointer type, a value type, or a reference type. A pointer type declaration takes one of the following forms:  
  
```  
type* identifier;  
void* identifier; //allowed but not recommended  
```  
  
 Any of the following types may be a pointer type:  
  
-   [sbyte](../../../csharp/language-reference/keywords/sbyte.md), [byte](../../../csharp/language-reference/keywords/byte.md), [short](../../../csharp/language-reference/keywords/short.md), [ushort](../../../csharp/language-reference/keywords/ushort.md), [int](../../../csharp/language-reference/keywords/int.md), [uint](../../../csharp/language-reference/keywords/uint.md), [long](../../../csharp/language-reference/keywords/long.md), [ulong](../../../csharp/language-reference/keywords/ulong.md), [char](../../../csharp/language-reference/keywords/char.md), [float](../../../csharp/language-reference/keywords/float.md), [double](../../../csharp/language-reference/keywords/double.md), [decimal](../../../csharp/language-reference/keywords/decimal.md), or [bool](../../../csharp/language-reference/keywords/bool.md).  
  
-   Any [enum](../../../csharp/language-reference/keywords/enum.md) type.  
  
-   Any pointer type.  
  
-   Any user-defined struct type that contains fields of unmanaged types only.  
  
 Pointer types do not inherit from [object](../../../csharp/language-reference/keywords/object.md) and no conversions exist between pointer types and `object`. Also, boxing and unboxing do not support pointers. However, you can convert between different pointer types and between pointer types and integral types.  
  
 When you declare multiple pointers in the same declaration, the asterisk (*) is written together with the underlying type only; it is not used as a prefix to each pointer name. For example:  
  
```  
int* p1, p2, p3;   // Ok  
int *p1, *p2, *p3;   // Invalid in C#  
```  
  
 A pointer cannot point to a reference or to a [struct](../../../csharp/language-reference/keywords/struct.md) that contains references, because an object reference can be garbage collected even if a pointer is pointing to it. The garbage collector does not keep track of whether an object is being pointed to by any pointer types.  
  
 The value of the pointer variable of type `myType*` is the address of a variable of type `myType`. The following are examples of pointer type declarations:  
  
|Example|Description|  
|-------------|-----------------|  
|`int* p`|`p` is a pointer to an integer.|  
|`int** p`|`p` is a pointer to a pointer to an integer.|  
|`int*[] p`|`p` is a single-dimensional array of pointers to integers.|  
|`char* p`|`p` is a pointer to a char.|  
|`void* p`|`p` is a pointer to an unknown type.|  
  
 The pointer indirection operator * can be used to access the contents at the location pointed to by the pointer variable. For example, consider the following declaration:  
  
```  
int* myVariable;  
```  
  
 The expression `*myVariable` denotes the `int` variable found at the address contained in `myVariable`.  
  
 There are several examples of pointers in the topics [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md) and [Pointer Conversions](../../../csharp/programming-guide/unsafe-code-pointers/pointer-conversions.md).  The following example shows the need for the `unsafe` keyword and the `fixed` statement, and how to increment an interior pointer.  You can paste this code into the Main function of a console application to run it. (Remember to enable unsafe code in the **Project Designer**; choose **Project**, **Properties** on the menu bar, and then select **Allow unsafe code** in the **Build** tab.)  
  
```  
// Normal pointer to an object.  
int[] a = new int[5] {10, 20, 30, 40, 50};  
// Must be in unsafe code to use interior pointers.  
unsafe  
{  
    // Must pin object on heap so that it doesn't move while using interior pointers.  
    fixed (int* p = &a[0])  
    {  
        // p is pinned as well as object, so create another pointer to show incrementing it.  
        int* p2 = p;  
        Console.WriteLine(*p2);  
        // Incrementing p2 bumps the pointer by four bytes due to its type ...  
        p2 += 1;  
        Console.WriteLine(*p2);  
        p2 += 1;  
        Console.WriteLine(*p2);  
        Console.WriteLine("--------");  
        Console.WriteLine(*p);  
        // Deferencing p and incrementing changes the value of a[0] ...  
        *p += 1;  
        Console.WriteLine(*p);  
        *p += 1;  
        Console.WriteLine(*p);  
    }  
}  
  
Console.WriteLine("--------");  
Console.WriteLine(a[0]);  
Console.ReadLine();  
  
// Output:  
//10  
//20  
//30  
//--------  
//10  
//11  
//12  
//--------  
//12  
```  
  
 You cannot apply the indirection operator to a pointer of type `void*`. However, you can use a cast to convert a void pointer to any other pointer type, and vice versa.  
  
 A pointer can be `null`. Applying the indirection operator to a null pointer causes an implementation-defined behavior.  
  
 Be aware that passing pointers between methods can cause undefined behavior. Consider a method that returns a pointer to a local variable through an `in`, `out` or `ref` parameter or as the function result. If the pointer was set in a fixed block, the variable to which it points may no longer be fixed.  
  
 The following table lists the operators and statements that can operate on pointers in an unsafe context:  
  
|Operator/Statement|Use|  
|-------------------------|---------|  
|*|Performs pointer indirection.|  
|->|Accesses a member of a struct through a pointer.|  
|[]|Indexes a pointer.|  
|`&`|Obtains the address of a variable.|  
|++ and --|Increments and decrements pointers.|  
|+ and -|Performs pointer arithmetic.|  
|==, !=, \<, >, \<=, and >=|Compares pointers.|  
|`stackalloc`|Allocates memory on the stack.|  
|`fixed` statement|Temporarily fixes a variable so that its address may be found.|  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Unsafe Code and Pointers](../../../csharp/programming-guide/unsafe-code-pointers/index.md)  
 [Pointer Conversions](../../../csharp/programming-guide/unsafe-code-pointers/pointer-conversions.md)  
 [Pointer Expressions](../../../csharp/programming-guide/unsafe-code-pointers/pointer-expressions.md)  
 [Types](../../../csharp/language-reference/keywords/types.md)  
 [unsafe](../../../csharp/language-reference/keywords/unsafe.md)  
 [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md)  
 [stackalloc](../../../csharp/language-reference/keywords/stackalloc.md)  
 [Boxing and Unboxing](../../../csharp/programming-guide/types/boxing-and-unboxing.md)
