//<snippet1>
using System;
using System.Text;
using System.Runtime.InteropServices;


class Program
{

//Applied to a parameter.
  public void M1([MarshalAs(UnmanagedType.LPWStr)]String msg) {}


//Applied to a field within a class.
  class MsgText {
                [MarshalAs(UnmanagedType.LPWStr)]
                public String msg = "Hello World";
                }

//Applied to a return value.
[return: MarshalAs(UnmanagedType.LPWStr)]
    public String GetMessage()
    {
        return "Hello World";
    }


static void Main(string[] args)
    {  }
}
//</snippet1>