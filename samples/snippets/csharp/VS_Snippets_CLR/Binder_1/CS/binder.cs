// <Snippet1>
using System;
using System.Reflection;
using System.Globalization;

public class MyBinder : Binder 
{
    public MyBinder() : base()
    {
    }
    private class BinderState
    {
        public object[] args;
    }
    public override FieldInfo BindToField(
        BindingFlags bindingAttr,
        FieldInfo[] match,
        object value,
        CultureInfo culture
        )
    {
        if(match == null)
            throw new ArgumentNullException("match");
        // Get a field for which the value parameter can be converted to the specified field type.
        for(int i = 0; i < match.Length; i++)
            if(ChangeType(value, match[i].FieldType, culture) != null)
                return match[i];
        return null;
    }
    public override MethodBase BindToMethod(
        BindingFlags bindingAttr,
        MethodBase[] match,
        ref object[] args,
        ParameterModifier[] modifiers,
        CultureInfo culture,
        string[] names,
        out object state
        )
    {
        // Store the arguments to the method in a state object.
        BinderState myBinderState = new BinderState();
        object[] arguments = new Object[args.Length];
        args.CopyTo(arguments, 0);
        myBinderState.args = arguments;
        state = myBinderState;
        if(match == null)
            throw new ArgumentNullException();
        // Find a method that has the same parameters as those of the args parameter.
        for(int i = 0; i < match.Length; i++)
        {
            // Count the number of parameters that match.
            int count = 0;
            ParameterInfo[] parameters = match[i].GetParameters();
            // Go on to the next method if the number of parameters do not match.
            if(args.Length != parameters.Length)
                continue;
            // Match each of the parameters that the user expects the method to have.
            for(int j = 0; j < args.Length; j++)
            {
                // If the names parameter is not null, then reorder args.
                if(names != null)
                {
                    if(names.Length != args.Length)
                        throw new ArgumentException("names and args must have the same number of elements.");
                    for(int k = 0; k < names.Length; k++)
                        if(String.Compare(parameters[j].Name, names[k].ToString()) == 0)
                            args[j] = myBinderState.args[k];
                }
                // Determine whether the types specified by the user can be converted to the parameter type.
                if(ChangeType(args[j], parameters[j].ParameterType, culture) != null)
                    count += 1;
                else
                    break;
            }
            // Determine whether the method has been found.
            if(count == args.Length)
                return match[i];
        }
        return null;
    }
    public override object ChangeType(
        object value,
        Type myChangeType,
        CultureInfo culture
        )
    {
        // Determine whether the value parameter can be converted to a value of type myType.
        if(CanConvertFrom(value.GetType(), myChangeType))
            // Return the converted object.
            return Convert.ChangeType(value, myChangeType);
        else
            // Return null.
            return null;
    }
    public override void ReorderArgumentArray(
        ref object[] args,
        object state
        )
    {
        // Return the args that had been reordered by BindToMethod.
        ((BinderState)state).args.CopyTo(args, 0);
    }
    public override MethodBase SelectMethod(
        BindingFlags bindingAttr,
        MethodBase[] match,
        Type[] types,
        ParameterModifier[] modifiers
        )
    {
        if(match == null)
            throw new ArgumentNullException("match");
        for(int i = 0; i < match.Length; i++)
        {
            // Count the number of parameters that match.
            int count = 0; 
            ParameterInfo[] parameters = match[i].GetParameters();
            // Go on to the next method if the number of parameters do not match.
            if(types.Length != parameters.Length)
                continue;
            // Match each of the parameters that the user expects the method to have.
            for(int j = 0; j < types.Length; j++)
                // Determine whether the types specified by the user can be converted to parameter type.
                if(CanConvertFrom(types[j], parameters[j].ParameterType))
                    count += 1;
                else
                    break;
            // Determine whether the method has been found.
            if(count == types.Length)
                return match[i];
        }
        return null;
    }
    public override PropertyInfo SelectProperty(
        BindingFlags bindingAttr,
        PropertyInfo[] match,
        Type returnType,
        Type[] indexes,
        ParameterModifier[] modifiers
        )
    {
        if(match == null)
            throw new ArgumentNullException("match");
        for(int i = 0; i < match.Length; i++)
        {
            // Count the number of indexes that match.
            int count = 0;
            ParameterInfo[] parameters = match[i].GetIndexParameters();
            // Go on to the next property if the number of indexes do not match.
            if(indexes.Length != parameters.Length)
                continue;
            // Match each of the indexes that the user expects the property to have.
            for(int j = 0; j < indexes.Length; j++)
                // Determine whether the types specified by the user can be converted to index type.
                if(CanConvertFrom(indexes[j], parameters[j].ParameterType))
                    count += 1;
                else
                    break;
            // Determine whether the property has been found.
            if(count == indexes.Length)
                // Determine whether the return type can be converted to the properties type.
                if(CanConvertFrom(returnType, match[i].PropertyType))
                    return match[i];
                else
                    continue;
        }
        return null;
    }
    // Determines whether type1 can be converted to type2. Check only for primitive types.
    private bool CanConvertFrom(Type type1, Type type2)
    {
        if(type1.IsPrimitive && type2.IsPrimitive)
        {
            TypeCode typeCode1 = Type.GetTypeCode(type1);
            TypeCode typeCode2 = Type.GetTypeCode(type2);
            // If both type1 and type2 have the same type, return true.
            if(typeCode1 == typeCode2)
                return true;
            // Possible conversions from Char follow.
            if(typeCode1 == TypeCode.Char)
                switch(typeCode2)
                {
                    case TypeCode.UInt16 : return true;
                    case TypeCode.UInt32 : return true;
                    case TypeCode.Int32  : return true;
                    case TypeCode.UInt64 : return true;
                    case TypeCode.Int64  : return true;
                    case TypeCode.Single : return true;
                    case TypeCode.Double : return true;
                    default              : return false;
                }
            // Possible conversions from Byte follow.
            if(typeCode1 == TypeCode.Byte)
                switch(typeCode2)
                {
                    case TypeCode.Char   : return true;
                    case TypeCode.UInt16 : return true;
                    case TypeCode.Int16  : return true;
                    case TypeCode.UInt32 : return true;
                    case TypeCode.Int32  : return true;
                    case TypeCode.UInt64 : return true;
                    case TypeCode.Int64  : return true;
                    case TypeCode.Single : return true;
                    case TypeCode.Double : return true;
                    default              : return false;
                }
            // Possible conversions from SByte follow.
            if(typeCode1 == TypeCode.SByte)
                switch(typeCode2)
                {
                    case TypeCode.Int16  : return true;
                    case TypeCode.Int32  : return true;
                    case TypeCode.Int64  : return true;
                    case TypeCode.Single : return true;
                    case TypeCode.Double : return true;
                    default              : return false;
                }
            // Possible conversions from UInt16 follow.
            if(typeCode1 == TypeCode.UInt16)
                switch(typeCode2)
                {
                    case TypeCode.UInt32 : return true;
                    case TypeCode.Int32  : return true;
                    case TypeCode.UInt64 : return true;
                    case TypeCode.Int64  : return true;
                    case TypeCode.Single : return true;
                    case TypeCode.Double : return true;
                    default              : return false;
                }
            // Possible conversions from Int16 follow.
            if(typeCode1 == TypeCode.Int16)
                switch(typeCode2)
                {
                    case TypeCode.Int32  : return true;
                    case TypeCode.Int64  : return true;
                    case TypeCode.Single : return true;
                    case TypeCode.Double : return true;
                    default              : return false;
                }
            // Possible conversions from UInt32 follow.
            if(typeCode1 == TypeCode.UInt32)
                switch(typeCode2)
                {
                    case TypeCode.UInt64 : return true;
                    case TypeCode.Int64  : return true;
                    case TypeCode.Single : return true;
                    case TypeCode.Double : return true;
                    default              : return false;
                }
            // Possible conversions from Int32 follow.
            if(typeCode1 == TypeCode.Int32)
                switch(typeCode2)
                {
                    case TypeCode.Int64  : return true;
                    case TypeCode.Single : return true;
                    case TypeCode.Double : return true;
                    default              : return false;
                }
            // Possible conversions from UInt64 follow.
            if(typeCode1 == TypeCode.UInt64)
                switch(typeCode2)
                {
                    case TypeCode.Single : return true;
                    case TypeCode.Double : return true;
                    default              : return false;
                }
            // Possible conversions from Int64 follow.
            if(typeCode1 == TypeCode.Int64)
                switch(typeCode2)
                {
                    case TypeCode.Single : return true;
                    case TypeCode.Double : return true;
                    default              : return false;
                }
            // Possible conversions from Single follow.
            if(typeCode1 == TypeCode.Single)
                switch(typeCode2)
                {
                    case TypeCode.Double : return true;
                    default              : return false;
                }
        }
        return false;
    }
}
public class MyClass1
{
    public short myFieldB;
    public int myFieldA; 
    public void MyMethod(long i, char k)
    {
        Console.WriteLine("\nThis is MyMethod(long i, char k)");
    }
    public void MyMethod(long i, long j)
    {
        Console.WriteLine("\nThis is MyMethod(long i, long j)");
    }
}
public class Binder_Example
{
    public static void Main()
    {
        // Get the type of MyClass1.
        Type myType = typeof(MyClass1);
        // Get the instance of MyClass1.
        MyClass1 myInstance = new MyClass1();
        Console.WriteLine("\nDisplaying the results of using the MyBinder binder.\n");
        // Get the method information for MyMethod.
        MethodInfo myMethod = myType.GetMethod("MyMethod", BindingFlags.Public | BindingFlags.Instance,
            new MyBinder(), new Type[] {typeof(short), typeof(short)}, null);
        Console.WriteLine(myMethod);
        // Invoke MyMethod.
        myMethod.Invoke(myInstance, BindingFlags.InvokeMethod, new MyBinder(), new Object[] {(int)32, (int)32}, CultureInfo.CurrentCulture);
    }
}
// </Snippet1>