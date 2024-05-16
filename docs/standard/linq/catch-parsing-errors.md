---
title: How to catch parsing errors - LINQ to XML
description: An exception can occur in your C# or Visual Basic program if it tries to parse invalid XML with a method such as XElement.Parse. You can write the program to catch and respond to such exceptions.
ms.date: 7/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to catch parsing errors (LINQ to XML)

This article shows how to detect badly formed or invalid XML in C# or Visual Basic.

LINQ to XML is implemented using <xref:System.Xml.XmlReader>. If badly formed or invalid XML is passed to LINQ to XML, the underlying <xref:System.Xml.XmlReader> class will throw an exception. The various methods that parse XML, such as <xref:System.Xml.Linq.XElement.Parse%2A?displayProperty=nameWithType>, don't catch the exception; the exception can then be caught by your application.

## Example: Parse invalid XML

The following code tries to parse invalid XML.

```csharp
try {
    XElement contacts = XElement.Parse(
        @"<Contacts>
            <Contact>
                <Name>Jim Wilson</Name>
            </Contact>
          </Contcts>");

    Console.WriteLine(contacts);
}
catch (System.Xml.XmlException e)
{
    Console.WriteLine(e.Message);
}
```

```vb
Try
    Dim contacts As XElement = XElement.Parse("<Contacts>" & vbCrLf & _
        "    <Contact>" & vbCrLf & _
        "        <Name>Jim Wilson</Name>" & vbCrLf & _
        "    </Contact>" & vbCrLf & _
        "</Contcts>")

    Console.WriteLine(contacts)
Catch e As System.Xml.XmlException
    Console.WriteLine(e.Message)
End Try
```

Because of the invalid end tag `</Contcts>`, the example throws the following exception:

```output
The 'Contacts' start tag on line 1 doesn't match the end tag of 'Contcts'. Line 5, position 13.
```

For information about the exceptions that the <xref:System.Xml.Linq.XElement.Parse%2A?displayProperty=nameWithType>, <xref:System.Xml.Linq.XDocument.Parse%2A?displayProperty=nameWithType>, <xref:System.Xml.Linq.XElement.Load%2A?displayProperty=nameWithType>, and <xref:System.Xml.Linq.XDocument.Load%2A?displayProperty=nameWithType> methods throw, see the <xref:System.Xml.XmlReader> documentation.

## See also

- [How to parse a string](parse-string.md)
