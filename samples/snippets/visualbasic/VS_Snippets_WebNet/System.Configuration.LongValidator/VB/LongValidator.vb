' <Snippet1>
Imports System
Imports System.Configuration

Namespace Microsoft.Samples.AspNet.Validators
  Class UsingLongValidator
    Public Shared Sub Main()

      ' Display title.
      Console.WriteLine("ASP.NET Validators")
      Console.WriteLine()

      ' <Snippet2>
      ' Create Long and Validator.
      Dim testLong As Int64 = 17592186044416
      Dim minLongVal As Int64 = 1099511627776
      Dim maxLongVal As Int64 = 281474976710656
      Dim myLongValidator As LongValidator = _
       New LongValidator(minLongVal, maxLongVal, False)
      ' </Snippet2>

      ' <Snippet3>
      ' Determine if the object to validate can be validated.
      Console.WriteLine("CanValidate: {0}", _
        myLongValidator.CanValidate(testLong.GetType()))
      ' </Snippet3>

      Try
        ' <Snippet4>
        ' Attempt validation.
        myLongValidator.Validate(testLong)
        ' </Snippet4>
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
' </Snippet1>