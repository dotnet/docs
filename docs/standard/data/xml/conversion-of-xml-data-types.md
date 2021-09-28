---
description: "Learn more about: Conversion of XML Data Types"
title: "Conversion of XML Data Types"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: a2aa99ba-8239-4818-9281-f1d72ee40bde
---
# Conversion of XML Data Types

The majority of the methods found in an **XmlConvert** class are used to convert data between strings and strongly typed formats. Methods are locale independent. This means that they do not take into account any locale settings when doing conversion.  
  
## Reading String as types  

 The following sample reads a string and converts it to a **DateTime** type.  
  
 Given the following XML input:  
  
 **Input**  
  
```xml  
<Element>2001-02-27T11:13:23</Element>  
```  
  
 This code converts the string to the **DateTime** format:  
  
```vb  
reader.ReadStartElement()  
Dim vDateTime As DateTime = XmlConvert.ToDateTime(reader.ReadString())  
Console.WriteLine(vDateTime)  
```  
  
```csharp  
reader.ReadStartElement();  
DateTime vDateTime = XmlConvert.ToDateTime(reader.ReadString());  
Console.WriteLine(vDateTime);  
```  
  
## Writing Strings as types  

 The following sample reads an **Int32** and converts it to a string.  
  
 Given the following XML input:  
  
 **Input**  
  
```xml  
<TestInt32>-2147483648</TestInt32>  
```  
  
 This code converts the **Int32** into a **String**:  
  
```vb  
Dim vInt32 As Int32 = -2147483648  
writer.WriteElementString("TestInt32", XmlConvert.ToString(vInt32))  
```  
  
```csharp  
Int32 vInt32=-2147483648;  
writer.WriteElementString("TestInt32",XmlConvert.ToString(vInt32));  
```  
  
## See also

- [Converting Strings to .NET Framework Data Types](converting-strings-to-dotnet-data-types.md)
- [Converting .NET Framework Types to Strings](converting-dotnet-types-to-strings.md)
