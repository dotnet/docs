---
title: "Extending the DOM"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: b5489c96-4afd-439a-a25d-fc82eb4a148d
caps.latest.revision: 5
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Extending the DOM
The Microsoft .NET Framework includes a base set of classes that provides an implementation of the XML Document Object Model (DOM). The <xref:System.Xml.XmlNode>, and its derived classes, provides methods and properties that allow you to navigate, query, and modify the content and structure of an XML document.  
  
 When XML content is loaded into memory using the DOM, the nodes created contain information such as node name, node type, and so on. There may be occasions where you require specific node information that the base classes do not provide. For example, you may want to see the line number and position of the node. In this case, you can derive new classes from the existing DOM classes and add additional functionality.  
  
 There are two general guidelines when deriving new classes:  
  
-   It is recommended that you never derive from the <xref:System.Xml.XmlNode> class. Instead, it is recommended that you derive classes from the class corresponding to the node type that you are interested in. For example, if you want to return additional information on attribute nodes, you can derive from the <xref:System.Xml.XmlAttribute> class.  
  
-   Except for the node creation methods, it is recommended that when overriding a function, you should always call the base version of the function and then add any additional processing.  
  
## Creating Your Own Node Instances  
 The <xref:System.Xml.XmlDocument> class contains node creation methods. When an XML file is loaded, these methods are called to create the nodes. You can override these methods so that your node instances are created when a document is loaded. For example, if you have extended the <xref:System.Xml.XmlElement> class, you would inherit the <xref:System.Xml.XmlDocument> class and override the <xref:System.Xml.XmlDocument.CreateElement%2A> method.  
  
 The following example shows how to override the <xref:System.Xml.XmlDocument.CreateElement%2A> method to return your implementation of the <xref:System.Xml.XmlElement> class.  
  
```vb  
Class LineInfoDocument  
    Inherits XmlDocument  
        Public Overrides Function CreateElement(prefix As String, localname As String, nsURI As String) As XmlElement  
        Dim elem As New LineInfoElement(prefix, localname, nsURI, Me)  
        Return elem  
    End Function 'CreateElement  
End Class 'LineInfoDocument  
```  
  
```csharp  
class LineInfoDocument : XmlDocument {  
  public override XmlElement CreateElement(string prefix, string localname, string nsURI) {  
  LineInfoElement elem = new LineInfoElement(prefix, localname, nsURI, this);  
  return elem;  
  }  
```  
  
## Extending a Class  
 To extend a class, derive your class from one of the existing DOM classes. You can then override any of the virtual methods or properties in the base class, or add your own.  
  
 In the following example, a new class is created, which implements the <xref:System.Xml.XmlElement> class and the <xref:System.Xml.IXmlLineInfo> interface. Additional methods and properties are defined which allows users to gather line information.  
  
```vb  
Class LineInfoElement  
   Inherits XmlElement  
   Implements IXmlLineInfo  
   Private lineNumber As Integer = 0  
   Private linePosition As Integer = 0  
  
   Friend Sub New(prefix As String, localname As String, nsURI As String, doc As XmlDocument)  
      MyBase.New(prefix, localname, nsURI, doc)  
      CType(doc, LineInfoDocument).IncrementElementCount()  
   End Sub 'New  
  
   Public Sub SetLineInfo(linenum As Integer, linepos As Integer)  
      lineNumber = linenum  
      linePosition = linepos  
   End Sub 'SetLineInfo  
  
   Public ReadOnly Property LineNumber() As Integer  
      Get  
         Return lineNumber  
      End Get  
   End Property  
  
   Public ReadOnly Property LinePosition() As Integer  
      Get  
         Return linePosition  
      End Get  
   End Property  
  
   Public Function HasLineInfo() As Boolean  
      Return True  
   End Function 'HasLineInfo  
End Class 'LineInfoElement ' End LineInfoElement class.  
```  
  
```csharp  
class LineInfoElement : XmlElement, IXmlLineInfo {  
   int lineNumber = 0;  
   int linePosition = 0;  
   internal LineInfoElement( string prefix, string localname, string nsURI, XmlDocument doc ) : base( prefix, localname, nsURI, doc ) {  
       ( (LineInfoDocument)doc ).IncrementElementCount();  
  }     
  public void SetLineInfo( int linenum, int linepos ) {  
      lineNumber = linenum;  
      linePosition = linepos;  
  }  
  public int LineNumber {  
     get {  
       return lineNumber;  
     }  
  }  
  public int LinePosition {  
      get {  
        return linePosition;  
      }  
  }  
  public bool HasLineInfo() {   
    return true;   
  }  
} // End LineInfoElement class.  
```  
  
### Example  
 The following example counts the number of elements in an XML document.  
  
```vb  
Imports System  
Imports System.Xml  
Imports System.IO  
  
 _  
  
Class LineInfoDocument  
   Inherits XmlDocument  
  
   Private elementCount As Integer  
  
   Friend Sub New()  
      elementCount = 0  
   End Sub 'New  
  
   Public Overrides Function CreateElement(prefix As String, localname As String, nsURI As String) As XmlElement  
      Dim elem As New LineInfoElement(prefix, localname, nsURI, Me)  
      Return elem  
   End Function 'CreateElement  
  
   Public Sub IncrementElementCount()  
      elementCount += 1  
   End Sub 'IncrementElementCount  
  
   Public Function GetCount() As Integer  
      Return elementCount  
   End Function 'GetCount  
End Class 'LineInfoDocument  
 _ 'End LineInfoDocument class.  
  
Class LineInfoElement  
   Inherits XmlElement  
  
   Friend Sub New(prefix As String, localname As String, nsURI As String, doc As XmlDocument)  
      MyBase.New(prefix, localname, nsURI, doc)  
      CType(doc, LineInfoDocument).IncrementElementCount()  
   End Sub 'New  
End Class 'LineInfoElement  
 _ 'End LineInfoElement class.  
  
Public Class Test  
  
   Private filename As [String] = "book.xml"  
  
   Public Shared Sub Main()  
  
      Dim doc As New LineInfoDocument()  
      doc.Load(filename)  
      Console.WriteLine("Number of elements in {0}: {1}", filename, doc.GetCount())  
   End Sub 'Main   
End Class 'Test  
```  
  
```csharp  
using System;  
using System.Xml;  
using System.IO;  
  
class LineInfoDocument : XmlDocument {  
  
  int elementCount;  
  internal LineInfoDocument():base() {  
    elementCount = 0;  
  }  
  
  public override XmlElement CreateElement( string prefix, string localname, string nsURI) {  
    LineInfoElement elem = new LineInfoElement(prefix, localname, nsURI, this );  
    return elem;  
  }  
  
  public void IncrementElementCount() {  
     elementCount++;  
  }  
  
  public int GetCount() {  
     return elementCount;  
  }  
} // End LineInfoDocument class.  
  
class LineInfoElement:XmlElement {  
  
    internal LineInfoElement( string prefix, string localname, string nsURI, XmlDocument doc ):base( prefix,localname,nsURI, doc ){  
      ((LineInfoDocument)doc).IncrementElementCount();  
    }     
} // End LineInfoElement class.  
  
public class Test {  
  
  const String filename = "book.xml";  
  public static void Main() {  
  
     LineInfoDocument doc =new LineInfoDocument();  
     doc.Load(filename);      
     Console.WriteLine("Number of elements in {0}: {1}", filename, doc.GetCount());  
  
  }  
}   
```  
  
##### Input  
 book.xml  
  
```xml  
<!--sample XML fragment-->  
<book genre='novel' ISBN='1-861001-57-5' misc='sale-item'>  
  <title>The Handmaid's Tale</title>  
  <price>14.95</price>  
</book>  
```  
  
##### Output  
  
```  
Number of elements in book.xml: 3  
```  
  
 For an example showing how to extend the XML DOM classes (System.Xml), see www.gotdotnet.com/userfiles/XMLDom/extendDOM.zip.  
  
## Node Event Handler  
 The .NET Framework implementation of the DOM also includes an event system that enables you to receive and handle events when nodes in an XML document change. Using the <xref:System.Xml.XmlNodeChangedEventHandler> and <xref:System.Xml.XmlNodeChangedEventArgs> classes, you can capture `NodeChanged`, `NodeChanging`, `NodeInserted`, `NodeInserting`, `NodeRemoved`, and `NodeRemoving` events.  
  
 The event-handling process works exactly the same in derived classes as it would in the original DOM classes.  
  
 For more information regarding node event handling, see [Events](../../../../docs/standard/events/index.md) and <xref:System.Xml.XmlNodeChangedEventHandler>.  
  
## Default Attributes and the CreateElement Method  
 If you are overriding the <xref:System.Xml.XmlDocument.CreateElement%2A> method in a derived class, default attributes are not added when you are creating new elements while editing the document. This is only an issue while editing. Because the <xref:System.Xml.XmlDocument.CreateElement%2A> method is responsible for adding default attributes to an <xref:System.Xml.XmlDocument>, you must code this functionality in the <xref:System.Xml.XmlDocument.CreateElement%2A> method. If you are loading an <xref:System.Xml.XmlDocument> that includes default attributes, they will be handled correctly. For more information on default attributes, see [Creating New Attributes for Elements in the DOM](../../../../docs/standard/data/xml/creating-new-attributes-for-elements-in-the-dom.md).  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)
