
using namespace System;
using namespace System::Reflection;

ref class TypedReferenceArray
{
private:
   TypedReferenceArray(){}


public:
   static void GetTypedRefArray()
   {
      try
      {
// <Snippet1>
         Assembly::Load("mscorlib.dll")->GetType("System.TypedReference[]");
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
   TypedReferenceArray::GetTypedRefArray();
}

