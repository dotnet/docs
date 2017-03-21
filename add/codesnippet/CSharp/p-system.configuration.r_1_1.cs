
            ConfigurationValidatorBase valBase;

            RegexStringValidatorAttribute rstrValAttr =
            new RegexStringValidatorAttribute(@"\w+\S*");

            // Get the regular expression string.
            string regex = rstrValAttr.Regex;
            Console.WriteLine("Regular expression: {0}", regex);
