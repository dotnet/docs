#using <System.Web.dll>

using namespace System;
using namespace System::IO;
using namespace System::Web;
using namespace System::Web::UI;

// Create a custom HtmlTextWriter class.
public ref class HTW1: public HtmlTextWriter
{
public:
   HTW1( TextWriter^ writer )
      : HtmlTextWriter( writer )
   {}

   HTW1( TextWriter^ writer, String^ tabString )
      : HtmlTextWriter( writer, tabString )
   {}

   // <snippet1>
   // Override the RenderBeginTag method to check whether
   // the tagKey parameter is set to a <label> element
   // or a <font> element.   
   virtual void RenderBeginTag( HtmlTextWriterTag tagKey ) override
   {
      // <snippet2>
      // If the tagKey parameter is set to a <label> element
      // but a color attribute is not defined on the element,
      // the AddStyleAttribute method adds a color attribute
      // and sets it to red.
      if ( tagKey == HtmlTextWriterTag::Label )
      {
         if (  !IsStyleAttributeDefined( HtmlTextWriterStyle::Color ) )
         {
            AddStyleAttribute( GetStyleKey( "color" ), "red" );
         }
      }
      // </snippet2>

      // <snippet3>
      // If the tagKey parameter is set to a <font> element
      // but a size attribute is not defined on the element,
      // the AddStyleAttribute method adds a size attribute
      // and sets it to 30 point.
      if ( tagKey == HtmlTextWriterTag::Font )
      {
         if (  !IsAttributeDefined( HtmlTextWriterAttribute::Size ) )
         {
            AddAttribute( GetAttributeKey( "size" ), "30pt" );
         }
      }
      // </snippet3>

      // Call the base class's RenderBeginTag method
      // to ensure that calling this custom markup writer
      // includes functionality for all other elements.
      __super::RenderBeginTag( tagKey );
   }
   // </snippet1>

protected:
   // <snippet4>
   // Override the FilterAttributes method to check whether 
   // <label> and <anchor> elements contain specific attributes. 
   virtual void FilterAttributes() override
   {
      // <snippet5>
      // If the <label> element is rendered and a style
      // attribute is not defined, add a style attribute 
      // and set its value to blue.
      if ( TagKey == HtmlTextWriterTag::Label )
      {
         if (  !IsAttributeDefined( HtmlTextWriterAttribute::Style ) )
         {
            AddAttribute( "style", EncodeAttributeValue( "color:blue", true ) );
            Write( NewLine );
            Indent = 3;
            OutputTabs();
         }
      }
      // </snippet5>

      // <snippet6>
      // If an <anchor> element is rendered and an href
      // attribute has not been defined, call the AddAttribute
      // method to add an href attribute
      // and set it to http://www.cohowinery.com.
      // Use the EncodeUrl method to convert any spaces to %20.
      if ( TagKey == HtmlTextWriterTag::A )
      {
         if (  !IsAttributeDefined( HtmlTextWriterAttribute::Href ) )
         {
            AddAttribute( "href", EncodeUrl( "http://www.cohowinery.com" ) );
         }
      }
      // </snippet6>

      // Call the FilterAttributes method of the base class.
      __super::FilterAttributes();
   }
   // </snippet4>

   // <snippet7>
   // Override the OutputTabs method to set the tab to
   // the number of spaces defined by the Indent variable.
   virtual void OutputTabs() override
   {
      
      // Output the DefaultTabString for the number
      // of times specified in the Indent property.
      for ( int i = 0; i < Indent; i++ )
         Write( DefaultTabString );
      __super::OutputTabs();
   }
   // </snippet7>
};
