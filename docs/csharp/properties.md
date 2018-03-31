---
title: Properties
description: Learn about C# properties, which include features for validation, computed values, lazy evaluation, and property changed notifications. 
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 04/03/2017
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 6950d25a-bba1-4744-b7c7-a3cc90438c55
---

# Properties

Properties are first class citizens in C#. The language
defines syntax that enables developers to write code
that accurately expresses their design intent.

Properties behave like fields when they are accessed.
However, unlike fields, properties are implemented
with accessors that define the statements executed
when a property is accessed or assigned.

## Property Syntax

The syntax for properties is a natural extension to
fields. A field defines a storage location:

```csharp
public class Person
{
    public string FirstName;
    // remaining implementation removed from listing
}
```

A property definition contains declarations for a `get` and
`set` accessor that retrieves and assigns the value of that
property:

```csharp
public class Person
{
    public string FirstName { get; set; }

    // remaining implementation removed from listing
}
```

The syntax shown above is the *auto property* syntax. The compiler
generates the storage location for the field that backs up the
property. The compiler also implements the body of the `get` and `set` accessors.

Sometimes, you need to initialize a property to
a value other than the default for its type.  C# enables
that by setting a value after the closing brace for the
property. You may prefer the initial value for the `FirstName`
property to be the empty string rather than `null`. You would
specify that as shown below:

```csharp
public class Person
{
    public string FirstName { get; set; } = string.Empty;

    // remaining implementation removed from listing
}
```

This is most useful for read-only properties, as you'll see later
in this topic.

You can also define the storage yourself, as shown below:

```csharp
public class Person
{
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    private string firstName;
    // remaining implementation removed from listing
}
```

When a property implementation is a single expression, you can
use *expression-bodied members* for the getter or setter:

```csharp
public class Person
{
    public string FirstName
    {
        get => firstName;
        set => firstName = value;
    }
    private string firstName;
    // remaining implementation removed from listing
}
```

This simplified syntax will be used where applicable throughout this
topic.

The property definition shown above is a read-write property. Notice
the keyword `value` in the set accessor. The `set` accessor always has
a single parameter named `value`. The `get` accessor must return a value
that is convertible to the type of the property (`string` in this example).
 
That's the basics of the syntax. There are many different variations that support
a variety of different design idioms. Let's explore those, and learn the syntax
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

```csharp
public class Person
{
    public string FirstName
    {
        get => firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("First name must not be blank");
            firstName = value;
        }
    }
    private string firstName;
    // remaining implementation removed from listing
}
```

The example above enforces the rule that the first name must not be blank
or white space. If a developer writes

```csharp
hero.FirstName = "";
```

That assignment throws an `ArgumentException`. Because a property set accessor
must have a void return type, you report errors in the set accessor by throwing an exception.

That is a simple case of validation. You can extend this same syntax to anything needed
in your scenario. You can check the relationships between different properties, or validate
against any external conditions. Any valid C# statements are valid in a property accessor.

### Read-only

Up to this point, all the property definitions you have seen are read/write properties
with public accessors. That's not the only valid accessibility for properties.
You can create read-only properties, or give different accessibility to the set and get
accessors. Suppose that your `Person` class should only enable changing the value of the
`FirstName` property from other methods in that class. You could give the set accessor
`private` accessibility instead of `public`:

```csharp
public class Person
{
    public string FirstName { get; private set; }

    // remaining implementation removed from listing
}
```

Now, the `FirstName` property can be accessed from any code, but it can only be assigned
from other code in the `Person` class.

You can add any restrictive access modifier to either the set or get accessors. Any access modifier
you place on the individual accessor must be more limited than the access modifier on the property
definition. The above is legal because the `FirstName` property is `public`, but the set accessor is
`private`. You could not declare a `private` property with a `public` accessor. Property declarations
can also be declared `protected`, `internal`, `protected internal`, `private protected` or even `private`.   

It is also legal to place the more restrictive modifier on the `get` accessor. For example, you could
have a `public` property, but restrict the `get` accessor to `private`. That scenario is rarely done
in practice.

You can also restrict modifications to a property so that it can only be set in a constructor
or a property initializer. You can modify the `Person` class so as follows:

```csharp
public class Person
{
    public Person(string firstName)
    {
        this.FirstName = firstName;
    }

    public string FirstName { get; }

    // remaining implementation removed from listing
}
```

This feature is most commonly used for initializing collections that are exposed as 
read-only properties:

```csharp
public class Measurements
{
    public ICollection<DataPoint> points { get; } = new List<DataPoint>();
}
```

### Computed Properties

A property does not need to simply return the value of a member field. You can create properties
that return a computed value. Let's expand the `Person` object to return the full name, computed
by concatenating the first and last names:

```csharp
public class Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName { get { return $"{FirstName} {LastName}"; } }
}
```

The example above uses the [string interpolation](../csharp/language-reference/tokens/interpolated.md) feature to create
the formatted string for the full name.

You can also use *expression-bodied members*, which provides a more
succinct way to create the computed `FullName` property:

```csharp
public class Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName =>  $"{FirstName} {LastName}";
}
```
 
*Expression-bodied members* use the *lambda expression* syntax to
define a method that contain a single expression. Here, that
expression returns the full name for the person object.

### Lazy Evaluated Properties

You can mix the concept of a computed property with storage and create
a *lazy evaluated property*.  For example, you could update the `FullName`
property so that the string formatting only happened the first time it
was accessed:

```csharp
public class Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    private string fullName;
    public string FullName
    {
        get
        {
            if (fullName == null)
                fullName = $"{FirstName} {LastName}";
            return fullName;
        }
    }
}
```

The above code contains a bug though. If code updates the value of
either the `FirstName` or `LastName` property, the previously evaluated
`fullName` field is invalid. You need to update the `set` accessors of the
`FirstName` and `LastName` property so that the `fullName` field is calculated
again:

```csharp
public class Person
{
    private string firstName;
    public string FirstName
    {
        get => firstName;
        set
        {
            firstName = value;
            fullName = null;
        }
    }

    private string lastName;
    public string LastName
    {
        get => lastName;
        set
        {
            lastName = value;
            fullName = null;
        }
    }

    private string fullName;
    public string FullName
    {
        get
        {
            if (fullName == null)
                fullName = $"{FirstName} {LastName}";
            return fullName;
        }
    }
}
```

This final version evaluates the `FullName` property only when needed.
If the previously calculated version is valid, it's used. If another
state change invalidates the previously calculated version, it will be
recalculated. Developers that use this class do not need to know the
details of the implementation. None of these internal changes affect the
use of the Person object. That's the key reason for using Properties to
expose data members of an object.
 
### INotifyPropertyChanged

A final scenario where you need to write code in a property accessor is to
support the `INotifyPropertyChanged` interface used to notify data binding
clients that a value has changed. When the value of a property changes, the object
raises the `PropertyChanged` event
to indicate the change. The data binding libraries, in turn, update display elements
based on that change. The code below shows how you would implement `INotifyPropertyChanged`
for the `FirstName` property of this person class.

```csharp
public class Person : INotifyPropertyChanged
{
    public string FirstName
    {
        get => firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("First name must not be blank");
            if (value != firstName)
            {
                PropertyChanged?.Invoke(this, 
                    new PropertyChangedEventArgs(nameof(FirstName)));
            }
            firstName = value;
        }
    }
    private string firstName;

    public event PropertyChangedEventHandler PropertyChanged;
    // remaining implementation removed from listing
}
```

The `?.` operator is called
the *null conditional operator*. It checks for a null reference before evaluating
the right side of the operator. The end result is that if there are no subscribers
to the `PropertyChanged` event, the code to raise the event doesn't execute. It would
throw a `NullReferenceException` without this check in that case. See the page on
[`events`](delegates-events.md) for more details. This example also uses the new
`nameof` operator to convert from the property name symbol to its text representation.
Using `nameof` can reduce errors where you have mistyped the name of the property.

Again, this is an example of a case where you can write code in your accessors to
support the scenarios you need.

## Summing up

Properties are a form of smart fields in a class or object. From
outside the object, they appear like fields in the object. However,
properties can be implemented using the full palette of C# functionality.
You can provide validation, different accessibility, lazy evaluation,
or any requirements your scenarios need.
