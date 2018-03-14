using System;
using System.Globalization;

namespace StringInterpolationTutorial
{
    public class Examples
    {
        public void StringFormatExample()
        {
            // <StringFormatExample>
            var firstName = "Matt";
            var lastName = "Groves";
            var str = String.Format("My name is {0} {1}", firstName, lastName);
            Console.WriteLine(str);
            // </StringFormatExample>
        }

        public void InterpolationExample()
        {
            // <InterpolationExample>
            var firstName = "Matt";
            var lastName = "Groves";
            var str = $"My name is {firstName} {lastName}";
            Console.WriteLine(str);
            // </InterpolationExample>
        }

        public void InterpolationExpressionExample()
        {
            // <InterpolationExpressionExample>
            for(var i = 0; i < 5; i++) {
                Console.WriteLine($"This is line number {i + 1}");
            }
            // </InterpolationExpressionExample>
        }

        public void InterpolationFormattingExample()
        {
            // <InterpolationFormattingExample>
            var rand = new Random();
            for(var i = 998; i < 1005; i++)
            {
                var randomDecimal = rand.NextDouble() * 10000;
                Console.WriteLine($"{i, -10} {randomDecimal, 6:N2}");
            }
            // </InterpolationFormattingExample>
        }

        public void InterpolationInternationalizationExample()
        {
            // <InterpolationInternationalizationExample>
            var birthday = new DateTime(1980, 1, 29);
            Console.WriteLine($"My birthday is {birthday}");
            // This outputs "My birthday is 1/29/1980 12:00:00 AM"

            var birthdayFormattable = (IFormattable)$"My birthday is {birthday}";
            Console.WriteLine(birthdayFormattable.ToString(null, new CultureInfo("fr-FR")));
            // This outputs "My birthday is 29/01/1980 00:00:00"
            // </InterpolationInternationalizationExample>
        }
    }
}