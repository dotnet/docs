//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
public ref class Sample
{
public:
   void Run( String^ args )
   {
      // Create and load the XML document.
      Console::WriteLine( "Loading file {0} ...", args );
      XmlDocument^ doc = gcnew XmlDocument;
      doc->Load( args );
      
      //Create the event handlers.
      doc->NodeChanged += gcnew XmlNodeChangedEventHandler( this, &Sample::MyNodeChangedEvent );
      doc->NodeInserted += gcnew XmlNodeChangedEventHandler( this, &Sample::MyNodeInsertedEvent );
      
      // Change the book price.
      doc->DocumentElement->LastChild->InnerText = "5.95";
      
      // Add a new element.
      XmlElement^ newElem = doc->CreateElement( "style" );
      newElem->InnerText = "hardcover";
      doc->DocumentElement->AppendChild( newElem );
      Console::WriteLine( "\r\nDisplay the modified XML..." );
      Console::WriteLine( doc->OuterXml );
   }

   // Handle the NodeChanged event.
private:
   void MyNodeChangedEvent( Object^ /*src*/, XmlNodeChangedEventArgs^ args )
   {
      Console::Write( "Node Changed Event: <{0}> changed", args->Node->Name );
      if ( args->Node->Value != nullptr )
      {
         Console::WriteLine( " with value  {0}", args->Node->Value );
      }
      else
            Console::WriteLine( "" );
   }

   // Handle the NodeInserted event.
   void MyNodeInsertedEvent( Object^ /*src*/, XmlNodeChangedEventArgs^ args )
   {
      Console::Write( "Node Inserted Event: <{0}> inserted", args->Node->Name );
      if ( args->Node->Value != nullptr )
      {
         Console::WriteLine( " with value {0}", args->Node->Value );
      }
      else
            Console::WriteLine( "" );
   }
};
// End class 

int main()
{
   Sample^ mySample = gcnew Sample;
   mySample->Run( "book.xml" );
}
//</snippet1>
