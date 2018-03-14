using System;
using System.Runtime.InteropServices;

//
// Some interface
// 
[Guid("1F948D8D-D9ED-4CCC-BB61-5C1730E39EE9"),
InterfaceType(ComInterfaceType.InterfaceIsDual)]
interface ISomeIFace
{
}

public class MyObject : ISomeIFace
{
}

public partial class DispatchWrapperTest
{
    partial
    // <Snippet1>
    void MyMethod(Object o);

    public void DoWrap()
    {
        Object o = new MyObject();
        MyMethod(o);                      // passes o as VT_UNKNOWN
        MyMethod(new DispatchWrapper(o)); // passes o as VT_DISPATCH

        //...
    }
    // </Snippet1>

    public static void Main()
    {
    }
}