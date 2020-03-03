
//<snippet1>
// Example for the Math::Log( double ) and Math::Log( double, double ) methods.
using namespace System;

// Evaluate logarithmic identities that are functions of two arguments.
void UseBaseAndArg( double argB, double argX )
{
   
   // Evaluate log(B)[X] == 1 / log(X)[B].
   Console::WriteLine( "\n                     Math::Log({1}, {0}) == {2:E16}"
   "\n               1.0 / Math::Log({0}, {1}) == {3:E16}", argB, argX, Math::Log( argX, argB ), 1.0 / Math::Log( argB, argX ) );
   
   // Evaluate log(B)[X] == ln[X] / ln[B].
   Console::WriteLine( "         Math::Log({1}) / Math::Log({0}) == {2:E16}", argB, argX, Math::Log( argX ) / Math::Log( argB ) );
   
   // Evaluate log(B)[X] == log(B)[e] * ln[X].
   Console::WriteLine( "Math::Log(Math::E, {0}) * Math::Log({1}) == {2:E16}", argB, argX, Math::Log( Math::E, argB ) * Math::Log( argX ) );
}

void main()
{
   Console::WriteLine( "This example of Math::Log( double ) and "
   "Math::Log( double, double )\n"
   "generates the following output.\n" );
   Console::WriteLine( "Evaluate these identities with "
   "selected values for X and B (base):" );
   Console::WriteLine( "   log(B)[X] == 1 / log(X)[B]" );
   Console::WriteLine( "   log(B)[X] == ln[X] / ln[B]" );
   Console::WriteLine( "   log(B)[X] == log(B)[e] * ln[X]" );
   UseBaseAndArg( 0.1, 1.2 );
   UseBaseAndArg( 1.2, 4.9 );
   UseBaseAndArg( 4.9, 9.9 );
   UseBaseAndArg( 9.9, 0.1 );
}

/*
This example of Math::Log( double ) and Math::Log( double, double )
generates the following output.

Evaluate these identities with selected values for X and B (base):
   log(B)[X] == 1 / log(X)[B]
   log(B)[X] == ln[X] / ln[B]
   log(B)[X] == log(B)[e] * ln[X]

                     Math::Log(1.2, 0.1) == -7.9181246047624818E-002
               1.0 / Math::Log(0.1, 1.2) == -7.9181246047624818E-002
         Math::Log(1.2) / Math::Log(0.1) == -7.9181246047624818E-002
Math::Log(Math::E, 0.1) * Math::Log(1.2) == -7.9181246047624804E-002

                     Math::Log(4.9, 1.2) == 8.7166610085093179E+000
               1.0 / Math::Log(1.2, 4.9) == 8.7166610085093161E+000
         Math::Log(4.9) / Math::Log(1.2) == 8.7166610085093179E+000
Math::Log(Math::E, 1.2) * Math::Log(4.9) == 8.7166610085093179E+000

                     Math::Log(9.9, 4.9) == 1.4425396251981288E+000
               1.0 / Math::Log(4.9, 9.9) == 1.4425396251981288E+000
         Math::Log(9.9) / Math::Log(4.9) == 1.4425396251981288E+000
Math::Log(Math::E, 4.9) * Math::Log(9.9) == 1.4425396251981288E+000

                     Math::Log(0.1, 9.9) == -1.0043839404494075E+000
               1.0 / Math::Log(9.9, 0.1) == -1.0043839404494075E+000
         Math::Log(0.1) / Math::Log(9.9) == -1.0043839404494075E+000
Math::Log(Math::E, 9.9) * Math::Log(0.1) == -1.0043839404494077E+000
*/
//</snippet1>
