// <Snippet1>
using System;
using System.Text;

public class Example
{
   public static void Main()
   {
      Encoding enc = Encoding.GetEncoding(1253);
      Encoding altEnc = Encoding.GetEncoding("windows-1253");
      Console.WriteLine($"{enc.EncodingName} = Code Page {altEnc.CodePage}: {enc.Equals(altEnc)}");
      string greekAlphabet = "Α α Β β Γ γ Δ δ Ε ε Ζ ζ Η η " +
                             "Θ θ Ι ι Κ κ Λ λ Μ μ Ν ν Ξ ξ " +
                             "Ο ο Π π Ρ ρ Σ σ ς Τ τ Υ υ " +
                             "Φ φ Χ χ Ψ ψ Ω ω";
      Console.OutputEncoding = Encoding.UTF8;
      byte[] bytes = enc.GetBytes(greekAlphabet);
      Console.WriteLine("{0,-12} {1,20} {2,20:X2}", "Character",
                        "Unicode Code Point", "Code Page 1253");
      for (int ctr = 0; ctr < bytes.Length; ctr++) {
         if (greekAlphabet[ctr].Equals(' '))
            continue;

         Console.WriteLine("{0,-12} {1,20} {2,20:X2}", greekAlphabet[ctr],
                           GetCodePoint(greekAlphabet[ctr]), bytes[ctr]);
      }
   }

   private static string GetCodePoint(char ch)
   {
      string retVal = "u+";
      byte[] bytes = Encoding.Unicode.GetBytes(ch.ToString());
      for (int ctr = bytes.Length - 1; ctr >= 0; ctr--)
         retVal += bytes[ctr].ToString("X2");

      return retVal;
   }
}
// The example displays the following output:
//       Character      Unicode Code Point       Code Page 1253
//       Α                          u+0391                   C1
//       α                          u+03B1                   E1
//       Β                          u+0392                   C2
//       β                          u+03B2                   E2
//       Γ                          u+0393                   C3
//       γ                          u+03B3                   E3
//       Δ                          u+0394                   C4
//       δ                          u+03B4                   E4
//       Ε                          u+0395                   C5
//       ε                          u+03B5                   E5
//       Ζ                          u+0396                   C6
//       ζ                          u+03B6                   E6
//       Η                          u+0397                   C7
//       η                          u+03B7                   E7
//       Θ                          u+0398                   C8
//       θ                          u+03B8                   E8
//       Ι                          u+0399                   C9
//       ι                          u+03B9                   E9
//       Κ                          u+039A                   CA
//       κ                          u+03BA                   EA
//       Λ                          u+039B                   CB
//       λ                          u+03BB                   EB
//       Μ                          u+039C                   CC
//       μ                          u+03BC                   EC
//       Ν                          u+039D                   CD
//       ν                          u+03BD                   ED
//       Ξ                          u+039E                   CE
//       ξ                          u+03BE                   EE
//       Ο                          u+039F                   CF
//       ο                          u+03BF                   EF
//       Π                          u+03A0                   D0
//       π                          u+03C0                   F0
//       Ρ                          u+03A1                   D1
//       ρ                          u+03C1                   F1
//       Σ                          u+03A3                   D3
//       σ                          u+03C3                   F3
//       ς                          u+03C2                   F2
//       Τ                          u+03A4                   D4
//       τ                          u+03C4                   F4
//       Υ                          u+03A5                   D5
//       υ                          u+03C5                   F5
//       Φ                          u+03A6                   D6
//       φ                          u+03C6                   F6
//       Χ                          u+03A7                   D7
//       χ                          u+03C7                   F7
//       Ψ                          u+03A8                   D8
//       ψ                          u+03C8                   F8
//       Ω                          u+03A9                   D9
//       ω                          u+03C9                   F9
// </Snippet1>