            Console.Write("Validating integer value of {0}:  ", valueToValidate)
            Try
                validator.Validate(valueToValidate)
                Console.WriteLine("Validated.")
            Catch e As ArgumentException
                Console.WriteLine("Failed validation.  Message: {0}", e.Message.ToString())
            End Try