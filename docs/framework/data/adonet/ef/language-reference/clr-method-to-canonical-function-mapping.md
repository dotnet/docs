---
title: "CLR Method to Canonical Function Mapping"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e3363261-2cb8-4b54-9555-2870be99b929
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# CLR Method to Canonical Function Mapping
The Entity Framework provides a set of canonical functions that implement functionality that is common across many database systems, such as string manipulation and mathematical functions. This enables developers to target a broad range of database systems. When called from a querying technology, such as LINQ to Entities, these canonical functions are translated to the correct corresponding store function for the provider being used. This allows function invocations to be expressed in a common form across data sources, providing a consistent query experience across data sources. The bitwise AND, OR, NOT, and XOR operators are also mapped to canonical functions when the operand is a numeric type. For Boolean operands, the bitwise AND, OR, NOT, and XOR operators compute the logical AND, OR, NOT, and XOR operations of their operands. For more information, see [Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/canonical-functions.md).  
  
 For LINQ scenarios, queries against the Entity Framework involve mapping certain CLR methods to methods on the underlying data source through canonical functions. Any method calls in a LINQ to Entities query that are not explicitly mapped to a canonical function will result in a runtime <xref:System.NotSupportedException> exception being thrown.  
  
## System.String Method (Static) Mapping  
  
|System.String method (static)|Canonical function|  
|-------------------------------------|------------------------|  
|System.String Concat(String `str0`, String `str1`)|Concat(`str0`, `str1`)|  
|System.String Concat(String `str0`, String `str1`, String `str2`)|Concat(Concat(`str0`, `str1`), `str2`)|  
|System.String Concat(String `str0`, String `str1`, String `str2`, String `str03`)|Concat(Concat(Concat(`str0`, `str1`), `str2`), `str3`)|  
|Boolean Equals(String `a`, String `b`)|= operator|  
|Boolean IsNullOrEmpty(String `value`)|(IsNull(`value`)) OR Length(`value`) = 0|  
|Boolean op_Equality(String `a`, String `b`)|= operator|  
|Boolean op_Inequality(String `a` , String `b`)|!= operator|  
|Microsoft.VisualBasic.Strings.Trim(String `str`)|Trim(`str`)|  
|Microsoft.VisualBasic.Strings.LTrim(String `str`)|Ltrim(`str`)|  
|Microsoft.VisualBasic.Strings.RTrim(String `str`)|Rtrim(`str`)|  
|Microsoft.VisualBasic.Strings.Len(String `expression`)|Length(`expression`)|  
|Microsoft.VisualBasic.Strings.Left(String `str`, Int32 `Length`)|Left(`str`, `Length`)|  
|Microsoft.VisualBasic.Strings.Mid(String `str`, Int32 `Start`, Int32 `Length`)|Substring(`str`, `Start`, `Length`)|  
|Microsoft.VisualBasic.Strings.Right(String `str`, Int32 `Length`)|Right(`str`, `Length`)|  
|Microsoft.VisualBasic.Strings.UCase(String `Value`)|ToUpper(`Value`)|  
|Microsoft.VisualBasic.Strings.LCase(String Value)|ToLower(`Value`)|  
  
## System.String Method (Instance) Mapping  
  
|System.String method (instance)|Canonical function|Notes|  
|---------------------------------------|------------------------|-----------|  
|Boolean Contains(String `value`)|`this` LIKE '%`value`%'|If `value` is not a constant, then this maps to IndexOf(`this`, `value`) > 0|  
|Boolean EndsWith(String `value`)|`this` LIKE `'`%`value`'|If `value` is not a constant, then this maps to Right(`this`, length(`value`)) = `value`.|  
|Boolean StartsWith(String `value`)|`this` LIKE '`value`%'|If `value` is not a constant, then this maps to IndexOf(`this`, `value`) = 1.|  
|Length|Length(`this`)||  
|Int32 IndexOf(String `value`)|IndexOf(`this`, `value`) - 1||  
|System.String Insert(Int32 `startIndex`, String `value`)|Concat(Concat(Substring(`this`, 1, `startIndex`), `value`), Substring(`this`, `startIndex`+1, Length(`this`) - `startIndex`))||  
|System.String Remove(Int32 `startIndex`)|Substring(`this`, 1, `startIndex`)||  
|System.String Remove(Int32 `startIndex`, Int32 `count`)|Concat(Substring(`this`, 1, `startIndex`) , Substring(`this`, `startIndex` + `count` +1, Length(`this`) - (`startIndex` + `count`)))|Remove(`startIndex`, `count`) is only supported if `count` is an integer greater than or equal to 0.|  
ystem.String Replace(String `oldValue`, String `newValue`)|Replace(`this`, `oldValue`, `newValue`)||  
|System.String Substring(Int32 `startIndex`)|Substring(`this`, `startIndex` +1, Length(`this`) - `startIndex`)||  
|System.String Substring(Int32 `startIndex`, Int32 `length`)|Substring(`this`, `startIndex` +1, `length`)||  
|System.String ToLower()|ToLower(`this`)||  
|System.String ToUpper()|ToUpper(`this`)||  
|System.String Trim()|Trim(`this`)||  
|System.String TrimEnd(Char[] `trimChars`)|RTrim(`this`)||  
|System.String TrimStart(Char[]`trimChars`)|LTrim(`this`)||  
|Boolean Equals(String `value`)|= operator||  
  
## System.DateTime Method (Static) Mapping  
  
|System.DateTime method (static)|Canonical function|Notes|  
|---------------------------------------|------------------------|-----------|  
|Boolean Equals(DateTime `t1`, DateTime `t2`)|= operator||  
|System.DateTime.Now|CurrentDateTime()||  
|System.DateTime.UtcNow|CurrentUtcDateTime()||  
|Boolean op_Equality(DateTime `d1`, DateTime `d2`)|= operator||  
|Boolean op_GreaterThan(DateTime `t1`, DateTime `t2`)|> operator||  
|Boolean op_GreaterThanOrEqual(DateTime `t1`, DateTime `t2`)|>= operator||  
|Boolean op_Inequality(DateTime `t1`, DateTime `t2`)|!= operator||  
|Boolean op_LessThan(DateTime `t1`, DateTime `t2`)|< operator||  
|Boolean op_LessThanOrEqual(DateTime `t1`, DateTime `t2`)|<= operator||  
|Microsoft.VisualBasic.DateAndTime.DatePart( _<br /><br /> ByVal `Interval` As DateInterval, \_<br /><br /> ByVal `DateValue` As DateTime, \_<br /><br /> Optional ByVal `FirstDayOfWeekValue` As FirstDayOfWeek = VbSunday, \_<br /><br /> Optional ByVal `FirstWeekOfYearValue` As FirstWeekOfYear = VbFirstJan1 \_<br /><br /> ) As Integer||See the DatePart Function section for more information.|  
|Microsoft.VisualBasic.DateAndTime.Now|CurrentDateTime()||  
|Microsoft.VisualBasic.DateAndTime.Year(DateTime `TimeValue`)|Year()||  
|Microsoft.VisualBasic.DateAndTime.Month(DateTime `TimeValue`)|Month()||  
icrosoft.VisualBasic.DateAndTime.Day(DateTime `TimeValue`)|Day()||  
|Microsoft.VisualBasic.DateAndTime.Hour(DateTime `TimeValue`)|Hour()||  
|Microsoft.VisualBasic.DateAndTime.Minute(DateTime `TimeValue`)|Minute()||  
|Microsoft.VisualBasic.DateAndTime.Second(DateTime `TimeValue`)|Second()||  
  
## System.DateTime Method (Instance) Mapping  
  
|System.DateTime method (instance)|Canonical function|  
|-----------------------------------------|------------------------|  
|Boolean Equals(DateTime `value`)|= operator|  
|Day|Day(`this`)|  
|Hour|Hour(`this`)|  
|Millisecond|Millisecond(`this`)|  
|Minute|Minute(`this`)|  
|Month|Month(`this`)|  
|Second|Second(`this`)|  
|Year|Year(`this`)|  
  
## System.DateTimeOffset Method (Instance) Mapping  
 The mapping shown for the `get` methods on the listed properties.  
  
|System.DateTimeOffset method (instance)|Canonical function|Notes|  
|-----------------------------------------------|------------------------|-----------|  
|Day|Day(`this`)|Not supported against SQL Server 2005.|  
|Hour|Hour(`this`)|Not supported against SQL Server 2005.|  
|Millisecond|Millisecond(`this`)|Not supported against SQL Server 2005.|  
|Minute|Minute(`this`)|Not supported against SQL Server 2005.|  
|Month|Month(`this`)|Not supported against SQL Server 2005.|  
|Second|Second(`this`)|Not supported against SQL Server 2005.|  
|Year|Year(`this`)|Not supported against SQL Server 2005.|  
  
> [!NOTE]
>  The <xref:System.DateTimeOffset.Equals%2A> method returns `true` if the compared <xref:System.DateTimeOffset> objects are equal; `false` otherwise. The <xref:System.DateTimeOffset.CompareTo%2A> method returns 0, 1, or -1 depending on whether the compared <xref:System.DateTimeOffset> object is equal, greater than, or less than, respectively.  
  
## System.DateTimeOffset Method (Static) Mapping  
 The mapping shown for the `get` methods on the listed properties.  
  
|System.DateTimeOffset method (static)|Canonical function|Notes|  
|---------------------------------------------|------------------------|-----------|  
|System.DateTimeOffset.Now()|CurrentDateTimeOffset()|Not supported against SQL Server 2005.|  
  
## System.TimeSpan Method (Instance) Mapping  
 The mapping shown for the `get` methods on the listed properties.  
  
|System.TimeSpan method (instance)|Canonical function|Notes|  
|-----------------------------------------|------------------------|-----------|  
|Hours|Hour(`this`)|Not supported against SQL Server 2005.|  
|Milliseconds|Millisecond(`this`)|Not supported against SQL Server 2005.|  
|Minutes|Minute(`this`)|Not supported against SQL Server 2005.|  
|Seconds|Second(`this`)|Not supported against SQL Server 2005.|  
  
> [!NOTE]
>  The <xref:System.TimeSpan.Equals%2A> method returns `true` if the compared <xref:System.TimeSpan> objects are equal; `false` otherwise. The <xref:System.TimeSpan.CompareTo%2A> method returns 0, 1, or -1 depending on whether the compared <xref:System.TimeSpan> object is equal, greater than, or less than, respectively.  
  
### DatePart Function  
 The `DatePart` Function is mapped to one of several different canonical functions, depending on the value of `Interval`. The following table displays the canonical function mapping for the supported values of `Interval`:  
  
|Interval value|Canonical function|  
|--------------------|------------------------|  
|DateInterval.Year|Year()|  
|DateInterval.Month|Month()|  
|DateInterval.Day|Day()|  
|DateInterval.Hour|Hour()|  
|DateInterval.Minute|Minute()|  
|DateInterval.Second|Second()|  
  
## Mathematical Function Mapping  
  
|CLR method|Canonical function|  
|----------------|------------------------|  
|System.Decimal.Ceiling(Decimal `d`)|Ceiling(`d`)|  
|System.Decimal.Floor(Decimal `d`)|Floor(`d`)|  
|System.Decimal.Round(Decimal `d`)|Round(`d`)|  
|System.Math.Ceiling(Decimal `d`)|Ceiling(`d`)|  
|System.Math.Floor(Decimal `d`)|Floor(`d`)|  
|System.Math.Round(Decimal `d`)|Round(`d`)|  
|System.Math.Ceiling(Double `a`)|Ceiling(`a`)|  
|System.Math.Floor(Double `a`)|Floor(`a`)|  
|System.Math.Round(Double `a`)|Round(`a`)|  
|System.Math.Round(Double value, Int16 digits)|Round(value, digits)|  
|System.Math.Round(Double value, Int32 digits)|Round(value, digits)|  
|System.Math.Round(Decimal value, Int16 digits)|Round(value, digits)|  
|System.Math.Round(Decimal value, Int32, digits)|Round(value, digits)|  
|System.Math.Abs(Int16 value)|Abs(value)|  
|System.Math.Abs(Int32 value)|Abs(value)|  
|System.Math.Abs(Int64 value)|Abs(value)|  
|System.Math.Abs(Byte value)|Abs(value)|  
|System.Math.Abs(Single value)|Abs(value)|  
|System.Math.Abs(Double value)|Abs(value)|  
|System.Math.Abs(Decimal value)|Abs(value)|  
|System.Math.Truncate(Double value, Int16 digits)|Truncate(value, digits)|  
|System.Math.Truncate(Double value, Int32 digits)|Truncate(value, digits)|  
|System.Math.Truncate(Decimal value, Int16 digits)|Truncate(value, digits)|  
|System.Math.Truncate(Decimal value, Int32 digits)|Truncate(value, digits)|  
|System.Math.Power(Int32 value, Int64 exponent)|Power(value, exponent)|  
|System.Math.Power(Int32 value, Double exponent)|Power(value, exponent)|  
|System.Math.Power(Int32 value, Decimal exponent)|Power(value, exponent)|  
|System.Math.Power(Int64 value, Int64 exponent)|Power(value, exponent)|  
|System.Math.Power(Int64 value, Double exponent)|Power(value, exponent)|  
|System.Math.Power(Int64 value, Decimal exponent)|Power(value, exponent)|  
|System.Math.Power(Double value, Int64 exponent)|Power(value, exponent)|  
|System.Math.Power(Double value, Double exponent)|Power(value, exponent)|  
|System.Math.Power(Double value, Decimal exponent)|Power(value, exponent)|  
|System.Math.Power(Decimal value, Int64 exponent)|Power(value, exponent)|  
|System.Math.Power(Decimal value, Double exponent)|Power(value, exponent)|  
|System.Math.Power(Decimal value, Decimal exponent)|Power(value, exponent)|  
  
## Bitwise Operator Mapping  
  
|Bitwise operator|Canonical function for non-Boolean operands|Canonical function for Boolean operands|  
|----------------------|--------------------------------------------------|---------------------------------------------|  
|Bitwise AND operator|BitWiseAnd|op1 AND op2|  
|Bitwise OR operator|BitWiseOr|op1 OR op2|  
|Bitwise NOT operator|BitWiseNot|NOT(op)|  
|Bitwise XOR operator|BitWiseXor|((op1 AND NOT(op2)) OR (NOT(op1) AND op2))|  
  
## Other Mapping  
  
|Method|Canonical function|  
|------------|------------------------|  
|Guid.NewGuid()|NewGuid()|  
  
## See Also  
 [LINQ to Entities](../../../../../../docs/framework/data/adonet/ef/language-reference/linq-to-entities.md)
