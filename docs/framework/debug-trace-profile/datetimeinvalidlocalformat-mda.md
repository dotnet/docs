---
title: "dateTimeInvalidLocalFormat MDA"
description: Review the dateTimeInvalidLocalFormat managed debugging assistant (MDA), which is activated when a UTC-stored DateTime value gets a local-only DateTime format.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "dates [.NET Framework], formatting"
  - "invalid date time local format"
  - "invalid local formats"
  - "MDAs (managed debugging assistants), invalid local formats"
  - "managed debugging assistants (MDAs), invalid local formats"
  - "dateTimeInvalidLocalFormat MDA"
  - "date formatting"
  - "time formatting"
  - "UTC formatting"
ms.assetid: c4a942bb-2651-4b65-8718-809f892a0659
---
# dateTimeInvalidLocalFormat MDA

The `dateTimeInvalidLocalFormat` MDA is activated when a <xref:System.DateTime> instance that is stored as a Universal Coordinated Time (UTC) is formatted using a format that is intended to be used only for local <xref:System.DateTime> instances. This MDA is not activated for unspecified or default <xref:System.DateTime> instances.  
  
## Symptom  

 An application is manually serializing a UTC <xref:System.DateTime> instance using a local format:  
  
```csharp
DateTime myDateTime = DateTime.UtcNow;  
Serialize(myDateTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffzzz"));  
```  
  
### Cause  

 The 'z' format for the <xref:System.DateTime.ToString%2A?displayProperty=nameWithType> method includes the local time zone offset, for example, "+10:00" for Sydney time. As such, it will only produce a meaningful result if the value of the <xref:System.DateTime> is local. If the value is UTC time, <xref:System.DateTime.ToString%2A?displayProperty=nameWithType> includes the local time zone offset, but it does not display or adjust the time zone specifier.  
  
### Resolution  

 UTC <xref:System.DateTime> instances should be formatted in a way that indicates that they are UTC. The recommended format for UTC times to use a 'Z' to denote UTC time:  
  
```csharp
DateTime myDateTime = DateTime.UtcNow;  
Serialize(myDateTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffZ"));  
```  
  
 There is also an "o" format that serializes a <xref:System.DateTime> making use of the <xref:System.DateTime.Kind%2A> property that serializes correctly regardless of whether the instance is local, UTC, or unspecified:  
  
```csharp
DateTime myDateTime = DateTime.UtcNow;  
Serialize(myDateTime.ToString("o"));  
```  
  
## Effect on the Runtime  

 This MDA does not affect the runtime.  
  
## Output  

 There is no special output as a result of this MDA activating., However, the call stack can be used to determine the location of the <xref:System.DateTime.ToString%2A> call that activated the MDA.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <dateTimeInvalidLocalFormat />  
  </assistants>  
</mdaConfig>  
```  
  
## Example  

 Consider an application that is indirectly serializing a UTC <xref:System.DateTime> value by using the <xref:System.Xml.XmlConvert> or <xref:System.Data.DataSet> class, in the following manner.  
  
```csharp
DateTime myDateTime = DateTime.UtcNow;  
String serialized = XMLConvert.ToString(myDateTime);  
```  
  
 The <xref:System.Xml.XmlConvert> and <xref:System.Data.DataSet> serializations use local formats for serialization by default. Additional options are required to serialize other kinds of <xref:System.DateTime> values, such as UTC.  
  
 For this specific example, pass in `XmlDateTimeSerializationMode.RoundtripKind` to the `ToString` call on `XmlConvert`. This serializes the data as a UTC time.  
  
 If using a <xref:System.Data.DataSet>, set the <xref:System.Data.DataColumn.DateTimeMode%2A> property on the <xref:System.Data.DataColumn> object to <xref:System.Data.DataSetDateTime.Utc>.  
  
```csharp
DateTime myDateTime = DateTime.UtcNow;  
String serialized = XmlConvert.ToString(myDateTime,
    XmlDateTimeSerializationMode.RoundtripKind);  
```  
  
## See also

- <xref:System.Globalization.DateTimeFormatInfo>
- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
