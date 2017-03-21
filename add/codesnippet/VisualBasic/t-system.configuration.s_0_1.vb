Imports System
Imports System.Configuration

Namespace Samples.AspNet
  Class UsingStringValidator
    Public Shared Sub Main()

      ' Display title.
      Console.WriteLine("ASP.NET Validators")
      Console.WriteLine()

      ' Create string and validator.
      Dim testVal As String = "filename"
      Dim myStrValidator As StringValidator = New StringValidator(1, 8, "$%^")

      ' Determine if the object to validate can be validated.
      Console.WriteLine("CanValidate: {0}", _
        myStrValidator.CanValidate(testVal.GetType()))

      Try
        ' Attempt validation.
        myStrValidator.Validate(testVal)
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