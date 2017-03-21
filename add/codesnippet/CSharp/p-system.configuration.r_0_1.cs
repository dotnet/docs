

            ConfigurationValidatorBase valBase;

            RegexStringValidatorAttribute rstrValAttr =
            new RegexStringValidatorAttribute(@"\w+\S*");

            // Get the regular expression string.
            string regex = rstrValAttr.Regex;
            Console.WriteLine("Regular expression: {0}", regex);


            string badValue = "&%$bbb";
            string goodValue = "filename.txt";

            try
            {
                valBase = rstrValAttr.ValidatorInstance;
                valBase.Validate(goodValue);
                // valBase.Validate(badValue);
            }
            catch (ArgumentException e)
            {
                // Display error message.
                string msg = e.ToString();
#if DEBUG
                Console.WriteLine(msg);
#endif
            }