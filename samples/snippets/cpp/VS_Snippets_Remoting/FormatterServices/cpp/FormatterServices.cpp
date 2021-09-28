//Types:System.Runtime.Serialization.FormatterServices
//Types:System.Runtime.Serialization.SerializationInfoEnumerator 
//<snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Runtime::Serialization;
using namespace System::Runtime::Serialization::Formatters;
using namespace System::Runtime::Serialization::Formatters::Binary;
using namespace System::Reflection;
using namespace System::Security::Permissions;

// Person is a serializable base class.
[Serializable]
public ref class Person
{
private:
    String^ title;

public:
    Person(String^ title)
    {
        this->title = title;
    }

public:
    virtual String^ ToString() override
    {
        return String::Format("{0}", title);
    }
};

// Employee is a serializable class derived from Person.
[Serializable]
public ref class Employee : public Person
{
private:
    String^ title;

public:
    Employee(String^ title) : Person("Person")
    {
        this->title = title;
    }

public:
    virtual String^ ToString() override
    {
        return String::Format("{0} -> {1}", title, Person::ToString());
    }
};

// Manager is a serializable and ISerializable class derived from Employee.
[Serializable]
ref class Manager : public Employee, public ISerializable
{
private:
    String^ title;

public:
    Manager() : Employee("Employee")
    {
        this->title = "Manager";
    }

    //<snippet2>
public:
    [SecurityPermission(SecurityAction::Demand, SerializationFormatter = true)]
    virtual void GetObjectData(SerializationInfo^ info, StreamingContext context)
    {
        // Serialize the desired values for this class.
        info->AddValue("title", title);

        // Get the set of serializable members for the class and base classes.
        Type^ thisType = this->GetType();
        array<MemberInfo^>^ serializableMembers =
            FormatterServices::GetSerializableMembers(thisType, context);

        // Serialize the base class's fields to the info object.
        for each (MemberInfo^ serializableMember in serializableMembers)
        {
            // Do not serialize fields for this class.
            if (serializableMember->DeclaringType != thisType)
            {
                // Skip this field if it is marked NonSerialized.
                if (!(Attribute::IsDefined(serializableMember,
                    NonSerializedAttribute::typeid)))
                {
                    // Get the value of this field and add it to the
                    // SerializationInfo object.
                    info->AddValue(serializableMember->Name,
                        ((FieldInfo^)serializableMember)->GetValue(this));
                }
            }
        }

        // Call the method below to see the contents of the
        // SerializationInfo object.
        DisplaySerializationInfo(info);
    }
    //</snippet2>

    //<snippet3>
private:
    static void DisplaySerializationInfo(SerializationInfo^ info)
    {
        Console::WriteLine("Values in the SerializationInfo:");
        for each (SerializationEntry^ infoEntry in info)
        {
            Console::WriteLine("Name={0}, ObjectType={1}, Value={2}",
                infoEntry->Name, infoEntry->ObjectType, infoEntry->Value);
        }
    }
    //</snippet3>

protected:
    Manager(SerializationInfo^ info,
        StreamingContext context) : Employee(nullptr)
    {
        // Get the set of serializable members for the class and base classes.
        Type^ thisType = this->GetType();
        array<MemberInfo^>^ serializableMembers =
            FormatterServices::GetSerializableMembers(thisType, context);

        // Deserialize the base class's fields from the info object.
        for each (MemberInfo^ serializableMember in serializableMembers)
        {
            // Do not deserialize fields for this class.
            if (serializableMember->DeclaringType != thisType)
            {
                // For easier coding, treat the member as a FieldInfo object
                FieldInfo^ fieldInformation = (FieldInfo^)serializableMember;

                // Skip this field if it is marked NonSerialized.
                if (!(Attribute::IsDefined(serializableMember,
                    NonSerializedAttribute::typeid)))
                {
                    // Get the value of this field from the
                    // SerializationInfo object.
                    fieldInformation->SetValue(this,
                        info->GetValue(fieldInformation->Name,
                        fieldInformation->FieldType));
                }
            }
        }

        // Deserialize the values that were serialized for this class.
        title = info->GetString("title");
    }

public:
    virtual String^ ToString() override
    {
        return String::Format("{0} -> {1}", title, Employee::ToString());
    }
};

int main()
{
    Stream^ stream = gcnew MemoryStream();
    IFormatter^ formatter = gcnew BinaryFormatter();
    Manager^ m = gcnew Manager();
    Console::WriteLine(m->ToString());
    formatter->Serialize(stream, m);

    stream->Position = 0;
    m = (Manager^) formatter->Deserialize(stream);
    Console::WriteLine(m->ToString());
}

// This code produces the following output.
//
//  Manager -> Employee -> Person
//  Values in the SerializaitonInfo:
//  Name=title, ObjectType=System.String, Value=Manager
//  Name=Employee+title, ObjectType=System.String, Value=Employee
//  Name=Person+title, ObjectType=System.String, Value=Person
//  Manager -> Employee -> Person
//</snippet1>
