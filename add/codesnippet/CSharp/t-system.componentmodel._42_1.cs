            // The sample first constructs a CultureInfo variable using the Greek culture - 'el'.
            System.Globalization.CultureInfo myCulture= new System.Globalization.CultureInfo("el");
            string myCString="Russian";
            Console.WriteLine(TypeDescriptor.GetConverter(myCulture).ConvertTo(myCulture, typeof(string)));
            // The following line will output 'ru' based on the string being converted.
            Console.WriteLine(TypeDescriptor.GetConverter(myCulture).ConvertFrom(myCString));