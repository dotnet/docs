//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Drawing::Design;
using namespace System::Windows::Forms;
using namespace System::Security::Permissions;

namespace TextDataTextBoxComponent
{
   // Custom toolbox item creates a TextBox and sets its Text property
   // to the constructor-specified text.
   [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
   public ref class TextToolboxItem: public ToolboxItem
   {
   private:
      String^ text;
      delegate void SetTextMethodHandler( Control^ c, String^ text );

   public:
      TextToolboxItem( String^ text )
         : ToolboxItem()
      {
         this->text = text;
      }

   protected:

      // ToolboxItem::CreateComponentsCore  to create the TextBox
      // and link a method to set its Text property.

      virtual array<IComponent^>^ CreateComponentsCore( IDesignerHost^ host ) override
      {
         TextBox^ textbox = dynamic_cast<TextBox^>(host->CreateComponent( TextBox::typeid ));
         
         // Because the designer resets the text of the textbox, use
         // a SetTextMethodHandler to set the text to the value of
         // the text data.
         Control^ c = dynamic_cast<Control^>(host->RootComponent);
         array<Object^>^temp0 = {textbox,text};
         c->BeginInvoke( gcnew SetTextMethodHandler( this, &TextToolboxItem::OnSetText ), temp0 );
         array<IComponent^>^temp1 = {textbox};
         return temp1;
      }

   private:

      // Method to set the text property of a TextBox after it is initialized.
      void OnSetText( Control^ c, String^ text )
      {
         c->Text = text;
      }

   };


   // Component that adds a "Text" data format ToolboxItemCreatorCallback 
    // to the Toolbox. This component uses a custom ToolboxItem that 
    // creates a TextBox containing the text data.
   public ref class TextDataTextBoxComponent: public Component
   {
   private:
      bool creatorAdded;
      IToolboxService^ ts;

   public:
      TextDataTextBoxComponent()
      {
         creatorAdded = false;
      }


      property System::ComponentModel::ISite^ Site 
      {
         // ISite to register TextBox creator
         virtual System::ComponentModel::ISite^ get() override
         {
            return __super::Site;
         }

         virtual void set( System::ComponentModel::ISite^ value ) override
         {
            if ( value != nullptr )
            {
               __super::Site = value;
               if (  !creatorAdded )
                              AddTextTextBoxCreator();
            }
            else
            {
               if ( creatorAdded )
                              RemoveTextTextBoxCreator();
               __super::Site = value;
            }
         }
      }

   private:

      // Adds a "Text" data format creator to the toolbox that creates
      // a textbox from a text fragment pasted to the toolbox.
      void AddTextTextBoxCreator()
      {
         ts = dynamic_cast<IToolboxService^>(GetService( IToolboxService::typeid ));
         if ( ts != nullptr )
         {
            ToolboxItemCreatorCallback^ textCreator = 
				gcnew ToolboxItemCreatorCallback( 
				this, 
				&TextDataTextBoxComponent::CreateTextBoxForText );
            try
            {
               ts->AddCreator( 
				   textCreator, 
				   "Text", 
				   dynamic_cast<IDesignerHost^>(GetService( IDesignerHost::typeid )) );
               creatorAdded = true;
            }
            catch ( Exception^ ex ) 
            {
               MessageBox::Show( ex->ToString(), "Exception Information" );
            }
         }
      }


      // Removes any "Text" data format creator from the toolbox.
      void RemoveTextTextBoxCreator()
      {
         if ( ts != nullptr )
         {
            ts->RemoveCreator( 
				"Text", 
				dynamic_cast<IDesignerHost^>(GetService( IDesignerHost::typeid )) );
            creatorAdded = false;
         }
      }


      // ToolboxItemCreatorCallback delegate format method to create
      // the toolbox item.
      ToolboxItem^ CreateTextBoxForText( Object^ serializedObject, String^ format )
      {
		IDataObject^ o = gcnew DataObject(dynamic_cast<IDataObject^>(serializedObject));

		if( o->GetDataPresent("System::String", true) )
		{
			String^ toolboxText = dynamic_cast<String^>(o->GetData( "System::String", true ));
		   return( gcnew TextToolboxItem( toolboxText ));
		}

		return nullptr;
	  }

   public:
      ~TextDataTextBoxComponent()
      {
         if ( creatorAdded )
                  RemoveTextTextBoxCreator();
      }
   };
}
//</Snippet1>
