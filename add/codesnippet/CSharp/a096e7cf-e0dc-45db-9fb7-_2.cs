using System;
using System.Resources;

public class CreateResource
{
   public static void Main()
   {
      Numbers en = new Numbers("one", "two", "three", "four", "five",
                               "six", "seven", "eight", "nine", "ten");
      CreateResourceFile(en, "en");
      Numbers fr = new Numbers("un", "deux", "trois", "quatre", "cinq", 
                               "six", "sept", "huit", "neuf", "dix");
      CreateResourceFile(fr, "fr");
      Numbers pt = new Numbers("um", "dois", "três", "quatro", "cinco", 
                               "seis", "sete", "oito", "nove", "dez");
      CreateResourceFile(pt, "pt"); 
      Numbers ru = new Numbers("один", "два", "три", "четыре", "пять", 
                               "шесть", "семь", "восемь", "девять", "десять");                                                       
      CreateResourceFile(ru, "ru");
   }

   public static void CreateResourceFile(Numbers n, string lang)
   {
      string filename = @".\NumberResources" + 
                        (lang != "en" ? "." + lang : "" ) +
                        ".resx";
      ResXResourceWriter rr = new ResXResourceWriter(filename);
      rr.AddResource("Numbers", n);
      rr.Generate();
      rr.Close();    
   }
}