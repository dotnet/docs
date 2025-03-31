using System;
using System.Reflection;
using System.Globalization;

class CustomBinder : Binder
{
    public override MethodBase BindToMethod(
        BindingFlags bindingAttr,
        MethodBase[] match,
        ref object[] args,
        ParameterModifier[] modifiers,
        CultureInfo culture,
        string[] names,
        out object state)
    {
        if (match == null)
        {
            throw new ArgumentNullException(nameof(match));
        }
        // Arguments are not being reordered.
        state = null;
        // Find a parameter match and return the first method with
        // parameters that match the request.
        foreach (MethodBase mb in match)
        {
            ParameterInfo[] parameters = mb.GetParameters();

            if (ParametersMatch(parameters, args))
            {
                return mb;
            }
        }
        return null;
    }

    public override FieldInfo BindToField(BindingFlags bindingAttr,
        FieldInfo[] match, object value, CultureInfo culture)
    {
        if (match == null)
        {
            throw new ArgumentNullException(nameof(match));
        }
        foreach (FieldInfo fi in match)
        {
            if (fi.GetType() == value.GetType())
            {
                return fi;
            }
        }
        return null;
    }

    public override MethodBase SelectMethod(
        BindingFlags bindingAttr,
        MethodBase[] match,
        Type[] types,
        ParameterModifier[] modifiers)
    {
        if (match == null)
        {
            throw new ArgumentNullException(nameof(match));
        }

        // Find a parameter match and return the first method with
        // parameters that match the request.
        foreach (MethodBase mb in match)
        {
            ParameterInfo[] parameters = mb.GetParameters();
            if (ParametersMatch(parameters, types))
            {
                return mb;
            }
        }

        return null;
    }

    public override PropertyInfo SelectProperty(
        BindingFlags bindingAttr,
        PropertyInfo[] match,
        Type returnType,
        Type[] indexes,
        ParameterModifier[] modifiers)
    {
        if (match == null)
        {
            throw new ArgumentNullException(nameof(match));
        }
        foreach (PropertyInfo pi in match)
        {
            if (pi.GetType() == returnType &&
                ParametersMatch(pi.GetIndexParameters(), indexes))
            {
                return pi;
            }
        }
        return null;
    }

    public override object ChangeType(
        object value,
        Type myChangeType,
        CultureInfo culture)
    {
        try
        {
            object newType;
            newType = Convert.ChangeType(value, myChangeType);
            return newType;
        }
        // Throw an InvalidCastException if the conversion cannot
        // be done by the Convert.ChangeType method.
        catch (InvalidCastException)
        {
            return null;
        }
    }

    public override void ReorderArgumentArray(ref object[] args,
        object state)
    {
        // No operation is needed here because BindToMethod does not
        // reorder the args array. The most common implementation
        // of this method is shown below.

        // ((BinderState)state).args.CopyTo(args, 0);
    }

    // Returns true only if the type of each object in a matches
    // the type of each corresponding object in b.
    private bool ParametersMatch(ParameterInfo[] a, object[] b)
    {
        if (a.Length != b.Length)
        {
            return false;
        }
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].ParameterType != b[i].GetType())
            {
                return false;
            }
        }
        return true;
    }

    // Returns true only if the type of each object in a matches
    // the type of each corresponding entry in b.
    private bool ParametersMatch(ParameterInfo[] a, Type[] b)
    {
        if (a.Length != b.Length)
        {
            return false;
        }
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].ParameterType != b[i])
            {
                return false;
            }
        }
        return true;
    }
}

//<snippet2>
public class CustomBinderDriver
{
    public static void Main()
    {
        Type t = typeof(CustomBinderDriver);
        CustomBinder binder = new CustomBinder();
        BindingFlags flags = BindingFlags.InvokeMethod | BindingFlags.Instance |
            BindingFlags.Public | BindingFlags.Static;
        object[] args;

        // Case 1. Neither argument coercion nor member selection is needed.
        args = new object[] {};
        t.InvokeMember("PrintBob", flags, binder, null, args);

        // Case 2. Only member selection is needed.
        args = new object[] {42};
        t.InvokeMember("PrintValue", flags, binder, null, args);

        // Case 3. Only argument coercion is needed.
        args = new object[] {"5.5"};
        t.InvokeMember("PrintNumber", flags, binder, null, args);
    }

    public static void PrintBob()
    {
        Console.WriteLine("PrintBob");
    }

    public static void PrintValue(long value)
    {
        Console.WriteLine($"PrintValue({value})");
    }

    public static void PrintValue(string value)
    {
        Console.WriteLine("PrintValue\"{0}\")", value);
    }

    public static void PrintNumber(double value)
    {
        Console.WriteLine($"PrintNumber ({value})");
    }
}
//</snippet2>
