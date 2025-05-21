---
title: Example that outputs Office Open XML document parts - LINQ to XML
description: Learn how to open an Office Open XML document and access its parts.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 6cd37055-89b4-42e8-bf27-5a29717e35f3
ms.topic: article
---

# Example that outputs Office Open XML document parts (LINQ to XML)

This article shows how to open an Office Open XML document and access its parts.

## Example: Print the document and style parts of an Office Open XML document

The following example opens an Office Open XML document and prints the document and styles parts.

This example uses classes from the WindowsBase assembly, and types from the <xref:System.IO.Packaging?displayProperty=nameWithType> namespace.

```csharp
const string fileName = "SampleDoc.docx";

const string documentRelationshipType =
  "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument";
const string stylesRelationshipType =
  "http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles";
const string wordmlNamespace =
  "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
XNamespace w = wordmlNamespace;

using (Package wdPackage = Package.Open(fileName, FileMode.Open, FileAccess.Read))
{
    PackageRelationship docPackageRelationship =
      wdPackage.GetRelationshipsByType(documentRelationshipType).FirstOrDefault();
    if (docPackageRelationship != null)
    {
        Uri documentUri = PackUriHelper.ResolvePartUri(new Uri("/", UriKind.Relative),
          docPackageRelationship.TargetUri);
        PackagePart documentPart = wdPackage.GetPart(documentUri);

        //  Load the document XML in the part into an XDocument instance.
        XDocument xdoc = XDocument.Load(XmlReader.Create(documentPart.GetStream()));

        Console.WriteLine("TargetUri:{0}", docPackageRelationship.TargetUri);
        Console.WriteLine("==================================================================");
        Console.WriteLine(xdoc.Root);
        Console.WriteLine();

        //  Find the styles part. There will only be one.
        PackageRelationship styleRelation =
          documentPart.GetRelationshipsByType(stylesRelationshipType).FirstOrDefault();
        if (styleRelation != null)
        {
            Uri styleUri = PackUriHelper.ResolvePartUri(documentUri, styleRelation.TargetUri);
            PackagePart stylePart = wdPackage.GetPart(styleUri);

            //  Load the style XML in the part into an XDocument instance.
            XDocument styleDoc = XDocument.Load(XmlReader.Create(stylePart.GetStream()));

            Console.WriteLine("TargetUri:{0}", styleRelation.TargetUri);
            Console.WriteLine("==================================================================");
            Console.WriteLine(styleDoc.Root);
            Console.WriteLine();
        }
    }
}
```

```vb
Const fileName As String = "SampleDoc.docx"

Const documentRelationshipType As String = _
  "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"
Const stylesRelationshipType As String = _
  "http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles"
Const wordmlNamespace As String = _
  "http://schemas.openxmlformats.org/wordprocessingml/2006/main"
Dim w As XNamespace = wordmlNamespace

Using wdPackage As Package = Package.Open(fileName, FileMode.Open, FileAccess.Read)
    Dim docPackageRelationship As PackageRelationship = _
      wdPackage.GetRelationshipsByType(documentRelationshipType).FirstOrDefault()
    If docPackageRelationship IsNot Nothing Then
        Dim documentUri As Uri = PackUriHelper.ResolvePartUri(New Uri("/", UriKind.Relative), _
          docPackageRelationship.TargetUri)
        Dim documentPart As PackagePart = wdPackage.GetPart(documentUri)

        ' Load the document XML in the part into an XDocument instance.
        Dim xdoc As XDocument = XDocument.Load(XmlReader.Create(documentPart.GetStream()))

        Console.WriteLine("TargetUri:{0}", docPackageRelationship.TargetUri)
        Console.WriteLine("==================================================================")
        Console.WriteLine(xdoc.Root)
        Console.WriteLine()

        ' Find the styles part. There will only be one.
        Dim styleRelation As PackageRelationship = _
          documentPart.GetRelationshipsByType(stylesRelationshipType).FirstOrDefault()
        If styleRelation IsNot Nothing Then
            Dim styleUri As Uri = _
              PackUriHelper.ResolvePartUri(documentUri, styleRelation.TargetUri)
            Dim stylePart As PackagePart = wdPackage.GetPart(styleUri)

            ' Load the style XML in the part into an XDocument instance.
            Dim styleDoc As XDocument = XDocument.Load(XmlReader.Create(stylePart.GetStream()))

            Console.WriteLine("TargetUri:{0}", styleRelation.TargetUri)
            Console.WriteLine("==================================================================")
            Console.WriteLine(styleDoc.Root)
            Console.WriteLine()
        End If
    End If
End Using
```
