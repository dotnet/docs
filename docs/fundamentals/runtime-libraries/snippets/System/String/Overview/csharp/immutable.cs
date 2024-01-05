// <Snippet15>
using System;
using System.IO;
using System.Text;

public class Example6
{
   public static void Main()
   {
      Random rnd = new Random();
      
      string str = String.Empty;
      StreamWriter sw = new StreamWriter(@".\StringFile.txt", 
                           false, Encoding.Unicode);

      for (int ctr = 0; ctr <= 1000; ctr++) {
         str += (char)rnd.Next(1, 0x0530);
         if (str.Length % 60 == 0)
            str += Environment.NewLine;          
      }                    
      sw.Write(str);
      sw.Close();
   }
}
// </Snippet15>
