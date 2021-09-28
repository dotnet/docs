---
title: How to build LINQ to XML examples
description: The C# and Visual Basic code in this documentation uses classes and types from various namespaces. To compile and run the code you must provide appropriate directives and statements to access the namespaces.
ms.date: 07/20/2015
ms.topic: how-to
---

# How to build LINQ to XML examples

The snippets and examples in this documentation use classes and types from various namespaces. When compiling C# code you need to supply appropriate `using` directives, and when compiling Visual Basic code you need to supply appropriate `Imports` statements.

## Example

The following code contains the `using` directives that the C# examples require to build and run. Not all `using` directives are required for every example.

```csharp
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;
using System.Threading;
using System.Reflection;
using System.IO.Packaging;
```

The following code contains the `Imports` statements that the Visual Basic examples require to build and run. Not all `Imports` statements are required for every example.

```vb
Imports System.Diagnostics
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Text
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports System.IO
Imports System.Threading
Imports System.Reflection
Imports System.IO.Packaging
```

## See also

- [LINQ to XML overview](linq-xml-overview.md)
