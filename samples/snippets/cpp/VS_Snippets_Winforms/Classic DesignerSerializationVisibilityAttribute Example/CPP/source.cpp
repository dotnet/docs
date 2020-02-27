

// <Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Windows::Forms;

// This attribute indicates that the public properties of this object should be listed in the property grid.

[TypeConverterAttribute(System::ComponentModel::ExpandableObjectConverter::typeid)]
public ref class DimensionData
{
private:
   Control^ owner;

internal:

   // This class reads and writes the Location and Size properties from the Control which it is initialized to.
   DimensionData( Control^ owner )
   {
      this->owner = owner;
   }

public:

   property Point Location 
   {
      Point get()
      {
         return owner->Location;
      }

      void set( Point value )
      {
         owner->Location = value;
      }

   }

   property Size FormSize 
   {
      Size get()
      {
         return owner->Size;
      }

      void set( Size value )
      {
         owner->Size = value;
      }
   }
};

// The code for this user control declares a public property of type DimensionData with a DesignerSerializationVisibility 
// attribute set to DesignerSerializationVisibility.Content, indicating that the properties of the object should be serialized.
// The public, not hidden properties of the object that are set at design time will be persisted in the initialization code
// for the class object. Content persistence will not work for structs without a custom TypeConverter.  
public ref class ContentSerializationExampleControl: public System::Windows::Forms::UserControl
{
private:
   System::ComponentModel::Container^ components;

public:

   property DimensionData^ Dimensions 
   {
      [DesignerSerializationVisibility(DesignerSerializationVisibility::Content)]
      DimensionData^ get()
      {
         return gcnew DimensionData( this );
      }
   }
   ContentSerializationExampleControl()
   {
      InitializeComponent();
   }

public:
   ~ContentSerializationExampleControl()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:
   void InitializeComponent()
   {
      components = gcnew System::ComponentModel::Container;
   }
};
// </Snippet1>
