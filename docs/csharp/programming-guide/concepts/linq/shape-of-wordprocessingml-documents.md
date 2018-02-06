---
title: "Shape of WordprocessingML Documents (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: 3791b5e0-c502-469b-bb75-a7bf6fdd0a94
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# Shape of WordprocessingML Documents (C#)
This topic introduces the XML shape of a WordprocessingML document.  
  
## Microsoft Office Formats  
 The native file format for the 2007 Microsoft Office system is Office Open XML (commonly called Open XML). Open XML is an XML-based format that an Ecma standard and is currently going through the ISO-IEC standards process. The markup language for word processing files within Open XML is called WordprocessingML. This tutorial uses WordprocessingML source files as input for the examples.  
  
 If you are using Microsoft Office 2003, you can save documents in the Office Open XML format if you have installed the Microsoft Office Compatibility Pack for Word, Excel, and PowerPoint 2007 File Formats.  
  
## The Shape of WordprocessingML Documents  
 The first thing to understand is the shape of WordprocessingML documents. A WordprocessingML document contains a body element (named `w:body`) that contains the paragraphs of the document. Each paragraph contains one or more text runs (named `w:r`). Each text run contains one or more text pieces (named `w:t`).  
  
 The following is a very simple WordprocessingML document:  
  
```xml  
<?xml version="1.0" encoding="utf-8" standalone="yes"?>  
<w:document  
xmlns:ve="http://schemas.openxmlformats.org/markup-compatibility/2006"  
xmlns:o="urn:schemas-microsoft-com:office:office"  
xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships"  
xmlns:m="http://schemas.openxmlformats.org/officeDocument/2006/math"  
xmlns:v="urn:schemas-microsoft-com:vml"  
xmlns:wp="http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing"  
xmlns:w10="urn:schemas-microsoft-com:office:word"  
xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"  
xmlns:wne="http://schemas.microsoft.com/office/word/2006/wordml">  
  <w:body>  
    <w:p w:rsidR="00E22EB6"  
         w:rsidRDefault="00E22EB6">  
      <w:r>  
        <w:t>This is a paragraph.</w:t>  
      </w:r>  
    </w:p>  
    <w:p w:rsidR="00E22EB6"  
         w:rsidRDefault="00E22EB6">  
      <w:r>  
        <w:t>This is another paragraph.</w:t>  
      </w:r>  
    </w:p>  
  </w:body>  
</w:document>  
```  
  
 This document contains two paragraphs. They both contain a single text run, and each text run contains a single text piece.  
  
 The easiest way to see the contents of a WordprocessingML document in XML form is to create one using Microsoft Word, save it, and then run the following program that prints the XML to the console.  
  
 This example uses classes found in the WindowsBase assembly. It uses types in the <xref:System.IO.Packaging?displayProperty=nameWithType> namespace.  
  
```csharp  
const string documentRelationshipType =  
  "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument";  
const string wordmlNamespace =  
  "http://schemas.openxmlformats.org/wordprocessingml/2006/main";  
XNamespace w = wordmlNamespace;  
  
using (Package wdPackage = Package.Open("SampleDoc.docx", FileMode.Open, FileAccess.Read))  
{  
    PackageRelationship relationship =  
        wdPackage  
        .GetRelationshipsByType(documentRelationshipType)  
        .FirstOrDefault();  
    if (relationship != null)  
    {  
        Uri documentUri =  
            PackUriHelper.ResolvePartUri(  
                new Uri("/", UriKind.Relative),  
                relationship.TargetUri);  
        PackagePart documentPart = wdPackage.GetPart(documentUri);  
  
        //  Get the officeDocument part from the package.  
        //  Load the XML in the part into an XDocument instance.  
        XDocument xdoc =  
            XDocument.Load(XmlReader.Create(documentPart.GetStream()));  
        Console.WriteLine(xdoc.Root);  
    }  
}  
```  
  
## External Resources  
 [Introducing the Office (2007) Open XML File Formats](https://msdn.microsoft.com/library/ms406049.aspx)  
 [Overview of WordprocessingML](https://msdn.microsoft.com/library/aa212812(office.11).aspx)  
 [Anatomy of a WordProcessingML File](http://officeopenxml.com/anatomyofOOXML.php)  
 [Introduction to WordprocessingML](http://ericwhite.com/blog/introduction-to-wordprocessingml-series/)  
 [Office 2003: XML Reference Schemas Download page](https://www.microsoft.com/en-us/download/details.aspx?id=101)  
  
## See Also  
 [Tutorial: Manipulating Content in a WordprocessingML Document (C#)](../../../../csharp/programming-guide/concepts/linq/tutorial-manipulating-content-in-a-wordprocessingml-document.md)
