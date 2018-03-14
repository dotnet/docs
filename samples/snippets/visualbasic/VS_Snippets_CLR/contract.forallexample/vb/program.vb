'<Snippet1>
Imports System
Imports System.Diagnostics.Contracts
Imports System.Collections.Generic


Class Program

    ' Start application with at least two arguments.
    Shared Sub Main(ByVal args() As String)
        args(1) = Nothing
        Contract.Requires(Not (args Is Nothing) AndAlso Contract.ForAll(args, Function(s) s Is Nothing))
        ' test the ForAll method.  This is only for purpose of demonstrating how ForAll works.
        CheckIndexes(args)
        Dim numbers As New Stack(Of String)
        numbers.Push("one")
        numbers.Push("two")
        numbers.Push("three")
        numbers.Push("four")
        numbers.Push("five")

        Contract.Requires(Not (numbers Is Nothing) AndAlso Not Contract.ForAll(numbers, Function(s) s Is Nothing))
        ' test the ForAll generic overload. This is only for purpose of demonstrating how ForAll works.
        CheckTypeArray(numbers)

    End Sub 'Main


    Private Shared Function CheckIndexes(ByVal args() As String) As Boolean
        Try
            If Not (args Is Nothing) AndAlso Not Contract.ForAll(0, args.Length, Function(i) args(i) Is Nothing) Then
                Throw New ArgumentException("The parameter array has a null element", "args")
            End If
            Return True
        Catch e As ArgumentException
            Console.WriteLine(e.Message)
            Return False
        End Try

    End Function 'CheckIndexes

    Private Shared Function CheckTypeArray(ByVal xs As Stack(Of String)) As Boolean

        Try
            If Not (xs Is Nothing) AndAlso Not Contract.ForAll(xs, Function(s) s Is Nothing) Then

                Throw New ArgumentException("The parameter array has a null element", "Stack")
            End If
            Return True

        Catch e As ArgumentException
            Console.WriteLine(e.Message)
            Return False
        End Try

    End Function 'CheckTypeArray
End Class 'Program
'</Snippet1>