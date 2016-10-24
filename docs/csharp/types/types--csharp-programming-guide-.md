---
title: "Types (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "value types [C#]"
  - "reference types [C#]"
  - "types [C#]"
  - "C# language, data types"
  - "common type system [C#]"
  - "data types [C#]"
  - "C# language, types"
  - "strong typing [C#]"
ms.assetid: f782d7cc-035e-4500-b1b1-36a9881130ad
caps.latest.revision: 53
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Types (C# Programming Guide)
## Types, Variables, and Values  
 C# is a strongly-typed language. Every variable and constant has a type, as does every expression that evaluates to a value. Every method signature specifies a type for each input parameter and for the return value. The .NET Framework class library defines a set of built-in numeric types as well as more complex types that represent a wide variety of logical constructs, such as the file system, network connections, collections and arrays of objects, and dates. A typical C# program uses types from the class library as well as user-defined types that model the concepts that are specific to the program's problem domain.  
  
 The information stored in a type can include the following:  
  
-   The storage space that a variable of the type requires.  
  
-   The maximum and minimum values that it can represent.  
  
-   The members (methods, fields, events, and so on) that it contains.  
  
-   The base type it inherits from.  
  
-   The location where the memory for variables will be allocated at run time.  
  
-   The kinds of operations that are permitted.  
  
 The compiler uses type information to make sure that all operations that are performed in your code are *type safe*. For example, if you declare a variable of type [int](../keywords/int--csharp-reference-.md), the compiler allows you to use the variable in addition and subtraction operations. If you try to perform those same operations on a variable of type [bool](../keywords/bool--csharp-reference-.md), the compiler generates an error, as shown in the following example:  
  
 [!code[csProgGuideTypes#42](../nullable-types/codesnippet/CSharp/types--csharp-programming-guide-_1.cs)]  
  
> [!NOTE]
>  C and C++ developers, notice that in C#, [bool](../keywords/bool--csharp-reference-.md) is not convertible to [int](../keywords/int--csharp-reference-.md).  
  
 The compiler embeds the type information into the executable file as metadata. The common language runtime (CLR) uses that metadata at run time to further guarantee type safety when it allocates and reclaims memory.  
  
### Specifying Types in Variable Declarations  
 When you declare a variable or constant in a program, you must either specify its type or use the [var](../keywords/var--csharp-reference-.md) keyword to let the compiler infer the type. The following example shows some variable declarations that use both built-in numeric types and complex user-defined types:  
  
 [!code[csProgGuideTypes#36](../nullable-types/codesnippet/CSharp/types--csharp-programming-guide-_2.cs)]  
  
 The types of method parameters and return values are specified in the method signature. The following signature shows a method that requires an [int](../keywords/int--csharp-reference-.md) as an input argument and returns a string:  
  
 [!code[csProgGuideTypes#35](../nullable-types/codesnippet/CSharp/types--csharp-programming-guide-_3.cs)]  
  
 After a variable is declared, it cannot be re-declared with a new type, and it cannot be assigned a value that is not compatible with its declared type. For example, you cannot declare an [int](../keywords/int--csharp-reference-.md) and then assign it a Boolean value of [true](../keywords/true-literal--csharp-reference-.md). However, values can be converted to other types, for example when they are assigned to new variables or passed as method arguments. A *type conversion* that does not cause data loss is performed automatically by the compiler. A conversion that might cause data loss requires a *cast* in the source code.  
  
 For more information, see [Casting and Type Conversions](../types/casting-and-type-conversions--csharp-programming-guide-.md).  
  
## Built-in Types  
 C# provides a standard set of built-in numeric types to represent integers, floating point values, Boolean expressions, text characters, decimal values, and other types of data. There are also built-in `string` and `object` types. These are available for you to use in any C# program. For a more information about the built-in types, see [Reference Tables for Types](../keywords/reference-tables-for-types--csharp-reference-.md).  
  
## Custom Types  
 You use the [struct](../keywords/struct--csharp-reference-.md), [class](../keywords/class--csharp-reference-.md), [interface](../keywords/interface--csharp-reference-.md), and [enum](../keywords/enum--csharp-reference-.md) constructs to create your own custom types. The .NET Framework class library itself is a collection of custom types provided by Microsoft that you can use in your own applications. By default, the most frequently used types in the class library are available in any C# program. Others become available only when you explicitly add a project reference to the assembly in which they are defined. After the compiler has a reference to the assembly, you can declare variables (and constants) of the types declared in that assembly in source code. For more information, see [.NET Framework Class Library](http://go.microsoft.com/fwlink/?LinkID=217856).  
  
## The Common Type System  
 It is important to understand two fundamental points about the type system in the [!INCLUDE[dnprdnshort](../classes-and-structs/includes/dnprdnshort_md.md)]:  
  
-   It supports the principle of inheritance. Types can derive from other types, called *base types*. The derived type inherits (with some restrictions) the methods, properties, and other members of the base type. The base type can in turn derive from some other type, in which case the derived type inherits the members of both base types in its inheritance hierarchy. All types, including built-in numeric types such as <xref:System.Int32?displayProperty=fullName> (C# keyword: [int](../keywords/int--csharp-reference-.md)), derive ultimately from a single base type, which is <xref:System.Object?displayProperty=fullName> (C# keyword: [object](../keywords/object--csharp-reference-.md)). This unified type hierarchy is called the [Common Type System](../Topic/Common%20Type%20System.md) (CTS). For more information about inheritance in C#, see [Inheritance](../classes-and-structs/inheritance--csharp-programming-guide-.md).  
  
-   Each type in the CTS is defined as either a *value type* or a *reference type*. This includes all custom types in the .NET Framework class library and also your own user-defined types. Types that you define by using the [struct](../keywords/struct--csharp-reference-.md) keyword are value types; all the built-in numeric types are `structs`. Types that you define by using the [class](../keywords/class--csharp-reference-.md) keyword are reference types. Reference types and value types have different compile-time rules, and different run-time behavior.  
  
 The following illustration shows the relationship between value types and reference types in the CTS.  
  
 ![Value Types and Reference Types](../types/media/valuetypescts.png "ValueTypesCTS")  
Value types and reference types in the CTS  
  
> [!NOTE]
>  You can see that the most commonly used types are all organized in the <xref:System> namespace. However, the namespace in which a type is contained has no relation to whether it is a value type or reference type.  
  
### Value Types  
 Value types derive from <xref:System.ValueType?displayProperty=fullName>, which derives from <xref:System.Object?displayProperty=fullName>. Types that derive from <xref:System.ValueType?displayProperty=fullName> have special behavior in the CLR. Value type variables directly contain their values, which means that the memory is allocated inline in whatever context the variable is declared. There is no separate heap allocation or garbage collection overhead for value-type variables.  
  
 There are two categories of value types: [struct](../keywords/struct--csharp-reference-.md) and [enum](../keywords/enum--csharp-reference-.md).  
  
 The built-in numeric types are structs, and they have properties and methods that you can access:  
  
```c#  
// Static method on type Byte.  
byte b = Byte.MaxValue;  
```  
  
 But you declare and assign values to them as if they were simple non-aggregate types:  
  
```c#  
byte num = 0xA;  
int i = 5;  
char c = 'Z';  
```  
  
 Value types are *sealed*, which means, for example, that you cannot derive a type from <xref:System.Int32?displayProperty=fullName>, and you cannot define a struct to inherit from any user-defined class or struct because a struct can only inherit from <xref:System.ValueType?displayProperty=fullName>. However, a struct can implement one or more interfaces. You can cast a struct type to an interface type; this causes a *boxing* operation to wrap the struct inside a reference type object on the managed heap. Boxing operations occur when you pass a value type to a method that takes a <xref:System.Object?displayProperty=fullName> as an input parameter. For more information, see [Boxing and Unboxing](../types/boxing-and-unboxing--csharp-programming-guide-.md).  
  
 You use the [struct](../keywords/struct--csharp-reference-.md) keyword to create your own custom value types. Typically, a struct is used as a container for a small set of related variables, as shown in the following example:  
  
 [!code[csProgGuideObjects#1](../classes-and-structs/codesnippet/CSharp/types--csharp-programming-guide-_4.cs)]  
  
 For more information about structs, see [Structs](../classes-and-structs/structs--csharp-programming-guide-.md). For more information about value types in the [!INCLUDE[dnprdnshort](../classes-and-structs/includes/dnprdnshort_md.md)], see [Common Type System](../Topic/Common%20Type%20System.md).  
  
 The other category of value types is [enum](../keywords/enum--csharp-reference-.md). An enum defines a set of named integral constants. For example, the <xref:System.IO.FileMode?displayProperty=fullName> enumeration in the .NET Framework class library contains a set of named constant integers that specify how a file should be opened. It is defined as shown in the following example:  
  
 [!code[csProgGuideTypes#44](../nullable-types/codesnippet/CSharp/types--csharp-programming-guide-_5.cs)]  
  
 The `System.IO.FileMode.Create` constant has a value of 2. However, the name is much more meaningful for humans reading the source code, and for that reason it is better to use enumerations instead of constant literal numbers. For more information, see <xref:System.IO.FileMode?displayProperty=fullName>.  
  
 All enums inherit from <xref:System.Enum?displayProperty=fullName>, which inherits from <xref:System.ValueType?displayProperty=fullName>. All the rules that apply to structs also apply to enums. For more information about enums, see [Enumeration Types](../programming-guide/enumeration-types--csharp-programming-guide-.md).  
  
### Reference Types  
 A type that is defined as a [class](../keywords/class--csharp-reference-.md), [delegate](../keywords/delegate--csharp-reference-.md), array, or [interface](../keywords/interface--csharp-reference-.md) is a *reference type*. At run time, when you declare a variable of a reference type, the variable contains the value [null](../keywords/null--csharp-reference-.md) until you explicitly create an instance of the object by using the [new](../keywords/new--csharp-reference-.md) operator, or assign it an object that has been created elsewhere by using `new, as shown in the following example:`  
  
```c#  
MyClass mc = new MyClass();  
MyClass mc2 = mc;  
```  
  
 An interface must be initialized together with a class object that implements it. If `MyClass` implements `IMyInterface`, you create an instance of `IMyInterface` as shown in the following example:  
  
```c#  
IMyInterface iface = new MyClass();  
```  
  
 When the object is created, the memory is allocated on the managed heap, and the variable holds only a reference to the location of the object. Types on the managed heap require overhead both when they are allocated and when they are reclaimed by the automatic memory management functionality of the CLR, which is known as *garbage collection*. However, garbage collection is also highly optimized, and in most scenarios it does not create a performance issue. For more information about garbage collection, see [Automatic Memory Management](../Topic/Automatic%20Memory%20Management.md).  
  
 All arrays are reference types, even if their elements are value types. Arrays implicitly derive from the <xref:System.Array?displayProperty=fullName> class, but you declare and use them with the simplified syntax that is provided by C#, as shown in the following example:  
  
 [!code[csProgGuideTypes#45](../nullable-types/codesnippet/CSharp/types--csharp-programming-guide-_6.cs)]  
  
 Reference types fully support inheritance. When you create a class, you can inherit from any other interface or class that is not defined as [sealed](../keywords/sealed--csharp-reference-.md), and other classes can inherit from your class and override your virtual methods. For more information about how to create your own classes, see [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md). For more information about inheritance and virtual methods, see [Inheritance](../classes-and-structs/inheritance--csharp-programming-guide-.md).  
  
## Types of Literal Values  
 In C#, literal values receive a type from the compiler. You can specify how a numeric literal should be typed by appending a letter to the end of the number. For example, to specify that the value 4.56 should be treated as a float, append an "f" or "F" after the number: `4.56f`. If no letter is appended, the compiler will infer a type for the literal. For more information about which types can be specified with letter suffixes, see the reference pages for individual types in [Value Types](../keywords/value-types--csharp-reference-.md).  
  
 Because literals are typed, and all types derive ultimately from <xref:System.Object?displayProperty=fullName>, you can write and compile code such as the following:  
  
 [!code[csProgGuideTypes#37](../nullable-types/codesnippet/CSharp/types--csharp-programming-guide-_7.cs)]  
  
## Generic Types  
 A type can be declared with one or more *type parameters* that serve as a placeholder for the actual type (the *concrete type*) that client code will provide when it creates an instance of the type. Such types are called *generic types*. For example, the .NET Framework type <xref:System.Collections.Generic.List`1?displayProperty=fullName> has one type parameter that by convention is given the name *T*. When you create an instance of the type, you specify the type of the objects that the list will contain, for example, string:  
  
<CodeContentPlaceHolder>4</CodeContentPlaceHolder>  
 The use of the type parameter makes it possible to reuse the same class to hold any type of element, without having to convert each element to [object](../keywords/object--csharp-reference-.md). Generic collection classes are called *strongly-typed collections* because the compiler knows the specific type of the collection's elements and can raise an error at compile-time if, for example, you try to add an integer to the `strings` object in the previous example. For more information, see [Generics](../generics/generics--csharp-programming-guide-.md).  
  
## Implicit Types, Anonymous Types, and Nullable Types  
 As stated previously, you can implicitly type a local variable (but not class members) by using the [var](../keywords/var--csharp-reference-.md) keyword. The variable still receives a type at compile time, but the type is provided by the compiler. For more information, see [Implicitly Typed Local Variables](../classes-and-structs/implicitly-typed-local-variables--csharp-programming-guide-.md).  
  
 In some cases, it is inconvenient to create a named type for simple sets of related values that you do not intend to store or pass outside method boundaries. You can create *anonymous types* for this purpose. For more information, see [Anonymous Types](../classes-and-structs/anonymous-types--csharp-programming-guide-.md).  
  
 Ordinary value types cannot have a value of [null](../keywords/null--csharp-reference-.md). However, you can create nullable value types by affixing a `?` after the type. For example, `int?` is an `int` type that can also have the value [null](../keywords/null--csharp-reference-.md). In the CTS, nullable types are instances of the generic struct type <xref:System.Nullable`1?displayProperty=fullName>. Nullable types are especially useful when you are passing data to and from databases in which numeric values might be null. For more information, see [Nullable Types](../nullable-types/nullable-types--csharp-programming-guide-.md).  
  
## Related Sections  
 For more information, see the following topics:  
  
-   [Casting and Type Conversions](../types/casting-and-type-conversions--csharp-programming-guide-.md)  
  
-   [Boxing and Unboxing](../types/boxing-and-unboxing--csharp-programming-guide-.md)  
  
-   [Using Type dynamic](../types/using-type-dynamic--csharp-programming-guide-.md)  
  
-   [Value Types](../keywords/value-types--csharp-reference-.md)  
  
-   [Reference Types](../keywords/reference-types--csharp-reference-.md)  
  
-   [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)  
  
-   [Anonymous Types](../classes-and-structs/anonymous-types--csharp-programming-guide-.md)  
  
-   [Generics](../generics/generics--csharp-programming-guide-.md)  
  
-   [Variables and Expressions](http://go.microsoft.com/fwlink/?LinkId=221228) in [Beginning Visual C# 2010](http://go.microsoft.com/fwlink/?LinkId=221214)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Conversion of XML Data Types](../Topic/Conversion%20of%20XML%20Data%20Types.md)   
 [Integral Types Table](../keywords/integral-types-table--csharp-reference-.md)