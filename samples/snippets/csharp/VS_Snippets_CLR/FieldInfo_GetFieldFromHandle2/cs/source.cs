// Created by REDMOND\glennha
//<Snippet1>
using System;
using System.Reflection;

// A generic class with a field whose type is specified by the 
// generic type parameter of the class.
public class Test<T>
{
    public T TestField;
}

public class Example
{
    public static void Main()
    {
        // Get type handles for Test<String> and its field.
        RuntimeTypeHandle rth = typeof(Test<string>).TypeHandle;
        RuntimeFieldHandle rfh = typeof(Test<string>).GetField("TestField").FieldHandle;

        // When a field belongs to a constructed generic type, 
        // such as Test<String>, retrieving the field from the
        // field handle requires the type handle of the constructed
        // generic type. An exception is thrown if the type is not
        // included.
        try
        {
            FieldInfo f1 = FieldInfo.GetFieldFromHandle(rfh);
        }
        catch(Exception ex)
        {
            Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
        }

        // To get the FieldInfo for a field on a generic type, use the
        // overload that specifies the type handle.
        FieldInfo fi = FieldInfo.GetFieldFromHandle(rfh, rth);
        Console.WriteLine("\r\nThe type of {0} is: {1}", fi.Name, fi.FieldType);

        // All constructions of Test<T> for which T is a reference
        // type share the same implementation, so the same runtime 
        // field handle can be used to retrieve the FieldInfo for 
        // TestField on any such construction. Here the runtime field
        // handle is used with Test<Object>.
        fi = FieldInfo.GetFieldFromHandle(rfh, typeof(Test<object>).TypeHandle);
        Console.WriteLine("\r\nThe type of {0} is: {1}", fi.Name, fi.FieldType);

        // Each construction of Test<T> for which T is a value type
        // has its own unique implementation, and an exception is thrown
        // if you supply a constructed type other than the one that 
        // the runtime field handle belongs to.  
        try
        {
            fi = FieldInfo.GetFieldFromHandle(rfh, typeof(Test<int>).TypeHandle);
        }
        catch(Exception ex)
        {
            Console.WriteLine("\r\n{0}: {1}", ex.GetType().Name, ex.Message);
        }
    }
}

/* This code example produces output similar to the following:

ArgumentException: Cannot resolve field TestField because the declaring type of
the field handle Test`1[T] is generic. Explicitly provide the declaring type to
GetFieldFromHandle.

The type of TestField is: System.String

The type of TestField is: System.Object

ArgumentException: Type handle 'Test`1[System.Int32]' and field handle with decl
aring type 'Test`1[System.__Canon]' are incompatible. Get RuntimeFieldHandle and
 declaring RuntimeTypeHandle off the same FieldInfo.
 */
//</Snippet1>


