// <Snippet1>
using namespace System;
using namespace System::Reflection;

// Create a class having three properties.
public ref class PropertyClass
{

public:
   property String^ Property1
   {
      String^ get()
      {
         return "hello";
      }
   }

   property String^ Property2 
   {
      String^ get()
      {
         return "hello";
      }
   }

protected:
   property String^ Property3
   {
      String^ get()
      {
         return "hello";
      }
   }

private:
   property int Property4
   {
      int get()
      {
         return 32;
      }
   }

internal:
   property String^ Property5
   {
      String^ get()
      {
         return "value";
      }
   }
   
public protected:
   property String^ Property6
   {
      String^ get()
      {
         return "value";
      }
   }
};

String^ GetVisibility(MethodInfo^ accessor)
{
    if (accessor->IsPublic)
       return "Public";
    else if (accessor->IsPrivate)
       return "Private";
    else if (accessor->IsFamily)
       return "Protected";
    else if (accessor->IsAssembly)
       return "Internal/Friend";
    else
       return "Protected Internal/Friend";
}

void DisplayPropertyInfo(array<PropertyInfo^>^ propInfos )
{
   // Display information for all properties.
   for each(PropertyInfo^ propInfo in propInfos) {
      bool readable = propInfo->CanRead;
      bool writable = propInfo->CanWrite;
      
      Console::WriteLine("   Property name: {0}", propInfo->Name);
      Console::WriteLine("   Property type: {0}", propInfo->PropertyType);
      Console::WriteLine("   Read-Write:    {0}", readable && writable);
      if (readable) {
         MethodInfo^ getAccessor = propInfo->GetMethod;
         Console::WriteLine("   Visibility:    {0}",
                           GetVisibility(getAccessor));
      }
      if (writable) {
         MethodInfo^ setAccessor = propInfo->SetMethod;
         Console::WriteLine("   Visibility:    {0}",
                            GetVisibility(setAccessor));
      }
      Console::WriteLine();
   }
}

void main()
{
   Type^ myType = PropertyClass::typeid;
   
   // Get the public properties.
   array<PropertyInfo^>^propInfos = myType->GetProperties( static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance) );
   Console::WriteLine("The number of public properties: {0}.\n",
                      propInfos->Length);
   // Display the public properties.
   DisplayPropertyInfo( propInfos );
   
   // Get the non-public properties.
   array<PropertyInfo^>^propInfos1 = myType->GetProperties( static_cast<BindingFlags>(BindingFlags::NonPublic | BindingFlags::Instance) );
   Console::WriteLine("The number of non-public properties: {0}.\n",
                      propInfos1->Length);
   // Display all the non-public properties.
   DisplayPropertyInfo(propInfos1);
}
// The example displays the following output:
//       The number of public properties: 2.
//
//          Property name: Property2
//          Property type: System.String
//          Read-Write:    False
//          Visibility:    Public
//
//          Property name: Property1
//          Property type: System.String
//          Read-Write:    False
//          Visibility:    Public
//
//       The number of non-public properties: 4.
//
//          Property name: Property6
//          Property type: System.String
//          Read-Write:    False
//          Visibility:    Protected Internal/Friend
//
//          Property name: Property5
//          Property type: System.String
//          Read-Write:    False
//          Visibility:    Internal/Friend
//
//          Property name: Property4
//          Property type: System.Int32
//          Read-Write:    False
//          Visibility:    Private
//
//          Property name: Property3
//          Property type: System.String
//          Read-Write:    False
//          Visibility:    Protected
// </Snippet1>
