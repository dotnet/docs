---
title: "Mapping Between JSON and XML"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 22ee1f52-c708-4024-bbf0-572e0dae64af
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Mapping Between JSON and XML
The readers and writers produced by the <xref:System.Runtime.Serialization.Json.JsonReaderWriterFactory> provide an XML API over JavaScript Object Notation (JSON) content. JSON encodes data using a subset of the object literals of JavaScript. The readers and writers produced by this factory are also used when JSON content is being sent or received by [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] applications using the <xref:System.ServiceModel.Channels.WebMessageEncodingBindingElement> or the <xref:System.ServiceModel.WebHttpBinding>.  
  
 When initialized with JSON content, the JSON reader behaves in the same way that a textual XML reader does over an instance of XML. The JSON writer, when given a sequence of calls that on a textual XML reader produces a certain XML instance, writes out JSON content. The mapping between this instance of XML and the JSON content is described in this topic for use in advanced scenarios.  
  
 Internally, JSON is represented as an XML infoset when processed by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. Normally you do not have to be concerned with this internal representation as the mapping is only a logical one: JSON is normally not physically converted to XML in memory or converted to JSON from XML. The mapping means that XML APIs are used to access JSON content.  
  
 When [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses JSON, the usual scenario is that the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> is automatically plugged in by the <xref:System.ServiceModel.Description.WebScriptEnablingBehavior> behavior, or by the <xref:System.ServiceModel.Description.WebHttpBehavior> behavior when appropriate. The <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> understands the mapping between JSON and the XML infoset and acts as if it is dealing with JSON directly. (It is possible to use the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> with any XML reader or writer, with the understanding that the XML conforms to the following mapping.)  
  
 In advanced scenarios, it may become necessary to directly access the following mapping. These scenarios occur when you want to serialize and deserialize JSON in custom ways, without relying on the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>, or when dealing with the <xref:System.ServiceModel.Channels.Message> type directly for messages containing JSON. The JSON-XML mapping is also used for message logging. When using the message logging feature in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], JSON messages is logged as XML according to the mapping described in the next section.  
  
 To clarify the concept of a mapping, the following example is of a JSON document.  
  
```json  
{"product":"pencil","price":12}  
```  
  
 To read this JSON document using one of the readers previously mentioned, use the same sequence of <xref:System.Xml.XmlDictionaryReader> calls as you would to read the following XML document.  
  
```xml  
<root type="object">  
    <product type="string">pencil</product>  
    <price type="number">12</price>  
</root>  
```  
  
 Furthermore, if the JSON message in the example is received by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and logged, you would see the XML fragment in the preceding log.  
  
## Mapping Between JSON and the XML Infoset  
 Formally, the mapping is between JSON as described in [RFC 4627](http://go.microsoft.com/fwlink/?LinkId=98808) (except with certain restrictions relaxed and certain other restrictions added) and the XML infoset (and not textual XML) as described in [XML Information Set](http://go.microsoft.com/fwlink/?LinkId=98809) . See this topic for the definitions of *information items* and fields in [square brackets].  
  
 A blank JSON document maps to blank XML document, and a blank XML document maps to a blank JSON document. On the XML to JSON mapping, preceding whitespace and trailing whitespace after the document are not allowed.  
  
 The mapping is defined between either a Document Information Item (DII) or an Element Information Item (EII) and JSON. The EII, or the DII’s [document element] property, is referred to as the Root JSON Element. Note that document fragments (XML with multiple root elements) are not supported in this mapping.  
  
 Example: The following document:  
  
 `<?xml version="1.0"?>`  
  
 `<root type="number">42</root>`  
  
 And the following element:  
  
 `<root type="number">42</root>`  
  
 Both have a mapping to JSON. The <`root`> element is the Root JSON Element in both cases.  
  
 Furthermore, in the case of a DII, the following should be considered:  
  
-   Some items in the [children] list must not be present. Do not rely on this fact when reading XML mapped from JSON.  
  
-   The [children] list holds no comment information items.  
  
-   The [children] list holds no DTD information items.  
  
-   The [children] list holds no personal Information (PI) information items (the \<?xml…> declaration is not considered a PI information item)  
  
-   The [notations] set is empty.  
  
-   The [unparsed entities] set is empty.  
  
 Example: The following document has no mapping to JSON because [children] holds a PI and a comment.  
  
 `<?xml version="1.0"?>`  
  
 `<!--comment--><?pi?>`  
  
 `<root type="number">42</root>`  
  
 The EII for the Root JSON Element has the following characteristics:  
  
-   [local name] has the value "root".  
  
-   [namespace name] has no value.  
  
-   [prefix] has no value.  
  
-   [children] may either contain EIIs (which represent Inner Elements as described further) or CIIs (Character Information Items as described further) or none of these, but not both.  
  
-   [attributes] may contain the following optional attribute information items (AIIs)  
  
-   The JSON Type Attribute ("type") as described further. This attribute is used to preserve the JSON type (string, number, boolean, object, array or null) in the mapped XML.  
  
-   The Data Contract Name Attribute ("__type") as described further. This attribute is can only be present if the JSON type attribute is also present and its [normalized value] is "object". This attribute is used by the `DataContractJsonSerializer` to preserve data contract type information - for example, in polymorphic cases where a derived type is serialized and where a base type is expected. If you are not working with the `DataContractJsonSerializer`, in most cases, this attribute is ignored.  
  
-   [in-scope namespaces] contains the binding of "xml" to "http://www.w3.org/XML/1998/namespace" as mandated by the infoset specification.  
  
-   [children], [attributes] and [in-scope namespaces] must not have any items other than as specified previously and [namespace attributes] must have no members, but do not rely on these facts when reading XML mapped from JSON.  
  
 Example: The following document has no mapping to JSON because [namespace attributes] is not empty.  
  
 `<?xml version="1.0"?>`  
  
 `<root  xmlns:a="myattributevalue">42</root>`  
  
 The AII for the JSON Type Attribute has the following characteristics:  
  
-   [namespace name] has no value.  
  
-   [prefix] has no value.  
  
-   [local name] is "type".  
  
-   [normalized value] is one of the possible type values described in the following section.  
  
-   [specified] is `true`.  
  
-   [attribute type] has no value.  
  
-   [references] has no value.  
  
 The AII for the Data Contract Name Attribute has the following characteristics:  
  
-   [namespace name] has no value.  
  
-   [prefix] has no value.  
  
-   [local name] is "__type" (two underscores and then "type").  
  
-   [normalized value] is any valid Unicode string – the mapping of this string to JSON is described in the following section.  
  
-   [specified] is `true`.  
  
-   [attribute type] has no value.  
  
-   [references] has no value.  
  
 Inner elements contained within the Root JSON Element or other inner elements have the following characteristics:  
  
-   [local name] may have any value as described further  
  
-   [namespace name], [prefix], [children], [attributes], [namespace attributes], and [in-scope namespaces] are subject to the same rules as the Root JSON Element.  
  
 In both the Root JSON Element and the inner elements, the JSON Type Attribute defines the mapping to JSON and the possible [children] and their interpretation. The attribute’s [normalized value] is case-sensitive and must be lowercase, and cannot contain whitespace.  
  
|[normalized value] of `JSON Type Attribute`’s AII|Allowed [children] of the corresponding EII|Mapping to JSON|  
|---------------------------------------------------------|---------------------------------------------------|---------------------|  
|`string` (or absence of the JSON type AII)<br /><br /> A `string` and the absence of the JSON type AII are the same makes `string` the default.<br /><br /> So, `<root> string1</root>` maps to the JSON `string` "string1".|0 or more CIIs|A JSON `string` (JSON RFC, section 2.5). Each `char` is a character that corresponds to the [character code] from the CII. If there are no CIIs, it maps to an empty JSON `string`.<br /><br /> Example: The following element maps to a JSON fragment:<br /><br /> `<root type="string">42</root>`<br /><br /> The JSON fragment is "42".<br /><br /> On XML to JSON mapping, characters that must be escaped map to escaped characters, all others map to characters that are not escaped. The "/" character is special – it is escaped even though it does not have to be (written out as "\\/").<br /><br /> Example: The following element maps to a JSON fragment.<br /><br /> `<root type="string">the "da/ta"</root>`<br /><br /> The JSON fragment is "the \\"da\\/ta\\"".<br /><br /> On JSON to XML mapping, any escaped characters and characters that are not escaped map correctly to the corresponding [character code].<br /><br /> Example: The JSON fragment "\u0041BC", maps to the following XML element.<br /><br /> `<root type="string">ABC</root>`<br /><br /> The string can be surrounded by whitespace ('ws' in section 2 of the JSON RFC) that does not get mapped to XML.<br /><br /> Example: The JSON fragment           "ABC", (there are spaces before the first double quote), maps to the following XML element.<br /><br /> `<root type="string">ABC</root>`<br /><br /> Any whitespace in XML maps to whitespace in JSON.<br /><br /> Example: The following XML element maps to a JSON fragment.<br /><br /> `<root type="string">  A BC      </root>`<br /><br /> The JSON fragment is " A BC ".|  
|`number`|1 or more CIIs|A JSON `number` (JSON RFC, section 2.4), possibly surrounded by whitespace. Each character in the number/whitespace combination is a character that corresponds to the [character code] from the CII.<br /><br /> Example: The following element maps to a JSON fragment.<br /><br /> `<root type="number">    42</root>`<br /><br /> The JSON fragment is    42<br /><br /> (Whitespace is preserved).|  
|`boolean`|4 or 5 CIIs (which corresponds to `true` or `false`), possibly surrounded by additional whitespace CIIs.|A CII sequence that corresponds to the string "true" is mapped to the literal `true`, and a CII sequence that corresponds to the string "false" is mapped to the literal `false`. Surrounding whitespace is preserved.<br /><br /> Example: The following element maps to a JSON fragment.<br /><br /> `<root type="boolean"> false</root>`<br /><br /> The JSON fragment is `false`.|  
|`null`|None allowed.|The literal `null`. On JSON to XML mapping, the `null` may be surrounded by whitespace (‘ws’ in section 2) that does not get mapped to XML.<br /><br /> Example: The following element maps to a JSON fragment.<br /><br /> `<root type="null"/>`<br /><br /> or<br /><br /> `<root type="null"></root>`<br /><br /> :<br /><br /> The JSON fragment in both cases is `Null`.|  
|`object`|0 or more EIIs.|A `begin-object` (left curly brace) as in section 2.2 of the JSON RFC, followed by a member record for each EII as described further. If there is more than one EII, there are value-separators (commas) between the member records. All this is followed by an end-object (right curly brace).<br /><br /> Example: The following element maps to the JSON fragment.<br /><br /> \<root type="object"><br /><br /> \<type1 type="string">aaa\</type1><br /><br /> \<type2 type="string">bbb\</type2><br /><br /> \</root ><br /><br /> The JSON fragment is {"type1":"aaa","type2":"bbb"}.<br /><br /> If the Data Contract Type Attribute is present on XML to JSON mapping, then an additional Member Record is inserted at the beginning. Its name is the [local name] of the Data Contract Type Attribute ("__type"), and its value is the attribute's [normalized value]. Conversely, on JSON to XML mapping, if the first member-record’s name is the [local name] of the Data Contract Type Attribute (that is, "\__type"), a corresponding Data Contract Type Attribute is present in the mapped XML, but a corresponding EII is not present. Note that this member record must occur first in the JSON object for this special mapping to apply. This represents a departure from usual JSON processing, where the order of member records is not significant.<br /><br /> Example:<br /><br /> The following JSON fragment maps to XML.<br /><br /> `{"__type":"Person","name":"John"}`<br /><br /> The XML is the following code.<br /><br /> `<root type="object" __type="Person">   <name type="string">John</name> </root>`<br /><br /> Notice that the \__type AII is present, but there is no \__type EII.<br /><br /> However, if the order in the JSON is reversed as shown in the following example.<br /><br /> {"name":"John","\__type":"Person"}<br /><br /> The corresponding XML is shown.<br /><br /> `<root type="object">   <name type="string">John</name>   <__type type="string">Person</__type> </root>`<br /><br /> That is, \__type ceases to have special meaning and maps to an EII as usual, not AII.<br /><br /> Escaping/unescaping rules for the AII’s [normalized value] when mapped to a JSON value are the same as for JSON strings, specified in the "string" row of this table.<br /><br /> Example:<br /><br /> `<root type="object" __type="\abc" />`<br /><br /> to the previous example can be mapped to the following JSON.<br /><br /> `{"__type":"\\abc"}`<br /><br /> On an XML to JSON mapping, the first EII’s [local name] must not be "\__type".<br /><br /> Whitespace (`ws`) is never generated on XML to JSON mapping for objects and is ignored on JSON to XML mapping.<br /><br /> Example: The following JSON fragment maps to an XML element.<br /><br /> {   "ccc"   :  "aaa",   "ddd"    :"bbb"}<br /><br /> The XML element is shown in the following code.<br /><br /> `<root type="object">    <ccc type="string">aaa</ccc>    <ddd type="string">bbb</bar> </root >`|  
ray`|0 or more EIIs|A begin-array (left square bracket) as in section 2.3 of the JSON RFC, followed by an array record for each EII as described further. If there is more than one EII, there are value-separators (commas) between the array records. All this is followed by an end-array.<br /><br /> Example: The following XML element maps to a JSON fragment.<br /><br /> `<root type="array"/>    <item type="string">aaa</item>    <item type="string">bbb</item> </root >`<br /><br /> The JSON fragment is ["aaa","bbb"]<br /><br /> Whitespace (`ws`) is never generated on XML to JSON mapping for arrays and is ignored on JSON to XML mapping.<br /><br /> Example: AJSON fragment.<br /><br /> [     "aaa",     "bbb"]<br /><br /> The XML element that it maps to.<br /><br /> `<root type="array"/>    <item type="string">aaa</item>    <item type="string">bbb</item> </root >`|  
  
 Member Records work as follows:  
  
-   Inner element’s [local name] maps to the `string` part of the `member` as defined in section 2.2 of the JSON RFC.  
  
 Example: The following element maps to a JSON fragment.  
  
 `<root type="object"/>`  
  
 `<myLocalName type="string">aaa</myLocalName>`  
  
 `</root >`  
  
 The following JSON fragment is displayed.  
  
 `{"myLocalName":"aaa"}`  
  
-   On the XML to JSON mapping, the characters that must be escaped in JSON are escaped, and the others are not escaped. The "/" character, even though it is not a character that must be escaped, is escaped nevertheless (it does not have to be escaped on JSON to XML mapping). This is required to support the ASP.NET AJAX format for `DateTime` data in JSON.  
  
-   On the JSON to XML mapping, all characters (including the not escaped characters, if necessary) are taken to form a `string` that produces a [local name].  
  
-   Inner elements [children] map to the value in section 2.2, according to the `JSON Type Attribute` just like for the `Root JSON Element`. Multiple levels of nesting of EIIs (including nesting within arrays) are allowed.  
  
 Example: The following element maps to a JSON fragment.  
  
 `<root type="object">`  
  
 `<myLocalName1 type="string">myValue1</myLocalName1>`  
  
 `<myLocalName2 type="number">2</myLocalName2>`  
  
 `<myLocalName3 type="object">`  
  
 `<myNestedName1 type="boolean">true</myNestedName1>`  
  
 `<myNestedName2 type="null"/>`  
  
 `</myLocalName3>`  
  
 `</root >`  
  
 The following JSON fragment is what it maps to.  
  
 `{"myLocalName1":"myValue1","myLocalName2":2,"myLocalName3":{"myNestedName1":true,"myNestedName2":null}}`  
  
> [!NOTE]
>  There is no XML encoding step in the preceding mapping. Therefore, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] only supports JSON documents where all characters in key names are valid characters in XML element names. For example, the JSON document {"<":"a"} is not supported because < is not a valid name for an XML element.  
  
 The reverse situation (characters valid in XML but not in JSON) does not cause any problems because the preceding mapping includes JSON escaping/unescaping steps.  
  
 Array Records work as follows:  
  
-   Inner element’s [local name] is "item".  
  
-   Inner element’s [children] map to the value in section 2.3, according to the JSON Type Attribute as is does for the Root JSON Element. Multiple levels of nesting of EIIs (including nesting within objects) are allowed.  
  
 Example: The following element maps to a JSON fragment.  
  
 `<root type="array"/>`  
  
 `<item type="string">myValue1</item>`  
  
 `<item type="number">2</item>`  
  
 `<item type="array">`  
  
 `<item type="boolean">true</item>`  
  
 `<item type="null"/>`  
  
 `</item>`  
  
 `</root >`  
  
 The following is the JSON fragment.  
  
 `["myValue1",2,[true,null]]`  
  
## See Also  
 <xref:System.Runtime.Serialization.Json.JsonReaderWriterFactory>  
 <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>  
 [Stand-Alone JSON Serialization](../../../../docs/framework/wcf/feature-details/stand-alone-json-serialization.md)
