---
title: "Members (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "types [C#], nested types"
  - "C# language, type members"
ms.assetid: 4a30a4ab-d690-4936-9124-92ce9448665a
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
---
# Members (C# Programming Guide)
Classes and structs have members that represent their data and behavior. A class's members include all the members declared in the class, along with all members (except constructors and finalizers) declared in all classes in its inheritance hierarchy. Private members in base classes are inherited but are not accessible from derived classes.  
  
 The following table lists the kinds of members a class or struct may contain:  
  
|Member|Description|  
|------------|-----------------|  
|[Fields](../../../csharp/programming-guide/classes-and-structs/fields.md)|Fields are variables declared at class scope. A field may be a built-in numeric type or an instance of another class. For example, a calendar class may have a field that contains the current date.|  
|[Constants](../../../csharp/programming-guide/classes-and-structs/constants.md)|Constants are fields or properties whose value is set at compile time and cannot be changed.|  
|[Properties](../../../csharp/programming-guide/classes-and-structs/properties.md)|Properties are methods on a class that are accessed as if they were fields on that class. A property can provide protection for a class field to keep it from being changed without the knowledge of the object.|  
|[Methods](../../../csharp/programming-guide/classes-and-structs/methods.md)|Methods define the actions that a class can perform. Methods can take parameters that provide input data, and can return output data through parameters. Methods can also return a value directly, without using a parameter.|  
|[Events](../../../csharp/programming-guide/events/index.md)|Events provide notifications about occurrences, such as button clicks or the successful completion of a method, to other objects. Events are defined and triggered by using delegates.|  
|[Operators](../../../csharp/programming-guide/statements-expressions-operators/operators.md)|Overloaded operators are considered class members. When you overload an operator, you define it as a public static method in a class. The predefined operators (`+`, `*`, `<`, and so on) are not considered members. For more information, see [Overloadable Operators](../../../csharp/programming-guide/statements-expressions-operators/overloadable-operators.md).|  
|[Indexers](../../../csharp/programming-guide/indexers/index.md)|Indexers enable an object to be indexed in a manner similar to arrays.|  
|[Constructors](../../../csharp/programming-guide/classes-and-structs/constructors.md)|Constructors are methods that are called when the object is first created. They are often used to initialize the data of an object.|  
|[Finalizers](../../../csharp/programming-guide/classes-and-structs/destructors.md)|Finalizers are used very rarely in C#. They are methods that are called by the runtime execution engine when the object is about to be removed from memory. They are generally used to make sure that any resources which must be released are handled appropriately.|  
|[Nested Types](../../../csharp/programming-guide/classes-and-structs/nested-types.md)|Nested types are types declared within another type. Nested types are often used to describe objects that are used only by the types that contain them.|  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Classes](../../../csharp/programming-guide/classes-and-structs/classes.md)  
 [Methods](../../../csharp/programming-guide/classes-and-structs/methods.md)  
 [Constructors](../../../csharp/programming-guide/classes-and-structs/constructors.md)  
 [Finalizers](../../../csharp/programming-guide/classes-and-structs/destructors.md)  
 [Properties](../../../csharp/programming-guide/classes-and-structs/properties.md)  
 [Fields](../../../csharp/programming-guide/classes-and-structs/fields.md)  
 [Indexers](../../../csharp/programming-guide/indexers/index.md)  
 [Events](../../../csharp/programming-guide/events/index.md)  
 [Nested Types](../../../csharp/programming-guide/classes-and-structs/nested-types.md)  
 [Operators](../../../csharp/programming-guide/statements-expressions-operators/operators.md)  
 [Overloadable Operators](../../../csharp/programming-guide/statements-expressions-operators/overloadable-operators.md)
