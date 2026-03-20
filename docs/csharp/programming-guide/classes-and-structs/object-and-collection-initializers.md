---
title: "Object and collection initializers"
description: Object initializers in C# assign values to accessible fields or properties of an object at creation after invoking a constructor.
ms.date: 02/04/2026
helpviewer_keywords: 
  - "object initializers [C#]"
  - "collection initializers [C#]"
---
# Object and collection initializers (C# programming guide)

C# enables you to instantiate an object or collection and perform member assignments in a single statement.

## Object initializers

Object initializers let you assign values to any accessible fields or properties of an object when you create it. You don't need to invoke a constructor and then use assignment statements. The object initializer syntax enables you to specify arguments for a constructor or omit the arguments and parentheses. For guidance on using object initializers consistently, see [Use object initializers (style rule IDE0017)](../../../fundamentals/code-analysis/style-rules/ide0017.md). The following example shows how to use an object initializer with a named type, `Cat`, and how to invoke the parameterless constructor. Note the use of automatically implemented properties in the `Cat` class. For more information, see [Automatically implemented properties](auto-implemented-properties.md).

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="CatDeclaration":::
:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="ObjectPropertyInitialization":::

The object initializer syntax allows you to create an instance and assign the newly created object, with its assigned properties, to the variable in the assignment.

Starting with nested object properties, you can use object initializer syntax without the `new` keyword. This syntax, `Property = { ... }`, enables you to initialize members of existing nested objects, which is useful with read-only properties. For more information, see [Object Initializers with class-typed properties](#object-initializers-with-class-typed-properties).

Object initializers can set indexers, in addition to assigning fields and properties. Consider this basic `Matrix` class:

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="MatrixDeclaration":::

You can initialize the identity matrix by using the following code:

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="MatrixInitialization":::

Any accessible indexer that contains an accessible setter can be used as one of the expressions in an object initializer, regardless of the number or types of arguments. The index arguments form the left side of the assignment, and the value is the right side of the expression. For example, the following initializers are all valid if `IndexersExample` has the appropriate indexers:

```csharp
var thing = new IndexersExample
{
    name = "object one",
    [1] = '1',
    [2] = '4',
    [3] = '9',
    Size = Math.PI,
    ['C',4] = "Middle C"
}
```

For the preceding code to compile, the `IndexersExample` type must have the following members:

```csharp
public string name;
public double Size { set { ... }; }
public char this[int i] { set { ... }; }
public string this[char c, int i] { set { ... }; }
```

## Object initializers with anonymous types

Although you can use object initializers in any context, they're especially useful in Language-Integrated Query (LINQ) expressions. Query expressions frequently use [anonymous types](../../fundamentals/types/anonymous-types.md), which you can only initialize by using an object initializer, as shown in the following declaration.

```csharp
var pet = new { Age = 10, Name = "Fluffy" };
```

By using anonymous types, the `select` clause in a LINQ query expression can transform objects of the original sequence into objects whose value and shape differ from the original. You might want to store only a part of the information from each object in a sequence. In the following example, assume that a product object (`p`) contains many fields and methods, and that you're only interested in creating a sequence of objects that contain the product name and the unit price.

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="AnonymousUse":::

When you execute this query, the `productInfos` variable contains a sequence of objects that you can access in a `foreach` statement as shown in this example:

```csharp
foreach(var p in productInfos){...}
```

Each object in the new anonymous type has two public properties that receive the same names as the properties or fields in the original object. You can also rename a field when you create an anonymous type. The following example renames the `UnitPrice` field to `Price`.

```csharp
select new {p.ProductName, Price = p.UnitPrice};
```

## Object initializers with the `required` modifier

Use the `required` keyword to force callers to set the value of a property or field by using an object initializer. You don't need to set required properties as constructor parameters. The compiler ensures all callers initialize those values.

```csharp
public class Pet
{
    public required int Age;
    public string Name;
}

// `Age` field is necessary to be initialized.
// You don't need to initialize `Name` property
var pet = new Pet() { Age = 10};

// Compiler error:
// Error CS9035 Required member 'Pet.Age' must be set in the object initializer or attribute constructor.
// var pet = new Pet();
```

It's a typical practice to guarantee that your object is properly initialized, especially when you have multiple fields or properties to manage and don't want to include them all in the constructor.

## Object initializers with the `init` accessor

By using an `init` accessor, you can make sure the object doesn't change after initializtion. It helps to restrict the setting of the property value.

```csharp
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; init; }
}

// The `LastName` property can be set only during initialization. It CAN'T be modified afterwards.
// The `FirstName` property can be modified after initialization.
var pet = new Person() { FirstName = "Joe", LastName = "Doe"};

// You can assign the FirstName property to a different value.
pet.FirstName = "Jane";

// Compiler error:
// Error CS8852  Init - only property or indexer 'Person.LastName' can only be assigned in an object initializer,
//               or on 'this' or 'base' in an instance constructor or an 'init' accessor.
// pet.LastName = "Kowalski";
```

Required init-only properties support immutable structures while allowing natural syntax for users of the type.

## Object initializers with class-typed properties

When you initialize objects with class-typed properties, you can use two different syntaxes:

1. **Object initializer without `new` keyword**: `Property = { ... }`
1. **Object initializer with `new` keyword**: `Property = new() { ... }`

These syntaxes behave differently. The following example demonstrates both approaches:

:::code language="csharp" source="./snippets/object-collection-initializers/HowToClassTypedInitializer.cs" id="HowToClassTypedInitializer":::

### Key differences

- **Without `new` keyword** (`ClassB = { BI = 100003 }`): This syntax modifies the existing instance of the property that the object constructor created. It calls member initializers on the existing object.

- **With `new` keyword** (`ClassB = new() { BI = 100003 }`): This syntax creates a new instance and assigns it to the property, replacing any existing instance.

The initializer without `new` reuses the current instance. In the previous example, ClassB's values are: `100003` (new value assigned), `true` (kept from EmbeddedClassTypeA's initialization), `BBBabc` (unchanged default from EmbeddedClassTypeB).

### Object initializers without `new` for read-only properties

The syntax without `new` is useful with read-only properties. You can't assign a new instance but you can still initialize the existing instance's members:

:::code language="csharp" source="./snippets/object-collection-initializers/ObjectInitializerWithoutNew.cs" id="ReadOnlyPropertyExample":::

This approach allows you to initialize nested objects even when the containing property doesn't have a setter.

## Collection initializers

Collection initializers let you specify one or more element initializers when you initialize a collection type that implements <xref:System.Collections.IEnumerable> and has an `Add` method with the appropriate signature as an instance method or an extension method. The element initializers can be a value, an expression, or an object initializer. By using a collection initializer, you don't have to specify multiple calls; the compiler adds the calls automatically. For guidance on using collection initializers consistently, see [Use collection initializers (style rule IDE0028)](../../../fundamentals/code-analysis/style-rules/ide0028.md). Collection initializers are also useful in [LINQ queries](../../linq/index.md).

The following example shows two simple collection initializers:

```csharp
List<int> digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
List<int> digits2 = new List<int> { 0 + 1, 12 % 3, MakeInt() };
```

The following collection initializer uses object initializers to initialize objects of the `Cat` class defined in a previous example. The individual object initializers are enclosed in braces and separated by commas.

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="ListInitializer":::

You can specify [null](../../language-reference/keywords/null.md) as an element in a collection initializer if the collection's `Add` method allows it.  

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="ListInitializerWithNull":::

You can use a spread element to create one list that copies other list or lists.

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="ListInitializerWithSpreadOperator":::

And include additional elements along with using a spread element.

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="ListInitializerWithSpreadOperatorAndAdditionalElement":::

You can specify indexed elements if the collection supports read / write indexing.

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="DictionaryIndexerInitializer":::

The preceding sample generates code that calls the <xref:System.Collections.Generic.Dictionary%602.Item(%600)> to set the values. You can also initialize dictionaries and other associative containers by using the following syntax. Instead of indexer syntax, with parentheses and an assignment, it uses an object with multiple values:

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="DictionaryAddInitializer":::

This initializer example calls <xref:System.Collections.Generic.Dictionary%602.Add(%600,%601)> to add the three items into the dictionary. These two different ways to initialize associative collections have slightly different behavior because of the method calls the compiler generates. Both variants work with the `Dictionary` class. Other types might only support one or the other based on their public API.

### Collection expression arguments

Starting in C# 15, use the `with(...)` element as the first element in a [collection expression](../../language-reference/operators/collection-expressions.md) to pass arguments to the collection's constructor. By using this feature, you can specify capacity, comparers, or other constructor parameters directly within the collection expression syntax:

:::code language="csharp" source="./snippets/object-collection-initializers/CollectionExpressionArguments.cs" id="CollectionExpressionWithArguments":::

For more information about collection expression arguments, including supported target types and restrictions, see [Collection expression arguments](../../language-reference/operators/collection-expressions.md#collection-expression-arguments).

## Object initializers with collection read-only property initialization

Some classes have collection properties where the property is read-only, like the `Cats` property of `CatOwner` in the following case:

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="CatOwnerDeclaration":::

You can't use the collection initializer syntax discussed earlier since the property can't be assigned a new list:

```csharp
CatOwner owner = new CatOwner
{
    Cats = new List<Cat>
    {
        new Cat{ Name = "Sylvester", Age=8 },
        new Cat{ Name = "Whiskers", Age=2 },
        new Cat{ Name = "Sasha", Age=14 }
    }
};
```

However, you can add new entries to `Cats` by using the initialization syntax and omitting the list creation (`new List<Cat>`), as shown in the following example:

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="ReadOnlyPropertyCollectionInitializer":::

The set of entries to add appears surrounded by braces. The preceding code is identical to writing:

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="ReadOnlyPropertyCollectionInitializerTranslation":::

## Examples

The following example combines the concepts of object and collection initializers.

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="FullExample":::

The following example shows an object that implements <xref:System.Collections.IEnumerable> and contains an `Add` method with multiple parameters. It uses a collection initializer with multiple elements per item in the list that correspond to the signature of the `Add` method.

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="FullListExample":::

`Add` methods can use the `params` keyword to take a variable number of arguments, as shown in the following example. This example also demonstrates the custom implementation of an indexer to initialize a collection using indexes. Starting with C# 13, the `params` parameter isn't restricted to an array. It can be a collection type or interface.

:::code language="csharp" source="./snippets/object-collection-initializers/BasicObjectInitializers.cs" id="FullDictionaryInitializer":::
