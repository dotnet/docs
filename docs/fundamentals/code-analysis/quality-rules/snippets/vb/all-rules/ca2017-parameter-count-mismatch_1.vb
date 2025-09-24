Imports Microsoft.Extensions.Logging

Namespace ca2017

    Public Class LoggingExample

        Private ReadOnly _logger As ILogger(Of LoggingExample)

        Public Sub New(logger As ILogger(Of LoggingExample))
            _logger = logger
        End Sub

        Public Sub ExampleMethod()
            Dim name As String = "Alice"
            Dim age As Integer = 30

            ' Violates CA2017: Too few arguments for placeholders
            _logger.LogInformation("User {Name} is {Age} years old and lives in {City}", name, age)

            ' Violates CA2017: Too many arguments for placeholders
            _logger.LogError("Error occurred: {Message}", "Something went wrong", "Extra argument")

            ' Correct usage: Matching number of placeholders and arguments
            _logger.LogInformation("User {Name} is {Age} years old", name, age)

            ' Correct usage: No placeholders, no arguments
            _logger.LogInformation("Application started")

            ' Correct usage: Single placeholder, single argument
            _logger.LogWarning("Failed to process {FileName}", "document.txt")
        End Sub

    End Class

End Namespace