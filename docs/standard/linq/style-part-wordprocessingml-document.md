---
title: Style part of a WordprocessingML document - LINQ to XML
description: See an example of XML that makes up the style part of an Office Open XML WordprocessingML document.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# Style part of a WordprocessingML document (LINQ to XML)

This article shows an example of the XML that makes up the style part of an Office Open XML WordprocessingML document.

## Example: The XML that makes up the style part of a document

The following example is the XML that makes up the style part of an Office Open XML WordprocessingML document.

The default paragraph style has an element with the following opening tag:

```xml
<w:style w:type="paragraph" w:default="1" w:styleId="Normal">
```

You need to know this information when you write the query to find the default style identifier, so that the query can identify the style of paragraphs that have the default style.

Note that these documents are very simple when compared to typical documents that Microsoft Word generates. In many cases, Word saves a great deal of additional information, additional formatting, and metadata. Furthermore, Word doesn't format the lines to be easily readable as in this example; instead, the XML is saved without indentation. However, all WordprocessingML documents share the same basic XML shape. Because of this, the queries presented in this section will work with more complicated documents.

```xml
<?xml version="1.0" encoding="utf-8"?>
<w:styles
    xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships"
    xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
  <w:docDefaults>
    <w:rPrDefault>
      <w:rPr>
        <w:rFonts
            w:ascii="Times New Roman"
            w:eastAsia="Times New Roman"
            w:hAnsi="Times New Roman"
            w:cs="Times New Roman" />
        <w:sz w:val="22" />
        <w:szCs w:val="22" />
        <w:lang w:val="en-US" w:eastAsia="en-US" w:bidi="ar-SA" />
      </w:rPr>
    </w:rPrDefault>
    <w:pPrDefault />
  </w:docDefaults>
  <w:style w:type="paragraph" w:default="1" w:styleId="Normal">
    <w:name w:val="Normal" />
    <w:qFormat />
    <w:rPr>
      <w:sz w:val="24" />
      <w:szCs w:val="24" />
    </w:rPr>
  </w:style>
  <w:style w:type="paragraph" w:styleId="Heading1">
    <w:name w:val="heading 1" />
    <w:basedOn w:val="Normal" />
    <w:next w:val="Normal" />
    <w:link w:val="Heading1Char" />
    <w:uiPriority w:val="99" />
    <w:qFormat />
    <w:rsid w:val="006027C7" />
    <w:pPr>
      <w:keepNext />
      <w:spacing w:before="240" w:after="60" />
      <w:outlineLvl w:val="0" />
    </w:pPr>
    <w:rPr>
      <w:rFonts w:ascii="Arial" w:hAnsi="Arial" w:cs="Arial" />
      <w:b />
      <w:bCs />
      <w:kern w:val="32" />
      <w:sz w:val="32" />
      <w:szCs w:val="32" />
    </w:rPr>
  </w:style>
  <w:style w:type="character" w:default="1" w:styleId="DefaultParagraphFont">
    <w:name w:val="Default Paragraph Font" />
    <w:uiPriority w:val="99" />
    <w:semiHidden />
  </w:style>
  <w:style w:type="table" w:default="1" w:styleId="TableNormal">
    <w:name w:val="Normal Table" />
    <w:uiPriority w:val="99" />
    <w:semiHidden />
    <w:unhideWhenUsed />
    <w:qFormat />
    <w:tblPr>
      <w:tblInd w:w="0" w:type="dxa" />
      <w:tblCellMar>
        <w:top w:w="0" w:type="dxa" />
        <w:left w:w="108" w:type="dxa" />
        <w:bottom w:w="0" w:type="dxa" />
        <w:right w:w="108" w:type="dxa" />
      </w:tblCellMar>
    </w:tblPr>
  </w:style>
  <w:style w:type="numbering" w:default="1" w:styleId="NoList">
    <w:name w:val="No List" />
    <w:uiPriority w:val="99" />
    <w:semiHidden />
    <w:unhideWhenUsed />
  </w:style>
  <w:style w:type="character" w:customStyle="1" w:styleId="Heading1Char">
    <w:name w:val="Heading 1 Char" />
    <w:basedOn w:val="DefaultParagraphFont" />
    <w:link w:val="Heading1" />
    <w:uiPriority w:val="9" />
    <w:rsid w:val="009765E3" />
    <w:rPr>
      <w:rFonts
          w:asciiTheme="majorHAnsi"
          w:eastAsiaTheme="majorEastAsia"
          w:hAnsiTheme="majorHAnsi"
          w:cstheme="majorBidi" />
      <w:b />
      <w:bCs />
      <w:kern w:val="32" />
      <w:sz w:val="32" />
      <w:szCs w:val="32" />
    </w:rPr>
  </w:style>
  <w:style w:type="paragraph" w:customStyle="1" w:styleId="Code">
    <w:name w:val="Code" />
    <w:aliases w:val="c" />
    <w:uiPriority w:val="99" />
    <w:rsid w:val="006027C7" />
    <w:pPr>
      <w:spacing w:after="60" w:line="300" w:lineRule="exact" />
    </w:pPr>
    <w:rPr>
      <w:rFonts w:ascii="Courier New" w:hAnsi="Courier New" />
      <w:noProof />
      <w:color w:val="000080" />
      <w:sz w:val="20" />
      <w:szCs w:val="20" />
    </w:rPr>
  </w:style>
</w:styles>
```
