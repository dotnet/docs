using namespace System;
using namespace System::Reflection;
using namespace System::Globalization;

public ref class CustomBinder : Binder
{
public:
    virtual MethodBase^ BindToMethod(
        BindingFlags bindingAttr,
        array<MethodBase^>^ match,
        array<Object^>^% args,
        array<ParameterModifier>^ modifiers,
        CultureInfo^ culture,
        array<String^>^ names,
        Object^% state) override
    {
        if (match == nullptr)
        {
            throw gcnew ArgumentNullException("match");
        }
        // Arguments are not being reordered.
        state = nullptr;
        // Find a parameter match and return the first method with
        // parameters that match the request.
        for each (MethodBase^ mb in match)
        {
            array<ParameterInfo^>^ parameters = mb->GetParameters();

            if (ParametersMatch(parameters, args))
            {
                return mb;
            }
        }
        return nullptr;
    }

    virtual FieldInfo^ BindToField(BindingFlags bindingAttr,
        array<FieldInfo^>^ match, Object^ value, CultureInfo^ culture) override
    {
        if (match == nullptr)
        {
            throw gcnew ArgumentNullException("match");
        }
        for each (FieldInfo^ fi in match)
        {
            if (fi->GetType() == value->GetType())
            {
                return fi;
            }
        }
        return nullptr;
    }

    virtual MethodBase^ SelectMethod(
        BindingFlags bindingAttr,
        array<MethodBase^>^ match,
        array<Type^>^ types,
        array<ParameterModifier>^ modifiers) override
    {
        if (match == nullptr)
        {
            throw gcnew ArgumentNullException("match");
        }

        // Find a parameter match and return the first method with
        // parameters that match the request.
        for each (MethodBase^ mb in match)
        {
            array<ParameterInfo^>^ parameters = mb->GetParameters();
            if (ParametersMatch(parameters, types))
            {
                return mb;
            }
        }

        return nullptr;
    }

    virtual PropertyInfo^ SelectProperty(
        BindingFlags bindingAttr,
        array<PropertyInfo^>^ match,
        Type^ returnType,
        array<Type^>^ indexes,
        array<ParameterModifier>^ modifiers) override
    {
        if (match == nullptr)
        {
            throw gcnew ArgumentNullException("match");
        }
        for each (PropertyInfo^ pi in match)
        {
            if (pi->GetType() == returnType &&
                ParametersMatch(pi->GetIndexParameters(), indexes))
            {
                return pi;
            }
        }
        return nullptr;
    }

    virtual Object^ ChangeType(
        Object^ value,
        Type^ myChangeType,
        CultureInfo^ culture) override
    {
        try
        {
            Object^ newType;
            newType = Convert::ChangeType(value, myChangeType);
            return newType;
        }
        // Throw an InvalidCastException if the conversion cannot
        // be done by the Convert.ChangeType method.
        catch (InvalidCastException^)
        {
            return nullptr;
        }
    }

    virtual void ReorderArgumentArray(array<Object^>^% args,
        Object^ state) override
    {
        // No operation is needed here because BindToMethod does not
        // reorder the args array. The most common implementation
        // of this method is shown below.

        // ((BinderState^)state).args.CopyTo(args, 0);
    }

    // Returns true only if the type of each object in a matches
    // the type of each corresponding object in b.
private:
    bool ParametersMatch(array<ParameterInfo^>^ a, array<Object^>^ b)
    {
        if (a->Length != b->Length)
        {
            return false;
        }
        for (int i = 0; i < a->Length; i++)
        {
            if (a[i]->ParameterType != b[i]->GetType())
            {
                return false;
            }
        }
        return true;
    }

    // Returns true only if the type of each object in a matches
    // the type of each corresponding entry in b.
    bool ParametersMatch(array<ParameterInfo^>^ a, array<Type^>^ b)
    {
        if (a->Length != b->Length)
        {
            return false;
        }
        for (int i = 0; i < a->Length; i++)
        {
            if (a[i]->ParameterType != b[i])
            {
                return false;
            }
        }
        return true;
    }
};

//<snippet2>
public ref class CustomBinderDriver
{
public:
    static void Main()
    {
        Type^ t = CustomBinderDriver::typeid;
        CustomBinder^ binder = gcnew CustomBinder();
        BindingFlags flags = BindingFlags::InvokeMethod | BindingFlags::Instance |
            BindingFlags::Public | BindingFlags::Static;
        array<Object^>^ args;

        // Case 1. Neither argument coercion nor member selection is needed.
        args = gcnew array<Object^> {};
        t->InvokeMember("PrintBob", flags, binder, nullptr, args);

        // Case 2. Only member selection is needed.
        args = gcnew array<Object^> {42};
        t->InvokeMember("PrintValue", flags, binder, nullptr, args);

        // Case 3. Only argument coercion is needed.
        args = gcnew array<Object^> {"5.5"};
        t->InvokeMember("PrintNumber", flags, binder, nullptr, args);
    }

    static void PrintBob()
    {
        Console::WriteLine("PrintBob");
    }

    static void PrintValue(long value)
    {
        Console::WriteLine("PrintValue({0})", value);
    }

    static void PrintValue(String^ value)
    {
        Console::WriteLine("PrintValue\"{0}\")", value);
    }

    static void PrintNumber(double value)
    {
        Console::WriteLine("PrintNumber ({0})", value);
    }
};

int main()
{
    CustomBinderDriver::Main();
}
//</snippet2>
