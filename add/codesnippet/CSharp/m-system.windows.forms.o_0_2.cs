        // Gets the caret width based upon the operating system or default value.
        private int GetCaretWidth ()
        {    

            // Check to see if the operating system supports the caret width metric. 
            if (OSFeature.IsPresent(SystemParameter.CaretWidthMetric))
            {

                // If the operating system supports this metric,
                // return the value for the caret width metric. 

                return SystemInformation.CaretWidth;
            } else

                // If the operating system does not support this metric,
                // return a custom default value for the caret width.

                return 1;
        }