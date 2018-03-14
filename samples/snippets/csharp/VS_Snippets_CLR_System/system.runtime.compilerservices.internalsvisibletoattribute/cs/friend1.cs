using System.IO;

// <Snippet2>
//
// The source code should be saved in a file named Friend1.cs. It 
// can be compiled at the command line as follows:
//
//    csc /r:Assembly1.dll /keyfile:<snkfilename> /out:Friend1.dll Friend1.cs
//
// The public key of the Friend1 assembly should correspond to the public key
// specified in the class constructor of the InternalsVisibleTo attribute in the
// Assembly1 assembly.
//
using System;

public class Example
{
   public static void Main()
   {
      string dir = @"C:\Program Files";
      dir = FileUtilities.AppendDirectorySeparator(dir);
      Console.WriteLine(dir);
   }
}
// The example displays the following output:
//       C:\Program Files\
// </Snippet2>


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
