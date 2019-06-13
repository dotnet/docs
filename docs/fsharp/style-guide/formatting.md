---
title: F# code formatting guidelines
description: Learn guidelines for formatting F# code.
ms.date: 02/08/2019
---
# F# code formatting guidelines

This article offers guidelines for how to format your code so that your F# code is:

* Generally viewed as more legible
* Is in accordance with conventions applied by formatting tools in Visual Studio and other editors
* Similar to other code online

These guidelines are based on [A comprehensive guide to F# Formatting Conventions](https://github.com/dungpa/fantomas/blob/master/docs/FormattingConventions.md) by [Anh-Dung Phan](https://github.com/dungpa).

## General rules for indentation

F# uses significant white space by default. The following guidelines are intended to provide guidance as to how to juggle some challenges this can impose.

### Using spaces

When indentation is required, you must use spaces, not tabs. At least one space is required. Your organization can create coding standards to specify the number of spaces to use for indentation; two, three or four spaces of indentation at each level where indentation occurs is typical.

**We recommend 4 spaces per indentation.**

That said, indentation of programs is a subjective matter. Variations are OK, but the first rule you should follow is *consistency of indentation*. Choose a generally accepted style of indentation and use it systematically throughout your codebase.

## Formatting white space

F# is white space sensitive. Although most semantics from white space are covered by proper indentation, there are some other things to consider.

### Formatting operators in arithmetic expressions

Always use white space around binary arithmetic expressions:

```fsharp
let subtractThenAdd x = x - 1 + 3
```

Unary `-` operators should always have the value they are negating immediately follow:

```fsharp
// OK
let negate x = -x

// Bad
let negateBad x = - x
```

Adding a white-space character after the `-` operator can lead to confusion for others.

In summary, it's important to always:

* Surround binary operators with white space
* Never have trailing white space after a unary operator

The binary arithmetic operator guideline is especially important. Failing to surround a binary `-` operator, when combined with certain formatting choices, could lead to interpreting it as a unary `-`.

### Surround a custom operator definition with white space

Always use white space to surround an operator definition:

```fsharp
// OK
let ( !> ) x f = f x

// Bad
let (!>) x f = f x
```

For any custom operator that starts with `*` and that has more than one character, you need to add a white space to the beginning of the definition to avoid a compiler ambiguity. Because of this, we recommend that you simply surround the definitions of all operators with a single white-space character.

### Surround function parameter arrows with white space

When defining the signature of a function, use white space around the `->` symbol:

```fsharp
// OK
type MyFun = int -> int -> string

// Bad
type MyFunBad = int->int->string
```

### Surround function arguments with white space

When defining a function, use white space around each argument.

```fsharp
// OK
let myFun (a: decimal) b c = a + b + c

// Bad
let myFunBad (a:decimal)(b)c = a + b + c
```

### Type annotations

#### Right-pad function argument type annotations

When defining arguments with type annotations, use white space after the `:` symbol:

```fsharp
// OK
let complexFunction (a: int) (b: int) c = a + b + c

// Bad
let complexFunctionBad (a :int) (b :int) (c:int) = a + b + c
```

#### Surround return type annotations with white space

In a let-bound function or value type annotation (return type in the case of a function), use white space before and after the `:` symbol:

```fsharp
// OK
let expensiveToCompute : int = 0 // Type annotation for let-bound value
let myFun (a: decimal) b c : decimal = a + b + c // Type annotation for the return type of a function
// Bad
let expensiveToComputeBad1:int = 1
let expensiveToComputeBad2 :int = 2
let myFunBad (a: decimal) b c:decimal = a + b + c
```

## Formatting blank lines

* Separate top-level function and class definitions with two blank lines.
* Method definitions inside a class are separated by a single blank line.
* Extra blank lines may be used (sparingly) to separate groups of related functions. Blank lines may be omitted between a bunch of related one-liners (for example, a set of dummy implementations).
* Use blank lines in functions, sparingly, to indicate logical sections.

## Formatting comments

Generally prefer multiple double-slash comments over ML-style block comments.

```fsharp
// Prefer this style of comments when you want
// to express written ideas on multiple lines.

(*
    ML-style comments are fine, but not a .NET-ism.
    They are useful when needing to modify multi-line comments, though.
*)
```

Inline comments should capitalize the first letter.

```fsharp
let f x = x + 1 // Increment by one.
```

## Naming conventions

### Use camelCase for class-bound, expression-bound and pattern-bound values and functions

It is common and accepted F# style to use camelCase for all names bound as local variables or in pattern matches and function definitions.

```fsharp
// OK
let addIAndJ i j = i + j

// Bad
let addIAndJ I J = I+J

// Bad
let AddIAndJ i j = i + j
```

Locally-bound functions in classes should also use camelCase.

```fsharp
type MyClass() =

    let doSomething () =

    let firstResult = ...

    let secondResult = ...

    member x.Result = doSomething()
```

### Use camelCase for module-bound public functions

When a module-bound function is part of a public API, it should use camelCase:

```fsharp
module MyAPI =
    let publicFunctionOne param1 param2 param2 = ...

    let publicFunctionTwo param1 param2 param3 = ...
```

### Use camelCase for internal and private module-bound values and functions

Use camelCase for private module-bound values, including the following:

* Ad hoc functions in scripts

* Values making up the internal implementation of a module or type

```fsharp
let emailMyBossTheLatestResults =
    ...
```

### Use camelCase for parameters

All parameters should use camelCase in accordance with .NET naming conventions.

```fsharp
module MyModule =
    let myFunction paramOne paramTwo = ...

type MyClass() =
    member this.MyMethod(paramOne, paramTwo) = ...
```

### Use PascalCase for modules

All modules (top-level, internal, private, nested) should use PascalCase.

```fsharp
module MyTopLevelModule

module Helpers =
    module private SuperHelpers =
        ...

    ...
```

### Use PascalCase for type declarations, members, and labels

Classes, interfaces, structs, enumerations, delegates, records, and discriminated unions should all be named with PascalCase. Members within types and labels for records and discriminated unions should also use PascalCase.

```fsharp
type IMyInterface =
    abstract Something: int

type MyClass() =
    member this.MyMethod(x, y) = x + y

type MyRecord = { IntVal: int; StringVal: string }

type SchoolPerson =
    | Professor
    | Student
    | Advisor
    | Administrator
```

### Use PascalCase for constructs intrinsic to .NET

Namespaces, exceptions, events, and project/`.dll` names should also use PascalCase. Not only does this make consumption from other .NET languages feel more natural to consumers, it's also consistent with .NET naming conventions that you are likely to encounter.

### Avoid underscores in names

Historically, some F# libraries have used underscores in names. However, this is no longer widely accepted, partly because it clashes with .NET naming conventions. That said, some F# programmers use underscores heavily, partly for historical reasons, and tolerance and respect is important. However, be aware that the style is often disliked by others who have a choice about whether to use it.

Some exceptions includes interoperating with native components, where underscores are very common.

### Use standard F# operators

The following operators are defined in the F# standard library and should be used instead of defining equivalents. Using these operators is recommended as it tends to make code more readable and idiomatic. Developers with a background in OCaml or other functional programming language may be accustomed to different idioms. The following list summarizes the recommended F# operators.

```fsharp
x |> f // Forward pipeline
f >> g // Forward composition
x |> ignore // Discard away a value
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

### Use prefix syntax for generics (`Foo<T>`) in preference to postfix syntax (`T Foo`)

F# inherits both the postfix ML style of naming generic types (for example, `int list`) as well as the prefix .NET style (for example, `list<int>`). Prefer the .NET style, except for five specific types:

1. For F# Lists, use the postfix form: `int list` rather than `list<int>`.
2. For F# Options, use the postfix form: `int option` rather than `option<int>`.
3. For F# Value Options, use the postfix form: `int voption` rather than `voption<int>`.
4. For F# arrays, use the syntactic name `int[]` rather than `int array` or `array<int>`.
5. For Reference Cells, use `int ref` rather than `ref<int>` or `Ref<int>`.

For all other types, use the prefix form.

## Formatting tuples

A tuple instantiation should be parenthesized, and the delimiting commas within should be followed by a single space, for example: `(1, 2)`, `(x, y, z)`.

It is commonly accepted to omit parentheses in pattern matching of tuples:

```fsharp
let (x, y) = z // Destructuring
let x, y = z // OK

// OK
match x, y with
| 1, _ -> 0
| x, 1 -> 0
| x, y -> 1
```

It is also commonly accepted to omit parentheses if the tuple is the return value of a function:

```fsharp
// OK
let update model msg =
    match msg with
    | 1 -> model + 1, []
    | _ -> model, [ msg ]
```

In summary, prefer parenthesized tuple instantiations, but when using tuples for pattern matching or a return value, it is considered fine to avoid parentheses.

## Formatting discriminated union declarations

Indent `|` in type definition by 4 spaces:

```fsharp
// OK
type Volume =
    | Liter of float
    | FluidOunce of float
    | ImperialPint of float

// Not OK
type Volume =
| Liter of float
| USPint of float
| ImperialPint of float
```

## Formatting discriminated unions

Instantiated Discriminated Unions that split across multiple lines should give contained data a new scope with indentation:

```fsharp
let tree1 =
    BinaryNode
        (BinaryNode(BinaryValue 1, BinaryValue 2),
         BinaryNode(BinaryValue 3, BinaryValue 4))
```

The closing parenthesis can also be on a new line:

```fsharp
let tree1 =
    BinaryNode(
        BinaryNode(BinaryValue 1, BinaryValue 2),
        BinaryNode(BinaryValue 3, BinaryValue 4)
    )
```

## Formatting record declarations

Indent `{` in type definition by 4 spaces and start the field list on the same line:

```fsharp
// OK
type PostalAddress =
    { Address: string
      City: string
      Zip: string }
    member x.ZipAndCity = sprintf "%s %s" x.Zip x.City

// Not OK
type PostalAddress =
  { Address: string
    City: string
    Zip: string }
    member x.ZipAndCity = sprintf "%s %s" x.Zip x.City

// Unusual in F#
type PostalAddress =
    {
        Address: string
        City: string
        Zip: string
    }
```

Placing the opening token on a new line and the closing token on a new line is preferable if you are declaring interface implementations or members on the record:

```fsharp
// Declaring additional members on PostalAddress
type PostalAddress =
    {
        Address: string
        City: string
        Zip: string
    } with
    member x.ZipAndCity = sprintf "%s %s" x.Zip x.City

type MyRecord =
    {
        SomeField: int
    }
    interface IMyInterface
```

## Formatting records

Short records can be written in one line:

```fsharp
let point = { X = 1.0; Y = 0.0 }
```

Records that are longer should use new lines for labels:

```fsharp
let rainbow =
    { Boss = "Jeffrey"
      Lackeys = ["Zippy"; "George"; "Bungle"] }
```

Placing the opening token on a new line, the contents tabbed over one scope, and the closing token on a new line is preferable if you are:

* Moving records around in code with different indentation scopes
* Piping them into a function

```fsharp
let rainbow =
    {
        Boss1 = "Jeffrey"
        Boss2 = "Jeffrey"
        Boss3 = "Jeffrey"
        Boss4 = "Jeffrey"
        Boss5 = "Jeffrey"
        Boss6 = "Jeffrey"
        Boss7 = "Jeffrey"
        Boss8 = "Jeffrey"
        Lackeys = ["Zippy"; "George"; "Bungle"]
    }

type MyRecord =
    {
        SomeField: int
    }
    interface IMyInterface

let foo a =
    a
    |> Option.map (fun x ->
        {
            MyField = x
        })
```

The same rules apply for list and array elements.

## Formatting copy-and-update record expressions

A copy-and-update record expression is still a record, so similar guidelines apply.

Short expressions can fit on one line:

```fsharp
let point2 = { point with X = 1; Y = 2 }
```

Longer expressions should use new lines:

```fsharp
let rainbow2 =
    { rainbow with
        Boss = "Jeffrey"
        Lackeys = ["Zippy"; "George"; "Bungle"] }
```

And as with the record guidance, you may want to dedicate separate lines for the braces and indent one scope to the right with the expression. Note that in some special cases, such as wrapping a value with an optional without parentheses, you may need to keep a brace on one line:

```fsharp
type S = { F1: int; F2: string }
type State = { F:  S option }

let state = { F = Some { F1 = 1; F2 = "Hello" } }
let newState =
    {
        state with
            F = Some {
                    F1 = 0
                    F2 = ""
                }
    }
```

## Formatting lists and arrays

Write `x :: l` with spaces around the `::` operator (`::` is an infix operator, hence surrounded by spaces).

List and arrays declared on a single line should have a space after the opening bracket and before the closing bracket:

```fsharp
let xs = [ 1; 2; 3 ]
let ys = [| 1; 2; 3; |]
```

Always use at least one space between two distinct brace-like operators. For example, leave a space between a `[` and a `{`.

```fsharp
// OK
[ { IngredientName = "Green beans"; Quantity = 250 }
  { IngredientName = "Pine nuts"; Quantity = 250 }
  { IngredientName = "Feta cheese"; Quantity = 250 }
  { IngredientName = "Olive oil"; Quantity = 10 }
  { IngredientName = "Lemon"; Quantity = 1 } ]

// Not OK
[{ IngredientName = "Green beans"; Quantity = 250 }
 { IngredientName = "Pine nuts"; Quantity = 250 }
 { IngredientName = "Feta cheese"; Quantity = 250 }
 { IngredientName = "Olive oil"; Quantity = 10 }
 { IngredientName = "Lemon"; Quantity = 1 }]
```

The same guideline applies for lists or arrays of tuples.

Lists and arrays that split across multiple lines follow a similar rule as records do:

```fsharp
let pascalsTriangle =
    [|
        [| 1 |]
        [| 1; 1 |]
        [| 1; 2; 1 |]
        [| 1; 3; 3; 1 |]
        [| 1; 4; 6; 4; 1 |]
        [| 1; 5; 10; 10; 5; 1 |]
        [| 1; 6; 15; 20; 15; 6; 1 |]
        [| 1; 7; 21; 35; 35; 21; 7; 1 |]
        [| 1; 8; 28; 56; 70; 56; 28; 8; 1 |]
    |]
```

And as with records, declaring the opening and closing brackets on their own line will make moving code around and piping into functions easier.

## Formatting if expressions

Indentation of conditionals depends on the sizes of the expressions that make them up. If `cond`, `e1` and `e2` are short, simply write them on one line:

```fsharp
if cond then e1 else e2
```

If either `cond`, `e1` or `e2` are longer, but not multi-line:

```fsharp
if cond
then e1
else e2
```

If any of the expressions are multi-line:

```fsharp
if cond then
    e1
else
    e2
```

Multiple conditionals with `elif` and `else` are indented at the same scope as the `if`:

```fsharp
if cond1 then e1
elif cond2 then e2
elif cond3 then e3
else e4
```

### Pattern matching constructs

Use a `|` for each clause of a match with no indentation. If the expression is short, you can consider using a single line if each subexpression is also simple.

```fsharp
// OK
match l with
| { him = x; her = "Posh" } :: tail -> x
| _ :: tail -> findDavid tail
| [] -> failwith "Couldn't find David"

// Not OK
match l with
    | { him = x; her = "Posh" } :: tail -> x
    | _ :: tail -> findDavid tail
    | [] -> failwith "Couldn't find David"
```

If the expression on the right of the pattern matching arrow is too large, move it to the following line, indented one step from the `match`/`|`.

```fsharp
match lam with
| Var v -> 1
| Abs(x, body) ->
    1 + sizeLambda body
| App(lam1, lam2) ->
    sizeLambda lam1 + sizeLambda lam2

```

Pattern matching of anonymous functions, starting by `function`, should generally not indent too far. For example, indenting one scope as follows is fine:

```fsharp
lambdaList
|> List.map (function
    | Abs(x, body) -> 1 + sizeLambda 0 body
    | App(lam1, lam2) -> sizeLambda (sizeLambda 0 lam1) lam2
    | Var v -> 1)
```

Pattern matching in functions defined by `let` or `let rec` should be indented 4 spaces after starting of `let`, even if `function` keyword is used:

```fsharp
let rec sizeLambda acc = function
    | Abs(x, body) -> sizeLambda (succ acc) body
    | App(lam1, lam2) -> sizeLambda (sizeLambda acc lam1) lam2
    | Var v -> succ acc
```

We do not recommend aligning arrows.

## Formatting try/with expressions

Pattern matching on the exception type should be indented at the same level as `with`.

```fsharp
try
    if System.DateTime.Now.Second % 3 = 0 then
        raise (new System.Exception())
    else
        raise (new System.ApplicationException())
with
| :? System.ApplicationException ->
    printfn "A second that was not a multiple of 3"
| _ ->
    printfn "A second that was a multiple of 3"
```

## Formatting function parameter application

In general, most function parameter application is done on the same line.

If you wish to apply parameters to a function on a new line, indent them by one scope.

```fsharp
// OK
sprintf "\t%s - %i\n\r"
     x.IngredientName x.Quantity

// OK
sprintf
     "\t%s - %i\n\r"
     x.IngredientName x.Quantity

// OK
let printVolumes x =
    printf "Volume in liters = %f, in us pints = %f, in imperial = %f"
        (convertVolumeToLiter x)
        (convertVolumeUSPint x)
        (convertVolumeImperialPint x)
```

The same guidelines apply for lambda expressions as function arguments. If the body of a lambda expression, the body can have another line, indented by one scope

```fsharp
let printListWithOffset a list1 =
    List.iter
        (fun elem -> printfn "%d" (a + elem))
        list1

// OK if lambda body is long enough
let printListWithOffset a list1 =
    List.iter
        (fun elem ->
            printfn "%d" (a + elem))
        list1
```

However, if the body of a lambda expression is more than one line, consider factoring it out into a separate function rather than have a multi-line construct applied as a single argument to a function.

### Formatting infix operators

Separate operators by spaces. Obvious exceptions to this rule are the `!` and `.` operators.

Infix expressions are OK to lineup on same column:

```fsharp
acc +
(sprintf "\t%s - %i\n\r"
     x.IngredientName x.Quantity)

let function1 arg1 arg2 arg3 arg4 =
    arg1 + arg2 +
    arg3 + arg4
```

### Formatting pipeline operators

Pipeline `|>` operators should go underneath the expressions they operate on.

```fsharp
// Preferred approach
let methods2 =
    System.AppDomain.CurrentDomain.GetAssemblies()
    |> List.ofArray
    |> List.map (fun assm -> assm.GetTypes())
    |> Array.concat
    |> List.ofArray
    |> List.map (fun t -> t.GetMethods())
    |> Array.concat

// Not OK
let methods2 = System.AppDomain.CurrentDomain.GetAssemblies()
            |> List.ofArray
            |> List.map (fun assm -> assm.GetTypes())
            |> Array.concat
            |> List.ofArray
            |> List.map (fun t -> t.GetMethods())
            |> Array.concat
```

### Formatting modules

Code in a local module must be indented relative to the module, but code in a top-level module should not be indented. Namespace elements do not have to be indented.

```fsharp
// A is a top-level module.
module A

let function1 a b = a - b * b
```

```fsharp
// A1 and A2 are local modules.
module A1 =
    let function1 a b = a*a + b*b

module A2 =
    let function2 a b = a*a - b*b
```

### Formatting object expressions and interfaces

Object expressions and interfaces should be aligned in the same way with `member` being indented after 4 spaces.

```fsharp
let comparer =
    { new IComparer<string> with
          member x.Compare(s1, s2) =
              let rev (s: String) =
                  new String (Array.rev (s.ToCharArray()))
              let reversed = rev s1
              reversed.CompareTo (rev s2) }
```

### Formatting white space in expressions

Avoid extraneous white space in F# expressions.

```fsharp
// OK
spam (ham.[1])

// Not OK
spam ( ham.[ 1 ] )
```

Named arguments should also not have space surrounding the `=`:

```fsharp
// OK
let makeStreamReader x = new System.IO.StreamReader(path=x)

// Not OK
let makeStreamReader x = new System.IO.StreamReader(path = x)
```

## Formatting attributes

[Attributes](../language-reference/attributes.md) are placed above a construct:

```fsharp
[<SomeAttribute>]
type MyClass() = ...

[<RequireQualifiedAccess>]
module M =
    let f x = x

[<Struct>]
type MyRecord =
    { Label1: int
      Label2: string }
```

### Formatting attributes on parameters

Attributes can also be places on parameters. In this case, place then on the same line as the parameter and before the name:

```fsharp
// Defines a class that takes an optional value as input defaulting to false.
type C() =
    member __.M([<Optional; DefaultParameterValue(false)>] doSomething: bool)
```

### Formatting multiple attributes

When multiple attributes are applied to a construct that is not a parameter, they should be placed such that there is one attribute per line:

```fsharp
[<Struct>]
[<IsByRefLike>]
type MyRecord =
    { Label1: int
      Label2: string }
```

When applied to a parameter, they must be on the same line and separated by a `;` separator.

## Formatting literals

[F# literals](../language-reference/literals.md) using the `Literal` attribute should place the attribute on its own line and use PascalCase naming:

```fsharp
[<Literal>]
let Path = __SOURCE_DIRECTORY__ + "/" + __SOURCE_FILE__

[<Literal>]
let MyUrl = "www.mywebsitethatiamworkingwith.com"
```

Avoid placing the attribute on the same line as the value.
