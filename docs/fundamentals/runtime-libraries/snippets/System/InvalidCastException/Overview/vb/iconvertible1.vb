' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example2
    Public Sub Main()
        Dim flag As Boolean = True
        Try
            Dim conv As IConvertible = flag
            Dim ch As Char = conv.ToChar(Nothing)
            Console.WriteLine("Conversion succeeded.")
        Catch e As InvalidCastException
            Console.WriteLine("Cannot convert a Boolean to a Char.")
        End Try

        Try
            Dim ch As Char = Convert.ToChar(flag)
            Console.WriteLine("Conversion succeeded.")
        Catch e As InvalidCastException
            Console.WriteLine("Cannot convert a Boolean to a Char.")
        End Try
    End Sub
End Module
' The example displays the following output:
'       Cannot convert a Boolean to a Char.
'       Cannot convert a Boolean to a Char.
' </Snippet2>
