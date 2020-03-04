#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Security::Permissions;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
public:
   [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
   Form1()
   {
      // The initial constructor code goes here.

      PropertyGrid^ propertyGrid1 = gcnew PropertyGrid;
      propertyGrid1->CommandsVisibleIfAvailable = true;
      propertyGrid1->Location = Point( 10, 20 );
      propertyGrid1->Size = System::Drawing::Size( 400, 300 );
      propertyGrid1->TabIndex = 1;
      propertyGrid1->Text = "Property Grid";

      this->Controls->Add( propertyGrid1 );

      propertyGrid1->SelectedObject = textBox1;
   }
   // </Snippet1>
};
