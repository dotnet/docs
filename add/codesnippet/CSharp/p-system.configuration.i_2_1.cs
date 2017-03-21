
            ConfigurationValidatorBase valBase;
            IntegerValidatorAttribute intValAttr;
            intValAttr = new IntegerValidatorAttribute();

            long badValue = 10;
            int goodValue = 10;

            try
            {
                valBase = intValAttr.ValidatorInstance;
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