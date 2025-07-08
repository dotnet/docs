// <Snippet5>
using System;
using System.Globalization;

public class Example4
{
   public static void Main()
   {
      String[] cultureNames = { "", "en-US", "fr-FR", "ru-RU" };
      foreach (var cultureName in cultureNames) {
         bool value = true;
         CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
         BooleanFormatter formatter = new BooleanFormatter(culture);

         string result = string.Format(formatter, "Value for '{0}': {1}", culture.Name, value);
         Console.WriteLine(result);
      }
   }
}

public class BooleanFormatter : ICustomFormatter, IFormatProvider
{
   private CultureInfo culture;

   public BooleanFormatter() : this(CultureInfo.CurrentCulture)
   { }

   public BooleanFormatter(CultureInfo culture)
   {
      this.culture = culture;
   }

   public Object GetFormat(Type formatType)
   {
      if (formatType == typeof(ICustomFormatter))
         return this;
      else
         return null;
   }

   public string Format(string fmt, Object arg, IFormatProvider formatProvider)
   {
      // Exit if another format provider is used.
      if (! formatProvider.Equals(this)) return null;

      // Exit if the type to be formatted is not a Boolean
      if (! (arg is Boolean)) return null;

      bool value = (bool) arg;
      switch (culture.Name) {
         case "en-US":
            return value.ToString();
         case "fr-FR":
            if (value)
               return "vrai";
            else
               return "faux";
         case "ru-RU":
            if (value)
               return "верно";
            else
               return "неверно";
         default:
            return value.ToString();
      }
   }
}
// The example displays the following output:
//       Value for '': True
//       Value for 'en-US': True
//       Value for 'fr-FR': vrai
//       Value for 'ru-RU': верно
// </Snippet5>
