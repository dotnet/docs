
// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Reflection;

int main()
{
   //Get the Type and MemberInfo.
   Type^ t = Type::GetType("System.IO.File");
   array<MemberInfo^>^ members = t->GetMembers();
   
   //Get and display the DeclaringType method.
   Console::WriteLine("There are {0} members in {1}.",
                      members->Length, t->FullName );
   Console::WriteLine("Is {0} non-public? {1}",
                      t->FullName, t->IsNotPublic );
}
// The example displays the following output:
//       There are 60 members in System.IO.File.
//       Is System.IO.File non-public? False
// </Snippet1>

// <Snippet2>
public ref class A
{
public:
   ref class B{};


private:
   ref class C{};


};

// </Snippet2>
