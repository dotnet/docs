# F# code formatting guidelines

TODO

## Recommendations for F# Implementation Code

In this section, we look at a small number of recommendations when writing implementation code (as opposed to library designs). These apply to all internal and private aspects of F# coding.

### Suggested Naming Conventions in F# Implementation Code

#### ✔ Suggest using `camelCase` for class-bound, expression-bound and pattern-bound values and functions

It is common and accepted F# style to use `camelCase` for all names bound as local variables or in pattern matches and function definitions.

```fsharp
✘ let add I J = I+J

✔ let add i j = i + j
```

It is also common and accepted F# style to use camelCase for locally bound functions, e.g.

```fsharp
type MyClass() =

    let doSomething () =

    let firstResult = ...

    let secondResult = ...

    member x.Result = doSomething()
```

#### ✔ Suggest using camelCase for internal and private module-bound values and functions

It is common and accepted F# style to use camelCase for private module-bound values, including the following:

* Ad hoc functions in scripts

* Values making up the internal implementation of a module or type

```fsharp
✔ let emailMyBossTheLatestResults = ...
```

In large assemblies and implementation files, PascalCase is sometimes used to indicate major internal routines.

#### ✘ Avoid using underscores in names.

Historically, some F# libraries have used underscores in names. However, this is no longer widely accepted, partly because it clashes with .NET naming conventions. That said, some F# programmers use underscores heavily, partly for historical reasons, and tolerance and respect is important. However, be aware that the style is often disliked by others who have a choice about whether to use it.

Note Some F# programmers choose to use naming conventions much more closely associated with OCaml, Python, or with a particular application domain such as hardware verification.

### Suggested Coding Conventions in F# Implementation Code

#### ✔ Do use standard F# operators

The following operators are defined in the F# standard library and should be used instead of defining equivalents. Using these operators is recommended as it tends to make code more readable and idiomatic. Developers with a background in OCaml or other functional programming language may be accustomed to different idioms, and this list summarizes the recommended F# operators.

```fsharp
x |> f // Forward pipeline
f >> g // Forward composition
x |> ignore // Throwing away a value
x + y // Overloaded addition (including string concatenation)
x - y // Overloaded subtraction
x * y // Overloaded multiplication
x / y // Overloaded division
x % y // Overloaded modulus
x && y // Lazy/short-cut "and"
x || y // Lazy/short-cut "or"
x <<< y // Bitwise left shift
x >>> y // Bitwise right shift
x ||| y // Bitwise or, also for working with “flags” enumeration
x &&& y // Bitwise and, also for working with “flags” enumeration
x ^^^ y // Bitwise xor, also for working with “flags” enumeration
```

#### ✔ Do place pipeline operator `|>` at the start of a line when writing multi-line pipeline series.

People often ask how to format pipelines. We recommend this style:

```fsharp
let allTypes =
    System.AppDomain.CurrentDomain.GetAssemblies()
    |> Array.map (fun assem -> assem.GetTypes())
    |> Array.concat
```

Note that this does not apply when piping on a single line (e.g. `expr |> ignore`, `expr |> box`)

#### ✔ Consider using the prefix syntax for generics (`Foo<T>`) in preference to postfix syntax (`T Foo`), with four notable exceptions (list, option, array, ref).

F# inherits both the postfix ML style of naming generic types, e.g. `int list` as well as the prefix .NET style, e.g. `list<int>`. You should prefer the .NET style, except for four specific types. For F# lists, use the postfix form: `int list` rather than `list<int>`. For options, use the postfix form: `int option` rather than `option<int>`. For arrays, use the syntactic name `int[]` rather than either `int array` or `array<int>`. For refs, use `int ref` rather than `ref<int>` or `Ref<int>`. For all other types, use the prefix form: `HashSet<int>`, `Dictionary<string,int>`, since this conforms to .NET standards.

#### ✔ Consider using `//` comments in preference to `(*…*)` comments.

Line comments // are easier to see in code because they appear consistently at the beginning of lines. They are also typically more predictable when reading code line by line. Tools like Visual Studio also make it particularly easy to comment/uncomment whole blocks with //.