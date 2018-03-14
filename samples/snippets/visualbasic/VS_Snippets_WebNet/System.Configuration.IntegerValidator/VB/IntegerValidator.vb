' <Snippet1>
Imports System
Imports System.Configuration

Namespace Microsoft.Samples.AspNet.Validators
    Module UsingIntegerValidator
        Public Sub Main()

            ' Display title.
            Console.WriteLine("ASP.NET Validators")
            Console.WriteLine()

            Console.WriteLine( _
                "Set mininum and maximum of 1 and 10 inclusive")

            ' <Snippet2>
            ' Create Validator for the range of 1 to 10 inclusive
            Dim minIntVal As Int32 = 1
            Dim maxIntVal As Int32 = 10
            Dim exclusive As Boolean = False
            Dim validator As IntegerValidator = _
                New IntegerValidator(minIntVal, maxIntVal, exclusive)
            ' </Snippet2>

            Dim testInt As Integer = 0
            ValidateInteger(validator, testInt)
            testInt = 1
            ValidateInteger(validator, testInt)
            testInt = 5
            ValidateInteger(validator, testInt)

            Console.WriteLine()
            Console.WriteLine( _
                "Set mininum and maximum of 1 and 10 exclusive")

            ' Create Validator for the range of 1 to 10 exclusive
            exclusive = True
            validator = _
                New IntegerValidator(minIntVal, maxIntVal, exclusive)

            testInt = 0
            ValidateInteger(validator, testInt)
            testInt = 1
            ValidateInteger(validator, testInt)
            testInt = 5
            ValidateInteger(validator, testInt)

            Console.WriteLine()
            Console.WriteLine( _
                "Determine if an object to validate can be validated.")

            Dim testObjectToValidate As Object = "a"
            ' <Snippet3>
            Console.WriteLine("Can validate object of type {0}: {1}", _
                testObjectToValidate.GetType(), _
                validator.CanValidate(testObjectToValidate.GetType()))
            ' </Snippet3>
            testObjectToValidate = New Integer()
            Console.WriteLine("Can validate object of type {0}: {1}", _
                testObjectToValidate.GetType(), _
                validator.CanValidate(testObjectToValidate.GetType()))

            ' Leave output on screen until enter is pressed.
            Console.ReadLine()
        End Sub

        Sub ValidateInteger(ByVal validator As IntegerValidator, ByVal valueToValidate As Integer)
            '<Snippet4>
            Console.Write("Validating integer value of {0}:  ", valueToValidate)
            Try
                validator.Validate(valueToValidate)
                Console.WriteLine("Validated.")
            Catch e As ArgumentException
                Console.WriteLine("Failed validation.  Message: {0}", e.Message.ToString())
            End Try
            '</Snippet4>
        End Sub
    End Module
End Namespace
' </Snippet1>