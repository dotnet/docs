// <Snippet1>
 using System;
 using System.IO;
 
 class TestRW 
 {
   public static void Main(String[] args)
   { 
     FileStream fs = new FileStream("MyFile.txt", FileMode.OpenOrCreate,
        FileAccess.Write);
     if (fs.CanRead && fs.CanWrite) {
         Console.WriteLine("MyFile.txt can be both written to and read from.");
     }
     else if (fs.CanWrite) {
         Console.WriteLine("MyFile.txt is writable.");
     }
   }
 }
 //This code outputs "MyFile.txt is writable."
 //To get the output message "MyFile.txt can be both written to and read from.",
 //change the FileAccess parameter to ReadWrite in the FileStream constructor.
// </Snippet1>

