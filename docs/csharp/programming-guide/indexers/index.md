---
title: "Indexers - C# Programming Guide"
ms.custom: seodec18
ms.date: 03/10/2017
f1_keywords: 
  - "cs.indexers"
helpviewer_keywords: 
  - "indexers [C#]"
  - "C# language, indexers"
ms.assetid: 022cd27d-d5e0-4cfe-8b97-dc018cc3355d
---
# Indexers (C# Programming Guide)

Indexers allow instances of a class or struct to be indexed just like arrays. The indexed value can be set or retrieved without explicitly specifying a type or instance member. Indexers resemble [properties](../classes-and-structs/properties.md) except that their accessors take parameters.  
 
 The following example defines a generic class with simple [get](../../language-reference/keywords/get.md) and [set](../../language-reference/keywords/set.md) accessor methods to assign and retrieve values. The `Program` class creates an instance of this class for storing strings.  
  
 [!code-csharp[indexers#1](../../../../samples/snippets/csharp/programming-guide/indexers/indexer-1.cs)]  
  
> [!NOTE]
>  For more examples, see [Related Sections](./index.md#BKMK_RelatedSections).  
  
## Expression Body Definitions  
 
It is common for an indexer's get or set accessor to consist of a single statement that either returns or sets a value. Expression-bodied members provide a simplified syntax to support this scenario. Starting with C# 6, a read-only indexer can be implemented as an expression-bodied member, as the following example shows.

[!code-csharp[indexers#2](../../../../samples/snippets/csharp/programming-guide/indexers/indexer-2.cs)]  

Note that `=>` introduces the expression body, and that the `get` keyword is not used. 

Starting with C# 7.0, both the get and set accessor can be an implemented as expression-bodied members. In this case, both `get` and `set` keywords must be used. For example:

[!code-csharp[indexers#3](../../../../samples/snippets/csharp/programming-guide/indexers/indexer-3.cs)]  
  
## Indexers Overview  
  
- Indexers enable objects to be indexed in a similar manner to arrays.  
  
- A `get` accessor returns a value. A `set` accessor assigns a value.  
  
- The [this](../../language-reference/keywords/this.md) keyword is used to define the indexer.  
  
- The [value](../../language-reference/keywords/value.md) keyword is used to define the value being assigned by the `set` indexer.  
  
- Indexers do not have to be indexed by an integer value; it is up to you how to define the specific look-up mechanism.  
  
- Indexers can be overloaded.  
  
- Indexers can have more than one formal parameter, for example, when accessing a two-dimensional array.  
  
## <a name="BKMK_RelatedSections"></a> Related Sections  
  
- [Using Indexers](./using-indexers.md)  
  
- [Indexers in Interfaces](./indexers-in-interfaces.md)  
  
- [Comparison Between Properties and Indexers](./comparison-between-properties-and-indexers.md)  
  
- [Restricting Accessor Accessibility](../classes-and-structs/restricting-accessor-accessibility.md)  
  
## C# Language Specification  

For more information, see [Indexers](~/_csharplang/spec/classes.md#indexers) in the [C# Language Specification](../../language-reference/language-specification/index.md). The language specification is the definitive source for C# syntax and usage.
  
## See also

- [C# Programming Guide](../index.md)
- [Properties](../classes-and-structs/properties.md)
