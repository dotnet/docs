

// <Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Security::Permissions;

// Provides a form containing a listbox that can display 
// a list of project components.
public ref class DesignerHostListForm: public System::Windows::Forms::Form
{
public:
   System::Windows::Forms::ListBox^ listBox1;

private:
   System::Windows::Forms::Button^ ok_button;

public:
   DesignerHostListForm()
   {
      this->Name = "DesignerHostListForm";
      this->Text = "List of design-time project components";
      this->SuspendLayout();
      this->listBox1 = gcnew System::Windows::Forms::ListBox;
      this->listBox1->Location = System::Drawing::Point( 8, 8 );
      this->listBox1->Name = "listBox1";
      this->listBox1->Size = System::Drawing::Size( 385, 238 );
      this->listBox1->TabIndex = 0;
      this->listBox1->Anchor = static_cast<AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom) | System::Windows::Forms::AnchorStyles::Left) | System::Windows::Forms::AnchorStyles::Right);
      this->ok_button = gcnew System::Windows::Forms::Button;
      this->ok_button->DialogResult = System::Windows::Forms::DialogResult::OK;
      this->ok_button->Location = System::Drawing::Point( 232, 256 );
      this->ok_button->Name = "ok_button";
      this->ok_button->TabIndex = 1;
      this->ok_button->Text = "OK";
      this->ok_button->Anchor = static_cast<AnchorStyles>(System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right);
      this->ClientSize = System::Drawing::Size( 400, 285 );
      array<System::Windows::Forms::Control^>^temp2 = {this->ok_button,this->listBox1};
      this->Controls->AddRange( temp2 );
      this->ResumeLayout( false );
   }

public:
   ~DesignerHostListForm()
   {
   }
};


// You can double-click the component of an IDesignerHostExampleDesigner 
// to show a form containing a listbox that lists the name and type 
// of each component or control in the current design-time project.
public ref class IDesignerHostExampleDesigner: public IDesigner
{
private:
   System::ComponentModel::IComponent^ component;

public:
   IDesignerHostExampleDesigner(){}

   virtual void DoDefaultAction()
   {
      ListComponents();
   }

   virtual void Initialize( System::ComponentModel::IComponent^ component )
   {
      this->component = component;
      MessageBox::Show( "Double-click the IDesignerHostExample component to view a list of project components." );
   }


private:

   // Displays a list of components in the current design 
   // document when the default action of the designer is invoked.
   void ListComponents()
   {
      DesignerHostListForm^ listform = gcnew DesignerHostListForm;

      // Obtain an IDesignerHost service from the design environment.
      IDesignerHost^ host = dynamic_cast<IDesignerHost^>(this->component->Site->GetService( IDesignerHost::typeid ));

      // Get the project components container (control containment depends on Controls collections)
      IContainer^ container = host->Container;

      // Add each component's type name and name to the list box.
      System::Collections::IEnumerator^ myEnum = container->Components->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         IComponent^ component = safe_cast<IComponent^>(myEnum->Current);
         listform->listBox1->Items->Add( String::Concat( component->GetType()->Name, " : ", component->Site->Name ) );
      }

      listform->ShowDialog();
   }

public:

   property System::ComponentModel::IComponent^ Component 
   {
      virtual System::ComponentModel::IComponent^ get()
      {
         return this->component;
      }
   }

   property System::ComponentModel::Design::DesignerVerbCollection^ Verbs 
   {
      [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
      virtual System::ComponentModel::Design::DesignerVerbCollection^ get()
      {
         DesignerVerbCollection^ dvc = gcnew DesignerVerbCollection;
         dvc->Add( gcnew DesignerVerb( "List Components",gcnew EventHandler( this, &IDesignerHostExampleDesigner::ListHandler ) ) );
         return dvc;
      }
   }

private:
   void ListHandler( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      ListComponents();
   }

public:
   ~IDesignerHostExampleDesigner(){}
};


// IDesignerHostExampleComponent is a component associated 
// with the IDesignerHostExampleDesigner that demonstrates 
// acquisition and use of the IDesignerHost service 
// to list project components.

[DesignerAttribute(IDesignerHostExampleDesigner::typeid)]
public ref class IDesignerHostExampleComponent: public System::ComponentModel::Component
{
public:
   IDesignerHostExampleComponent(){}

public:
   ~IDesignerHostExampleComponent(){}
};
// </Snippet1>
