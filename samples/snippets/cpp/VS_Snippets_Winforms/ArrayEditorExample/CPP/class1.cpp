#using <System.dll>
#using <System.Drawing.dll>
#using <System.Design.dll>
#using <System.Drawing.Design.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing::Design;

namespace ArrayEditorExample
{
   public ref class ArrayEditorTestComponent: public Component
   {
      //<Snippet1>
   public:
      property array<Object^>^ componentArray 
      {
         [EditorAttribute(System::ComponentModel::Design::ArrayEditor::typeid,
            System::Drawing::Design::UITypeEditor::typeid)]
         array<Object^>^ get()
         {
            return compArray;
         }
         void set( array<Object^>^ value )
         {
            compArray = value;
         }
      }
   private:
      array<Object^>^compArray;
      //</Snippet1>

   public:
      ArrayEditorTestComponent()
      {
         array<Component^>^ temp0 = {gcnew Component, gcnew Component, this};
         compArray = temp0;
      }
   };
}
