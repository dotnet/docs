---
title: Caller information (F#)
description: Describes how to use Caller Info Argument Attributes to obtain caller information from a method.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 04/25/2017
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: a3dcc335-433b-4672-ac2d-ae6b11b816f3 
---

# Caller information

By using Caller Info attributes, you can obtain information about the caller to a method. You can obtain file path of the source code, the line number in the source code, and the member name of the caller. This information is helpful for tracing, debugging, and creating diagnostic tools.

To obtain this information, you use attributes that are applied to optional parameters, each of which has a default value. The following table lists the Caller Info attributes that are defined in the [System.Runtime.CompilerServices](/dotnet/api/system.runtime.compilerservices) namespace:

|Attribute|Description|Type|
|---------|-----------|----|
|[CallerFilePath](/dotnet/api/system.runtime.compilerservices.callerfilepathattribute)|Full path of the source file that contains the caller. This is the file path at compile time.|`String`
|[CallerLineNumber](/dotnet/api/system.runtime.compilerservices.callerlinenumberattribute)|Line number in the source file at which the method is called.|`Integer`|
|[CallerMemberName](/dotnet/api/system.runtime.compilerservices.callermembernameattribute)|Method or property name of the caller. See the Member Names section later in this topic.|`String`|

## Example

The following example shows how you might use these attributes to trace a caller.

```fsharp
open System.Diagnostics
open System.Runtime.CompilerServices

type Tracer() =
    member __.DoTrace(msg: string,
                      [<CallerMemberName>] ?memberName: string,
                      [<CallerFilePath>] ?path: string
                      [<CallerLineNumber>] ?line: int) =
        Trace.WriteLine(sprintf "Message: %s" message)
        match (memberName, path, line) with
        | Some m, Some p, Some l ->
            Trace.WriteLine(sprintf "Member name: %s" m)
            Trace.WriteLine(sprintf "Source file path: %s" p)
            Trace.WriteLine(sprintf "Source line number: %d" l)
        | _,_,_ -> ()
```

## Remarks

Caller Info attributes can only be applied to optional parameters. You must supply an explicit value for each optional parameter. The Caller Info attributes cause the compiler to write the proper value for each optional parameter decorated with a Caller Info attribute.

Caller Info values are emitted as literals into the Intermediate Language (IL) at compile time. Unlike the results of the [StackTrace](/dotnet/api/system.diagnostics.stacktrace) property for exceptions, the results aren't affected by obfuscation.

You can explicitly supply the optional arguments to control the caller information or to hide caller information.

## Member names

You can use the [`CallerMemberName`](/dotnet/api/system.runtime.compilerservices.callermembernameattribute) attribute to avoid specifying the member name as a `String` argument to the called method. By using this technique, you avoid the problem that Rename Refactoring doesn't change the `String` values. This benefit is especially useful for the following tasks:

* Using tracing and diagnostic routines.
* Implementing the [INotifyPropertyChanged](/dotnet/api/system.componentmodel.inotifypropertychanged) interface when binding data. This interface allows the property of an object to notify a bound control that the property has changed, so that the control can display the updated information. Without the [`CallerMemberName`](/dotnet/api/system.runtime.compilerservices.callermembernameattribute) attribute, you must specify the property name as a literal.

The following chart shows the member names that are returned when you use the CallerMemberName attribute.

|Calls occurs within|Member name result|
|-------------------|------------------|
|Method, property, or event|The name of the method, property, or event from which the call originated.|
|Constructor|The string ".ctor"|
|Static constructor|The string ".cctor"|
|Destructor|The string "Finalize"|
|User-defined operators or conversions|The generated name for the member, for example, "op_Addition".|
|Attribute constructor|The name of the member to which the attribute is applied. If the attribute is any element within a member (such as a parameter, a return value, or a generic type parameter), this result is the name of the member that's associated with that element.|
|No containing member (for example, assembly-level or attributes that are applied to types)|The default value of the optional parameter.|

## See also
 [Attributes](attributes.md)  
 [Named arguments](parameters-and-arguments.md#named-arguments)  
 [Optional parameters](parameters-and-arguments.md#optional-parameters)  
