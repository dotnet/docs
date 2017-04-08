//<Snippet1>
using namespace System;
using namespace System::Collections;
using namespace System::Reflection;

// Define a sample interface to use as an interface constraint.
interface class ITest{};

// Define a base type to use as a class constraint.
public ref class Base{};

// Define the generic type to examine. The first generic type parameter,
// T, derives from the class Base and implements ITest. This demonstrates
// a base class constraint and an interface constraint. In the .NET
// Framework version 2.0, C++ has no way of expressing special constraints.
// See the C# example code.
//
generic <typename T, typename U>
   where T :  Base, ITest
ref class Test {};

// Define a type that derives from Base and implements interface
// ITest. This type satisfies the constraint on T in class Test.
public ref class Derived: public Base, public ITest {};

public ref class Example
{
public:
   static void Main()
   {
      // Create a constructed type from Test<T,U>, and from it
      // get the generic type definition.
      //
      Type^ def = Test::typeid;
      Console::WriteLine( L"\r\nExamining generic type {0}", def );
      
      // Get the type parameters of the generic type definition,
      // and display them.
      //
      for each (Type^ tp in def->GetGenericArguments())
      {
         Console::WriteLine( L"\r\nType parameter: {0}", tp);
         Console::WriteLine( L"\t{0}", 
            ListGenericParameterAttributes( tp ) );
         
         // List the base class and interface constraints. The
         // constraints do not appear in any particular order. If
         // there are no class or interface constraints, an empty
         // array is returned.
         //
         for each (Type^ constraint in tp->GetGenericParameterConstraints())
         {
            Console::WriteLine( L"\t{0}", constraint );
         }
      }
   }

private:

   // List the variance and special constraint flags. 
   //
   static String^ ListGenericParameterAttributes( Type^ t )
   {
      String^ retval;
      GenericParameterAttributes gpa = t->GenericParameterAttributes;

      // Select the variance flag.
      GenericParameterAttributes variance =
         static_cast<GenericParameterAttributes>(
            gpa & GenericParameterAttributes::VarianceMask );

      if ( variance == GenericParameterAttributes::None )
            retval = L"No variance flag;";
      else
      {
         if ( (variance & GenericParameterAttributes::Covariant) !=
               GenericParameterAttributes::None )
            retval = L"Covariant;";
         else
            retval = L"Contravariant;";
      }

      // Select the special constraint flags.
      GenericParameterAttributes constraints =
         static_cast<GenericParameterAttributes>(
            gpa & GenericParameterAttributes::SpecialConstraintMask);

      if ( constraints == GenericParameterAttributes::None )
            retval = String::Concat( retval, L" No special constraints" );
      else
      {
         if ( (constraints & GenericParameterAttributes::ReferenceTypeConstraint) !=
               GenericParameterAttributes::None )
            retval = String::Concat( retval, L" ReferenceTypeConstraint" );

         if ( (constraints & GenericParameterAttributes::NotNullableValueTypeConstraint) !=
               GenericParameterAttributes::None )
            retval = String::Concat( retval, L" NotNullableValueTypeConstraint" );

         if ( (constraints & GenericParameterAttributes::DefaultConstructorConstraint) !=
               GenericParameterAttributes::None )
            retval = String::Concat( retval, L" DefaultConstructorConstraint" );
      }

      return retval;
   }
};

int main()
{
   Example::Main();
}

/* This example produces the following output:

Examining generic type Test`2[T,U]

Type parameter: T
        No variance flag; No special constraints
        Base
        ITest

Type parameter: U
        No variance flag; No special constraints
 */
//</Snippet1>
