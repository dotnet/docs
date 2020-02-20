---
title: Properties
description: Learn about C# properties, which include features for validation, computed values, lazy evaluation, and property changed notifications.
ms.technology: csharp-fundamentals
ms.date: 04/25/2018
---
# Properties

Properties are first class citizens in C#. The language
defines syntax that enables developers to write code
that accurately expresses their design intent.

Properties behave like fields when they are accessed.
However, unlike fields, properties are implemented
with accessors that define the statements executed
when a property is accessed or assigned.

## Property syntax

The syntax for properties is a natural extension to
fields. A field defines a storage location:

[!code-csharp[Person class with public fields](../../samples/snippets/csharp/properties/Person.cs#1)]

A property definition contains declarations for a `get` and
`set` accessor that retrieves and assigns the value of that
property:

[!code-csharp[Person class with public properties](../../samples/snippets/csharp/properties/Person.cs#2)]

The syntax shown above is the *auto property* syntax. The compiler
generates the storage location for the field that backs up the
property. The compiler also implements the body of the `get` and `set` accessors.

Sometimes, you need to initialize a property to
a value other than the default for its type.  C# enables
that by setting a value after the closing brace for the
property. You may prefer the initial value for the `FirstName`
property to be the empty string rather than `null`. You would
specify that as shown below:

[!code-csharp[Person class with properties and initializer](../../samples/snippets/csharp/properties/Person.cs#3)]

Specific initialization is most useful for read-only properties, as you'll see later
in this article.

You can also define the storage yourself, as shown below:

[!code-csharp[Person class with properties and backing field](../../samples/snippets/csharp/properties/Person.cs#4)]

When a property implementation is a single expression, you can
use *expression-bodied members* for the getter or setter:

[!code-csharp[Person class with properties and expression bodied getters and setters](../../samples/snippets/csharp/properties/Person.cs#5)]

This simplified syntax will be used where applicable throughout this
article.

The property definition shown above is a read-write property. Notice
the keyword `value` in the set accessor. The `set` accessor always has
a single parameter named `value`. The `get` accessor must return a value
that is convertible to the type of the property (`string` in this example).

That's the basics of the syntax. There are many different variations that support
a variety of different design idioms. Let's explore, and learn the syntax
options for each.

## Scenarios

The examples above showed one of the simplest cases of property definition:
a read-write property with no validation. By writing the code you want in the
`get` and `set` accessors, you can create many different scenarios.

### Validation

You can write code in the `set` accessor to ensure that the values represented
by a property are always valid. For example, suppose one rule for the `Person`
class is that the name cannot be blank or white space. You would write that as
follows:

[!code-csharp[Validating property setters](../../samples/snippets/csharp/properties/Person.cs#6)]

The preceding example can be simplified by using a`throw` expression as part
of the property setter validation:

[!code-csharp[Validating property setters](../../samples/snippets/csharp/properties/Person.cs#7)]

The example above enforces the rule that the first name must not be blank
or white space. If a developer writes

```csharp
hero.FirstName = "";
```

That assignment throws an `ArgumentException`. Because a property set accessor
must have a void return type, you report errors in the set accessor by throwing an exception.

You can extend this same syntax to anything needed
in your scenario. You can check the relationships between different properties, or validate
against any external conditions. Any valid C# statements are valid in a property accessor.

### Read-only

Up to this point, all the property definitions you have seen are read/write properties
with public accessors. That's not the only valid accessibility for properties.
You can create read-only properties, or give different accessibility to the set and get
accessors. Suppose that your `Person` class should only enable changing the value of the
`FirstName` property from other methods in that class. You could give the set accessor
`private` accessibility instead of `public`:

[!code-csharp[Using a private setter for a publicly readonly property](../../samples/snippets/csharp/properties/Person.cs#8)]

Now, the `FirstName` property can be accessed from any code, but it can only be assigned
from other code in the `Person` class.

You can add any restrictive access modifier to either the set or get accessors. Any access modifier
you place on the individual accessor must be more limited than the access modifier on the property
definition. The above is legal because the `FirstName` property is `public`, but the set accessor is
`private`. You could not declare a `private` property with a `public` accessor. Property declarations
can also be declared `protected`, `internal`, `protected internal`, or, even `private`.

It is also legal to place the more restrictive modifier on the `get` accessor. For example, you could
have a `public` property, but restrict the `get` accessor to `private`. That scenario is rarely done
in practice.

You can also restrict modifications to a property so that it can only be set in a constructor
or a property initializer. You can modify the `Person` class so as follows:

[!code-csharp[A readonly auto implemented property](../../samples/snippets/csharp/properties/Person.cs#9)]

This feature is most commonly used for initializing collections that are exposed as
read-only properties:

```csharp
public class Measurements
{
    public ICollection<DataPoint> points { get; } = new List<DataPoint>();
}
```

### Computed properties

A property does not need to simply return the value of a member field. You can create properties
that return a computed value. Let's expand the `Person` object to return the full name, computed
by concatenating the first and last names:

[!code-csharp[A computed property](../../samples/snippets/csharp/properties/Person.cs#10)]

The example above uses the [string interpolation](./language-reference/tokens/interpolated.md) feature to create
the formatted string for the full name.

You can also use an *expression-bodied member*, which provides a more
succinct way to create the computed `FullName` property:

[!code-csharp[A computed property using an expression bodied member](../../samples/snippets/csharp/properties/Person.cs#11)]

*Expression-bodied members* use the *lambda expression* syntax to
define methods that contain a single expression. Here, that
expression returns the full name for the person object.

### Cached evaluated properties

You can mix the concept of a computed property with storage and create
a *cached evaluated property*.  For example, you could update the `FullName`
property so that the string formatting only happened the first time it
was accessed:

[!code-csharp[Caching the value of a computed property](../../samples/snippets/csharp/properties/Person.cs#12)]

The above code contains a bug though. If code updates the value of
either the `FirstName` or `LastName` property, the previously evaluated
`fullName` field is invalid. You modify the `set` accessors of the
`FirstName` and `LastName` property so that the `fullName` field is calculated
again:

[!code-csharp[Invalidating the cache correctly](../../samples/snippets/csharp/properties/Person.cs#13)]

This final version evaluates the `FullName` property only when needed.
If the previously calculated version is valid, it's used. If another
state change invalidates the previously calculated version, it will be
recalculated. Developers that use this class do not need to know the
details of the implementation. None of these internal changes affect the
use of the Person object. That's the key reason for using Properties to
expose data members of an object.

### Attaching attributes to auto-implemented properties

Beginning with C# 7.3, field attributes can be attached to the compiler
generated backing field in auto-implemented properties. For example, consider
a revision to the `Person` class that adds a unique integer `Id` property.
You write the`Id` property using an auto-implemented property, but your design does
not call for persisting the `Id` property. The <xref:System.NonSerializedAttribute>
can only be attached to fields, not properties. You can attach the
<xref:System.NonSerializedAttribute> to the backing field for the `Id` property
by using the `field:` specifier on the attribute, as shown in the following example:

[!code-csharp[Attaching attributes to a backing field](../../samples/snippets/csharp/properties/Person.cs#14)]

This technique works for any attribute you attach to the backing field on the
auto-implemented property.

### Implementing INotifyPropertyChanged

A final scenario where you need to write code in a property accessor is to
support the <xref:System.ComponentModel.INotifyPropertyChanged> interface used to notify data binding
clients that a value has changed. When the value of a property changes, the object
raises the <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged?displayProperty=nameWithType>
event to indicate the change. The data binding libraries, in turn, update display elements
based on that change. The code below shows how you would implement `INotifyPropertyChanged`
for the `FirstName` property of this person class.

[!code-csharp[invalidating the cache correctly](../../samples/snippets/csharp/properties/Person.cs#15)]

The `?.` operator is called
the *null conditional operator*. It checks for a null reference before evaluating
the right side of the operator. The end result is that if there are no subscribers
to the `PropertyChanged` event, the code to raise the event doesn't execute. It would
throw a `NullReferenceException` without this check in that case. For more information,
see [`events`](events-overview.md). This example also uses the new
`nameof` operator to convert from the property name symbol to its text representation.
Using `nameof` can reduce errors where you have mistyped the name of the property.

Again, implementing <xref:System.ComponentModel.INotifyPropertyChanged> is an
example of a case where you can write code in your accessors to support the scenarios you need.

## Summing up

Properties are a form of smart fields in a class or object. From
outside the object, they appear like fields in the object. However,
properties can be implemented using the full palette of C# functionality.
You can provide validation, different accessibility, lazy evaluation,
or any requirements your scenarios need.
