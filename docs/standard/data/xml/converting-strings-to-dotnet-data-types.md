---
title: "Converting Strings to .NET Framework Data Types"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 65455ef3-9120-412c-819b-d0f59f88ac09
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Converting Strings to .NET Framework Data Types
If you want to convert a string to a .NET Framework data type, use the **XmlConvert** method that fits the application requirements. For a list of all conversion methods available in the **XmlConvert** class, see <xref:System.Xml.XmlConvert>.  
  
 The string returned from the **ToString** method is a string version of the data that is passed in. Additionally, there are several .NET Framework types that convert using the **XmlConvert** class yet they do not use the methods in the **System.Convert** class. The **XmlConvert** class follows the XML Schema (XSD) data type specification and has a data type that the **XmlConvert** can map to.  
  
 The following table lists .NET Framework data types and the string types that are returned using XML Schema (XSD) data type mapping. These .NET Framework types cannot be processed using **System.Convert**.  
  
|.NET Framework type|String returned|  
|-------------------------|---------------------|  
|Boolean|"true", "false"|  
|Single.PositiveInfinity|"INF"|  
|Single.NegativeInfinity|"-INF"|  
|Double.PositiveInfinity|"INF"|  
|Double.NegativeInfinity|"-INF"|  
|DateTime|Format is "yyyy-MM-ddTHH:mm:sszzzzzz" and its subsets.|  
|Timespan|Format is PnYnMnTnHnMnS that is, `P2Y10M15DT10H30M20S` is a duration of 2 years, 10 months, 15 days, 10 hours, 30 minutes, and 20 seconds.|  
  
> [!NOTE]
>  If converting any of the .NET Framework types listed in the table to a string using the **ToString** method, the returned string is not the base type, but the XML Schema (XSD) string type.  
  
 The **DateTime** and **Timespan** value type differs in that a **DateTime** represents an instant in time, whereas a **TimeSpan** represents a time interval. The **DateTime** and **Timespan** formats are specified in the XML Schema (XSD) data types specification. For example:  
  
```vb  
Dim writer As New XmlTextWriter("myfile.xml", Nothing)  
Dim [date] As New DateTime(2001, 8, 4)  
writer.WriteElementString("Date", XmlConvert.ToString([date]))  
```  
  
```csharp  
XmlTextWriter writer = new XmlTextWriter("myfile.xml", null);  
DateTime date = new DateTime (2001, 08, 04);  
writer.WriteElementString("Date", XmlConvert.ToString(date));  
```  
  
 **Output**  
  
 `<Date>2001-08-04T00:00:00</Date>`.  
  
 The following code converts an integer to a string:  
  
```vb  
Dim writer As New XmlTextWriter("myfile.xml", Nothing)  
Dim value As Int32 = 200  
writer.WriteElementString("Number", XmlConvert.ToString(value))  
```  
  
```csharp  
XmlTextWriter writer = new XmlTextWriter("myfile.xml", null);  
Int32 value = 200;  
writer.WriteElementString("Number", XmlConvert.ToString(value));  
```  
  
 **Output**  
  
 `<Number>200</Number>`  
  
 However, if you are converting a string to **Boolean**, **Single**, or **Double**, the .NET Framework type that is returned is not the same as the type returned when using the **System.Convert** class.  
  
## String to Boolean  
 The following table shows what type is generated for the given input strings, when converting a string to **Boolean** using the **ToBoolean** method.  
  
|Valid string input parameter|.NET Framework output type|  
|----------------------------------|--------------------------------|  
|"true"|Boolean.True|  
|"1"|Boolean.True|  
|"false"|Boolean.False|  
|"0"|Boolean.False|  
  
 For example, given the following XML:  
  
 **Input**  
  
```xml  
<Boolean>true</Boolean>  
<Boolean>1</Boolean>   
```  
  
 Both can be understood by the following code, and **bvalue** is **System.Boolean.True**:  
  
```vb  
Dim bvalue As Boolean = _  
   XmlConvert.ToBoolean(reader.ReadElementString())  
Console.WriteLine(bvalue)  
```  
  
```csharp  
Boolean bvalue = XmlConvert.ToBoolean(reader.ReadElementString());  
Console.WriteLine(bvalue);  
```  
  
## String to Single  
 The following table shows what type is generated for the given input strings, when converting a string to a **Single** using the **ToSingle** method.  
  
|Valid string input parameter|.NET Framework output type|  
|----------------------------------|--------------------------------|  
|"INF"|Single.PositiveInfinity|  
|"-INF"|Single.NegativeInfinity|  
  
## String to Double  
 The following table shows what type is generated for the given input strings, when converting a string to a **Single** using the **ToDouble** method.  
  
|Valid string input parameter|.NET Framework output type|  
|----------------------------------|--------------------------------|  
|"INF"|Double.PositiveInfinity|  
|"-INF"|Double.NegativeInfinity|  
  
 The following code writes `<Infinity>INF</Infinity>`:  
  
```vb  
Dim value As Double = Double.PositiveInfinity  
writer.WriteElementString("Infinity", XmlConvert.ToString(value))  
```  
  
```csharp  
Double value = Double.PositiveInfinity;  
writer.WriteElementString("Infinity", XmlConvert.ToString(value));  
```  
  
## See Also  
 [Conversion of XML Data Types](../../../../docs/standard/data/xml/conversion-of-xml-data-types.md)  
 [Converting .NET Framework Types to Strings](../../../../docs/standard/data/xml/converting-dotnet-types-to-strings.md)
