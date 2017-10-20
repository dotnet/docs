---
title: "Creating XML Trees in C# (LINQ to XML)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: cc74234a-0bac-4327-9c8c-5a2ead15b595
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Creating XML Trees in C# (LINQ to XML)
This section provides information about creating XML trees in C#.  
  
 For information about using the results of LINQ queries as the content for an <xref:System.Xml.Linq.XElement>, see [Functional Construction (LINQ to XML) (C#)](../../../../csharp/programming-guide/concepts/linq/functional-construction-linq-to-xml.md).  
  
## Constructing Elements  
 The signatures of the <xref:System.Xml.Linq.XElement> and <xref:System.Xml.Linq.XAttribute> constructors let you pass the contents of the element or attribute as arguments to the constructor. Because one of the constructors takes a variable number of arguments, you can pass any number of child elements. Of course, each of those child elements can contain their own child elements. For any element, you can add any number of attributes.  
  
 When adding <xref:System.Xml.Linq.XNode> (including <xref:System.Xml.Linq.XElement>) or <xref:System.Xml.Linq.XAttribute> objects, if the new content has no parent, the objects are simply attached to the XML tree. If the new content already is parented, and is part of another XML tree, the new content is cloned, and the newly cloned content is attached to the XML tree. The last example in this topic demonstrates this.  
  
 To create a `contacts`<xref:System.Xml.Linq.XElement>, you could use the following code:  
  
```csharp  
XElement contacts =  
    new XElement("Contacts",  
        new XElement("Contact",  
            new XElement("Name", "Patrick Hines"),   
            new XElement("Phone", "206-555-0144"),  
            new XElement("Address",  
                new XElement("Street1", "123 Main St"),  
                new XElement("City", "Mercer Island"),  
                new XElement("State", "WA"),  
                new XElement("Postal", "68042")  
            )  
        )  
    );  
```  
  
 If indented properly, the code to construct <xref:System.Xml.Linq.XElement> objects closely resembles the structure of the underlying XML.  
  
## XElement Constructors  
 The <xref:System.Xml.Linq.XElement> class uses the following constructors for functional construction. Note that there are some other constructors for <xref:System.Xml.Linq.XElement>, but because they are not used for functional construction they are not listed here.  
  
|Constructor|Description|  
|-----------------|-----------------|  
|`XElement(XName name, object content)`|Creates an <xref:System.Xml.Linq.XElement>. The `name` parameter specifies the name of the element; `content` specifies the content of the element.|  
|`XElement(XName name)`|Creates an <xref:System.Xml.Linq.XElement> with its <xref:System.Xml.Linq.XName> initialized to the specified name.|  
|`XElement(XName name, params object[] content)`|Creates an <xref:System.Xml.Linq.XElement> with its <xref:System.Xml.Linq.XName> initialized to the specified name. The attributes and/or child elements are created from the contents of the parameter list.|  
  
 The `content` parameter is extremely flexible. It supports any type of object that is a valid child of an <xref:System.Xml.Linq.XElement>. The following rules apply to different types of objects passed in this parameter:  
  
-   A string is added as text content.  
  
-   An <xref:System.Xml.Linq.XElement> is added as a child element.  
  
-   An <xref:System.Xml.Linq.XAttribute> is added as an attribute.  
  
-   An <xref:System.Xml.Linq.XProcessingInstruction>, <xref:System.Xml.Linq.XComment>, or <xref:System.Xml.Linq.XText> is added as child content.  
  
-   An <xref:System.Collections.IEnumerable> is enumerated, and these rules are applied recursively to the results.  
  
-   For any other type, its `ToString` method is called and the result is added as text content.  
  
### Creating an XElement with Content  
 You can create an <xref:System.Xml.Linq.XElement> that contains simple content with a single method call. To do this, specify the content as the second parameter, as follows:  
  
```csharp  
XElement n = new XElement("Customer", "Adventure Works");  
Console.WriteLine(n);  
```  
  
 This example produces the following output:  
  
```xml  
<Customer>Adventure Works</Customer>  
```  
  
 You can pass any type of object as the content. For example, the following code creates an element that contains a floating point number as content:  
  
```csharp  
XElement n = new XElement("Cost", 324.50);  
Console.WriteLine(n);  
```  
  
 This example produces the following output:  
  
```xml  
<Cost>324.5</Cost>  
```  
  
 The floating point number is boxed and passed in to the constructor. The boxed number is converted to a string and used as the content of the element.  
  
### Creating an XElement with a Child Element  
 If you pass an instance of the <xref:System.Xml.Linq.XElement> class for the content argument, the constructor creates an element with a child element:  
  
```csharp  
XElement shippingUnit = new XElement("ShippingUnit",  
    new XElement("Cost", 324.50)  
);  
Console.WriteLine(shippingUnit);  
```  
  
 This example produces the following output:  
  
```xml  
<ShippingUnit>  
  <Cost>324.5</Cost>  
</ShippingUnit>  
```  
  
### Creating an XElement with Multiple Child Elements  
 You can pass in a number of <xref:System.Xml.Linq.XElement> objects for the content. Each of the <xref:System.Xml.Linq.XElement> objects is included as a child element.  
  
```csharp  
XElement address = new XElement("Address",  
    new XElement("Street1", "123 Main St"),  
    new XElement("City", "Mercer Island"),  
    new XElement("State", "WA"),  
    new XElement("Postal", "68042")  
);  
Console.WriteLine(address);  
```  
  
 This example produces the following output:  
  
```xml  
<Address>  
  <Street1>123 Main St</Street1>  
  <City>Mercer Island</City>  
  <State>WA</State>  
  <Postal>68042</Postal>  
</Address>  
```  
  
 By extending the above example, you can create an entire XML tree, as follows:  
  
```csharp  
XElement contacts =  
    new XElement("Contacts",  
        new XElement("Contact",  
            new XElement("Name", "Patrick Hines"),                                                   
            new XElement("Phone", "206-555-0144"),  
            new XElement("Address",  
                new XElement("Street1", "123 Main St"),  
                new XElement("City", "Mercer Island"),  
                new XElement("State", "WA"),  
                new XElement("Postal", "68042")  
            )  
        )  
    );  
Console.WriteLine(contacts);  
```  
  
 This example produces the following output:  
  
```xml  
<Contacts>  
  <Contact>  
    <Name>Patrick Hines</Name>  
    <Phone>206-555-0144</Phone>  
    <Address>  
      <Street1>123 Main St</Street1>  
      <City>Mercer Island</City>  
      <State>WA</State>  
      <Postal>68042</Postal>  
    </Address>  
  </Contact>  
</Contacts>  
```  
  
### Creating an Empty Element  
 To create an empty <xref:System.Xml.Linq.XElement>, you do not pass any content to the constructor. The following example creates an empty element:  
  
```csharp  
XElement n = new XElement("Customer");  
Console.WriteLine(n);  
```  
  
 This example produces the following output:  
  
```xml  
<Customer />  
```  
  
### Attaching vs. Cloning  
 As mentioned previously, when adding <xref:System.Xml.Linq.XNode> (including <xref:System.Xml.Linq.XElement>) or <xref:System.Xml.Linq.XAttribute> objects, if the new content has no parent, the objects are simply attached to the XML tree. If the new content already is parented and is part of another XML tree, the new content is cloned, and the newly cloned content is attached to the XML tree.  
  
```csharp  
// Create a tree with a child element.  
XElement xmlTree1 = new XElement("Root",  
    new XElement("Child1", 1)  
);  
  
// Create an element that is not parented.  
XElement child2 = new XElement("Child2", 2);  
  
// Create a tree and add Child1 and Child2 to it.  
XElement xmlTree2 = new XElement("Root",  
    xmlTree1.Element("Child1"),  
    child2  
);  
  
// Compare Child1 identity.  
Console.WriteLine("Child1 was {0}",  
    xmlTree1.Element("Child1") == xmlTree2.Element("Child1") ?  
    "attached" : "cloned");  
  
// Compare Child2 identity.  
Console.WriteLine("Child2 was {0}",  
    child2 == xmlTree2.Element("Child2") ?  
    "attached" : "cloned");  
```  
  
 This example produces the following output:  
  
```  
Child1 was cloned  
Child2 was attached  
```  
  
## See Also  
 [Creating XML Trees (C#)](../../../../csharp/programming-guide/concepts/linq/creating-xml-trees.md)
