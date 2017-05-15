
// <Snippet1>
using namespace System;
using namespace System::Reflection;
public ref class MyPropertyClass
{
private:
   array<int, 2>^ myPropertyArray;

public:

   property int Item [int, int]
   {
      // Declare an indexer.
      int get( int i, int j )
      {
         return myPropertyArray[ i,j ];
      }

      void set( int i, int j, int value )
      {
         myPropertyArray[ i,j ] = value;
      }

   }

};

int main()
{
   try
   {
      Type^ myType = MyPropertyClass::typeid;
      array<Type^>^myTypeArray = gcnew array<Type^>(2);
      
      // Create an instance of the Type array representing the number, order
      // and type of the parameters for the property.
      myTypeArray->SetValue( int::typeid, 0 );
      myTypeArray->SetValue( int::typeid, 1 );
      
      // Search for the indexed property whose parameters match the
      // specified argument types and modifiers.
      PropertyInfo^ myPropertyInfo = myType->GetProperty( "Item", int::typeid, myTypeArray, nullptr );
      Console::WriteLine( "{0}.{1} has a property type of {2}", myType->FullName, myPropertyInfo->Name, myPropertyInfo->PropertyType );
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "An exception occurred {0}", ex->Message );
   }

}

// </Snippet1>
