---
title: "Attributes (C#)"
ms.date: 04/26/2018
---
# Attributes (C#)

Attributes provide a powerful method of associating metadata, or declarative information, with code (assemblies, types, methods, properties, and so forth). After an attribute is associated with a program entity, the attribute can be queried at run time by using a technique called *reflection*. For more information, see [Reflection (C#)](../reflection.md).

Attributes have the following properties:

- Attributes add metadata to your program. *Metadata* is information about the types defined in a program. All .NET assemblies contain a specified set of metadata that describes the types and type members defined in the assembly. You can add custom attributes to specify any additional information that is required. For more information, see, [Creating Custom Attributes (C#)](creating-custom-attributes.md).
- You can apply one or more attributes to entire assemblies, modules, or smaller program elements such as classes and properties.
- Attributes can accept arguments in the same way as methods and properties.
- Your program can examine its own metadata or the metadata in other programs by using reflection. For more information, see [Accessing Attributes by Using Reflection (C#)](accessing-attributes-by-using-reflection.md).

## Using attributes

Attributes can be placed on most any declaration, though a specific attribute might restrict the types of declarations on which it is valid. In C#, you specify an attribute by placing the name of the attribute enclosed in square brackets ([]) above the declaration of the entity to which it applies.

In this example, the <xref:System.SerializableAttribute> attribute is used to apply a specific characteristic to a class:

[!code-csharp[Using the serializable attribute](../../../../../samples/snippets/csharp/attributes/AttributesOverview.cs#1)]

A method with the attribute <xref:System.Runtime.InteropServices.DllImportAttribute> is declared like the following example:

[!code-csharp[Declaring a method to import from an external library](../../../../../samples/snippets/csharp/attributes/AttributesOverview.cs#2)]

More than one attribute can be placed on a declaration as the following example shows:

[!code-csharp[Including the interop namespace](../../../../../samples/snippets/csharp/attributes/AttributesOverview.cs#3)]
[!code-csharp[Declaring two way marshaling for arguments](../../../../../samples/snippets/csharp/attributes/AttributesOverview.cs#4)]

Some attributes can be specified more than once for a given entity. An example of such a multiuse attribute is <xref:System.Diagnostics.ConditionalAttribute>:

[!code-csharp[Using the conditional attribute](../../../../../samples/snippets/csharp/attributes/AttributesOverview.cs#5)]

> [!NOTE]
> By convention, all attribute names end with the word "Attribute" to distinguish them from other items in the .NET libraries. However, you do not need to specify the attribute suffix when using attributes in code. For example, `[DllImport]` is equivalent to `[DllImportAttribute]`, but `DllImportAttribute` is the attribute's actual name in the .NET Framework Class Library.

### Attribute parameters

Many attributes have parameters, which can be positional, unnamed, or named. Any positional parameters must be specified in a certain order and cannot be omitted. Named parameters are optional and can be specified in any order. Positional parameters are specified first. For example, these three attributes are equivalent:

```csharp
[DllImport("user32.dll")]
[DllImport("user32.dll", SetLastError=false, ExactSpelling=false)]
[DllImport("user32.dll", ExactSpelling=false, SetLastError=false)]
```

The first parameter, the DLL name, is positional and always comes first; the others are named. In this case, both named parameters default to false, so they can be omitted. Positional parameters correspond to the parameters of the attribute constructor. Named or optional parameters correspond to either properties or fields of the attribute. Refer to the individual attribute's documentation for information on default parameter values.

### Attribute targets

The *target* of an attribute is the entity which the attribute applies to. For example, an attribute may apply to a class, a particular method, or an entire assembly. By default, an attribute applies to the element that follows it. But you can also explicitly identify, for example, whether an attribute is applied to a method, or to its parameter, or to its return value.

To explicitly identify an attribute target, use the following syntax:

```csharp
[target : attribute-list]
```

The list of possible `target` values is shown in the following table.

|Target value|Applies to|
|------------------|----------------|
|`assembly`|Entire assembly|
|`module`|Current assembly module|
|`field`|Field in a class or a struct|
|`event`|Event|
|`method`|Method or `get` and `set` property accessors|
|`param`|Method parameters or `set` property accessor parameters|
|`property`|Property|
|`return`|Return value of a method, property indexer, or `get` property accessor|
|`type`|Struct, class, interface, enum, or delegate|

You would specify the `field` target value to apply an attribute to the backing field created for an [auto-implemented property](../../../properties.md).

The following example shows how to apply attributes to assemblies and modules. For more information, see [Common Attributes (C#)](common-attributes.md).

```csharp
using System;
using System.Reflection;
[assembly: AssemblyTitleAttribute("Production assembly 4")]
[module: CLSCompliant(true)]
```

The following example shows how to apply attributes to methods, method parameters, and method return values in C#.

[!code-csharp[Applying attributes to different code elements](../../../../../samples/snippets/csharp/attributes/AttributesOverview.cs#6)]

> [!NOTE]
> Regardless of the targets on which `ValidatedContract` is defined to be valid, the `return` target has to be specified, even if `ValidatedContract` were defined to apply only to return values. In other words, the compiler will not use `AttributeUsage` information to resolve ambiguous attribute targets. For more information, see [AttributeUsage (C#)](attributeusage.md).

## Common uses for attributes

The following list includes a few of the common uses of attributes in code:

- Marking methods using the `WebMethod` attribute in Web services to indicate that the method should be callable over the SOAP protocol. For more information, see <xref:System.Web.Services.WebMethodAttribute>.
- Describing how to marshal method parameters when interoperating with native code. For more information, see <xref:System.Runtime.InteropServices.MarshalAsAttribute>.
- Describing the COM properties for classes, methods, and interfaces.
- Calling unmanaged code using the <xref:System.Runtime.InteropServices.DllImportAttribute> class.
- Describing your assembly in terms of title, version, description, or trademark.
- Describing which members of a class to serialize for persistence.
- Describing how to map between class members and XML nodes for XML serialization.
- Describing the security requirements for methods.
- Specifying characteristics used to enforce security.
- Controlling optimizations by the just-in-time (JIT) compiler so the code remains easy to debug.
- Obtaining information about the caller to a method.

## Related sections

For more information, see:

- [Creating Custom Attributes (C#)](creating-custom-attributes.md)  
- [Accessing Attributes by Using Reflection (C#)](accessing-attributes-by-using-reflection.md)  
- [How to: Create a C/C++ Union by Using Attributes (C#)](how-to-create-a-c-cpp-union-by-using-attributes.md)  
- [Common Attributes (C#)](common-attributes.md)  
- [Caller Information (C#)](../caller-information.md)  

## See also

- [C# Programming Guide](../../index.md)
- [Reflection (C#)](../reflection.md)
- [Attributes](../../../../standard/attributes/index.md)
- [Using Attributes in C#](../../../tutorials/attributes.md)
