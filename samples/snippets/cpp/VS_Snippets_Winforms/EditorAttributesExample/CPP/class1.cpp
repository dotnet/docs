#using <System.Design.dll>
#using <System.Drawing.dll>
#using <System.Drawing.Design.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Drawing::Design;
using namespace System::Web::UI::Design;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;

namespace EditorAttributeExamples
{
   public ref class Class1: public System::ComponentModel::Component
   {
      // System::ComponentModel::Design::CollectionEditor EditorAttribute example
      //<Snippet1>
   public:
      [EditorAttribute(System::ComponentModel::Design::CollectionEditor::typeid,
         System::Drawing::Design::UITypeEditor::typeid)]
      property ICollection^ testCollection 
      {
         ICollection^ get()
         {
            return Icollection;
         }
         void set( ICollection^ value )
         {
            Icollection = value;
         }
      }
   private:
      ICollection^ Icollection;
      //</Snippet1>

      // System::Drawing::Design::FontEditor EditorAttribute example
      //<Snippet2>
   public:
      [EditorAttribute(System::ComponentModel::Design::CollectionEditor::typeid,
         System::Drawing::Design::UITypeEditor::typeid)]
      property System::Drawing::Font^ testFont 
      {
         System::Drawing::Font^ get()
         {
            return font;
         }
         void set( System::Drawing::Font^ value )
         {
            font = value;
         }
      }
   private:
      Font^ font;
      //</Snippet2>

      // System::Drawing::Design::ImageEditor EditorAttribute example
      //<Snippet3>
   public:
      [EditorAttribute(System::ComponentModel::Design::CollectionEditor::typeid,
         System::Drawing::Design::UITypeEditor::typeid)]
      property Image^ testImage 
      {
         Image^ get()
         {
            return testImg;
         }
         void set( Image^ value )
         {
            testImg = value;
         }
      }
   private:
      Image^ testImg;
      //</Snippet3>

      // System::Windows::Forms::Design::AnchorEditor EditorAttribute example
      //<Snippet4>
   public:
      [EditorAttribute(System::ComponentModel::Design::CollectionEditor::typeid,
         System::Drawing::Design::UITypeEditor::typeid)]
      property System::Windows::Forms::AnchorStyles testAnchor 
      {
         System::Windows::Forms::AnchorStyles get()
         {
            return anchor;
         }
         void set( System::Windows::Forms::AnchorStyles value )
         {
            anchor = value;
         }
      }
   private:
      AnchorStyles anchor;
      //</Snippet4>

      // System::Windows::Forms::Design::FileNameEditor EditorAttribute example
      //<Snippet5>
   public:
      [EditorAttribute(System::ComponentModel::Design::CollectionEditor::typeid,
         System::Drawing::Design::UITypeEditor::typeid)]
      property String^ testFilename 
      {
         String^ get()
         {
            return filename;
         }
         void set( String^ value )
         {
            filename = value;
         }
      }
   private:
      String^ filename;
      //</Snippet5>

   public:
      Class1()
      {
         // Initialize collections for design-mode editor testing.
         array<int>^ temp1 = { 0, 2, 4, 6, 8, 12, 14 };
         Icollection = (ICollection^)(temp1);
         font = gcnew Font( "Arial", 8 );
         testAnchor = AnchorStyles::None;
         filename = String::Empty;
      }
   };
}
