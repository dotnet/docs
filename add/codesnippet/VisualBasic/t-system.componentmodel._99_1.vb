        Try
            Dim licTest As License
            licTest = LicenseManager.Validate(GetType(Form1), Me)
        Catch licE As LicenseException
            Console.WriteLine(licE.Message)
            Console.WriteLine(licE.LicensedType)
            Console.WriteLine(licE.StackTrace)
            Console.WriteLine(licE.Source)
        End Try