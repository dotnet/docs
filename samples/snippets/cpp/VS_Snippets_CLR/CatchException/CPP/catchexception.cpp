//<Snippet1>
using namespace System;
int main()
{
    int x = 0;
    try
    {
        int y = 100 / x;
    }
    catch ( ArithmeticException^ e ) 
    {
        Console::WriteLine( "ArithmeticException Handler: {0}", e );
    }
    catch ( Exception^ e ) 
    {
        Console::WriteLine( "Generic Exception Handler: {0}", e );
    }
}
/*
This code example produces the following results:

ArithmeticException Handler: System.DivideByZeroException: Attempted to divide by zero.
   at main()
 
*/
//</Snippet1>
