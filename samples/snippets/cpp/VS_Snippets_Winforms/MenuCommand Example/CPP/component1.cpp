// <snippet10>
#using <system.dll>
#using <system.design.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Security::Permissions;

namespace CppMenuCommand
{
   //<Snippet1>
   public ref class CDesigner: public ComponentDesigner
   {
   public:
    [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
      virtual void Initialize( IComponent^ comp ) override
      {
         ComponentDesigner::Initialize( comp );
         IMenuCommandService^ mcs = static_cast<IMenuCommandService^>(comp->Site->GetService( IMenuCommandService::typeid ));
		 MenuCommand^ mc = gcnew MenuCommand( gcnew EventHandler( this, &CDesigner::OnF1Help ),StandardCommands::F1Help );
         mc->Enabled = true;
         mc->Visible = true;
         mc->Supported = true;
         mcs->AddCommand( mc );
         System::Windows::Forms::MessageBox::Show( "Initialize() has been invoked." );
      }

   private:
      void OnF1Help( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         System::Windows::Forms::MessageBox::Show( "F1Help has been invoked." );
      }
   };
}
//</Snippet1>
// </snippet10>