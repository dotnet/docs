# <xref:System.Globalization.SortVersion> class

[!INCLUDE [context](includes/context.md)]

## Sorting and string comparison in .NET Framework

Through .NET Framework 4, each version of .NET Framework included tables that contained sort weights and data on string normalization and that are based on a particular version of Unicode. In .NET Framework 4.5 and later versions, the presence of these tables depends on the operating system:

- On Windows 7 and previous versions, the tables continue to be used for comparing and ordering strings.
- On Windows 8, .NET Framework delegates string comparison and ordering operations to the operating system.

Consequently, the result of a string comparison can depend not only on the .NET Framework version, but also on the operating system version, as the following table shows. Note that this list of supported Unicode versions applies to character comparison and sorting only; it does not apply to classification of Unicode characters by category.

| .NET Framework version | Operating system             | Unicode version |
|------------------------|------------------------------|-----------------|
| 4                      | All operating systems        | Unicode 5.0     |
| 4.5 and later versions | Windows 7                    | Unicode 5.0     |
| 4.5 and later versions | Windows 8 and later versions | Unicode 6.0     |

On Windows 8, because the version of Unicode used in string comparison and ordering depends on the version of the operating system, the results of string comparison may differ even for applications that run on a specific version of .NET Framework.

## Sorting and string comparison in .NET Core

All versions of .NET (Core) rely on the underlying operating system when performing string comparisons. Therefore, the results of a string comparison or the order in which strings are sorted depends on the version of Unicode used by the operating system when performing the comparison. On Linux, macOS, and Windows 10 and later versions, [International Components for Unicode](https://icu.unicode.org/) libraries provide the implementation for comparison and sorting APIs.

## Use the SortVersion class

The <xref:System.Globalization.SortVersion> class provides information about the Unicode version used by .NET for string comparison and ordering. It enables developers to write applications that can detect and successfully handle changes in the version of Unicode that is used to compare and sort an application's strings.

You can instantiate a <xref:System.Globalization.SortVersion> object in two ways:

- By calling the <xref:System.Globalization.SortVersion.%23ctor%2A> constructor, which instantiates a new <xref:System.Globalization.SortVersion> object based on a version number and sort ID. This constructor is most useful when recreating a <xref:System.Globalization.SortVersion> object from saved data.
- By retrieving the value of the <xref:System.Globalization.CompareInfo.Version%2A?displayProperty=nameWithType> property. This property provides information about the Unicode version used by the .NET implementation on which the application is running.

The <xref:System.Globalization.SortVersion> class has two properties, <xref:System.Globalization.SortVersion.FullVersion%2A> and <xref:System.Globalization.SortVersion.SortId%2A>, that indicate the Unicode version and the specific culture used for string comparison. The <xref:System.Globalization.SortVersion.FullVersion%2A> property is an arbitrary numeric value that reflects the Unicode version used for string comparison, and the <xref:System.Globalization.SortVersion.SortId%2A> property is an arbitrary <xref:System.Guid> that reflects the culture whose conventions are used for string comparison. The values of these two properties are important only when you compare two <xref:System.Globalization.SortVersion> objects by using the <xref:System.Globalization.SortVersion.Equals%2A> method, the <xref:System.Globalization.SortVersion.op_Equality%2A> operator, or the <xref:System.Globalization.SortVersion.op_Inequality%2A> operator.

You typically use a <xref:System.Globalization.SortVersion> object when saving or retrieving some form of culture-sensitive, ordered string data, such as indexes or the literal strings themselves. This requires the following steps:

1. When the ordered string data is saved, the <xref:System.Globalization.SortVersion.FullVersion%2A> and <xref:System.Globalization.SortVersion.SortId%2A> property values are also saved.

2. When the ordered string data is retrieved, you can recreate the <xref:System.Globalization.SortVersion> object used for ordering the strings by calling the <xref:System.Globalization.SortVersion.%23ctor%2A> constructor.

3. This newly instantiated <xref:System.Globalization.SortVersion> object is compared with a <xref:System.Globalization.SortVersion> object that reflects the culture whose conventions are used to order the string data.

4. If the two <xref:System.Globalization.SortVersion> objects are not equal, the string data must be reordered.

The example provides an illustration.

## Examples

The following example contains a portion of the source code from an application that uses the <xref:System.Globalization.SortVersion> class to ensure that the native names of <xref:System.Globalization.RegionInfo> objects are ordered appropriately for the current system and current culture. It uses the <xref:System.IO.BinaryReader> and <xref:System.IO.BinaryWriter> objects to store and retrieve ordered data from a data file named `Regions.dat` rather than retrieving and ordering data each time the application is run. The example first checks to determine whether the data file exists. If it does not, it creates the data and sets the `reindex` flag, which indicates that the data must be resorted and saved again. Otherwise, it retrieves the data and compares the saved <xref:System.Globalization.SortVersion> object with the <xref:System.Globalization.SortVersion> object for the current culture on the current system. If they are not equal, or if the `reindex` flag had been set previously, it resorts the <xref:System.Globalization.RegionInfo> data.

:::code language="csharp" source="~/snippets/csharp/System.Globalization/SortVersion/Overview/example1.cs" id="Snippet1":::
:::code language="vb" source="~/snippets/visualbasic/VS_Snippets_CLR_System/system.globalization.sortversion/vb/example1.vb" id="Snippet1":::
