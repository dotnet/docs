// <Snippet1>
//
// The source code should be saved in a file named Example1.cs. It 
// can be compiled at the command line as follows:
//
//    csc /t:library /keyfile:<snkfilename> Assembly1.cs
//
// The public key of the Friend1 file should be changed to the full
// public key stored in your strong-named key file.
//
using System;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Friend1, PublicKey=002400000480000094" + 
                              "0000000602000000240000525341310004000" +
                              "001000100bf8c25fcd44838d87e245ab35bf7" +
                              "3ba2615707feea295709559b3de903fb95a93" +
                              "3d2729967c3184a97d7b84c7547cd87e435b5" +
                              "6bdf8621bcb62b59c00c88bd83aa62c4fcdd4" +
                              "712da72eec2533dc00f8529c3a0bbb4103282" +
                              "f0d894d5f34e9f0103c473dce9f4b457a5dee" +
                              "fd8f920d8681ed6dfcb0a81e96bd9b176525a" +
                              "26e0b3")]

public class FileUtilities
{
   internal static string AppendDirectorySeparator(string dir)
   {
      if (! dir.Trim().EndsWith(Path.DirectorySeparatorChar.ToString()))
         return dir.Trim() + Path.DirectorySeparatorChar;
      else
         return dir;
   }
}
// </Snippet1>
