
// <Snippet1>
using namespace System;
using namespace System::Reflection;
ref class MyClass1
{
private:
   array<int, 2>^myArray;

public:

   property int Item [int, int]
   {

      // Declare an indexer.
      int get( int i, int j )
      {
         return myArray[ i,j ];
      }

      void set( int i, int j, int value )
      {
         myArray[ i,j ] = value;
      }

   }

};

int main()
{
   try
   {
      
      // Get the Type object.
      Type^ myType = MyClass1::typeid;
      array<Type^>^myTypeArr = gcnew array<Type^>(2);
      
      // Create an instance of a Type array.
      myTypeArr->SetValue( int::typeid, 0 );
      myTypeArr->SetValue( int::typeid, 1 );
      
      // Get the PropertyInfo object for the indexed property Item, which has two integer parameters.
      PropertyInfo^ myPropInfo = myType->GetProperty( "Item", myTypeArr );
      
      // Display the property.
      Console::WriteLine( "The {0} property exists in MyClass1.", myPropInfo );
   }
   catch ( NullReferenceException^ e ) 
   {
      Console::WriteLine( "An exception occurred." );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }

}

// </Snippet1>
