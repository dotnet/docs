using System;
using System.Text;
using System.IO;
using System.Xml;

class XmlReader_Samples {

  static void Main() {
}

static void AttributeCount() {
XmlReader reader = XmlReader.Create("books.xml");
reader.ReadToDescendant("book");
//<snippet1>
// Display all attributes.
if (reader.HasAttributes) {
  Console.WriteLine("Attributes of <" + reader.Name + ">");
  for (int i = 0; i < reader.AttributeCount; i++) {
    Console.WriteLine($"  {reader[i]}");
  }
  // Move the reader back to the element node.
  reader.MoveToElement();
}
//</snippet1>
}

//==============================//
//
static void GetAttribute1() {
XmlReader reader = XmlReader.Create("books.xml");
//<snippet2>
reader.ReadToFollowing("book");
string isbn = reader.GetAttribute(2);
//</snippet2>
}
//==============================//
//
static void GetAttribute2() {
XmlReader reader = XmlReader.Create("books.xml");
//<snippet3>
reader.ReadToFollowing("book");
string isbn = reader.GetAttribute("ISBN");
Console.WriteLine("The ISBN value: " + isbn);
//</snippet3>
}

//==============================//
//
static void MoveToAttribute1() {
XmlReader reader = XmlReader.Create("books.xml");
reader.ReadToFollowing("book");
//<snippet4>
if (reader.HasAttributes) {
  Console.WriteLine("Attributes of <" + reader.Name + ">");
  for (int i = 0; i < reader.AttributeCount; i++) {
    reader.MoveToAttribute(i);
    Console.Write(" {0}={1}", reader.Name, reader.Value);
  }
reader.MoveToElement(); // Moves the reader back to the element node.
}
//</snippet4>
}

//==============================//
//
static void MoveToFirstAttribute() {
XmlReader reader = XmlReader.Create("books.xml");
//<snippet5>
reader.ReadToFollowing("book");
reader.MoveToFirstAttribute();
string genre = reader.Value;
Console.WriteLine("The genre value: " + genre);
//</snippet5>
}

//==============================//
//
static void MoveToNextAttribute() {
XmlReader reader = XmlReader.Create("books.xml");
reader.ReadToFollowing("book");
//<snippet6>
if (reader.HasAttributes) {
  Console.WriteLine("Attributes of <" + reader.Name + ">");
  while (reader.MoveToNextAttribute()) {
    Console.WriteLine($" {reader.Name}={reader.Value}");
  }
  // Move the reader back to the element node.
  reader.MoveToElement();
}
//</snippet6>
}

//==============================//
//
static void Item() {
XmlReader reader = XmlReader.Create("books.xml");
//<snippet7>
reader.ReadToDescendant("book");
string isbn =reader["ISBN"];
Console.WriteLine("The ISBN value: " + isbn);
//</snippet7>
}

//==============================//
//
static void Node_Value() {

//<snippet8>
XmlReaderSettings settings = new XmlReaderSettings();
settings.DtdProcessing = DtdProcessing.Parse;
XmlReader reader = XmlReader.Create("items.xml", settings);

reader.MoveToContent();
  // Parse the file and display each of the nodes.
  while (reader.Read()) {
    switch (reader.NodeType) {
      case XmlNodeType.Element:
          Console.Write("<{0}>", reader.Name);
          break;
      case XmlNodeType.Text:
          Console.Write(reader.Value);
          break;
       case XmlNodeType.CDATA:
           Console.Write("<![CDATA[{0}]]>", reader.Value);
           break;
       case XmlNodeType.ProcessingInstruction:
           Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
           break;
       case XmlNodeType.Comment:
           Console.Write("<!--{0}-->", reader.Value);
           break;
       case XmlNodeType.XmlDeclaration:
           Console.Write("<?xml version='1.0'?>");
           break;
       case XmlNodeType.Document:
           break;
       case XmlNodeType.DocumentType:
           Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
           break;
       case XmlNodeType.EntityReference:
           Console.Write(reader.Name);
           break;
       case XmlNodeType.EndElement:
           Console.Write("</{0}>", reader.Name);
           break;
   }
}
//</snippet8>
}

//==============================//
//
static void NamespaceURI() {
//<snippet9>
XmlReader reader = XmlReader.Create("book2.xml");

// Parse the file.  If they exist, display the prefix and
// namespace URI of each node.
while (reader.Read()) {
  if (reader.IsStartElement()) {
    if (reader.Prefix==String.Empty)
                {
                    Console.WriteLine($"<{reader.LocalName}>");
                }
                else {
      Console.Write("<{0}:{1}>", reader.Prefix, reader.LocalName);
      Console.WriteLine(" The namespace URI is " + reader.NamespaceURI);
    }
  }
}
reader.Close();
//</snippet9>
}

//==============================//
//
static void IsStartElement() {
XmlReader reader = XmlReader.Create("elems.xml");
//<snippet10>
while (reader.Read()) {
  if (reader.IsStartElement()) {
    if (reader.IsEmptyElement)
                {
                    Console.WriteLine($"<{reader.Name}/>");
                }
                else {
      Console.Write("<{0}> ", reader.Name);
      reader.Read(); // Read the start tag.
      if (reader.IsStartElement())  // Handle nested elements.
        Console.Write("\r\n<{0}>", reader.Name);
      Console.WriteLine(reader.ReadString());  //Read the text content of the element.
    }
  }
}
//</snippet10>
}

//==============================//
//
static void ReadEndElement() {
//<snippet11>
using (XmlReader reader = XmlReader.Create("book3.xml")) {

  // Parse the XML document.  ReadString is used to
  // read the text content of the elements.
  reader.Read();
  reader.ReadStartElement("book");
  reader.ReadStartElement("title");
  Console.Write("The content of the title element:  ");
  Console.WriteLine(reader.ReadString());
  reader.ReadEndElement();
  reader.ReadStartElement("price");
  Console.Write("The content of the price element:  ");
  Console.WriteLine(reader.ReadString());
  reader.ReadEndElement();
  reader.ReadEndElement();
}
//</snippet11>
    }
//==============================//
//
static void ReadInnerXml() {
//<snippet12>
// Load the file and ignore all white space.
XmlReaderSettings settings = new XmlReaderSettings();
settings.IgnoreWhitespace = true;
using (XmlReader reader = XmlReader.Create("2books.xml")) {

  // Moves the reader to the root element.
  reader.MoveToContent();

  // Moves to book node.
  reader.Read();

  // Note that ReadInnerXml only returns the markup of the node's children
  // so the book's attributes are not returned.
  Console.WriteLine("Read the first book using ReadInnerXml...");
  Console.WriteLine(reader.ReadInnerXml());

  // ReadOuterXml returns the markup for the current node and its children
  // so the book's attributes are also returned.
  Console.WriteLine("Read the second book using ReadOuterXml...");
  Console.WriteLine(reader.ReadOuterXml());
}
//</snippet12>
    }

//==============================//
//
static void ReadSubtree() {
//<snippet13>
XmlReaderSettings settings = new XmlReaderSettings();
settings.IgnoreWhitespace = true;
using (XmlReader reader = XmlReader.Create("books.xml", settings)) {

  // Position the reader on the second book node
  reader.ReadToFollowing("Book");
  reader.Skip();

  // Create another reader that contains just the second book node.
  XmlReader inner = reader.ReadSubtree();

  inner.ReadToDescendant("Title");
  Console.WriteLine(inner.Name);

  // Do additional processing on the inner reader. After you
  // are done, call Close on the inner reader and
  // continue processing using the original reader.
  inner.Close();
}
//</snippet13>
}

//==============================//
//
static void ReadtoDescendant() {
//<snippet14>
using (XmlReader reader = XmlReader.Create("2books.xml")) {

  // Move the reader to the second book node.
  reader.MoveToContent();
  reader.ReadToDescendant("book");
  reader.Skip(); //Skip the first book.

  // Parse the file starting with the second book node.
  do {
     switch (reader.NodeType) {
        case XmlNodeType.Element:
           Console.Write("<{0}", reader.Name);
           while (reader.MoveToNextAttribute()) {
               Console.Write(" {0}='{1}'", reader.Name, reader.Value);
           }
           Console.Write(">");
           break;
        case XmlNodeType.Text:
           Console.Write(reader.Value);
           break;
        case XmlNodeType.EndElement:
           Console.Write("</{0}>", reader.Name);
           break;
     }
  }  while (reader.Read());
}
//</snippet14>
}

//==============================//
//
static void ReadToFollowing() {
//<snippet15>
using (XmlReader reader = XmlReader.Create("books.xml")) {
    reader.ReadToFollowing("book");
    do {
       Console.WriteLine($"ISBN: {reader.GetAttribute("ISBN")}");
    } while (reader.ReadToNextSibling("book"));
}
//</snippet15>
}

//==============================//
//
static void HasValue() {
//<snippet16>
XmlReaderSettings settings = new XmlReaderSettings();
settings.IgnoreWhitespace = true;
using (XmlReader reader = XmlReader.Create("book1.xml", settings)) {
  // Parse the file and display each node.
  while (reader.Read()) {
    if (reader.HasValue)
      Console.WriteLine($"({reader.NodeType})  {reader.Name}={reader.Value}");
    else
      Console.WriteLine($"({reader.NodeType}) {reader.Name}");
  }
}
//</snippet16>
}

//==============================//
//
static void IsStartElement_2() {
using (XmlReader reader = XmlReader.Create("books.xml")) {
//<snippet17>
  // Parse the file and display each price node.
  while (reader.Read()) {
    if (reader.IsStartElement("price")) {
       Console.WriteLine(reader.ReadInnerXml());
    }
  }
//</snippet17>
}
}
}