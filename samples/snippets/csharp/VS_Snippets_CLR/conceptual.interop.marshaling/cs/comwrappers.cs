//<snippet48>
using System;
using System.Runtime.InteropServices;

public class Snippets
{
    public static void Main()
    {
    }

    //<snippet49>
    void M1([MarshalAs(UnmanagedType.LPWStr)] string msg)
    {
        // ...
    }
    //</snippet49>

    //<snippet51>
    [return: MarshalAs(UnmanagedType.LPWStr)]
    public string GetMessage()
    {
        string msg = new string(new char[128]);
        // Load message here ...
        return msg;
    }
    //</snippet51>
}

//<snippet50>
class MsgText
{
    [MarshalAs(UnmanagedType.LPWStr)]
    public string msg = "";
}
//</snippet50>
//</snippet48>
