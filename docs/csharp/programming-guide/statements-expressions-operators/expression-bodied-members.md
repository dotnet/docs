---
title: "Expression-bodied members (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "expression-bodied members[C#]"
  - "C# language, expresion-bodied members"
author: "rpetrusha"
ms.author: "ronpet"
---
# Expression-bodied members (C# programming guide)
Expression body definitions let you provide a member's implementation in a very concise, readable form. You can use an expression body definition whenever the logic for any supported member, such as a method or property, consists of a single expression. An expression body definition has the following general syntax:

```csharp
member => expression;
```

where *expression* is a valid expression. 

Support for expression body definitions was introduced for methods and property get accessors in C# 6 and was expanded in C# 7. Expression body definitions can be used with the type members listed in the following table: 

|Member  |Supported as of... |
|---------|---------|
|[Method](#methods)  |C# 6 |
|[Constructor](#constructors)   |C# 7 |
|[Finalizer](#finalizers)     |C# 7 |
|[Property Get](#property-get-statements)  |C# 6 |
|[Property Set](#property-set-statements)  |C# 7 |
|[Indexer](#indexers)       |C# 7 |

## Methods

An expression-bodied method consists of a single expression that returns a value whose type matches the method's return type, or, for methods that return `void`, that performs some operation. For example, types that override the <xref:System.Object.ToString%2A> method typically include a single expression that returns the string representation of the current object. 

The following example defines a `Person` class that overrides the <xref:System.Object.ToString%2A> method with an expression body definition. It also defines a `Show` method that displays a name to the console. Note that the `return` keyword is not used in the `ToString` expression body definition.

[!code-csharp[expression-bodied-methods](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/expr-bodied-methods.cs)]  

For more information, see [Methods (C# Programming Guide)](../classes-and-structs/methods.md).
 
## Constructors

An expression body definition for a constructor typically consists of a single assignment expression or a method call that handles the constructor's arguments or initializes instance state. 

The following example defines a `Location` class whose constructor has a single string parameter named *name*. The expression body definition assigns the argument to the `Name` property.

[!code-csharp[expression-bodied-constructor](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/expr-bodied-ctor.cs#1)]  

For more information, see [Constructors (C# Programming Guide)](../classes-and-structs/constructors.md).

## Finalizers

An expression body definition for a finalizer typically contains cleanup statements, such as statements that release unmanaged resources.

The following example defines a finalizer that uses an expression body definition to indicate that the finalizer has been called.

[!code-csharp[expression-bodied-finalizer](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/expr-bodied-destructor.cs#1)]  

For more information, see [Finalizers (C# Programming Guide)](../classes-and-structs/destructors.md).

## Property get statements

If you choose to implement a property get accessor yourself, you can use an expression body definition for single expressions that simply return the property value. Note that the `return` statement isn't used.

The following example defines a `Location.Name` property whose property get accessor returns the value of the private `locationName` field that backs the property. 

[!code-csharp[expression-bodied-property-getter](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/expr-bodied-ctor.cs#1)]  

Read-only properties that use an expression body definition can be implemented without an explicit `set` statement. The syntax is:

```csharp
PropertyName => returnValue;
```

The following example defines a `Location` class whose read-only `Name` property is implemented as an expression body definition that returns the value of the private `locationName` field.

[!code-csharp[expression-bodied-constructor](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/expr-bodied-readonly.cs#1)]  

For more information, see [Properties (C# Programming Guide)](../classes-and-structs/properties.md).

## Property set statements

If you choose to implement a property set accessor yourself, you can use an expression body definition for a single-line expression that assigns a value to the field that backs the property.

The following example defines a `Location.Name` property whose property set statement assigns its input argument to the private `locationName` field that backs the property.

[!code-csharp[expression-bodied-property-setter](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/expr-bodied-ctor.cs#1)]  

For more information, see [Properties (C# Programming Guide)](../classes-and-structs/properties.md).

## Indexers

Like properties, an indexer's get and set accessors consist of expression body definitions if the get accessor consists of a single statement that returns a value or the set accessor performs a simple assignment.

The following example defines a class named `Sports` that includes an internal <xref:System.String> array that contains the names of a number of sports. Both the indexer's get and set accessors are implemented as expression body definitions.

[!code-csharp[expression-bodied-indexer](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/expr-bodied-indexers.cs#1)] 

For more information, see [Indexers (C# Programming Guide)](../indexers/index.md).

