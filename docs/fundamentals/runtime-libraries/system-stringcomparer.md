---
title: System.StringComparer class
description: Learn about the System.StringComparer class.
ms.date: 12/31/2023
ms.topic: article
---
# System.StringComparer class

[!INCLUDE [context](includes/context.md)]

An object derived from the <xref:System.StringComparer> class embodies string-based comparison, equality, and hash code operations that take into account both case and culture-specific comparison rules. You can use the <xref:System.StringComparer> class to create a type-specific comparison to sort the elements in a generic collection. Classes such as <xref:System.Collections.Hashtable>, <xref:System.Collections.Generic.Dictionary%602>, <xref:System.Collections.SortedList>, and <xref:System.Collections.Generic.SortedList%602> use the <xref:System.StringComparer> class for sorting purposes.

A comparison operation that is represented by the <xref:System.StringComparer> class is defined to be either case-sensitive or case-insensitive, and use either word (culture-sensitive) or ordinal (culture-insensitive) comparison rules. For more information about word and ordinal comparison rules, see <xref:System.Globalization.CompareOptions?displayProperty=nameWithType>.

> [!NOTE]
> You can download the [Default Unicode Collation Element Table](https://www.unicode.org/Public/UCA/latest/allkeys.txt), the latest version of the sort weight table. The specific version of the sort weight table depends on the version of the [International Components for Unicode](https://icu.unicode.org/) libraries installed on the system. For information on ICU versions and the Unicode versions that they implement, see [Downloading ICU](https://icu.unicode.org/download).
>
> For .NET Framework on Windows, you can download the [Sorting Weight Tables](https://www.microsoft.com/download/details.aspx?id=10921), a set of text files that contain information on the character weights used in sorting and comparison operations.

## Implemented properties

You might be confused about how to use the <xref:System.StringComparer> class properties because of a seeming contradiction. The <xref:System.StringComparer> class is declared `abstract` (`MustInherit` in Visual Basic), which means its members can be invoked only on an object of a class derived from the <xref:System.StringComparer> class. The contradiction is that each property of the <xref:System.StringComparer> class is declared `static` (`Shared` in Visual Basic), which means the property can be invoked without first creating a derived class.

You can call a <xref:System.StringComparer> property directly because each property actually returns an instance of an anonymous class that is derived from the <xref:System.StringComparer> class. Consequently, the type of each property value is <xref:System.StringComparer>, which is the base class of the anonymous class, not the type of the anonymous class itself. Each <xref:System.StringComparer> class property returns a <xref:System.StringComparer> object that supports predefined case and comparison rules.
