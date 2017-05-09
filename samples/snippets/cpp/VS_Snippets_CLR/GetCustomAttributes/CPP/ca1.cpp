// <Snippet1>
using namespace System;
using namespace System::Reflection;

[assembly:AssemblyTitle("CustAttrs1CPP")];
[assembly:AssemblyDescription("GetCustomAttributes() Demo")];
[assembly:AssemblyCompany("Microsoft")];

ref class Example
{};

static void main()
{
    Type^ clsType = Example::typeid;

    // Get the Assembly type to access its metadata.
    Assembly^ assy = clsType->Assembly;

    // Iterate through the attributes for the assembly.
    System::Collections::IEnumerator^ myEnum = Attribute::GetCustomAttributes( assy )->GetEnumerator();
    while ( myEnum->MoveNext() )
    {
       Attribute^ attr = safe_cast<Attribute^>(myEnum->Current);

       // Check for the AssemblyTitle attribute.
       if ( attr->GetType() == AssemblyTitleAttribute::typeid )
          Console::WriteLine( "Assembly title is \"{0}\".", (dynamic_cast<AssemblyTitleAttribute^>(attr))->Title );
          // Check for the AssemblyDescription attribute.
       else
          // Check for the AssemblyDescription attribute.
          if ( attr->GetType() == AssemblyDescriptionAttribute::typeid )
             Console::WriteLine( "Assembly description is \"{0}\".", (dynamic_cast<AssemblyDescriptionAttribute^>(attr))->Description );
          // Check for the AssemblyCompany attribute.
          else if ( attr->GetType() == AssemblyCompanyAttribute::typeid )
             Console::WriteLine( "Assembly company is {0}.", (dynamic_cast<AssemblyCompanyAttribute^>(attr))->Company );
    }
}
// The example displays the following output:
//     Assembly description is "GetCustomAttributes() Demo".
//     Assembly company is Microsoft.
//     Assembly title is "CustAttrs1CPP".
// </Snippet1>
