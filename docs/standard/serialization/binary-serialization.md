---
title: "Binary serialization"
ms.date: "08/11/2017"
ms.prod: ".net"
ms.topic: "article"
helpviewer_keywords: 
  - "binary serialization"
  - "serialization, about serialization"
  - "deserialization"
  - "binary serialization, about serialization"
  - "binary serialization, .net core serialization"
  - "serialization, cross-framework"
ms.assetid: 2b1ea3be-1152-4032-b2b3-07794054c405
caps.latest.revision: 5
author: "ViktorHofer"
ms.author: "mairaw"
---
# Binary serialization

Serialization can be defined as the process of storing the state of an object to a storage medium. During this process, the public and private fields of the object and the name of the class, including the assembly containing the class, are converted to a stream of bytes, which is then written to a data stream. When the object is subsequently deserialized, an exact clone of the original object is created.

When implementing a serialization mechanism in an object-oriented environment, you have to make a number of tradeoffs between ease of use and flexibility. The process can be automated to a large extent, provided you are given sufficient control over the process. For example, situations may arise where simple binary serialization is not sufficient, or there might be a specific reason to decide which fields in a class need to be serialized. The following sections examine the robust serialization mechanism provided with .NET and highlight a number of important features that allow you to customize the process to meet your needs.

> [!NOTE]
> The state of a UTF-8 or UTF-7 encoded object is not preserved if the object is serialized and deserialized using different .NET Framework versions.

[!INCLUDE [binary-serialization-warning](../../../includes/binary-serialization-warning.md)]

As the nature of binary serialization allows the modification of private members inside an object and therefore changing the state of it, other serialization frameworks like JSON.NET which operate on the public API surface are recommended.

## Binary serialization in .NET Core

.NET Core supports binary serialization with a subset of types. You can see the list of supported types in the [Serializable types section](#serializable-types). The defined set of types are guaranteed to be serializable between .NET Framework 4.5.1 and later versions and .NET Core 2.0 and later versions. Other .NET implementations, such as Mono, aren't officially supported but should also be working.

### Serializable types

- <xref:System.AggregateException?displayProperty=fullName>   
- <xref:System.Array?displayProperty=fullName>   
- <xref:System.ArraySegment%601?displayProperty=fullName>   
- <xref:System.Attribute?displayProperty=fullName>   
- <xref:System.Boolean?displayProperty=fullName>   
- <xref:System.Byte?displayProperty=fullName>   
- <xref:System.Char?displayProperty=fullName>   
- <xref:System.Collections.ArrayList?displayProperty=fullName>   
- <xref:System.Collections.BitArray?displayProperty=fullName>   
- <xref:System.Collections.Comparer?displayProperty=fullName>   
- <xref:System.Collections.DictionaryEntry?displayProperty=fullName>   
- <xref:System.Collections.Generic.Comparer%601?displayProperty=fullName>   
- <xref:System.Collections.Generic.Dictionary%602?displayProperty=fullName>   
- <xref:System.Collections.Generic.EqualityComparer%601?displayProperty=fullName>   
- <xref:System.Collections.Generic.HashSet%601?displayProperty=fullName>   
- <xref:System.Collections.Generic.KeyValuePair%602?displayProperty=fullName>   
- <xref:System.Collections.Generic.LinkedList%601?displayProperty=fullName>   
- <xref:System.Collections.Generic.List%601?displayProperty=fullName>   
- <xref:System.Collections.Generic.Queue%601?displayProperty=fullName>   
- <xref:System.Collections.Generic.SortedDictionary%602?displayProperty=fullName>   
- <xref:System.Collections.Generic.SortedList%602?displayProperty=fullName>   
- <xref:System.Collections.Generic.SortedSet%601?displayProperty=fullName>   
- <xref:System.Collections.Generic.Stack%601?displayProperty=fullName>   
- <xref:System.Collections.Hashtable?displayProperty=fullName>   
- <xref:System.Collections.ObjectModel.Collection%601?displayProperty=fullName>   
- <xref:System.Collections.ObjectModel.KeyedCollection%602?displayProperty=fullName>   
- <xref:System.Collections.ObjectModel.ObservableCollection%601?displayProperty=fullName>   
- <xref:System.Collections.ObjectModel.ReadOnlyCollection%601?displayProperty=fullName>   
- <xref:System.Collections.ObjectModel.ReadOnlyDictionary%602?displayProperty=fullName>   
- <xref:System.Collections.ObjectModel.ReadOnlyObservableCollection%601?displayProperty=fullName>   
- <xref:System.Collections.Queue?displayProperty=fullName>   
- <xref:System.Collections.SortedList?displayProperty=fullName>   
- <xref:System.Collections.Specialized.HybridDictionary?displayProperty=fullName>   
- <xref:System.Collections.Specialized.ListDictionary?displayProperty=fullName>   
- <xref:System.Collections.Specialized.OrderedDictionary?displayProperty=fullName>   
- <xref:System.Collections.Specialized.StringCollection?displayProperty=fullName>   
- <xref:System.Collections.Specialized.StringDictionary?displayProperty=fullName>   
- <xref:System.Collections.Stack?displayProperty=fullName>   
- <xref:System.ComponentModel.BindingList%601?displayProperty=fullName>   
- <xref:System.Data.DataSet?displayProperty=fullName>   
- <xref:System.Data.DataTable?displayProperty=fullName>   
- <xref:System.Data.PropertyCollection?displayProperty=fullName>   
- <xref:System.Data.SqlTypes.SqlBoolean?displayProperty=fullName>   
- <xref:System.Data.SqlTypes.SqlByte?displayProperty=fullName>   
- <xref:System.Data.SqlTypes.SqlDateTime?displayProperty=fullName>   
- <xref:System.Data.SqlTypes.SqlDouble?displayProperty=fullName>   
- <xref:System.Data.SqlTypes.SqlGuid?displayProperty=fullName>   
- <xref:System.Data.SqlTypes.SqlInt16?displayProperty=fullName>   
- <xref:System.Data.SqlTypes.SqlInt32?displayProperty=fullName>   
- <xref:System.Data.SqlTypes.SqlInt64?displayProperty=fullName>   
- <xref:System.Data.SqlTypes.SqlString?displayProperty=fullName>   
- <xref:System.DateTime?displayProperty=fullName>   
- <xref:System.DateTimeOffset?displayProperty=fullName>   
- <xref:System.Decimal?displayProperty=fullName>   
- <xref:System.Double?displayProperty=fullName>   
- <xref:System.Drawing.Color?displayProperty=fullName>   
- <xref:System.Drawing.Point?displayProperty=fullName>   
- <xref:System.Drawing.PointF?displayProperty=fullName>   
- <xref:System.Drawing.Rectangle?displayProperty=fullName>   
- <xref:System.Drawing.RectangleF?displayProperty=fullName>   
- <xref:System.Drawing.Size?displayProperty=fullName>   
- <xref:System.Drawing.SizeF?displayProperty=fullName>   
- <xref:System.Enum?displayProperty=fullName>   
- <xref:System.Exception?displayProperty=fullName>   
- <xref:System.Globalization.CompareInfo?displayProperty=fullName>   
- <xref:System.Globalization.SortVersion?displayProperty=fullName>   
- <xref:System.Guid?displayProperty=fullName>   
- <xref:System.Int16?displayProperty=fullName>   
- <xref:System.Int32?displayProperty=fullName>   
- <xref:System.Int64?displayProperty=fullName>   
- <xref:System.IntPtr?displayProperty=fullName>   
- <xref:System.Net.Cookie?displayProperty=fullName>   
- <xref:System.Net.CookieCollection?displayProperty=fullName>   
- <xref:System.Net.CookieContainer?displayProperty=fullName>   
- <xref:System.Nullable%601?displayProperty=fullName>   
- <xref:System.Numerics.BigInteger?displayProperty=fullName>   
- <xref:System.Numerics.Complex?displayProperty=fullName>   
- <xref:System.Object?displayProperty=fullName>   
- <xref:System.SByte?displayProperty=fullName>   
- <xref:System.Single?displayProperty=fullName>   
- <xref:System.String?displayProperty=fullName>   
- <xref:System.StringComparer?displayProperty=fullName>   
- <xref:System.Text.StringBuilder?displayProperty=fullName>   
- <xref:System.TimeSpan?displayProperty=fullName>   
- <xref:System.TimeZoneInfo?displayProperty=fullName>   
- <xref:System.TimeZoneInfo.AdjustmentRule?displayProperty=fullName>   
- <xref:System.Tuple?displayProperty=fullName>   
- <xref:System.UInt16?displayProperty=fullName>   
- <xref:System.UInt32?displayProperty=fullName>   
- <xref:System.UInt64?displayProperty=fullName>   
- <xref:System.UIntPtr?displayProperty=fullName>   
- <xref:System.Uri?displayProperty=fullName>   
- <xref:System.ValueTuple?displayProperty=fullName> (not serializable in .NET Framework 4.7 and earlier versions)  
- <xref:System.ValueType?displayProperty=fullName>   
- <xref:System.Version?displayProperty=fullName>   
- <xref:System.WeakReference?displayProperty=fullName>   
- <xref:System.WeakReference%601?displayProperty=fullName>   

## In this section

 [Serialization Concepts](../../../docs/standard/serialization/serialization-concepts.md)  
 Discusses two scenarios where serialization is useful: when persisting data to storage and when passing objects across application domains.  
  
 [Basic Serialization](../../../docs/standard/serialization/basic-serialization.md)  
 Describes how to use the binary and SOAP formatters to serialize objects.  
  
 [Selective Serialization](../../../docs/standard/serialization/selective-serialization.md)  
 Describes how to prevent some members of a class from being serialized.  
  
 [Custom Serialization](../../../docs/standard/serialization/custom-serialization.md)  
 Describes how to customize serialization for a class by using the <xref:System.Runtime.Serialization.ISerializable> interface.  
  
 [Steps in the Serialization Process](../../../docs/standard/serialization/steps-in-the-serialization-process.md)  
 Describes the course of action serialization takes when the <xref:System.Runtime.Serialization.Formatter.Serialize%2A> method is called on a formatter.  
  
 [Version Tolerant Serialization](../../../docs/standard/serialization/version-tolerant-serialization.md)  
 Explains how to create serializable types that can be modified over time without causing applications to throw exceptions.  
  
 [Serialization Guidelines](../../../docs/standard/serialization/serialization-guidelines.md)  
 Provides some general guidelines for deciding when to serialize an object.  
  
## Reference  
 <xref:System.Runtime.Serialization>  
 Contains classes that can be used for serializing and deserializing objects.  
  
## Related sections  
 [XML and SOAP Serialization](../../../docs/standard/serialization/xml-and-soap-serialization.md)  
 Describes the XML serialization mechanism that is included with the common language runtime.  
  
 [Security and Serialization](../../../docs/framework/misc/security-and-serialization.md)  
 Describes the secure coding guidelines to follow when writing code that performs serialization.  
  
 [Remote Objects](http://msdn.microsoft.com/en-us/515686e6-0a8d-42f7-8188-73abede57c58)  
 Describes the various communications methods available in the .NET Framework for remote communications.  
  
 [XML Web Services Created Using ASP.NET and XML Web Service Clients](http://msdn.microsoft.com/en-us/1e64af78-d705-4384-b08d-591a45f4379c)  
 Provides topics that describe and explain how to program XML Web services created using ASP.NET.
