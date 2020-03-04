#using <System.Web.dll>
#using <System.dll>
#using <System.Design.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Web::UI;
using namespace System::Web::UI::Design;
using namespace System::Web::UI::WebControls;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing::Design;
using namespace System::Windows::Forms;

[DefaultProperty("Text"),
ToolboxData("< {0}:WebCustomControl1 runat=server></ {0}:WebCustomControl1>")]
public ref class WebCustomControl1: public WebControl
{
private:
   String^ text;

   //<Snippet1>
public:
   property String^ URL 
   {

	   [EditorAttribute(UrlEditor::typeid,UITypeEditor::typeid)]
      String^ get()
      {
         return http_url;
      }

      [EditorAttribute(UrlEditor::typeid,UITypeEditor::typeid)]
      void set( String^ value )
      {
         http_url = value;
      }
   }

private:
   String^ http_url;
   //</Snippet1>

   //<Snippet2>
private:
   property String^ XmlFile 
   {
      [EditorAttribute(XmlFileEditor::typeid,UITypeEditor::typeid)]
      String^ get()
      {
         return xml_;
      }

      [EditorAttribute(XmlFileEditor::typeid,UITypeEditor::typeid)]
      void set( String^ value )
      {
         xml_ = value;
      }
   }
   String^ xml_;
   //</Snippet2>

   //<Snippet3>
public:
   property String^ XmlFileURL 
   {
      [EditorAttribute(XmlUrlEditor::typeid,UITypeEditor::typeid)]
      String^ get()
      {
         return xmlURL;
      }


      [EditorAttribute(XmlUrlEditor::typeid,UITypeEditor::typeid)]
      void set( String^ value )
      {
         xmlURL = value;
      }

   }

private:
   String^ xmlURL;
   //</Snippet3>

   //<Snippet4>
public:
   property String^ XslFileURL 
   {
      [EditorAttribute(XslUrlEditor::typeid,UITypeEditor::typeid)]
      String^ get()
      {
         return xslURL;
      }

      [EditorAttribute(XslUrlEditor::typeid,UITypeEditor::typeid)]
      void set( String^ value )
      {
         xslURL = value;
      }
   }

private:
   String^ xslURL;
   //</Snippet4>

   //<Snippet5>
public:
   property String^ imageURL 
   {
      [EditorAttribute(ImageUrlEditor::typeid,UITypeEditor::typeid)]
      String^ get()
      {
         return imgURL;
      }


      [EditorAttribute(ImageUrlEditor::typeid,UITypeEditor::typeid)]
      void set( String^ value )
      {
         imgURL = value;
      }

   }

private:
   String^ imgURL;
   //</Snippet5>

   //<Snippet6>
public:
   property DataBindingCollection^ TestDataBindings 
   {
      [EditorAttribute(DataBindingCollectionEditor::typeid,
      UITypeEditor::typeid)]
      DataBindingCollection^ get()
      {
         return testBindings;
      }

      [EditorAttribute(DataBindingCollectionEditor::typeid,
      UITypeEditor::typeid)]
      void set( DataBindingCollection^ value )
      {
         testBindings = value;
      }
   }

private:
   DataBindingCollection^ testBindings;
   //</Snippet6>

public:
   property String^ Text 
   {
      [Bindable(true),Category("Appearance"),DefaultValue("")]
      String^ get()
      {
         return text;
      }

      [Bindable(true),Category("Appearance"),DefaultValue("")]
      void set( String^ value )
      {
         text = value;
      }
   }

protected:
   virtual void Render( HtmlTextWriter^ output ) override
   {
      output->Write( Text );
   }
};
