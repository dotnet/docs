
// <Snippet1>
using namespace System;
using namespace System::Reflection;

// A class that contains some properties.
public ref class MyProperty
{
private:

   // Define a simple string property.
   String^ caption;

public:

   property String^ Caption 
   {
      String^ get()
      {
         return caption;
      }

      void set( String^ value )
      {
         if ( caption != value )
         {
            caption = value;
         }
      }

   }

private:

   // A very limited indexer that gets or sets one of four 
   // strings.
   array<String^>^strings;

public:
   MyProperty()
   {
      array<String^>^temp0 = {"abc","def","ghi","jkl"};
      strings = temp0;
   }


   property String^ Item [int]
   {
      String^ get( int Index )
      {
         return strings[ Index ];
      }

      void set( int Index, String^ value )
      {
         strings[ Index ] = value;
      }

   }

};

int main()
{
   
   // Get the type and PropertyInfo.
   Type^ t = Type::GetType( "MyProperty" );
   PropertyInfo^ pi = t->GetProperty( "Caption" );
   
   // Get the public GetIndexParameters method.
   array<ParameterInfo^>^parms = pi->GetIndexParameters();
   Console::WriteLine( "\n{0}.{1} has {2} parameters.", t->FullName, pi->Name, parms->GetLength( 0 ) );
   
   // Display a property that has parameters. 
   pi = t->GetProperty( "Item" );
   parms = pi->GetIndexParameters();
   Console::WriteLine( "{0}.{1} has {2} parameters.", t->FullName, pi->Name, parms->GetLength( 0 ) );
   for ( int i = 0; i < parms->GetLength( 0 ); i++ )
   {
      Console::WriteLine( "    Parameter: {0}", parms[ i ]->Name );

   }
   return 0;
}

/*
 This example produces the following output:
 MyProperty.Caption has 0 parameters.
 MyProperty.Item has 1 parameters.
    Parameter: Index
 */
// </Snippet1>
