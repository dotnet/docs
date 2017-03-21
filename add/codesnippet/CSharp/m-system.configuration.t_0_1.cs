
            ConfigurationValidatorBase valBase;
            TimeSpanValidatorAttribute tsValAttr;
            tsValAttr = new TimeSpanValidatorAttribute();

            TimeSpan goodValue = TimeSpan.FromMinutes(10);
            Int16 badValue = 10;

            try
            {
                valBase = tsValAttr.ValidatorInstance;
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