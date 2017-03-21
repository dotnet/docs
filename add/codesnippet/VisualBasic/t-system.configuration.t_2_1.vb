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

      ' Create TimeSpan and Validator.
      Dim testTimeSpan As TimeSpan = New TimeSpan(0, 1, 5)
      Dim minTimeSpan As TimeSpan = New TimeSpan(0, 1, 0)
      Dim maxTimeSpan As TimeSpan = New TimeSpan(0, 1, 10)
      Dim myTimeSpanValidator As TimeSpanValidator = _
       New TimeSpanValidator(minTimeSpan, maxTimeSpan, False, 65)

      ' Determine if the object to validate can be validated.
      Console.WriteLine("CanValidate: {0}", _
        myTimeSpanValidator.CanValidate(testTimeSpan.GetType()))

      Try
        ' Attempt validation.
        myTimeSpanValidator.Validate(testTimeSpan)
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