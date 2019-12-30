---
title: "How to: Retrieve Paragraphs from an Office Open XML Document"
ms.date: 07/20/2015
ms.assetid: 66053f21-9217-473c-a6f3-a0897be07756
---
# How to: Retrieve Paragraphs from an Office Open XML Document (Visual Basic)

This topic presents an example that opens an Office Open XML document, and retrieves a collection of all of the paragraphs in the document.

For more information on Office Open XML, see [Eric White's Blog](http://www.ericwhite.com).

## Example

This example opens an Office Open XML package, uses the relationships within the Open XML package to find the document and the style parts. It then queries the document, projecting a collection of an anonymous type that contains the paragraph <xref:System.Xml.Linq.XElement> node, the style name of each paragraph, and the text of each paragraph.

The example uses an extension method named `StringConcatenate`, which is also supplied in the example.

For a detailed tutorial that explains how this example works, see [Pure Functional Transformations of XML (Visual Basic)](pure-functional-transformations-of-xml.md).

This example uses classes found in the WindowsBase assembly. It uses types in the <xref:System.IO.Packaging?displayProperty=nameWithType> namespace.

> [!TIP]
> For .NET Core apps, run the following command to add the **System.IO.Packaging** NuGet package.
>
> ```dotnetcli
> dotnet add package System.IO.Packaging
> ```

```vb
Imports System.IO
Imports System.IO.Packaging
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Xml
Imports <xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">

Module Module1
    <Extension()>
    Public Function StringConcatenate(source As IEnumerable(Of String)) As String
        Dim sb As New StringBuilder()
        For Each s As String In source
            sb.Append(s)
        Next
        Return sb.ToString()
    End Function

    <Extension()>
    Public Function StringConcatenate(Of T)(source As IEnumerable(Of T),
    func As Func(Of T, String)) As String
        Dim sb As New StringBuilder()
        For Each item As T In source
            sb.Append(func(item))
        Next
        Return sb.ToString()
    End Function

    <Extension()>
    Public Function StringConcatenate(Of T)(source As IEnumerable(Of T),
    separator As String) As String
        Dim sb As New StringBuilder()
        For Each s As T In source
            sb.Append(s).Append(separator)
        Next
        Return sb.ToString()
    End Function

    <Extension()>
    Public Function StringConcatenate(Of T)(source As IEnumerable(Of T),
    func As Func(Of T, String), separator As String) As String
        Dim sb As New StringBuilder()
        For Each item As T In source
            sb.Append(func(item)).Append(separator)
        Next
        Return sb.ToString()
    End Function

    Public Function ParagraphText(e As XElement) As String
        Dim w As XNamespace = e.Name.Namespace
        Return (e.<w:r>.<w:t>).StringConcatenate(Function(element) CStr(element))
    End Function

    ' Following function is required because Visual Basic does not support short circuit evaluation
    Private Function GetStyleOfParagraph(styleNode As XElement, defaultStyle As String) As String
        If styleNode Is Nothing Then
            Return defaultStyle
        Else
            Return styleNode.@w:val
        End If
    End Function

    Sub Main()
        Dim fileName = "SampleDoc.docx"

        Dim documentRelationshipType =
          "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"
        Dim stylesRelationshipType =
          "http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles"
        Dim wordmlNamespace =
          "http://schemas.openxmlformats.org/wordprocessingml/2006/main"

        Dim xDoc As XDocument = Nothing
        Dim styleDoc As XDocument = Nothing
        Using wdPackage As Package = Package.Open(fileName, FileMode.Open, FileAccess.Read)
            Dim docPackageRelationship As PackageRelationship =
              wdPackage.GetRelationshipsByType(documentRelationshipType).FirstOrDefault()
            If docPackageRelationship IsNot Nothing Then
                Dim documentUri As Uri =
                  PackUriHelper.
                  ResolvePartUri(New Uri("/", UriKind.Relative), docPackageRelationship.TargetUri)
                Dim documentPart As PackagePart = wdPackage.GetPart(documentUri)

                '  Load the document XML in the part into an XDocument instance.
                xDoc = XDocument.Load(XmlReader.Create(documentPart.GetStream()))

                '  Find the styles part. There will only be one.
                Dim styleRelation As PackageRelationship = documentPart.GetRelationshipsByType(stylesRelationshipType).FirstOrDefault()
                If styleRelation IsNot Nothing Then
                    Dim styleUri As Uri = PackUriHelper.ResolvePartUri(documentUri, styleRelation.TargetUri)
                    Dim stylePart As PackagePart = wdPackage.GetPart(styleUri)

                    '  Load the style XML in the part into an XDocument instance.
                    styleDoc = XDocument.Load(XmlReader.Create(stylePart.GetStream()))
                End If
            End If
        End Using

        Dim defaultStyle As String =
            (From style In styleDoc.Root.<w:style>
             Where style.@w:type = "paragraph" AndAlso style.@w:default = "1"
             Select style).First().@w:styleId

        ' Find all paragraphs in the document.
        Dim paragraphs = From para In xDoc.Root.<w:body>...<w:p>
                         Let styleNode As XElement = para.<w:pPr>.<w:pStyle>.FirstOrDefault()
                         Select New With {
                             .ParagraphNode = para,
                             .StyleName = GetStyleOfParagraph(styleNode, defaultStyle)
                         }

        ' Retrieve the text of each paragraph.
        Dim paraWithText = From para In paragraphs
                           Select New With {
                               .ParagraphNode = para.ParagraphNode,
                               .StyleName = para.StyleName,
                               .Text = ParagraphText(para.ParagraphNode)
                           }

        For Each p In paraWithText
            Console.WriteLine($"StyleName:{p.StyleName} >{p.Text}<")
        Next
    End Sub
End Module
```

When run with the sample Open XML document described in [Creating the Source Office Open XML Document (Visual Basic)](creating-the-source-office-open-xml-document.md), this example produces the following output:

```console
StyleName:Heading1 >Parsing WordprocessingML with LINQ to XML<
StyleName:Normal ><
StyleName:Normal >The following example prints to the console.<
StyleName:Normal ><
StyleName:Code >using System;<
StyleName:Code ><
StyleName:Code >class Program {<
StyleName:Code >    public static void (string[] args) {<
StyleName:Code >        Console.WriteLine("Hello World");<
StyleName:Code >    }<
StyleName:Code >}<
StyleName:Normal ><
StyleName:Normal >This example produces the following output:<
StyleName:Normal ><
StyleName:Code >Hello World<
```

## See also

- [Advanced Query Techniques (LINQ to XML) (Visual Basic)](advanced-query-techniques-linq-to-xml.md)
