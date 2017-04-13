
using System;
using System.Reflection;

class FieldAttribTest
{
    public int field1 = 99;

    public static void Main()
    {
        object obj = new FieldAttribTest();

        // <snippet1>
        FieldInfo fi = obj.GetType().GetField("field1");

        if ((fi.Attributes & FieldAttributes.FieldAccessMask) ==
            FieldAttributes.Public)
        {
            Console.WriteLine("{0:s} is public. Value: {1:d}", fi.Name, fi.GetValue(obj));
        }
        // </snippet1>
    }
}





