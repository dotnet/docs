---
title: Microsoft.FSharp.Core Namespace (F#)
description: Microsoft.FSharp.Core Namespace (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9a3ecb6b-4590-4d0e-9c02-b6cce1d5a8c9
---

# Microsoft.FSharp.Core Namespace (F#)

This namespace contains functionality that supports core F# functionality, including language primitives, operators, attributes, primitive types, strings, and formatted I/O.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
namespace Microsoft.FSharp.Core
```

## Modules

|Module|Description|
|------|-----------|
|module [ExtraTopLevelOperators](https://msdn.microsoft.com/library/03c4f2ba-52e1-48cd-9f62-6d224a32b135)|Additional F# operators and types that are available without opening a module or namespace.|
|module [LanguagePrimitives](https://msdn.microsoft.com/library/69d08ac5-5d51-4c20-bf1e-850fd312ece3)|Language primitives associated with the F# language|
|module [NumericLiterals](https://msdn.microsoft.com/library/b544f524-cd80-4fda-8f18-c8b50442f8e1)|Provides a default implementations of F# numeric literal syntax for literals fo the form 'dddI'.|
|module [Operators](https://msdn.microsoft.com/library/a5a3adf6-3957-4293-8e51-069381017af0)|Basic F# Operators. This module is automatically opened in all F# code.|
|module [OptimizedClosures](https://msdn.microsoft.com/library/8f1e5ba0-9ae6-45d5-949a-150fda7eeedb)|An implementation module used to hold some private implementations of function value invocation.|
|module [Option](https://msdn.microsoft.com/library/e615e4d3-bbbb-49ba-addc-6061ea2e2f4c)|Basic operations on options.|
|module [Printf](https://msdn.microsoft.com/library/ea074733-6b5d-498c-ac88-7e4e0f8ded25)|Extensible printf-style formatting for numbers and other datatypes|
|module [String](https://msdn.microsoft.com/library/a5fda9cd-d71f-4271-a6a4-ab4caa0be550)|Functional programming operators for string processing. Further string operations are available via the member functions on strings and other functionality in **System.String** and **System.Text.RegularExpressions.Regex** types.|

## Type Definitions

|Type|Description|
|----|-----------|
|type [[,,,]&lt;'T&gt;](https://msdn.microsoft.com/library/e957316d-b2e0-4f04-ac4c-426d4f38a968)|Four dimensional arrays, typically zero-based. Non-zero-based arrays can be created using methods on the System.Array type.|
|type [[,,]&lt;'T&gt;](https://msdn.microsoft.com/library/b4e5b35b-dc83-4b50-94aa-85fcf3ccb2b0)|Three dimensional arrays, typically zero-based. Non-zero-based arrays can be created using methods on the System.Array type.|
|type [[,]&lt;'T&gt;](https://msdn.microsoft.com/library/077252f3-e6ce-441c-9d5b-a6030eaef7cd)|Two dimensional arrays, typically zero-based.|
|type [[]&lt;'T&gt;](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)|Single dimensional, zero-based arrays, written **int[]**, **string[]** and so on.|
|type [AbstractClassAttribute](https://msdn.microsoft.com/library/dfdc0c97-e72d-4cda-8f3b-7591820e7c44)|Adding this attribute to class definition makes it abstract, which means it need not implement all its methods. Instances of abstract classes may not be constructed directly.|
|type [AllowNullLiteralAttribute](https://msdn.microsoft.com/library/4f315196-f444-4cca-ba07-1176ff71eb0f)|Adding this attribute to a type lets the 'null' literal be used for the type within F# code. This attribute may only be added to F#-defined class or interface types.|
|type [AutoOpenAttribute](https://msdn.microsoft.com/library/9e0b39c1-26a2-4bd9-b6a0-9ce7b40dc158)|This attribute is used for two purposes. When applied to an assembly, it must be given a string argument, and this argument must indicate a valid module or namespace in that assembly. Source code files compiled with a reference to this assembly are processed in an environment where the given path is automatically oepned.|
|type [AutoSerializableAttribute](https://msdn.microsoft.com/library/e0102c84-9313-4eb4-a992-f39aa01db4bc)|Adding this attribute to a type with value 'false' disables the behaviour where F# makes the type Serializable by default.|
|type [byref&lt;'T&gt;](https://msdn.microsoft.com/library/ab37321f-5515-4c29-8296-48b57eae15f7)|Represents a managed pointer in F# code.|
|type [Choice&lt;'T1,'T2,'T3,'T4,'T5,'T6,'T7&gt;](https://msdn.microsoft.com/library/e1aae03b-685c-479f-900c-c4cc6659f286)|Helper types for active patterns with 7 choices.|
|type [Choice&lt;'T1,'T2,'T3,'T4,'T5,'T6&gt;](https://msdn.microsoft.com/library/5964378a-8181-4cdc-bc91-b301ea442e57)|Helper types for active patterns with 6 choices.|
|type [Choice&lt;'T1,'T2,'T3,'T4,'T5&gt;](https://msdn.microsoft.com/library/7ffee923-d523-478b-96b5-3b960f604c9f)|Helper types for active patterns with 5 choices.|
|type [Choice&lt;'T1,'T2,'T3,'T4&gt;](https://msdn.microsoft.com/library/26cf61c5-4ed8-44d2-a6a4-7b2618b8c9d5)|Helper types for active patterns with 4 choices.|
|type [Choice&lt;'T1,'T2,'T3&gt;](https://msdn.microsoft.com/library/481a9fd9-e117-41b6-b53e-362ecd820cbc)|Helper types for active patterns with 3 choices.|
|type [Choice&lt;'T1,'T2&gt;](https://msdn.microsoft.com/library/2ab2513e-e307-4360-96cd-8b682a8d64f0)|Helper types for active patterns with 2 choices.|
|type [ClassAttribute](https://msdn.microsoft.com/library/956bd710-c547-4fb8-a0db-6b82753739bc)|Adding this attribute to a type causes it to be represented using a CLI class.|
|type [CLIEventAttribute](https://msdn.microsoft.com/library/d359f1dd-ffa5-42fb-8808-b4c8131a0333)|Adding this attribute to a property with event type causes it to be compiled with as a CLI metadata event, through a syntactic translation to a pair of 'add_EventName' and 'remove_EventName' methods.|
|type [CLIMutableAttribute](https://msdn.microsoft.com/library/571d62f3-5fb5-4088-a9d8-9d2fa61efdb7)|Adding this attribute to a record type causes it to be compiled to a CLI representation with a default constructor with property getters and setters.|
|type [ComparisonConditionalOnAttribute](https://msdn.microsoft.com/library/30f6b489-e03d-4864-bd84-7e88708f569c)|This attribute is used to indicate a generic container type satisfies the F# 'comparison' constraint only if a generic argument also satisfies this constraint. For example, adding this attribute to parameter 'T on a type definition C&lt;'T&gt; means that a type C&lt;X&gt; only supports comparison if the type X also supports comparison and all other conditions for C&lt;X&gt; to support comparison are also met. The type C&lt;'T&gt; can still be used with other type arguments, but a type such as C&lt;(int -&gt; int)&gt; will not support comparison because the type (int -&gt; int) is an F# function type and does not support comparison.|
|type [CompilationArgumentCountsAttribute](https://msdn.microsoft.com/library/b774bd57-b7e8-40a2-9f4b-d2b8079723b6)|This attribute is generated automatically by the F# compiler to tag functions and members that accept a partial application of some of their arguments and return a residual function|
|type [CompilationMappingAttribute](https://msdn.microsoft.com/library/59f72aa6-2c04-4318-8243-02875407da29)|This attribute is inserted automatically by the F# compiler to tag types and methods in the generated CLI code with flags indicating the correspondence with original source constructs. It is used by the functions in the Microsoft.FSharp.Reflection namespace to reverse-map compiled constructs to their original forms. It is not intended for use from user code.|
|type [CompilationRepresentationAttribute](https://msdn.microsoft.com/library/44f25078-a62b-4fcc-9143-344e0af97399)|This attribute is used to adjust the runtime representation for a type. For example, it may be used to note that the **null** representation may be used for a type. This affects how some constructs are compiled.|
|type [CompilationRepresentationFlags](https://msdn.microsoft.com/library/e32f2b3e-34f0-4e03-8bcc-05ed535c0b51)|Indicates one or more adjustments to the compiled representation of an F# type or member.|
|type [CompilationSourceNameAttribute](https://msdn.microsoft.com/library/a191c0ef-160a-4c15-aea6-425198276efd)|This attribute is inserted automatically by the F# compiler to tag methods which are given the 'CompiledName' attribute. It is not intended for use from user code.|
|type [CompiledNameAttribute](https://msdn.microsoft.com/library/fb4ca03a-86ae-4334-b6a0-3de01e98904d)|Adding this attribute to a value or function definition in an F# module changes the name used for the value in compiled CLI code.|
|type [CompilerMessageAttribute](https://msdn.microsoft.com/library/6c7601c0-a58e-458c-bee7-66f6a0de4fb6)|Indicates that a message should be emitted when F# source code uses this construct.|
|type [CustomComparisonAttribute](https://msdn.microsoft.com/library/e25c43cc-e553-44b2-8229-cff53f4af552)|Adding this attribute to a type indicates it is a type with a user-defined implementation of comparison.|
|type [CustomEqualityAttribute](https://msdn.microsoft.com/library/798e06a2-fbc1-452c-a606-5f050227866e)|Adding this attribute to a type indicates it is a type with a user-defined implementation of equality.|
|type [CustomOperationAttribute](https://msdn.microsoft.com/library/199f3927-79df-484b-ba66-85f58cc49b19)|Indicates that a member on a computation builder type is a custom query operator, and indicates the name of that operator.|
|type [decimal&lt;'Measure&gt;](https://msdn.microsoft.com/library/78bad839-9dfb-4e26-85dc-e0ccd3ef361d)|The type of decimal numbers, annotated with a unit of measure. The unit of measure is erased in compiled code and when values of this type are analyzed using reflection. The type is representationally equivalent to **System.Decimal**.|
|type [DefaultAugmentationAttribute](https://msdn.microsoft.com/library/add853d3-c839-4720-a6d1-b9dbe5b9db56)|Adding this attribute to a discriminated union with value false turns off the generation of standard helper member tester, constructor and accessor members for the generated CLI class for that type.|
|type [DefaultValueAttribute](https://msdn.microsoft.com/library/a3a3307b-8c05-441e-b109-245511614d58)|Adding this attribute to a field declaration means that the field is not initialized. During type checking a constraint is asserted that the field type supports 'null'. If the 'check' value is false then the constraint is not asserted.|
|type [EntryPointAttribute](https://msdn.microsoft.com/library/accfa56a-f18e-4671-b31e-9209e4a337a9)|Adding this attribute to a function indicates it is the entrypoint for an application. If this absent is not speficied for an EXE then the initialization implicit in the module bindings in the last file in the compilation sequence are used as the entrypoint.|
|type [EqualityConditionalOnAttribute](https://msdn.microsoft.com/library/26f5c760-97fe-4a6c-8437-652bdc203ee8)|This attribute is used to indicate a generic container type satisfies the F# 'equality' constraint only if a generic argument also satisfies this constraint. For example, adding this attribute to parameter 'T on a type definition C&lt;'T&gt; means that a type C&lt;X&gt; only supports equality if the type X also supports equality and all other conditions for C&lt;X&gt; to support equality are also met. The type C&lt;'T&gt; can still be used with other type arguments, but a type such as C&lt;(int -&gt; int)&gt; will not support equality because the type (int -&gt; int) is an F# function type and does not support equality.|
|type [ExperimentalAttribute](https://msdn.microsoft.com/library/af5fb739-9fce-414d-a956-0ec61326de08)|This attribute is used to tag values that are part of an experimental library feature.|
|type [float&lt;'Measure&gt;](https://msdn.microsoft.com/library/618b935e-4407-459b-a877-95ae031deb57)|The type of floating point numbers, annotated with a unit of measure. The unit of measure is erased in compiled code and when values of this type are analyzed using reflection. The type is representationally equivalent to **System.Double**.|
|type [float32&lt;'Measure&gt;](https://msdn.microsoft.com/library/12549ca9-58d8-41ee-a163-f02f28d19a07)|The type of floating point numbers, annotated with a unit of measure. The unit of measure is erased in compiled code and when values of this type are analyzed using reflection. The type is representationally equivalent to **System.Single**.|
|type [FSharpFunc&lt;'T,'U&gt;](https://msdn.microsoft.com/library/6fbc582c-a36a-4154-9bfe-296de5ecba53)|The CLI type used to represent F# function values. This type is not typically used directly, though may be used from other CLI languages.|
|type [FSharpInterfaceDataVersionAttribute](https://msdn.microsoft.com/library/900505db-8d27-432e-a216-07ec17dc179d)|This attribute is added to generated assemblies to indicate the version of the data schema used to encode additional F# specific information in the resource attached to compiled F# libraries.|
|type [FSharpTypeFunc](https://msdn.microsoft.com/library/695a5ba3-d499-464a-9ccd-85bb3e5573dc)|The CLI type used to represent F# first-class type function values. This type is for use by compiled F# code.|
|type [FuncConvert](https://msdn.microsoft.com/library/6891aadd-43e8-43a2-a362-c0c81e73aacf)|Helper functions for converting F# first class function values to and from CLI representaions of functions using delegates.|
|type [GeneralizableValueAttribute](https://msdn.microsoft.com/library/80cf5376-ac02-42d2-99d5-e1d662907a32)|Adding this attribute to a non-function value with generic parameters indicates that uses of the construct can give rise to generic code through type inference.|
|type [ilsigptr&lt;'T&gt;](https://msdn.microsoft.com/library/d1996af9-3b01-4ad3-bad7-54390dffd6aa)|This type is for internal use by the F# code generator.|
|type [int&lt;'Measure&gt;](https://msdn.microsoft.com/library/4adfbe83-28fc-4e0e-8a61-c0ed36c40703)|The type of 32-bit signed integer numbers, annotated with a unit of measure. The unit of measure is erased in compiled code and when values of this type are analyzed using reflection. The type is representationally equivalent to **System.Int32**.|
|type [int16&lt;'Measure&gt;](https://msdn.microsoft.com/library/cb64fd68-ed52-4ce4-88e8-bac6e52a1ec9)|The type of 16-bit signed integer numbers, annotated with a unit of measure. The unit of measure is erased in compiled code and when values of this type are analyzed using reflection. The type is representationally equivalent to **System.Int16**.|
|type [int64&lt;'Measure&gt;](https://msdn.microsoft.com/library/3162a880-c9f2-4129-8ced-f1c37b981184)|The type of 64-bit signed integer numbers, annotated with a unit of measure. The unit of measure is erased in compiled code and when values of this type are analyzed using reflection. The type is representationally equivalent to **System.Int64**.|
|type [InterfaceAttribute](https://msdn.microsoft.com/library/19860f07-4922-4fd0-9d84-2c1b35a6ee62)|Adding this attribute to a type causes it to be represented using a CLI interface.|
|type [LiteralAttribute](https://msdn.microsoft.com/library/465f36ce-d146-41c0-b425-679c509cd285)|Adding this attribute to a value causes it to be compiled as a CLI constant literal.|
|type [MeasureAnnotatedAbbreviationAttribute](https://msdn.microsoft.com/library/11c1a476-9661-40a6-92c8-2e7889f33d88)|Adding this attribute to a type causes it to be interpreted as a refined type, currently limited to measure-parameterized types. This may only be used under very limited conditions.|
|type [MeasureAttribute](https://msdn.microsoft.com/library/553c9d6b-880c-4592-ba0b-756bc9f47a2b)|Adding this attribute to a type causes it to be interpreted as a unit of measure. This may only be used under very limited conditions.|
|type [nativeptr&lt;'T&gt;](https://msdn.microsoft.com/library/6e74c8e5-f2ff-4e56-ab05-c337b0618d73)|Represents an unmanaged pointer in F# code.|
|type [NoComparisonAttribute](https://msdn.microsoft.com/library/2203a119-7e12-48cc-9b8d-58d07db3da26)|Adding this attribute to a type indicates it is a type where comparison is an abnormal operation. This means that the type does not satisfy the F# 'comparison' constraint. Within the bounds of the F# type system, this helps ensure that the F# generic comparison function is not instantiated directly at this type. The attribute and checking does not constrain the use of comparison with base or child types of this type.|
|type [NoDynamicInvocationAttribute](https://msdn.microsoft.com/library/fceab6c1-2592-43a4-88b4-c294b2082e16)|This attribute is used to tag values that may not be dynamically invoked at runtime. This is typically added to inlined functions whose implementations include unverifiable code. It causes the method body emitted for the inlined function to raise an exception if dynamically invoked, rather than including the unverifiable code in the generated assembly.|
|type [NoEqualityAttribute](https://msdn.microsoft.com/library/c94ead1e-4d74-4075-a287-fc2c565945a0)|Adding this attribute to a type indicates it is a type where equality is an abnormal operation. This means that the type does not satisfy the F# 'equality' constraint. Within the bounds of the F# type system, this helps ensure that the F# generic equality function is not instantiated directly at this type. The attribute and checking does not constrain the use of comparison with base or child types of this type.|
|type [Option&lt;'T&gt;](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)|The type of optional values. When used from other CLI languages the empty option is the **null** value.|
|type [OptionalArgumentAttribute](https://msdn.microsoft.com/library/1757b4d4-0f46-4c96-94e6-986a744bf7bb)|This attribute is added automatically for all optional arguments.|
|type [PrintfFormat&lt;'Printer,'State,'Residue,'Result,'Tuple&gt;](https://msdn.microsoft.com/library/ce1f2264-215b-44ed-b588-77798acc756a)|Type of a formatting expression.|
|type [PrintfFormat&lt;'Printer,'State,'Residue,'Result&gt;](https://msdn.microsoft.com/library/60c973f2-afb2-44ca-8331-3758a5f96467)|Type of a formatting expression.|
|type [ProjectionParameterAttribute](https://msdn.microsoft.com/library/b71b8ac1-0fd4-41d2-b97e-d6fc118421fa)|Indicates that, when a custom operator is used in a computation expression, a parameter is automatically parameterized by the variable space of the computation expression.|
|type [Ref&lt;'T&gt;](https://msdn.microsoft.com/library/d816cd68-043d-4f2f-a8a1-01c3bb78f93d)|The type of mutable references. Use the functions [:=] and [!] to get and set values of this type.|
|type [ReferenceEqualityAttribute](https://msdn.microsoft.com/library/6b448574-616f-4825-80c5-ad9334c4d252)|Adding this attribute to a record or union type disables the automatic generation of overrides for 'System.Object.Equals(obj)', 'System.Object.GetHashCode()' and 'System.IComparable' for the type. The type will by default use reference equality.|
|type [ReflectedDefinitionAttribute](https://msdn.microsoft.com/library/56bb03a2-4deb-4860-b334-f59fdfc95b04)|Adding this attribute to the let-binding for the definition of a top-level value makes the quotation expression that implements the value available for use at runtime.|
|type [RequireQualifiedAccessAttribute](https://msdn.microsoft.com/library/8b9b6ade-0471-4413-ac5d-638cd0de5f15)|This attribute is used to indicate that references to a the elements of a module, record or union type require explicit qualified access.|
|type [RequiresExplicitTypeArgumentsAttribute](https://msdn.microsoft.com/library/74f570a0-88f8-4183-a314-2151e3351076)|Adding this attribute to a type, value or member requires that uses of the construct must explicitly instantiate any generic type parameters.|
|type [sbyte&lt;'Measure&gt;](https://msdn.microsoft.com/library/c57f7fca-3b86-4024-80fe-481ba329bffc)|The type of 8-bit signed integer numbers, annotated with a unit of measure. The unit of measure is erased in compiled code and when values of this type are analyzed using reflection. The type is representationally equivalent to **System.SByte**.|
|type [SealedAttribute](https://msdn.microsoft.com/library/375b15c9-c6c4-4466-95db-35cbabb6c1d5)|Adding this attribute to class definition makes it sealed, which means it may not be extended or implemented.|
|type [SourceConstructFlags](https://msdn.microsoft.com/library/6da6a0c5-25d0-407d-8536-70182654d738)|Indicates the relationship between a compiled entity in a CLI binary and an element in F# source code.|
|type [StructAttribute](https://msdn.microsoft.com/library/8a85f5ba-4ea8-438f-b88b-5b0c8b57d018)|Adding this attribute to a type causes it to be represented using a CLI struct.|
|type [StructuralComparisonAttribute](https://msdn.microsoft.com/library/92bc1c1e-8b77-494f-900b-0fd394abb565)|Adding this attribute to a record, union, exception, or struct type confirms the automatic generation of implementations for 'System.IComparable' for the type.|
|type [StructuralEqualityAttribute](https://msdn.microsoft.com/library/ce41f6e6-5534-4bb5-98f8-24288d04265a)|Adding this attribute to a record, union or struct type confirms the automatic generation of overrides for 'System.Object.Equals(obj)' and 'System.Object.GetHashCode()' for the type.|
|type [StructuredFormatDisplayAttribute](https://msdn.microsoft.com/library/1a860822-bc8c-4137-9f25-e95483b5b781)|This attribute is used to mark how a type is displayed by default when using '%A' printf formatting patterns and other two-dimensional text-based display layouts. In this version of F# the only valid values are of the form **PreText {PropertyName} PostText**. The property name indicates a property to evaluate and to display instead of the object itself.|
|type [Unit](https://msdn.microsoft.com/library/d40df6bf-4448-4691-9965-0f1dbc376839)|The type 'unit', which has only one value "()". This value is special and always uses the representation 'null'.|
|type [UnverifiableAttribute](https://msdn.microsoft.com/library/3a874ac6-dc5e-4da6-82c1-2addaf8b3189)|This attribute is used to tag values whose use will result in the generation of unverifiable code. These values are inevitably marked 'inline' to ensure that the unverifiable constructs are not present in the actual code for the F# library, but are rather copied to the source code of the caller.|
|type [VolatileFieldAttribute](https://msdn.microsoft.com/library/1e7ea0f8-4c85-402e-b529-55079bc79d7e)|Adding this attribute to an F# mutable binding causes the "volatile" prefix to be used for all accesses to the field.|

## Type Abbreviations

|Type|Description|
|----|-----------|
|type [array&lt;'T&gt;](https://msdn.microsoft.com/library/4c962adb-1f9e-4cf9-89fe-5c2bbb4a4a89)|Single dimensional, zero-based arrays, written **int[]**, **string[]** etc.|
|type [bigint](https://msdn.microsoft.com/library/dc8be18d-4042-46c4-b136-2f21a84f6efa)|Arbitrarily large integers. An abbreviation for the type **System.Numerics.BigInteger**.|
|type [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)|An abbreviation for the CLI type **System.Boolean**.|
|type [byte](https://msdn.microsoft.com/library/17a98430-283a-4ff6-a475-e6999577179d)|An abbreviation for the CLI type **System.Byte**.|
|type [char](https://msdn.microsoft.com/library/3627f475-985b-4b4e-94d2-14f217c04958)|An abbreviation for the CLI type **System.Char**.|
|type [decimal](https://msdn.microsoft.com/library/9d557533-316c-4b5c-aed5-4d35506f6c3e)|An abbreviation for the CLI type **System.Decimal**.|
|type [double](https://msdn.microsoft.com/library/f8182bed-b370-4b05-9768-ee2132bff02c)|An abbreviation for the CLI type **System.Double**.|
|type [exn](https://msdn.microsoft.com/library/e1569b69-3b30-440b-8c6f-966d1c6a06ab)|An abbreviation for the CLI type **System.Exception**.|
|type [float](https://msdn.microsoft.com/library/3fa76cae-e9b5-4672-8bdf-88ff6dbcf7b8)|An abbreviation for the CLI type **System.Double**.|
|type [float32](https://msdn.microsoft.com/library/9bf674b5-ea9a-4b08-ad42-4da313b6ebf0)|An abbreviation for the CLI type **System.Single**.|
|type [Format&lt;'Printer,'State,'Residue,'Result,'Tuple&gt;](https://msdn.microsoft.com/library/861ade4e-9b91-4508-b3ca-32316359af53)|Type of a formatting expression.|
|type [Format&lt;'Printer,'State,'Residue,'Result&gt;](https://msdn.microsoft.com/library/470f484f-a026-40af-8f8c-1e3aaf013bdc)|Type of a formatting expression.|
|type [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)|An abbreviation for the CLI type **System.Int32**.|
|type [int16](https://msdn.microsoft.com/library/608e612c-5a8e-40c4-912f-55788628cb9b)|An abbreviation for the CLI type **System.Int16**.|
|type [int32](https://msdn.microsoft.com/library/6ab0ea34-03db-4874-a265-bef9c64f8eff)|An abbreviation for the CLI type **System.Int32**.|
|type [int64](https://msdn.microsoft.com/library/1bec11c0-45ac-469e-923b-22a1708c0701)|An abbreviation for the CLI type **System.Int64**.|
|type [int8](https://msdn.microsoft.com/library/bb8b2db1-1621-42b8-ac4c-3a3b5b193198)|An abbreviation for the CLI type **System.SByte**.|
|type [nativeint](https://msdn.microsoft.com/library/f8478c3e-fff5-4f10-82cf-4bedfe305f7b)|An abbreviation for the CLI type **System.IntPtr**.|
|type [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)|An abbreviation for the CLI type **System.Object**.|
|type [option&lt;'T&gt;](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)|The type of optional values. When used from other CLI languages the empty option is the **null** value.|
|type [ref&lt;'T&gt;](https://msdn.microsoft.com/library/8c9b90cf-4341-4a04-a9ee-d1be2b0d1aa6)|The type of mutable references. Use the functions [:=] and [!] to get and set values of this type.|
|type [sbyte](https://msdn.microsoft.com/library/fbc28b7f-2dbf-4361-acb3-830886820068)|An abbreviation for the CLI type **System.SByte**.|
|type [single](https://msdn.microsoft.com/library/d772f88f-4365-4f8c-95ef-e66eb10f0722)|An abbreviation for the CLI type **System.Single**.|
|type [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)|An abbreviation for the CLI type **System.String**.|
|type [uint16](https://msdn.microsoft.com/library/2ab2f1fa-344e-4fcf-a688-5024c589630b)|An abbreviation for the CLI type **System.UInt16**.|
|type [uint32](https://msdn.microsoft.com/library/02aea3e2-e400-453a-a681-3a657afe1825)|An abbreviation for the CLI type **System.UInt32**.|
|type [uint64](https://msdn.microsoft.com/library/3c4f3a04-06eb-48aa-b38e-16646bda2f33)|An abbreviation for the CLI type **System.UInt64**.|
|type [uint8](https://msdn.microsoft.com/library/fae517cf-c501-477e-96ca-5b6a3d8d8e30)|An abbreviation for the CLI type **System.Byte**.|
|type [unativeint](https://msdn.microsoft.com/library/9d2946a7-ace9-48a4-8cff-7894b8e7de86)|An abbreviation for the CLI type **System.UIntPtr**.|
|type [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)|The type 'unit', which has only one value "()". This value is special and always uses the representation 'null'.|

## Exceptions

|Exception|Condition|
|----|----|
|[MatchFailureException](https://msdn.microsoft.com/library/ee353648.aspx)|Non-exhaustive match failures will raise the MatchFailureException exception.|

## See Also
[F&#35; Core Library Reference](FSharp-Core-Library-Reference.md)
