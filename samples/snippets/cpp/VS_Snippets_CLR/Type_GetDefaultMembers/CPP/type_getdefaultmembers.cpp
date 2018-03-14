
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::IO;

[DefaultMemberAttribute("Age")]
public ref class MyClass
{
public:
   void Name( String^ s ){}


   property int Age 
   {
      int get()
      {
         return 20;
      }

   }

};

int main()
{
   try
   {
      Type^ myType = MyClass::typeid;
      array<MemberInfo^>^memberInfoArray = myType->GetDefaultMembers();
      if ( memberInfoArray->Length > 0 )
      {
         System::Collections::IEnumerator^ myEnum = memberInfoArray->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            MemberInfo^ memberInfoObj = safe_cast<MemberInfo^>(myEnum->Current);
            Console::WriteLine( "The default member name is: {0}", memberInfoObj );
         }
      }
      else
      {
         Console::WriteLine( "No default members are available." );
      }
   }
   catch ( InvalidOperationException^ e ) 
   {
      Console::WriteLine( "InvalidOperationException: {0}", e->Message );
   }
   catch ( IOException^ e ) 
   {
      Console::WriteLine( "IOException: {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
// </Snippet1>
