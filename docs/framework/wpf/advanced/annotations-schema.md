---
title: "Annotations Schema"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "XML schema definition (XSD)"
  - "Microsoft Annotations Framework [WPF]"
  - "documents [WPF], annotations"
ms.assetid: a893442b-e220-4603-bf6a-b01fefcb4b37
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Annotations Schema
This topic describes the XML schema definition (XSD) used by the Microsoft Annotations Framework to save and retrieve user annotation data.  
  
 The [!INCLUDE[TLA2#tla_caf](../../../../includes/tla2sharptla-caf-md.md)] serializes annotation data from an internal representation to an XML format.  The XML format used for this conversion is described by the [!INCLUDE[TLA2#tla_caf](../../../../includes/tla2sharptla-caf-md.md)] XSD Schema.  The schema defines the implementation-independent XML format that can be used to exchange annotation data between applications.  
  
 The [!INCLUDE[TLA2#tla_caf](../../../../includes/tla2sharptla-caf-md.md)] XML schema definition consists of two subschemas  
  
-   The Annotations XML Core Schema (Core Schema).  
  
-   The Annotations XML Base Schema (Base Schema).  
  
 The Core Schema defines the primary XML structure of an <xref:System.Windows.Annotations.Annotation>.  The majority of XML elements defined in the Core Schema correspond to types in the <xref:System.Windows.Annotations> namespace.  The Core Schema exposes three extension points where applications can add their own XML data.  These extension points include the <xref:System.Windows.Annotations.Annotation.Authors%2A>, <xref:System.Windows.Annotations.ContentLocatorPart>, and "Content".  (Content elements are provided in the form of an <xref:System.Xml.XmlElement> list.)  
  
 The Base Schema described in this topic defines the extensions for the <xref:System.Windows.Annotations.Annotation.Authors%2A>, <xref:System.Windows.Annotations.ContentLocatorPart>, and Content types included with the initial [!INCLUDE[TLA#tla_wpf](../../../../includes/tlasharptla-wpf-md.md)] release.  
  
<a name="CoreSchema"></a>   
## Annotations XML Core Schema  
 The Annotations XML Core Schema defines the XML structure that is used to store <xref:System.Windows.Annotations.Annotation> objects.  
  
```xml  
<xsd:schema elementFormDefault="qualified" attributeFormDefault="unqualified"  
            blockDefault="#all"  
            xmlns:xsd="http://www.w3.org/2001/XMLSchema"  
            targetNamespace="http://schemas.microsoft.com/windows/annotations/2003/11/core"  
            xmlns:anc="http://schemas.microsoft.com/windows/annotations/2003/11/core">  
  
  <!--  The Annotations element groups a number of annotations.  -->  
  <xsd:element name="Annotations" type="anc:AnnotationsType" />  
  
  <xsd:complexType name="AnnotationsType">  
    <xsd:sequence>  
      <xsd:element name="Annotation" minOccurs="0" maxOccurs="unbounded"  
                   type="anc:AnnotationType" />  
    </xsd:sequence>  
  </xsd:complexType>  
  
  <!-- AnnotationType defines the structure of the Annotation element. -->  
  <xsd:complexType name="AnnotationType">  
    <xsd:sequence>  
  
      <!-- List of 0 or more authors. -->  
      <xsd:element name="Authors" minOccurs="0" maxOccurs="1"  
                   type="anc:AuthorListType" />  
  
      <!-- List of 0 or more anchors. -->  
      <xsd:element name="Anchors" minOccurs="0" maxOccurs="1"  
                   type="anc:ResourceListType" />  
  
      <!-- List of 0 or more cargos. -->  
      <xsd:element name="Cargos" minOccurs="0" maxOccurs="1"  
                   type="anc:ResourceListType" />  
  
    </xsd:sequence>  
  
    <!-- Unique annotation ID. -->  
    <xsd:attribute name="Id" type="xsd:string" use="required" />  
  
    <!-- Annotation "Type" is used to map the annotation to an annotation  
         component that takes care of the visual representation of the  
         annotation.  WPF V1 recognizes three annotation types:  
  http://schemas.microsoft.com/windows/annotations/2003/11/base:Highlight  
  http://schemas.microsoft.com/windows/annotations/2003/11/base:TextStickyNote  
  http://schemas.microsoft.com/windows/annotations/2003/11/base:InkStickyNote  
    -->  
    <xsd:attribute name="Type" type="xsd:QName" use="required" />  
  
    <!--  Time when the annotation was last modified.  -->  
    <xsd:attribute name="LastModificationTime" use="optional"  
                   type="xsd:dateTime" />  
  
    <!--  Time when the annotation was created.  -->  
    <xsd:attribute name="CreationTime" use="optional"  
                   type="xsd:dateTime" />  
  </xsd:complexType>  
  
  <!-- "Authors" consists of 0 or more elements that represent an author. -->  
  <xsd:complexType name="AuthorListType">  
    <xsd:sequence minOccurs="0" maxOccurs="unbounded">  
      <xsd:element ref="anc:Author" />  
    </xsd:sequence>  
  </xsd:complexType>  
  
  <!-- The core schema allows any author type. Supported author types  
       in version 1 (V1) are described in the base schema. -->  
  <xsd:element name="Author" abstract="true" block="extension restriction"/>  
  
  <!-- Both annotation anchor and annotation cargo are represented by the  
       ResourceListType which contains 0 or more "Resource" elements. -->  
  <xsd:complexType name="ResourceListType">  
    <xsd:sequence>  
      <xsd:element name="Resource" minOccurs="0" maxOccurs="unbounded"  
                   type="anc:ResourceType" />  
    </xsd:sequence>  
  </xsd:complexType>  
  
  <!-- Resource groups identification, location  
       and/or content of some information.  -->  
  <xsd:complexType name="ResourceType">  
    <xsd:choice minOccurs="0" maxOccurs="unbounded" >  
      <xsd:choice>  
        <xsd:element name="ContentLocator" type="anc:ContentLocatorType" />  
        <xsd:element name="ContentLocatorGroup" type="anc:ContentLocatorGroupType" />  
      </xsd:choice>  
      <xsd:element ref="anc:Content"/>  
    </xsd:choice>  
  
    <!-- Unique resource identifier. -->  
    <xsd:attribute name="Id" type="xsd:string" use="required" />  
  
    <!-- Optional resource name. -->  
    <xsd:attribute name="Name" type="xsd:string" use="optional" />  
  </xsd:complexType>  
  
  <!-- ContentLocatorGroup contains a set of ContentLocators -->  
  <xsd:complexType name="ContentLocatorGroupType">  
    <xsd:sequence>  
      <xsd:element name="ContentLocator" minOccurs="1" maxOccurs="unbounded"  
                   type="anc:ContentLocatorType" />  
    </xsd:sequence>  
  </xsd:complexType>  
  
  <!-- A ContentLocator describes the location or the identification  
       of particular data within some context.  The ContentLocator consists  
       of one or more ContentLocatorParts.  Each ContentLocatorPart needs to  
       be successively applied to the context to arrive at the data.  What  
       "applying", "context", and "data" mean is application dependent.  
  -->  
  <xsd:complexType name="ContentLocatorType">  
    <xsd:sequence minOccurs="1" maxOccurs="unbounded">  
      <xsd:element ref="anc:ContentLocatorPart" />  
    </xsd:sequence>  
  </xsd:complexType>  
  
  <!-- A ContentLocatorPart is a set of "Item" elements.  Each "Item" element  
       has "Name" and "Value" attributes that define a name/value pair.  
       ContentLocatorPart is an abstract type that must be restricted for each  
       concrete ContentLocatorPart definition.  This restriction should define  
       allowed names and values for the concrete ContentLocatorPart type. That  
       way the application can define its own way of locating information. The   
       ContentLocatorPartTypes that are allowed in version 1 (V1) of WPF are  
       defined in the Annotations Base Schema.  
  -->  
  <xsd:element name="ContentLocatorPart" type="anc:ContentLocatorPartType"  
               abstract="true" />  
  
  <xsd:complexType name="ContentLocatorPartType" abstract="true"  
                   block="restriction">  
    <xsd:sequence minOccurs="0" maxOccurs="unbounded">  
      <xsd:element name="Item" type="anc:ItemType" />  
    </xsd:sequence>  
  </xsd:complexType>  
  
  <xsd:complexType name="ItemType" abstract="true" >  
    <xsd:attribute name="Name" type='xsd:string' use="required" />  
    <xsd:attribute name="Value" type='xsd:string' use="optional" />  
  </xsd:complexType>  
  
  <!-- Content describes the underlying content of a resource.  This is an  
       abstract type that should be redefined for each concrete content type  
       through restriction.  Allowed content types in WPF version 1 are  
       defined in the Annotations Base Schema.  
  -->  
  <xsd:element name="Content" abstract="true" block="extension restriction"/>  
  
</xsd:schema>  
```  
  
<a name="BaseSchema"></a>   
## Annotations XML Base Schema  
 The Base Schema defines the XML structure for the three abstract elements defined in the Core Schema – <xref:System.Windows.Annotations.Annotation.Authors%2A>, <xref:System.Windows.Annotations.ContentLocatorPart>, and <xref:System.Windows.Annotations.AnnotationResource.Contents%2A>.  
  
```xml  
<xsd:schema elementFormDefault="qualified" attributeFormDefault="unqualified"  
     blockDefault="#all"  
     xmlns:xsd="http://www.w3.org/2001/XMLSchema"  
     targetNamespace="http://schemas.microsoft.com/windows/annotations/2003/11/base"  
     xmlns:anb="http://schemas.microsoft.com/windows/annotations/2003/11/base"   
     xmlns:anc="http://schemas.microsoft.com/windows/annotations/2003/11/core">  
  
  <xsd:import schemaLocation="AnnotationCoreV1.xsd"  
       namespace="http://schemas.microsoft.com/windows/annotations/2003/11/core"/>  
  
  <!-- ***** Author ***** -->  
  <!-- Simple DisplayName Author -->  
  <xsd:complexType name="StringAuthorType">  
    <xsd:simpleContent >  
      <xsd:extension base='xsd:string' />  
    </xsd:simpleContent>  
  </xsd:complexType>  
  <xsd:element name="StringAuthor" type="anb:StringAuthorType"  
               substitutionGroup="anc:Author"/>  
  
  <!-- ***** LocatorParts ***** -->  
  
  <!-- Helper types -->  
  
  <!-- CountItemNameType - helper type to define count item -->  
  <xsd:simpleType name="CountItemNameType">  
    <xsd:restriction base='xsd:string'>  
      <xsd:pattern value="Count" />  
    </xsd:restriction>  
  </xsd:simpleType>  
  
  <!-- NumberType - helper type to define segment count item -->  
  <xsd:simpleType name="NumberType">  
    <xsd:restriction base='xsd:string'>  
      <xsd:pattern value="\d*" />  
    </xsd:restriction>  
  </xsd:simpleType>  
  
  <!-- SegmentNameType: helper type to define possible segment name types -->  
  <xsd:simpleType name="SegmentItemNameType">  
    <xsd:restriction base='xsd:string'>  
      <xsd:pattern value="Segment\d*" />  
    </xsd:restriction>  
  </xsd:simpleType>  
  
  <!-- Flow Locator Part -->  
  
  <!-- FlowSegmentValueItemType: helper type to define flow segment values -->  
  <xsd:simpleType name="FlowSegmentItemValueType">  
    <xsd:restriction base='xsd:string'>  
      <xsd:pattern value=" \d*,\d*" />  
    </xsd:restriction>  
  </xsd:simpleType>  
  
  <!-- FlowItemType -->  
  <xsd:complexType name="FlowItemType" abstract = "true">  
    <xsd:complexContent>  
      <xsd:restriction base="anc:ItemType">  
      </xsd:restriction>  
   </xsd:complexContent>  
  </xsd:complexType>  
  
  <!-- FlowSegmentItemType -->  
  <xsd:complexType name="FlowSegmentItemType">  
    <xsd:complexContent>  
      <xsd:restriction base="anb:FlowItemType">  
        <xsd:attribute name="Name" use="required"  
                       type="anb:SegmentItemNameType"/>  
        <xsd:attribute name="Value" use="required"  
                       type="anb:FlowSegmentItemValueType"/>  
       </xsd:restriction>  
    </xsd:complexContent>  
 </xsd:complexType>  
  
  <!-- FlowCountItemType -->  
  <xsd:complexType name="FlowCountItemType">  
    <xsd:complexContent>  
      <xsd:restriction base="anb:FlowItemType">  
        <xsd:attribute name="Name" type="anb:CountItemNameType" use="required"/>  
        <xsd:attribute name="Value" type="anb:NumberType" use="required"/>  
       </xsd:restriction>  
    </xsd:complexContent>  
  </xsd:complexType>  
  
  <!-- CharacterRangeType is an extension of ContentLocatorPartType that locates  
  *    part of the content within a FlowDocument. CharacterRangeType contains one  
  *    "Item" element with name "Count" and value the number(N) of "SegmentXX"  
  *    elements that this ContentLocatorPart has.  It also contains N "Item"  
  *    elements with name "SegmentXX" where XX is a number from 0 to N-1. The  
  *    value of each "SegmnetXX" element is a string in the form "offset, length"  
  *    which locates one sequence of symbols in the FlowDocument. Example:  
  
  *        <anb:CharacterRange>  
  *          <anc:Item Name="Count" Value="2" />  
  *          <anc:Item Name="Segment0" Value="5,10" />  
  *          <anc:Item Name="Segment1" Value="25,2" />  
  *        </anb:ChacterRange>  
  -->  
  <xsd:complexType name="CharacterRangeType">  
    <xsd:complexContent>  
      <xsd:extension base="anc:ContentLocatorPartType">  
        <xsd:sequence minOccurs="1" maxOccurs="unbounded">  
          <xsd:element name="Item" type="anb:FlowItemType" />  
        </xsd:sequence>  
      </xsd:extension>  
    </xsd:complexContent>  
  </xsd:complexType>  
  
  <!-- CharacterRange element substitutes ContentLocatorPart element -->  
  <xsd:element name="CharacterRange" type="anb:CharacterRangeType"  
               substitutionGroup="anc:ContentLocatorPart"/>  
  
  <!-- Fixed LocatorPart -->  
  
  <!-- Helper type – FixedItemType -->  
  <xsd:complexType name="FixedItemType" abstract = "true">  
    <xsd:complexContent>  
      <xsd:restriction base="anc:ItemType">  
      </xsd:restriction>  
    </xsd:complexContent>  
  </xsd:complexType>  
  
  <!-- Helper type – FixedCountItemType: ContentLocatorPart items count -->  
  <xsd:complexType name="FixedCountItemType">  
    <xsd:complexContent>  
      <xsd:restriction base="anb:FixedItemType">  
        <xsd:attribute name="Name" type="anb:CountItemNameType" use="required"/>  
        <xsd:attribute name="Value" type="anb:NumberType" use="required"/>  
      </xsd:restriction>  
    </xsd:complexContent>  
  </xsd:complexType>  
  
  <!-- Helper type -FixedSegmentValue: Defines possible fixed segment values -->  
  <xsd:simpleType name="FixedSegmentItemValueType">  
     <xsd:restriction base='xsd:string'>  
        <xsd:pattern value="\d*,\d*,\d*,\d*" />  
     </xsd:restriction>  
  </xsd:simpleType>  
  
  <!-- Helper type - FixedSegmentItemType -->  
  <xsd:complexType name="FixedSegmentItemType">  
    <xsd:complexContent>  
      <xsd:restriction base="anb:FixedItemType">  
        <xsd:attribute name="Name" use="required"  
                       type="anb:SegmentItemNameType"/>  
        <xsd:attribute name="Value" use="required"  
                       type="anb:FixedSegmentItemValueType "/>  
      </xsd:restriction>  
    </xsd:complexContent>  
  </xsd:complexType>  
  
  <!-- FixedTextRangeType is an extension of ContentLocatorPartType that locates  
  *    content within a FixedDocument.  It contains one "Item" element with name  
  *    "Count" and value the number (N) of "Item" elements with name "SegmentXX"  
  *    that this ContentLocatorPart has.  FixedTextRange locator part also  
  *    contains N "Item" elements with one attribute Name="SegmentXX" where XX is  
  *    a number from 0 to N-1 and one attribute "Value" in the form "X1, Y1, X2,  
  *    Y2".  Here X1,Y1 are the coordinates of the start symbol in this segment,  
  *    X2,Y2 are the coordinates of the end symbol in this segment.  Example:  
  *  
  *        <anb:FixedTextRange>  
  *          <anc:Item Name="Count" Value="2" />  
  *          <anc:Item Name="Segment0" Value="10,5,20,5" />  
  *          <anc:Item Name="Segment1" Value="25,15, 25,20" />  
  *        </anb:FixedTextRange>  
  -->  
  <xsd:complexType name="FixedTextRangeType">  
     <xsd:complexContent>  
        <xsd:extension base="anc:ContentLocatorPartType">  
           <xsd:sequence minOccurs="1" maxOccurs="unbounded">  
              <xsd:element name="Item" type="anb:FixedItemType" />  
           </xsd:sequence>  
       </xsd:extension>  
     </xsd:complexContent>  
  </xsd:complexType>  
  
  <!-- FixedTextRange element substitutes ContentLocatorPart element -->  
  <xsd:element name="FixedTextRange" type="anb:FixedTextRangeType"  
               substitutionGroup="anc:ContentLocatorPart"/>  
  
  <!-- DataId -->  
  
  <!-- ValueItemNameType: helper type to define value item -->  
  <xsd:simpleType name="ValueItemNameType">  
    <xsd:restriction base='xsd:string'>  
      <xsd:pattern value="Value" />  
    </xsd:restriction>  
  </xsd:simpleType>  
  
  <!-- StringValueItemType -->  
  <xsd:complexType name="StringValueItemType">  
     <xsd:complexContent>  
        <xsd:restriction base="anc:ItemType">  
           <xsd:attribute name="Name" type="anb:ValueItemNameType" use="required"/>  
        <xsd:attribute name="Value" type="xsd:string" use="required"/>  
        </xsd:restriction>  
     </xsd:complexContent>  
  </xsd:complexType>  
  
  <xsd:complexType name="StringValueLocatorPartType">  
    <xsd:complexContent>  
      <xsd:extension base="anc:ContentLocatorPartType">  
        <xsd:sequence minOccurs="1" maxOccurs="1">  
          <xsd:element name="Item" type="anb:ValueItemType" />  
        </xsd:sequence>  
      </xsd:extension>  
    </xsd:complexContent>  
  </xsd:complexType>  
  
  <!-- DataId element substitutes ContentLocatorPart and is used to locate a  
  *    subtree in the logical tree.  Including DataId locator part in a  
  *    ContentLocator helps to narrow down the search for a particular content.  
  *    Examle of DataId ContentLocatorPart:  
  *      
  *        <anb:DataId>  
  *          <anc:Item Name="Value" Value="FlowDocument" />  
  *        </anb:DataId>  
  -->  
  
  <xsd:element name="DataId" type="anb: StringValueLocatorPartType "  
               substitutionGroup="anc:ContentLocatorPart"/>  
  
  <!-- PageNumber -->  
  
  <!-- NumberValueItemType -->  
  <xsd:complexType name="NumberValueItemType">  
    <xsd:complexContent>  
      <xsd:restriction base="anc:ItemType">  
        <xsd:attribute name="Name" type="anb:ValueItemNameType" use="required"/>  
        <xsd:attribute name="Value" type="anb:NumberType" use="required"/>  
      </xsd:restriction>  
    </xsd:complexContent>  
  </xsd:complexType>  
  
  <xsd:complexType name="NumberValueLocatorPartType">  
    <xsd:complexContent>  
      <xsd:extension base="anc:ContentLocatorPartType">  
        <xsd:sequence minOccurs="1" maxOccurs="1">  
          <xsd:element name="Item" type="anb:ValueItemType" />  
        </xsd:sequence>  
      </xsd:extension>  
    </xsd:complexContent>  
  </xsd:complexType>  
  
  <-- PageNumber element substitutes ContentLocatorPart and is used to locate a  
  *  page in a FixedDocument.  PageNumber ContentLocatorPart is used in  
  *   conjunction with the FixedTextRange ContentLocatorPart and it shows on with  
  *   page are the coordinates defined in the FixedTextRange.  
  *   Example of a PageNumber ContentLocatorPart:  
  *     
  *       <anb:PageNumber>  
  *         <anc:Item Name="Value" Value="1" />  
  *       </anb:PageNumber>  
  -->  
  <xsd:element name="PageNumber" type="anb:NumbnerValueLocatorPartType"  
               substitutionGroup="anc:ContentLocatorPart"/>  
  
  <!-- ***** Content ***** -->  
  <!-- Highlight colors – defines highlight color for annotations of type  
  *    Highlight or normal and active anchor colors for annotations of type  
  *    TextStickyNote and InkStickyNote.   
  -->  
  <xsd:complexType name="ColorsContentType">  
    <xsd:attribute name="Background" type='xsd:string' use="required" />  
    <xsd:attribute name="ActiveBackground" type='xsd:string' use="optional" />  
  </xsd:complexType>  
  
  <xsd:element name="Colors" type="anb:ColorsContentType"  
               substitutionGroup="anc:Content"/>  
  
  <!-- RTB Text –contains XAML representing StickyNote Reach Text Box text.  
  *    Used in annotations of type TextStickyNote. -->  
  <xsd:complexType name="TextContentType">  
    <!-- See XAML schema for RTB content -->  
  </xsd:complexType>  
  
  <xsd:element name="Text" type="anb:TextContentType"  
               substitutionGroup="anc:Content"/>  
  
  <-- Ink – contains XAML representing Sticky Note ink.  
  *   Used in annotations of type InkStickyNote. -->  
  <xsd:complexType name="InkContentType">  
    <!-- See XAML schema for Ink content -->  
  </xsd:complexType>  
  
  <xsd:element name="Ink" type="anb:InkContentType"  
               substitutionGroup="anc:Content"/>  
  
  <!-- SN Metadata – defines StickyNote attributes as position width, height,  
  *    etc.  Used in annotations of type TextStickyNote and InkStickyNote. -->  
  <xsd:complexType name="MetadataContentType">  
    <xsd:attribute name="Left" type='xsd:decimal' use="optional"  />  
    <xsd:attribute name="Top" type='xsd:decimal' use="optional" />  
    <xsd:attribute name="Width" type='xsd:decimal' use="optional" />  
    <xsd:attribute name="Height" type='xsd:decimal' use="optional" />  
    <xsd:attribute name="XOffset" type='xsd:decimal' use="optional" />  
    <xsd:attribute name="YOffset" type='xsd:decimal' use="optional" />  
    <xsd:attribute name="ZOrder" type='xsd:decimal' use="optional" />  
  </xsd:complexType>  
  
  <xsd:element name="Metadata" type="anb:MetadataContentType"   
               substitutionGroup="anc:Content"/>  
  
</xsd:schema>  
```  
  
<a name="SampleXML"></a>   
## Sample XML Produced by Annotations XmlStreamStore  
 The XML that follows shows the output of an Annotations <xref:System.Windows.Annotations.Storage.XmlStreamStore> and the organization of a sample file that contains three annotations - a highlight, a text sticky-note, and an ink stick-note.  
  
```xml  
<?xml version="1.0" encoding="utf-8"?>  
<anc:Annotations  
     xmlns:anc="http://schemas.microsoft.com/windows/annotations/2003/11/core"  
     xmlns:anb="http://schemas.microsoft.com/windows/annotations/2003/11/base">  
  
  <anc:Annotation Id="d308ea9b-36eb-4cc4-94d0-97634f10f7a2"  
                  CreationTime="2006-09-13T18:28:51.4465702-07:00"  
                  LastModificationTime="2006-09-13T18:28:51.4465702-07:00"  
                  Type="anb:Highlight">  
    <anc:Anchors>  
      <anc:Resource Id="4f53661b-7328-4673-8e3f-c53f08b9cd94">  
        <anc:ContentLocator>  
          <anb:DataId>  
            <anc:Item Name="Value" Value="FlowDocument" />  
          </anb:DataId>  
          <anb:CharacterRange>  
            <anc:Item Name="Segment0" Value="600,609" />  
            <anc:Item Name="Count" Value="1" />  
          </anb:CharacterRange>  
        </anc:ContentLocator>  
      </anc:Resource>  
    </anc:Anchors>  
  </anc:Annotation>  
  
  <anc:Annotation Id="d7a8d271-387e-4144-9f8b-bc3c97816e5f"  
                  CreationTime="2006-09-13T18:28:56.7903202-07:00"  
                  LastModificationTime="2006-09-13T18:28:56.8996952-07:00"  
                  Type="anb:TextStickyNote">  
    <anc:Authors>  
      <anb:StringAuthor>Denise Smith</anb:StringAuthor>  
    </anc:Authors>  
  
    <anc:Anchors>  
      <anc:Resource Id="dab2560e-6ebd-4ad0-80f9-483356a3be0b">  
        <anc:ContentLocator>  
          <anb:DataId>  
            <anc:Item Name="Value" Value="FlowDocument" />  
          </anb:DataId>  
          <anb:CharacterRange>  
            <anc:Item Name="Segment0" Value="787,801" />  
            <anc:Item Name="Count" Value="1" />  
          </anb:CharacterRange>  
        </anc:ContentLocator>  
      </anc:Resource>  
    </anc:Anchors>  
  
    <anc:Cargos>  
      <anc:Resource Id="ea4dbabd-b400-4cf9-8908-5716b410f9e4" Name="Meta Data">  
        <anb:MetaData anb:ZOrder="0" />  
      </anc:Resource>  
    </anc:Cargos>  
  </anc:Annotation>  
  
  <anc:Annotation Id="66803c69-b0d7-4cc3-bdff-cacc1955e806"  
                  CreationTime="2006-09-13T18:29:03.6653202-07:00"  
                  LastModificationTime="2006-09-13T18:29:03.7121952-07:00"  
                  Type="anb:InkStickyNote">  
    <anc:Authors>  
      <anb:StringAuthor>Mike Nash</anb:StringAuthor>  
    </anc:Authors>  
  
    <anc:Anchors>  
      <anc:Resource Id="52251c53-8eeb-4fd7-b8f3-94e78dfc25fa">  
        <anc:ContentLocator>  
          <anb:DataId>  
            <anc:Item Name="Value" Value="FlowDocument" />  
          </anb:DataId>  
          <anb:CharacterRange>  
            <anc:Item Name="Segment0" Value="880,884" />  
            <anc:Item Name="Count" Value="1" />  
          </anb:CharacterRange>  
        </anc:ContentLocator>  
      </anc:Resource>  
    </anc:Anchors>  
  
    <anc:Cargos>  
      <anc:Resource Id="11e50b97-8d91-4ff9-82c3-16607b2b552b" Name="Meta Data">  
        <anb:MetaData anb:ZOrder="1" />  
      </anc:Resource>  
    </anc:Cargos>  
  </anc:Annotation>  
  
</anc:Annotations>  
```  
  
## See Also  
 <xref:System.Windows.Annotations>  
 <xref:System.Windows.Annotations.Storage>  
 <xref:System.Windows.Annotations.Annotation>  
 <xref:System.Windows.Annotations.Storage.AnnotationStore>  
 <xref:System.Windows.Annotations.Storage.XmlStreamStore>  
 [Annotations Overview](../../../../docs/framework/wpf/advanced/annotations-overview.md)
