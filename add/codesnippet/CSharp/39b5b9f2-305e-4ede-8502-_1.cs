            // Create Validator for the range of 1 to 10 inclusive
            int minIntVal = 1;
            int maxIntVal = 10;
            bool exclusive = false;
            IntegerValidator integerValidator =
                new IntegerValidator(minIntVal, maxIntVal, exclusive);