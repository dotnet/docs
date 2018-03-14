/* 
* The following example demonstrates the 'AddStyleAttribute(string, string)' method 
* of 'HtmlTextWriter' class.
* 
* In this program a custom web control called 'FirstControl' is shown. It has 
* one property called the 'Message'. The 'Render' method has been overriden to
* write the html contents with reference to this control. This contents are 
* written to the final .aspx page in which this control is inserted. The 'Render'
* method displays the contents of the 'Message' property followed by the current
* time on the server were the corresponding .aspx page resides. 
* 
* Note : Follow the instructions in HtmlTextWriterReadme.txt for details on installing
*        a site that uses custom controls.  
*/

#using <System.Web.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::UI;
using namespace System::Web::UI::WebControls;

namespace CustomControls
{
   public ref class FirstControl: public WebControl
   {
      // The message property.
   private:
      String^ message;

   // Accessors for the message property.
   public:
      property String^ Message 
      {
         virtual String^ get()
         {
            return message;
         }
         virtual void set( String^ value )
         {
            message = value;
         }
      }

   protected:
      virtual void Render( HtmlTextWriter^ writer ) override
      {
         // <Snippet1>
         // Add style attribute for 'p'(paragraph) element.
         writer->AddStyleAttribute( "font-size", "12pt" );
         writer->AddStyleAttribute( "color", "fuchsia" );
         // Output the 'p' (paragraph) element with the style attributes.
         writer->RenderBeginTag( "p" );
         // Output the 'Message' property contents and the time on the server.
         writer->Write( String::Concat( Message, "<br>",
            "The time on the server: ",
            System::DateTime::Now.ToLongTimeString() ) );
         
         // Close the element.
         writer->RenderEndTag();
         // </Snippet1>
      }
   };
}
