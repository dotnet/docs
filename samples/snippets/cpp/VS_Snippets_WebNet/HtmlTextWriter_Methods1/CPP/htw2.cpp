// <snippet1>
// Create a custom HtmlTextWriter class that overrides
// the RenderBeforeContent and RenderAfterContent methods.
#using <System.dll>
#using <System.Web.dll>

using namespace System;
using namespace System::IO;
using namespace System::Web::UI;
using namespace System::Security::Permissions;
using namespace System::Web;

public ref class cstmHtmlTW: public HtmlTextWriter
{
public:
   cstmHtmlTW( TextWriter^ writer )
      : HtmlTextWriter( writer )
   {}

   cstmHtmlTW( TextWriter^ writer, String^ tabString )
      : HtmlTextWriter( writer, tabString )
   {}


protected:

   // <snippet2>
   // Override the RenderBeforeContent method to write
   // a font element that applies red to the text in a Label element.

   virtual String^ RenderBeforeContent() override
   {
      
      // Check to determine whether the element being rendered
      // is a label element. If so, render the opening tag
      // of the font element; otherwise, call the base method.
      if ( TagKey == HtmlTextWriterTag::Label )
      {
         return "<font color=\"red\">";
      }
      else
      {
         return __super::RenderBeforeContent();
      }
   }


   // </snippet2>
   // <snippet3>
   // Override the RenderAfterContent method to render
   // the closing tag of a font element if the
   // rendered tag is a label element.

   virtual String^ RenderAfterContent() override
   {
      
      // Check to determine whether the element being rendered
      // is a label element. If so, render the closing tag
      // of the font element; otherwise, call the base method.
      if ( TagKey == HtmlTextWriterTag::Label )
      {
         return "</font>";
      }
      else
      {
         return __super::RenderAfterContent();
      }
   }

   // </snippet3>
};

// </snippet1>
