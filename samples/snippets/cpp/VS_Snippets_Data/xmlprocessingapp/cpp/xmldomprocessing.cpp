// This is the main DLL file.


#include "stdafx.h"

#include "XMLDOMProcessing.h"

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;
using namespace System::Text;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::IO;
using namespace std;

#pragma region Constants



#pragma endregion

#pragma region Load and Save XML
//************************************************************************************
//
//  Loads XML from a file. If the file is not found, load XML from a string.
//
//************************************************************************************

XmlDocument ^XMLDOMProcessing::XMLHelperMethods::LoadDocument(bool generateXML)
{
	//<Snippet1>
	XmlDocument ^doc = gcnew XmlDocument();
	doc->PreserveWhitespace = true;
	try
	{doc->Load("booksData.xml");}
	catch (System::IO::FileNotFoundException ^e1)
	{
		// If no book is found, generate some XML.

		doc->LoadXml("<?xml version=\"1.0\"?> \n" +
		"<books xmlns=\"http://www.contoso.com/books\"> \n" +
		"  <book genre=\"novel\" ISBN=\"1-861001-57-8\" publicationdate=\"1823-01-28\"> \n" +
		"    <title>Pride And Prejudice</title> \n" +
		"    <price>24.95</price> \n" +
		"  </book> \n" +
		"  <book genre=\"novel\" ISBN=\"1-861002-30-1\" publicationdate=\"1985-01-01\"> \n" +
		"    <title>The Handmaid's Tale</title> \n" +
		"    <price>29.95</price> \n" +
		"  </book> \n" +
		"</books>");
	}
	//</Snippet1>
	return doc;
}

//************************************************************************************
//
//  Helper method that generates an XML string.
//
//************************************************************************************


String ^XMLDOMProcessing::XMLHelperMethods::generateXMLString()
{
	String ^xml = "<?xml version=\"1.0\"?> \n" + "<books xmlns=\"http://www.contoso.com/books\"> \n" + "  <book genre=\"novel\" ISBN=\"1-861001-57-8\" publicationdate=\"1823-01-28\"> \n" + "    <title>Pride And Prejudice</title> \n" + "    <price>24.95</price> \n" + "  </book> \n" + "  <book genre=\"novel\" ISBN=\"1-861002-30-1\" publicationdate=\"1985-01-01\"> \n" + "    <title>The Handmaid's Tale</title> \n" + "    <price>29.95</price> \n" + "  </book> \n" + "  <book genre=\"novel\" ISBN=\"1-861001-45-3\" publicationdate=\"1811-01-01\"> \n" + "    <title>Sense and Sensibility</title> \n" + "    <price>19.95</price> \n" + "  </book> \n" + "</books>";
	return xml;
}

//************************************************************************************
//
//  Loads XML from a file. If the file is not found, load XML from a string.
//
//************************************************************************************

void XMLDOMProcessing::XMLHelperMethods::SaveXML(XmlDocument ^doc)
{
	doc->Save(Constants::booksFileName);
}
#pragma endregion

#pragma region Validate XML against a Schema
//<Snippet2>
//************************************************************************************
//
//  Associate the schema with XML. Then, load the XML and validate it against
//  the schema.
//
//************************************************************************************

XmlDocument ^XMLDOMProcessing::XMLHelperMethods::LoadDocumentWithSchemaValidation(bool generateXML, bool generateSchema)
{
	XmlReader ^reader;

	XmlReaderSettings ^settings = gcnew XmlReaderSettings();

	// Helper method to retrieve schema.
	XmlSchema ^schema = getSchema(generateSchema);
	
	if (schema == nullptr)
	{
		return nullptr;
	}

	settings->Schemas->Add(schema);
	settings->ValidationEventHandler +=
		gcnew System::Xml::Schema::ValidationEventHandler
		(this, &XMLDOMProcessing::XMLHelperMethods::OnValidationEventHandler);
	settings->ValidationFlags = settings->ValidationFlags | XmlSchemaValidationFlags::ReportValidationWarnings;
	settings->ValidationType = ValidationType::Schema;

	try
	{
		reader = XmlReader::Create("booksData.xml", settings);
	}
	catch (System::IO::FileNotFoundException ^e1)
	{
		if (generateXML)
		{
			String ^xml = generateXMLString();
			array<Byte> ^byteArray = Encoding::UTF8->GetBytes(xml);
			MemoryStream ^stream = gcnew MemoryStream(byteArray);
			reader = XmlReader::Create(stream, settings);
		}
		else
		{
			return nullptr;
		}

	}

	XmlDocument ^doc = gcnew XmlDocument();
	doc->PreserveWhitespace = true;
	doc->Load(reader);
	reader->Close();

	return doc;
}

//************************************************************************************
//
//  Helper method that generates an XML Schema.
//
//************************************************************************************

String ^XMLDOMProcessing::XMLHelperMethods::generateXMLSchema()
{
	String ^xmlSchema = "<?xml version=\"1.0\" encoding=\"utf-8\"?> " + 
		"<xs:schema attributeFormDefault=\"unqualified\" " + 
		"elementFormDefault=\"qualified\" targetNamespace=\"http://www.contoso.com/books\" " + 
		"xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"> " + "<xs:element name=\"books\"> " + 
		"<xs:complexType> " + "<xs:sequence> " + "<xs:element maxOccurs=\"unbounded\" name=\"book\"> " + 
		"<xs:complexType> " + "<xs:sequence> " + "<xs:element name=\"title\" type=\"xs:string\" /> " + 
		"<xs:element name=\"price\" type=\"xs:decimal\" /> " + "</xs:sequence> " + 
		"<xs:attribute name=\"genre\" type=\"xs:string\" use=\"required\" /> " + 
		"<xs:attribute name=\"publicationdate\" type=\"xs:date\" use=\"required\" /> " + 
		"<xs:attribute name=\"ISBN\" type=\"xs:string\" use=\"required\" /> " + "</xs:complexType> " + 
		"</xs:element> " + "</xs:sequence> " + "</xs:complexType> " + "</xs:element> " + "</xs:schema> ";
	
	return xmlSchema;
}

//************************************************************************************
//
//  Helper method that gets a schema
//
//************************************************************************************

XmlSchema ^XMLDOMProcessing::XMLHelperMethods::getSchema(bool generateSchema)
{
	XmlSchemaSet ^xs = gcnew XmlSchemaSet();
	XmlSchema ^schema;
	try
	{
		schema = xs->Add("http://www.contoso.com/books", "booksData.xsd");
	}
	catch (System::IO::FileNotFoundException ^e1)
	{
		if (generateSchema)
		{
			String ^xmlSchemaString = generateXMLSchema();
			array<Byte> ^byteArray = Encoding::UTF8->GetBytes(xmlSchemaString);
			MemoryStream ^stream = gcnew MemoryStream(byteArray);
			XmlReader ^reader = XmlReader::Create(stream);
			schema = xs->Add("http://www.contoso.com/books", reader);
		}
		else
		{
			return nullptr;
		}

	}
	return schema;
}
//************************************************************************************
//
//  Helper method to validate the XML against the schema.
//
//************************************************************************************
bool XMLDOMProcessing::XMLHelperMethods::validateXML(bool generateSchema, XmlDocument ^doc)
{
	if (doc->Schemas->Count == 0)
	{
		// Helper method to retrieve schema.
		XmlSchema ^schema = getSchema(generateSchema);
		doc->Schemas->Add(schema);
	}

	ValidationEventHandler^ eventHandler = gcnew System::Xml::Schema::ValidationEventHandler
		(this, &XMLDOMProcessing::XMLHelperMethods::OnValidationEventHandler);

	// Use an event handler to validate the XML node against the schema.
	doc->Validate(eventHandler);

	if (_IsValid == false)
	{
		_IsValid = true;
		return false;
	}
	else
	{
		return true;
	}

}
//************************************************************************************
//
//  Event handler that is raised when XML doesn't validate against the schema.
//
//************************************************************************************

void XMLDOMProcessing::XMLHelperMethods::OnValidationEventHandler(System::Object ^sender, System::Xml::Schema::ValidationEventArgs ^e)
{
	if (e->Severity == XmlSeverityType::Warning)
	{
		// do nothing.
	}
	else if (e->Severity == XmlSeverityType::Error)
	{
		// set some global variables.
		_IsValid = false;
		ValidationError = e->Message;
	}
}
//</Snippet2>
#pragma endregion

#pragma region Find elements and attributes

//************************************************************************************
//
//  Search the XML tree for a specific XMLNode element by using an attribute value.
//  Description: Must identify the namespace of the nodes and define a prefix. Also include the 
//  prefix in the XPath string.
//
//************************************************************************************
//<Snippet3>
XmlNode ^XMLDOMProcessing::XMLHelperMethods::GetBook(String ^uniqueAttribute, XmlDocument ^doc)
{
	XmlNamespaceManager ^nsmgr = gcnew XmlNamespaceManager(doc->NameTable);
	nsmgr->AddNamespace("bk", "http://www.contoso.com/books");
	String ^xPathString = "//bk:books/bk:book[@ISBN='" + uniqueAttribute + "']";
	XmlNode ^xmlNode = doc->DocumentElement->SelectSingleNode(xPathString, nsmgr);
	return xmlNode;
}
//</Snippet3>

//************************************************************************************
//
//  Get information about a specific book. Pass in an XMLNode that 
//  represents the book and populate strings passed in by reference.
//
//  **********************************************************************************  
//<Snippet4>
void XMLDOMProcessing::XMLHelperMethods::GetBookInformation
(String ^%title, String ^%ISBN, String ^%publicationDate, String ^%price, String ^%genre, XmlNode ^book)
{
	XmlElement ^bookElement = safe_cast<XmlElement^>(book);

	// Get the attributes of a book.        
	XmlAttribute ^attr = bookElement->GetAttributeNode("ISBN");
	ISBN = attr->InnerXml;

	attr = bookElement->GetAttributeNode("genre");
	genre = attr->InnerXml;

	attr = bookElement->GetAttributeNode("publicationdate");
	publicationDate = attr->InnerXml;

	// Get the values of child elements of a book.
	title = bookElement["title"]->InnerText;
	price = bookElement["price"]->InnerText;
}
//</Snippet4>

//************************************************************************************
//
//  Uses filter criteria collection in the UI to retreive specific elements and attributes.
//
//***********^************************************************************************

XmlNodeList ^XMLDOMProcessing::XMLHelperMethods::ApplyFilters(ArrayList ^conditions, ArrayList ^operatorSymbols, ArrayList ^values, XmlDocument ^doc, String ^matchString)
{
	XmlNamespaceManager ^nsmgr = gcnew XmlNamespaceManager(doc->NameTable);
	nsmgr->AddNamespace("bk", "http://www.contoso.com/books");

	String ^xPathQueryString = "//bk:books/bk:book[";
	String ^xPathQueryEnding = "]";
	ArrayList ^xPathQueryStrings = gcnew ArrayList();
	String ^booleanOperator = (matchString == "Any") ? "or " : "and ";
	int counter = 0;
	array<String^> ^operatorArray = safe_cast<array<String^>^>(operatorSymbols->ToArray(String::typeid));
	array<String^> ^valueArray = safe_cast<array<String^>^>(values->ToArray(String::typeid));

	for each (String ^condition in conditions)
	{
		String ^xPathQueryPart = "";
		String ^operatorSymbol = operatorArray[counter];
		String ^value = valueArray[counter];
		if (counter > 0)
		{
			xPathQueryString = xPathQueryString + booleanOperator;
		}
		counter++;

		if (condition == Constants::Title)
		{
			if (operatorSymbol == "Contains")
			{
				xPathQueryPart = "contains(bk:title,'" + value + "')";
			}
			else if (operatorSymbol == "Excludes")
			{
				xPathQueryPart = "not(contains(bk:title,'" + value + "'))";
			}
			else if (operatorSymbol == "=")
			{
				xPathQueryPart = "bk:title='" + value + "'";
			}
		}
		else if (condition == Constants::ISBN)
		{
			if (operatorSymbol == "Contains")
			{
				xPathQueryPart = "contains(@ISBN, '" + value + "')";
			}
			else if (operatorSymbol == "Excludes")
			{
				xPathQueryPart = "not(contains(@ISBN, '" + value + "'))";
			}
			else if (operatorSymbol == "=")
			{
				xPathQueryPart = "@ISBN='" + value + "'";
			}
		}
		else if (condition == Constants::PubDate)
		{
			xPathQueryPart = "contains(@publicationdate, '" + value + "')";
		}
		else if (condition == Constants::Price)
		{
			if (operatorSymbol == "=")
			{
				xPathQueryPart = "bk:price='" + value + "'";
			}
			else if (operatorSymbol == ">")
			{
				xPathQueryPart = "bk:price>'" + value + "'";
			}
			else if (operatorSymbol == "<")
			{
				xPathQueryPart = "bk:price<'" + value + "'";
			}
			else if (operatorSymbol == ">=")
			{
				xPathQueryPart = "bk:price>='" + value + "'";
			}
			else if (operatorSymbol == "<=")
			{
				xPathQueryPart = "bk:price<='" + value + "'";
			}
			else if (operatorSymbol == "<>")
			{
				xPathQueryPart = "bk:price!='" + value + "'";
			}
		}
		else if (condition == Constants::Genre)
		{
			xPathQueryPart = "@genre='" + value + "'";

		}

		xPathQueryString = xPathQueryString + xPathQueryPart;
	}

	xPathQueryString = xPathQueryString + xPathQueryEnding;

	XmlNodeList ^nodeList = doc->DocumentElement->SelectNodes(xPathQueryString, nsmgr);

	return nodeList;
}
#pragma endregion

#pragma region Add XML elements and attributes
//************************************************************************************
//
//  Add an element to the XML document.
//  This method creates a new book element and saves that element to the 
//  XMLDocument object. It addes attributes for the new element and introduces
//  newline characters between elements fora nice readable format.
//  
//
//************************************************************************************
//<Snippet5>
XmlElement ^XMLDOMProcessing::XMLHelperMethods::AddNewBook(String ^genre, String ^ISBN, String ^misc, String ^title, String ^price, XmlDocument ^doc)
{
	// Create a new book element.
	XmlElement ^bookElement = doc->CreateElement("book", "http://www.contoso.com/books");

	// Create attributes for book and append them to the book element.
	XmlAttribute ^attribute = doc->CreateAttribute("genre");
	attribute->Value = genre;
	bookElement->Attributes->Append(attribute);

	attribute = doc->CreateAttribute("ISBN");
	attribute->Value = ISBN;
	bookElement->Attributes->Append(attribute);

	attribute = doc->CreateAttribute("publicationdate");
	attribute->Value = misc;
	bookElement->Attributes->Append(attribute);

	// Create and append a child element for the title of the book.
	XmlElement ^titleElement = doc->CreateElement("title");
	titleElement->InnerText = title;
	bookElement->AppendChild(titleElement);

	// Introduce a newline character so that XML is nicely formatted.
	bookElement->InnerXml = bookElement->InnerXml->Replace(titleElement->OuterXml, "\n    " + titleElement->OuterXml + " \n    ");

	// Create and append a child element for the price of the book.
	XmlElement ^priceElement = doc->CreateElement("price");
	priceElement->InnerText = price;
	bookElement->AppendChild(priceElement);

	// Introduce a newline character so that XML is nicely formatted.
	bookElement->InnerXml = bookElement->InnerXml->Replace(priceElement->OuterXml, priceElement->OuterXml + "   \n  ");

	return bookElement;

}
//</Snippet5>

//************************************************************************************
//
//  Add an element to the XML document at a specific location
//  Takes a string that describes where the user wants the new node
//  to be positioned. The string comes from a series of radio buttons in a UI.
//  this method also accepts the XMLDocument in context. You have to use the 
//  this instance because it is the object that was used to generate the 
//  selectedBook XMLNode.
//
//************************************************************************************
bool XMLDOMProcessing::XMLHelperMethods::InsertBookElement(XmlElement ^bookElement, String ^position, XmlNode ^selectedBook, bool validateNode, bool generateSchema)
{
	XmlDocument ^doc = bookElement->OwnerDocument;

	String ^stringThatContainsNewline = bookElement->OuterXml;
	XmlSignificantWhitespace ^sigWhiteSpace;
	if (position == Constants::positionTop)
	{
		// Add newline characters and spaces to make XML more readable.
		sigWhiteSpace = doc->CreateSignificantWhitespace("\n  ");
		doc->DocumentElement->InsertBefore(sigWhiteSpace, doc->DocumentElement->FirstChild);
		doc->DocumentElement->InsertAfter(bookElement, doc->DocumentElement->FirstChild);

	}
	else if (position == Constants::positionBottom)
	{
		// Add newline characters to make XML more readable.
		XmlWhitespace ^whitespace = doc->CreateWhitespace("  ");
		XmlNode ^appendedNode = doc->DocumentElement->AppendChild(bookElement);
		doc->DocumentElement->InsertBefore(whitespace, appendedNode);
		sigWhiteSpace = doc->CreateSignificantWhitespace("\n");
		doc->DocumentElement->InsertAfter(sigWhiteSpace, appendedNode);

	}
	else if (position == Constants::positionAbove)
	{
		// Add newline characters to make XML more readable.
		XmlNode ^currNode = doc->DocumentElement->InsertBefore(bookElement, selectedBook);
		sigWhiteSpace = doc->CreateSignificantWhitespace("\n  ");
		doc->DocumentElement->InsertAfter(sigWhiteSpace, currNode);

	}
	else if (position == Constants::positionBelow)
	{
		// Add newline characters to make XML more readable.
		sigWhiteSpace = doc->CreateSignificantWhitespace("\n  ");
		XmlNode ^whiteSpaceNode = doc->DocumentElement->InsertAfter(sigWhiteSpace, selectedBook);
		doc->DocumentElement->InsertAfter(bookElement, whiteSpaceNode);

	}
	else
	{
		doc->DocumentElement->AppendChild(bookElement);
	}

	if (validateNode)
	{
		if (validateXML(generateSchema, doc))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	return true;
}
#pragma endregion

#pragma region Edit XML elements and attributes
//************************************************************************************
//
//  Edit an XML element
//
//************************************************************************************
//<Snippet7>
bool XMLDOMProcessing::XMLHelperMethods::editBook(String ^title, String ^ISBN, String ^publicationDate, String ^genre, String ^price, XmlNode ^book, bool validateNode, bool generateSchema)
{

	XmlElement ^bookElement = safe_cast<XmlElement^>(book);

	// Get the attributes of a book.        
	bookElement->SetAttribute("ISBN", ISBN);
	bookElement->SetAttribute("genre", genre);
	bookElement->SetAttribute("publicationdate", publicationDate);

	// Get the values of child elements of a book.
	bookElement["title"]->InnerText = title;
	bookElement["price"]->InnerText = price;

	if (validateNode)
	{
		if (validateXML(generateSchema, bookElement->OwnerDocument))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	return true;
}
//</Snippet7>

#pragma endregion

#pragma region Remove elements
//************************************************************************************
//
//  Summary: Move elements up in the XML.
//  
//
//************************************************************************************
//<Snippet6>
void XMLDOMProcessing::XMLHelperMethods::deleteBook(XmlNode ^book)
{
	XmlNode ^prevNode = book->PreviousSibling;

	book->OwnerDocument->DocumentElement->RemoveChild(book);


	if (prevNode->NodeType == XmlNodeType::Whitespace || prevNode->NodeType == XmlNodeType::SignificantWhitespace)
	{
		prevNode->OwnerDocument->DocumentElement->RemoveChild(prevNode);
	}
}
//</Snippet6>
#pragma endregion

#pragma region Position elements
//<Snippet8>
//************************************************************************************
//
//  Summary: Move elements up in the XML.
//  
//
//************************************************************************************
void XMLDOMProcessing::XMLHelperMethods::MoveElementUp(XmlNode ^book)
{
	XmlNode ^previousNode = book->PreviousSibling;
	while (previousNode != nullptr && (previousNode->NodeType != XmlNodeType::Element))
	{
		previousNode = previousNode->PreviousSibling;
	}
	if (previousNode != nullptr)
	{
		XmlNode ^newLineNode = book->NextSibling;
		book->OwnerDocument->DocumentElement->RemoveChild(book);
		if (newLineNode->NodeType == XmlNodeType::Whitespace || newLineNode->NodeType == XmlNodeType::SignificantWhitespace)
		{
			newLineNode->OwnerDocument->DocumentElement->RemoveChild(newLineNode);
		}
		InsertBookElement(safe_cast<XmlElement^>(book), Constants::positionAbove, previousNode, false, false);
	}
}

//************************************************************************************
//
//  Summary: Move elements down in the XML.
//  
//
//************************************************************************************
void XMLDOMProcessing::XMLHelperMethods::MoveElementDown(XmlNode ^book)
{
	// Walk backwards until we find an element - ignore text nodes
	XmlNode ^NextNode = book->NextSibling;
	while (NextNode != nullptr && (NextNode->NodeType != XmlNodeType::Element))
	{
		NextNode = NextNode->NextSibling;
	}
	if (NextNode != nullptr)
	{
		XmlNode ^newLineNode = book->PreviousSibling;
		book->OwnerDocument->DocumentElement->RemoveChild(book);
		if (newLineNode->NodeType == XmlNodeType::Whitespace || newLineNode->NodeType == XmlNodeType::SignificantWhitespace)
		{
			newLineNode->OwnerDocument->DocumentElement->RemoveChild(newLineNode);
		}

		InsertBookElement(safe_cast<XmlElement^>(book), Constants::positionBelow, NextNode, false, false);
	}

}
//</Snippet8>
#pragma endregion


