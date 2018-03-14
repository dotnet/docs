// <Snippet1>
using System;
using System.IO;
 
class TestRW 
{
    public static void Main(String[] args)
    {
        FileStream fs = new FileStream("MyFile.txt", FileMode.OpenOrCreate, FileAccess.Read);
        if (fs.CanRead && fs.CanWrite)
        {
            Console.WriteLine("MyFile.txt can be both written to and read from.");
        }
        else if (fs.CanRead)
        {
            Console.WriteLine("MyFile.txt is not writable.");
        }
    }
}
// </Snippet1>