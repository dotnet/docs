---
title: "Stand-Alone JSON Serialization"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 312bd7b2-1300-4b12-801e-ebe742bd2287
caps.latest.revision: 32
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Stand-Alone JSON Serialization
JSON (JavaScript Object Notation) is a data format that is specifically designed to be used by JavaScript code running on Web pages inside the browser. It is the default data format used by ASP.NET AJAX services created in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)].  
  
 This format can also be used when creating AJAX services without integrating with ASP.NET - in this case, XML is the default but JSON can be chosen.  
  
 Finally, if you require JSON support but are not creating an AJAX service, the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> makes it possible to directly serialize .NET objects into JSON data and to deserialize such data back into instances of .NET types. For a description of how to do this, see [How to: Serialize and Deserialize JSON Data](../../../../docs/framework/wcf/feature-details/how-to-serialize-and-deserialize-json-data.md).  
  
 When working with JSON, the same .NET types are supported, with a few exceptions, as are supported by the <xref:System.Runtime.Serialization.DataContractSerializer>. For a list of the types supported, see [Types Supported by the Data Contract Serializer](../../../../docs/framework/wcf/feature-details/types-supported-by-the-data-contract-serializer.md). This includes most primitive types, most array and collection types, as well as complex types that use the <xref:System.Runtime.Serialization.DataContractAttribute> and <xref:System.Runtime.Serialization.DataMemberAttribute>.  
  
## Mapping .NET types to JSON Types  
 The following table shows the correspondence between .NET types and JSON/JavaScript types when mapped by serialization and deserialization procedures.  
  
|.NET Types|JSON/JavaScript|Notes|  
|----------------|----------------------|-----------|  
|All numeric types, for example <xref:System.Int32>, <xref:System.Decimal> or <xref:System.Double>|Number|Special values such as  `Double.NaN`, `Double.PositiveInfinity` and `Double.NegativeInfinity` are not supported and result in invalid JSON.|  
|<xref:System.Enum>|Number|See "Enumerations and JSON" later in this topic.|  
|<xref:System.Boolean>|Boolean|--|  
|<xref:System.String>, <xref:System.Char>|String|--|  
|<xref:System.TimeSpan>, <xref:System.Guid>, <xref:System.Uri>|String|The format of these types in JSON is the same as in XML (essentially, TimeSpan in the ISO 8601 Duration format, GUID in the "12345678-ABCD-ABCD-ABCD-1234567890AB" format and URI in its natural string form like "http://www.example.com"). For precise information, see [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md).|  
|<xref:System.Xml.XmlQualifiedName>|String|The format is "name:namespace" (anything before the first colon is the name). Either the name or the namespace can be missing. If there is no namespace the colon can be omitted as well.|  
|<xref:System.Array> of type <xref:System.Byte>|Array of numbers|Each number represents the value of one byte.|  
|<xref:System.DateTime>|DateTime or String|See Dates/Times and JSON later in this topic.|  
|<xref:System.DateTimeOffset>|Complex type|See Dates/Times and JSON later in this topic.|  
|XML and ADO.NET types (<xref:System.Xml.XmlElement>,<br /><br /> <xref:System.Xml.Linq.XElement>. Arrays of <xref:System.Xml.XmlNode>,<br /><br /> <xref:System.Runtime.Serialization.ISerializable>,<br /><br /> <xref:System.Data.DataSet>).|String|See the XML Types and JSON section of this topic.|  
|<xref:System.DBNull>|Empty complex type|--|  
|Collections, dictionaries, and arrays|Array|See the Collections, Dictionaries, and Arrays section of this topic.|  
|Complex types (with the <xref:System.Runtime.Serialization.DataContractAttribute> or <xref:System.SerializableAttribute> applied)|Complex type|Data members become members of the JavaScript complex type.|  
|Complex types implementing the <xref:System.Runtime.Serialization.ISerializable> interface)|Complex type|Same as other complex types but some <xref:System.Runtime.Serialization.ISerializable> types are not supported – see the ISerializable Support part of the Advanced Information section of this topic.|  
|`Null` value for any type|Null|Nullable types are also supported and map to JSON in the same way as non-nullable types.|  
  
### Enumerations and JSON  
 Enumeration member values are treated as numbers in JSON, which is different from how they are treated in data contracts, where they are included as member names. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the data contract treatment, see [Enumeration Types in Data Contracts](../../../../docs/framework/wcf/feature-details/enumeration-types-in-data-contracts.md).  
  
-   For example, if you have `public enum Color {red, green, blue, yellow, pink}`, serializing `yellow` produces the number 3 and not the string "yellow".  
  
-   All `enum` members are serializable. The <xref:System.Runtime.Serialization.EnumMemberAttribute> and the <xref:System.NonSerializedAttribute> attributes are ignored if used.  
  
-   It is possible to deserialize a nonexistent `enum` value - for example, the value 87 can be deserialized into the previous Color enum even though there is no corresponding color name defined.  
  
-   A flags `enum` is not special and is treated the same as any other `enum`.  
  
### Dates/Times and JSON  
 The JSON format does not directly support dates and times. However, they are very commonly used and ASP.NET AJAX provides special support for these types. When using ASP.NET AJAX proxies, the <xref:System.DateTime> type in .NET fully corresponds to the `DateTime` type in JavaScript.  
  
-   When not using ASP.NET, a <xref:System.DateTime> type is represented in JSON as a string with a special format that is described in the Advanced Information section of this topic.  
  
-   <xref:System.DateTimeOffset> is represented in JSON as a complex type: {"DateTime":dateTime,"OffsetMinutes":offsetMinutes}. The `offsetMinutes` member is the local time offset from Greenwich Mean Time (GMT), also now referred to as Coordinated Universal Time (UTC), associated with the location of the event of interest. The `dateTime` member represents the instance in time when the event of interest occurred (again, it becomes a `DateTime` in JavaScript when ASP.NET AJAX is in use and a string when it is not). On serialization, the `dateTime` member is always serialized in GMT. So, if describing 3:00 AM New York time, `dateTime` has a time component of 8:00 AM and `offsetMinutes` are 300 (minus 300 minutes or 5 hours from GMT).  
  
    > [!NOTE]
    >  <xref:System.DateTime> and <xref:System.DateTimeOffset> objects, when serialized to JSON, only preserve information to millisecond precision. Sub-millisecond values (micro/nanoseconds) are lost during serialization.  
  
### XML Types and JSON  
 XML types become JSON strings.  
  
-   For example, if a data member "q" of type XElement contains \<abc/>, the JSON is {"q":"\<abc/>"}.  
  
-   There are some special rules that specify how XML is wrapped - for more information, see the Advanced Information section later in this topic.  
  
-   If you are using ASP.NET AJAX and do not want to use strings in the JavaScript, but want the XML DOM instead, set the <xref:System.ServiceModel.Web.WebGetAttribute.ResponseFormat%2A> property to XML on <xref:System.ServiceModel.Web.WebGetAttribute> or the <xref:System.ServiceModel.Web.WebInvokeAttribute.ResponseFormat%2A> property to XML on the <xref:System.ServiceModel.Web.WebInvokeAttribute>.  
  
### Collections, Dictionaries and Arrays  
 All collections, dictionaries, and arrays are represented in JSON as arrays.  
  
-   Any customization that uses the <xref:System.Runtime.Serialization.CollectionDataContractAttribute> is ignored in the JSON representation.  
  
-   Dictionaries are not a way to work directly with JSON. Dictionary\<string,object> may not be supported in the same way in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] as expected from working with other JSON technologies. For example, if "abc" is mapped to "xyz" and "def" is mapped to 42 in a dictionary, the JSON representation is not {"abc":"xyz","def":42} but is [{"Key":"abc","Value":"xyz"},{"Key":"def","Value":42}] instead.  
  
-   If you would like to work with JSON directly (accessing keys and values dynamically, without pre-defining a rigid contract), you have several options:  
  
    -   Consider using the [Weakly-typed JSON Serialization (AJAX)](../../../../docs/framework/wcf/samples/weakly-typed-json-serialization-sample.md) sample.  
  
    -   Consider using the <xref:System.Runtime.Serialization.ISerializable> interface and deserialization constructors - these two mechanisms allow you to access JSON key/value pairs on serialization and deserialization respectively, but do not work in partial trust scenarios.  
  
    -   Consider working with the [Mapping Between JSON and XML](../../../../docs/framework/wcf/feature-details/mapping-between-json-and-xml.md) instead of using a serializer.  
  
    -   *Polymorphism* in the context of serialization refers to the ability to serialize a derived type where its base type is expected. There are special JSON-specific rules when using collections polymorphically, when, for example, assigning a collection to an <xref:System.Object>. This issue is more fully discussed in the Advanced Information section later in this topic.  
  
## Additional Details  
  
### Order of Data Members  
 Order of data members is not important when using JSON. Specifically, even if <xref:System.Runtime.Serialization.DataMemberAttribute.Order%2A> is set, JSON data can still be deserialized in any order.  
  
### JSON Types  
 The JSON type does not have to match the preceding table on deserialization. For example, an `Int` normally maps to a JSON number, but it can also be successfully deserialized from a JSON string as long as that string contains a valid number. That is, both {"q":42} and {"q":"42"} are valid if there is an `Int` data member called "q".  
  
### Polymorphism  
 Polymorphic serialization consists of the ability to serialize a derived type where its base type is expected. This is supported for JSON serialization by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] comparable to the way XML serialization is supported. For example, you can serialize `MyDerivedType` where `MyBaseType` is expected, or serialize `Int` where `Object` is expected.  
  
 Type information may be lost when deserializing a derived type if the base type is expected, unless you are deserializing a complex type. For example, if <xref:System.Uri> is serialized where <xref:System.Object> is expected, it results in a JSON string. If this string is then deserialized back into <xref:System.Object>, a .NET <xref:System.String> is returned. The deserializer does not know that the string was initially of type <xref:System.Uri>. Generally, when expecting <xref:System.Object>, all JSON strings are deserialized as .NET strings, and all JSON arrays used to serialize .NET collections, dictionaries, and arrays are deserialized as .NET <xref:System.Array> of type <xref:System.Object>, regardless of what the actual original type had been. A JSON boolean maps to a .NET <xref:System.Boolean>. However when expecting an <xref:System.Object>, JSON numbers are deserialized as either .NET <xref:System.Int32>, <xref:System.Decimal> or <xref:System.Double>, where the most appropriate type is automatically picked.  
  
 When deserializing into an interface type, the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> deserializes as if the declared type were object.  
  
 When working with your own base and derived types, using the <xref:System.Runtime.Serialization.KnownTypeAttribute>, <xref:System.ServiceModel.ServiceKnownTypeAttribute> or an equivalent mechanism is normally required. For example, if you have an operation that has an `Animal` return value and it actually returns an instance of `Cat` (derived from `Animal`), you should either apply the <xref:System.Runtime.Serialization.KnownTypeAttribute>, to the `Animal` type or the <xref:System.ServiceModel.ServiceKnownTypeAttribute> to the operation and specify the `Cat` type in these attributes. For more information, see [Data Contract Known Types](../../../../docs/framework/wcf/feature-details/data-contract-known-types.md).  
  
 For details of how polymorphic serialization works and a discussion of some of the limitations that must be respected when using it, see the Advanced Information section later in this topic.  
  
### Versioning  
 The data contract versioning features, including the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface, are fully supported in JSON. Furthermore, in most cases it is possible to deserialize a type in one format (for example, XML) and then serialize it into another format (for example, JSON) and still preserve the data in <xref:System.Runtime.Serialization.IExtensibleDataObject>. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Forward-Compatible Data Contracts](../../../../docs/framework/wcf/feature-details/forward-compatible-data-contracts.md). Remember that JSON is unordered so any order information is lost. Furthermore, JSON does not support multiple key/value pairs with the same key name. Finally, all operations on <xref:System.Runtime.Serialization.IExtensibleDataObject> are inherently polymorphic - that is their derived type are assigned to <xref:System.Object>, the base type for all types.  
  
## JSON in URLs  
 When using ASP.NET AJAX endpoints with the HTTP GET verb (using the <xref:System.ServiceModel.Web.WebGetAttribute> attribute), incoming parameters appear in the request URL instead of the message body. JSON is supported even in the request URL, so if you have an operation that takes an `Int` called "number" and a `Person` complex type called "p", the URL may resemble the following URL.  
  
```  
http://example.com/myservice.svc/MyOperation?number=7&p={"name":"John","age":42}  
```  
  
 If you are using an ASP.NET AJAX Script Manager control and proxy to call the service, this URL is automatically generated by the proxy and is not seen. JSON cannot be used in URLs on non-ASP.NET AJAX endpoints.  
  
## Advanced information  
  
### ISerializable Support  
  
#### Supported and Unsupported ISerializable Types  
 In general, types that implement the <xref:System.Runtime.Serialization.ISerializable> interface are fully supported when serializing/deserializing JSON. However, some of these types (including some .NET Framework types) are implemented in such a way that the JSON-specific serialization aspects cause them to not deserialize correctly:  
  
-   With <xref:System.Runtime.Serialization.ISerializable>, the type of individual data members is never known in advance. This leads to a polymorphic situation similar to deserializing types into an object. As mentioned before, this may lead to loss of type information in JSON. For example, a type that serializes an `enum` in its <xref:System.Runtime.Serialization.ISerializable> implementation and attempts to deserialize back directly into an `enum` (without proper casts) fails, because an `enum` is serialized using numbers in JSON and JSON numbers deserialize into built-in .NET numeric types (Int32, Decimal or Double). So the fact that the number used to be an `enum` value is lost.  
  
-   An <xref:System.Runtime.Serialization.ISerializable> type that depends on a particular order of deserialization in its deserialization constructor may also fail to deserialize some JSON data, because most JSON serializers do not guarantee any specific order.  
  
#### Factory Types  
 While the <xref:System.Runtime.Serialization.IObjectReference> interface is supported in JSON in general, any types that require the "factory type" feature (returning an instance of a different type from <xref:System.Runtime.Serialization.IObjectReference.GetRealObject%28System.Runtime.Serialization.StreamingContext%29> than the type that implements the interface) are not supported.  
  
### DateTime Wire Format  
 <xref:System.DateTime> values appear as JSON strings in the form of "/Date(700000+0500)/", where the first number (700000 in the example provided) is the number of milliseconds in the GMT time zone, regular (non-daylight savings) time since midnight, January 1, 1970. The number may be negative to represent earlier times. The part that consists of "+0500" in the example is optional and indicates that the time is of the <xref:System.DateTimeKind.Local> kind - that is, should be converted to the local time zone on deserialization. If it is absent, the time is deserialized as <xref:System.DateTimeKind.Utc>. The actual number ("0500" in this example) and its sign (+ or -) are ignored.  
  
 When serializing <xref:System.DateTime>, <xref:System.DateTimeKind.Local> and <xref:System.DateTimeKind.Unspecified> times are written with an offset, and <xref:System.DateTimeKind.Utc> is written without.  
  
 The ASP.NET AJAX client JavaScript code automatically converts such strings into JavaScript `DateTime` instances. If there are other strings that have a similar form that are not of type <xref:System.DateTime> in .NET, they are converted as well.  
  
 The conversion only takes place if the "/" characters are escaped (that is, the JSON looks like "\\/Date(700000+0500)\\/"), and for this reason [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]'s JSON encoder (enabled by the <xref:System.ServiceModel.WebHttpBinding>) always escapes the "/" character.  
  
### XML in JSON Strings  
  
#### XmlElement  
 <xref:System.Xml.XmlElement> is serialized as is, with no wrapping. For example, data member "x" of type <xref:System.Xml.XmlElement> that contains \<abc/> is as represented as follows.  
  
```json  
{"x":"<abc/>"}  
```  
  
#### Arrays of XmlNode  
 <xref:System.Array> objects of type <xref:System.Xml.XmlNode> are wrapped in an element called ArrayOfXmlNode in the standard data contract namespace for the type. If "x" is an array that contains attribute node "N" in namespace "ns" that contains "value" and an empty element node "M", the representation is as follows.  
  
```  
{"x":"<ArrayOfXmlNode xmlns=\"http://schemas.datacontract.org/2004/07/System.Xml\" a:N=\"value\" xmlns:a=\"ns\"><M/></ArrayOfXmlNode>"}  
```  
  
 Attributes in the empty namespace at the beginning of XmlNode arrays (before other elements) are unsupported.  
  
#### IXmlSerializable Types including XElement and DataSet  
 <xref:System.Runtime.Serialization.ISerializable> types subdivide into "content types", "DataSet types" and "element types". For definitions of these types, see [XML and ADO.NET Types in Data Contracts](../../../../docs/framework/wcf/feature-details/xml-and-ado-net-types-in-data-contracts.md).  
  
 "Content" and "DataSet" types are serialized similar to <xref:System.Array> objects of <xref:System.Xml.XmlNode> discussed in the previous section. They are wrapped in an element whose name and namespace corresponds to the data contract name and namespace of the type in question.  
  
 "Element" types such as <xref:System.Xml.Linq.XElement> are serialized as is, similar to <xref:System.Xml.XmlElement> previously discussed in this topic.  
  
### Polymorphism  
  
#### Preserving Type Information  
 As stated earlier, polymorphism is supported in JSON with some limitations. JavaScript is a weakly-typed language and type identity is normally not an issue. However, when using JSON to communicate between a strongly-typed system (.NET) and a weakly-typed system (JavaScript), it is useful to preserve type identity. For example, types with data contract names "Square" and "Circle" derive from a type with a data contract name of "Shape". If "Circle" is sent from .NET to JavaScript and is later returned to a .NET method that expects "Shape", it is useful for the .NET side to know that the object in question was originally a "Circle" - otherwise any information specific to the derived type (for example, "radius" data member on "Circle") may be lost.  
  
 To preserve type identity, when serializing complex types to JSON a "type hint" can be added, and the deserializer recognizes the hint and acts appropriately. The "type hint" is a JSON key/value pair with the key name of "__type" (two underscores followed by the word "type"). The value is a JSON string of the form "DataContractName:DataContractNamespace" (anything up to the first colon is the name). Using the earlier example, "Circle" can be serialized as follows.  
  
```json  
{"__type":"Circle:http://example.com/myNamespace","x":50,"y":70,"radius":10}  
```  
  
 The type hint is very similar to the `xsi:type` attribute defined by the XML Schema Instance standard and used when serializing/deserializing XML.  
  
 Data members called "__type" are forbidden due to potential conflict with the type hint.  
  
#### Reducing the Size of Type Hints  
 To reduce the size of JSON messages, the default data contract namespace prefix (http://schemas.datacontract.org/2004/07/) is replaced with the "#" character. (To make this replacement reversible, an escaping rule is used: if the namespace starts with the "#" or "\\" characters, they are appended with an extra "\\" character). Thus, if "Circle" is a type in the .NET namespace "MyApp.Shapes", its default data contract namespace is http://schemas.datacontract.org/2004/07/MyApp. Shapes and the JSON representation is as follows.  
  
```json  
{"__type":"Circle:#MyApp.Shapes","x":50,"y":70,"radius":10}  
```  
  
 Both the truncated (#MyApp.Shapes) and the full (http://schemas.datacontract.org/2004/07/MyApp.Shapes) names is understood on deserialization.  
  
#### Type Hint Position in JSON Objects  
 Note that the type hint must appear first in the JSON representation. This is the only case where order of key/value pairs is important in JSON processing. For example, the following is not a valid way to specify the type hint.  
  
```json  
{"x":50,"y":70,"radius":10,"__type":"Circle:#MyApp.Shapes"}  
```  
  
 Both the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> used by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and ASP.NET AJAX client pages always emit the type hint first.  
  
#### Type Hints Apply Only to Complex Types  
 There is no way to emit a type hint for non-complex types. For example, if an operation has an <xref:System.Object> return type but returns a Circle, the JSON representation can be as shown earlier and the type information is preserved. However, if Uri is returned, the JSON representation is a string and the fact that the string used to represent a Uri is lost. This applies not only to primitive types but also to collections and arrays.  
  
#### When Are Type Hints Emitted  
 Type hints may increase message size significantly (one way to mitigate this is to use shorter data contract namespaces if possible). Therefore, the following rules govern whether type hints are emitted:  
  
-   When using ASP.NET AJAX, type hints are always emitted whenever possible, even if there is no base/derived assignment - for example, even if a Circle is assigned to a Circle. (This is required to fully enable the process of calling from the weakly-typed JSON environment into the strongly-typed .NET environment with no surprising loss of information.)  
  
-   When using AJAX services with no ASP.NET integration, type hints are only emitted when there is a base/derived assignment - that is, emitted when Circle is assigned to Shape or <xref:System.Object> but not when assigned to Circle. This provides the minimum information required to correctly implement a JavaScript client, thus improving performance, but does not protect against type information loss in incorrectly-designed clients. Avoid base/derived assignments altogether on the server if you want to avoid dealing with this issue on the client.  
  
-   When using the <xref:System.Runtime.Serialization.DataContractSerializer> type, the `alwaysEmitTypeInformation` constructor parameter allows you to choose between the preceding two modes, with the default being "`false`" (only emit type hints when required).  
  
#### Duplicate Data Member Names  
 Derived type information is present in the same JSON object together with base type information, and can occur in any order. For example, `Shape` may be represented as follows.  
  
```json  
{"__type":"Shape:#MyApp.Shapes","x":50,"y":70}  
```  
  
 Whereas Circle may be represented as follows.  
  
```json  
{"__type":"Circle:#MyApp.Shapes","x":50, "radius":10,"y":70}  
```  
  
 If the base `Shape` type also contained a data member called "`radius`", this leads to a collision on both serialization (because JSON objects cannot have repeating key names) and deserialization (because it is unclear whether "radius" refers to `Shape.radius` or `Circle.radius`). Therefore, while the concept of "property hiding" (data members of the same name on based and derived classes) is generally not recommended in data contract classes, it is actually forbidden in the case of JSON.  
  
#### Polymorphism and IXmlSerializable Types  
 <xref:System.Xml.Serialization.IXmlSerializable> types may be polymorphically assigned to each other as usual as long as Known Types requirements are met, according to usual data contract rules. However, serializing an <xref:System.Xml.Serialization.IXmlSerializable> type in place of <xref:System.Object> results in loss of type information as the result is a JSON string.  
  
#### Polymorphism and Certain Interface Types  
 It is forbidden to serialize a collection type or a type that implements <xref:System.Xml.Serialization.IXmlSerializable> where a non-collection type that is not <xref:System.Xml.Serialization.IXmlSerializable> (except for <xref:System.Object>) is expected. For example, a custom interface called `IMyInterface` and a type `MyType` that implement both <xref:System.Collections.Generic.IEnumerable%601> of type `int` and `IMyInterface`. It is forbidden to return `MyType` from an operation whose return type is `IMyInterface`. This is because `MyType` must be serialized as a JSON array and requires a type hint, and as stated before you cannot include a type hint with arrays, only with complex types.  
  
#### Known Types and Configuration  
 All of the Known Type mechanisms used by the <xref:System.Runtime.Serialization.DataContractSerializer> are also supported in the same way by the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>. Both serializers read the same configuration element, [\<dataContractSerializer>](../../../../docs/framework/configure-apps/file-schema/wcf/datacontractserializer-of-system-runtime-serialization.md) in [\<system.runtime.serialization>](../../../../docs/framework/configure-apps/file-schema/wcf/system-runtime-serialization.md), to discover known types added through a configuration file.  
  
#### Collections Assigned to Object  
 Collections assigned to Object are serialized as if they are collections that implement <xref:System.Collections.Generic.IEnumerable%601>: a JSON array with each entry that has a type hint if it is a complex type. For example, a <xref:System.Collections.Generic.List%601> of type `Shape` assigned to <xref:System.Object> looks like the following.  
  
```json  
[{"__type":"Shape:#MyApp.Shapes","x":50,"y":70},  
{"__type":"Shape:#MyApp.Shapes","x":58,"y":73},  
{"__type":"Shape:#MyApp.Shapes","x":41,"y":32}]  
```  
  
 When deserialized back into <xref:System.Object>:  
  
-   `Shape` must be in the Known Types list. Having <xref:System.Collections.Generic.List%601> of type `Shape` in known types has no effect. Note that you do not have to add `Shape` to known types on serialization in this case - this is done automatically.  
  
-   The collection is deserialized as an <xref:System.Array> of type <xref:System.Object> that contains `Shape` instances.  
  
#### Derived Collections Assigned to Base Collections  
 When a derived collection is assigned to a base collection, the collection is usually serialized as if it was a collection of the base type. However, if the item type of the derived collection cannot be assigned to the item type of the base collection, an exception is thrown.  
  
#### Type Hints and Dictionaries  
 When a dictionary is assigned to an <xref:System.Object>, each Key and Value entry in the dictionary is treated as if it was assigned to <xref:System.Object> and gets a type hint.  
  
 When serializing dictionary types, the JSON object that contains the "Key" and "Value" members is unaffected by the `alwaysEmitTypeInformation` setting and only contains a type hint when the preceding collection rules require it.  
  
### Valid JSON Key Names  
 The serializer XML-encodes key names that are not valid XML names. For example, a data member with the name of "123" would have an encoded name such as "_x0031\__x0032\__x0033\_" because "123" is an invalid XML element name (starts with a digit). A similar situation may arise with some international character sets not valid in XML names. For an explanation of this effect of XML on JSON processing, see [Mapping Between JSON and XML](../../../../docs/framework/wcf/feature-details/mapping-between-json-and-xml.md).  
  
## See Also  
 [Support for JSON and Other Data Transfer Formats](../../../../docs/framework/wcf/feature-details/support-for-json-and-other-data-transfer-formats.md)
