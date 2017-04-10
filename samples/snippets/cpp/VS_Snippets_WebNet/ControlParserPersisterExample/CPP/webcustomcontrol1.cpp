//<Snippet1>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Web.dll>
#using <System.Design.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Drawing::Design;
using namespace System::IO;
using namespace System::Web::UI;
using namespace System::Web::UI::Design;
using namespace System::Web::UI::WebControls;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;

// Provides a form with a multiline text box display.
private ref class StringDisplayForm: public Form
{
public:
   StringDisplayForm( String^ displayText )
   {
      this->Size = System::Drawing::Size( 400, 400 );
      this->Text = "Control Persistence String";
      this->SuspendLayout();
      System::Windows::Forms::TextBox^ tbox = gcnew System::Windows::Forms::TextBox;
      tbox->Multiline = true;
      tbox->Size = System::Drawing::Size( this->Width - 40, this->Height - 90 );
      tbox->Text = displayText;
      this->Controls->Add( tbox );
      System::Windows::Forms::Button^ okButton = gcnew System::Windows::Forms::Button;
      okButton->Text = "OK";
      okButton->Size = System::Drawing::Size( 80, 24 );
      okButton->Location = Point(this->Width - 100,this->Height - 60);
      okButton->Anchor = AnchorStyles(AnchorStyles::Bottom | AnchorStyles::Right);
      okButton->DialogResult = ::DialogResult::OK;
      this->Controls->Add( okButton );
      this->ResumeLayout();
   }

};

// Provides a form with a list for selection.
private ref class ControlSelectionForm: public Form
{
private:
   array<System::Web::UI::Control^>^controlArray;

public:
   System::Windows::Forms::ListBox^ controlList;
   ControlSelectionForm( array<System::Web::UI::Control^>^controlArray )
   {
      this->controlArray = controlArray;
      this->Size = System::Drawing::Size( 400, 500 );
      this->Text = "Control Persister Selection Form";
      this->SuspendLayout();
      System::Windows::Forms::Label ^ label1 = gcnew System::Windows::Forms::Label;
      label1->Text = "Select the control to persist:";
      label1->Size = System::Drawing::Size( 240, 20 );
      label1->Location = Point(10,10);
      this->Controls->Add( label1 );
      controlList = gcnew System::Windows::Forms::ListBox;
      controlList->Size = System::Drawing::Size( 370, 400 );
      controlList->Location = Point(10,30);
      controlList->Anchor = AnchorStyles(AnchorStyles::Left | AnchorStyles::Top | AnchorStyles::Bottom | AnchorStyles::Right);
      this->Controls->Add( controlList );
      System::Windows::Forms::Button^ okButton = gcnew System::Windows::Forms::Button;
      okButton->Text = "OK";
      okButton->Size = System::Drawing::Size( 80, 24 );
      okButton->Location = Point(this->Width - 100,this->Height - 60);
      okButton->Anchor = AnchorStyles(AnchorStyles::Bottom | AnchorStyles::Right);
      okButton->DialogResult = ::DialogResult::OK;
      this->Controls->Add( okButton );
      System::Windows::Forms::Button^ cancelButton = gcnew System::Windows::Forms::Button;
      cancelButton->Text = "Cancel";
      cancelButton->Size = System::Drawing::Size( 80, 24 );
      cancelButton->Location = Point(this->Width - 200,this->Height - 60);
      cancelButton->Anchor = AnchorStyles(AnchorStyles::Bottom | AnchorStyles::Right);
      cancelButton->DialogResult = ::DialogResult::Cancel;
      this->Controls->Add( cancelButton );
      for ( int i = 0; i < controlArray->Length; i++ )
         controlList->Items->Add( controlArray[ i ]->UniqueID );
      this->ResumeLayout();
   }
};

// Provides a form with a multiline text box for input.
private ref class StringInputForm: public Form
{
public:
   System::Windows::Forms::TextBox^ tbox;
   StringInputForm()
   {
      this->Size = System::Drawing::Size( 400, 400 );
      this->Text = "Input Control Persistence String";
      this->SuspendLayout();
      tbox = gcnew System::Windows::Forms::TextBox;
      tbox->Multiline = true;
      tbox->Size = System::Drawing::Size( this->Width - 40, this->Height - 90 );
      tbox->Text = "";
      this->Controls->Add( tbox );
      System::Windows::Forms::Button^ okButton = gcnew System::Windows::Forms::Button;
      okButton->Text = "OK";
      okButton->Size = System::Drawing::Size( 80, 24 );
      okButton->Location = Point(this->Width - 100,this->Height - 60);
      okButton->Anchor = AnchorStyles(AnchorStyles::Bottom | AnchorStyles::Right);
      okButton->DialogResult = ::DialogResult::OK;
      this->Controls->Add( okButton );
      System::Windows::Forms::Button^ cancelButton = gcnew System::Windows::Forms::Button;
      cancelButton->Text = "Cancel";
      cancelButton->Size = System::Drawing::Size( 80, 24 );
      cancelButton->Location = Point(this->Width - 200,this->Height - 60);
      cancelButton->Anchor = AnchorStyles(AnchorStyles::Bottom | AnchorStyles::Right);
      cancelButton->DialogResult = ::DialogResult::Cancel;
      this->Controls->Add( cancelButton );
      this->ResumeLayout();
   }
};


// Web control designer provides an interface
// to use the ControlPersister and ControlParser.
public ref class ControlParserPersisterDesigner: public System::Web::UI::Design::ControlDesigner
{
public:
   ControlParserPersisterDesigner()
      : ControlDesigner()
   {}

   property System::ComponentModel::Design::DesignerVerbCollection^ Verbs 
   {
      // Provides designer verb menu commands to
      // persist a control and to load a persisted control.
      [System::Security::Permissions::PermissionSetAttribute(System::Security::Permissions::SecurityAction::Demand, Name="FullTrust")]
      virtual System::ComponentModel::Design::DesignerVerbCollection^ get() override
      {
         DesignerVerbCollection^ dvc = gcnew DesignerVerbCollection;
         dvc->Add( gcnew DesignerVerb( "Load Persisted Control...",gcnew EventHandler( this, &ControlParserPersisterDesigner::loadPersistedControl ) ) );
         dvc->Add( gcnew DesignerVerb( "Parse and Save Control...",gcnew EventHandler( this, &ControlParserPersisterDesigner::saveControl ) ) );
         return dvc;
      }

   }

private:

   // Displays a textbox form to receive an HTML
   // String* that represents a control, and creates
   // a toolbox item for the control, if not already
   // present in the selected toolbox category.
   void loadPersistedControl( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Display a StringInputForm to obtain a persisted control String*.
      StringInputForm^ inputForm = gcnew StringInputForm;
      if ( inputForm->ShowDialog() != DialogResult::OK )
            return;

      if ( inputForm->tbox->Text->Length < 2 )
            return;

      // Obtain an IDesignerHost* for the design-mode document.
	  IDesignerHost^ host = dynamic_cast<IDesignerHost^>(this->Component->Site->GetService( IDesignerHost::typeid ));
      
      //<Snippet2>
      // Create a Web control from the persisted control String*.
      System::Web::UI::Control^ ctrl = ControlParser::ParseControl( host, inputForm->tbox->Text->Trim() );
      //</Snippet2>

      // Create a Web control toolbox item for the type of the control
      WebControlToolboxItem^ item = gcnew WebControlToolboxItem( ctrl->GetType() );
      
      // Add the Web control toolbox item to the toolbox
      IToolboxService^ toolService = dynamic_cast<IToolboxService^>(this->Component->Site->GetService( IToolboxService::typeid ));
      if ( toolService != nullptr )
            toolService->AddToolboxItem( item );
      else
            throw gcnew Exception( "IToolboxService* was not found." );
   }

   // Displays a list of controls in the project, if any,
   // and displays the HTML representing the persisted, selected control.
   void saveControl( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Get the collection of components in the current
      // design mode document.
      ComponentCollection^ documentComponents = this->Component->Site->Container->Components;

      // Filter the components to those that derive from the
      // System::Web::UI::Control class.
      // Create an IComponent* array of the maximum possible length needed.
      array<IComponent^>^filterArray = gcnew array<IComponent^>(documentComponents->Count);

      // Count the total qualifying components.
      int total = 0;
      for ( int i = 0; i < documentComponents->Count; i++ )
      {
         // If the component derives from System::Web::UI::Control,
         // copy a reference to the control to the filterArray
         // array and increment the control count.
         if ( System::Web::UI::Control::typeid->IsAssignableFrom( documentComponents[i]->GetType() ) )
         {
            if ( (dynamic_cast<System::Web::UI::Control^>(documentComponents[i]))->UniqueID != nullptr )
            {
               filterArray[total] = documentComponents[i];
               total++;
            }
         }

      }
      if ( total == 0 )
            throw gcnew Exception( "Document contains no System::Web::UI::Control components." );

      // Move the components that derive from System::Web::UI::Control to a
      // new array of the correct size.
      array<System::Web::UI::Control^>^controlArray = gcnew array<System::Web::UI::Control^>(total);
      for ( int i = 0; i < total; i++ )
         controlArray[i] = dynamic_cast<System::Web::UI::Control^>(filterArray[i]);

      // Create a ControlSelectionForm to provide a persistence
      // configuration interface.
      ControlSelectionForm^ selectionForm = gcnew ControlSelectionForm( controlArray );

      // Display the form.
      if ( selectionForm->ShowDialog() != DialogResult::OK )
            return;

      // Validate the selection.
      if ( selectionForm->controlList->SelectedIndex == -1 )
            throw gcnew Exception( "You must select a control to persist." );

      //<Snippet3>
      // Parse the selected control.
      String^ persistedData = ControlPersister::PersistControl( controlArray[ selectionForm->controlList->SelectedIndex ] );
      //</Snippet3>

      // Display the control persistence String* in a text box.
      StringDisplayForm^ displayForm = gcnew StringDisplayForm( persistedData );
      displayForm->ShowDialog();
   }
};

// Simple text display control hosts the ControlParserPersisterDesigner.

[DesignerAttribute(ControlParserPersisterDesigner::typeid,IDesigner::typeid)]
public ref class ControlParserPersisterDesignerControl: public WebControl
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
   ControlParserPersisterDesignerControl()
      : WebControl()
   {
      text = "Right-click here to access control persistence methods in design mode";
   }

protected:
   virtual void Render( HtmlTextWriter^ output ) override
   {
      output->Write( Text );
   }
};
//</Snippet1>
