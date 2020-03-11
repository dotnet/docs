// <snippet1>
#using <System.dll>
#using <System.Web.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Web::UI;
using namespace System::Web::UI::WebControls;

// Create a custom markup writer that overrides two versions
// of the RenderBeginTag method and one version of the
// RenderEndTag method.
public ref class HtmlStyledLabelWriter: public HtmlTextWriter
{
private:
   TextWriter^ writer;

public:
   HtmlStyledLabelWriter( TextWriter^ writer )
      : HtmlTextWriter( writer )
   {
      this->writer = writer;
   }

   HtmlStyledLabelWriter( TextWriter^ writer, String^ tabString )
      : HtmlTextWriter( writer, tabString )
   {
      this->writer = writer;
   }

   // <snippet2>
   virtual void RenderBeginTag( HtmlTextWriterTag tagKey ) override
   {
      // <snippet3>
      // <snippet4>
      // If the markup element being rendered is a Label,
      // render the opening tag of a <Font> element before it.
      if ( tagKey == HtmlTextWriterTag::Label )
      {
         
         // Check whether a Color style attribute is
         // included on the Label. If not, use the
         // AddStyleAttribute and GetStyleName methods to add one
         // and set its value to red.
         if (  !IsStyleAttributeDefined( HtmlTextWriterStyle::Color ) )
         {
            AddStyleAttribute( GetStyleName( HtmlTextWriterStyle::Color ), "red" );
         }

         // </snippet4>
         Write( TagLeftChar );
         
         // <snippet5>
         // Use the GetTagName method to associate 
         // the Font element with its HtmlTextWriteTag
         // enumeration value in a Write method call.
         Write( GetTagName( HtmlTextWriterTag::Font ) );
         
         // </snippet5>
         Write( SpaceChar );
         
         // <snippet6>
         // Use the GetAttributeName method to associate 
         // the Size attribute with its HtmlTextWriteAttribute
         // enumeration value in a Write method call.
         Write( GetAttributeName( HtmlTextWriterAttribute::Size ) );
         // </snippet6>
         Write( EqualsChar );
         Write( DoubleQuoteChar );
         Write( "30pt" );
         Write( DoubleQuoteChar );
         Write( TagRightChar );
         // <snippet7>
         // Close the Font element.
         WriteEndTag( GetTagName( HtmlTextWriterTag::Font ) );
         // </snippet7>
      }

      
      // </snippet3>
      // Call the base class's RenderBeginTag method.
      __super::RenderBeginTag( tagKey );
   }


   // </snippet2>
   // <snippet8>
   virtual void RenderBeginTag( String^ tagName ) override
   {
      
      // Call the overloaded RenderBeginTag(HtmlTextWriterTag) method.
      RenderBeginTag( GetTagKey( tagName ) );
   }
   // </snippet8>

   // <snippet9>
   virtual void RenderEndTag() override
   {
      
      // Call the RenderEndTag method of the base class.
      __super::RenderEndTag();
      
      // If the element being rendered is a Label,
      // call the PopEndTag method to write its closing tag.
      if ( TagKey == HtmlTextWriterTag::Label )
      {
         Write( PopEndTag() );
      }
   }
   // </snippet9>
};
// </snippet1>

// <snippet10>
// A custom class that overrides its CreateHtmlTextWriter method.
// This page uses the StyledLabelHtmlWriter class to render its content.
public ref class MyPage: public Page
{
protected:
   virtual HtmlTextWriter^ CreateHtmlTextWriter( TextWriter^ writer ) override
   {
      return gcnew HtmlStyledLabelWriter( writer );
   }
};
// </snippet10>
