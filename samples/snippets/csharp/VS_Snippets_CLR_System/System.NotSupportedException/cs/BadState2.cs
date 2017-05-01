// <Snippet2>
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      Encoding enc = Encoding.Unicode;
      String value = "This is a string to persist.";
      Byte[] bytes  = enc.GetBytes(value);

      FileStream fs = new FileStream(@".\TestFile.dat", 
                                     FileMode.Create,
                                     FileAccess.Write);
      Task t = fs.WriteAsync(enc.GetPreamble(), 0, enc.GetPreamble().Length);
      Task t2 = t.ContinueWith( (a) => fs.WriteAsync(bytes, 0, bytes.Length) ); 
      t2.Wait();
      fs.Close();
   }
}
// </Snippet2>

