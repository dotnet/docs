#using <System.dll>
#using <System.Drawing.dll>
#using <System.Web.dll>

using namespace System;
using namespace System::IO;
using namespace System::Web::UI;
using namespace System::Web::UI::WebControls;
public ref class FirstControl: public WebControl
{
private:

   // The message property.
   String^ myMessage;

public:
   FirstControl()
   {
      myMessage = "Hello";
   }


   property String^ Message 
   {

      // Accessors for the message property.
      virtual String^ get()
      {
         return myMessage;
      }

      virtual void set( String^ value )
      {
         myMessage = value;
      }

   }

protected:

   // <snippet1>
   // Override a control's Render method to determine what it
   // displays when included in a Web Forms page.
   virtual void Render( HtmlTextWriter^ writer ) override
   {
      
      // <snippet2>
      // Get the value of the current markup writer's
      // Encoding property, convert it to a string, and
      // write it to the markup stream.
      writer->Write( String::Concat( "Encoding : ", writer->Encoding, "<br>" ) );
      
      // </snippet2>
      // <snippet3>
      // Write the opening tag of a Font element.
      writer->WriteBeginTag( "font" );
      
      // Write a Color style attribute to the opening tag
      // of the Font element and set its value to red.
      writer->WriteAttribute( "color", "red" );
      
      // Write the closing character for the opening tag of
      // the Font element.
      writer->Write( '>' );
      
      // Use the InnerWriter property to create a TextWriter
      // object that will write the content found between
      // the opening and closing tags of the Font element.
      // Message is a string property of the control that
      // overrides the Render method.
      TextWriter^ innerTextWriter = writer->InnerWriter;
      innerTextWriter->Write( String::Concat( Message, "<br> The time on the server : ", System::DateTime::Now.ToLongTimeString() ) );
      
      // Write the closing tag of the Font element.
      writer->WriteEndTag( "font" );
   }

   // </snippet3>
};

// </snippet1>
