---
title: "Binary Serialization in .NET Core"
ms.custom: ""
ms.date: "05/08/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
helpviewer_keywords: 
  - "binary serialization, .net core serialization"
  - "serialization, cross framework"
ms.assetid: ""
caps.latest.revision: 1
author: "ViktorHofer"
ms.author: "ViktorHofer"
manager: "ViktorHofer"
---
# Binary Serialization in .NET Core
 .NET Core supports binary serialization with a subset of types. Please find the list of supported types below. The defined set of types are guaranteed to be serializable between .NET Framework (v4.5.1 and above) and .NET Core (v2.0 and above). Other frameworks like Mono aren't officially supported but should also be working.

## Serializable types
```
System.AdjustmentRule
System.AggregateException
System.Array
System.ArraySegment<T>
System.Attribute
System.Boolean
System.Byte
System.Char
System.Collections.ArrayList
System.Collections.BitArray
System.Collections.Comparer
System.Collections.DictionaryEntry
System.Collections.DictionaryNode
System.Collections.Generic.ByteEqualityComparer
System.Collections.Generic.Comparer<T>
System.Collections.Generic.Dictionary<TKey, TValue>
System.Collections.Generic.EqualityComparer<T>
System.Collections.Generic.HashSet<T>
System.Collections.Generic.KeyValuePair<TKey, TValue>
System.Collections.Generic.LinkedList<T>
System.Collections.Generic.List<T>
System.Collections.Generic.Queue<T>
System.Collections.Generic.SortedDictionary<TKey, TValue>
System.Collections.Generic.SortedList<TKey, TValue>
System.Collections.Generic.SortedSet<T>
System.Collections.Generic.Stack<T>
System.Collections.Generic.TreeSet<T>
System.Collections.Hashtable
System.Collections.ObjectModel.Collection<T>
System.Collections.ObjectModel.KeyedCollection<TKey, TItem>
System.Collections.ObjectModel.ObservableCollection<T>
System.Collections.ObjectModel.ReadOnlyCollection<T>
System.Collections.ObjectModel.ReadOnlyDictionary<TKey, TValue>
System.Collections.ObjectModel.ReadOnlyObservableCollection<T>
System.Collections.Queue
System.Collections.SortedList
System.Collections.Specialized.HybridDictionary
System.Collections.Specialized.ListDictionary
System.Collections.Specialized.OrderedDictionary
System.Collections.Specialized.StringCollection
System.Collections.Specialized.StringDictionary
System.Collections.Stack
System.ComponentModel.BindingList<T>
System.Data.DataSet
System.Data.DataTable
System.Data.PropertyCollection
System.Data.SqlTypes.SqlBoolean
System.Data.SqlTypes.SqlByte
System.Data.SqlTypes.SqlDateTime
System.Data.SqlTypes.SqlDouble
System.Data.SqlTypes.SqlGuid
System.Data.SqlTypes.SqlInt16
System.Data.SqlTypes.SqlInt32
System.Data.SqlTypes.SqlInt64
System.Data.SqlTypes.SqlString
System.DateTime
System.DateTimeOffset
System.Decimal
System.Double
System.Drawing.Color
System.Drawing.Point
System.Drawing.PointF
System.Drawing.Rectangle
System.Drawing.RectangleF
System.Drawing.Size
System.Drawing.SizeF
System.Enum
System.Exception
System.Globalization.CompareInfo
System.Globalization.SortVersion
System.Guid
System.Int16
System.Int32
System.Int64
System.IntPtr
System.Net.Cookie
System.Net.CookieCollection
System.Net.CookieContainer
System.Net.PathList
System.Nullable<T>
System.Numerics.BigInteger
System.Numerics.Complex
System.Object
System.SByte
System.Single
System.String
System.StringComparer
System.Text.StringBuilder
System.TimeSpan
System.TimeZoneInfo
System.Tuple
System.UInt16
System.UInt32
System.UInt64
System.UIntPtr
System.Uri
System.ValueTuple
System.ValueType
System.Version
System.WeakReference
System.WeakReference<T>
``` 

## Remarks
As the nature of binary serialization allows the modification of private members inside an object and therefore changing the state of it, other serialization frameworks like JSON.NET which operate on the public API surface are recommended. 

## See Also  
 [Binary Serialization](../../../docs/standard/serialization/binary-serialization.md)
