Imports System
Imports System.Configuration

Namespace Microsoft.Samples.AspNet.Validators
  Class UsingRegexStringValidator
    Public Shared Sub Main()

      ' Display title.
      Console.WriteLine("ASP.NET Validators")
      Console.WriteLine()

      ' Create RegexString and Validator.
      Dim testString As String = "someone@example.com"
      Dim regexString As String = _
       "^[a-zA-Z\.\-_]+@([a-zA-Z\.\-_]+\.)+[a-zA-Z]{2,4}$"
      Dim myRegexValidator As RegexStringValidator = _ 
       New RegexStringValidator(regexString)

      ' Determine if the object to validate can be validated.
      Console.WriteLine("CanValidate: {0}", _
        myRegexValidator.CanValidate(testString.GetType()))

      Try
        ' Attempt validation.
        myRegexValidator.Validate(testString)
        Console.WriteLine("Validated.")

      Catch e As Exception
        ' Validation failed.
        Console.WriteLine("Error: {0}", e.Message.ToString())
      End Try

      ' Display and wait.
      Console.ReadLine()
    End Sub
  End Class
End Namespace