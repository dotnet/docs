
// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Reflection;

namespace MyNamespace1
{
   interface class i
   {
      int MyVar();
   };

   // DeclaringType for MyVar is i.
   ref class A: public i
   {
   public:
      virtual int MyVar()
      {
         return 0;
      }

   };

   // DeclaringType for MyVar is A.
   ref class B: public A
   {
   private:
      int MyVar() new
      {
         return 0;
      }
   };

   // DeclaringType for MyVar is B.
   ref class C: public A{};
}

// DeclaringType for MyVar is A.
int main()
{
   Console::WriteLine( "\nReflection.MemberInfo" );

   //Get the Type and MemberInfo. 
   Type^ MyType = Type::GetType( "System.IO.BufferedStream" );
   array<MemberInfo^>^Mymemberinfoarray = MyType->GetMembers();

   //Get and display the DeclaringType method. 
   Console::WriteLine( "\nThere are {0} members in {1}.", Mymemberinfoarray->Length, MyType->FullName );
   System::Collections::IEnumerator^ enum0 = Mymemberinfoarray->GetEnumerator();
   while ( enum0->MoveNext() )
   {
      MemberInfo^ Mymemberinfo = safe_cast<MemberInfo^>(enum0->Current);
      Console::WriteLine( "Declaring type of {0} is {1}.", Mymemberinfo->Name, Mymemberinfo->DeclaringType );
   }
}

namespace MyNamespace3
{
   ref class A
   {
   public:
      virtual void M(){}

   };

   ref class B: public A
   {
   public:
      virtual void M() override {}
   };
}
// </Snippet1>
