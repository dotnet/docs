// <Snippet14>
using System;
using System.Globalization;
using System.IO;
using System.Text;

public class Example13
{
   private static StreamWriter sw;
   
   public static void Main()
   {
      sw = new StreamWriter(@".\TestNorm1.txt");

      // Define three versions of the same word. 
      string s1 = "sống";        // create word with U+1ED1
      string s2 = "s\u00F4\u0301ng";
      string s3 = "so\u0302\u0301ng";

      TestForEquality(s1, s2, s3);      
      sw.WriteLine();

      // Normalize and compare strings using each normalization form.
      foreach (string formName in Enum.GetNames(typeof(NormalizationForm)))
      {
         sw.WriteLine("Normalization {0}:\n", formName); 
         NormalizationForm nf = (NormalizationForm) Enum.Parse(typeof(NormalizationForm), formName);
         string[] sn = NormalizeStrings(nf, s1, s2, s3);
         TestForEquality(sn);           
         sw.WriteLine("\n");                                        
      }
      
      sw.Close();   
   }

   private static void TestForEquality(params string[] words)
   {
      for (int ctr = 0; ctr <= words.Length - 2; ctr++)
         for (int ctr2 = ctr + 1; ctr2 <= words.Length - 1; ctr2++) 
            sw.WriteLine("{0} ({1}) = {2} ({3}): {4}", 
                         words[ctr], ShowBytes(words[ctr]),
                         words[ctr2], ShowBytes(words[ctr2]),
                         words[ctr].Equals(words[ctr2], StringComparison.Ordinal));
   }

   private static string ShowBytes(string str)
   {
      string result = null;
      foreach (var ch in str)
         result += $"{(ushort)ch:X4} ";
      return result.Trim();            
   } 
   
   private static string[] NormalizeStrings(NormalizationForm nf, params string[] words)
   {
      for (int ctr = 0; ctr < words.Length; ctr++)
         if (! words[ctr].IsNormalized(nf))
            words[ctr] = words[ctr].Normalize(nf); 
      return words;   
   }
}
// The example displays the following output:
//       sống (0073 1ED1 006E 0067) = sống (0073 00F4 0301 006E 0067): False
//       sống (0073 1ED1 006E 0067) = sống (0073 006F 0302 0301 006E 0067): False
//       sống (0073 00F4 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): False
//       
//       Normalization FormC:
//       
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
//       
//       
//       Normalization FormD:
//       
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
//       
//       
//       Normalization FormKC:
//       
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
//       
//       
//       Normalization FormKD:
//       
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
// </Snippet14>
