// <Snippet3>
using System;
using System.Globalization;
using System.Resources;
using System.Threading;

[assembly:NeutralResourcesLanguageAttribute("en-US")]

public class Example
{
   static string[] cultureNames = [ "fr-FR", "pt-BR", "ru-RU" ];

   public static void Main()
   {
      // Make any non-default culture the current culture.
      Random rnd = new Random();
      CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureNames[rnd.Next(0, cultureNames.Length)]);
      Thread.CurrentThread.CurrentUICulture = culture;
      Console.WriteLine($"The current culture is {CultureInfo.CurrentUICulture.Name}\n");
      CultureInfo enCulture = CultureInfo.CreateSpecificCulture("en-US");

      ResourceManager rm = new ResourceManager(typeof(NumberResources));
      Numbers numbers = (Numbers) rm.GetObject("Numbers");
      Numbers numbersEn = (Numbers) rm.GetObject("Numbers", enCulture);
      Console.WriteLine($"{numbers.One} --> {numbersEn.One}");
      Console.WriteLine($"{numbers.Three} --> {numbersEn.Three}");
      Console.WriteLine($"{numbers.Five} --> {numbersEn.Five}");
      Console.WriteLine($"{numbers.Seven} --> {numbersEn.Seven}");
      Console.WriteLine($"{numbers.Nine} --> {numbersEn.Nine}\n");
   }
}

internal class NumberResources
{
}
// The example displays output like the following:
//       The current culture is pt-BR
//
//       um --> one
//       três --> three
//       cinco --> five
//       sete --> seven
//       nove --> nine
// </Snippet3>

[Serializable] public class Numbers3
{
   public readonly string One;
   public readonly string Two;
   public readonly string Three;
   public readonly string Four;
   public readonly string Five;
   public readonly string Six;
   public readonly string Seven;
   public readonly string Eight;
   public readonly string Nine;
   public readonly string Ten;

   public Numbers3(string one, string two, string three, string four,
                  string five, string six, string seven, string eight,
                  string nine, string ten)
   {
      this.One = one;
      this.Two = two;
      this.Three = three;
      this.Four = four;
      this.Five = five;
      this.Six = six;
      this.Seven = seven;
      this.Eight = eight;
      this.Nine = nine;
      this.Ten = ten;
   }
}
