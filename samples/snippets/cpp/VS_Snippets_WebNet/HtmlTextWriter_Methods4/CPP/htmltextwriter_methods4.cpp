#using <System.dll>
#using <System.Drawing.dll>
#using <System.Web.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Web::UI;
using namespace System::Web::UI::WebControls;

public ref class htwFour: public HtmlTextWriter
{
public:
   htwFour( TextWriter^ writer )
      : HtmlTextWriter( writer )
   {}

   htwFour( TextWriter^ writer, String^ tabString )
      : HtmlTextWriter( writer, tabString )
   {}

protected:

   // <Snippet1>
   // Override the RenderBeforeTag method to add the
   // opening tag of a Font element before the
   // opening tag of any Label elements rendered by this
   // custom markup writer.
   virtual String^ RenderBeforeTag() override
   {
      // Compare the TagName property value to the
      // String* label to determine whether the element to
      // be rendered is a Label. If it is a Label,
      // the opening tag of the Font element, with a Color
      // style attribute set to red, is added before
      // the Label.
      if ( String::Compare( TagName, "label" ) == 0 )
      {
         return "<font color=\"red\">";
      }
      // If a Label is not being rendered, use
      // the base RenderBeforeTag method.
      else
      {
         return __super::RenderBeforeTag();
      }
   }
   // </snippet1>

   // <Snippet2>
   // Override the RenderAfterTag method to add the
   // closing tag of the Font element after the
   // closing tag of a Label element has been rendered.
   virtual String^ RenderAfterTag() override
   {
      // Compare the TagName property value to the
      // String* label to determine whether the element to
      // be rendered is a Label. If it is a Label,
      // the closing tag of a Font element is rendered
      // after the closing tag of the Label element.
      if ( String::Compare( TagName, "label" ) == 0 )
      {
         return "</font>";
      }
      // If a Label is not being rendered, use
      // the base RenderAfterTag method.
      else
      {
         return __super::RenderAfterTag();
      }
   }
   // </snippet2>
};

public ref class ctlMessage: public WebControl
{
private:

   // The message property.
   String^ myMessage;

public:
   ctlMessage()
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
   virtual void Render( HtmlTextWriter^ writer ) override
   {
      // Write the contents of the control.
      writer->RenderBeginTag( HtmlTextWriterTag::Label );
      writer->Write( Message );
      writer->RenderEndTag();
      writer->Write( "<br> The time on the server: {0}", System::DateTime::Now.ToLongTimeString() );
   }
};

public ref class MyPage: public Page
{
protected:
   virtual HtmlTextWriter^ CreateHtmlTextWriter( TextWriter^ writer ) override
   {
      return gcnew htwFour( writer );
   }
};
