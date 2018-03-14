// Updated for 406827 REDMOND\glennha
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Security::Permissions;

public ref class Demo
{
private:
    // Make three fields:
    // The first field is private.
    String^ m_field;

    // The second field is public.
public:
    String^ Field;

    // The third field is public and literal. 
    literal String^ FieldC = "String C";

    Demo() { m_field = "String A"; Field = "String B"; }
};

static void DisplayField(Object^ obj, FieldInfo^ f)
{ 
    // Display the field name, value, and attributes.
    //
    Console::WriteLine("{0} = \"{1}\"; attributes: {2}", 
        f->Name, f->GetValue(obj), f->Attributes);
};

void main()
{
    Console::WriteLine ("\nReflection.FieldAttributes");
    Demo^ d = gcnew Demo();

    // Get a Type object for Demo, and a FieldInfo for each of
    // the three fields. Use the FieldInfo to display field
    // name, value for the Demo object in d, and attributes.
    //
    Type^ myType = Demo::typeid;

    FieldInfo^ fiPrivate = myType->GetField("m_field",
        BindingFlags::NonPublic | BindingFlags::Instance);
    DisplayField(d, fiPrivate);

    FieldInfo^ fiPublic = myType->GetField("Field",
        BindingFlags::Public | BindingFlags::Instance);
    DisplayField(d, fiPublic);

    FieldInfo^ fiConstant = myType->GetField("FieldC",
        BindingFlags::Public | BindingFlags::Static);
    DisplayField(d, fiConstant);
}

/* This code example produces the following output:

Reflection.FieldAttributes
m_field = "String A"; attributes: Private
Field = "String B"; attributes: Public
FieldC = "String C"; attributes: Public, Static, Literal, HasDefault
 */
// </Snippet1>
