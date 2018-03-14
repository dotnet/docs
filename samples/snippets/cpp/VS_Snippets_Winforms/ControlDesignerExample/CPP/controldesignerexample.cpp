

#using <System.dll>
#using <System.Design.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

//<Snippet1>
using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Collections;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;
using namespace System::Security::Permissions;

   public ref class TestControlDesigner: public System::Windows::Forms::Design::ControlDesigner
   {
   private:
      bool mouseover;
      Color lineColor;

   public:

      property Color OutlineColor 
      {
         Color get()
         {
            return lineColor;
         }

         void set( Color value )
         {
            lineColor = value;
         }

      }
      TestControlDesigner()
      {
         mouseover = false;
         lineColor = Color::White;
      }

   protected:
      virtual void OnMouseEnter() override
      {
         this->mouseover = true;
         this->Control->Refresh();
      }

      virtual void OnMouseLeave() override
      {
         this->mouseover = false;
         this->Control->Refresh();
      }

      virtual void OnPaintAdornments( System::Windows::Forms::PaintEventArgs^ pe ) override
      {
         if ( this->mouseover )
                  pe->Graphics->DrawRectangle( gcnew Pen( gcnew SolidBrush( this->lineColor ),6 ), 0, 0, this->Control->Size.Width, this->Control->Size.Height );
      }

      //<Snippet2>
   protected:
      [ReflectionPermission(SecurityAction::Demand, Flags=ReflectionPermissionFlag::MemberAccess)]
      virtual void PreFilterProperties( System::Collections::IDictionary^ properties ) override
      {
         properties->Add( "OutlineColor", TypeDescriptor::CreateProperty( TestControlDesigner::typeid, "OutlineColor", System::Drawing::Color::typeid, nullptr ) );
      }
      //</Snippet2>
   };

   [DesignerAttribute(TestControlDesigner::typeid)]
   public ref class TestControl: public System::Windows::Forms::UserControl
   {
   private:
      System::ComponentModel::Container^ components;

   public:
      TestControl()
      {
         components = gcnew System::ComponentModel::Container;
      }

   protected:
      ~TestControl()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }
   };
//</Snippet1>

int main(){}
