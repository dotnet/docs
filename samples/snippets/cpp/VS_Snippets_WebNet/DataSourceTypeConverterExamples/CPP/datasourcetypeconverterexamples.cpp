#using <System.dll>
#using <System.Drawing.dll>
#using <System.Web.dll>
#using <System.Design.dll>

using namespace System;
using namespace System::Web::UI;
using namespace System::Web::UI::Design;
using namespace System::Web::UI::WebControls;
using namespace System::ComponentModel;

public ref class DataSourceTypeConverterExampleControl: public System::Web::UI::WebControls::WebControl
{
   //<Snippet1>
   // Associates the DataBindingCollectionConverter
   // with a DataBindingCollection property.
public:
   [TypeConverterAttribute(DataBindingCollectionConverter::typeid)]
   property DataBindingCollection^ dataBindings 
   {
      DataBindingCollection^ get()
      {
         return bindings;
      }
      void set( DataBindingCollection^ value )
      {
         bindings = value;
      }
   }
private:
   DataBindingCollection^ bindings;
   //</Snippet1>

   //<Snippet2>
   // Associates the DataMemberConverter with a string property.
public:
   [TypeConverterAttribute(DataMemberConverter::typeid)]
   property String^ dataMember 
   {
      String^ get()
      {
         return member;
      }
      void set( String^ value )
      {
         member = value;
      }
   }
private:
   String^ member;
   //</Snippet2>

   //<Snippet3>
   // Associates the DataFieldConverter with a string property.
public:
   [TypeConverterAttribute(DataMemberConverter::typeid)]
   property String^ dataField 
   {
      String^ get()
      {
         return field;
      }
      void set( String^ value )
      {
         field = value;
      }
   }
private:
   String^ field;
   //</Snippet3>

   //<Snippet4>
   // Associates the DataSourceConverter with an object property.
public:
   [TypeConverterAttribute(DataSourceConverter::typeid)]
   property Object^ dataSource 
   {
      Object^ get()
      {
         return source;
      }
      void set( Object^ value )
      {
         source = value;
      }
   }
private:
   Object^ source;
   //</Snippet4>

public:
   [Bindable(true),
      Category("Appearance"),
      DefaultValue("")]
   property String^ Text 
   {
      String^ get()
      {
         return text;
      }
      void set( String^ value )
      {
         text = value;
      }
   }
private:
   String^ text;

protected:
   virtual void Render( HtmlTextWriter^ output ) override
   {
      output->Write( Text );
   }
};
