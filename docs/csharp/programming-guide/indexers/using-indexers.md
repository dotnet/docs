---
title: "Using Indexers - C# Programming Guide"
ms.custom: seodec18
ms.date: 10/03/2018
helpviewer_keywords: 
  - "indexers [C#], about indexers"
ms.assetid: df70e1a2-3ce3-4aba-ad80-4b2f3538699f
---
# Using indexers (C# Programming Guide)

Indexers are a syntactic convenience that enable you to create a [class](../../../csharp/language-reference/keywords/class.md), [struct](../../../csharp/language-reference/keywords/struct.md), or [interface](../../../csharp/language-reference/keywords/interface.md) that client applications can access just as an array. Indexers are most frequently implemented in types whose primary purpose is to encapsulate an internal collection or array. For example, suppose you have a class `TempRecord` that represents the temperature in Fahrenheit as recorded at 10 different times during a 24 hour period. The class contains an array `temps` of type `float[]` to store the temperature values. By implementing an indexer in this class, clients can access the temperatures in a `TempRecord` instance as `float temp = tr[4]` instead of as `float temp = tr.temps[4]`. The indexer notation not only simplifies the syntax for client applications; it also makes the class and its purpose more intuitive for other developers to understand.  
  
To declare an indexer on a class or struct, use the [this](../../../csharp/language-reference/keywords/this.md) keyword, as the following example shows:

```csharp
public int this[int index]    // Indexer declaration  
{  
    // get and set accessors  
}  
```

## Remarks

The type of an indexer and the type of its parameters must be at least as accessible as the indexer itself. For more information about accessibility levels, see [Access Modifiers](../../../csharp/language-reference/keywords/access-modifiers.md).  
  
 For more information about how to use indexers with an interface, see [Interface Indexers](../../../csharp/programming-guide/indexers/indexers-in-interfaces.md).  
  
 The signature of an indexer consists of the number and types of its formal parameters. It doesn't include the indexer type or the names of the formal parameters. If you declare more than one indexer in the same class, they must have different signatures.  
  
 An indexer value is not classified as a variable; therefore, you cannot pass an indexer value as a [ref](../../../csharp/language-reference/keywords/ref.md) or [out](../../../csharp/language-reference/keywords/out-parameter-modifier.md) parameter.  
  
 To provide the indexer with a name that other languages can use, use <xref:System.Runtime.CompilerServices.IndexerNameAttribute?displayProperty=nameWithType>, as the following example shows:  

```csharp
[System.Runtime.CompilerServices.IndexerName("TheItem")]  
public int this[int index]   // Indexer declaration  
{
    // get and set accessors  
}  
```

This indexer will have the name `TheItem`. Not providing the name attribute would make `Item` the default name.  
  
## Example 1  
  
The following example shows how to declare a private array field, `temps`, and an indexer. The indexer enables direct access to the instance `tempRecord[i]`. The alternative to using the indexer is to declare the array as a [public](../../../csharp/language-reference/keywords/public.md) member and access its members, `tempRecord.temps[i]`, directly.  
  
 Notice that when an indexer's access is evaluated, for example, in a `Console.Write` statement, the [get](../../../csharp/language-reference/keywords/get.md) accessor is invoked. Therefore, if no `get` accessor exists, a compile-time error occurs.  
  
 [!code-csharp[csProgGuideIndexers#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideIndexers/CS/Indexers.cs#1)]  
  
## Indexing using other values

C# doesn't limit the indexer parameter type to integer. For example, it may be useful to use a string with an indexer. Such an indexer might be implemented by searching for the string in the collection, and returning the appropriate value. As accessors can be overloaded, the string and integer versions can co-exist.  
  
## Example 2  
  
The following example declares a class that stores the days of the week. A `get` accessor takes a string, the name of a day, and returns the corresponding integer. For example, "Sunday" returns 0, "Monday" returns 1, and so on.  
  
 [!code-csharp[csProgGuideIndexers#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideIndexers/CS/Indexers.cs#2)]  
  
## Robust programming

 There are two main ways in which the security and reliability of indexers can be improved:  
  
- Be sure to incorporate some type of error-handling strategy to handle the chance of client code passing in an invalid index value. In the first example earlier in this topic, the TempRecord class provides a Length property that enables the client code to verify the input before passing it to the indexer. You can also put the error handling code inside the indexer itself. Be sure to document for users any exceptions that you throw inside an indexer accessor.  
  
- Set the accessibility of the [get](../../../csharp/language-reference/keywords/get.md) and [set](../../../csharp/language-reference/keywords/set.md) accessors to be as restrictive as is reasonable. This is important for the `set` accessor in particular. For more information, see [Restricting Accessor Accessibility](../../../csharp/programming-guide/classes-and-structs/restricting-accessor-accessibility.md).  
  
## See also

- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [Indexers](../../../csharp/programming-guide/indexers/index.md)
- [Properties](../../../csharp/programming-guide/classes-and-structs/properties.md)
