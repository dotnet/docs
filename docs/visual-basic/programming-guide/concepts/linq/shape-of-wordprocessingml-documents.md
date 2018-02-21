---
title: "Shape of WordprocessingML Documents (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2dfb446b-5a07-4c00-9ab3-a74ba734ff3a
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent

---
# Shape of WordprocessingML Documents (Visual Basic)
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
  
```vb  
Imports <xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">  
  
Module Module1  
    Sub Main()  
        Dim documentRelationshipType = _  
          "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"  
  
        Using wdPackage As Package = _  
          Package.Open("SampleDoc.docx", _  
                       FileMode.Open, FileAccess.Read)  
            Dim docPackageRelationship As PackageRelationship = wdPackage _  
                .GetRelationshipsByType(documentRelationshipType).FirstOrDefault()  
            If (docPackageRelationship IsNot Nothing) Then  
                Dim documentUri As Uri = PackUriHelper.ResolvePartUri( _  
                            New Uri("/", UriKind.Relative), _  
                            docPackageRelationship.TargetUri)  
                Dim documentPart As PackagePart = wdPackage.GetPart(documentUri)  
  
                ' Get the officeDocument part from the package.  
                ' Load the XML in the part into an XDocument instance.  
                Dim xDoc As XDocument = _  
                    XDocument.Load(XmlReader.Create(documentPart.GetStream()))  
                Console.WriteLine(xDoc.Root)  
            End If  
        End Using  
    End Sub  
End Module  
```  
  
## External Resources  
 [Introducing the Office (2007) Open XML File Formats](http://go.microsoft.com/fwlink/?LinkId=98093)  
  
 [Overview of WordprocessingML](http://go.microsoft.com/fwlink/?LinkId=98094)  
  
 [Office 2003: XML Reference Schemas Download page](http://go.microsoft.com/fwlink/?LinkId=98095)  
  
## See Also  
 [Tutorial: Manipulating Content in a WordprocessingML Document (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/tutorial-manipulating-content-in-a-wordprocessingml-document.md)
