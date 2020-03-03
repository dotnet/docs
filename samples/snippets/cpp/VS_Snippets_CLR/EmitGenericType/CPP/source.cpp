//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Collections::Generic;

// Dummy class to satisfy TFirst constraints.
//
public ref class Example {};

// Define a trivial base class and two trivial interfaces 
// to use when demonstrating constraints.
//
public ref class ExampleBase {};
public interface class IExampleA {};
public interface class IExampleB {};

// Define a trivial type that can substitute for type parameter 
// TSecond.
//
public ref class ExampleDerived : ExampleBase, IExampleA, IExampleB {};

// List the constraint flags. The GenericParameterAttributes
// enumeration contains two sets of attributes, variance and
// constraints. For this example, only constraints are used.
//
static void ListConstraintAttributes( Type^ t )
{
   // Mask off the constraint flags. 
   GenericParameterAttributes constraints = 
       t->GenericParameterAttributes & 
       GenericParameterAttributes::SpecialConstraintMask;

   if ((constraints & GenericParameterAttributes::ReferenceTypeConstraint)
           != GenericParameterAttributes::None)
       Console::WriteLine( L"    ReferenceTypeConstraint");

   if ((constraints & GenericParameterAttributes::NotNullableValueTypeConstraint)
           != GenericParameterAttributes::None)
       Console::WriteLine( L"    NotNullableValueTypeConstraint");

   if ((constraints & GenericParameterAttributes::DefaultConstructorConstraint)
           != GenericParameterAttributes::None)
       Console::WriteLine( L"    DefaultConstructorConstraint");
}

static void DisplayGenericParameters( Type^ t )
{
   if (!t->IsGenericType)
   {
       Console::WriteLine( L"Type '{0}' is not generic." );
       return;
   }
   if (!t->IsGenericTypeDefinition)
       t = t->GetGenericTypeDefinition();

   array<Type^>^ typeParameters = t->GetGenericArguments();
   Console::WriteLine( L"\r\nListing {0} type parameters for type '{1}'.", 
       typeParameters->Length, t );

   for each ( Type^ tParam in typeParameters )
   {
       Console::WriteLine( L"\r\nType parameter {0}:", 
           tParam->ToString() );

       for each (Type^ c in tParam->GetGenericParameterConstraints())
       {
           if (c->IsInterface)
               Console::WriteLine( L"    Interface constraint: {0}", c);
           else
               Console::WriteLine( L"    Base type constraint: {0}", c);
       }
       ListConstraintAttributes(tParam);
   }
}

void main()
{
   // Define a dynamic assembly to contain the sample type. The
   // assembly will be run and also saved to disk, so
   // AssemblyBuilderAccess.RunAndSave is specified.
   //
   //<Snippet2>
   AppDomain^ myDomain = AppDomain::CurrentDomain;
   AssemblyName^ myAsmName = gcnew AssemblyName( L"GenericEmitExample1" );
   AssemblyBuilder^ myAssembly = myDomain->DefineDynamicAssembly( 
       myAsmName, AssemblyBuilderAccess::RunAndSave );
   //</Snippet2>

   // An assembly is made up of executable modules. For a single-
   // module assembly, the module name and file name are the same 
   // as the assembly name. 
   //
   //<Snippet3>
   ModuleBuilder^ myModule = myAssembly->DefineDynamicModule( 
       myAsmName->Name, String::Concat( myAsmName->Name, L".dll" ) );
   //</Snippet3>

   // Get type objects for the base class trivial interfaces to
   // be used as constraints.
   //
   Type^ baseType = ExampleBase::typeid; 
   Type^ interfaceA = IExampleA::typeid; 
   Type^ interfaceB = IExampleB::typeid;
   
   // Define the sample type.
   //
   //<Snippet4>
   TypeBuilder^ myType = myModule->DefineType( L"Sample", 
       TypeAttributes::Public );
   //</Snippet4>
   
   Console::WriteLine( L"Type 'Sample' is generic: {0}", 
       myType->IsGenericType );
   
   // Define type parameters for the type. Until you do this, 
   // the type is not generic, as the preceding and following 
   // WriteLine statements show. The type parameter names are
   // specified as an array of strings. To make the code
   // easier to read, each GenericTypeParameterBuilder is placed
   // in a variable with the same name as the type parameter.
   // 
   //<Snippet5>
   array<String^>^typeParamNames = {L"TFirst",L"TSecond"};
   array<GenericTypeParameterBuilder^>^typeParams = 
       myType->DefineGenericParameters( typeParamNames );

   GenericTypeParameterBuilder^ TFirst = typeParams[0];
   GenericTypeParameterBuilder^ TSecond = typeParams[1];
   //</Snippet5>

   Console::WriteLine( L"Type 'Sample' is generic: {0}", 
       myType->IsGenericType );
   
   // Apply constraints to the type parameters.
   //
   // A type that is substituted for the first parameter, TFirst,
   // must be a reference type and must have a parameterless
   // constructor.
   //<Snippet6>
   TFirst->SetGenericParameterAttributes( 
       GenericParameterAttributes::DefaultConstructorConstraint | 
       GenericParameterAttributes::ReferenceTypeConstraint 
   );
   //</Snippet6>

   // A type that is substituted for the second type
   // parameter must implement IExampleA and IExampleB, and
   // inherit from the trivial test class ExampleBase. The
   // interface constraints are specified as an array
   // containing the interface types. 
   //<Snippet7>
   array<Type^>^interfaceTypes = { interfaceA, interfaceB };
   TSecond->SetInterfaceConstraints( interfaceTypes );
   TSecond->SetBaseTypeConstraint( baseType );
   //</Snippet7>

   // The following code adds a private field named ExampleField,
   // of type TFirst.
   //<Snippet21>
   FieldBuilder^ exField = 
       myType->DefineField("ExampleField", TFirst, 
           FieldAttributes::Private);
   //</Snippet21>

   // Define a static method that takes an array of TFirst and 
   // returns a List<TFirst> containing all the elements of 
   // the array. To define this method it is necessary to create
   // the type List<TFirst> by calling MakeGenericType on the
   // generic type definition, generic<T> List. 
   // The parameter type is created by using the
   // MakeArrayType method. 
   //
   //<Snippet22>
   Type^ listOf = List::typeid;
   Type^ listOfTFirst = listOf->MakeGenericType(TFirst);
   array<Type^>^ mParamTypes = { TFirst->MakeArrayType() };

   MethodBuilder^ exMethod = 
       myType->DefineMethod("ExampleMethod", 
           MethodAttributes::Public | MethodAttributes::Static, 
           listOfTFirst, 
           mParamTypes);
   //</Snippet22>

   // Emit the method body. 
   // The method body consists of just three opcodes, to load 
   // the input array onto the execution stack, to call the 
   // List<TFirst> constructor that takes IEnumerable<TFirst>,
   // which does all the work of putting the input elements into
   // the list, and to return, leaving the list on the stack. The
   // hard work is getting the constructor.
   // 
   // The GetConstructor method is not supported on a 
   // GenericTypeParameterBuilder, so it is not possible to get 
   // the constructor of List<TFirst> directly. There are two
   // steps, first getting the constructor of generic<T> List and then
   // calling a method that converts it to the corresponding 
   // constructor of List<TFirst>.
   //
   // The constructor needed here is the one that takes an
   // IEnumerable<T>. Note, however, that this is not the 
   // generic type definition of generic<T> IEnumerable; instead, the
   // T from generic<T> List must be substituted for the T of 
   // generic<T> IEnumerable. (This seems confusing only because both
   // types have type parameters named T. That is why this example
   // uses the somewhat silly names TFirst and TSecond.) To get
   // the type of the constructor argument, take the generic
   // type definition generic<T> IEnumerable and 
   // call MakeGenericType with the first generic type parameter
   // of generic<T> List. The constructor argument list must be passed
   // as an array, with just one argument in this case.
   // 
   // Now it is possible to get the constructor of generic<T> List,
   // using GetConstructor on the generic type definition. To get
   // the constructor of List<TFirst>, pass List<TFirst> and
   // the constructor from generic<T> List to the static
   // TypeBuilder.GetConstructor method.
   //
   //<Snippet23>
   ILGenerator^ ilgen = exMethod->GetILGenerator();
        
   Type^ ienumOf = IEnumerable::typeid;
   Type^ TfromListOf = listOf->GetGenericArguments()[0];
   Type^ ienumOfT = ienumOf->MakeGenericType(TfromListOf);
   array<Type^>^ ctorArgs = {ienumOfT};

   ConstructorInfo^ ctorPrep = listOf->GetConstructor(ctorArgs);
   ConstructorInfo^ ctor = 
       TypeBuilder::GetConstructor(listOfTFirst, ctorPrep);

   ilgen->Emit(OpCodes::Ldarg_0);
   ilgen->Emit(OpCodes::Newobj, ctor);
   ilgen->Emit(OpCodes::Ret);
   //</Snippet23>

   // Create the type and save the assembly. 
   //<Snippet8>
   Type^ finished = myType->CreateType();
   myAssembly->Save( String::Concat( myAsmName->Name, L".dll" ) );
   //</Snippet8>

   // Invoke the method.
   // ExampleMethod is not generic, but the type it belongs to is
   // generic, so in order to get a MethodInfo that can be invoked
   // it is necessary to create a constructed type. The Example 
   // class satisfies the constraints on TFirst, because it is a 
   // reference type and has a default constructor. In order to
   // have a class that satisfies the constraints on TSecond, 
   // this code example defines the ExampleDerived type. These
   // two types are passed to MakeGenericMethod to create the
   // constructed type.
   //
   //<Snippet9>
   array<Type^>^ typeArgs = 
       { Example::typeid, ExampleDerived::typeid };
   Type^ constructed = finished->MakeGenericType(typeArgs);
   MethodInfo^ mi = constructed->GetMethod("ExampleMethod");
   //</Snippet9>

   // Create an array of Example objects, as input to the generic
   // method. This array must be passed as the only element of an 
   // array of arguments. The first argument of Invoke is 
   // null, because ExampleMethod is static. Display the count
   // on the resulting List<Example>.
   // 
   //<Snippet10>
   array<Example^>^ input = { gcnew Example(), gcnew Example() };
   array<Object^>^ arguments = { input };

   List<Example^>^ listX = 
       (List<Example^>^) mi->Invoke(nullptr, arguments);

   Console::WriteLine(
       "\nThere are {0} elements in the List<Example>.", 
       listX->Count);
   //</Snippet10>

   DisplayGenericParameters(finished);
}

/* This code example produces the following output:

Type 'Sample' is generic: False
Type 'Sample' is generic: True

There are 2 elements in the List<Example>.

Listing 2 type parameters for type 'Sample[TFirst,TSecond]'.

Type parameter TFirst:
    ReferenceTypeConstraint
    DefaultConstructorConstraint

Type parameter TSecond:
    Interface constraint: IExampleA
    Interface constraint: IExampleB
    Base type constraint: ExampleBase
 */
//</Snippet1>
