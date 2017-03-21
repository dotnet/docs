            ' The sample first constructs a CultureInfo variable using the Greek culture - 'el'.
            Dim myCulture As New System.Globalization.CultureInfo("el")
            Dim myCString As String = "Russian"
            Console.WriteLine(TypeDescriptor.GetConverter(myCulture).ConvertTo(myCulture, GetType(String)))
            ' The following line will output 'ru' based on the string being converted.
            Console.WriteLine(TypeDescriptor.GetConverter(myCulture).ConvertFrom(myCString))