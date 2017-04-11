// <Snippet6>
using System;

public class FileName : IComparable
{
   string fname;
   StringComparer comparer; 
   
   public FileName(string name, StringComparer comparer)
   {
      if (String.IsNullOrEmpty(name))
         throw new ArgumentNullException("name");

      this.fname = name;
      
      if (comparer != null)
         this.comparer = comparer;
      else
         this.comparer = StringComparer.OrdinalIgnoreCase;
   }

   public string Name
   {
      get { return fname; }
   }
   
   public int CompareTo(object obj)
   {
      if (obj == null) return 1;

      if (! (obj is FileName))
         return comparer.Compare(this.fname, obj.ToString());
      else
         return comparer.Compare(this.fname, ((FileName) obj).Name);
   }
}
// </Snippet6>

public class Class1
{
   public static void Main()
   {
      FileName file1 = new FileName("autoexec.bat", null);
      FileName file2 = new FileName("AutoExec.BAT", null);
      Console.WriteLine(file1.CompareTo(file2));
   }
}
