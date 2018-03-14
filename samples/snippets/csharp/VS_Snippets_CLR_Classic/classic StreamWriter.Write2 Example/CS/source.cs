// <Snippet1>
using System;
using System.IO;
 
public class SWBuff 
{
    public static void Main(String[] args)
    {
        FileStream sb = new FileStream("MyFile.txt", FileMode.OpenOrCreate);
        char[] b = {'a','b','c','d','e','f','g','h','i','j','k','l','m'};
        StreamWriter sw = new StreamWriter(sb);
        sw.Write(b, 3, 8);
        sw.Close();
    }
}
// </Snippet1>

