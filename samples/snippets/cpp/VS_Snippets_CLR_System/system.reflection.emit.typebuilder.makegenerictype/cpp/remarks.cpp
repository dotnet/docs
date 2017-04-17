
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

public ref class CompareGenericTypes
{
public:
    static void Main()
    {
        try
        {
            AppDomain^ currentDomain = AppDomain::CurrentDomain;

            AssemblyName^ aName = gcnew AssemblyName("TempAssembly");
            AssemblyBuilder^ ab = currentDomain->DefineDynamicAssembly(aName, AssemblyBuilderAccess::Run);
    
            ModuleBuilder^ mb = ab->DefineDynamicModule(aName->Name);

            TypeBuilder^ tbldr = mb->DefineType("MyNewType", TypeAttributes::Public);
            tbldr->DefineGenericParameters("T");
            // <Snippet1>
            Type^ t1 = tbldr->MakeGenericType(String::typeid);
            Type^ t2 = tbldr->MakeGenericType(String::typeid);
            bool result = t1->Equals(t2);
            // </Snippet1>
            Console::WriteLine("Types t1 and t2 match: {0:s}", result ? "Yes" : "No");
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
    CompareGenericTypes::Main();
}



