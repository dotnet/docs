// XMLDOMProcessing.h
#include <string>
#pragma once

namespace XMLDOMProcessing {

	public ref class XMLHelperMethods
	{

	public:

		System::Xml::XmlDocument ^LoadDocument(bool generateXML);
		void SaveXML(System::Xml::XmlDocument ^doc);
		System::Xml::XmlDocument ^LoadDocumentWithSchemaValidation(bool generateXML, bool generateSchema);
		System::Xml::XmlNode ^GetBook(System::String ^uniqueAttribute, System::Xml::XmlDocument ^doc);
		void GetBookInformation(System::String ^%title, System::String ^%ISBN, System::String ^%publicationDate, System::String ^%price, System::String ^%genre, System::Xml::XmlNode ^book);
		System::Xml::XmlNodeList ^ApplyFilters(System::Collections::ArrayList ^conditions, System::Collections::ArrayList ^operatorSymbols, System::Collections::ArrayList ^values, System::Xml::XmlDocument ^doc, System::String ^matchString);
		System::Xml::XmlElement ^AddNewBook(System::String ^genre, System::String ^ISBN, System::String ^misc, System::String ^title, System::String ^price, System::Xml::XmlDocument ^doc);
		bool InsertBookElement(System::Xml::XmlElement ^bookElement, System::String ^position, System::Xml::XmlNode ^selectedBook, bool validateNode, bool generateSchema);
		bool editBook(System::String ^title, System::String ^ISBN, System::String ^publicationDate, System::String ^genre, System::String ^price, System::Xml::XmlNode ^book, bool validateNode, bool generateSchema);
		void deleteBook(System::Xml::XmlNode ^book);
		void MoveElementUp(System::Xml::XmlNode ^book);
		void MoveElementDown(System::Xml::XmlNode ^book);
		void OnValidationEventHandler(System::Object ^sender, System::Xml::Schema::ValidationEventArgs ^e);
		System::String ^ValidationError = "";

	private:

		System::Xml::Schema::XmlSchema ^getSchema(bool generateSchema);
		System::String ^generateXMLString();
		System::String ^generateXMLSchema();
		bool validateXML(bool generateSchema, System::Xml::XmlDocument ^doc);
		bool _IsValid = true;

	};

	public ref class Constants sealed abstract
	{
	public:
		literal System::String ^positionTop = "Top";
		literal System::String ^positionBottom = "Bottom";
		literal System::String ^positionAbove = "Above selected item";
		literal System::String ^positionBelow = "Below selected item";
		literal int lengthOfNamespaceDeclaration = 37;
		literal System::String ^booksFileName = "booksData.xml";
		literal System::String ^Title = "Title";
		literal System::String ^Genre = "Genre";
		literal System::String ^PubDate = "Publish Year";
		literal System::String ^Price = "Price";
		literal System::String ^ISBN = "ISBN";
		literal System::String ^Condition = "Condition";
		literal System::String ^Excludes = "Excludes";
	};
}
