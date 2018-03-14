

// <Snippet1>
#using <system.xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Reflection;
public ref class MyFindInterfacesSample
{
public:
    static bool MyInterfaceFilter(Type^ typeObj, Object^ criteriaObj)
    {
        if(typeObj->ToString()->Equals(criteriaObj->ToString()))
            return true;
        else
            return false;
   }
};

int main()
{
    try
    {
        XmlDocument^ myXMLDoc = gcnew XmlDocument;
        myXMLDoc->LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" 
            + "<title>Pride And Prejudice</title> </book>");
        Type^ myType = myXMLDoc->GetType();
      
        // Specify the TypeFilter delegate that compares the interfaces 
        // against filter criteria.
        TypeFilter^ myFilter = gcnew TypeFilter( 
            MyFindInterfacesSample::MyInterfaceFilter);
        array<String^>^myInterfaceList = {"System.Collections.IEnumerable",
            "System.Collections.ICollection"};
        for(int index = 0; index < myInterfaceList->Length; index++)
        {
            array<Type^>^myInterfaces = myType->FindInterfaces( 
                myFilter, myInterfaceList[index]);
            if(myInterfaces->Length > 0)
            {
                Console::WriteLine("\n{0} implements the interface {1}.", 
                    myType, myInterfaceList[index]);
                for(int j = 0; j < myInterfaces->Length; j++)
                Console::WriteLine("Interfaces supported: {0}.",
                    myInterfaces[j]);
            }
            else
                Console::WriteLine(
                    "\n{0} does not implement the interface {1}.", 
                    myType, myInterfaceList[index]);

        }
    }
    catch(ArgumentNullException^ e) 
    {
        Console::WriteLine("ArgumentNullException: {0}", e->Message);
    }
    catch(TargetInvocationException^ e) 
    {
        Console::WriteLine("TargetInvocationException: {0}", e->Message);
    }
    catch(Exception^ e) 
    {
        Console::WriteLine("Exception: {0}", e->Message);
    }
}

// </Snippet1>
