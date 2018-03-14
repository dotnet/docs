---
title: "Literals (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 092ef693-6e5f-41b4-b868-5b9e82928abf
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Literals (Entity SQL)
This topic describes [!INCLUDE[esql](../../../../../../includes/esql-md.md)] support for literals.  
  
## Null  
 The null literal is used to represent the value null for any type. A null literal is compatible with any type.  
  
 Typed nulls can be created by a cast over a null literal. For more information, see [CAST](../../../../../../docs/framework/data/adonet/ef/language-reference/cast-entity-sql.md).  
  
 For rules about where free floating null literals can be used, see [Null Literals and Type Inference](../../../../../../docs/framework/data/adonet/ef/language-reference/null-literals-and-type-inference-entity-sql.md).  
  
## Boolean  
 Boolean literals are represented by the keywords `true` and `false`.  
  
## Integer  
 Integer literals can be of type <xref:System.Int32> or <xref:System.Int64>. An <xref:System.Int32> literal is a series of numeric characters. An <xref:System.Int64> literal is series of numeric characters followed by an uppercase L.  
  
## Decimal  
 A fixed-point number (decimal) is a series of numeric characters, a dot (.) and another series of numeric characters followed by an uppercase "M".  
  
## Float, Double  
 A double-precision floating point number is a series of numeric characters, a dot (.) and another series of numeric characters possibly followed by an exponent. A single-precisions floating point number (or float) is a double-precision floating point number syntax followed by the lowercase f.  
  
## String  
 A string is a series of characters enclosed in quote marks. Quotes can be either both single-quotes (`'`) or both double-quotes ("). Character string literals can be either Unicode or non-Unicode. To declare a character string literal as Unicode, prefix the literal with an uppercase "N". The default is non-Unicode character string literals. There can be no spaces between the N and the string literal payload, and the N must be uppercase.  
  
```  
'hello' -- non-Unicode character string literal  
N'hello' -- Unicode character string literal  
"x"  
N"This is a string!"  
'so is THIS'  
```  
  
## DateTime  
 A datetime literal is independent of locale and is composed of a date part and a time part. Both date and time parts are mandatory and there are no default values.  
  
 The date part must have the format: `YYYY`-`MM`-`DD`, where `YYYY` is a four digit year value between 0001 and 9999, `MM` is the month between 1 and 12 and `DD` is the day value that is valid for the given month `MM`.  
  
 The time part must have the format: `HH`:`MM`[:`SS`[.fffffff]], where `HH` is the hour value between 0 and 23, `MM` is the minute value between 0 and 59, `SS` is the second value between 0 and 59 and fffffff is the fractional second value between 0 and 9999999. All value ranges are inclusive. Fractional seconds are optional. Seconds are optional unless fractional seconds are specified; in this case, seconds are required. When seconds or fractional seconds are not specified, the default value of zero will be used instead.  
  
 There can be any number of spaces between the DATETIME symbol and the literal payload, but no new lines.  
  
```  
DATETIME'2006-10-1 23:11'  
DATETIME'2006-12-25 01:01:00.0000000' -- same as DATETIME'2006-12-25 01:01'  
```  
  
## Time  
 A time literal is independent of locale and composed of a time part only. The time part is mandatory and there is no default value. It must have the format HH:MM[:SS[.fffffff]], where HH is the hour value between 0 and 23, MM is the minute value between 0 and 59, SS is the second value between 0 and 59, and fffffff is the second fraction value between 0 and 9999999. All value ranges are inclusive. Fractional seconds are optional. Seconds are optional unless fractional seconds are specified; in this case, seconds are required. When seconds or fractions are not specified, the default value of zero will be used instead.  
  
 There can be any number of spaces between the TIME symbol and the literal payload, but no new lines.  
  
```  
TIME‘23:11’  
TIME‘01:01:00.1234567’  
```  
  
## DateTimeOffset  
 A datetimeoffset literal is independent of locale and composed of a date part, a time part, and an offset part. All date, time, and offset parts are mandatory and there are no default values. The date part must have the format YYYY-MM-DD, where YYYY is a four digit year value between 0001 and 9999, MM is the month between 1 and 12, and DD is the day value that is valid for the given month. The time part must have the format HH:MM[:SS[.fffffff]], where HH is the hour value between 0 and 23, MM is the minute value between 0 and 59, SS is the second value between 0 and 59, and fffffff is the fractional second value between 0 and 9999999. All value ranges are inclusive. Fractional seconds are optional. Seconds are optional unless fractional seconds are specified; in this case, seconds are required. When seconds or fractions are not specified, the default value of zero will be used instead. The offset part must have the format {+&#124;-}HH:MM, where HH and MM have the same meaning as in the time part. The range of the offset, however, must be between -14:00 and + 14:00  
  
 There can be any number of spaces between the DATETIMEOFFSET symbol and the literal payload, but no new lines.  
  
```  
DATETIMEOFFSET‘2006-10-1 23:11 +02:00’  
DATETIMEOFFSET‘2006-12-25 01:01:00.0000000 -08:30’  
```  
  
> [!NOTE]
>  A valid Entity SQL literal value can fall outside the supported ranges for CLR or the data source. This might result in an exception  
  
## Binary  
 A binary string literal is a sequence of hexadecimal digits delimited by single quotes following the keyword binary or the shortcut symbol `X` or `x`. The shortcut symbol `X` is case insensitive. A zero or more spaces are allowed between the keyword `binary` and the binary string value.  
  
 Hexadecimal characters are also case insensitive. If the literal is composed of an odd number of hexadecimal digits, the literal will be aligned to the next even hexadecimal digit by prefixing the literal with a hexadecimal zero digit. There is no formal limit on the size of the binary string.  
  
```  
Binary'00ffaabb'  
X'ABCabc'  
BINARY    '0f0f0f0F0F0F0F0F0F0F'  
X'' –- empty binary string  
```  
  
## Guid  
 A `GUID` literal represents a globally unique identifier. It is a sequence formed by the keyword `GUID` followed by hexadecimal digits in the form known as *registry* format: 8-4-4-4-12 enclosed in single quotes. Hexadecimal digits are case insensitive.  
  
 There can be any number of spaces between the GUID symbol and the literal payload, but no new lines.  
  
```  
Guid'1afc7f5c-ffa0-4741-81cf-f12eAAb822bf'  
GUID  '1AFC7F5C-FFA0-4741-81CF-F12EAAB822BF'  
```  
  
## See Also  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)
