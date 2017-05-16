// <snippet11>
using System;
using System.Reflection;

// <snippet12>
[DefaultMember("GetIVal")]
public class Class1
{
    private int ival;
    private string sval;

    public Class1()
    {
        ival = 5050;
        sval = "6040";
    }

    public int GetIVal()
    {
        return ival;
    }

    public string GetSVal()
    {
        return sval;
    }
}
// </snippet12>

public class GetMemberExample
{
    public static void Main()
    {
        // <snippet13>
        Class1 c = new Class1();
        object o;
        o = c.GetType().InvokeMember("", BindingFlags.InvokeMethod, null, c, new object[0]);
        Console.WriteLine("Default member result: {0}", o);
        // </snippet13>

        GetDefMemberExample1();
        GetDefMemberExample2();
        GetDefMemberExample3();
    }

    public static void GetDefMemberExample1()
    {
        // <snippet14>
        Type classType = typeof(Class1);
        Type attribType = typeof(DefaultMemberAttribute);
        DefaultMemberAttribute defMem =
            (DefaultMemberAttribute)Attribute.GetCustomAttribute((MemberInfo)classType, attribType);
        MemberInfo[] memInfo = classType.GetMember(defMem.MemberName);
        // </snippet14>
        if ( memInfo.Length > 0)
        {
            Console.WriteLine("Default Member: {0}", memInfo[0].Name);
        }
    }

    public static void GetDefMemberExample2()
    {
        // <snippet15>
        Type t = typeof(Class1);
        MemberInfo[] memInfo = t.GetDefaultMembers();
        // </snippet15>
        if ( memInfo.Length > 0)
        {
            Console.WriteLine("Default Member: {0}", memInfo[0].Name);
        }
    }

    public static void GetDefMemberExample3()
    {
        // <snippet16>
        Type t = typeof(Class1);
        object[] customAttribs = t.GetCustomAttributes(typeof(DefaultMemberAttribute), false);
        if (customAttribs.Length > 0)
        {
            DefaultMemberAttribute defMem = (DefaultMemberAttribute)customAttribs[0];
            MemberInfo[] memInfo = t.GetMember(defMem.MemberName);
            if (memInfo.Length > 0)
            {
                Console.WriteLine("Default Member: {0}", memInfo[0].Name);
            }
        }
        // </snippet16>
    }
}
// </snippet11>
