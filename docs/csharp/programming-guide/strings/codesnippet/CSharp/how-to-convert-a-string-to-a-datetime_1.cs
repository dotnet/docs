            // Date strings are interpreted according to the current culture.
            // If the culture is en-US, this is interpreted as "January 8, 2008",
            // but if the user's computer is fr-FR, this is interpreted as "August 1, 2008"
            string date = "01/08/2008";
            DateTime dt = Convert.ToDateTime(date);            
            Console.WriteLine("Year: {0}, Month: {1}, Day: {2}", dt.Year, dt.Month, dt.Day);

            // Specify exactly how to interpret the string.
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);

            // Alternate choice: If the string has been input by an end user, you might 
            // want to format it according to the current culture:
            // IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            DateTime dt2 = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            Console.WriteLine("Year: {0}, Month: {1}, Day {2}", dt2.Year, dt2.Month, dt2.Day);

            /* Output (assuming first culture is en-US and second is fr-FR):
                Year: 2008, Month: 1, Day: 8
                Year: 2008, Month: 8, Day 1
             */