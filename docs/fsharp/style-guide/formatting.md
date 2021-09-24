---
title: F# code formatting guidelines
description: Learn guidelines for formatting F# code.
ms.date: 09/19/2021
---
# F# code formatting guidelines

This article offers guidelines for how to format your code so that your F# code is:

* More legible
* In accordance with conventions applied by formatting tools in Visual Studio Code and other editors
* Similar to other code online

These guidelines are based on [A comprehensive guide to F# Formatting Conventions](https://github.com/dungpa/fantomas/blob/master/docs/FormattingConventions.md) by [Anh-Dung Phan](https://github.com/dungpa).

See also [Coding conventions](conventions.md) and [Component design guidelines](component-design-guidelines.md), which also covers naming conventions.

## General rules for formatting

F# uses significant white space by default and is white space sensitive.
The following guidelines are intended to provide guidance as to how to juggle some challenges this can impose.

### Use spaces not tabs

When indentation is required, you must use spaces, not tabs. F# code does not use tabs and the compiler will give an error if a tab character is encountered outside
a string literal or comment.

### Use consistent indentation

When indenting, at least one space is required. Your organization can create coding standards to specify the number of spaces to use for indentation; two, three, or four spaces of indentation at each level where indentation occurs is typical.

**We recommend four spaces per indentation.**

That said, indentation of programs is a subjective matter. Variations are OK, but the first rule you should follow is *consistency of indentation*. Choose a generally accepted style of indentation and use it systematically throughout your codebase.

### Use an automatic code formatter

The [Fantomas code formatter](https://github.com/fsprojects/fantomas/#fantomas) is the F# community standard tool for automatic code formatting. The default
settings correspond to this style guide.

We strongly recommend the use of this code formatter. Within F# teams, code formatting specifications should be agreed and codified in terms
of an agreed settings file for the code formatter checked into the team repository.

### Avoid formatting that is sensitive to name length

Seek to avoid indentation and alignment that is sensitive to naming:

```fsharp
// ✔️ OK
let myLongValueName =
    someExpression
    |> anotherExpression

// ❌ Not OK
let myLongValueName = someExpression
                      |> anotherExpression
```

The primary reasons for avoiding this are:

* Important code is moved far to the right
* There is less width left for the actual code
* Renaming can break the alignment

### Avoid extraneous white space

Avoid extraneous white space in F# code, except where described in this style guide.

```fsharp
// ✔️ OK
spam (ham 1)

// ❌ Not OK
spam ( ham 1 )
```

## Formatting comments

Prefer multiple double-slash comments over block comments.

```fsharp
// Prefer this style of comments when you want
// to express written ideas on multiple lines.

(*
    Block comments can be used, but use sparingly.
    They are useful when eliding code sections.
*)
```

Comments should capitalize the first letter and be well-formed phrases or sentences.

```fsharp
// ✔️ A good comment.
let f x = x + 1 // Increment by one.

// ❌ two poor comments
let f x = x + 1 // plus one
```

For formatting XML doc comments, see "Formatting declarations" below.

## Formatting expressions

This section discusses formatting expressions of different kinds.

### Formatting string expressions

String literals and interpolated strings can just be left on a single line, regardless of how long the line is.

```fsharp
let serviceStorageConnection =
    $"DefaultEndpointsProtocol=https;AccountName=%s{serviceStorageAccount.Name};AccountKey=%s{serviceStorageAccountKey.Value}"
```

Multi-line interpolated expressions are discouraged. Instead, bind the expression result to a value and use that in the interpolated string.

### Formatting tuple expressions

A tuple instantiation should be parenthesized, and the delimiting commas within it should be followed by a single space, for example: `(1, 2)`, `(x, y, z)`.

```fsharp
// ✔️ OK
let pair = (1, 2)
let triples = [ (1, 2, 3); (11, 12, 13) ]
```

It is commonly accepted to omit parentheses in pattern matching of tuples:

```fsharp
// ✔️ OK
let (x, y) = z
let x, y = z

// ✔️ OK
match x, y with
| 1, _ -> 0
| x, 1 -> 0
| x, y -> 1
```

It is also commonly accepted to omit parentheses if the tuple is the return value of a function:

```fsharp
// ✔️ OK
let update model msg =
    match msg with
    | 1 -> model + 1, []
    | _ -> model, [ msg ]
```

In summary, prefer parenthesized tuple instantiations, but when using tuples for pattern matching or a return value, it is considered fine to avoid parentheses.

### Formatting application expressions

When formatting a function or method application, arguments are provided on the same line when line-width allows:

```fsharp
// ✔️ OK
someFunction1 x.IngredientName x.Quantity
```

Parentheses should be omitted unless arguments require them:

```fsharp
// ✔️ OK
someFunction1 x.IngredientName

// ❌ Not preferred - parentheses should be omitted unless required
someFunction1(x.IngredientName)
```

In default formatting conventions, a space is added when applying lower-case functions to tupled or parenthesized arguments:

```fsharp
// ✔️ OK
someFunction2 ()

// ✔️ OK
someFunction3 (x.Quantity1 + x.Quantity2)

// ❌ Not OK, formatting tools will add the extra space by default
someFunction2()

// ❌ Not OK, formatting tools will add the extra space by default
someFunction3(x.IngredientName, x.Quantity)
```

In default formatting conventions, no space is added when applying capitalized methods to tupled arguments. This is because these are often used with fluent programming:

```fsharp
// ✔️ OK - Methods accepting parenthesize arguments are applied without a space
SomeClass.Invoke()

// ✔️ OK - Methods accepting tuples are applied without a space
String.Format(x.IngredientName, x.Quantity)

// ❌ Not OK, formatting tools will remove the extra space by default
SomeClass.Invoke ()

// ❌ Not OK, formatting tools will remove the extra space by default
String.Format (x.IngredientName, x.Quantity)
```

You may need to pass arguments to a function on a new line, as a matter of readability or because the list of arguments or the argument names are too long. In that case, indent one level:

```fsharp
// ✔️ OK
someFunction2
    x.IngredientName x.Quantity

// ✔️ OK
someFunction3
    x.IngredientName1 x.Quantity2
    x.IngredientName2 x.Quantity2

// ✔️ OK
someFunction4
    x.IngredientName1
    x.Quantity2
    x.IngredientName2
    x.Quantity2

// ✔️ OK
someFunction5
    (convertVolumeToLiter x)
    (convertVolumeUSPint x)
    (convertVolumeImperialPint x)
```

When the function takes a single multi-line tupled argument, place each argument on a new line:

```fsharp
// ✔️ OK
someTupledFunction (
    478815516,
    "A very long string making all of this multi-line",
    1515,
    false
)

// OK, but formatting tools will reformat to the above
someTupledFunction
    (478815516,
     "A very long string making all of this multi-line",
     1515,
     false)
```

If argument expressions are short, separate arguments with spaces and keep it in one line.

```fsharp
// ✔️ OK
let person = new Person(a1, a2)

// ✔️ OK
let myRegexMatch = Regex.Match(input, regex)

// ✔️ OK
let untypedRes = checker.ParseFile(file, source, opts)
```

If argument expressions are long, use newlines and indent one level, rather than indenting to the left-parenthesis.

```fsharp
// ✔️ OK
let person =
    new Person(
        argument1,
        argument2
    )

// ✔️ OK
let myRegexMatch =
    Regex.Match(
        "my longer input string with some interesting content in it",
        "myRegexPattern"
    )

// ✔️ OK
let untypedRes =
    checker.ParseFile(
        fileName,
        sourceText,
        parsingOptionsWithDefines
    )

// ❌ Not OK, formatting tools will reformat to the above
let person =
    new Person(argument1,
               argument2)

// ❌ Not OK, formatting tools will reformat to the above
let untypedRes =
    checker.ParseFile(fileName,
                      sourceText,
                      parsingOptionsWithDefines)
```

The same rules apply even if there is only a single multi-line argument, including multi-line strings:

```fsharp
// ✔️ OK
let poemBuilder = StringBuilder()
poemBuilder.AppendLine(
    """
The last train is nearly due
The Underground is closing soon
And in the dark, deserted station
Restless in anticipation
A man waits in the shadows
    """
)

Option.traverse(
    create
    >> Result.setError [ invalidHeader "Content-Checksum" ]
)
```

### Formatting pipeline expressions

When using multiple lines, pipeline `|>` operators should go underneath the expressions they operate on.

```fsharp
// ✔️ OK
let methods2 =
    System.AppDomain.CurrentDomain.GetAssemblies()
    |> List.ofArray
    |> List.map (fun assm -> assm.GetTypes())
    |> Array.concat
    |> List.ofArray
    |> List.map (fun t -> t.GetMethods())
    |> Array.concat

// ❌ Not OK, add a line break after "=" and put multi-line pipelines on multiple lines.
let methods2 = System.AppDomain.CurrentDomain.GetAssemblies()
            |> List.ofArray
            |> List.map (fun assm -> assm.GetTypes())
            |> Array.concat
            |> List.ofArray
            |> List.map (fun t -> t.GetMethods())
            |> Array.concat

// ❌ Not OK either
let methods2 = System.AppDomain.CurrentDomain.GetAssemblies()
               |> List.ofArray
               |> List.map (fun assm -> assm.GetTypes())
               |> Array.concat
               |> List.ofArray
               |> List.map (fun t -> t.GetMethods())
               |> Array.concat
```

### Formatting lambda expressions

When a lambda expression is used as an argument in a multi-line expression, and is followed by other arguments,
place the body of a lambda expression on a new line, indented by one level:

```fsharp
// ✔️ OK
let printListWithOffset a list1 =
    List.iter
        (fun elem ->
             printfn $"A very long line to format the value: %d{a + elem}")
        list1
```

If the lambda argument is the last argument in a function application, place all arguments until the arrow on the same line.

```fsharp
// ✔️ OK
Target.create "Build" (fun ctx ->
    // code
    // here
    ())

// ✔️ OK
let printListWithOffsetPiped a list1 =
    list1
    |> List.map (fun x -> x + 1)
    |> List.iter (fun elem ->
        printfn $"A very long line to format the value: %d{a + elem}")
```

Treat match lambda's in a similar fashion.

```fsharp
// ✔️ OK
functionName arg1 arg2 arg3 (function
    | Choice1of2 x -> 1
    | Choice2of2 y -> 2)
```

When there are many leading or multi-line arguments before the lambda indent all arguments with one level.

```fsharp
// ✔️ OK
functionName 
    arg1 
    arg2 
    arg3 
    (fun arg4 ->
        bodyExpr)

// ✔️ OK
functionName 
    arg1 
    arg2 
    arg3 
    (function
     | Choice1of2 x -> 1
     | Choice2of2 y -> 2)
```

If the body of a lambda expression is multiple lines long, you should consider refactoring it into a locally-scoped function.

When pipelines include lambda expressions, each lambda expression is typically the last argument at each stage of the pipeline:

```fsharp
// ✔️ OK, with 4 spaces indentation
let printListWithOffsetPiped list1 =
    list1
    |> List.map (fun elem -> elem + 1)
    |> List.iter (fun elem ->
        // one indent starting from the pipe
        printfn $"A very long line to format the value: %d{elem}")

// ✔️ OK, with 2 spaces indentation
let printListWithOffsetPiped list1 =
  list1
  |> List.map (fun elem -> elem + 1)
  |> List.iter (fun elem ->
    // one indent starting from the pipe
    printfn $"A very long line to format the value: %d{elem}")
```

### Formatting arithmetic and binary expressions

Always use white space around binary arithmetic expressions:

```fsharp
// ✔️ OK
let subtractThenAdd x = x - 1 + 3
```

Failing to surround a binary `-` operator, when combined with certain formatting choices, could lead to interpreting it as a unary `-`.
Unary `-` operators should always be immediately followed by the value they are negating:

```fsharp
// ✔️ OK
let negate x = -x

// ❌ Not OK
let negateBad x = - x
```

Adding a white-space character after the `-` operator can lead to confusion for others.

Separate binary operators by spaces. Infix expressions are OK to lineup on same column:

```fsharp
// ✔️ OK
let function1 () =
    acc +
    (someFunction
         x.IngredientName x.Quantity)

// ✔️ OK
let function1 arg1 arg2 arg3 arg4 =
    arg1 + arg2 +
    arg3 + arg4
```

The following operators are defined in the F# standard library and should be used instead of defining equivalents. Using these operators is recommended as it tends to make code more readable and idiomatic. The following list summarizes the recommended F# operators.

```fsharp
// ✔️ OK
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

### Formatting if expressions

Indentation of conditionals depends on the size and complexity of the expressions that make them up.
Write them on one line when:

- `cond`, `e1`, and `e2` are short
- `e1` and `e2` are not `if/then/else` expressions themselves.

```fsharp
// ✔️ OK
if cond then e1 else e2
```

If any of the expressions are multi-line or `if/then/else` expressions.

```fsharp
// ✔️ OK
if cond then
    e1
else
    e2
```

Multiple conditionals with `elif` and `else` are indented at the same scope as the `if` when they follow the rules of the one line `if/then/else` expressions.

```fsharp
// ✔️ OK
if cond1 then e1
elif cond2 then e2
elif cond3 then e3
else e4
```

If any of the conditions or expressions is multi-line, the entire `if/then/else` expression is multi-line:

```fsharp
// ✔️ OK
if cond1 then
    e1
elif cond2 then
    e2
elif cond3 then
    e3
else
    e4
```

If a condition is long, the `then` keyword is still placed at the end of the expression.

```fsharp
// ✔️ OK, but better to refactor, see below
if
    complexExpression a b && env.IsDevelopment()
    || someFunctionToCall
        aVeryLongParameterNameOne
        aVeryLongParameterNameTwo
        aVeryLongParameterNameThree then
        e1
    else
        e2
```

It is, however, better style to refactor long conditions to a let binding or separate function:

```fsharp
// ✔️ OK
let performAction =
    complexExpression a b && env.IsDevelopment()
    || someFunctionToCall
        aVeryLongParameterNameOne
        aVeryLongParameterNameTwo
        aVeryLongParameterNameThree

if performAction then
    e1
else
    e2
```

### Formatting union case expressions

Applying discriminated union cases follows the same rules as function and method applications.
That is, because the name is capitalized, code formatters will remove a space before a tuple:

```fsharp
// ✔️ OK
let opt = Some("A", 1)

// OK, but code formatters will remove the space
let opt = Some ("A", 1)
```

Like function applications, constructions that split across multiple lines should use indentation:

```fsharp
// ✔️ OK
let tree1 =
    BinaryNode(
        BinaryNode (BinaryValue 1, BinaryValue 2),
        BinaryNode (BinaryValue 3, BinaryValue 4)
    )
```

### Formatting list and array expressions

Write `x :: l` with spaces around the `::` operator (`::` is an infix operator, hence surrounded by spaces).

List and arrays declared on a single line should have a space after the opening bracket and before the closing bracket:

```fsharp
// ✔️ OK
let xs = [ 1; 2; 3 ]

// ✔️ OK
let ys = [| 1; 2; 3; |]
```

Always use at least one space between two distinct brace-like operators. For example, leave a space between a `[` and a `{`.

```fsharp
// ✔️ OK
[ { Ingredient = "Green beans"; Quantity = 250 }
  { Ingredient = "Pine nuts"; Quantity = 250 }
  { Ingredient = "Feta cheese"; Quantity = 250 }
  { Ingredient = "Olive oil"; Quantity = 10 }
  { Ingredient = "Lemon"; Quantity = 1 } ]

// ❌ Not OK
[{ Ingredient = "Green beans"; Quantity = 250 }
 { Ingredient = "Pine nuts"; Quantity = 250 }
 { Ingredient = "Feta cheese"; Quantity = 250 }
 { Ingredient = "Olive oil"; Quantity = 10 }
 { Ingredient = "Lemon"; Quantity = 1 }]
```

The same guideline applies for lists or arrays of tuples.

Lists and arrays that split across multiple lines follow a similar rule as records do:

```fsharp
// ✔️ OK
let pascalsTriangle =
    [| [| 1 |]
       [| 1; 1 |]
       [| 1; 2; 1 |]
       [| 1; 3; 3; 1 |]
       [| 1; 4; 6; 4; 1 |]
       [| 1; 5; 10; 10; 5; 1 |]
       [| 1; 6; 15; 20; 15; 6; 1 |]
       [| 1; 7; 21; 35; 35; 21; 7; 1 |]
       [| 1; 8; 28; 56; 70; 56; 28; 8; 1 |] |]
```

And as with records, declaring the opening and closing brackets on their own line will make moving code around and piping into functions easier.

When generating arrays and lists programmatically, prefer `->` over `do ... yield` when a value is always generated:

```fsharp
// ✔️ OK
let squares = [ for x in 1..10 -> x * x ]

// ❌ Not preferred, use "->" when a value is always generated
let squares' = [ for x in 1..10 do yield x * x ]
```

Older versions of the F# language required specifying `yield` in situations where data may be generated conditionally, or there may be consecutive expressions to be evaluated. Prefer omitting these `yield` keywords unless you must compile with an older F# language version:

```fsharp
// ✔️ OK
let daysOfWeek includeWeekend =
    [
        "Monday"
        "Tuesday"
        "Wednesday"
        "Thursday"
        "Friday"
        if includeWeekend then
            "Saturday"
            "Sunday"
    ]

// ❌ Not preferred - omit yield instead
let daysOfWeek' includeWeekend =
    [
        yield "Monday"
        yield "Tuesday"
        yield "Wednesday"
        yield "Thursday"
        yield "Friday"
        if includeWeekend then
            yield "Saturday"
            yield "Sunday"
    ]
```

In some cases, `do...yield` may aid in readability. These cases, though subjective, should be taken into consideration.

### Formatting record expressions

Short records can be written in one line:

```fsharp
// ✔️ OK
let point = { X = 1.0; Y = 0.0 }
```

Records that are longer should use new lines for labels:

```fsharp
// ✔️ OK
let rainbow =
    { Boss = "Jeffrey"
      Lackeys = ["Zippy"; "George"; "Bungle"] }
```

Placing the `{` and `}` on new lines with contents indented is possible, however code formatters may reformat this by default:

```fsharp
// ✔️ OK
let rainbow =
    { Boss1 = "Jeffrey"
      Boss2 = "Jeffrey"
      Boss3 = "Jeffrey"
      Lackeys = ["Zippy"; "George"; "Bungle"] }

// ❌ Not preferred, code formatters will reformat to the above by default
let rainbow =
    {
        Boss1 = "Jeffrey"
        Boss2 = "Jeffrey"
        Boss3 = "Jeffrey"
        Lackeys = ["Zippy"; "George"; "Bungle"]
    }
```

The same rules apply for list and array elements.

### Formatting copy-and-update record expressions

A copy-and-update record expression is still a record, so similar guidelines apply.

Short expressions can fit on one line:

```fsharp
// ✔️ OK
let point2 = { point with X = 1; Y = 2 }
```

Longer expressions should use new lines:

```fsharp
// ✔️ OK
let rainbow2 =
    { rainbow with
        Boss = "Jeffrey"
        Lackeys = [ "Zippy"; "George"; "Bungle" ] }
```

You may want to dedicate separate lines for the braces and indent one scope to the right with the expression, however
code formatters may . In some special cases, such as wrapping a value with an optional without parentheses, you may need to keep a brace on one line:

```fsharp
// ✔️ OK
let newState =
    { state with
          Foo = Some { F1 = 0; F2 = "" } }

// ❌ Not OK, code formatters will reformat to the above by default
let newState =
    {
        state with
            Foo =
                Some {
                    F1 = 0
                    F2 = ""
                }
    }
```

### Formatting pattern matching

Use a `|` for each clause of a match with no indentation. If the expression is short, you can consider using a single line if each subexpression is also simple.

```fsharp
// ✔️ OK
match l with
| { him = x; her = "Posh" } :: tail -> x
| _ :: tail -> findDavid tail
| [] -> failwith "Couldn't find David"

// ❌ Not OK, code formatters will reformat to the above by default
match l with
    | { him = x; her = "Posh" } :: tail -> x
    | _ :: tail -> findDavid tail
    | [] -> failwith "Couldn't find David"
```

If the expression on the right of the pattern matching arrow is too large, move it to the following line, indented one step from the `match`/`|`.

```fsharp
// ✔️ OK
match lam with
| Var v -> 1
| Abs(x, body) ->
    1 + sizeLambda body
| App(lam1, lam2) ->
    sizeLambda lam1 + sizeLambda lam2
```

Aligning the arrows of a pattern match should be avoided.

```fsharp
// ✔️ OK
match lam with
| Var v -> v.Length
| Abstraction _ -> 2

// ❌ Not OK, code formatters will reformat to the above by default
match lam with
| Var v         -> v.Length
| Abstraction _ -> 2
```

Pattern matching introduced by using the keyword `function` should indent one level from the start of the previous line:

```fsharp
// ✔️ OK
lambdaList
|> List.map (function
    | Abs(x, body) -> 1 + sizeLambda 0 body
    | App(lam1, lam2) -> sizeLambda (sizeLambda 0 lam1) lam2
    | Var v -> 1)
```

The use of `function` in functions defined by `let` or `let rec` should in general be avoided in
favour of a `match`.  If used, the pattern rules should align with the keyword `function`:

```fsharp
// ✔️ OK
let rec sizeLambda acc =
    function
    | Abs(x, body) -> sizeLambda (succ acc) body
    | App(lam1, lam2) -> sizeLambda (sizeLambda acc lam1) lam2
    | Var v -> succ acc
```

### Formatting try/with expressions

Pattern matching on the exception type should be indented at the same level as `with`.

```fsharp
// ✔️ OK
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

Add a `|` for each clause, except when there is only a single clause:

```fsharp
// ✔️ OK
try
    persistState currentState
with ex ->
    printfn "Something went wrong: %A" ex

// ✔️ OK
try
    persistState currentState
with :? System.ApplicationException as ex ->
    printfn "Something went wrong: %A" ex

// ❌ Not OK, see above for preferred formatting
try
    persistState currentState
with
| ex ->
    printfn "Something went wrong: %A" ex

// ❌ Not OK, see above for preferred formatting
try
    persistState currentState
with
| :? System.ApplicationException as ex ->
    printfn "Something went wrong: %A" ex
```

### Formatting named arguments

Named arguments should not have space surrounding the `=`:

```fsharp
// ✔️ OK
let makeStreamReader x = new System.IO.StreamReader(path=x)

// ❌ Not OK, no spaces necessary around '=' for named arguments
let makeStreamReader x = new System.IO.StreamReader(path = x)
```

### Formatting mutation expressions

Mutation expressions `location <- expr` are normally formatted on one line.
If multi-line formatting is required, place the right-hand-side expression on a new line.

```fsharp
// ✔️ OK
ctx.Response.Headers.[HeaderNames.ContentType] <-
    Constants.jsonApiMediaType |> StringValues

ctx.Response.Headers.[HeaderNames.ContentLength] <-
    bytes.Length |> string |> StringValues

// ❌ Not OK, code formatters will reformat to the above by default
ctx.Response.Headers.[HeaderNames.ContentType] <- Constants.jsonApiMediaType
                                                  |> StringValues
ctx.Response.Headers.[HeaderNames.ContentLength] <- bytes.Length
                                                    |> string
                                                    |> StringValues
```

### Formatting object expressions

Object expression members should be aligned with `member` being indented by one level.

```fsharp
// ✔️ OK
let comparer =
    { new IComparer<string> with
          member x.Compare(s1, s2) =
              let rev (s: String) = new String (Array.rev (s.ToCharArray()))
              let reversed = rev s1
              reversed.CompareTo (rev s2) }
```

## Formatting declarations

This section discusses formatting declarations of different kinds.

### Add blank lines between declarations

Separate top-level function and class definitions with a single blank line. For example:

```fsharp
// ✔️ OK
let thing1 = 1+1

let thing2 = 1+2

let thing3 = 1+3

type ThisThat = This | That

// ❌ Not OK
let thing1 = 1+1
let thing2 = 1+2
let thing3 = 1+3
type ThisThat = This | That
```

If a construct has XML doc comments, add a blank line before the comment.

```fsharp
// ✔️ OK

/// This is a function
let thisFunction() =
    1 + 1

/// This is another function, note the blank line before this line
let thisFunction() =
    1 + 1
```

### Formatting let and member declarations

When formatting `let` and `member` declarations, the right-hand side of a binding either goes on one line, or (if it's too long) goes on a new line indented one level.

For example, the following are compliant:

```fsharp
// ✔️ OK
let a =
    """
foobar, long string
"""

// ✔️ OK
type File =
    member this.SaveAsync(path: string) : Async<unit> =
        async {
            // IO operation
            return ()
        }

// ✔️ OK
let c =
    { Name = "Bilbo"
      Age = 111
      Region = "The Shire" }

// ✔️ OK
let d =
    while f do
        printfn "%A" x
```

The following are non-compliant:

```fsharp
// ❌ Not OK, code formatters will reformat to the above by default
let a = """
foobar, long string
"""

type File =
    member this.SaveAsync(path: string) : Async<unit> = async {
        // IO operation
        return ()
    }

let c = {
    Name = "Bilbo"
    Age = 111
    Region = "The Shire"
}

let d = while f do
    printfn "%A" x
```

Separate members with a single blank line and document and add a documentation comment:

```fsharp
// ✔️ OK

/// This is a thing
type ThisThing(value: int) =

    /// Gets the value
    member _.Value = value

    /// Returns twice the value
    member _.TwiceValue() = value*2
```

Extra blank lines may be used (sparingly) to separate groups of related functions. Blank lines may be omitted between a bunch of related one-liners (for example, a set of dummy implementations). Use blank lines in functions, sparingly, to indicate logical sections.

### Formatting function and member arguments

When defining a function, use white space around each argument.

```fsharp
// ✔️ OK
let myFun (a: decimal) (b: int) c = a + b + c

// ❌ Not OK, code formatters will reformat to the above by default
let myFunBad (a:decimal)(b:int)c = a + b + c
```

If you have a long function definition, place the parameters on new lines and indent them to match the indentation level of the subsequent parameter.

```fsharp
// ✔️ OK
module M =
    let longFunctionWithLotsOfParameters
        (aVeryLongParam: AVeryLongTypeThatYouNeedToUse)
        (aSecondVeryLongParam: AVeryLongTypeThatYouNeedToUse)
        (aThirdVeryLongParam: AVeryLongTypeThatYouNeedToUse)
        =
        // ... the body of the method follows

    let longFunctionWithLotsOfParametersAndReturnType
        (aVeryLongParam: AVeryLongTypeThatYouNeedToUse)
        (aSecondVeryLongParam: AVeryLongTypeThatYouNeedToUse)
        (aThirdVeryLongParam: AVeryLongTypeThatYouNeedToUse)
        : ReturnType =
        // ... the body of the method follows

    let longFunctionWithLongTupleParameter
        (
            aVeryLongParam: AVeryLongTypeThatYouNeedToUse,
            aSecondVeryLongParam: AVeryLongTypeThatYouNeedToUse,
            aThirdVeryLongParam: AVeryLongTypeThatYouNeedToUse
        ) =
        // ... the body of the method follows

    let longFunctionWithLongTupleParameterAndReturnType
        (
            aVeryLongParam: AVeryLongTypeThatYouNeedToUse,
            aSecondVeryLongParam: AVeryLongTypeThatYouNeedToUse,
            aThirdVeryLongParam: AVeryLongTypeThatYouNeedToUse
        ) : ReturnType =
        // ... the body of the method follows
```

This also applies to members, constructors, and parameters using tuples:

```fsharp
// ✔️ OK
type TypeWithLongMethod() =
    member _.LongMethodWithLotsOfParameters
        (
            aVeryLongParam: AVeryLongTypeThatYouNeedToUse,
            aSecondVeryLongParam: AVeryLongTypeThatYouNeedToUse,
            aThirdVeryLongParam: AVeryLongTypeThatYouNeedToUse
        ) =
        // ... the body of the method

// ✔️ OK
type TypeWithLongConstructor
    (
        aVeryLongCtorParam: AVeryLongTypeThatYouNeedToUse,
        aSecondVeryLongCtorParam: AVeryLongTypeThatYouNeedToUse,
        aThirdVeryLongCtorParam: AVeryLongTypeThatYouNeedToUse
    ) =
    // ... the body of the class follows
```

If the parameters are curried, place the `=` character along with any return type on a new line:

```fsharp
// ✔️ OK
type TypeWithLongCurriedMethods() =
    member _.LongMethodWithLotsOfCurriedParamsAndReturnType
        (aVeryLongParam: AVeryLongTypeThatYouNeedToUse)
        (aSecondVeryLongParam: AVeryLongTypeThatYouNeedToUse)
        (aThirdVeryLongParam: AVeryLongTypeThatYouNeedToUse)
        : ReturnType =
        // ... the body of the method

    member _.LongMethodWithLotsOfCurriedParams
        (aVeryLongParam: AVeryLongTypeThatYouNeedToUse)
        (aSecondVeryLongParam: AVeryLongTypeThatYouNeedToUse)
        (aThirdVeryLongParam: AVeryLongTypeThatYouNeedToUse)
        =
        // ... the body of the method
```

This is a way to avoid too long lines (in case return type might have long name) and have less line-damage when adding parameters.

### Formatting operator declarations

Optionally use white space to surround an operator definition:

```fsharp
// ✔️ OK
let ( !> ) x f = f x

// ✔️ OK
let (!>) x f = f x
```

For any custom operator that starts with `*` and that has more than one character, you need to add a white space to the beginning of the definition to avoid a compiler ambiguity. Because of this, we recommend that you simply surround the definitions of all operators with a single white-space character.

### Formatting record declarations

For record declarations, indent `{` in type definition by four spaces, start the field list on the same line and align any members with the `{` token:

```fsharp
// ✔️ OK
type PostalAddress =
    { Address: string
      City: string
      Zip: string }
    member x.ZipAndCity = $"{x.Zip} {x.City}"
```

Do not place the `{` at the end of the type declaration line, and do not use `with`/`end` for members, which are redundant.

```fsharp
// ❌ Not OK, code formatters will reformat to the above by default
type PostalAddress = {
    Address: string
    City: string
    Zip: string 
  }
  with
    member x.ZipAndCity = $"{x.Zip} {x.City}"
  end
```

When XML documentation is added for record fields, it becomes normal to indent and add whitespace:

```fsharp
// ✔️ OK
type PostalAddress =
    {
        /// The address
        Address: string

        /// The city
        City: string

        /// The zip code
        Zip: string
    }

    /// Format the zip code and the city
    member x.ZipAndCity = $"{x.Zip} {x.City}"
```

Placing the opening token on a new line and the closing token on a new line is preferable if you are declaring interface implementations or members on the record:

```fsharp
// ✔️ OK
// Declaring additional members on PostalAddress
type PostalAddress =
    {
        /// The address
        Address: string

        /// The city
        City: string

        /// The zip code
        Zip: string
    }

    member x.ZipAndCity = $"{x.Zip} {x.City}"

type MyRecord =
    {
        /// The record field
        SomeField: int
    }
    interface IMyInterface
```

### Formatting discriminated union declarations

For discriminated union declarations, indent `|` in type definition by four spaces:

```fsharp
// ✔️ OK
type Volume =
    | Liter of float
    | FluidOunce of float
    | ImperialPint of float

// ❌ Not OK
type Volume =
| Liter of float
| USPint of float
| ImperialPint of float
```

When there is a single short union, you can omit the leading `|`.

```fsharp
// ✔️ OK
type Address = Address of string
```

For a longer or multi-line union, keep the `|` and place each union field on a new line, with the separating `*` at the end of each line.

```fsharp
// ✔️ OK
[<NoEquality; NoComparison>]
type SynBinding =
    | SynBinding of
        accessibility: SynAccess option *
        kind: SynBindingKind *
        mustInline: bool *
        isMutable: bool *
        attributes: SynAttributes *
        xmlDoc: PreXmlDoc *
        valData: SynValData *
        headPat: SynPat *
        returnInfo: SynBindingReturnInfo option *
        expr: SynExpr *
        range: range *
        seqPoint: DebugPointAtBinding
```

When documentation comments are added, use an empty line before each `///` comment.

```fsharp
// ✔️ OK

/// The volume
type Volume =

    /// The volume in liters
    | Liter of float

    /// The volume in fluid ounces
    | FluidOunce of float

    /// The volume in imperial pints
    | ImperialPint of float
```

### Formatting literal declarations

[F# literals](../language-reference/literals.md) using the `Literal` attribute should place the attribute on its own line and use PascalCase naming:

```fsharp
// ✔️ OK

[<Literal>]
let Path = __SOURCE_DIRECTORY__ + "/" + __SOURCE_FILE__

[<Literal>]
let MyUrl = "www.mywebsitethatiamworkingwith.com"
```

Avoid placing the attribute on the same line as the value.

### Formatting module declarations

Code in a local module must be indented relative to the module, but code in a top-level module should not be indented. Namespace elements do not have to be indented.

```fsharp
// ✔️ OK - A is a top-level module.
module A

let function1 a b = a - b * b
```

```fsharp
// ✔️ OK - A1 and A2 are local modules.
module A1 =
    let function1 a b = a * a + b * b

module A2 =
    let function2 a b = a * a - b * b
```

### Formatting do declarations

In type declarations, module declarations and computation expressions, the use of `do` or `do!` is sometimes required for side-effecting operations.
When these span multiple lines, use indentation and a new line to keep the indentation consistent with `let`/`let!`. Here is an example using `do` in a class:

```fsharp
// ✔️ OK
type Foo () =
    let foo =
        fooBarBaz
        |> loremIpsumDolorSitAmet
        |> theQuickBrownFoxJumpedOverTheLazyDog

    do
        fooBarBaz
        |> loremIpsumDolorSitAmet
        |> theQuickBrownFoxJumpedOverTheLazyDog

// ❌ Not OK - notice the "do" expression is indented one space less than the `let` expression
type Foo () =
    let foo =
        fooBarBaz
        |> loremIpsumDolorSitAmet
        |> theQuickBrownFoxJumpedOverTheLazyDog
    do fooBarBaz
       |> loremIpsumDolorSitAmet
       |> theQuickBrownFoxJumpedOverTheLazyDog
```

Here is an example with `do!` using 2 spaces of indentation (because with `do!` there is coincidentally no difference between the approaches when using 4 spaces of indentation):

```fsharp
// ✔️ OK
async {
  let! foo =
    fooBarBaz
    |> loremIpsumDolorSitAmet
    |> theQuickBrownFoxJumpedOverTheLazyDog
    
  do!
    fooBarBaz
    |> loremIpsumDolorSitAmet
    |> theQuickBrownFoxJumpedOverTheLazyDog
}

// ❌ Not OK - notice the "do!" expression is indented two spaces more than the `let!` expression
async {
  let! foo =
    fooBarBaz
    |> loremIpsumDolorSitAmet
    |> theQuickBrownFoxJumpedOverTheLazyDog
  do! fooBarBaz
      |> loremIpsumDolorSitAmet
      |> theQuickBrownFoxJumpedOverTheLazyDog
}
```

### Formatting computation expression operations

When creating custom operations for [computation expressions](../language-reference/computation-expressions.md), it is recommended to use camelCase naming:

```fsharp
// ✔️ OK
type MathBuilder () =
    member _.Yield _ = 0

    [<CustomOperation("addOne")>]
    member _.AddOne (state: int) =
        state + 1

    [<CustomOperation("subtractOne")>]
    member _.SubtractOne (state: int) =
        state - 1

    [<CustomOperation("divideBy")>]
    member _.DivideBy (state: int, divisor: int) =
        state / divisor

    [<CustomOperation("multiplyBy")>]
    member _.MultiplyBy (state: int, factor: int) =
        state * factor

let math = MathBuilder()

let myNumber =
    math {
        addOne
        addOne
        addOne
        subtractOne
        divideBy 2
        multiplyBy 10
    }
```

The domain that's being modeled should ultimately drive the naming convention.
If it is idiomatic to use a different convention, that convention should be used instead.

## Formatting types and type annotations

This section discusses formatting types and type annotations. This includes formatting signature files with the `.fsi` extension.

### For types, prefer prefix syntax for generics (`Foo<T>`), with some specific exceptions

F# allows both postfix style of writing generic types (for example, `int list`) as well as the prefix style (for example, `list<int>`).
Postfix style can only be used with a single type argument.
Always prefer the .NET style, except for five specific types:

1. For F# Lists, use the postfix form: `int list` rather than `list<int>`.
2. For F# Options, use the postfix form: `int option` rather than `option<int>`.
3. For F# Value Options, use the postfix form: `int voption` rather than `voption<int>`.
4. For F# arrays, use the syntactic name `int[]` rather than `int array` or `array<int>`.
5. For Reference Cells, use `int ref` rather than `ref<int>` or `Ref<int>`.

For all other types, use the prefix form.

### Formatting function types

When defining the signature of a function, use white space around the `->` symbol:

```fsharp
// ✔️ OK
type MyFun = int -> int -> string

// ❌ Not OK
type MyFunBad = int->int->string
```

### Formatting value and argument type annotations

When defining values or arguments with type annotations, use white space after the `:` symbol, but not before:

```fsharp
// ✔️ OK
let complexFunction (a: int) (b: int) c = a + b + c

let simpleValue: int = 0 // Type annotation for let-bound value

type C() =
    member _.Property: int = 1

// ❌ Not OK
let complexFunctionPoorlyAnnotated (a :int) (b :int) (c:int) = a + b + c
let simpleValuePoorlyAnnotated1:int = 1
let simpleValuePoorlyAnnotated2 :int = 2
```

### Formatting return type annotations

In function or member return type annotations, use white space before and after the `:` symbol:

```fsharp
// ✔️ OK
let myFun (a: decimal) b c : decimal = a + b + c

type C() =
    member _.SomeMethod(x: int) : int = 1

// ❌ Not OK
let myFunBad (a: decimal) b c:decimal = a + b + c

let anotherFunBad (arg: int): unit = ()

type C() =
    member _.SomeMethodBad(x: int): int = 1
```

### Formatting types in signatures

When writing full function types in signatures, it is sometimes necessary to split the arguments
over multiple lines. For a tupled function the arguments are separated by `*`,
placed at the end of each line. The return type is indented. For example, consider a function with the
following implementation:

```fsharp
let SampleTupledFunction(arg1, arg2, arg3, arg4) = ...
```

In the corresponding signature file (`.fsi` extension) the function can be formatted as follows when
multi-line formatting is required:

```fsharp
// ✔️ OK
val SampleTupledFunction:
    arg1: string *
    arg2: string *
    arg3: int *
    arg4: int
        -> int list
```

Likewise consider a curried function:

```fsharp
let SampleCurriedFunction arg1 arg2 arg3 arg4 = ...
```

In the corresponding signature file the `->` are placed at the start of each line:

```fsharp
// ✔️ OK
val SampleCurriedFunction:
    arg1: string
    -> arg2: string
    -> arg3: int
    -> arg4: int
        -> int list
```

Likewise consider a function that takes a mix of curried and tupled arguments:

```fsharp
// Typical call syntax:
let SampleMixedFunction
        (arg1, arg2)
        (arg3, arg4, arg5)
        (arg6, arg7)
        (arg8, arg9, arg10) = ..
```

In the corresponding signature file the `->` are placed at the end of each argument except the last:

```fsharp
// ✔️ OK
val SampleMixedFunction:
    arg1: string *
    arg2: string
    -> arg3: string *
       arg4: string *
       arg5: TType
    -> arg6: TType *
       arg7: TType *
    -> arg8: TType *
       arg9: TType *
       arg10: TType
        -> TType list
```

### Formatting explicit generic type arguments and constraints

The guidelines below apply to function definitions, member definitions, and type definitions.

Keep generic type arguments and constraints on a single line if it’s not too long:

```fsharp
// ✔️ OK
let f<'T1, 'T2 when 'T1: equality and 'T2: comparison> param =
    // function body
```

If both generic type arguments/constraints and function parameters don’t fit, but the type parameters/constraints alone do, place the parameters on new lines:

```fsharp
// ✔️ OK
let f<'T1, 'T2 when 'T1 : equality and 'T2 : comparison>
    param
    =
    // function body
```

If the type parameters or constraints are too long, break and align them as shown below. Keep the list of type parameters on the same line as the function, regardless of its length. For constraints, place `when` on the first line, and keep each constraint on a single line regardless of its length. Place `>` at the end of the last line. Indent the constraints by one level.

```fsharp
// ✔️ OK
let inline f< ^T1, ^T2
    when ^T1 : (static member Foo1: unit -> ^T2)
    and ^T2 : (member Foo2: unit -> int)
    and ^T2 : (member Foo3: string -> ^T1 option)>
    arg1
    arg2
    =
    // function body
```

If the type parameters/constraints are broken up, but there are no normal function parameters, place the `=` on a new line regardless:

```f#
// ✔️ OK
let inline f<^T1, ^T2
    when ^T1 : (static member Foo1: unit -> ^T2)
    and ^T2 : (member Foo2: unit -> int)
    and ^T2 : (member Foo3: string -> ^T1 option)>
    =
    // function body
```

## Formatting attributes

[Attributes](../language-reference/attributes.md) are placed above a construct:

```fsharp
// ✔️ OK
[<SomeAttribute>]
type MyClass() = ...

// ✔️ OK
[<RequireQualifiedAccess>]
module M =
    let f x = x

// ✔️ OK
[<Struct>]
type MyRecord =
    { Label1: int
      Label2: string }
```

They should go after any XML documentation:

```fsharp
// ✔️ OK

/// Module with some things in it.
[<RequireQualifiedAccess>]
module M =
    let f x = x
```

### Formatting attributes on parameters

Attributes can also be placed on parameters. In this case, place then on the same line as the parameter and before the name:

```fsharp
// ✔️ OK - defines a class that takes an optional value as input defaulting to false.
type C() =
    member _.M([<Optional; DefaultParameterValue(false)>] doSomething: bool)
```

### Formatting multiple attributes

When multiple attributes are applied to a construct that is not a parameter, they should be placed such that there is one attribute per line:

```fsharp
// ✔️ OK

[<Struct>]
[<IsByRefLike>]
type MyRecord =
    { Label1: int
      Label2: string }
```

When applied to a parameter, they must be on the same line and separated by a `;` separator.
