# F# coding conventions

The following conventions are formulated from experience working with large F# codebases. The [Five principles of good F# code](index.md#five-principles-of-good-f-code) are the foundation of each recommendation. They are related to the [F# component design guidelines](component-design-guidelines.md), but are generally applicable for any F# code, not just components such as libraries.

## Using namespaces and modules for code organization

F# features two primarily ways to organize code: modules and namespaces. They are very similar, but do have the following differences:

* Namespaces are compiled as .NET namespaces. Modules are compared as static classes.
* Namespaces are always top-level. Modules can be top-level and nested within other modules.
* Namespaces can span mutiple files. Modules cannot.
* Modules can be decorated with `[<RequireQualifiedAccess>]` and `[<AutoOpen>]`.

### Prefer namespaces at the top level

For any publically consumable code, namespaces are preferential to modules at the top level. Because they are compiled as .NET namespaces, they are consumable from C# with no issue.

```fsharp
// Good!
namespace MyCode

type MyClass() =
    ...
```

Using a top-level module may not appear different when called only from F#, but should your code change to be consumed by C#, callers may be surprised.

```fsharp
// Bad!
module MyCode

type MyClass() =
    ...
```

### Only use `[<AutoOpen>]` for nested private modules

The `[<AutoOpen>]` can pollute callers and the answer to where something comes from is "magic". The only exception to this rule is the F# Core Library itself (though this fact is also a bit controversial).

However, it is a great convenience if you have more complicated helper functionality for a public API that you wish to organize separately from that public API.

```fsharp
module MyAPI =
    [<AutoOpen>]
    module private Helpers =
        let helper1 x y z =
            ...


    let myFunction1 x =
        let y = ...
        let z = ...

        helper1 x y z
```

This lets you cleanly separate implementation details from the public API of a function without having to fully qualify a helper each time you call it.

### Use `[<RequireQualifiedAccess>]` whenever names could conflict or you feel it helps with readability

Adding the `[<RequireQualifiedAccess>]` attribute to a module indicates that the module may not be opened and that references to the elements of the module require explicit qualified access. For example, the Microsoft.FSharp.Collections.List module has this attribute.

This is useful when functions and values in the module have names that are likely to conflict with names in other modules. Requiring qualified access can greatly increase the long-term maintainability and evolvability of a library.

```fsharp
[<RequireQualifiedAccess>]
module StringHelpers =
    let parse s = ...

...

let s = getAString()
let parsed = StringHepers.parse s // Must qualify to use 'parse'
```

## Use classes to contain values which have side effects

There are numerous places where initializing a value can have side effects, such as instantiating a context to a database or other remote resource. It is tempting to initialize such things in a module and use it in subsequent functions:

```fsharp
// This is really bad!
module MyApi =
    let dep1 = File.ReadAllText "/Users/{your name}/connectionstring.txt"
    let dep2 = Environment.GetEnvironmentVariable "DEP_2"
    let dep3 = Random().Next()
 
    let function1 arg = doStuffWith dep1 dep2 dep3 arg
    let function2 arg = doSutffWith dep1 dep2 dep3 arg
```

This is a very bad idea for a few reasons:

First, it makes the API itself reliant on global state. Secondly, it pushes application configuration into the codebase itself. This is very difficult to maintain for larger codebases.

Finally, and this is perhaps the most insidious, is that module initialization compiles into a static constructor for the entire compilation unit. If any error occurs in let-bound value initialization in that module, it manifests as a `TypeInitializationException` which is then cached for the entire lifetime of the application. There is no way to tell what actually went wrong when this happens.

Instead, just use a simple class to hold dependencies:

```fsharp
type MyParametricApi(dep1, dep2, dep3) =
    member __.Function1 arg1 = doStuffWith dep1 dep2 dep3 arg1
    member __.Function2 arg2 = doStuffWith' dep1 dep2 dep3 arg2
```

This enables the following:

1. Pushing any dependent state outside of the API itself.
2. Configuration can now be done outsie of the API.
3. Errors in initialization for dependent values are not likely to manifest as a `TypeInitializationException`.
4. The API is now easier to test.

One could even argue that the example with classes is more "functional" than the example with let-bound values in a module.

## Prefer error handling with exceptions in most cases

asdf

## Use result-based/monadic error handling only when it is part of your domain

asdf