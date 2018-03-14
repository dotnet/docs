

//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Design.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::IO;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;

public ref class HelpDesigner: public System::Windows::Forms::Design::ControlDesigner
{
public:
   HelpDesigner(){}

   property System::ComponentModel::Design::DesignerVerbCollection^ Verbs 
   {
      virtual System::ComponentModel::Design::DesignerVerbCollection^ get() override
      {
         array<DesignerVerb^>^temp0 = {gcnew DesignerVerb( "Add IHelpService Help Keyword",gcnew EventHandler( this, &HelpDesigner::addKeyword ) ),gcnew DesignerVerb( "Remove IHelpService Help Keyword",gcnew EventHandler( this, &HelpDesigner::removeKeyword ) )};
         return gcnew DesignerVerbCollection( temp0 );
      }
   }

private:
   void addKeyword( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      IHelpService^ hs = dynamic_cast<IHelpService^>(this->Control->Site->GetService( IHelpService::typeid ));
      hs->AddContextAttribute( "keyword", "IHelpService", HelpKeywordType::F1Keyword );
   }

   void removeKeyword( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      IHelpService^ hs = dynamic_cast<IHelpService^>(this->Control->Site->GetService( IHelpService::typeid ));
      hs->RemoveContextAttribute( "keyword", "IHelpService" );
   }
};


[Designer(HelpDesigner::typeid)]
public ref class HelpTestControl: public System::Windows::Forms::UserControl
{
public:
   HelpTestControl()
   {
      this->Size = System::Drawing::Size( 320, 100 );
      this->BackColor = Color::White;
   }

protected:
   virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
   {
      Brush^ brush = gcnew SolidBrush( Color::Blue );
      e->Graphics->DrawString( "IHelpService Example Designer Control", gcnew System::Drawing::Font( FontFamily::GenericMonospace,10 ), brush, 5, 5 );
      e->Graphics->DrawString( "Right-click this component for", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), brush, 5, 25 );
      e->Graphics->DrawString( "add/remove Help context keyword commands.", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), brush, 5, 35 );
      e->Graphics->DrawString( "Press F1 while this component is", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), brush, 5, 55 );
      e->Graphics->DrawString( "selected to raise Help topics for", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), brush, 5, 65 );
      e->Graphics->DrawString( "the current keyword or keywords", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), brush, 5, 75 );
   }
};
//</Snippet1>
