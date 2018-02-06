---
title: "How to: Modify an Office Open XML Document (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1cefd7f5-8e39-44c4-869c-f8021538a777
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent

---
# How to: Modify an Office Open XML Document (Visual Basic)
This topic presents an example that opens an Office Open XML document, modifies it, and saves it.  
  
 For more information on Office Open XML, see [www.openxmldeveloper.org](http://go.microsoft.com/fwlink/?LinkID=95573).  
  
## Example  
 This example finds the first paragraph element in the document. It retrieves the text from the paragraph, and then deletes all text runs in the paragraph. It creates a new text run that consists of the first paragraph text that has been converted to upper case. It then serializes the changed XML into the Open XML package and closes it.  
  
 This example uses classes found in the WindowsBase assembly. It uses types in the <xref:System.IO.Packaging?displayProperty=nameWithType> namespace.  
  
```vb  
Imports <xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">  
  
Module Module1  
    <System.Runtime.CompilerServices.Extension()> _  
    Public Function StringConcatenate(ByVal source As IEnumerable(Of String)) As String  
        Dim sb As StringBuilder = New StringBuilder()  
        For Each s As String In source  
            sb.Append(s)  
        Next  
        Return sb.ToString()  
    End Function  
  
    <System.Runtime.CompilerServices.Extension()> _  
    Public Function StringConcatenate(Of T)(ByVal source As IEnumerable(Of T), _  
    ByVal func As Func(Of T, String)) As String  
        Dim sb As StringBuilder = New StringBuilder()  
        For Each item As T In source  
            sb.Append(func(item))  
        Next  
        Return sb.ToString()  
    End Function  
  
    <System.Runtime.CompilerServices.Extension()> _  
    Public Function StringConcatenate(Of T)(ByVal source As IEnumerable(Of T), _  
    ByVal separator As String) As String  
        Dim sb As StringBuilder = New StringBuilder()  
        For Each s As T In source  
            sb.Append(s).Append(separator)  
        Next  
        Return sb.ToString()  
    End Function  
  
    <System.Runtime.CompilerServices.Extension()> _  
    Public Function StringConcatenate(Of T)(ByVal source As IEnumerable(Of T), _  
    ByVal func As Func(Of T, String), ByVal separator As String) As String  
        Dim sb As StringBuilder = New StringBuilder()  
        For Each item As T In source  
            sb.Append(func(item)).Append(separator)  
        Next  
        Return sb.ToString()  
    End Function  
  
    Public Function ParagraphText(ByVal e As XElement) As String  
        Dim w As XNamespace = e.Name.Namespace  
        Return (e.<w:r>.<w:t>).StringConcatenate(Function(element) CStr(element))  
    End Function  
  
    ' Following function is required because VB does not support short circuit evaluation  
    Private Function GetStyleOfParagraph(ByVal styleNode As XElement, _  
                                         ByVal defaultStyle As String) As String  
        If (styleNode Is Nothing) Then  
            Return defaultStyle  
        Else  
            Return styleNode.@w:val  
        End If  
    End Function  
  
    Sub Main()  
        Dim fileName = "SampleDoc.docx"  
  
        Dim documentRelationshipType = _  
          "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"  
        Dim stylesRelationshipType = _  
          "http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles"  
        Dim wordmlNamespace = _  
          "http://schemas.openxmlformats.org/wordprocessingml/2006/main"  
  
        Using wdPackage As Package = Package.Open(fileName, FileMode.Open, FileAccess.ReadWrite)  
            Dim docPackageRelationship As PackageRelationship = wdPackage _  
                    .GetRelationshipsByType(documentRelationshipType).FirstOrDefault()  
            If (docPackageRelationship IsNot Nothing) Then  
                Dim documentUri As Uri = PackUriHelper.ResolvePartUri(New Uri("/", _  
                            UriKind.Relative), docPackageRelationship.TargetUri)  
                Dim documentPart As PackagePart = wdPackage.GetPart(documentUri)  
  
                '  Load the document XML in the part into an XDocument instance.  
                Dim xDoc As XDocument = XDocument.Load(XmlReader.Create(documentPart.GetStream()))  
  
                '  Find the styles part. There will only be one.  
                Dim styleRelation As PackageRelationship = documentPart _  
                        .GetRelationshipsByType(stylesRelationshipType).FirstOrDefault()  
                Dim stylePart As PackagePart = Nothing  
                Dim styleDoc As XDocument = Nothing  
  
                If (styleRelation IsNot Nothing) Then  
                    Dim styleUri As Uri = PackUriHelper.ResolvePartUri( _  
                            documentUri, styleRelation.TargetUri)  
                    stylePart = wdPackage.GetPart(styleUri)  
  
                    ' Load the style XML in the part into an XDocument instance.  
                    styleDoc = XDocument.Load(XmlReader.Create(stylePart.GetStream()))  
                End If  
  
                Dim paraNode As XElement = xDoc.Root.<w:body>...<w:p>.FirstOrDefault()  
  
                Dim paraText As String = ParagraphText(paraNode)  
  
                ' Remove all text runs.  
                paraNode...<w:r>.Remove()  
  
                paraNode.Add(<w:r><w:t><%= paraText.ToUpper() %></w:t></w:r>)  
  
                ' Save the XML into the package.  
                Using xw As XmlWriter = _  
                  XmlWriter.Create(documentPart.GetStream(FileMode.Create, FileAccess.Write))  
                    xDoc.Save(xw)  
                End Using  
  
                Console.WriteLine("New first paragraph: >{0}<", paraText.ToUpper())  
            End If  
        End Using  
    End Sub  
End Module  
```  
  
 If you open `SampleDoc.docx` after running this program, you can see that this program converted the first paragraph in the document to upper case.  
  
 When run with the sample Open XML document described in [Creating the Source Office Open XML Document (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/creating-the-source-office-open-xml-document.md), this example produces the following output:  
  
```  
New first paragraph: >PARSING WORDPROCESSINGML WITH LINQ TO XML<  
```  
  
## See Also  
 [Advanced Query Techniques (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/advanced-query-techniques-linq-to-xml.md)
