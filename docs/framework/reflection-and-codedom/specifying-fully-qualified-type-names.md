---
title: "Specifying Fully Qualified Type Names"
ms.custom: ""
ms.date: "03/14/2018"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "names [.NET Framework], fully qualified type names"
  - "reflection, fully qualified type names"
  - "names [.NET Framework], assemblies"
  - "tokens"
  - "BNF"
  - "assemblies [.NET Framework], names"
  - "languages, grammar"
  - "fully qualified type names"
  - "type names"
  - "special characters"
  - "IDENTIFIER"
ms.assetid: d90b1e39-9115-4f2a-81c0-05e7e74e5580
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Specifying Fully Qualified Type Names
You must specify type names to have valid input to various reflection operations. A fully qualified type name consists of an assembly name specification, a namespace specification, and a type name. Type name specifications are used by methods such as <xref:System.Type.GetType%2A?displayProperty=nameWithType>, <xref:System.Reflection.Module.GetType%2A?displayProperty=nameWithType>, <xref:System.Reflection.Emit.ModuleBuilder.GetType%2A?displayProperty=nameWithType>, and <xref:System.Reflection.Assembly.GetType%2A?displayProperty=nameWithType>.  
  
## Grammar for Type Names  
 The grammar defines the syntax of formal languages. The following table lists lexical rules that describe how to recognize a valid input. Terminals (those elements that are not further reducible) are shown in all uppercase letters. Nonterminals (those elements that are further reducible) are shown in mixed-case or singly quoted strings, but the single quote (') is not a part of the syntax itself. The pipe character (&#124;) denotes rules that have subrules.  

```antlr
TypeSpec
	: ReferenceTypeSpec
	| SimpleTypeSpec
	;

ReferenceTypeSpec
	: SimpleTypeSpec '&'
	;

SimpleTypeSpec
	: PointerTypeSpec
	| ArrayTypeSpec
	| TypeName
	;

PointerTypeSpec
	: SimpleTypeSpec '*'
	;

ArrayTypeSpec
	: SimpleTypeSpec '[ReflectionDimension]'
	| SimpleTypeSpec '[ReflectionEmitDimension]'
	;

ReflectionDimension
	: '*'
	| ReflectionDimension ',' ReflectionDimension
	| NOTOKEN
	;

ReflectionEmitDimension
	: '*'
	| Number '..' Number
	| Number '…'
	| ReflectionDimension ',' ReflectionDimension
	| NOTOKEN
	;

Number
	: [0-9]+
	;

TypeName
	: NamespaceTypeName
	| NamespaceTypeName ',' AssemblyNameSpec
	;

NamespaceTypeName
	: NestedTypeName
	| NamespaceSpec '.' NestedTypeName
	;

NestedTypeName
	: IDENTIFIER
	| NestedTypeName '+' IDENTIFIER
	;

NamespaceSpec
	: IDENTIFIER
	| NamespaceSpec '.' IDENTIFIER
	;

AssemblyNameSpec
	: IDENTIFIER
	| IDENTIFIER ',' AssemblyProperties
	;

AssemblyProperties
	: AssemblyProperty
	| AssemblyProperties ',' AssemblyProperty
	;

AssemblyProperty
	: AssemblyPropertyName '=' AssemblyPropertyValue
	;
```

## Specifying Special Characters  
 In a type name, IDENTIFIER is any valid name determined by the rules of a language.  
  
 Use the backslash (\\) as an escape character to separate the following tokens when used as part of IDENTIFIER.  
  
|Token|Meaning|  
|-----------|-------------|  
|\\,|Assembly separator.|  
|\\+|Nested type separator.|  
|\\&|Reference type.|  
|\\*|Pointer type.|  
|\\[|Array dimension delimiter.|  
|\\]|Array dimension delimiter.|  
|\\.|Use the backslash before a period only if the period is used in an array specification. Periods in NamespaceSpec do not take the backslash.|  
|\\\|Backslash when needed as a string literal.|  
  
 Note that in all TypeSpec components except AssemblyNameSpec, spaces are relevant. In the AssemblyNameSpec, spaces before the ',' separator are relevant, but spaces after the ',' separator are ignored.  
  
 Reflection classes, such as <xref:System.Type.FullName%2A?displayProperty=nameWithType>, return the mangled name so that the returned name can be used in a call to <xref:System.Type.GetType%2A>, as in `MyType.GetType(myType.FullName)`.  
  
 For example, the fully qualified name for a type might be `Ozzy.OutBack.Kangaroo+Wallaby,MyAssembly`.  
  
 If the namespace were `Ozzy.Out+Back`, then the plus sign must be preceded by a backslash. Otherwise, the parser would interpret it as a nesting separator. Reflection emits this string as `Ozzy.Out\+Back.Kangaroo+Wallaby,MyAssembly`.  
  
## Specifying Assembly Names  
 The minimum information required in an assembly name specification is the textual name (IDENTIFIER) of the assembly. You can follow the IDENTIFIER by a comma-separated list of property/value pairs as described in the following table. IDENTIFIER naming should follow the rules for file naming. The IDENTIFIER is case-insensitive.  
  
|Property name|Description|Allowable values|  
|-------------------|-----------------|----------------------|  
|**Version**|Assembly version number|*Major.Minor.Build.Revision*, where *Major*, *Minor*, *Build*, and *Revision* are integers between 0 and 65535 inclusive.|  
|**PublicKey**|Full public key|String value of full public key in hexadecimal format. Specify a null reference (**Nothing** in Visual Basic) to explicitly indicate a private assembly.|  
|**PublicKeyToken**|Public key token (8-byte hash of the full public key)|String value of public key token in hexadecimal format. Specify a null reference (**Nothing** in Visual Basic) to explicitly indicate a private assembly.|  
|**Culture**|Assembly culture|Culture of the assembly in RFC-1766 format, or "neutral" for language-independent (nonsatellite) assemblies.|  
|**Custom**|Custom binary large object (BLOB). This is currently used only in assemblies generated by the [Native Image Generator (Ngen)](../../../docs/framework/tools/ngen-exe-native-image-generator.md).|Custom string used by the Native Image Generator tool to notify the assembly cache that the assembly being installed is a native image, and is therefore to be installed in the native image cache. Also called a zap string.|  
  
 The following example shows an **AssemblyName** for a simply named assembly with default culture.  
  
```csharp  
com.microsoft.crypto, Culture=""   
```  
  
 The following example shows a fully specified reference for a strongly named assembly with culture "en".  
  
```csharp  
com.microsoft.crypto, Culture=en, PublicKeyToken=a5d015c7d5a0b012,  
    Version=1.0.0.0   
```  
  
 The following examples each show a partially specified **AssemblyName**, which can be satisfied by either a strong or a simply named assembly.  
  
```csharp  
com.microsoft.crypto  
com.microsoft.crypto, Culture=""  
com.microsoft.crypto, Culture=en   
```  
  
 The following examples each show a partially specified **AssemblyName**, which must be satisfied by a simply named assembly.  
  
```csharp  
com.microsoft.crypto, Culture="", PublicKeyToken=null   
com.microsoft.crypto, Culture=en, PublicKeyToken=null  
```  
  
 The following examples each show a partially specified **AssemblyName**, which must be satisfied by a strongly named assembly.  
  
```csharp  
com.microsoft.crypto, Culture="", PublicKeyToken=a5d015c7d5a0b012  
com.microsoft.crypto, Culture=en, PublicKeyToken=a5d015c7d5a0b012,  
    Version=1.0.0.0  
```  
  
## Specifying Pointers  
 SimpleTypeSpec* represents an unmanaged pointer. For example, to get a pointer to type MyType, use `Type.GetType("MyType*")`. To get a pointer to a pointer to type MyType, use `Type.GetType("MyType**")`.  
  
## Specifying References  
 SimpleTypeSpec & represents a managed pointer or reference. For example, to get a reference to type MyType, use `Type.GetType("MyType &")`. Note that unlike pointers, references are limited to one level.  
  
## Specifying Arrays  
 In the BNF Grammar, ReflectionEmitDimension only applies to incomplete type definitions retrieved using <xref:System.Reflection.Emit.ModuleBuilder.GetType%2A?displayProperty=nameWithType>. Incomplete type definitions are <xref:System.Reflection.Emit.TypeBuilder> objects constructed using <xref:System.Reflection.Emit?displayProperty=nameWithType> but on which <xref:System.Reflection.Emit.TypeBuilder.CreateType%2A?displayProperty=nameWithType> has not been called. ReflectionDimension can be used to retrieve any type definition that has been completed, that is, a type that has been loaded.  
  
 Arrays are accessed in reflection by specifying the rank of the array:  
  
-   `Type.GetType("MyArray[]")` gets a single-dimension array with 0 lower bound.  
  
-   `Type.GetType("MyArray[*]")` gets a single-dimension array with unknown lower bound.  
  
-   `Type.GetType("MyArray[][]")` gets a two-dimensional array's array.  
  
-   `Type.GetType("MyArray[*,*]")` and `Type.GetType("MyArray[,]")` gets a rectangular two-dimensional array with unknown lower bounds.  
  
 Note that from a runtime point of view, `MyArray[] != MyArray[*]`, but for multidimensional arrays, the two notations are equivalent. That is, `Type.GetType("MyArray [,]") == Type.GetType("MyArray[*,*]")` evaluates to **true**.  
  
 For **ModuleBuilder.GetType**, `MyArray[0..5]` indicates a single-dimension array with size 6, lower bound 0. `MyArray[4…]` indicates a single-dimension array of unknown size and lower bound 4.  
  
## See Also  
 <xref:System.Reflection.AssemblyName>  
 <xref:System.Reflection.Emit.ModuleBuilder>  
 <xref:System.Reflection.Emit.TypeBuilder>  
 <xref:System.Type.FullName%2A?displayProperty=nameWithType>  
 <xref:System.Type.GetType%2A?displayProperty=nameWithType>  
 <xref:System.Type.AssemblyQualifiedName%2A?displayProperty=nameWithType>  
 [Viewing Type Information](../../../docs/framework/reflection-and-codedom/viewing-type-information.md)
