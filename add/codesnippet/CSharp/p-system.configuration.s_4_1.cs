
            ConfigurationValidatorBase valBase;
            StringValidatorAttribute strValAttr =
            new StringValidatorAttribute();

            long badValue = 10;
            string goodValue = "10";

            try
            {
                valBase = strValAttr.ValidatorInstance;
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