#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Drawing::Design;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::ComponentModel::Design::Serialization;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Security::Permissions;

public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      InitializeComponent();
   }

   //<Snippet1>
public:
   void LinkResolveNameEvent( IDesignerSerializationManager^ serializationManager )
   {
      // Registers an event handler for the ResolveName event.
      serializationManager->ResolveName +=
         gcnew ResolveNameEventHandler( this, &Form1::OnResolveName );
   }

private:
   void OnResolveName( Object^ sender, ResolveNameEventArgs^ e )
   {
      // Displays ResolveName event information on the console.
      Console::WriteLine( "Name of the name to resolve: " + e->Name );
      Console::WriteLine( "ToString output of the Object that no name was resolved for: " +
         e->Value );
   }
   //</Snippet1>

   //<Snippet2>
public:
   [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
   void LinkToolboxComponentsCreatedEvent( ToolboxItem^ item )
   {
      item->ComponentsCreated +=
         gcnew ToolboxComponentsCreatedEventHandler( this, &Form1::OnComponentsCreated );
   }

private:
   void OnComponentsCreated( Object^ sender, ToolboxComponentsCreatedEventArgs^ e )
   {
      // Lists created components on the Console.
      for ( int i = 0; i < e->Components->Length; i++ )
      {
         Console::WriteLine( "Component #" + i + ": " +
            e->Components[ i ]->Site->Name );
      }
   }
   //</Snippet2>

   //<Snippet3>
public:
   [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
   void LinkToolboxComponentsCreatingEvent( ToolboxItem^ item )
   {
      item->ComponentsCreating +=
         gcnew ToolboxComponentsCreatingEventHandler( this, &Form1::OnComponentsCreating );
   }

private:
   void OnComponentsCreating( Object^ sender, ToolboxComponentsCreatingEventArgs^ e )
   {
      // Displays ComponentsCreating event information on the Console.
      Console::WriteLine( "Name of the class of the root component of " +
         "the designer host receiving new components: " +
         e->DesignerHost->RootComponentClassName );
   }
   //</Snippet3>

   #pragma region Windows Form Designer generated code
   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->components = gcnew System::ComponentModel::Container;
      this->Size = System::Drawing::Size( 300, 300 );
      this->Text = "Form1";
   }
   #pragma endregion
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
