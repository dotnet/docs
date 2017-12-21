---
title: "Understanding XAML Node Stream Structures and Concepts"
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
  - "XAML node streams [XAML Services]"
  - "nodes [XAML Services], XAML node stream"
  - "XAML [XAML Services], XAML node streams"
ms.assetid: 7c11abec-1075-474c-9d9b-778e5dab21c3
caps.latest.revision: 14
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Understanding XAML Node Stream Structures and Concepts
XAML readers and XAML writers as implemented in .NET Framework XAML Services are based on the design concept of a XAML node stream. The XAML node stream is a conceptualization of a set of XAML nodes. In this conceptualization, a XAML processor walks through the structure of the node relationships in the XAML one at a time. At any time, only one current record or current position exists in an open XAML node stream, and many aspects of the API report only the information available from that position. The current node in a XAML node stream can be described as being an object, a member, or a value. By treating XAML as a XAML node stream, XAML readers can communicate with XAML writers and enable a program to view, interact with, or alter the contents of a XAML node stream during either a load path or a save path operation that involves XAML. XAML reader and writer API design and the XAML node stream concept are similar to previous related reader and writer designs and concepts, such as the [!INCLUDE[TLA#tla_xmldom](../../../includes/tlasharptla-xmldom-md.md)] and the <xref:System.Xml.XmlReader> and <xref:System.Xml.XmlWriter> classes. This topic discusses XAML node stream concepts and describes how you can write routines that interact with XAML representations at the XAML node level.  
  
<a name="loading_into_a_xaml_reader"></a>   
## Loading XAML into a XAML Reader  
 The base <xref:System.Xaml.XamlReader> class does not declare a particular technique for loading the initial XAML into a XAML reader. Instead, a derived class declares and implements the loading technique, including the general characteristics and constraints of its input source for XAML. For example, a <xref:System.Xaml.XamlObjectReader> reads an object graph, starting from the input source of a single object that represents the root or base. The <xref:System.Xaml.XamlObjectReader> then produces a XAML node stream from the object graph.  
  
 The most prominent .NET Framework XAML Services–defined <xref:System.Xaml.XamlReader> subclass is <xref:System.Xaml.XamlXmlReader>. <xref:System.Xaml.XamlXmlReader> loads the initial XAML, either by loading a text file directly through a stream or file path, or indirectly through a related reader class such as <xref:System.IO.TextReader>. The <xref:System.Xaml.XamlReader> can be thought of as containing the entirety of the XAML input source after it has loaded. However, the <xref:System.Xaml.XamlReader> base API is designed so that the reader is interacting with a single node of the XAML. When first loaded, the first single node you encounter is the root of the XAML, and its start object.  
  
### The XAML Node Stream Concept  
 If you are generally more familiar with a DOM, tree metaphor, or query-based approach towards accessing XML-based technologies, a helpful way to conceptualize a XAML node stream is as follows. Imagine that the loaded XAML is a DOM or a tree where every possible node is expanded all the way, and then presented linearly. As you advance through the nodes, you might be traversing "in" or "out" of levels that would be relevant to a DOM, but the XAML node stream does not explicitly keep track because these level concepts are not relevant to a node stream. The node stream has a "current" position, but unless you have stored other parts of the stream yourself as references, every aspect of the node stream other than the current node position is out of view.  
  
 The XAML node stream concept has the notable advantage that if you go through the entire node stream, you are assured that you have processed the entire XAML representation; you do not need to worry that a query, a DOM operation, or some other nonlinear approach to processing information has missed some part of the complete XAML representation. For this reason, the XAML node stream representation is ideal both for connecting XAML readers and XAML writers, and for providing a system where you can insert your own process that acts between the read and write phases of a XAML processing operation. In many cases, the ordering of nodes in the XAML node stream is deliberately optimized or reordered by XAML readers versus how the order might appear in the source text, binary, or object graph. This behavior is intended to enforce a XAML processing architecture whereby XAML writers are never in a position where they have to go "back" in the node stream. Ideally, all XAML write operations should be able to act based on schema context plus the current position of the node stream.  
  
<a name="a_basic_reading_node_loop"></a>   
## A Basic Reading Node Loop  
 A basic reading node loop for examining a XAML node stream consists of the following concepts. For purposes of node loops as discussed in this topic, assume that you are reading a text-based, human-readable XAML file using <xref:System.Xaml.XamlXmlReader>. The links in this section refer to the particular XAML node loop API implemented by <xref:System.Xaml.XamlXmlReader>.  
  
-   Make sure that you are not at the end of the XAML node stream (check <xref:System.Xaml.XamlXmlReader.IsEof%2A>, or use the <xref:System.Xaml.XamlXmlReader.Read%2A> return value). If you are at the end of the stream, there is no current node and you should exit.  
  
-   Check what type of node the XAML node stream currently exposes by calling <xref:System.Xaml.XamlXmlReader.NodeType%2A>.  
  
-   If you have an associated XAML object writer that is connected directly, you generally call <xref:System.Xaml.XamlWriter.WriteNode%2A> at this point.  
  
-   Based on which <xref:System.Xaml.XamlNodeType> is reported as the current node or current record, call one of the following to obtain information about the node contents:  
  
    -   For a <xref:System.Xaml.XamlXmlReader.NodeType%2A> of <xref:System.Xaml.XamlNodeType.StartMember> or <xref:System.Xaml.XamlNodeType.EndMember>, call <xref:System.Xaml.XamlXmlReader.Member%2A> to obtain <xref:System.Xaml.XamlMember> information about a member. Note that the member might be a <xref:System.Xaml.XamlDirective>, and thus might not necessarily be a conventional type-defined member of the preceding object. For example, `x:Name` applied to an object appears as a XAML member where <xref:System.Xaml.XamlMember.IsDirective%2A> is true and the <xref:System.Xaml.XamlMember.Name%2A> of the member is `Name`, with other properties indicating that this directive is under the XAML language XAML namespace.  
  
    -   For a <xref:System.Xaml.XamlXmlReader.NodeType%2A> of <xref:System.Xaml.XamlNodeType.StartObject> or <xref:System.Xaml.XamlNodeType.EndObject>, call <xref:System.Xaml.XamlXmlReader.Type%2A> to obtain <xref:System.Xaml.XamlType> information about an object.  
  
    -   For a <xref:System.Xaml.XamlXmlReader.NodeType%2A> of <xref:System.Xaml.XamlNodeType.Value>, call <xref:System.Xaml.XamlXmlReader.Value%2A>. A node is a value only if it is the simplest expression of a value for a member, or the initialization text for an object (however, you should be aware of type conversion behavior as documented in an upcoming section of this topic).  
  
    -   For a <xref:System.Xaml.XamlXmlReader.NodeType%2A> of <xref:System.Xaml.XamlNodeType.NamespaceDeclaration>, call <xref:System.Xaml.XamlXmlReader.Namespace%2A> to obtain namespace information for a namespace node.  
  
-   Call <xref:System.Xaml.XamlXmlReader.Read%2A> to advance the XAML reader to the next node in the XAML node stream, and repeat the steps again.  
  
 The XAML node stream provided by .NET Framework XAML Services XAML readers always provides a full, deep traversal of all possible nodes. Typical flow-control techniques for a XAML node loop include defining a body within `while (reader.Read())`, and switching on <xref:System.Xaml.XamlXmlReader.NodeType%2A> at each node point in the node loop.  
  
 If the node stream is at end of file, the current node is null.  
  
 The simplest loop that uses a reader and writer resembles the following example.  
  
```  
XamlXmlReader xxr = new XamlXmlReader(new StringReader(xamlStringToLoad));  
//where xamlStringToLoad is a string of well formed XAML  
XamlObjectWriter xow = new XamlObjectWriter(xxr.SchemaContext);  
while (xxr.Read()) {  
  xow.WriteNode(xxr);  
}  
```  
  
 This basic example of a load path XAML node loop transparently connects the XAML reader and XAML writer, doing nothing different than if you had used <xref:System.Xaml.XamlServices.Parse%2A?displayProperty=nameWithType>. But this basic structure is then expanded to apply to your reading or writing scenario. Some possible scenarios are as follows:  
  
-   Switch on <xref:System.Xaml.XamlXmlReader.NodeType%2A>. Perform different actions depending on which node type is being read.  
  
-   Do not call <xref:System.Xaml.XamlWriter.WriteNode%2A> in all cases. Only call <xref:System.Xaml.XamlWriter.WriteNode%2A> in some <xref:System.Xaml.XamlXmlReader.NodeType%2A> cases.  
  
-   Within the logic for a particular node type, analyze the specifics of that node and act on them. For example, you could write only objects that come from a particular XAML namespace, and then drop or defer any objects not from that XAML namespace. Or you could drop or otherwise reprocess any XAML directives that your XAML system does not support as part of your member processing.  
  
-   Define a custom <xref:System.Xaml.XamlObjectWriter> that overrides `Write*` methods, possibly performing type mapping that bypasses XAML schema context.  
  
-   Construct the <xref:System.Xaml.XamlXmlReader> to use a nondefault XAML schema context, so that customized differences in XAML behavior are used both by the reader and the writer.  
  
### Accessing XAML Beyond the Node Loop Concept  
 There are potentially other ways to work with a XAML representation other than as a XAML node loop. For example, there could exist a XAML reader that can read an indexed node, or in particular accesses nodes directly by `x:Name`, by `x:Uid`, or through other identifiers. .NET Framework XAML Services does not provide a full implementation, but provides a suggested pattern through services and support types. For more information, see <xref:System.Xaml.IXamlIndexingReader> and <xref:System.Xaml.XamlNodeList>.  
  
> [!TIP]
>  Microsoft also produces an out-of-band release known as the Microsoft XAML Toolkit. This out-of-band release is still in its pre-release stages. However, if you are willing to work with pre-release components, the Microsoft XAML Toolkit provides some interesting resources for XAML tooling and static analysis of XAML. The Microsoft XAML Toolkit includes a XAML DOM API, support for FxCop analysis, and a XAML schema context for Silverlight. For more information, see [Microsoft XAML Toolkit](http://code.msdn.microsoft.com/XAML).  
  
<a name="working_with_the_current_node"></a>   
## Working with the Current Node  
 Most scenarios that use a XAML node loop do not only read the nodes. Most scenarios process current nodes and pass each node one at a time to an implementation of <xref:System.Xaml.XamlWriter>.  
  
 In the typical load path scenario, a <xref:System.Xaml.XamlXmlReader> produces a XAML node stream; the XAML nodes are processed according to your logic and XAML schema context; and the nodes are passed to a <xref:System.Xaml.XamlObjectWriter>. You then integrate the resulting object graph into your application or framework.  
  
 In a typical save path scenario, a <xref:System.Xaml.XamlObjectReader> reads the object graph, individual XAML nodes are processed, and a <xref:System.Xaml.XamlXmlWriter> outputs the serialized result as a XAML text file. The key is that both paths and scenarios involve working with exactly one XAML node at a time, and the XAML nodes are available for treatment in a standardized way that is defined by the XAML type system and the.NET Framework XAML Services APIs.  
  
### Frames and Scope  
 A XAML node loop walks through a XAML node stream in a linear way. The node stream traverses into objects, into members that contain other objects, and so on. It is often useful to keep track of scope within the XAML node stream by implementing a frame and stack concept. This is particularly true if you are actively adjusting the node stream while you are in it. The frame and stack support that you implement as part of your node loop logic could count `StartObject` (or `GetObject`) and `EndObject` scopes as you descend into a XAML node structure if the structure is thought of from a DOM perspective.  
  
<a name="traversing_and_entering_object_nodes"></a>   
## Traversing and Entering Object Nodes  
 The first node in a node stream when it is opened by a XAML reader is the start-object node of the root object. By definition, this object is always a single object node and has no peers. In any real-world XAML example, the root object is defined to have one or more properties that hold more objects, and these properties have member nodes. The member nodes then have one or more object nodes, or might also terminate in a value node instead. The root object typically defines XAML namescopes, which are syntactically assigned as attributes in the XAML text markup but map to a `Namescope` node type in the XAML node stream representation.  
  
 Consider the following XAML example (this is arbitrary XAML, not backed by existing types in the .NET Framework). Assume that in this object model, `FavorCollection` is `List<T>` of `Favor`, `Balloon` and `NoiseMaker` are assignable to `Favor`, the `Balloon.Color` property is backed by a `Color` object similar to how WPF defines colors as known color names, and `Color` supports a type converter for attribute syntax.  
  
|XAML markup|Resulting XAML node stream|  
|-----------------|--------------------------------|  
|`<Party`|`Namespace` node for `Party`|  
|`xmlns="PartyXamlNamespace">`|`StartObject` node for `Party`|  
|`<Party.Favors>`|`StartMember` node for `Party.Favors`|  
||`StartObject` node for implicit `FavorCollection`|  
||`StartMember` node for implicit `FavorCollection` items property.|  
|`<Balloon`|`StartObject` node for `Balloon`|  
|`Color="Red"`|`StartMember` node for `Color`<br /><br /> `Value` node for the attribute value string `"Red"`<br /><br /> `EndMember` for `Color`|  
|`HasHelium="True"`|`StartMember` node for `HasHelium`<br /><br /> `Value` node for the attribute value string `"True"`<br /><br /> `EndMember` for `HasHelium`|  
|`>`|`EndObject` for `Balloon`|  
|`<NoiseMaker>Loudest</NoiseMaker>`|`StartObject` node for `NoiseMaker`<br /><br /> `StartMember` node for `_Initialization`<br /><br /> `Value` node for the initialization value string `"Loudest"`<br /><br /> `EndMember` node for `_Initialization`<br /><br /> `EndObject` for `NoiseMaker`|  
||`EndMember` node for implicit `FavorCollection` items property.|  
||`EndObject` node for implicit `FavorCollection`|  
|`</Party.Favors>`|`EndMember` for `Favors`|  
|`</Party>`|`EndObject` for `Party`|  
  
 In the XAML node stream, you can rely on the following behavior:  
  
-   If a `Namespace` node exists, it is added to the stream immediately before the `StartObject` that declared the XAML namespace with `xmlns`. Look at the previous table with the XAML and example node stream again. Notice how the `StartObject` and `Namespace` nodes seem to be transposed versus their declaration positions in text markup. This is representative of the behavior where the namespace nodes always appear ahead of the node they apply to in the node stream. The purpose of this design is that the namespace information is vital to object writers and must be known before the object writer attempts to perform type mapping or otherwise process the object. Placing the XAML namespace information ahead of its application scope in the stream makes it simpler to always process the node stream in its presented order.  
  
-   Because of the above consideration, it is one or more `Namespace` nodes that you read first in most real-world markup cases when traversing nodes from the start, not the `StartObject` of the root.  
  
-   A `StartObject` node can be followed by `StartMember`, `Value`, or an immediate `EndObject`. It is never followed immediately by another `StartObject`.  
  
-   A `StartMember` can be followed by a `StartObject`, `Value`, or an immediate `EndMember`. It can be followed by `GetObject`, for members where the value is supposed to come from an existing value of the parent object rather than a `StartObject` that would instantiate a new value. It can also be followed by a `Namespace` node, which applies to an upcoming `StartObject`. It is never followed immediately by another `StartMember`.  
  
-   A `Value` node represents the value itself; there is no "EndValue". It can be followed only by an `EndMember`.  
  
    -   XAML initialization text of the object as might be used by construction does not result in an Object-Value structure. Instead, a dedicated member node for a member named `_Initialization` is created. and that member node contains the initialization value string. If it exists, `_Initialization` is always the first `StartMember`. `_Initialization` may be qualified in some XAML services representations with the XAML language XAML namescope, to clarify that `_Initialization` is not a defined property in backing types.  
  
    -   A Member-Value combination represents an attribute setting of the value. There might eventually be a value converter involved in processing this value, and the value is a plain string. However, that is not evaluated until a XAML object writer processes this node stream. The XAML object writer possesses the necessary XAML schema context, type system mapping, and other support needed for value conversions.  
  
-   An `EndMember` node can be followed by a `StartMember` node for a subsequent member, or by an `EndObject` node for the member owner.  
  
-   An `EndObject` node can be followed by an `EndMember` node. It can also be followed by a `StartObject` node for cases where the objects are peers in a collection's items. Or it can be followed by a `Namespace` node, which applies to an upcoming `StartObject`.  
  
    -   For the unique case of closing the entire node stream, the `EndObject` of the root is not followed by anything; the reader is now end-of-file, and <xref:System.Xaml.XamlReader.Read%2A> returns `false`.  
  
<a name="value_converters_and_the_xaml_node_stream"></a>   
## Value Converters and the XAML Node Stream  
 A value converter is a general term for a markup extension, a type converter (including value serializers) or another dedicated class that is reported as a value converter through the XAML type system. In the XAML node stream, a type converter usage and a markup extension usage have very different representations.  
  
### Type Converters in the XAML Node Stream  
 An attribute set that eventually results in a type converter usage is reported in the XAML node stream as a value of a member. The XAML node stream does not attempt to produce a type converter instance object and pass the value to it. Using a type converter's conversion implementation requires invoking the XAML schema context and using it for type-mapping. Even determining which type converter class should be used to process the value requires the XAML schema context indirectly. When you use the default XAML schema context, that information is available from the XAML type system. If you need the type converter class information at the XAML node stream level before connection to a XAML writer, you can obtain it from the <xref:System.Xaml.XamlMember> information of the member being set. But otherwise, type converter input should be preserved in the XAML node stream as a plain value until the remainder of operations that require the type mapping system and XAML schema context are performed, for example the object creation by a XAML object writer.  
  
 For example, consider the following class definition outline and XAML usage for it:  
  
```  
public class BoardSizeConverter : TypeConverter {  
  //converts from string to an int[2] by splitting on an "x" char  
}  
public class GameBoard {  
  [TypeConverter(typeof(BoardSizeConverter))]  
  public int[] BoardSize; //2x2 array, initialization not shown  
}  
```  
  
```xaml  
<GameBoard BoardSize="8x8"/>  
```  
  
 A text representation of the XAML node stream for this usage could be expressed as the following:  
  
 `StartObject` with <xref:System.Xaml.XamlType> representing `GameBoard`  
  
 `StartMember` with <xref:System.Xaml.XamlMember> representing `BoardSize`  
  
 `Value` node, with text string "`8x8`"  
  
 `EndMember` matches `BoardSize`  
  
 `EndObject` matches `GameBoard`  
  
 Notice that there is no type converter instance in this node stream. But you can get type converter information by calling <xref:System.Xaml.XamlMember.TypeConverter%2A?displayProperty=nameWithType> on the <xref:System.Xaml.XamlMember> for `BoardSize`. If you have a valid XAML schema context, you can also invoke the converter methods by obtaining an instance from <xref:System.Xaml.Schema.XamlValueConverter%601.ConverterInstance%2A>.  
  
### Markup Extensions in the XAML Node Stream  
 A markup extension usage is reported in the XAML node stream as an object node within a member, where the object represents a markup extension instance. Thus a markup extension usage is presented more explicitly in the node stream representation than a type converter usage is, and carries more information. <xref:System.Xaml.XamlMember> information could not have told you anything about the markup extension, because the usage is situational and varies in each possible markup case; it is not dedicated and implicit per type or member as is the case with type converters.  
  
 The node stream representation of markup extensions as object nodes is the case even if the markup extension usage was made in attribute form in the XAML text markup (which is often the case). Markup extension usages that used an explicit object element form are treated the same way.  
  
 Within a markup extension object node, there may be members of that markup extension. The XAML node stream representation preserves the usage of that markup extension, whether that be a positional parameter usage or a usage with explicit named parameters.  
  
 For a positional parameter usage, the XAML node stream contains a XAML language-defined property `_PositionalParameters` that records the usage. This property is a generic <xref:System.Collections.Generic.List%601> with <xref:System.Object> constraint. The constraint is object and not string because conceivably a positional parameter usage could contain nested markup extension usages within it. To access the positional parameters from the usage, you could iterate through the list and use the indexers for individual list values.  
  
 For a named parameter usage, each named parameter is represented as a member node of that name in the node stream. The member values are not necessarily strings, because there could be a nested markup extension usage.  
  
 `ProvideValue` from the markup extension is not yet invoked. However, it is invoked if you connect a XAML reader and XAML writer so that `WriteEndObject` is invoked on the markup extension node when you examine it in the node stream. For this reason, you generally need the same XAML schema context available as would be used in order to form the object graph on the load path. Otherwise, `ProvideValue` from any markup extension can throw exceptions here, because it does not have expected services available.  
  
<a name="xaml_and_xml_languagedefined_members_in_the_xaml_node_stream"></a>   
## XAML and XML Language-Defined Members in the XAML Node Stream  
 Certain members are introduced to a XAML node stream because of interpretations and conventions of a XAML reader, instead of through an explicit <xref:System.Xaml.XamlMember> lookup or construction. Often, these members are XAML directives. In some cases, it is the act of reading the XAML that introduces the directive into the XAML node stream. In other words, the original input XAML text did not explictly specify the member directive, but the XAML reader inserts the directive in order to satisfy a structural XAML convention and report information in the XAML node stream before that information is lost.  
  
 The following list notes all cases where a XAML reader is expected to introduce a directive XAML member node, and how that member node is identified in the .NET Framework XAML Services implementations.  
  
-   **Initialization text for an object node:** The name of this member node is `_Initialization`, it represents a XAML directive, and it is defined in the XAML language XAML namespace. You can get a static entity for it from <xref:System.Xaml.XamlLanguage.Initialization%2A>.  
  
-   **Positional parameters for a markup extension:** The name of this member node is `_PositionalParameters`, and it is defined in the XAML language XAML namespace. It always contains a generic list of objects, each of which is a positional parameter pre-separated by splitting on the `,` delimiter character as supplied in the input XAML. You can get a static entity for the positional parameters directive from <xref:System.Xaml.XamlLanguage.PositionalParameters%2A>.  
  
-   **Unknown content:** The name of this member node is `_UnknownContent`. Strictly speaking, it is a <xref:System.Xaml.XamlDirective>, and it is defined in the XAML language XAML namespace. This directive is used as a sentinel for cases where a XAML object element contains content in the source XAML but no content property can be determined under the currently available XAML schema context. You can detect this case in a XAML node stream by checking for members named `_UnknownContent`. If no other action is taken in a load path XAML node stream, the default <xref:System.Xaml.XamlObjectWriter> throws on attempted `WriteEndObject` when it encounters the `_UnknownContent` member on any object. The default <xref:System.Xaml.XamlXmlWriter> does not throw, and treats the member as implicit. You can get a static entity for `_UnknownContent` from <xref:System.Xaml.XamlLanguage.UnknownContent%2A>.  
  
-   **Collection property of a collection:**Although the backing CLR type of a collection class that is used for XAML usually has a dedicated named property that holds the collection items, that property is not known to a XAML type system prior to backing type resolution. Instead, the XAML node stream introduces an `Items` placeholder as a member of the collection XAML type. In the .NET Framework XAML Services implementation the name of this directive / member in the node stream is `_Items`. A constant for this directive can be obtained from <xref:System.Xaml.XamlLanguage.Items%2A>.  
  
     Note that a XAML node stream might contain an Items property with items that turn out to not be parseable based on the backing type resolution and XAML schema context. For example,  
  
-   **XML-defined members:** The XML-defined `xml:base`, `xml:lang` and `xml:space` members are reported as XAML directives named `base`, `lang`, and `space` in the .NET Framework XAML Services implementations. The namespace for these is the XML namespace `http://www.w3.org/XML/1998/namespace`. Constants for each of these can be obtained from <xref:System.Xaml.XamlLanguage>.  
  
## Node Order  
 In some cases, <xref:System.Xaml.XamlXmlReader> changes the order of XAML nodes in the XAML node stream, versus the order the nodes appear if viewed in the markup or if processed as XML. This is done in order to order the nodes such that a <xref:System.Xaml.XamlObjectWriter> can process the node stream in a forward-only manner.  In .NET Framework XAML Services, the XAML reader reorders nodes rather than leaving this task to the XAML writer, as a performance optimization for XAML object writer consumers of the node stream.  
  
 Certain directives are intended specifically to provide more information for the creation of an object from an object element. These directives are: `Initialization`, `PositionalParameters`, `TypeArguments`, `FactoryMethod`, `Arguments`. The .NET Framework XAML Services XAML readers attempt to place these directives as the first members in the node stream following an object's `StartObject`, for reasons that are explained in the next section.  
  
### XamlObjectWriter Behavior and Node Order  
 `StartObject` to a <xref:System.Xaml.XamlObjectWriter> is not necessarily a signal to the XAML object writer to immediately construct the object instance. XAML includes several language features that make it possible to initialize an object with additional input, and to not rely entirely on invoking a default constructor to produce the initial object, and only then setting properties. These features include: <xref:System.Windows.Markup.XamlDeferLoadAttribute>; initialization text; [x:TypeArguments](../../../docs/framework/xaml-services/x-typearguments-directive.md); positional parameters of a markup extension; factory methods and associated [x:Arguments](../../../docs/framework/xaml-services/x-arguments-directive.md) nodes (XAML 2009). Each of these cases delay the actual object construction, and because the node stream is reordered, the XAML object writer can rely on a behavior of actually constructing the instance whenever a start member is encountered that is not specifically a construction directive for that object type.  
  
### GetObject  
 `GetObject` represents a XAML node where rather than constructing a new object, a XAML object writer should instead get the value of the object's containing property. A typical  case where a `GetObject` node is encountered in a XAML node stream is for a collection object or a dictionary object, when the containing property is deliberately read-only in the backing type's object model. In this scenario, the collection or dictionary often is created and initialized (usually empty) by the initialization logic of an owning type.  
  
## See Also  
 <xref:System.Xaml.XamlObjectReader>  
 [XAML Services](../../../docs/framework/xaml-services/index.md)  
 [XAML Namespaces](../../../docs/framework/xaml-services/xaml-namespaces-for-net-framework-xaml-services.md)
