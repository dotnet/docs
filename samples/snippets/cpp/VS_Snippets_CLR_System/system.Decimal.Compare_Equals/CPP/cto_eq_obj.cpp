
//<Snippet1>
// Example of the Decimal::CompareTo and Decimal::Equals instance 
// methods.
using namespace System;

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}


// Compare the Decimal to the Object parameters, 
// and display the Object parameters with the results.
void CompDecimalToObject( Decimal Left, Object^ Right, String^ RightText )
{
   Console::WriteLine( "{0,-46}{1}", String::Concat( "Object: ", RightText ), Right );
   Console::WriteLine( "{0,-46}{1}", "Left.Equals( Object )", Left.Equals( Right ) );
   Console::Write( "{0,-46}", "Left.CompareTo( Object )" );
   try
   {
      
      // Catch the exception if CompareTo( ) throws one.
      Console::WriteLine( "{0}\n", Left.CompareTo( Right ) );
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "{0}\n", GetExceptionType( ex ) );
   }

}

int main()
{
   Console::WriteLine( "This example of the Decimal::Equals( Object* ) and \n"
   "Decimal::CompareTo( Object* ) methods generates the \n"
   "following output. It creates several different "
   "Decimal \nvalues and compares them with the following "
   "reference value.\n" );
   
   // Create a reference Decimal value.
   Decimal Left = Decimal(987.654);
   Console::WriteLine( "{0,-46}{1}\n", "Left: Decimal( 987.654 )", Left );
   
   // Create objects to compare with the reference.
   CompDecimalToObject( Left, Decimal(9.8765400E+2), "Decimal( 9.8765400E+2 )" );
   CompDecimalToObject( Left, Decimal::Parse( "987.6541" ), "Decimal::Parse( \"987.6541\" )" );
   CompDecimalToObject( Left, Decimal::Parse( "987.6539" ), "Decimal::Parse( \"987.6539\" )" );
   CompDecimalToObject( Left, Decimal(987654000,0,0,false,6), "Decimal( 987654000, 0, 0, false, 6 )" );
   CompDecimalToObject( Left, 9.8765400E+2, "Double 9.8765400E+2" );
   CompDecimalToObject( Left, "987.654", "String \"987.654\"" );
}

/*
This example of the Decimal::Equals( Object* ) and
Decimal::CompareTo( Object* ) methods generates the
following output. It creates several different Decimal
values and compares them with the following reference value.

Left: Decimal( 987.654 )                      987.654

Object: Decimal( 9.8765400E+2 )               987.654
Left.Equals( Object )                         True
Left.CompareTo( Object )                      0

Object: Decimal::Parse( "987.6541" )          987.6541
Left.Equals( Object )                         False
Left.CompareTo( Object )                      -1

Object: Decimal::Parse( "987.6539" )          987.6539
Left.Equals( Object )                         False
Left.CompareTo( Object )                      1

Object: Decimal( 987654000, 0, 0, false, 6 )  987.654000
Left.Equals( Object )                         True
Left.CompareTo( Object )                      0

Object: Double 9.8765400E+2                   987.654
Left.Equals( Object )                         False
Left.CompareTo( Object )                      ArgumentException

Object: String "987.654"                      987.654
Left.Equals( Object )                         False
Left.CompareTo( Object )                      ArgumentException
*/
//</Snippet1>
