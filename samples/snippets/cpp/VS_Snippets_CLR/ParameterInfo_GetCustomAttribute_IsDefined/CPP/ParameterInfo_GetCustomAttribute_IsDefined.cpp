// <Snippet1>
// System::Reflection::ParameterInfo::GetCustomAttributes(Type, bool)
// System::Reflection::ParameterInfo::IsDefined(Type, bool)
using namespace System;
using namespace System::Reflection;

// Define a custom attribute with one named parameter.
[AttributeUsage(AttributeTargets::Parameter)]
public ref class MyAttribute: public Attribute
{
private:
   String^ myName;

public:
   MyAttribute( String^ name )
   {
      myName = name;
   }

   property String^ Name 
   {
      String^ get()
      {
         return myName;
      }
   }
};

// Derive another custom attribute from MyAttribute.
[AttributeUsage(AttributeTargets::Parameter)]
public ref class MyDerivedAttribute: public MyAttribute
{
public:
   MyDerivedAttribute( String^ name ) : MyAttribute( name ) {}
};

// Define a class with a method that has three parameters. Apply
// MyAttribute to one parameter, MyDerivedAttribute to another, and
// no attributes to the third. 
public ref class MyClass1
{
public:
   void MyMethod( [MyAttribute("This is an example parameter attribute")] 
                  int i,
                  [MyDerivedAttribute("This is another parameter attribute")] 
                  int j,
                  int k ){}
};

void main()
{
   // Get the type of the class 'MyClass1'.
   Type^ myType = MyClass1::typeid;

   // Get the members associated with the class 'MyClass1'.
   array<MethodInfo^>^myMethods = myType->GetMethods();

   // For each method of the class 'MyClass1', display all the parameters
   // to which MyAttribute or its derived types have been applied.
   for each ( MethodInfo^ mi in myMethods )
   {
      // Get the parameters for the method.
      array<ParameterInfo^>^ myParameters = mi->GetParameters();
      if ( myParameters->Length > 0 )
      {
         Console::WriteLine("\nThe following parameters of {0} have MyAttribute or a derived type:", mi);
         for each ( ParameterInfo^ pi in myParameters)
         {
            if (pi->IsDefined(MyAttribute::typeid, false))
            {
               Console::WriteLine("Parameter {0}, name = {1}, type = {2}", 
                  pi->Position, pi->Name, pi->ParameterType);
            }
         }
      }
   }
}

/* This code example produces the following output:

The following parameters of Void MyMethod(Int32, Int32, Int32) have MyAttribute or a derived type:
Parameter 0, name = i, type = System.Int32
Parameter 1, name = j, type = System.Int32

The following parameters of Boolean Equals(System.Object) have MyAttribute or a derived type:
 */
// </Snippet1>
