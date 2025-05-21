---
title: System.Resources.ResourceReader class
description: Learn about the System.Resources.ResourceReader class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Resources.ResourceReader class

[!INCLUDE [context](includes/context.md)]

[!INCLUDE [untrusted-data-class-note](./includes/untrusted-data-class-note.md)]

The <xref:System.Resources.ResourceReader> class provides a standard implementation of the <xref:System.Resources.IResourceReader> interface. A <xref:System.Resources.ResourceReader> instance represents either a standalone .resources file or a .resources file that is embedded in an assembly. It is used to enumerate the resources in a .resources file and retrieve its name/value pairs. It differs from the <xref:System.Resources.ResourceManager> class, which is used to retrieve specified named resources from a .resources file that is embedded in an assembly. The <xref:System.Resources.ResourceManager> class is used to retrieve resources whose names are known in advance, whereas the <xref:System.Resources.ResourceReader> class is useful for retrieving resources whose number or precise names are not known at compile time. For example, an application may use a resources file to store configuration information that is organized into sections and items in a section, where the number of sections or items in a section is not known in advance. Resources can then be named generically (such as `Section1`, `Section1Item1`, `Section1Item2`, and so on) and retrieved by using a <xref:System.Resources.ResourceReader> object.

> [!IMPORTANT]
> This type implements the <xref:System.IDisposable> interface. When you have finished using the type, you should dispose of it either directly or indirectly. To dispose of the type directly, call its <xref:System.IDisposable.Dispose%2A> method in a `try`/`catch` block. To dispose of it indirectly, use a language construct such as `using` (in C#) or `Using` (in Visual Basic). For more information, see the "Using an Object that Implements IDisposable" section in the <xref:System.IDisposable> interface documentation.

## Instantiate a ResourceReader object

A .resources file is a binary file that has been compiled from either a text file or an XML .resx file by [Resgen.exe (Resource File Generator)](../../framework/tools/resgen-exe-resource-file-generator.md). A <xref:System.Resources.ResourceReader> object can represent either a standalone .resources file or a .resources file that has been embedded in an assembly.

To instantiate a <xref:System.Resources.ResourceReader> object that reads from a standalone .resources file, use the <xref:System.Resources.ResourceReader> class constructor with either an input stream or a string that contains the .resources file name. The following example illustrates both approaches. The first instantiates a <xref:System.Resources.ResourceReader> object that represents a .resources file named `Resources1.resources` by using its file name. The second instantiates a <xref:System.Resources.ResourceReader> object that represents a .resources file named `Resources2.resources` by using a stream created from the file.

:::code language="csharp" source="./snippets/System.Resources/ResourceReader/Overview/csharp/ctor1.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Resources/ResourceReader/Overview/vb/ctor1.vb" id="Snippet2":::

To create a <xref:System.Resources.ResourceReader> object that represents an embedded .resources file, instantiate an <xref:System.Reflection.Assembly> object from the assembly in which the .resources file is embedded. Its <xref:System.Reflection.Assembly.GetManifestResourceStream%2A?displayProperty=nameWithType> method returns a <xref:System.IO.Stream> object that can be passed to the <xref:System.Resources.ResourceReader.%23ctor%28System.IO.Stream%29> constructor. The following example instantiates a <xref:System.Resources.ResourceReader> object that represents an embedded .resources file.

:::code language="csharp" source="./snippets/System.Resources/ResourceReader/Overview/csharp/ctor1.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Resources/ResourceReader/Overview/vb/ctor1.vb" id="Snippet3":::

## Enumerate a ResourceReader object's resources

To enumerate the resources in a .resources file, you call the <xref:System.Resources.ResourceReader.GetEnumerator%2A> method, which returns an <xref:System.Collections.IDictionaryEnumerator?displayProperty=nameWithType> object. You call the `IDictionaryEnumerator.MoveNext` method to move from one resource to the next. The method returns `false` when all the resources in the .resources file have been enumerated.

> [!NOTE]
> Although the <xref:System.Resources.ResourceReader> class implements the <xref:System.Collections.IEnumerable> interface and the <xref:System.Collections.IEnumerable.GetEnumerator%2A?displayProperty=nameWithType> method, the <xref:System.Resources.ResourceReader.GetEnumerator%2A?displayProperty=nameWithType> method does not provide the <xref:System.Collections.IEnumerable.GetEnumerator%2A?displayProperty=nameWithType> implementation. Instead, the <xref:System.Resources.ResourceReader.GetEnumerator%2A?displayProperty=nameWithType> method returns an <xref:System.Collections.IDictionaryEnumerator> interface object that provides access to each resource's name/value pair.

You can retrieve the individual resources in the collection in two ways:

- You can iterate each resource in the <xref:System.Collections.IDictionaryEnumerator?displayProperty=nameWithType> collection and use <xref:System.Collections.IDictionaryEnumerator?displayProperty=nameWithType> properties to retrieve the resource name and value. We recommend this technique when all the resources are of the same type, or you know the data type of each resource.

- You can retrieve the name of each resource when you iterate the <xref:System.Collections.IDictionaryEnumerator?displayProperty=nameWithType> collection and call the <xref:System.Resources.ResourceReader.GetResourceData%2A> method to retrieve the resource's data. We recommend this approach when you do not know the data type of each resource or if the previous approach throws exceptions.

### Retrieve resources by using IDictionaryEnumerator properties

The first method of enumerating the resources in a .resources file involves directly retrieving each resource's name/value pair. After you call the `IDictionaryEnumerator.MoveNext` method to move to each resource in the collection, you can retrieve the resource name from the <xref:System.Collections.IDictionaryEnumerator.Key?displayProperty=nameWithType> property and the resource data from the <xref:System.Collections.IDictionaryEnumerator.Value?displayProperty=nameWithType> property.

The following example shows how to retrieve the name and value of each resource in a .resources file by using the <xref:System.Collections.IDictionaryEnumerator.Key%2A?displayProperty=nameWithType> and <xref:System.Collections.IDictionaryEnumerator.Value%2A?displayProperty=nameWithType> properties. To run the example, create the following text file named ApplicationResources.txt to define string resources.

```
Title="Contact Information"
Label1="First Name:"
Label2="Middle Name:"
Label3="Last Name:"
Label4="SSN:"
Label5="Street Address:"
Label6="City:"
Label7="State:"
Label8="Zip Code:"
Label9="Home Phone:"
Label10="Business Phone:"
Label11="Mobile Phone:"
Label12="Other Phone:"
Label13="Fax:"
Label14="Email Address:"
Label15="Alternate Email Address:"
```

You can then convert the text resource file to a binary file named ApplicationResources.resources by using the following command:

`resgen ApplicationResources.txt`

The following example then uses the <xref:System.Resources.ResourceReader> class to enumerate each resource in the standalone binary .resources file and to display its key name and corresponding value.

:::code language="csharp" source="./snippets/System.Resources/ResourceReader/Overview/csharp/class1.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Resources/ResourceReader/Overview/vb/class1.vb" id="Snippet1":::

The attempt to retrieve resource data from the <xref:System.Collections.IDictionaryEnumerator.Value?displayProperty=nameWithType> property can throw the following exceptions:

- A <xref:System.FormatException> if the data is not in the expected format.
- A <xref:System.IO.FileNotFoundException> if the assembly that contains the type to which the data belongs cannot be found.
- A <xref:System.TypeLoadException> if the type to which the data belongs cannot be cannot be found.

Typically, these exceptions are thrown if the .resources file has been modified manually, if the assembly in which a type is defined has either not been included with an application or has been inadvertently deleted, or if the assembly is an older version that predates a type. If one of these exceptions is thrown, you can retrieve resources by enumerating each resource and calling the <xref:System.Resources.ResourceReader.GetResourceData%2A> method, as the following section shows. This approach provides you with some information about the data type that the <xref:System.Collections.IDictionaryEnumerator.Value?displayProperty=nameWithType> property attempted to return.

### Retrieve resources by name with GetResourceData

The second approach to enumerating resources in a .resources file also involves navigating through the resources in the file by calling the `IDictionaryEnumerator.MoveNext` method. For each resource, you retrieve the resource's name from the <xref:System.Collections.IDictionaryEnumerator.Key?displayProperty=nameWithType> property, which is then passed to the <xref:System.Resources.ResourceReader.GetResourceData%28System.String%2CSystem.String%40%2CSystem.Byte%5B%5D%40%29> method to retrieve the resource's data. This is returned as a byte array in the `resourceData` argument.

This approach is more awkward than retrieving the resource name and value from the <xref:System.Collections.IDictionaryEnumerator.Key%2A?displayProperty=nameWithType> and <xref:System.Collections.IDictionaryEnumerator.Value%2A?displayProperty=nameWithType> properties, because it returns the actual bytes that form the resource value. However, if the attempt to retrieve the resource throws an exception, the <xref:System.Resources.ResourceReader.GetResourceData%2A> method can help identify the source of the exception by supplying information about the resource's data type. For more information about the string that indicates the resource's data type, see <xref:System.Resources.ResourceReader.GetResourceData%2A>.

The following example illustrates how to use this approach to retrieve resources and to handle any exceptions that are thrown. It programmatically creates a binary .resources file that contains four strings, one Boolean, one integer, and one bitmap. To run the example, do the following:

1. Compile and execute the following source code, which creates a .resources file named ContactResources.resources.

   :::code language="csharp" source="./snippets/System.Resources/ResourceReader/Overview/csharp/createresourceex1.cs" id="Snippet5":::

   The source code file is named CreateResources.cs. You can compile it in C# by using the following command:

    ```
    csc CreateResources.cs /r:library.dll
    ```

2. Compile and run the following code to enumerate the resources in the ContactResources.resources file.

   :::code language="csharp" source="./snippets/System.Resources/ResourceReader/Overview/csharp/readresourceex1.cs" id="Snippet6":::

   After modifying the source code (for example, by deliberately throwing a <xref:System.FormatException> at the end of the `try` block), you can run the example to see how calls to <xref:System.Resources.ResourceReader.GetResourceData%2A> enable you to retrieve or recreate some resource information.
