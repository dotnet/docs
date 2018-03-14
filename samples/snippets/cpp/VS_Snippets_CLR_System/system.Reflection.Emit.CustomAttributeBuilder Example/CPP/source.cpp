
// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

// We will apply this custom attribute to our dynamic type.
public ref class ClassCreator: public Attribute
{
private:
   String^ creator;

public:

   property String^ Creator 
   {
      String^ get()
      {
         return creator;
      }

   }
   ClassCreator( String^ name )
   {
      this->creator = name;
   }

};


// We will apply this dynamic attribute to our dynamic method.
public ref class DateLastUpdated: public Attribute
{
private:
   String^ dateUpdated;

public:

   property String^ DateUpdated 
   {
      String^ get()
      {
         return dateUpdated;
      }

   }
   DateLastUpdated( String^ theDate )
   {
      this->dateUpdated = theDate;
   }

};

Type^ BuildTypeWithCustomAttributesOnMethod()
{
   AppDomain^ currentDomain = Thread::GetDomain();
   AssemblyName^ myAsmName = gcnew AssemblyName;
   myAsmName->Name = "MyAssembly";
   AssemblyBuilder^ myAsmBuilder = currentDomain->DefineDynamicAssembly( myAsmName, AssemblyBuilderAccess::Run );
   ModuleBuilder^ myModBuilder = myAsmBuilder->DefineDynamicModule( "MyModule" );
   
   // First, we'll build a type with a custom attribute attached.
   TypeBuilder^ myTypeBuilder = myModBuilder->DefineType( "MyType", TypeAttributes::Public );
   array<Type^>^temp6 = {String::typeid};
   array<Type^>^ctorParams = temp6;
   ConstructorInfo^ classCtorInfo = ClassCreator::typeid->GetConstructor( ctorParams );
   array<Object^>^temp0 = {"Joe Programmer"};
   CustomAttributeBuilder^ myCABuilder = gcnew CustomAttributeBuilder( classCtorInfo,temp0 );
   myTypeBuilder->SetCustomAttribute( myCABuilder );
   
   // Now, let's build a method and add a custom attribute to it.
   array<Type^>^temp1 = gcnew array<Type^>(0);
   MethodBuilder^ myMethodBuilder = myTypeBuilder->DefineMethod( "HelloWorld", MethodAttributes::Public, nullptr, temp1 );
   array<Type^>^temp7 = {String::typeid};
   ctorParams = temp7;
   classCtorInfo = DateLastUpdated::typeid->GetConstructor( ctorParams );
   array<Object^>^temp2 = {DateTime::Now.ToString()};
   CustomAttributeBuilder^ myCABuilder2 = gcnew CustomAttributeBuilder( classCtorInfo,temp2 );
   myMethodBuilder->SetCustomAttribute( myCABuilder2 );
   ILGenerator^ myIL = myMethodBuilder->GetILGenerator();
   myIL->EmitWriteLine( "Hello, world!" );
   myIL->Emit( OpCodes::Ret );
   return myTypeBuilder->CreateType();
}

int main()
{
   Type^ myType = BuildTypeWithCustomAttributesOnMethod();
   Object^ myInstance = Activator::CreateInstance( myType );
   array<Object^>^customAttrs = myType->GetCustomAttributes( true );
   Console::WriteLine( "Custom Attributes for Type 'MyType':" );
   Object^ attrVal = nullptr;
   System::Collections::IEnumerator^ myEnum = customAttrs->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ customAttr = safe_cast<Object^>(myEnum->Current);
      array<Object^>^temp3 = gcnew array<Object^>(0);
      attrVal = ClassCreator::typeid->InvokeMember( "Creator", BindingFlags::GetProperty, nullptr, customAttr, temp3 );
      Console::WriteLine( "-- Attribute: [{0} = \"{1}\"]", customAttr, attrVal );
   }

   Console::WriteLine( "Custom Attributes for Method 'HelloWorld()' in 'MyType':" );
   customAttrs = myType->GetMember( "HelloWorld" )[ 0 ]->GetCustomAttributes( true );
   System::Collections::IEnumerator^ myEnum2 = customAttrs->GetEnumerator();
   while ( myEnum2->MoveNext() )
   {
      Object^ customAttr = safe_cast<Object^>(myEnum2->Current);
      array<Object^>^temp4 = gcnew array<Object^>(0);
      attrVal = DateLastUpdated::typeid->InvokeMember( "DateUpdated", BindingFlags::GetProperty, nullptr, customAttr, temp4 );
      Console::WriteLine( "-- Attribute: [{0} = \"{1}\"]", customAttr, attrVal );
   }

   Console::WriteLine( "---" );
   array<Object^>^temp5 = gcnew array<Object^>(0);
   Console::WriteLine( myType->InvokeMember( "HelloWorld", BindingFlags::InvokeMethod, nullptr, myInstance, temp5 ) );
}
// </Snippet1>
