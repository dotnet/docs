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