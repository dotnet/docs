#using <System.dll>
#using <System.Drawing.dll>
#using <System.Web.dll>
#using <System.Design.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Web::UI;
using namespace System::Web::UI::Design;
using namespace System::Web::UI::WebControls;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing::Design;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;
using namespace System::Security::Permissions;

//<Snippet2>
// Example designer provides a designer verb menu command to launch the
// BuildUrl method of the UrlBuilder.
public ref class UrlBuilderDesigner: public UserControlDesigner
{
public:
   UrlBuilderDesigner(){}


   property DesignerVerbCollection^ Verbs 
   {

      // Provides a designer verb menu command for invoking the BuildUrl
      // method of the UrlBuilder.
      [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
      virtual DesignerVerbCollection^ get() override
      {
         DesignerVerbCollection^ dvc = gcnew DesignerVerbCollection;
         dvc->Add( gcnew DesignerVerb( "Launch URL Builder UI",gcnew EventHandler( this, &UrlBuilderDesigner::launchUrlBuilder ) ) );
         return dvc;
      }

   }

private:

   // This method handles the "Launch Url Builder UI" menu command.
   // Invokes the BuildUrl method of the System::Web::UI::Design.UrlBuilder.
   void launchUrlBuilder( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      //<Snippet1>
      // Create a parent control.
      System::Windows::Forms::Control^ c = gcnew System::Windows::Forms::Control;
      c->CreateControl();
      
      // Launch the Url Builder using the specified control
      // parent, initial URL, empty relative base URL path,
      // window caption, filter String* and URLBuilderOptions value.
      UrlBuilder::BuildUrl( this->Component, c, "http://www.example.com", "Select a URL", "", UrlBuilderOptions::None );
      
      //</Snippet1>
   }

};


// Example Web control displays the value of its text property.
// This control is associated with the UrlBuilderDesigner.

[DesignerAttribute(UrlBuilderDesigner::typeid,IDesigner::typeid)]
public ref class UrlBuilderControl: public WebControl
{
private:
   String^ text;

public:

   property String^ Text 
   {

      [Bindable(true),
      Category("Appearance"),
      DefaultValue("")]
      String^ get()
      {
         return text;
      }

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

//</Snippet2>
