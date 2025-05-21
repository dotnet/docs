---
title: System.Type.GetType methods
description: Learn about the System.Type.GetType methods.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
ms.topic: article
---
# System.Type.GetType methods

[!INCLUDE [context](includes/context.md)]

Use the <xref:System.Type.GetType(System.String,System.Func{System.Reflection.AssemblyName,System.Reflection.Assembly},System.Func{System.Reflection.Assembly,System.String,System.Boolean,System.Type},System.Boolean,System.Boolean)> method overload and its associated overloads (<xref:System.Type.GetType(System.String,System.Func{System.Reflection.AssemblyName,System.Reflection.Assembly},System.Func{System.Reflection.Assembly,System.String,System.Boolean,System.Type})> and <xref:System.Type.GetType(System.String,System.Func{System.Reflection.AssemblyName,System.Reflection.Assembly},System.Func{System.Reflection.Assembly,System.String,System.Boolean,System.Type},System.Boolean)>) to replace the default implementation of the <xref:System.Type.GetType%2A> method with more flexible implementations. By providing your own methods that resolve type names and the names of the assemblies that contain them, you can do the following:

- Control which version of an assembly a type is loaded from.
- Provide another place to look for a type name that does not include an assembly name.
- Load assemblies using partial assembly names.
- Return subclasses of <xref:System.Type?displayProperty=nameWithType> that are not created by the common language runtime (CLR).

For example, in version-tolerant serialization this method enables you to search for a "best fit" assembly by using a partial name. Other overloads of the <xref:System.Type.GetType%2A> method require an assembly-qualified type name, which includes the version number.

Alternate implementations of the type system may need to return subclasses of <xref:System.Type?displayProperty=nameWithType> that are not created by the CLR; all types that are returned by other overloads of the <xref:System.Type.GetType%2A> method are runtime types.

## Usage notes

This method overload and its associated overloads parse `typeName` into the name of a type and the name of an assembly, and then resolve the names. Resolution of the assembly name occurs before resolution of the type name, because a type name must be resolved in the context of an assembly.

> [!NOTE]
> If you are unfamiliar with the concept of assembly-qualified type names, see the <xref:System.Type.AssemblyQualifiedName> property.

If `typeName` is not an assembly-qualified name, assembly resolution is skipped. Unqualified type names can be resolved in the context of mscorlib.dll/System.Private.CoreLib.dll or the currently executing assembly, or you can optionally provide an assembly in the `typeResolver` parameter. The effects of including or omitting the assembly name for different kinds of name resolution are displayed as a table in the [Mixed name resolution](#mixed-name-resolution) section.

General usage notes:

- Do not pass methods to `assemblyResolver` or `typeResolver` if they come from unknown or untrusted callers. Use only methods that you provide or that you are familiar with.

  > [!CAUTION]
  > Using methods from unknown or untrusted callers could result in elevation of privilege for malicious code.

- If you omit the `assemblyResolver` and/or `typeResolver` parameters, the value of the `throwOnError` parameter is passed to the methods that perform the default resolution.

- If `throwOnError` is `true`, this method throws a <xref:System.TypeLoadException> when `typeResolver` returns `null`, and a <xref:System.IO.FileNotFoundException> when `assemblyResolver` returns `null`.

- This method does not catch exceptions thrown by `assemblyResolver` and `typeResolver`. You are responsible for any exceptions that are thrown by the resolver methods.

### Resolve assemblies

The `assemblyResolver` method receives an <xref:System.Reflection.AssemblyName> object, which is produced by parsing the string assembly name that is included in `typeName`. If `typeName` does not contain an assembly name, `assemblyResolver` is not called and `null` is passed to `typeResolver`.

If `assemblyResolver` is not supplied, standard assembly probing is used to locate the assembly. If `assemblyResolver` is provided, the <xref:System.Type.GetType%2A> method does not do standard probing; in that case you must ensure that your `assemblyResolver` can handle all the assemblies you pass to it.

The `assemblyResolver` method should return `null` if the assembly cannot be resolved. If `assemblyResolver` returns `null`, `typeResolver` is not called and no further processing occurs; additionally, if `throwOnError` is `true`, a <xref:System.IO.FileNotFoundException> is thrown.

If the <xref:System.Reflection.AssemblyName> that is passed to `assemblyResolver` is a partial name, one or more of its parts are `null`. For example, if it has no version, the <xref:System.Reflection.AssemblyName.Version> property is `null`. If the <xref:System.Reflection.AssemblyName.Version> property, the <xref:System.Reflection.AssemblyName.CultureInfo> property, and the <xref:System.Reflection.AssemblyName.GetPublicKeyToken%2A> method all return `null`, then only the simple name of the assembly was supplied. The `assemblyResolver` method can use or ignore all parts of the assembly name.

The effects of different assembly resolution options are displayed as a table in the [Mixed name resolution](#mixed-name-resolution) section, for simple and assembly-qualified type names.

### Resolve types

If `typeName` does not specify an assembly name, `typeResolver` is always called. If `typeName` specifies an assembly name, `typeResolver` is called only when the assembly name is successfully resolved. If `assemblyResolver` or standard assembly probing returns `null`, `typeResolver` is not called.

The `typeResolver` method receives three arguments:

- The assembly to search or `null` if `typeName` does not contain an assembly name.
- The simple name of the type. In the case of a nested type, this is the outermost containing type. In the case of a generic type, this is the simple name of the generic type.
- A Boolean value that's `true` if the case of type names is to be ignored.

The implementation determines the way these arguments are used. The `typeResolver` method should return `null` if it cannot resolve the type. If `typeResolver` returns `null` and `throwOnError` is `true`, this overload of <xref:System.Type.GetType%2A> throws a <xref:System.TypeLoadException>.

The effects of different type resolution options are displayed as a table in the [Mixed name resolution](#mixed-name-resolution) section, for simple and assembly-qualified type names.

#### Resolve nested types

If `typeName` is a nested type, only the name of the outermost containing type is passed to `typeResolver`. When `typeResolver` returns this type, the <xref:System.Type.GetNestedType%2A> method is called recursively until the innermost nested type has been resolved.

#### Resolve generic types

The <xref:System.Type.GetType%2A> is called recursively to resolve generic types: First to resolve the generic type itself, and then to resolve its type arguments. If a type argument is generic, <xref:System.Type.GetType%2A> is called recursively to resolve its type arguments, and so on.

The combination of `assemblyResolver` and `typeResolver` that you provide must be capable of resolving all levels of this recursion. For example, suppose you supply an `assemblyResolver` that controls the loading of `MyAssembly`. Suppose you want to resolve the generic type `Dictionary<string, MyType>` (`Dictionary(Of String, MyType)` in Visual Basic). You might pass the following generic type name:

```
"System.Collections.Generic.Dictionary`2[System.String,[MyNamespace.MyType, MyAssembly]]"
```

Notice that `MyType` is the only assembly-qualified type argument. The names of the <xref:System.Collections.Generic.Dictionary%602> and <xref:System.String> classes are not assembly-qualified. Your `typeResolver` must be able to handle either an assembly or `null`, because it will receive `null` for <xref:System.Collections.Generic.Dictionary%602> and <xref:System.String>. It can handle that case by calling an overload of the <xref:System.Type.GetType%2A> method that takes a string, because both of the unqualified type names are in mscorlib.dll/System.Private.CoreLib.dll:

:::code language="csharp" source="./snippets/System/Type/GetType/csharp/source.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Type/GetType/fsharp/source.fs" id="Snippet1":::

The `assemblyResolver` method is not called for the dictionary type and the string type, because those type names are not assembly-qualified.

Now suppose that instead of `System.String`, the first generic argument type is `YourType`, from `YourAssembly`:

```
"System.Collections.Generic.Dictionary`2[[YourNamespace.YourType, YourAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null], [MyNamespace.MyType, MyAssembly]]"
```

Because this assembly is neither mscorlib.dll/System.Private.CoreLib.dll nor the currently executing assembly, you cannot resolve `YourType` without an assembly-qualified name. Because your `assemblyResolve` will be called recursively, it must be able to handle this case. Instead of returning `null` for assemblies other than `MyAssembly`, it now performs an assembly load using the supplied <xref:System.Reflection.AssemblyName> object.

:::code language="csharp" source="./snippets/System/Type/GetType/csharp/source.cs" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Type/GetType/fsharp/source.fs" id="Snippet2":::

#### Resolve type names with special characters

Certain characters have special meanings in assembly-qualified names. If a simple type name contains these characters, the characters cause parsing errors when the simple name is part of an assembly-qualified name. To avoid the parsing errors, you must escape the special characters with a backslash before you can pass the assembly-qualified name to the <xref:System.Type.GetType%2A> method. For example, if a type is named `Strange]Type`, the escape character must be added ahead of the square bracket as follows: `Strange\]Type`.

> [!NOTE]
> Names with such special characters cannot be created in Visual Basic or C#, but can be created by using common intermediate language (CIL) or by emitting dynamic assemblies.

The following table shows the special characters for type names.

|Character|Meaning|
|---------------|-------------|
|`,` (comma)|Delimiter for assembly-qualified names.|
|`[]` (square brackets)|As a suffix pair, indicates an array type; as a delimiter pair, encloses generic argument lists and assembly-qualified names.|
|`&` (ampersand)|As a suffix, indicates that a type is a reference type.|
|`*` (asterisk)|As a suffix, indicates that a type is a pointer type.|
|`+` (plus)|Delimiter for nested types.|
|`\` (backslash)|Escape character.|

Properties such as <xref:System.Type.AssemblyQualifiedName%2A> return correctly escaped strings. You must pass correctly escaped strings to the <xref:System.Type.GetType%2A> method. In turn, the <xref:System.Type.GetType%2A> method passes correctly escaped names to `typeResolver` and to the default type resolution methods. If you need to compare a name to an unescaped name in `typeResolver`, you must remove the escape characters.

## Mixed name resolution

The following table summarizes the interactions between `assemblyResolver`, `typeResolver`, and default name resolution, for all combinations of type name and assembly name in `typeName`:

|Contents of type name|Assembly resolver method|Type resolver method|Result|
|---------------------------|------------------------------|--------------------------|------------|
|type, assembly|null|null|Equivalent to calling the <xref:System.Type.GetType(System.String,System.Boolean,System.Boolean)?displayProperty=nameWithType> method overload.|
|type, assembly|provided|null|`assemblyResolver` returns the assembly or returns `null` if it cannot resolve the assembly. If the assembly is resolved, the <xref:System.Reflection.Assembly.GetType(System.String,System.Boolean,System.Boolean)?displayProperty=nameWithType> method overload is used to load the type from the assembly; otherwise, there is no attempt to resolve the type.|
|type, assembly|null|provided|Equivalent to converting the assembly name to an <xref:System.Reflection.AssemblyName> object and calling the <xref:System.Reflection.Assembly.Load(System.Reflection.AssemblyName)?displayProperty=nameWithType> method overload to get the assembly. If the assembly is resolved, it is passed to `typeResolver`; otherwise, `typeResolver` is not called and there is no further attempt to resolve the type.|
|type, assembly|provided|provided|`assemblyResolver` returns the assembly or returns `null` if it cannot resolve the assembly. If the assembly is resolved, it is passed to `typeResolver`; otherwise, `typeResolver` is not called and there is no further attempt to resolve the type.|
|type|null, provided|null|Equivalent to calling the <xref:System.Type.GetType(System.String,System.Boolean,System.Boolean)?displayProperty=nameWithType> method overload. Because the assembly name is not provided, only mscorlib.dll/System.Private.CoreLib.dll and the currently executing assembly are searched. If `assemblyResolver` is provided, it is ignored.|
|type|null, provided|provided|`typeResolver` is called, and `null` is passed for the assembly. `typeResolver` can provide a type from any assembly, including assemblies it loads for the purpose. If `assemblyResolver` is provided, it is ignored.|
|assembly|null, provided|null, provided|A <xref:System.IO.FileLoadException> is thrown, because the assembly name is parsed as if it were an assembly-qualified type name. This results in an invalid assembly name.|
