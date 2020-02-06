---
title: Quotations.Expr Class (F#)
description: Quotations.Expr Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: bd417cb3-aea1-4855-a01c-2888aa233b55
---

# Quotations.Expr Class (F#)

Quoted expressions annotated with `System.Type` values.

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type Expr =
class
static member AddressOf : Expr -> Expr
static member AddressSet : Expr * Expr -> Expr
static member Application : Expr * Expr -> Expr
static member Applications : Expr * Expr list list -> Expr
static member Call : Expr * MethodInfo * Expr list -> Expr
static member Call : MethodInfo * Expr list -> Expr
static member Cast : Expr -> Expr<'T>
static member Coerce : Expr * Type -> Expr
static member DefaultValue : Type -> Expr
static member Deserialize : Type * Type list * Expr list * byte [] -> Expr
static member FieldGet : Expr * FieldInfo -> Expr
static member FieldGet : FieldInfo -> Expr
static member FieldSet : Expr * FieldInfo * Expr -> Expr
static member FieldSet : FieldInfo * Expr -> Expr
static member ForIntegerRangeLoop : Var * Expr * Expr * Expr -> Expr
member this.GetFreeVars : unit -> seq<Var>
static member GlobalVar : string -> Expr<'T>
static member IfThenElse : Expr * Expr * Expr -> Expr
static member Lambda : Var * Expr -> Expr
static member Let : Var * Expr * Expr -> Expr
static member LetRecursive : Var * Expr list * Expr -> Expr
static member NewArray : Type * Expr list -> Expr
static member NewDelegate : Type * Var list * Expr -> Expr
static member NewObject : ConstructorInfo * Expr list -> Expr
static member NewRecord : Type * Expr list -> Expr
static member NewTuple : Expr list -> Expr
static member NewUnionCase : UnionCaseInfo * Expr list -> Expr
static member PropertyGet : PropertyInfo * Expr list option -> Expr
static member PropertyGet : Expr * PropertyInfo * Expr list option -> Expr
static member PropertySet : PropertyInfo * Expr * Expr list option -> Expr
static member PropertySet : Expr * PropertyInfo * Expr * Expr list option -> Expr
static member Quote : Expr -> Expr
static member RegisterReflectedDefinitions : Assembly * string * byte [] -> unit
static member Sequential : Expr * Expr -> Expr
member this.Substitute : (Var -> Expr option) -> Expr
member this.ToString : bool -> string
static member TryFinally : Expr * Expr -> Expr
static member TryGetReflectedDefinition : MethodBase -> Expr option
static member TryWith : Expr * Var * Expr * Var * Expr -> Expr
static member TupleGet : Expr * int -> Expr
static member TypeTest : Expr * Type -> Expr
static member UnionCaseTest : Expr * UnionCaseInfo -> Expr
static member Value : 'T -> Expr
static member Value : obj * Type -> Expr
static member Var : Var -> Expr
static member VarSet : Var * Expr -> Expr
static member WhileLoop : Expr * Expr -> Expr
member this.CustomAttributes :  Expr list
member this.Type :  Type
end
```

## Remarks
This type is named `FSharpExpr` in compiled assemblies. If you are accessing the type from a language other than F#, or through reflection, use this name.


## Instance Members

|Member|Description|
|------|-----------|
|[CustomAttributes](https://msdn.microsoft.com/library/eb89943f-5f5b-474e-b125-030ca412edb3)|Returns the custom attributes of an expression.|
|[GetFreeVars](https://msdn.microsoft.com/library/289ad069-c023-44b0-b583-dfa4c6c5477b)|Gets the free expression variables of an expression as a list.|
|[Substitute](https://msdn.microsoft.com/library/dc22a870-74f2-4dc2-bc77-260ccd7823d3)|Substitutes through the given expression using the given functions to map variables to new values. The functions must give consistent results at each application. Variable renaming may occur on the target expression if variable capture occurs.|
|[ToString](https://msdn.microsoft.com/library/d8e236c6-adee-4620-9361-fd217d09052d)|Formats the expression as a string.|
|[Type](https://msdn.microsoft.com/library/38bd15ac-eaa4-494f-9d5b-c67467fa0566)|Returns type of an expression.|

## Static Members


|Member|Description|
|------|-----------|
|[AddressOf](https://msdn.microsoft.com/library/f497c445-a54a-49b0-ae38-f55677a87920)|Creates an expression that represents getting the address of a value.|
|[AddressSet](https://msdn.microsoft.com/library/ab5eb237-cb0a-43fa-b1ab-4bb604be362c)|Creates an expression that represents setting the value held at a particular address.|
|[Application](https://msdn.microsoft.com/library/82dfc5dd-0d8f-4f1d-892f-391e8ebfda45)|Creates an expression that represents the application of a first class function value to a single argument.|
|[Applications](https://msdn.microsoft.com/library/7abf4dd2-e607-4341-8a63-d59b5adc9228)|Creates an expression that represents the application of a first class function value to multiple arguments.|
|[Call](https://msdn.microsoft.com/library/ca1f1f21-180d-480d-a070-e76d04bd0910)|Creates an expression that represents a call to an instance method associated with an object.|
|[Cast](https://msdn.microsoft.com/library/ec6eeb85-8790-45d1-9846-0433cbd360bd)|Returns a new typed expression given an underlying runtime-typed expression. A type annotation is usually required to use this function, and using an incorrect type annotation may result in a later runtime exception.|
|[Coerce](https://msdn.microsoft.com/library/8ae78055-7c73-4bec-b8db-62d5cbf361a5)|Creates an expression that represents the coercion of an expression to a type|
|[DefaultValue](https://msdn.microsoft.com/library/89c68c3c-8b2c-418e-a244-5f80d3543587)|Creates an expression that represents the invocation of a default object constructor|
|[Deserialize](https://msdn.microsoft.com/library/0d61cb91-5326-461c-8ffe-51966a66ac2e)|This function is called automatically when quotation syntax (`<@ @>`) and related typed-expression quotations are used. The bytes are a pickled binary representation of an unlinked form of the quoted expression, and the `System.Type` argument is any type in the assembly where the quoted expression occurs, that is, it helps scope the interpretation of the cross-assembly references in the bytes.|
|[FieldGet](https://msdn.microsoft.com/library/9c077cee-3c0e-44c4-bb1c-a6089b53b79b)|Creates an expression that represents the access of a field of an object.|
|[FieldSet](https://msdn.microsoft.com/library/15457912-7817-4363-afa3-67263d6ad072)|Creates an expression that represents writing to a field of an object.|
|[ForIntegerRangeLoop](https://msdn.microsoft.com/library/0c1c70b9-508d-428f-9187-7273961db724)|Creates a `for` expression that represent loops over integer ranges.|
|[GlobalVar](https://msdn.microsoft.com/library/eefa478a-0d37-4119-a221-2bfa0e1e7b3c)|Fetches or creates a new variable with the given name and type from a global pool of shared variables indexed by name and type. The type is given by the explicit or inferred type parameter.|
|[IfThenElse](https://msdn.microsoft.com/library/cdb7253d-a451-435c-8acf-21ff9ad4ccb6)|Creates an `if...then...else` expression.|
|[Lambda](https://msdn.microsoft.com/library/783760ed-8dd5-407e-a752-19451d81bb97)|Creates an expression that represents the construction of an F# function value.|
|[Let](https://msdn.microsoft.com/library/0da309db-1146-49ae-ac11-9285a1473d0a)|Creates expressions associated with let constructs.|
|[LetRecursive](https://msdn.microsoft.com/library/0a73193a-3a26-4656-82af-badb5c714eb2)|Creates recursive expressions associated with `let rec` constructs.|
|[NewArray](https://msdn.microsoft.com/library/0e9ebff1-70e6-4f42-9710-dc94412d594d)|Creates an expression that represents the creation of an array value initialized with the given elements.|
|[NewDelegate](https://msdn.microsoft.com/library/fee21336-730d-4310-ac81-27013e1c5241)|Creates an expression that represents the creation of a delegate value for the given type.|
|[NewObject](https://msdn.microsoft.com/library/c900f8bc-aaaa-41dd-9715-6755c3ae776b)|Creates an expression that represents the invocation of an object constructor.|
|[NewRecord](https://msdn.microsoft.com/library/c5721cc2-2f6a-462b-97b9-93f6b135c6b3)|Creates record-construction expressions.|
|[NewTuple](https://msdn.microsoft.com/library/332c33ee-fef4-428c-9afa-934bee58cf8b)|Creates an expression that represents the creation of an F# tuple value.|
|[NewUnionCase](https://msdn.microsoft.com/library/481c3359-71cd-404d-a2be-53208ffb9d9f)|Creates an expression that represents the creation of a union case value.|
|[PropertyGet](https://msdn.microsoft.com/library/403fa57a-f195-464d-aa2e-20b201c5948a)|Creates an expression that represents reading a static property.|
|[PropertySet](https://msdn.microsoft.com/library/520f728e-6ac1-4d4c-b2f4-726c234b42d7)|Creates an expression that represents writing to a static property.|
|[Quote](https://msdn.microsoft.com/library/9334aa81-6905-40c0-9308-fc847450c33c)|Creates an expression that represents a nested quotation literal.|
|[RegisterReflectedDefinitions](https://msdn.microsoft.com/library/d0f779f3-3fd0-48cb-bd12-26fc807f1a0b)|Permits interactive environments such as F# Interactive to explicitly register new pickled resources that represent persisted top level definitions. The string indicates a unique name for the resources being added. The format for the bytes is the encoding generated by the F# compiler.|
|[Sequential](https://msdn.microsoft.com/library/2ea21025-7f96-4170-a53a-afc5dc499efe)|Creates an expression that represents the sequential execution of one expression followed by another.|
|[TryFinally](https://msdn.microsoft.com/library/1acf577d-6143-4211-9ebb-20e48aafba29)|Creates an expression that represents a `try...finally` construct.|
|[TryGetReflectedDefinition](https://msdn.microsoft.com/library/62865941-b319-433a-81ff-d841bb40744b)|Try and find a stored reflection definition for the given method. Stored reflection definitions are added to an F# assembly through the use of the `ReflectedDefinition` attribute.|
|[TryWith](https://msdn.microsoft.com/library/bb6a4a9f-0a49-4fe5-b4fd-b2167bda74e1)|Creates an expression that represents a `try...with` construct for exception filtering and catching.|
|[TupleGet](https://msdn.microsoft.com/library/ee0704eb-5af3-446f-88f9-f82fafe01d6b)|Creates an expression that represents getting a field of a tuple.|
|[TypeTest](https://msdn.microsoft.com/library/200bf817-e6e4-4fb0-9502-1c49a4163ef2)|Creates an expression that represents a type test.|
|[UnionCaseTest](https://msdn.microsoft.com/library/a9d0803c-863c-493b-81ac-964a6b4f230a)|Creates an expression that represents a test of a value is of a particular union case.|
|[Value](https://msdn.microsoft.com/library/811aad5e-40c2-4df0-8bd4-9beb1c998a06)|Creates an expression that represents a constant value.|
|[Value](https://msdn.microsoft.com/library/ffae1099-0e49-4e54-9110-cb625954e667)|Creates an expression that represents a constant value of a particular type.|
|[Var](https://msdn.microsoft.com/library/392d26d0-787e-47f2-91c6-e8d6ecbfb4c1)|Creates an expression that represents a variable.|
|[VarSet](https://msdn.microsoft.com/library/a14e1535-7ad2-41fb-8029-ed1b513091ba)|Creates an expression that represents setting a mutable variable.|
|[WhileLoop](https://msdn.microsoft.com/library/b5100cab-a292-4112-a214-303724fd2514)|Creates an expression that represents a while loop.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
