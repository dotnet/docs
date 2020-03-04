using namespace System;

ref class AppDomainLoad
{
private:
   AppDomainLoad(){}


public:
   static void CreateAndLoad()
   {
      try
      {
// <Snippet1>
         AppDomain^ ad = AppDomain::CreateDomain("ChildDomain");
         ad->Load("MyAssembly");
// </Snippet1>
      }
      catch (Exception^ ex)
      {
         Console::WriteLine(ex->Message);
         Console::WriteLine(ex->StackTrace);
      }
   }

};

int main()
{
   AppDomainLoad::CreateAndLoad();
}
