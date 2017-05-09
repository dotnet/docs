//<Snippet1>
using System;
using System.Security;


namespace TransparencyWarningsDemo
{

    public class UnverifiableMethodClass
    {
        // CA2137 violation - transparent method with unverifiable code.  This method should become critical or
        // safe critical 
    //    public unsafe byte[] UnverifiableMethod(int length)
    //    {
    //        byte[] bytes = new byte[length];
    //        fixed (byte* pb = bytes)
    //        {
    //            *pb = (byte)length;
    //        }

    //        return bytes;
    //    }
    }

}

//</Snippet1>