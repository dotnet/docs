            // Report that the required argument is not present.
            const string ENTER_PARAM = "Enter the number of " +
                      "possibilities as a command line argument.";
            defaultListener.Fail(ENTER_PARAM);
            if (!defaultListener.AssertUiEnabled)
            {
                Console.WriteLine(ENTER_PARAM);
            }