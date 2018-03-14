//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Design.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::ComponentModel::Design::Serialization;
using namespace System::Drawing;
using namespace System::Reflection;
using namespace System::Timers;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;

// Designer for a Button control which cycles the background color.
public ref class ColorCycleButtonDesigner: public System::Windows::Forms::Design::ControlDesigner
{
private:
   System::Windows::Forms::Timer^ timer1;
   Color initial_bcolor;
   Color initial_fcolor;
   int r;
   int g;
   int b;
   bool ru;
   bool gu;
   bool bu;
   bool continue_;

public:
   ColorCycleButtonDesigner()
   {
      timer1 = gcnew System::Windows::Forms::Timer;
      timer1->Interval = 50;
      timer1->Tick += gcnew EventHandler( this, &ColorCycleButtonDesigner::Elapsed );
      ru = true;
      gu = false;
      bu = true;
      continue_ = false;
      timer1->Start();
   }

private:
   void Elapsed( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      this->Control->BackColor = Color::FromArgb( r % 255, g % 255, b % 255 );
      this->Control->Refresh();
      
      // Updates color.
      if ( ru )
            r += 10;
      else
      if ( r > 10 )
            r -= 10;

      if ( gu )
            g += 10;
      else
      if ( g > 10 )
            g -= 10;

      if ( bu )
            b += 10;
      else
      if ( b > 10 )
            b -= 10;
      
      // Randomly switches direction of color component values.
      Random^ rand = gcnew Random;
      for ( int i = 0; i < 4; i++ )
         switch ( rand->Next( 0, 2 ) )
         {
            case 0:
               if ( ru )
                              ru = false;
               else
                              ru = true;

               break;

            case 1:
               if ( gu )
                              gu = false;
               else
                              gu = true;

               break;

            case 2:
               if ( bu )
                              bu = false;
               else
                              bu = true;

               break;
         }
      this->Control->ForeColor = Color::FromArgb( (this->Control->BackColor.R + 128) % 255, (this->Control->BackColor.G + 128) % 255, (this->Control->BackColor.B + 128) % 255 );
   }

protected:
   virtual void OnMouseEnter() override
   {
      if (  !timer1->Enabled )
      {
         initial_bcolor = this->Control->BackColor;
         initial_fcolor = this->Control->ForeColor;
         r = initial_bcolor.R;
         g = initial_bcolor.G;
         b = initial_bcolor.B;
         timer1->Start();
      }
   }

   virtual void OnMouseLeave() override
   {
      if (  !continue_ )
      {
         continue_ = true;
         timer1->Stop();
      }
      else
            continue_ = false;

      this->Control->BackColor = initial_bcolor;
      this->Control->ForeColor = initial_fcolor;
   }

public:
   ~ColorCycleButtonDesigner()
   {
      timer1->Stop();
      this->Control->BackColor = initial_bcolor;
      this->Control->ForeColor = initial_fcolor;
   }
};

// Provides a TypeDescriptorFilterService to add the
// ColorCycleButtonDesigner using a DesignerAttribute.
public ref class ButtonDesignerFilterService: public System::ComponentModel::Design::ITypeDescriptorFilterService
{
public:
   ITypeDescriptorFilterService^ oldService;
   ButtonDesignerFilterService(){}

   ButtonDesignerFilterService( ITypeDescriptorFilterService^ oldService_ )
   {
      // Stores any previous ITypeDescriptorFilterService to implement service chaining.
      this->oldService = oldService_;
   }

   virtual bool FilterAttributes( System::ComponentModel::IComponent^ component, System::Collections::IDictionary^ attributes )
   {
      if ( oldService != nullptr )
            oldService->FilterAttributes( component, attributes );

      // Creates a designer attribute to compare its TypeID with the TypeID of existing attributes of the component.
      DesignerAttribute^ da = gcnew DesignerAttribute( ColorCycleButtonDesigner::typeid );
      // Adds the designer attribute if the attribute collection does not contain a DesignerAttribute of the same TypeID.
      if ( dynamic_cast<System::Windows::Forms::Button^>(component) && attributes->Contains( da->TypeId ) )
            attributes[ da->TypeId ] = da;

      return true;
   }

   virtual bool FilterEvents( System::ComponentModel::IComponent^ component, System::Collections::IDictionary^ events )
   {
      if ( oldService != nullptr )
            oldService->FilterEvents( component, events );

      return true;
   }

   virtual bool FilterProperties( System::ComponentModel::IComponent^ component, System::Collections::IDictionary^ properties )
   {
      if ( oldService != nullptr )
            oldService->FilterProperties( component, properties );

      return true;
   }
};


// System.Windows.Forms.Button associated with the ColorCycleButtonDesigner.

[Designer(ColorCycleButtonDesigner::typeid)]
public ref class ColorCycleButton: public System::Windows::Forms::Button
{
public:
   ColorCycleButton(){}

};


// Provides a designer that can add a ColorCycleButtonDesigner to each
// button in a design time project using the ButtonDesignerFilterService
// ITypeDescriptorFilterService.
public ref class ButtonDesignerFilterComponentDesigner: public System::ComponentModel::Design::ComponentDesigner
{
private:

   // Indicates whether the service has been loaded.
   bool serviceloaded;

   // Stores any old ITypeDescriptorFilterService to restore later.
   ITypeDescriptorFilterService^ oldservice;

public:
   ButtonDesignerFilterComponentDesigner()
   {
      serviceloaded = false;
   }

   // Loads the new ITypeDescriptorFilterService and reloads the
   // designers for each button.
   virtual void Initialize( System::ComponentModel::IComponent^ component ) override
   {
      ComponentDesigner::Initialize( component );

      // Loads the custom service if it has not been loaded already
      LoadService();

      // Build list of buttons from Container.Components.
      ArrayList^ buttons = gcnew ArrayList;
      IEnumerator^ myEnum = this->Component->Site->Container->Components->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         IComponent^ c = safe_cast<IComponent^>(myEnum->Current);
         if ( c->GetType() == System::Windows::Forms::Button::typeid )
                  buttons->Add( dynamic_cast<System::Windows::Forms::Button^>(c) );
      }

      if ( buttons->Count > 0 )
      {
         // Tests each Button for an existing
         // ColorCycleButtonDesigner;
         // if it has no designer of type
         // ColorCycleButtonDesigner, adds a designer.
         IEnumerator^ myEnum1 = buttons->GetEnumerator();
         while ( myEnum1->MoveNext() )
         {
            Button^ b = safe_cast<Button^>(myEnum1->Current);
            bool loaddesigner = true;

            // Gets the attributes for each button.
            AttributeCollection^ ac = TypeDescriptor::GetAttributes( b );
            for ( int i = 0; i < ac->Count; i++ )
            {
               // If designer attribute is not for a
               // ColorCycleButtonDesigner, adds a new
               // ColorCycleButtonDesigner.
               if ( dynamic_cast<DesignerAttribute^>(ac[ i ]) )
               {
                  DesignerAttribute^ da = dynamic_cast<DesignerAttribute^>(ac[ i ]);
                  if ( da->DesignerTypeName->Substring( da->DesignerTypeName->LastIndexOf( "." ) + 1 )->Equals( "ColorCycleButtonDesigner" ) )
                                    loaddesigner = false;
               }
            }
            if ( loaddesigner )
            {
               // Saves the button location so that it
               // can be repositioned.
               Point p = b->Location;

               // Gets an IMenuCommandService to cut and
               // paste control in order to register with
               // selection and movement interface after
               // designer is changed without reloading.
               IMenuCommandService^ imcs = dynamic_cast<IMenuCommandService^>(this->GetService( IMenuCommandService::typeid ));
               if ( imcs == nullptr )
                              throw gcnew Exception( "Could not obtain IMenuCommandService interface." );

               // Gets an ISelectionService to select the
               // button so that it can be cut and pasted.
               ISelectionService^ iss = dynamic_cast<ISelectionService^>(this->GetService( ISelectionService::typeid ));
               if ( iss == nullptr )
                              throw gcnew Exception( "Could not obtain ISelectionService interface." );
               array<IComponent^>^temp0 = {b};
               iss->SetSelectedComponents( dynamic_cast<ICollection^>(temp0), SelectionTypes::Normal );

               // Invoke Cut and Paste.
               imcs->GlobalInvoke( StandardCommands::Cut );
               imcs->GlobalInvoke( StandardCommands::Paste );

               // Regains reference to button from
               // selection service.
               System::Windows::Forms::Button^ b2 = dynamic_cast<System::Windows::Forms::Button^>(iss->PrimarySelection);
               iss->SetSelectedComponents( nullptr );

               // Refreshes TypeDescriptor properties of
               // button to load new attributes from
               // ButtonDesignerFilterService.
               TypeDescriptor::Refresh( b2 );
               b2->Location = p;
               b2->Focus();
            }
         }
      }
   }


private:

   // Loads a ButtonDesignerFilterService ITypeDescriptorFilterService
   // to add ColorCycleButtonDesigner designers to each button.
   void LoadService()
   {
      // If no custom ITypeDescriptorFilterService is loaded,
      // loads it now.
      if (  !serviceloaded )
      {
         // Stores the current ITypeDescriptorFilterService
         // to restore later.
         ITypeDescriptorFilterService^ tdfs = dynamic_cast<ITypeDescriptorFilterService^>(this->Component->Site->GetService( ITypeDescriptorFilterService::typeid ));
         if ( tdfs != nullptr )
                  oldservice = tdfs;

         // Retrieves an IDesignerHost interface to use to
         // remove and add services.
         IDesignerHost^ dh = dynamic_cast<IDesignerHost^>(this->Component->Site->GetService( IDesignerHost::typeid ));
         if ( dh == nullptr )
                  throw gcnew Exception( "Could not obtain IDesignerHost interface." );

         // Removes standard ITypeDescriptorFilterService.
         dh->RemoveService( ITypeDescriptorFilterService::typeid );

         // Adds new custom ITypeDescriptorFilterService.
         dh->AddService( ITypeDescriptorFilterService::typeid, gcnew ButtonDesignerFilterService );
         serviceloaded = true;
      }
   }

   // Removes the custom service and reloads any stored,
   // preexisting service.
   void RemoveService()
   {
      IDesignerHost^ dh = dynamic_cast<IDesignerHost^>(this->GetService( IDesignerHost::typeid ));
      if ( dh == nullptr )
            throw gcnew Exception( "Could not obtain IDesignerHost interface." );

      dh->RemoveService( ITypeDescriptorFilterService::typeid );
      if ( oldservice != nullptr )
            dh->AddService( ITypeDescriptorFilterService::typeid, oldservice );

      serviceloaded = false;
   }

public:
   ~ButtonDesignerFilterComponentDesigner()
   {
      if ( serviceloaded )
         RemoveService();
   }
};

// Component to host the ButtonDesignerFilterComponentDesigner that loads the
// ButtonDesignerFilterService ITypeDescriptorFilterService.

[Designer(ButtonDesignerFilterComponentDesigner::typeid)]
public ref class ButtonDesignerFilterComponent: public System::ComponentModel::Component
{
public:
   ButtonDesignerFilterComponent( System::ComponentModel::IContainer^ container )
   {
      container->Add( this );
   }

   ButtonDesignerFilterComponent(){}
};
//</Snippet1>
